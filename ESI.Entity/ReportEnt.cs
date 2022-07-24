using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class ReportEnt
    {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public string ChannelName { get; set; }
        public List<KPIReportEnt> KPI { get; set; }
        public List<ConditionReportEnt> Condition { get; set; }
    }
}
