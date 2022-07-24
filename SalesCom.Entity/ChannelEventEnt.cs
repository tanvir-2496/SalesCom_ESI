using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ChannelEventEnt
    {
        public Int64 ChannelEventId { get; set; }
        public Int64 ExternalId { get; set; }
        public Int64 SimId { get; set; }
        public string ChannelCode { get; set; }
        public Int32 ChannelTypeId { get; set; }
        public Int32 EventTypeId { get; set; }
        public DateTime EventDate { get; set; }
        public float EventAmount { get; set; }
        public string AmountType { get; set; }
        public Int64 ChannelEventBatchId { get; set; }
        public string Status { get; set; }
        public Int64 ChannelId { get; set; }
        public string ImportBy { get; set; }
        public DateTime ImportDate { get; set; }
        public string SimNumber { get; set; }
        public string Msisdn { get; set; }
        public string BatchSource { get; set; }
        public string EventType { get; set; }
        public string ChannelType { get; set; }

        public ChannelEventEnt() { }
        public ChannelEventEnt(DataRow dr)
        {
            if (dr["ChannelEventId"] != DBNull.Value) { this.ChannelEventId = Convert.ToInt64(dr["ChannelEventId"]); }
            if (dr["ExternalId"] != DBNull.Value) { this.ExternalId = Convert.ToInt64(dr["ExternalId"]); }
            if (dr["SimId"] != DBNull.Value) { this.SimId = Convert.ToInt64(dr["SimId"]); }
            this.ChannelCode = dr["ChannelCode"] as String;
            if (dr["ChannelTypeId"] != DBNull.Value) { this.ChannelTypeId = Convert.ToInt32(dr["ChannelTypeId"]); }
            if (dr["EventTypeId"] != DBNull.Value) { this.EventTypeId = Convert.ToInt32(dr["EventTypeId"]); }
            if (dr["EventDate"] != DBNull.Value) { this.EventDate = Convert.ToDateTime(dr["EventDate"]); }
            if (dr["EventAmount"] != DBNull.Value) { this.EventAmount = (float) Convert.ToDecimal(dr["EventAmount"]); }
            this.AmountType = dr["AmountType"] as String;
            if (dr["ChannelEventBatchId"] != DBNull.Value) { this.ChannelEventBatchId = Convert.ToInt64(dr["ChannelEventBatchId"]); }
            this.Status = dr["Status"] as String;
            if (dr["ChannelId"] != DBNull.Value) { this.ChannelId = Convert.ToInt64(dr["ChannelId"]); }
            this.ImportBy = dr["ImportBy"] as String;
            if (dr["ImportDate"] != DBNull.Value) { this.ImportDate = Convert.ToDateTime(dr["ImportDate"]); }
            this.SimNumber = dr["SimNumber"] as String;
            this.Msisdn = dr["Msisdn"] as String;
            this.BatchSource = dr["BatchSource"] as String;
            this.EventType = dr["EventType"] as String;
            this.ChannelType = dr["ChannelType"] as String;

        }
    }
}
