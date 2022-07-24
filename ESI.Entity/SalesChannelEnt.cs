using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class SalesChannelEnt
    {
        public int Sales_Channel_Id { get; set; }
        public string Sales_Channel_Name { get; set; }
        public string UNIT { get; set; }
        public int Sales_Group_Id { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public int Updated_By { get; set; }
        public DateTime Updated_Date { get; set; }


        public SalesChannelEnt() { }

        public SalesChannelEnt(DataRow dr)
        {
            if (dr["SALES_CHANNEL_ID"] != DBNull.Value) { this.Sales_Channel_Id = Convert.ToInt32(dr["SALES_CHANNEL_ID"]); }
            this.Sales_Channel_Name = dr["SALES_CHANNEL_NAME"] as String;
            this.UNIT = dr["UNIT"] as String;
            if (dr["SALES_GROUP_ID"] != DBNull.Value) this.Sales_Group_Id = Convert.ToInt32(dr["SALES_GROUP_ID"]);
            if (dr["CREATED_BY"] != DBNull.Value) this.Created_By = Convert.ToInt32(dr["CREATED_BY"]);
            if (dr["CREATED_DATE"] != DBNull.Value) this.Created_Date = Convert.ToDateTime(dr["CREATED_DATE"]);
            if (dr["UPDATED_BY"] != DBNull.Value) this.Updated_By = Convert.ToInt32(dr["UPDATED_BY"]);
            if (dr["UPDATED_DATE"] != DBNull.Value) this.Updated_Date = Convert.ToDateTime(dr["UPDATED_DATE"]);
            
        }
    }
}
