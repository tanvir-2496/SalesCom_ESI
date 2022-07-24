using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
   public class RecipientTypeEnt
    {
        public int RecipientId { get; set; }
        public string RecipientType { get; set; }

        public RecipientTypeEnt() { }

        public RecipientTypeEnt(DataRow dr)
        {
            if (dr["ID"] != DBNull.Value) { this.RecipientId = Convert.ToInt32(dr["ID"]); }
            this.RecipientType = dr["DENO_TYPE_NAME"] as String;
        }
    }
}
