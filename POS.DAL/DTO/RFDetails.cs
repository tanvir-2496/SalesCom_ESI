using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class RFDetails
    {
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.Int32 RFID { get; set; }
        [DataMember] public System.Int32 REQUISIONQTY { get; set; }
        [DataMember] public System.Int32 DELIVEREDQTY { get; set; }
        [DataMember] public System.Int32 AVLQTY { get; set; }
        [DataMember] public System.Decimal PRICE { get; set; }
        [DataMember] public System.Decimal RATE { get; set; }
        [DataMember] public System.String REMARKS { get; set; }
        [DataMember] public System.String DELIVERYREF { get; set; }
        [DataMember] public System.Int32 PROMOTIONCYCLEID { get; set; }
        [DataMember] public System.String PRODUCTNAME { get; set; }
        [DataMember] public System.String PROMOTIONCYCLENAME { get; set; }
        [DataMember] public System.String PROMOTIONNAME { get; set; }
        [DataMember] public System.String PRODUCTCODE { get; set; }
        [DataMember] public System.String ISDELIVEREDBYWAREHOUSE { get; set; }
        [DataMember] public System.String STATUS { get; set; }
        
        public RFDetails() { }
        public RFDetails(DataRow objectRow)
        {
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            if (objectRow["RFID"] != DBNull.Value) this.RFID = Convert.ToInt32(objectRow["RFID"]);
            if (objectRow["REQUISIONQTY"] != DBNull.Value) this.REQUISIONQTY = Convert.ToInt32(objectRow["REQUISIONQTY"]);
            if (objectRow["DELIVEREDQTY"] != DBNull.Value) this.DELIVEREDQTY = Convert.ToInt32(objectRow["DELIVEREDQTY"]);
            this.REMARKS = objectRow["REMARKS"] as System.String;
            this.DELIVERYREF = objectRow["DELIVERYREF"] as System.String;
            if (objectRow["PROMOTIONCYCLEID"] != DBNull.Value) this.PROMOTIONCYCLEID = Convert.ToInt32(objectRow["PROMOTIONCYCLEID"]);
            this.PRODUCTNAME = objectRow["PRODUCTNAME"] as String;
            this.PROMOTIONCYCLENAME = objectRow["PROMOTIONCYCLENAME"] as String;
            this.PROMOTIONNAME = objectRow["PROMOTIONNAME"] as String;
            this.PRODUCTCODE = objectRow["PRODUCTCODE"] as String;
            this.ISDELIVEREDBYWAREHOUSE = objectRow["ISDELIVEREDBYWAREHOUSE"] as String;
            try
            {
                if (objectRow["STATUS"] != DBNull.Value) this.STATUS = objectRow["STATUS"].ToString();
            }
            catch (Exception ex)
            { }
        }
    }
}