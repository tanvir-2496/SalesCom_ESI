using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ESI.Entity
{
    public class ApprovalHistoryEnt
    {
        public int approval_status_log_id { get; set; }
        public string approvallevelname { get; set; }
        public string status { get; set; }
        public string comments { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set; }
        public DateTime create_date { get; set; }
        public string ftype { get; set; }
        public byte?[] srcontent { get; set; }

        public ApprovalHistoryEnt() { }

        public ApprovalHistoryEnt(DataRow dr)
        {
            if (dr["approval_status_log_id"] != DBNull.Value) this.approval_status_log_id = Convert.ToInt32(dr["approval_status_log_id"]);
            this.approvallevelname = dr["approvallevelname"] as String;
            this.status = dr["status"] as String;
            this.comments = dr["comments"] as String;
            if (dr["user_id"] != DBNull.Value) this.user_id = Convert.ToInt32(dr["user_id"]);
            this.user_name = dr["user_name"] as String;
            this.ftype = dr["ftype"] as String;
            //this.user_name = dr["user_name"] as String;
            //this.srcontent = dr["srcontent"] as Byte;
            this.srcontent = dr["srcontent"] as Byte?[];
            if (dr["create_date"] != DBNull.Value) { this.create_date = Convert.ToDateTime(dr["create_date"]); }
        }
    }
}
