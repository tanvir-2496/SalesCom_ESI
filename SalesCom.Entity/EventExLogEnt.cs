using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    class EventExLogEnt
    {
        public Int64 EventLogId { get; set; }
        public Int64 EventId { get; set; }
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public Int32 ChangedUserId { get; set; }
        public DateTime UpdateDate { get; set; }

        public EventExLogEnt() { }

        public EventExLogEnt(DataRow dr)
        {
            if (dr["EventLogId"] != DBNull.Value) { this.EventLogId = Convert.ToInt64(dr["EventLogId"]); }
            if (dr["EventId"] != DBNull.Value) { this.EventId = Convert.ToInt64(dr["EventId"]); }
            this.ColumnName = dr["ColumnName"] as String;
            this.OldValue = dr["OldValue"] as String;
            this.NewValue = dr["NewValue"] as String;
            if (dr["ChangedUserId"] != DBNull.Value) { this.ChangedUserId = Convert.ToInt32(dr["ChangedUserId"]); }
            if (dr["UpdateDate"] != DBNull.Value) { this.UpdateDate = Convert.ToDateTime(dr["UpdateDate"]); }

        }
    }
}
