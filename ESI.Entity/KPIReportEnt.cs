using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class KPIReportEnt
    {
        public string KPI_NAME { get; set; }
        public int KPI_TARGET { get; set; }
        public int KPI_COUNT { get; set; }
        public int KPI_ACHIEVEMENT { get; set; }
    }
}
