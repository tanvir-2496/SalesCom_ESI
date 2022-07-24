using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ApprovalFlowEnt
    {
        public int ApprovalFlowID { get; set; }
        public string ApprovalName { get; set; }
        public string ApprovalType { get; set; }

        public ApprovalFlowEnt() { }

        public ApprovalFlowEnt(DataRow dr)
        {
            if (dr["ApprovalFlowID"] != DBNull.Value) { this.ApprovalFlowID = Convert.ToInt32(dr["ApprovalFlowID"]); }
            this.ApprovalName = dr["ApprovalName"] as String;
            this.ApprovalType = dr["ApprovalType"] as String;
        }
    }
}
