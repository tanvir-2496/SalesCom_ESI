
using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class DeliveryDetail
    {
        [DataMember] public System.Int32 DELIVERYDETAILID { get; set; }
        [DataMember] public System.Int32 DELIVERYID { get; set; }
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.Int32 REQQTY { get; set; }
        [DataMember] public System.String ISDELIVEREDYN { get; set; }
        [DataMember] public System.String PRODUCTNAME { get; set; }
        [DataMember] public System.String PRODUCTCODE { get; set; }
        [DataMember] public System.String DELIVERYREF { get; set; }
              
        public DeliveryDetail() { }
        public DeliveryDetail(DataRow objectRow)
        {
            if (objectRow["DELIVERYDETAILID"] != DBNull.Value) this.DELIVERYDETAILID = Convert.ToInt32(objectRow["DELIVERYDETAILID"]);
            if (objectRow["DELIVERYID"] != DBNull.Value) this.DELIVERYID = Convert.ToInt32(objectRow["DELIVERYID"]);
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            if (objectRow["REQQTY"] != DBNull.Value) this.REQQTY = Convert.ToInt32(objectRow["REQQTY"]);
            this.DELIVERYREF = objectRow["DELIVERYREF"] as System.String;
            this.ISDELIVEREDYN = objectRow["ISDELIVEREDYN"] as System.String;
            this.PRODUCTNAME = objectRow["PRODUCTNAME"] as System.String;
            this.PRODUCTCODE = objectRow["PRODUCTCODE"] as System.String;
        }
    }
}
