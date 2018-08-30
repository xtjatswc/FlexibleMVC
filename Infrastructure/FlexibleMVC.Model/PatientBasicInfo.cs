using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.LessBase.Infrastructure.Attribute;
using System;

namespace FlexibleMVC.Model
{
    public class PatientBasicInfo : BaseModel
    {
        [PrimaryKey()]
        public Int64 PATIENT_DBKEY { get; set; }
        public String PatientNo { get; set; }
        public String PatientName { get; set; }
        public String PatientNameFirstLetter { get; set; }
        public String Gender { get; set; }
        public Single Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Credential { get; set; }
        public String IDNumber { get; set; }
        public String Peoples { get; set; }
        public String NativePlace { get; set; }
        public String MaritalStatus { get; set; }
        public String TelPhone { get; set; }
        public String MobilePhone { get; set; }
        public String Email { get; set; }
        public String HomeAddress { get; set; }
        public String ZipCode { get; set; }
        public String Job { get; set; }
        public String WorkCompany { get; set; }
        public String UrgentContactName { get; set; }
        public String UrgentContactTelPhone { get; set; }
        public String Relationship { get; set; }
        public String CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public String CreateProgram { get; set; }
        public String CreateIP { get; set; }
        public String UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public String UpdateProgram { get; set; }
        public String UpdateIP { get; set; }
    }
}
