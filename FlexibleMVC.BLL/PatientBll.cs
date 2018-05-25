using FlexibleMVC.DAL;
using FlexibleMVC.LessBase;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Model;
using System.Collections.Generic;

namespace FlexibleMVC.BLL
{
    public class PatientBll : BaseBLL
    {
        PatientDal patientDal = new PatientDal();

        public override LessFlexibleContext flexibleContext
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
