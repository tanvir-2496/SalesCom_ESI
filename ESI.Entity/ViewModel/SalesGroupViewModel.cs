using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity.ViewModel
{
    public class SalesGroupViewModel
    {
        public int SALES_GROUP_ID { get; set; }
        public string SALES_GROUP_NAME { get; set; }


        public SalesGroupViewModel() { }

        public SalesGroupViewModel(DataRow dr)
        {
            if (dr["SALES_GROUP_ID"] != DBNull.Value) { this.SALES_GROUP_ID = Convert.ToInt32(dr["SALES_GROUP_ID"]); }
            this.SALES_GROUP_NAME = dr["SALES_GROUP_NAME"] as String;
        }
    }
}
