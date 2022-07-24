using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class CommissionTypeEnt
    {
        public int CommissionTypeID { get; set; }
      //  public int SegmentTypeID { get; set; }
        public string CommissionTypeName { get; set; }



        public CommissionTypeEnt() { }

        public CommissionTypeEnt(DataRow dr)
        {
            if (dr["CommissionTypeID"] != DBNull.Value) { this.CommissionTypeID = Convert.ToInt32(dr["CommissionTypeID"]); }
            this.CommissionTypeName = dr["CommissionTypeName"] as String;
        }

    }


}
