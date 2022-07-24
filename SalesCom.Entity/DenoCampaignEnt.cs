using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class DenoCampaignEnt
    {
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public DateTime CampaignStartDate { get; set; }
        public DateTime CampaignEndDate { get; set; }
        public DateTime ExtendEndDate { get; set; }
        public int UpperCap { get; set; }
        public string IsActive { get; set; }
        public string CurrentStatus { get; set; }
        public string IsTargetFileUploaded { get; set; }
        public Int16 status { get; set; }

        public DenoCampaignEnt()
        { }
        public DenoCampaignEnt(DataRow dr)
        {
            if (dr["ID"] != DBNull.Value) this.CampaignID = Convert.ToInt32(dr["ID"]);
            this.CampaignName = dr["CAMP_NAME"] as System.String;
            this.CurrentStatus = dr["current_status"] as System.String;
            if (dr["CAMP_START_DATE"] != DBNull.Value) { this.CampaignStartDate = Convert.ToDateTime(dr["CAMP_START_DATE"]); }
            if (dr["CAMP_END_DATE"] != DBNull.Value) { this.CampaignEndDate = Convert.ToDateTime(dr["CAMP_END_DATE"]); }
            if (dr["EX_END_DATE"] != DBNull.Value) { this.ExtendEndDate = Convert.ToDateTime(dr["EX_END_DATE"]); }
            if (dr["UPPER_CAP"] != DBNull.Value) this.UpperCap = Convert.ToInt32(dr["UPPER_CAP"]);
            this.IsActive = Convert.ToInt32(dr["IS_CAMP_STOP"]) == 0 ? "N" : "Y";
            this.IsTargetFileUploaded = Convert.ToInt32(dr["IS_TARGET_FILE_UP"]) == 0 ? "N" : "Y";
            this.status = Convert.ToInt16(dr["STATUS"]);
          
        }
    }

    public class DenoCampaign2 : DenoCampaignEnt
    {
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }

    
}
