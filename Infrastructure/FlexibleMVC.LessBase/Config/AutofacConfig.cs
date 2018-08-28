using Autofac;
using Autofac.Integration.Mvc;
using FlexibleMVC.Base.Jwt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace FlexibleMVC.LessBase.Config
{
    public class AutofacConfig
    {
        /// <summary>
        /// 负责调用autofac框架实现业务逻辑层和数据仓储层程序集中的类型对象的创建
        /// 负责创建MVC控制器类的对象(调用控制器中的有参构造函数),接管DefaultControllerFactory的工作
        /// </summary>
        public static void Register()
        {
            //实例化一个autofac的创建容器
            var builder = new ContainerBuilder();

            string[] ctrls = new string[] { "FlexibleMVC.Web", "FlexibleMVC.Web.Admin", "FlexibleMVC.Web.Frond", "FlexibleMVC.LessBase" };
            foreach (var ctrl in ctrls)
            {
                //告诉Autofac框架，将来要创建的控制器类存放在哪个程序集
                Assembly controllerAss = Assembly.Load(ctrl);
                builder.RegisterControllers(controllerAss);
            }

            //InstancePerRequest() 针对MVC的,或者说是ASP.NET的..每个请求单例
            //builder.RegisterType<JwtResult>().InstancePerRequest();
            //builder.RegisterType<FlexibleMVC.LessBase.Context.LessFlexibleContext>().InstancePerRequest();
            //builder.RegisterType<FlexibleMVC.Base.Context.FlexibleContext>().InstancePerRequest();

            Assembly serviceBase = Assembly.Load("FlexibleMVC.Base");
            builder.RegisterTypes(serviceBase.GetTypes()).InstancePerRequest();

            Assembly serviceLessBase = Assembly.Load("FlexibleMVC.LessBase");
            builder.RegisterTypes(serviceLessBase.GetTypes()).InstancePerRequest();

            //如果有Dal层的话，注册Dal层的组件
            //告诉autofac框架注册数据仓储层所在程序集中的所有类的对象实例
            Assembly dalAss = Assembly.Load("FlexibleMVC.DAL");
            //创建respAss中的所有类的instance以此类的实现接口存储
            builder.RegisterTypes(dalAss.GetTypes()).AsImplementedInterfaces();
            builder.RegisterTypes(dalAss.GetTypes()).InstancePerRequest();

            //告诉autofac框架注册业务逻辑层所在程序集中的所有类的对象实例
            Assembly serviceAss = Assembly.Load("FlexibleMVC.BLL");
            //创建serAss中的所有类的instance以此类的实现接口存储
            //builder.RegisterTypes(serviceAss.GetTypes()).AsImplementedInterfaces();
            builder.RegisterTypes(serviceAss.GetTypes()).PropertiesAutowired().InstancePerRequest();

            //加载插件目录
            var execution_path = AppDomain.CurrentDomain.BaseDirectory + "bin\\plugins\\";
            var plugin_filename = "Plugin";

            var d = new DirectoryInfo(execution_path);
            var pluginDlls = (from FileInfo fi in d.GetFiles()
                              where (
                                  fi.FullName.EndsWith(plugin_filename + ".dll")
                              )
                              select fi).ToList();
            foreach (var plugin in pluginDlls)
            {
                Assembly assPlugin = Assembly.LoadFile(plugin.FullName);
                builder.RegisterTypes(assPlugin.GetTypes()).AsImplementedInterfaces().PropertiesAutowired().InstancePerRequest();
            }

            //创建一个Autofac的容器
            var container = builder.Build();
            //将MVC的控制器对象实例 交由autofac来创建
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}