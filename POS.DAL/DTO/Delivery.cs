using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{


    [DataContract] public class Delivery
    {
        [DataMember] public System.Int32 DELIVERYID { get; set; }
        [DataMember] public System.String DELIVERYNUMBER { get; set; }
        [DataMember] public System.Int32 RFID { get; set; }
        [DataMember] public System.DateTime DELIVERYDATE { get; set; }
        [DataMember] public System.String DELIVERYREF { get; set; }
        [DataMember] public System.String CREATEDBY { get; set; }
        [DataMember] public System.DateTime CREATEDDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.String RFCODE { get; set; }

        [DataMember] public System.DateTime FROMDATE { get; set; }
        [DataMember] public System.DateTime TODATE { get; set; }
        public Delivery() { }
        public Delivery(DataRow objectRow)
        {
            if (objectRow["DELIVERYID"] != DBNull.Value) this.DELIVERYID = Convert.ToInt32(objectRow["DELIVERYID"]);
            if (objectRow["RFID"] != DBNull.Value) this.RFID = Convert.ToInt32(objectRow["RFID"]);
            if (objectRow["DELIVERYDATE"] != DBNull.Value) this.DELIVERYDATE = Convert.ToDateTime(objectRow["DELIVERYDATE"]);
            this.DELIVERYNUMBER = objectRow["DELIVERYNUMBER"] as System.String;
            this.CREATEDBY = objectRow["CREATEDBY"] as System.String;
            if (objectRow["CREATEDDATE"] != DBNull.Value) this.CREATEDDATE = Convert.ToDateTime(objectRow["CREATEDDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            if (objectRow["RFCODE"] != DBNull.Value) this.RFCODE = Convert.ToString(objectRow["RFCODE"]);
        }
    }
}
