using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ProductDetailsEnt
    {
        public int ProductId { get; set; }
        public string ProductDetail { get; set; }

        public ProductDetailsEnt() { }

        public ProductDetailsEnt(DataRow dr)
        {
            if (dr["PRODUCTID"] != DBNull.Value) { this.ProductId = Convert.ToInt32(dr["PRODUCTID"]); }
            this.ProductDetail = dr["ProductDetail"] as String;
        }

    }
}
