using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class DetailDownloadList
    {
        public int Id { get; set; }
        public string ReportName { get; set; }
        public string MonthName { get; set; }
      

        public DetailDownloadList() { }

        public DetailDownloadList(DataRow dr)
        {
            if (dr["Id"] != DBNull.Value) { this.Id = Convert.ToInt32(dr["Id"]); }
            this.ReportName = dr["ReportName"] as String;
            this.MonthName = dr["MonthName"] as String;
        }
    }
}
