using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class DailyDenoCampaignEnt
    {
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public DateTime CampaignStartDate { get; set; }
        public DateTime CampaignEndDate { get; set; }
        public int UpperCap { get; set; }
        public string IsActive { get; set; }

        public DailyDenoCampaignEnt()
        { }
        public DailyDenoCampaignEnt(DataRow dr)
        {
            if (dr["CAMPAIGN_ID"] != DBNull.Value) this.CampaignID = Convert.ToInt32(dr["CAMPAIGN_ID"]);
            this.CampaignName = dr["CAMPAIGN_NAME"] as System.String;
            if (dr["CAMPAIGN_START_DATE"] != DBNull.Value) { this.CampaignStartDate = Convert.ToDateTime(dr["CAMPAIGN_START_DATE"]); }
            if (dr["CAMPAIGN_END_DATE"] != DBNull.Value) { this.CampaignEndDate = Convert.ToDateTime(dr["CAMPAIGN_END_DATE"]); }
            if (dr["UPPUR_CAP"] != DBNull.Value) this.UpperCap = Convert.ToInt32(dr["UPPUR_CAP"]);
            this.IsActive = Convert.ToInt32(dr["IS_ACTIVE"])==0?"Y":"N";
        }
    }

    public class DailyDenoCampaign2 : DailyDenoCampaignEnt
    {
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }



}
