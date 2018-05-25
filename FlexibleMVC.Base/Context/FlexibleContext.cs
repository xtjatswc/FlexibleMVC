using FluentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.Base.Context
{
    public class FlexibleContext
    {
        public IDbContext db = new DbContext().ConnectionStringName("testDBContext", new MySqlProvider());
    }
}
