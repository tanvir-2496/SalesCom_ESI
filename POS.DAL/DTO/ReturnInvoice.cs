using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ReturnInvoice
    {
        [DataMember] public System.Int32 RETURNINVOICEID { get; set; }
        [DataMember] public System.String RETURNINVOICENO { get; set; }
        [DataMember] public System.String RETURNINVOICEREF { get; set; }
        [DataMember] public System.String RETURNINVOICEREFTYPE { get; set; }
        [DataMember] public System.DateTime RETURNINVOICEDATE { get; set; }
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.Int32 CUSTOMERID { get; set; }
        [DataMember] public System.Decimal INVOICEAMOUNT { get; set; }
        [DataMember] public System.String REMARKS { get; set; }
        [DataMember] public System.String CREATEDBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.String RECORDSTATUS { get; set; }
        [DataMember] public System.DateTime STARTRFDATE { get; set; }
        [DataMember] public System.DateTime ENDRFDATE { get; set; }
        [DataMember] public System.Int32 RETURNID { get; set; }
        [DataMember] public System.String CUSTOMERNAME { get; set; }
        [DataMember] public System.String CENTERNAME { get; set; }
        [DataMember] public System.String INVOICESTATUS { get; set; }
        
        public ReturnInvoice() { }
        public ReturnInvoice(DataRow objectRow)
        {
            if (objectRow["RETURNINVOICEID"] != DBNull.Value) this.RETURNINVOICEID = Convert.ToInt32(objectRow["RETURNINVOICEID"]);
            this.RETURNINVOICENO = objectRow["RETURNINVOICENO"] as System.String;
            this.RETURNINVOICEREF = objectRow["RETURNINVOICEREF"] as System.String;
            this.RETURNINVOICEREFTYPE = objectRow["RETURNINVOICEREFTYPE"] as System.String;
            if (objectRow["RETURNINVOICEDATE"] != DBNull.Value) this.RETURNINVOICEDATE = Convert.ToDateTime(objectRow["RETURNINVOICEDATE"]);
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            if (objectRow["CUSTOMERID"] != DBNull.Value) this.CUSTOMERID = Convert.ToInt32(objectRow["CUSTOMERID"]);
            if (objectRow["INVOICEAMOUNT"] != DBNull.Value) this.INVOICEAMOUNT = Convert.ToDecimal(objectRow["INVOICEAMOUNT"]);
            this.REMARKS = objectRow["REMARKS"] as System.String;
            this.CREATEDBYUSER = objectRow["CREATEDBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            this.RECORDSTATUS = objectRow["RECORDSTATUS"] as System.String;
            if (objectRow["RETURNID"] != DBNull.Value) this.RETURNID = Convert.ToInt32(objectRow["RETURNID"]);
            this.CUSTOMERNAME = objectRow["CUSTOMERNAME"] as String;
            this.CENTERNAME = objectRow["CENTERNAME"] as String;
            this.INVOICESTATUS = objectRow["INVOICESTATUS"] as String;
        }
    }
}