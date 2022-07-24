using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class SalesGroupEnt
    {
        public int Sales_Group_Id { get; set; }
        public string Sales_Group_Name { get; set; }

        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public int Updated_By { get; set; }
        public DateTime Updated_Date { get; set; }


        public SalesGroupEnt() { }

        public SalesGroupEnt(DataRow dr)
        {
            if (dr["SALES_GROUP_ID"] != DBNull.Value) { this.Sales_Group_Id = Convert.ToInt32(dr["SALES_GROUP_ID"]); }
            this.Sales_Group_Name = dr["SALES_GROUP_NAME"] as String;
            if (dr["CREATED_BY"] != DBNull.Value) this.Created_By = Convert.ToInt32(dr["CREATED_BY"]);
            if (dr["CREATED_DATE"] != DBNull.Value) this.Created_Date = Convert.ToDateTime(dr["CREATED_DATE"]);
            if (dr["UPDATED_BY"] != DBNull.Value) this.Updated_By = Convert.ToInt32(dr["UPDATED_BY"]);
            if (dr["UPDATED_DATE"] != DBNull.Value) this.Updated_Date = Convert.ToDateTime(dr["UPDATED_DATE"]);
        }
    }
}
