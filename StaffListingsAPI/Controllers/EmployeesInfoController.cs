using StaffListingsAPI.Models;
using System.Collections.Generic;
using System.Web.Http;
using Oracle.ManagedDataAccess.Client;
using System;

namespace StaffListingsAPI.Controllers
{
    public class EmployeesInfoController : ApiController
    {
        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["EmployeesDetailsCon"].ConnectionString;


        [HttpGet]
        [Route("api/EmployeeInfo/GetAllEmployees")]
        public IEnumerable<StaffModel> GetAllEmployees()
        {
            OracleConnection orclCon = new OracleConnection(connstring);
            StaffModel StaffDetails = new StaffModel();
           


            string Query = @"select * from ods.src_vw_employeeinfodiv";
            //employee_number,name,jobtitle,department,email,mobile_phone,logon_name

            OracleCommand cmd = new OracleCommand(Query, orclCon);
            orclCon.Open();
            OracleDataReader rdr = cmd.ExecuteReader();

            //The Output Model initialization
            List<StaffModel> staffList = new List<StaffModel>();

            while (rdr.Read())
            {
                StaffDetails.EMPLOYEE_NUMBER = rdr["EMPLOYEE_NUMBER"].ToString();
                StaffDetails.NAME = rdr["NAME"].ToString();
                StaffDetails.JOBTITLE = rdr["JOBTITLE"].ToString();
                StaffDetails.DEPARTMENT= rdr["DEPT"].ToString();
                StaffDetails.EMAIL = rdr["EMAIL"].ToString();
                StaffDetails.MOBILE_PHONE = rdr["MOBILE_PHONE"].ToString();
                StaffDetails.LOGON_NAME = rdr["LOGON_NAME"].ToString();

                staffList.Add(StaffDetails);
            }

            return staffList;
        }
        
    }
}
