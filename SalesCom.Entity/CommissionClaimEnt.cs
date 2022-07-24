using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class CommissionClaimEnt
    {
        public Int64 ClaimId { get; set; }
        public Int64 ReportId { get; set; }
        public string ReportName { get; set; }
        public string ReferenceNumber { get; set; }
        public string CommissionCriterion { get; set; }
        public Int32 CycleId { get; set; }
        public string CycleDescription { get; set; }
        public string ModeOfPayment { get; set; }
        public string HasWithdrawalList { get; set; }

        public CommissionClaimEnt() { }

        public CommissionClaimEnt(DataRow dr)
        {
            if (dr["ClaimId"] != DBNull.Value) { this.ClaimId = Convert.ToInt64(dr["ClaimId"]); }
            if (dr["ReportId"] != DBNull.Value) { this.ReportId = Convert.ToInt64(dr["ReportId"]); }
            this.ReportName = dr["ReportName"] as String;
            this.ReferenceNumber = dr["ReferenceNumber"] as String;
            this.CommissionCriterion = dr["CommissionCriterion"] as String;
            if (dr["CycleId"] != DBNull.Value) { this.CycleId = Convert.ToInt32(dr["CycleId"]); }
            this.CycleDescription = dr["CycleDescription"] as String;
            this.ModeOfPayment = dr["ModeOfPayment"] as String;
            this.HasWithdrawalList = dr["HasWithdrawalList"] as String;
        }
    }
}
