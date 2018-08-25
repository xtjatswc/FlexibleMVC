using FlexibleMVC.DAL;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Infrastructure;

namespace FlexibleMVC.BLL
{
    public class PatientBll : BaseBLL
    {
        public PatientDal patientDal { get; set; }
        public FoodDal foodDal { get; set; }

    }
}
