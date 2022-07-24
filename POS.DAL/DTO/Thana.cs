using System;
using System.Runtime.Serialization;
using System.Data;

namespace POS.DAL
{
    [DataContract]
    public class Thana
    {
        [DataMember]
        public System.Int32 ID{set;get;}
        [DataMember]
        public string NAME { set; get; }
        [DataMember]
        public System.Int32 DISTRICT { set; get; }
        [DataMember]
        public string CODE { set; get; }    
  
         public Thana()
        {
        }

         public Thana(DataRow objectRow)
        {
            this.ID = objectRow["ID"] != DBNull.Value ? Convert.ToInt32(objectRow["ID"]) : 0;
            this.NAME = objectRow["NAME"] as System.String;
            this.DISTRICT = objectRow["DISTRICT"] != DBNull.Value ? Convert.ToInt32(objectRow["DISTRICT"]) : 0;
            this.CODE = objectRow["CODE"] as System.String;
        }
    }
}
