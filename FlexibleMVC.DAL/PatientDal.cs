using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Model;
using System.Collections.Generic;

namespace FlexibleMVC.DAL
{
    public class PatientDal : BaseDAL<PatientBasicInfo>
    {
        protected override string TableName { get => "PatientBasicInfo"; }

        protected override string PrimaryKey { get => "PATIENT_DBKEY"; }
    }
}
