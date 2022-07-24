using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
   public class DenoListModel
    {
        public int status { get; set; }
        public string DenoStart { get; set; }
        public string DenoEnd { get; set; }
        public string DenoIncentive { get; set; }

        public DenoListModel() { 
        }
        public DenoListModel(DataRow dr)
        {
            this.status = Convert.ToInt32(dr["ISMORETHAN"]);
           this.DenoStart = dr["START_HIT"].ToString();
           this.DenoEnd = dr["END_HIT"].ToString();
           this.DenoIncentive = dr["INCENTIVE"].ToString();
        }

    }
}
