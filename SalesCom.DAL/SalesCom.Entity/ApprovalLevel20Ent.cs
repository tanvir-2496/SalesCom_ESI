using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ApprovalLevel20Ent
    {
        public int ApprovalLevelID { get; set; }
        public string ApprovalLevelName { get; set; }
        public int OrderID { get; set; }
        public int ApprovalFlowID { get; set; }
        public string ApprovalFlowName { get; set; }
        public ApprovalLevel20Ent() { }

        public ApprovalLevel20Ent(DataRow dr)
        {
            if (dr["APPROVALLEVELID"] != DBNull.Value) { this.ApprovalLevelID = Convert.ToInt32(dr["APPROVALLEVELID"]); }
            this.ApprovalLevelName = dr["APPROVALLEVELNAME"] as String;
            if (dr["ORDERID"] != DBNull.Value) { this.OrderID = Convert.ToInt32(dr["ORDERID"]); }
            if (dr["APPROVALFLOWID"] != DBNull.Value) { this.ApprovalFlowID = Convert.ToInt32(dr["APPROVALFLOWID"]); }
            this.ApprovalFlowName = dr["ApprovalFlowName"] as String;
        }
    }

}

