using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Model;
using System.Collections.Generic;

namespace FlexibleMVC.DAL
{
    public class PatientDal : BaseDAL<PatientBasicInfo>
    {
        protected override string TableName { get => "PatientBasicInfo";}

        public List<PatientBasicInfo> GetPatients()
        {
            List<PatientBasicInfo> list = lessContext.db.Sql(@"select * from patientbasicinfo limit 30 ").QueryMany<PatientBasicInfo>();
            return list;
        }

    }
}
