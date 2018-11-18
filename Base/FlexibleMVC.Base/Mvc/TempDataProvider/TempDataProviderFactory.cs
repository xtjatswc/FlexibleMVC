using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace FlexibleMVC.Base.Mvc.TempDataProvider
{
    internal class TempDataProviderFactory
    {
        public static ITempDataProvider GetProvider(long type)
        {
            ITempDataProvider tempDataProvider = null;
            switch (type)
            {
                case 1:
                    {
                        tempDataProvider = new CacheTempDataProvider();
                        break;
                    }
                case 2:
                    {
                        tempDataProvider = new TokenCacheTempDataProvider();
                        break;
                    }
                case 3:
                    {
                        tempDataProvider = new MemcachedTempDataProvider();
                        break;
                    }
                default:
                    tempDataProvider = new SessionStateTempDataProvider();
                    break;
            }

            return tempDataProvider;
        }
    }
}
