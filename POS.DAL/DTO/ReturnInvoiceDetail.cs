using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ReturnInvoiceDetail
    {
        [DataMember] public System.Int32 RETURNINVOICEDETAILID { get; set; }
        [DataMember] public System.Int32 RETURNINVOICEID { get; set; }
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.Int32 PROMOTIONCYCLEID { get; set; }
        [DataMember] public System.Int32 RETURNQTY { get; set; }
        [DataMember] public System.String RFREF { get; set; }
            [DataMember] public System.String PRODUCTNAME { get; set; }

        public ReturnInvoiceDetail() { }
        public ReturnInvoiceDetail(DataRow objectRow)
        {
            if (objectRow["RETURNINVOICEDETAILID"] != DBNull.Value) this.RETURNINVOICEDETAILID = Convert.ToInt32(objectRow["RETURNINVOICEDETAILID"]);
            if (objectRow["RETURNINVOICEID"] != DBNull.Value) this.RETURNINVOICEID = Convert.ToInt32(objectRow["RETURNINVOICEID"]);
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            if (objectRow["PROMOTIONCYCLEID"] != DBNull.Value) this.PROMOTIONCYCLEID = Convert.ToInt32(objectRow["PROMOTIONCYCLEID"]);
            if (objectRow["RETURNQTY"] != DBNull.Value) this.RETURNQTY = Convert.ToInt32(objectRow["RETURNQTY"]);
            this.RFREF = objectRow["RFREF"] as System.String;
            this.PRODUCTNAME = objectRow["PRODUCTNAME"] as System.String;
                
        }
    }
}