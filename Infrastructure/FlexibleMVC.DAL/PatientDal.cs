using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Model;
using System.Collections.Generic;
using FlexibleMVC.LessBase.Context;

namespace FlexibleMVC.DAL
{
    public class PatientDal : BaseDAL<PatientBasicInfo>
    {
        public PatientDal(LessFlexibleContext lessContext) : base(lessContext)
        {
        }

        protected override string TableName { get => "PatientBasicInfo"; }

        protected override string PrimaryKey { get => "PATIENT_DBKEY"; }
    }
}
