using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class EventExEnt
    {
        public Int64 EventId { get; set; }
        public string EventName { get; set; }
        public Int64 EventTypeId { get; set; }
        public string EventType { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Int16 Frequency { get; set; }
        public Int64 ChannelTypeId { get; set; }
        public string ChannelType { get; set; }
        public Int32 ApprovalFlowId { get; set; }
        public string ApprovalName { get; set; }
        public Int16 CurrentLevel { get; set; }
        public string ApprovalLevelName { get; set; }
        public string CurrentStatus { get; set; }
        public Int16 Status { get; set; }
        public Int64 LastEventLogId { get; set; }
        public string Comments { get; set; }

        public Int32 LevelUserId { get; set; }
        public Int64 ReportId { get; set; }

        public EventExEnt() { }

        public EventExEnt(DataRow dr)
        {
            if (dr["EventId"] != DBNull.Value) { this.EventId = Convert.ToInt64(dr["EventId"]); }
            this.EventName = dr["EventName"] as String;
            if (dr["EventTypeId"] != DBNull.Value) { this.EventTypeId = Convert.ToInt64(dr["EventTypeId"]); }
            this.EventType = dr["EventType"] as String;
            if (dr["EffectiveDate"] != DBNull.Value) { this.EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]); }
            if (dr["ExpiryDate"] != DBNull.Value) { this.ExpiryDate = Convert.ToDateTime(dr["EffectiveDate"]); }
            if (dr["Frequency"] != DBNull.Value) { this.Frequency = Convert.ToInt16(dr["Frequency"]); }
            if (dr["ChannelTypeId"] != DBNull.Value) { this.ChannelTypeId = Convert.ToInt64(dr["ChannelTypeId"]); }
            this.ChannelType = dr["ChannelType"] as String;
            if (dr["ApprovalFlowId"] != DBNull.Value) { this.ApprovalFlowId = Convert.ToInt32(dr["ApprovalFlowId"]); }
            this.ApprovalName = dr["ApprovalName"] as String;
            if (dr["CurrentLevel"] != DBNull.Value) { this.CurrentLevel = Convert.ToInt16(dr["CurrentLevel"]); }
            this.ApprovalLevelName = dr["ApprovalLevelName"] as String;
            this.CurrentStatus = dr["CurrentStatus"] as String;
            if (dr["Status"] != DBNull.Value) { this.Status = Convert.ToInt16(dr["Status"]); }
            if (dr["LastEventLogId"] != DBNull.Value) { this.LastEventLogId = Convert.ToInt64(dr["LastEventLogId"]); }
            this.Comments = dr["Comments"] as String;
            if (dr["LevelUserId"] != DBNull.Value) { this.LastEventLogId = Convert.ToInt32(dr["LevelUserId"]); }
            if (dr["ReportId"] != DBNull.Value) { this.ReportId = Convert.ToInt64(dr["ReportId"]); }

        }


    }
}
