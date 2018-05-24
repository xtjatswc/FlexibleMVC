using FlexibleMVC.Base.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace FlexibleMVC.Base
{
    public abstract class BaseAreaRegistration : AreaRegistration
    {
        public abstract string Namespace { get; }
        public abstract string ModuleName { get; }
        public override string AreaName { get; }

        private AreaRegistrationContext context;
        private string prefix;
        private MvcType mvcType;

        enum MvcType
        {
            None = 0,
            Area = 1,
            Module = 2,
            ModuleAndArea = 3,
        }

        public BaseAreaRegistration()
        {
            if (string.IsNullOrEmpty(ModuleName) && AreaName.Equals(MvcConst.ROOT_AREANAME))
            {
                prefix = "";
                mvcType = MvcType.None;
            }
            else if (string.IsNullOrEmpty(ModuleName) && !AreaName.Equals(MvcConst.ROOT_AREANAME))
            {
                prefix = AreaName + "_";
                mvcType = MvcType.Area;
            }
            else if (!string.IsNullOrEmpty(ModuleName) && AreaName.Equals(MvcConst.ROOT_AREANAME))
            {
                prefix = ModuleName + "_";
                mvcType = MvcType.Module;
            }
            else if (!string.IsNullOrEmpty(ModuleName) && !AreaName.Equals(MvcConst.ROOT_AREANAME))
            {
                prefix = ModuleName + "_" + AreaName + "_";
                mvcType = MvcType.ModuleAndArea;
            }
        }

        public void MapRoute(string name, string url, object defaults, object constraints = null)
        {
            if (constraints == null)
            {
                switch (mvcType)
                {
                    case MvcType.None:
                        constraints = new { area = new BaseRouteConstraint() { ModuleName = ModuleName, AreaName = AreaName } };
                        break;
                    case MvcType.Area:
                        constraints = new { area = new BaseAreaRouteConstraint() { ModuleName = ModuleName, AreaName = AreaName } };
                        break;
                    case MvcType.Module:
                        constraints = new { area = new BaseModuleRouteConstraint() { ModuleName = ModuleName, AreaName = AreaName } };
                        break;
                    case MvcType.ModuleAndArea:
                        constraints = new { area = new BaseModuleAreaRouteConstraint() { ModuleName = ModuleName, AreaName = AreaName } };
                        break;
                    default:
                        break;
                }

            }

            string namespa = "";
            if (AreaName.Equals(MvcConst.ROOT_AREANAME))
            {
                namespa = Namespace + ".Controllers";
            }
            else
            {
                namespa = Namespace + ".Areas." + AreaName + ".Controllers";
            }

            context.MapRoute(
                    name: prefix + name,
                    url: prefix + url,
                    defaults: defaults,
                    namespaces: new string[] { namespa },
                    constraints: constraints
                );

        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            this.context = context;
        }
    }
}
