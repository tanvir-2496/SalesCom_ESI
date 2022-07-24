using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ReportMaster
    {
        public string Id { get; set; }
        public string ReportName { get; set; }
        public string Mode { get; set; }
        public string CyCleId { get; set; }

         public ReportMaster()
        {

        }
         public ReportMaster(DataRow dr)
         {
             this.ReportName = dr["Report_Name"] as String;
         }
    }
}
