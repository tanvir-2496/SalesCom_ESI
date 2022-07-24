using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ApprovalLevelEnt
    {
        public int ApprovalLevelID { get; set;    }
        public int LevelCollectionId { get; set; }
        public int OrderID { get; set; }
        public int ApprovalFlowID { get; set; }

        public ApprovalLevelEnt() { }

        public ApprovalLevelEnt(DataRow dr)
        {
            if (dr["APPROVALLEVELID"] != DBNull.Value) { this.ApprovalLevelID = Convert.ToInt32(dr["APPROVALLEVELID"]); }
            if (dr["LEVELCOLLECTIONID"] != DBNull.Value) { this.LevelCollectionId = Convert.ToInt32(dr["LEVELCOLLECTIONID"]); }
            if (dr["ORDERID"] != DBNull.Value) { this.OrderID = Convert.ToInt32(dr["ORDERID"]); }
            if (dr["APPROVALFLOWID"] != DBNull.Value) { this.ApprovalFlowID = Convert.ToInt32(dr["APPROVALFLOWID"]); }
        }
    }


    public class ApprovalLevelWithJoin
    {
        public int ApprovalLevelId { get; set; }
        public string Name { get; set; }
        public int OrderId { get; set; }
        public string ApprovalName { get; set; }

        public ApprovalLevelWithJoin() { }

        public ApprovalLevelWithJoin(DataRow dr)
        {
            if (dr["ApprovalLevelId"] != DBNull.Value) { this.ApprovalLevelId = Convert.ToInt32(dr["ApprovalLevelId"]); }
            this.Name = dr["Name"] as String;
            if (dr["OrderId"] != DBNull.Value) { this.OrderId = Convert.ToInt32(dr["OrderId"]); }
            this.ApprovalName = dr["ApprovalName"] as String;
        }
    }

}

