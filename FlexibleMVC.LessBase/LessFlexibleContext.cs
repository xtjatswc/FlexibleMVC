using FlexibleMVC.Base.Context;
using FlexibleMVC.BLL;
using FluentData;

namespace FlexibleMVC.LessBase
{
    public class LessFlexibleContext : FlexibleContext
    {
        public FlexibleContext Base { get; set; }

        public IDbContext db = new DbContext().ConnectionStringName("testDBContext", new MySqlProvider());

        private PatientBll _patientBll;
        public PatientBll PatientBll
        {
            get
            {
                if (_patientBll == null)
                    _patientBll = new PatientBll { flexibleContext = this };
                return _patientBll;
            }
        }

    }
}
