using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity.ViewModel
{
    public class IncentivePayoutViewModel
    {
        public int IOrder { get; set; }
        public string IOperator { get; set; }
        public int IThreshold { get; set; }
        public int IAmount { get; set; }
        public string IAtActual { get; set; }
        public int IRatioAmount { get; set; }
        public string IIsLinear { get; set; }
        public int kpiId { get; set; }
        public int IIncentiveID { get; set; }
    }
}
