using FlexibleMVC.Base.Context;
using FlexibleMVC.Base.Infrastructure;
using FlexibleMVC.DAL;
using FlexibleMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.BLL
{
    public class PatientBll : BaseBLL
    {
        PatientDal patientDal = new PatientDal();

        public override FlexibleContext flexibleContext
        {
            get
            {
                return base.flexibleContext;
            }
            set
            {
                base.flexibleContext = value;
                patientDal.flexibleContext = value;
            }
        }

        public List<PatientBasicInfo> GetPatients()
        {
            return patientDal.GetPatients();
        }
    }
}
