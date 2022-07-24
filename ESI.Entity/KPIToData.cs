using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
   public class KPIToData
    {
        public string ToReportType { get; set; }
        public string ToSalesGroup { get; set; }
        public string ToSalesChannelName { get; set; }
        public string ToYear { get; set; }
        public string ToQuarter { get; set; }
        public string ToMonth { get; set; }
    }

   public class KPITargetToData
   {
       public string ToCloneSalesGroup { get; set; }
       public string ToCloneYear { get; set; }
       public string ToCloneQuarter { get; set; }
       public string ToCloneReportName { get; set; }
       public string ToCloneMonth { get; set; }
       public string ToCloneKPI { get; set; }
       public string ToCloneSubKPI { get; set; }
       public string ToCloneCondition { get; set; }
   }
}
