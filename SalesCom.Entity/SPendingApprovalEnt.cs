using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class SPendingApprovalEnt
    {
        public int PendingApprovalId { get; set; }
        public int LevelId { get; set; }
        public int ApprovalflowId { get; set; }
        public int CycleId { get; set; }

        public SPendingApprovalEnt()
        { }

        public SPendingApprovalEnt(DataRow dr)
        {
            if (dr["PENDINGAPPROVALID"] != DBNull.Value) { this.PendingApprovalId = Convert.ToInt32(dr["PENDINGAPPROVALID"]); }
            if (dr["LEVELID"] != DBNull.Value) { this.LevelId = Convert.ToInt32(dr["LEVELID"]); }
            if (dr["APPROVALFLOWID"] != DBNull.Value) { this.ApprovalflowId = Convert.ToInt32(dr["APPROVALFLOWID"]); }
            if (dr["CYCLEID"] != DBNull.Value) { this.CycleId = Convert.ToInt32(dr["CYCLEID"]); }

        }
    }

    public class PendingApprovalViewEnt
    {
        public int PendingApprovalId { get; set; }
        public int LevelCollectionId { get; set; }
        public string ApprovalName { get; set; }
        public int CycleId { get; set; }
        public string Name { get; set; }

        public PendingApprovalViewEnt() { }

        public PendingApprovalViewEnt(DataRow dr)
        {
            if (dr["PENDINGAPPROVALID"] != DBNull.Value) { this.PendingApprovalId = Convert.ToInt32(dr["PENDINGAPPROVALID"]); }
            if (dr["LevelCollectionId"] != DBNull.Value) { this.LevelCollectionId = Convert.ToInt32(dr["LevelCollectionId"]); }
            this.ApprovalName = dr["APPROVALNAME"] as String;
            if (dr["CYCLEID"] != DBNull.Value) { this.CycleId = Convert.ToInt32(dr["CYCLEID"]); }
            this.Name = dr["Name"] as String;
        }


    }


}
