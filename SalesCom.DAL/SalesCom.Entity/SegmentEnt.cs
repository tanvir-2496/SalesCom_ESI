using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class SegmentEnt
    {
        public int SegmentID { get; set; }
        public int SegmentTypeID { get; set; }
        public string SegmentName { get; set; }

        public SegmentEnt() { }

        public SegmentEnt(DataRow dr)
        {
            if (dr["SegmentID"] != DBNull.Value) { this.SegmentID = Convert.ToInt32(dr["SegmentID"]); }
            if (dr["SegmentTypeID"] != DBNull.Value) { this.SegmentTypeID = Convert.ToInt32(dr["SegmentTypeID"]); }
            this.SegmentName = dr["SegmentName"] as String;
        }
    }

    public class SegmentTypeSegmentEnt
    {
        public int SegmentID { get; set; }
        public int SegmentTypeID { get; set; }
        public string SegmentName { get; set; }
        public string TypeName { get; set; }

        public SegmentTypeSegmentEnt() { }

        public SegmentTypeSegmentEnt(DataRow dr)
        {
            if (dr["SegmentID"] != DBNull.Value) { this.SegmentID = Convert.ToInt32(dr["SegmentID"]); }
            if (dr["SegmentTypeID"] != DBNull.Value) { this.SegmentTypeID = Convert.ToInt32(dr["SegmentTypeID"]); }
            this.SegmentName = dr["SegmentName"] as String;
            this.TypeName = dr["TypeName"] as String;
        }
    }


}
