using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ProductChannelEnt
    {
        public Int64 ProductChannelId { get; set; }
        public string ProdChhName { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string ProcedureName { get; set; }
        public Int32 IsActive { get; set; }
        public string IsDynamic { get; set; }

        public ProductChannelEnt() { }

        public ProductChannelEnt(DataRow dr)
        {
            if (dr["ProductChannelId"] != DBNull.Value) { this.ProductChannelId = Convert.ToInt64(dr["ProductChannelId"]); }
            this.ProdChhName = dr["ProdChhName"] as String;
            if (dr["EffectiveDate"] != DBNull.Value) { this.EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]); }
            if (dr["ExpireDate"] != DBNull.Value) { this.ExpireDate = Convert.ToDateTime(dr["ExpireDate"]); }
            this.ProcedureName = dr["ProcedureName"] as String;
            if (dr["IsActive"] != DBNull.Value) { this.IsActive = Convert.ToInt32(dr["IsActive"]); }
            this.IsDynamic = dr["IsDynamic"] as String;
        }
    }
}
