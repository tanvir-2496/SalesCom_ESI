using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ChannelEventImportEnt
    {
        public Int64 ChannelEventId { get; set; }
        public Int32 ExternalId { get; set; }
        public Int64 SimId { get; set; }
        public Int64 ChannelTypeId { get; set; }
        public Int32 CventTypeId { get; set; }
        public DateTime EventDate { get; set; }
        public float EventAmount { get; set; }
        public string AamountType { get; set; }
        public Int32 ChannelEventBatchId { get; set; }
        public string Status { get; set; }
        public Int64 ChannelId { get; set; }
        public Int32 ImportBy { get; set; }
        public DateTime ImportDate { get; set; }

    }
}
