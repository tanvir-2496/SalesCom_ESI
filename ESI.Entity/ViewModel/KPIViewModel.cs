using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity.ViewModel
{
    public class KPIViewModel
    {
        public int Kpi_id { get; set; }
        public string Incentive_Payout { get; set; }
        public string Incentive_Payout_Json { get; set; }
        public decimal Weightage { get; set; }
        public int QUARTER_MONTH_CYCLE_ID { get; set; }
        public string Kpi_Name { get; set; }
        public int Sales_Group_Id { get; set; }
        public int Kpi_Type { get; set; }
        public int Is_Active { get; set; }
        public int ParentKpiId { get; set; }
        public string Remarks { get; set; }
    }
}
