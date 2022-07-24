using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class SegmentTypeEnt
    {
        public int SegmentTypeId { get; set; }
        public string TypeName { get; set; }
        public int ChannelTypeId { get; set; }

        public SegmentTypeEnt() { }

        public SegmentTypeEnt(DataRow dr)
        {
            if (dr["SEGMENTTYPEID"] != DBNull.Value) { this.SegmentTypeId = Convert.ToInt32(dr["SEGMENTTYPEID"]); }
            this.TypeName = dr["TYPENAME"] as String;
            if (dr["CHANNELTYPEID"] != DBNull.Value) { this.ChannelTypeId = Convert.ToInt32(dr["CHANNELTYPEID"]); }
        }
    }

    public class SegmentTypeEntForView
    {
        public int SegmentTypeId { get; set; }
        public string TypeName { get; set; }
        public int ChannelTypeId { get; set; }
        public string ChannelType { get; set; }

        public SegmentTypeEntForView() { }

        public SegmentTypeEntForView(DataRow dr)
        {
            if (dr["SEGMENTTYPEID"] != DBNull.Value) { this.SegmentTypeId = Convert.ToInt32(dr["SEGMENTTYPEID"]); }
            this.TypeName = dr["TYPENAME"] as String;
            this.ChannelType = dr["CHANNELTYPE"] as String;
            if (dr["CHANNELTYPEID"] != DBNull.Value) { this.ChannelTypeId = Convert.ToInt32(dr["CHANNELTYPEID"]); }
        }
    }



}
