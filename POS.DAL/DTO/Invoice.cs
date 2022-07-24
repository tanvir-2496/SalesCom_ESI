using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Invoice
    {
        [DataMember] public System.Int32 INVOICEID { get; set; }
        [DataMember] public System.String INVOICENO { get; set; }
        [DataMember] public System.String INVOICEREF { get; set; }
        [DataMember] public System.String INVOICEREFTYPE { get; set; }
        [DataMember] public System.DateTime INVOICEDATE { get; set; }
        [DataMember] public System.Int32 CUSTOMERID { get; set; }
        [DataMember] public System.Int32 SALESPERSONID { get; set; }
        [DataMember] public System.Decimal INVOICEAMOUNT { get; set; }
        [DataMember] public System.String CREATEDBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.String PAYMENTSTATUS { get; set; }
        [DataMember] public System.String RECORDSTATUS { get; set; }
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.DateTime STARTRFDATE { get; set; }
        [DataMember] public System.DateTime ENDRFDATE { get; set; }
        [DataMember] public System.String CUSTOMERNAME { get; set; }
        [DataMember] public System.String SALESPERSONNAME { get; set; }
        [DataMember] public System.String CENTERNAME { get; set; }
        [DataMember] public System.String INVOICESTATUS { get; set; }
        [DataMember] public System.Int32 RFRAISERID { get; set; }
        [DataMember] public System.String ACTIVEYN { get; set; }
        [DataMember] public System.String MSISDN { get; set; }
        [DataMember] public System.String ISDELIVERED { get; set; }
        [DataMember] public System.Int32 COLLECTIONID { get; set; }
        [DataMember]public System.String PRODUCTSNAME { get; set; }
        [DataMember]
        public System.String PRODUCTSL { get; set; }
        public Invoice() { }
        public Invoice(DataRow objectRow)
        {
            if (objectRow["INVOICEID"] != DBNull.Value) this.INVOICEID = Convert.ToInt32(objectRow["INVOICEID"]);
            this.INVOICENO = objectRow["INVOICENO"] as string;

            this.INVOICEREF = objectRow["INVOICEREF"] as System.String;
            this.INVOICEREFTYPE = objectRow["INVOICEREFTYPE"] as System.String;
            if (objectRow["INVOICEDATE"] != DBNull.Value) this.INVOICEDATE = Convert.ToDateTime(objectRow["INVOICEDATE"]);
            if (objectRow["CUSTOMERID"] != DBNull.Value) this.CUSTOMERID = Convert.ToInt32(objectRow["CUSTOMERID"]);
            if (objectRow["SALESPERSONID"] != DBNull.Value) this.SALESPERSONID = Convert.ToInt32(objectRow["SALESPERSONID"]);
            if (objectRow["INVOICEAMOUNT"] != DBNull.Value) this.INVOICEAMOUNT = Convert.ToDecimal(objectRow["INVOICEAMOUNT"]);
            this.CREATEDBYUSER = objectRow["CREATEDBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            this.PAYMENTSTATUS = objectRow["PAYMENTSTATUS"] as System.String;
            this.RECORDSTATUS = objectRow["RECORDSTATUS"] as System.String;
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            this.CUSTOMERNAME = objectRow["CUSTOMERNAME"] as System.String;
            this.SALESPERSONNAME = objectRow["SALESPERSONNAME"] as System.String;
            this.CENTERNAME = objectRow["CENTERNAME"] as System.String;
            this.INVOICESTATUS = objectRow["INVOICESTATUS"] as System.String;
            this.MSISDN = objectRow["MSISDN"] as System.String;           
            if(objectRow.Table.Columns.Contains("COLLECTIONID"))
            {
                this.COLLECTIONID = objectRow["COLLECTIONID"] != DBNull.Value ? Convert.ToInt32(objectRow["COLLECTIONID"]) : 0;
            }
            
            try
            {
                if (objectRow["RFRAISERID"] != DBNull.Value) this.RFRAISERID = Convert.ToInt32(objectRow["RFRAISERID"]);
               
            }
            catch { }
            try{
                this.ISDELIVERED = objectRow["ISDELIVERED"] as System.String;
            }catch{}
            try
            {
                this.PRODUCTSNAME = objectRow["PRODUCTSNAME"] as System.String;
            }
            catch { } 
            try
            {
                this.PRODUCTSL = objectRow["PRODUCTSL"] as System.String;
            }
            catch { }
            this.ACTIVEYN = objectRow["ACTIVEYN"] as System.String;
        }
    }
}