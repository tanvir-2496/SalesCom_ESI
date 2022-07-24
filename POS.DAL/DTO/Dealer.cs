using System;
using System.Runtime.Serialization;
using System.Data;

namespace POS.DAL
{
    [DataContract]
    public class Dealer
    {
        [DataMember]
        public Int32 ID { set; get; }
        [DataMember]
        public string NAME { set; get; }
        [DataMember]
        public string DESCRIPTION { set; get; }
        [DataMember]
        public string ENABLED { set; get; }
        [DataMember]
        public DateTime CHANGEDATE { set; get; }
        [DataMember]
        public string CHANGEDBY { set; get; }

         public Dealer()
        {
        }

         public Dealer(DataRow objectRow)
        {
            this.ID = objectRow["ID"] != DBNull.Value ? Convert.ToInt32(objectRow["ID"]) : 0;
            this.NAME = objectRow["NAME"] as System.String;
            this.DESCRIPTION = objectRow["DESCRIPTION"] as System.String;
            this.ENABLED = objectRow["ENABLED"] as System.String;
            this.CHANGEDATE = objectRow["CHANGEDATE"] != DBNull.Value ? Convert.ToDateTime(objectRow["CHANGEDATE"]) : DateTime.MinValue;
            this.ENABLED = objectRow["CHANGEDBY"] as System.String;

        }
    }
}
