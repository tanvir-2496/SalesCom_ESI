using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class InvoiceDetail
    {
        [DataMember] public System.Int32 INVOICEDETAILID { get; set; }
        [DataMember] public System.Int32 INVOICEID { get; set; }
        [DataMember] public System.Int32 PROMOTIONCYCLEID { get; set; }
        [DataMember] public System.Int32 QTY { get; set; }
        [DataMember] public System.Int32 DELIVEREDQTY { get; set; }
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.Int32 REQUISIONQTY { get; set; }
        [DataMember] public System.String PRODUCTNAME { get; set; }
        [DataMember] public System.String PROMOTIONCYCLENAME { get; set; }
        [DataMember] public System.String PROMOTIONNAME { get; set; }
        [DataMember] public System.Decimal FACEVALUE { get; set; }
        [DataMember] public System.Decimal SD { get; set; }
        [DataMember] public System.Decimal VATAMOUNT { get; set; }
        [DataMember]public System.String REMARKS { get; set; }
        [DataMember]public System.String INVENTORYYN { get; set; }
        [DataMember]
        public System.Decimal DISCOUNT { get; set; }


        public InvoiceDetail() { }
        public InvoiceDetail(DataRow objectRow)
        {
            if (objectRow["INVOICEDETAILID"] != DBNull.Value) this.INVOICEDETAILID = Convert.ToInt32(objectRow["INVOICEDETAILID"]);
            if (objectRow["INVOICEID"] != DBNull.Value) this.INVOICEID = Convert.ToInt32(objectRow["INVOICEID"]);
            if (objectRow["PROMOTIONCYCLEID"] != DBNull.Value) this.PROMOTIONCYCLEID = Convert.ToInt32(objectRow["PROMOTIONCYCLEID"]);
            if (objectRow["QTY"] != DBNull.Value) this.QTY = Convert.ToInt32(objectRow["QTY"]);
            if (objectRow["DELIVEREDQTY"] != DBNull.Value) this.DELIVEREDQTY = Convert.ToInt32(objectRow["DELIVEREDQTY"]);
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            if (objectRow["QTY"] != DBNull.Value) this.REQUISIONQTY = Convert.ToInt32(objectRow["QTY"]);
            this.PRODUCTNAME = objectRow["PRODUCTNAME"] as String;
            this.PROMOTIONCYCLENAME = objectRow["PROMOTIONCYCLENAME"] as String;
            this.PROMOTIONNAME = objectRow["PROMOTIONNAME"] as String;

            if (objectRow["FACEVALUE"] != DBNull.Value) this.FACEVALUE = Convert.ToDecimal(objectRow["FACEVALUE"]);
            if (objectRow["SD"] != DBNull.Value) this.SD = Convert.ToDecimal(objectRow["SD"]);
            if (objectRow["VATAMOUNT"] != DBNull.Value) this.VATAMOUNT = Convert.ToDecimal(objectRow["VATAMOUNT"]);
            this.REMARKS = objectRow["REMARKS"] as String;
            this.INVENTORYYN = objectRow["INVENTORYYN"] as string;

        }
    }
}