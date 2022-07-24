using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class EventTypeEnt
    {
        public int EventTypeId { get; set; }
        public string EventType { get; set; }

        public EventTypeEnt() { }

        public EventTypeEnt(DataRow dr)
        {
            if (dr["EVENTTYPEID"] != DBNull.Value) { this.EventTypeId = Convert.ToInt32(dr["EVENTTYPEID"]); }
            this.EventType = dr["EVENTTYPE"] as string;
        }
    }

    public class EventType2 : EventTypeEnt
    {
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }

}
