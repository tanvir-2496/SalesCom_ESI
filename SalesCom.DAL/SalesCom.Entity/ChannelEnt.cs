using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ChannelEnt
    {
        public int ChannelId { get; set; }
        public int ParentChannelId { get; set; }
        public int ChannelTypeId { get; set; }
        public string ChannelName { get; set; }

        public ChannelEnt() { }

        public ChannelEnt(DataRow dr)
        {
            if (dr["CHANNELID"] != DBNull.Value) { this.ChannelId = Convert.ToInt32(dr["CHANNELID"]); }
            if (dr["PARENTCHANNELID"] != DBNull.Value) { this.ParentChannelId = Convert.ToInt32(dr["PARENTCHANNELID"]); }
            if (dr["CHANNELTYPEID"] != DBNull.Value) { this.ChannelTypeId = Convert.ToInt32(dr["CHANNELTYPEID"]); }
            this.ChannelName = dr["CHANNELNAME"] as String;
        }

    }

    public class ViewChannelEnt
    {
        public int ChannelId { get; set; }
        public string ParentChannelName { get; set; }
        public string ChannelType { get; set; }
        public string ChannelName { get; set; }

        public ViewChannelEnt() { }

        public ViewChannelEnt(DataRow dr)
        {
            if (dr["CHANNELID"] != DBNull.Value) { this.ChannelId = Convert.ToInt32(dr["CHANNELID"]); }
            this.ParentChannelName = dr["PARENTCHANNELNAME"] as string;
            this.ChannelType = dr["CHANNELTYPE"] as string;
            this.ChannelName = dr["CHANNELNAME"] as String;
        }

    }
}
