using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class AmountTypeEnt
    {
        public int AmountTypeId { get; set; }
        public string AmountTypeName { get; set; }

        public AmountTypeEnt() { }

        public AmountTypeEnt(DataRow dr)
        {
            if (dr["AmountTypeId"] != DBNull.Value) { this.AmountTypeId = Convert.ToInt32(dr["AmountTypeId"]); }
            this.AmountTypeName = dr["AmountTypeName"] as String;
        }

    }

   
}
