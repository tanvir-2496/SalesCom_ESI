using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity.ViewModel
{
    public class EmployeeViewModel
    {
        public int EMPLOYEEID { get; set; }
        public string EMPLOYEENO { get; set; } // EmployeeId
        public string NAME { get; set; }
        public string EMAILADDRESS { get; set; }
        public string DEPARTMENT { get; set; }
        public int USERID { get; set; }
        public string UNIT { get; set; }
         public EmployeeViewModel()
        {

        }

         public EmployeeViewModel(DataRow dr)
        {
            if (dr["EMPLOYEEID"] != DBNull.Value) { this.EMPLOYEEID = Convert.ToInt32(dr["EMPLOYEEID"]); }
            if (dr["USERID"] != DBNull.Value) { this.USERID = Convert.ToInt32(dr["USERID"]); }
            this.EMPLOYEENO = dr["EMPLOYEENO"] as String;
            this.NAME = dr["NAME"] as String;
            this.EMAILADDRESS = dr["EMAILADDRESS"] as String;
            this.DEPARTMENT = dr["DEPARTMENT"] as String;
            this.UNIT = dr["UNIT"] as String;
        }
    }
}
