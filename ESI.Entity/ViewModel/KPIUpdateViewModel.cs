using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity.ViewModel
{
    public class KPIUpdateViewModel
    {
        public List<KPIConfigurationEnt> KPIs { get; set; }
        public List<KPIConfigurationEnt> SubKPIs { get; set; }
        public List<ConditionConfigEnt> Conditions { get; set; }

        public List<KPIEnt> KPIDropdown { get; set; }
        public List<KPIViewModel> SubKPIDropdown { get; set; }
        public List<ConditionViewModel> ConditionDropdown { get; set; }
       // public int QUARTER_MONTH_CYCLE_ID { get; set; }
    }
}
