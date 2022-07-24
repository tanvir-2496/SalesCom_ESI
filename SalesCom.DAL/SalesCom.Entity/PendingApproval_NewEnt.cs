using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class PendingApproval_NewEnt
    {
        public int Id { get; set; }
        public int ApprovalFlowId { get; set; }
        public int CycleId { get; set; }
        public int Status { get; set; }
        public string Comments { get; set; }

        public PendingApproval_NewEnt() { }

        public PendingApproval_NewEnt(DataRow dr)
        {
            if (dr["Id"] != DBNull.Value) { this.Id = Convert.ToInt32(dr["Id"]); }
            if (dr["ApprovalFlowId"] != DBNull.Value) { this.ApprovalFlowId = Convert.ToInt32(dr["ApprovalFlowId"]); }
            if (dr["CycleId"] != DBNull.Value) { this.CycleId = Convert.ToInt32(dr["CycleId"]); }
            if (dr["Status"] != DBNull.Value) { this.Status = Convert.ToInt32(dr["Status"]); }
            this.Comments = dr["Comments"] as String;
        }
    }

}
