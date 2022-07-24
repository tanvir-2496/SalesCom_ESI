using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity.ViewModel
{
    public class KPIConfigurationViewModel
    {
        public int KPI_CONFIG_ID { get; set; }
        public int YEAR { get; set; }
        public int QUARTER { get; set; }
        public int MONTH { get; set; }
        public int SALES_CHANNEL_ID { get; set; }
        public int KPI_ID { get; set; }
        public string KPIName { get; set; }
        public int PARENT_KPI_ID { get; set; }
        public int REPORT_CYCLE_ID { get; set; }
        public int IS_LAST_LEVEL { get; set; }
        public string INCENTIVE_PAYOUT { get; set; }
        public decimal WEIGHTAGE { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public int Updated_By { get; set; }
        public DateTime Updated_Date { get; set; }

    }
}
