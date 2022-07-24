using System;
using System.Data;

namespace SalesCom.Entity
{
    public class SetupUserEnt
    {
        public Int64 NumId { get; set; }
        public string StrUserCode { get; set; }
        public string StrLoginName { get; set; }
        public string StrFullName { get; set; }
        public string StrDesignation { get; set; }
        public string StrPassword { get; set; }
        public string StrDepartment { get; set; }
        public string StrEmail { get; set; }
        public string StrPhone { get; set; }

        public Int64 NumCreateUser { get; set; }
        public DateTime DtcreateDate { get; set; }
        public Int64 NumEditUser { get; set; }
        public DateTime DtEditDate { get; set; }

        public SetupUserEnt() { }

        public SetupUserEnt(DataRow dr)
        {
            if (dr["NUMID"] != DBNull.Value) { this.NumId = Convert.ToInt64(dr["NUMID"]); }
            this.StrUserCode = dr["STRUSERCODE"] as String;
            this.StrLoginName = dr["STRLOGINNAME"] as String;
            this.StrFullName = dr["STRFULLNAME"] as String;
            this.StrDesignation = dr["STRDESIGNATION"] as String;
            this.StrPassword = dr["STRPASSWORD"] as String;
            this.StrDepartment = dr["STRDEPARTMENT"] as String;
            this.StrEmail = dr["STREMAIL"] as String;
            this.StrPhone = dr["STRPHONE"] as String;
            if (dr["NUMCREATEUSER"] != DBNull.Value) { this.NumCreateUser = Convert.ToInt64(dr["NUMCREATEUSER"]); }
            if (dr["DTCREATEDATE"] != DBNull.Value) { this.DtcreateDate = Convert.ToDateTime(dr["DTCREATEDATE"]); }
            if (dr["NUMEDITUSER"] != DBNull.Value) { this.NumEditUser = Convert.ToInt64(dr["NUMEDITUSER"]); }
            if (dr["DTEDITDATE"] != DBNull.Value) { this.DtEditDate = Convert.ToDateTime(dr["DTEDITDATE"]); }
        }
    }
}
