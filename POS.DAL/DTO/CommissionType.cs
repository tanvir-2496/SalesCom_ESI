using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;

namespace POS.DAL
{
    [DataContract] 
    public class CommissionType
    {
        [DataMember] public System.Int32 COMTYPEID { get; set; }
        [DataMember] public System.String COMTYPE { get; set; }

        public CommissionType() { }
        public CommissionType(DataRow objectRow)
        {
            if (objectRow["COMTYPEID"] != DBNull.Value) this.COMTYPEID = Convert.ToInt32(objectRow["COMTYPEID"]);
            this.COMTYPE = objectRow["COMTYPE"] as System.String;
        }
    }
}
