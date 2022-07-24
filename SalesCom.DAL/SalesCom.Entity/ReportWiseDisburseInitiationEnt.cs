using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ReportWiseDisburseInitiationEnt
    {
        public int ReportCycleId { get; set; }
        public int CurrentRedisburseNumber { get; set; }
        public int RedisburseFlowId { get; set; }
        public int CurrentOrderId { get; set; }
        public string ReportName { get; set; }
        public string ReportDuration { get; set; }
        public decimal CurrentWithheldAmount { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
