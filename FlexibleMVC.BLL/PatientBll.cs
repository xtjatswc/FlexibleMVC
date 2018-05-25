using FlexibleMVC.DAL;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Infrastructure;

namespace FlexibleMVC.BLL
{
    public class PatientBll : BaseBLL
    {
        public PatientDal dal = new PatientDal();

        public override LessFlexibleContext lessContext
        {
            get
            {
                return base.lessContext;
            }
            set
            {
                base.lessContext = value;
                dal.flexibleContext = value;
            }
        }
    }
}
