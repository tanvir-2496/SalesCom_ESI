using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ChannelTypeEnt
    {
        public int ChannelTypeId { get; set; }
        public string ChannelType { get; set; }

        public ChannelTypeEnt() { }

        public ChannelTypeEnt(DataRow dr)
        {
            if (dr["CHANNELTYPEID"] != DBNull.Value) { this.ChannelTypeId = Convert.ToInt32(dr["CHANNELTYPEID"]); }
            this.ChannelType = dr["CHANNELTYPE"] as String;
        }


    }
}
