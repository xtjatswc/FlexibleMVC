using FluentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexibleMVC.Web.Areas.A.Model
{
    public class Class1
    {
        public static IDbContext GetDBContext()
        {
            return new DbContext().ConnectionStringName("testDBContext", new MySqlProvider());
        }
    }
}