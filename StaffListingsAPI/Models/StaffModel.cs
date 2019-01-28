using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaffListingsAPI.Models
{
    public class StaffModel
    {
     
        public string EMPLOYEE_NUMBER { get; set; }
        public string NAME { get; set; }
        public string JOBTITLE { get; set; }
        public string DEPARTMENT { get; set; }
        public string EMAIL { get; set; }
        public string MOBILE_PHONE { get; set; }
        public string LOGON_NAME { get; set; }

    }
}