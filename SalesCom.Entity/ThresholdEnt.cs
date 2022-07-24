using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ThresholdEnt
    {
        public int ThresholdTypeId { get; set; }
        public string Name { get; set; }

        public ThresholdEnt() { }

        public ThresholdEnt(DataRow dr)
        {
            if (dr["ThresholdTypeId"] != DBNull.Value) { this.ThresholdTypeId = Convert.ToInt32(dr["ThresholdTypeId"]); }
            this.Name = dr["Name"] as String;
        }
    }
}
