using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static FlexibleMVC.Base.JsonConfig.Config;

namespace FlexibleMVC.LessBase.Config
{
    public class LessConfig
    {
        public static readonly string AttachmentPath;
        public static readonly string ConfigPath;
        public static readonly string DbPath;

        static LessConfig()
        {
            //从文件目录加载用户配置
            var execution_path = AppDomain.CurrentDomain.BaseDirectory;
            AttachmentPath = new DirectoryInfo(execution_path).Parent.FullName + @"\FlexibleMVC_Attachment\";
            ConfigPath = AttachmentPath + @"config\";
            DbPath = AttachmentPath + @"db\";
            User = ApplyFromDirectory(ConfigPath, User, true);

        }

        public static string AdminLTE_Path { get { return Global.LessBase.adminLTE.Path; } }
        public static string MiniUI_Path { get { return Global.LessBase.miniui.Path; } }

        public static string db1 { get { return Global.DataBases.db1; } }

        private static string _db2;
        public static string db2
        {
            get
            {
                if (string.IsNullOrEmpty(_db2))
                {
                    //Password=asdf1234;
                    _db2 = string.Format(Global.DataBases.db2.ToString(), DbPath, "");
                }
                return _db2;
            }
        }

        public static string Copyright { get { return Global.LessBase.SystemInfo.Copyright; } }
        public static string Version { get { return Global.LessBase.SystemInfo.Version; } }

    }
}
