using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class StageUserAssignmentViewEnt
    {
        public Int64 SerialNo { get; set; }
        public Int64 NumId { get; set; }
        public Int64 ProcessId { get; set; }
        public string ProcessName { get; set; }
        public Int64 StageId { get; set; }
        public string StageName { get; set; }
        public Int64 StageOrder { get; set; }
        public Int64 UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Int64 ReceiveeMail { get; set; }
        public Int64 ReceivePhone { get; set; }

        public Int64 CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public Int64 EditUser { get; set; }
        public DateTime EditDate { get; set; }


        public StageUserAssignmentViewEnt() { }

        public StageUserAssignmentViewEnt(DataRow dr)
        {
            if (dr["NUMID"] != DBNull.Value) { this.NumId = Convert.ToInt64(dr["NUMID"]); }
            this.ProcessName = dr["PROCESSNAME"] as String;
            if (dr["STAGEID"] != DBNull.Value) { this.StageId = Convert.ToInt64(dr["STAGEID"]); }
            this.StageName = dr["STAGENAME"] as String;
            if (dr["STAGEORDER"] != DBNull.Value) { this.StageOrder = Convert.ToInt64(dr["STAGEORDER"]); }
            this.UserName = dr["USERNAME"] as String;
            this.Email = dr["EMAIL"] as String;
            this.Phone = dr["PHONE"] as String;
        }
    }
}
