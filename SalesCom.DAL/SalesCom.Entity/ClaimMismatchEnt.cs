using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ClaimMismatchEnt
    {
        public string channel_code { get; set; }
        public string status { get; set; }

        public ClaimMismatchEnt()
        {
        }

        public ClaimMismatchEnt(DataRow dr)
        {
            this.channel_code = dr["channel_code"] as String;
            this.status = dr["status"] as String;
        }
    }
}
