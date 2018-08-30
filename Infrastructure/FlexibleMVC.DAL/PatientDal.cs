using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Model;
using System.Collections.Generic;
using FlexibleMVC.LessBase.Context;
using FluentData;

namespace FlexibleMVC.DAL
{
    public class PatientDal : BaseDAL<PatientBasicInfo>
    {
        public PatientDal(LessFlexibleContext lessContext) : base(lessContext)
        {
            Db = lessContext.db;
        }

    }
}
