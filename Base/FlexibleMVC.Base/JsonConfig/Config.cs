//
using System;
using System.Linq;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.IO;

using System.Text.RegularExpressions;

namespace FlexibleMVC.Base.JsonConfig
{
    public static class Config
    {
        public static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static dynamic Default = new ConfigObject();
        public static dynamic User = new ConfigObject();

        public static dynamic MergedConfig
        {
            get
            {
                return Merger.Merge(User, Default);
            }
        }

        public static string defaultEnding = ".conf";

        private static dynamic global_config;
        public static dynamic Global
        {
            get
            {
                if (global_config == null)
                {
                    global_config = MergedConfig;
                }
                return global_config;
            }
            set
            {
                global_config = Merger.Merge(value, MergedConfig);
            }
        }

        /// <summary>
        /// Gets a ConfigObject that represents the current configuration. Since it is 
        /// a cloned copy, changes to the underlying configuration files that are done
        /// after GetCurrentScope() is called, are not applied in the returned instance.
        /// </summary>
        public static ConfigObject GetCurrentScope()
        {
            if (Global is NullExceptionPreventer)
                return new ConfigObject();
            else
                return Global.Clone();
        }

        public delegate void UserConfigFileChangedHandler();
        public static event UserConfigFileChangedHandler OnUserConfigFileChanged;

        static Config()
        {
            // static C'tor, run once to check for compiled/embedded config

            // scan ALL linked assemblies and merge their default configs while
            // giving the entry assembly top priority in merge
            try
            {
                var entryAssembly = Assembly.GetEntryAssembly();
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var assembly in assemblies.Where(assembly => !assembly.Equals(entryAssembly) && assembly.GetName().Name.StartsWith("FlexibleMVC")))
                {
                    Default = Merger.Merge(GetDefaultConfig(assembly), Default);
                }
                if (entryAssembly != null)
                    Default = Merger.Merge(GetDefaultConfig(entryAssembly), Default);

                // User config (provided through a settings.conf file)
                var execution_path = AppDomain.CurrentDomain.BaseDirectory;
                var user_config_filename = "settings";

                var d = new DirectoryInfo(execution_path);
                var userConfig = (from FileInfo fi in d.GetFiles()
                                  where (
                                      fi.FullName.EndsWith(user_config_filename + ".conf") ||
                                      fi.FullName.EndsWith(user_config_filename + ".json") ||
                                      fi.FullName.EndsWith(user_config_filename + ".conf.json") ||
                                      fi.FullName.EndsWith(user_config_filename + ".json.conf")
                                  )
                                  select fi).FirstOrDefault();

                if (userConfig != null)
                {
                    User = Config.ParseJson(File.ReadAllText(userConfig.FullName));
                    WatchUserConfig(userConfig);
                }
                else
                {
                    User = new NullExceptionPreventer();
                }

            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

        }
        private static FileSystemWatcher userConfigWatcher;
        public static void WatchUserConfig(FileInfo info)
        {
            var lastRead = File.GetLastWriteTime(info.FullName);
            userConfigWatcher = new FileSystemWatcher(info.Directory.FullName, info.Name);
            userConfigWatcher.NotifyFilter = NotifyFilters.LastWrite;
            userConfigWatcher.Changed += delegate
            {
                DateTime lastWriteTime = File.GetLastWriteTime(info.FullName);
                if (lastWriteTime.Subtract(lastRead).TotalMilliseconds > 100)
                {
                    Console.WriteLine("user configuration has changed, updating config information");
                    try
                    {
                        User = (ConfigObject)ParseJson(File.ReadAllText(info.FullName));
                    }
                    catch (IOException)
                    {
                        System.Threading.Thread.Sleep(100); //Sleep shortly, and try again.
                        try
                        {
                            User = (ConfigObject)ParseJson(File.ReadAllText(info.FullName));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("updating user config failed.");
                            throw;
                        }
                    }



                    // invalidate the Global config, forcing a re-merge next time its accessed
                    global_config = null;

                    // trigger our event
                    if (OnUserConfigFileChanged != null)
                        OnUserConfigFileChanged();
                }
                lastRead = lastWriteTime;
            };
            userConfigWatcher.EnableRaisingEvents = true;
        }
        public static ConfigObject ApplyJsonFromFileInfo(FileInfo file, ConfigObject config = null)
        {
            var overlay_json = File.ReadAllText(file.FullName);
            dynamic overlay_config = ParseJson(overlay_json);
            return Merger.Merge(overlay_config, config);
        }
        public static ConfigObject ApplyJsonFromPath(string path, ConfigObject config = null)
        {
            return ApplyJsonFromFileInfo(new FileInfo(path), config);
        }
        public static ConfigObject ApplyJson(string json, ConfigObject config = null)
        {
            if (config == null)
                config = new ConfigObject();

            dynamic parsed = ParseJson(json);
            return Merger.Merge(parsed, config);
        }
        // seeks a folder for .conf files
        public static ConfigObject ApplyFromDirectory(string path, ConfigObject config = null, bool recursive = false)
        {
            if (!Directory.Exists(path))
                throw new Exception("no folder found in the given path");

            if (config == null)
                config = new ConfigObject();

            DirectoryInfo info = new DirectoryInfo(path);
            if (recursive)
            {
                foreach (var dir in info.GetDirectories())
                {
                    Console.WriteLine("reading in folder {0}", dir.ToString());
                    config = ApplyFromDirectoryInfo(dir, config, recursive);
                }
            }

            // find all files
            var files = info.GetFiles();
            foreach (var file in files)
            {
                Console.WriteLine("reading in file {0}", file.ToString());
                config = ApplyJsonFromFileInfo(file, config);
            }
            return config;
        }
        public static ConfigObject ApplyFromDirectoryInfo(DirectoryInfo info, ConfigObject config = null, bool recursive = false)
        {
            return ApplyFromDirectory(info.FullName, config, recursive);
        }

        public static ConfigObject ParseJson(string json)
        {
            #region 去除带#的注释
            var lines = json.Split(new char[] { '\n' });
            // remove lines that start with a dash # character 
            var filtered = from l in lines
                           where !(Regex.IsMatch(l, @"^\s*#(.*)"))
                           select l;

            var filtered_json = string.Join("\n", filtered);
            #endregion

            ExpandoObject parsed = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(filtered_json);
            // convert the ExpandoObject to ConfigObject before returning
            var result = ConfigObject.FromExpando(parsed);
            return result;
        }
        // overrides any default config specified in default.conf
        public static void SetDefaultConfig(dynamic config)
        {
            Default = config;

            // invalidate the Global config, forcing a re-merge next time its accessed
            global_config = null;
        }
        public static void SetUserConfig(ConfigObject config)
        {
            User = config;
            // disable the watcher
            if (userConfigWatcher != null)
            {
                userConfigWatcher.EnableRaisingEvents = false;
                userConfigWatcher.Dispose();
                userConfigWatcher = null;
            }

            // invalidate the Global config, forcing a re-merge next time its accessed
            global_config = null;
        }
        private static dynamic GetDefaultConfig(Assembly assembly)
        {
            var dconf_json = ScanForDefaultConfig(assembly);
            if (dconf_json == null || dconf_json.Count == 0)
                return null;

            ConfigObject cfg = new ConfigObject();
            foreach (var dconf in dconf_json)
            {
                cfg = Merger.Merge(ParseJson(dconf), cfg);
            }

            return cfg;
        }
        private static List<string> ScanForDefaultConfig(Assembly assembly)
        {
            if (assembly == null)
                assembly = System.Reflection.Assembly.GetEntryAssembly();

            string[] res;
            try
            {
                // this might fail for the 'Anonymously Hosted DynamicMethods Assembly' created by an Reflect.Emit()
                res = assembly.GetManifestResourceNames();
            }
            catch
            {
                // for those assemblies, we don't provide a config
                return null;
            }
            var dconf_resource = res.Where(r =>
                   r.EndsWith("default.conf", StringComparison.OrdinalIgnoreCase) ||
                   r.EndsWith("default.json", StringComparison.OrdinalIgnoreCase) ||
                   r.EndsWith("default.conf.json", StringComparison.OrdinalIgnoreCase));
            //去掉.FirstOrDefault()这里不限制配置文件的数量

            List<string> lstConf = new List<string>();
            foreach (var dconf in dconf_resource)
            {
                if (string.IsNullOrEmpty(dconf))
                    continue;

                var stream = assembly.GetManifestResourceStream(dconf);
                string default_json = new StreamReader(stream).ReadToEnd();
                lstConf.Add(default_json);

            }

            return lstConf;
        }
    }
}
