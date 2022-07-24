using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class GetDenoSetUpModel
    {
        public int? RecipientTypeId { get; set; }
        public int? ApprovalId { get; set; }
        public string CamPaignName { get; set; }
        public DateTime? CamPaignStart { get; set; }
        public DateTime? CamPaignEnd { get; set; }
        public string DenoAmount { get; set; }
        public int? ModalityId { get; set; }
        public string MaxCap { get; set; }
        public string HitPercentage { get; set; }
        public string OverHit { get; set; }
        public string IncentiveAmount { get; set; }
        public bool? IsMaxCap { get; set; }
        public bool? IsHitPercentage { get; set; }
        public bool? IsOverHit { get; set; }
        public bool? IsHitAmount { get; set; }
        public bool? IsIncentiveAmount { get; set; }
        public bool? IsSlab { get; set; }
        public bool? IsTargetSlab { get; set; }
        public bool? IsAchivementSlab { get; set; }

        public GetDenoSetUpModel()
        {
        }
        public GetDenoSetUpModel(DataRow dr)
        {
            if (dr["DENOTYPEID"] != DBNull.Value) { this.RecipientTypeId = Convert.ToInt32( dr["DENOTYPEID"].ToString()) as int?; }
            this.ApprovalId = Convert.ToInt32(dr["APPROVALID"].ToString()) as int?;
            this.CamPaignName = dr["CAMPAIGNNAME"] as String;
            this.CamPaignStart = dr["CAMPAIGNSTART"] as DateTime?;
            this.CamPaignEnd = dr["CAMPAIGNEND"] as DateTime?;
            this.DenoAmount = dr["DENOAMOUNT"] as String;
            this.ModalityId = Convert.ToInt32(dr["MODALITYID"].ToString()) as int?;
            this.MaxCap = dr["MAXCAP"].ToString();
            this.HitPercentage = dr["HITPERCENTAGE"].ToString();
            this.OverHit = dr["OVERHIT"].ToString();
            this.IncentiveAmount = dr["INCENTIVEAMOUNT"].ToString();
            this.IsMaxCap = Convert.ToBoolean(Convert.ToInt32(dr["ISMAXCAP"].ToString()));
            this.IsHitPercentage = Convert.ToBoolean(Convert.ToInt32(dr["ISHITPERCENTAGE"].ToString()));
            this.IsOverHit = Convert.ToBoolean(Convert.ToInt32(dr["ISOVERHIT"].ToString()));
            this.IsHitAmount = Convert.ToBoolean(Convert.ToInt32(dr["ISHITAMOUNT"].ToString()));
            this.IsIncentiveAmount = Convert.ToBoolean(Convert.ToInt32(dr["ISINCENTIVEAMOUNT"].ToString()));
            this.IsSlab = Convert.ToBoolean(Convert.ToInt32(dr["ISSLAB"].ToString()));
            this.IsTargetSlab = Convert.ToBoolean(Convert.ToInt32(dr["ISTARGETSLAB"].ToString()));
            this.IsAchivementSlab = Convert.ToBoolean(Convert.ToInt32(dr["ISACHIVEMENTSLAB"].ToString())); 
        }
    }
}
