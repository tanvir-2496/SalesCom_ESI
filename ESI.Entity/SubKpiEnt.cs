using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class SubKpiEnt
    {
        public int Kpi_id { get; set; }
        public int SubKpi_id { get; set; }

        public string Kpi_Name { get; set; }
        public string Display_Name { get; set; }
        public int Sales_Group_Id { get; set; }
        public int Kpi_Type { get; set; }
        public int Is_Active { get; set; }
        public int Is_Financial { get; set; }
        public int Is_Source_Manual { get; set; }
        public string Manual_Source { get; set; }
        public string Remarks { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public int Updated_By { get; set; }
        public DateTime Updated_Date { get; set; } 

        


        public SubKpiEnt() { }

        public SubKpiEnt(DataRow dr)
        {
            if (dr["KPI_ID"] != DBNull.Value) { this.Kpi_id = Convert.ToInt32(dr["KPI_ID"]); }
            this.Kpi_Name = dr["KPI_NAME"] as String;
            this.Display_Name = dr["DISPLAY_NAME"] as String;
            if (dr["SUB_KPI_ID"] != DBNull.Value) this.SubKpi_id = Convert.ToInt32(dr["SUB_KPI_ID"]);
            if (dr["SALES_GROUP_ID"] != DBNull.Value) this.Sales_Group_Id = Convert.ToInt32(dr["SALES_GROUP_ID"]);
            if (dr["KPI_TYPE"] != DBNull.Value) this.Kpi_Type = Convert.ToInt32(dr["KPI_TYPE"]);
            if (dr["IS_ACTIVE"] != DBNull.Value) this.Is_Active = Convert.ToInt32(dr["IS_ACTIVE"]);
            if (dr["IS_FINANCIAL"] != DBNull.Value) this.Is_Financial = Convert.ToInt32(dr["IS_FINANCIAL"]);
            if (dr["IS_SOURCE_MANUAL"] != DBNull.Value) this.Is_Source_Manual = Convert.ToInt32(dr["IS_SOURCE_MANUAL"]);
            if (dr["MANUAL_SOURCE"] != DBNull.Value) this.Manual_Source = dr["MANUAL_SOURCE"] as string;
            if (dr["REMARKS"] != DBNull.Value) this.Remarks = dr["REMARKS"] as string;
            if (dr["CREATED_BY"] != DBNull.Value) this.Created_By = Convert.ToInt32(dr["CREATED_BY"]);
            if (dr["CREATED_DATE"] != DBNull.Value) this.Created_Date = Convert.ToDateTime(dr["CREATED_DATE"]);
            if (dr["UPDATED_BY"] != DBNull.Value) this.Updated_By = Convert.ToInt32(dr["UPDATED_BY"]);
            if (dr["UPDATED_DATE"] != DBNull.Value) this.Updated_Date = Convert.ToDateTime(dr["UPDATED_DATE"]);
        }
    }
}
