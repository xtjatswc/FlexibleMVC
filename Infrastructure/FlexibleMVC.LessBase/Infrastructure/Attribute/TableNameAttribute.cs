using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FlexibleMVC.LessBase.Infrastructure.Attribute
{
    public class TableNameAttribute : DescriptionAttribute
    {
        public TableNameAttribute(string description) : base(description)
        { }
    }
}
