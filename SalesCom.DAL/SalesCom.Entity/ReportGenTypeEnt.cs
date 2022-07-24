using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ReportGenTypeEnt
    {
        public int ReportGenTypeId { get; set; }
        public string Name { get; set; }

        public ReportGenTypeEnt() { }

        public ReportGenTypeEnt(DataRow dr)
        {
            if (dr["ReportGenTypeId"] != DBNull.Value) { this.ReportGenTypeId = Convert.ToInt32(dr["ReportGenTypeId"]); }
            this.Name = dr["Name"] as String;
        }
    }
}
