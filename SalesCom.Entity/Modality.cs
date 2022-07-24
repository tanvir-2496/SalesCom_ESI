using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCom.Entity
{
   public class Modality
    {
       public string Value { get; set; }
       public string Text { get; set; }

        public Modality() { 
        }
        public Modality(DataRow dr)
        {
            this.Value = dr["ID"].ToString();
            this.Text = dr["NAME"].ToString();
        }


    }
}
