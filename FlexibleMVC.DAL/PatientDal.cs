using FlexibleMVC.Base.Infrastructure;
using FlexibleMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
