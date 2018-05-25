using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Model;
using System.Collections.Generic;

namespace FlexibleMVC.DAL
{
    public class PatientDal : BaseDAL
    {
        public List<PatientBasicInfo> GetPatients()
        {
            List<PatientBasicInfo> list = flexibleContext.db.Sql(@"select * from patientbasicinfo limit 30 ").QueryMany<PatientBasicInfo>();
            return list;
        }

    }
}
