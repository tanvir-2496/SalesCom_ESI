using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ModalityTypeEnt
    {
         public int ModalityId { get; set; }
        public string ModalityType { get; set; }

        public ModalityTypeEnt() { }

        public ModalityTypeEnt(DataRow dr)
        {
            if (dr["ID"] != DBNull.Value) { this.ModalityId = Convert.ToInt32(dr["ID"]); }
            this.ModalityType = dr["MODALITY_NAME"] as String;
        }
    }
}
