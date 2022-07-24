using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
  public class KPIFromData
    {
        public string FromSalesGroup { get; set; }
        public string FromYear { get; set; }
        public string FromQuarter { get; set; }
        public string FromReportName { get; set; }
        public string FromMonth { get; set; }
    }


  public class KPITargetFromData
  {
      public string FromSalesGroup { get; set; }
      public string FromYear { get; set; }
      public string FromQuarter { get; set; }
      public string FromReportName { get; set; }
      public string FromMonth { get; set; }
      public string FromKPI { get; set; }
      public string FromSubKPI { get; set; }
      public string FromCondition { get; set; }
  }
}
