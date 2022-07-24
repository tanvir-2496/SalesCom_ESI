using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
   public class DenoSetUpModel
    {
        public string Id { get; set; }
        public string RecipientTypeId { get; set; }
        public string ApprovalFlowId { get; set; }
        public string CamPaignName { get; set; }
        public string CamPaignStart { get; set; }
        public string CamPaignEnd { get; set; }
        public string DenoAmount { get; set; }
        public string ModalityId { get; set; }
        public string MaxCap { get; set; }
        public string HitPercentage { get; set; }
        public string OverHit { get; set; }
        public string IncentiveAmount { get; set; }
        public string IsMaxCap { get; set; }
        public string IsHitPercentage { get; set; }
        public string IsOverHit { get; set; }
        public string IsHitAmount { get; set; }
        public string IsIncentiveAmount { get; set; }
        public string IsSlab { get; set; }
        public string IsTargetSlab { get; set; }
        public string IsAchivementSlab { get; set; }
        public string Mode { get; set; }

         public DenoSetUpModel()
        {
        }

         public DenoSetUpModel(DataRow dr)
        {
            if (dr["RecipientTypeId"] != DBNull.Value) { this.RecipientTypeId = dr["RecipientTypeId"] as String; }
            this.ApprovalFlowId = dr["ApprovalFlowId"] as String;
            this.CamPaignName = dr["CamPaignName"] as String;
            this.CamPaignName = dr["CamPaignName"] as String;
            this.CamPaignStart = dr["CamPaignStart"] as String;
            this.CamPaignEnd = dr["CamPaignEnd"] as String;
            this.DenoAmount = dr["DenoAmount"] as String;
            this.ModalityId = dr["ModalityId"] as String;
            this.MaxCap = dr["MaxCap"] as String;
            this.HitPercentage = dr["HitPercentage"] as String;
            this.OverHit = dr["OverHit"] as String;
            this.IncentiveAmount = dr["IncentiveAmount"] as String;
            this.IsMaxCap = dr["IsMaxCap"] as String;
            this.IsHitPercentage = dr["IsHitPercentage"] as String;
            this.IsOverHit = dr["IsOverHit"] as String;
            this.IsIncentiveAmount = dr["IsIncentiveAmount"] as String;
            this.IsSlab = dr["IsSlab"] as String;
            this.IsTargetSlab = dr["IsTargetSlab"] as String;
            this.IsAchivementSlab = dr["IsAchivementSlab"] as String;
        }
    }
}
