using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class EventEnt
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public int EventTypeID { get; set; }
        public string EventType { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Frequency { get; set; }
        public int ChannelTypeID { get; set; }
        public string ChannelType { get; set; }
        public Int64 ProductChannelId { get; set; }
        public string ProdChhName { get; set; }
        public Int32 ReportId { get; set; }
        public string ReportName { get; set; }
        public EventEnt() { }

        public EventEnt(DataRow dr)
        {

            if (dr["EVENTID"] != DBNull.Value) { this.EventID = Convert.ToInt32(dr["EVENTID"]); }
            this.EventName = dr["EVENTNAME"] as string;
            if (dr["EVENTTYPEID"] != DBNull.Value) { this.EventTypeID = Convert.ToInt32(dr["EVENTTYPEID"]); }
            this.EventType = dr["EventType"] as string;
            if (dr["EFFECTIVEDATE"] != DBNull.Value) { this.EffectiveDate = Convert.ToDateTime(dr["EFFECTIVEDATE"]); }
            if (dr["EXPIRYDATE"] != DBNull.Value) { this.ExpiryDate = Convert.ToDateTime(dr["EXPIRYDATE"]); }
            if (dr["FREQUENCY"] != DBNull.Value) { this.Frequency = Convert.ToInt32(dr["FREQUENCY"]); }
            if (dr["ChannelTypeID"] != DBNull.Value) { this.ChannelTypeID = Convert.ToInt32(dr["ChannelTypeID"]); }
            this.ChannelType = dr["ChannelType"] as string;

            if (dr["ProductChannelId"] != DBNull.Value) { this.ProductChannelId = Convert.ToInt32(dr["ProductChannelId"]); }
            this.ProdChhName = dr["ProdChhName"] as string;
            if (dr["ReportId"] != DBNull.Value) { this.ReportId = Convert.ToInt32(dr["ReportId"]); }
            this.ReportName = dr["ReportName"] as String;


        }
    }

    public class Event2 : EventEnt
    {
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { set; get; }
    }



}
