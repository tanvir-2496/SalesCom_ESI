using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ChannelEventBatchEnt
    {
        public int ChannelEventBatchId { get; set; }
        public string BatchSource { get; set; }
        public DateTime BatchDate { get; set; }
        public string IsReady { get; set; }
        public string BatchType { get; set; }

        public ChannelEventBatchEnt() { }

        public ChannelEventBatchEnt(DataRow dr)
        {
            if (dr["CHANNELEVENTBATCHID"] != DBNull.Value) { this.ChannelEventBatchId = Convert.ToInt32(dr["CHANNELEVENTBATCHID"]); }
            this.BatchSource = dr["BATCHSOURCE"] as string;
            if (dr["BATCHDATE"] != DBNull.Value) { this.BatchDate = Convert.ToDateTime(dr["BATCHDATE"]); }
            this.IsReady = dr["ISREADY"] as string;
            this.BatchType = dr["BATCHTYPE"] as string;
        }
    }



    public class ChannelEventBatchEntEx
    {
        public int ChannelEventBatchId { get; set; }
        public string BatchSource { get; set; }

        public ChannelEventBatchEntEx() { }

        public ChannelEventBatchEntEx(DataRow dr)
        {
            if (dr["CHANNELEVENTBATCHID"] != DBNull.Value) { this.ChannelEventBatchId = Convert.ToInt32(dr["CHANNELEVENTBATCHID"]); }
            this.BatchSource = dr["BATCHSOURCE"] as string;
        }
    }
}
