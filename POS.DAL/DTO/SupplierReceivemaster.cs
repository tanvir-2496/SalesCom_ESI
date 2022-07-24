using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class SupplierReceivemaster
    { 
        [DataMember]  public System.Decimal RECEIVEID { get; set; }
        [DataMember]  public System.String RECEIVECODE { get; set; }
        [DataMember]  public System.DateTime RECEIVEDATE { get; set; }
        [DataMember]  public System.Decimal SUPPLIERID { get; set; }       
        [DataMember]  public System.String INVOICENO { get; set; }
        [DataMember]  public System.String LCPONO { get; set; }       
        [DataMember]  public System.String REMARKS { get; set; }
        [DataMember]  public System.Decimal WAREHOUSEID { get; set; }       
        [DataMember]  public System.String CREATEBYUSER { get; set; }       
        [DataMember]  public System.DateTime CREATEDATE { get; set; }       
        [DataMember]  public System.String LASTUPDATEBY { get; set; }
        [DataMember]  public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember]  public System.Decimal STOREID { get; set; }
        [DataMember]  public System.Decimal TRANSACTIONID { get; set; }
        [DataMember]  public System.String SUPPLIERCODE { get; set; }
        [DataMember]  public System.String SUPPLIERNAME { get; set; }
        [DataMember]  public System.String WAREHOUSECODE { get; set; }
        [DataMember]  public System.String WAREHOUSENAME { get; set; }
        [DataMember]
        public System.String Status { get; set; }
        [DataMember]
        public System.String PONO { get; set; }
        [DataMember]
        public System.String APPROVEDBY { get; set; }
        [DataMember]
        public System.DateTime APPROVEDDATE { get; set; }
        public SupplierReceivemaster() { }
        public SupplierReceivemaster(DataRow objectRow)
        {
            if (objectRow["RECEIVEID"] != DBNull.Value) this.RECEIVEID = Convert.ToDecimal(objectRow["RECEIVEID"]);
            this.RECEIVECODE = objectRow["RECEIVECODE"] as System.String;
            if (objectRow["RECEIVEDATE"] != DBNull.Value) this.RECEIVEDATE = Convert.ToDateTime(objectRow["RECEIVEDATE"]);
            if (objectRow["SUPPLIERID"] != DBNull.Value) this.SUPPLIERID = Convert.ToDecimal(objectRow["SUPPLIERID"]);
            this.INVOICENO = objectRow["INVOICENO"] as System.String;
            this.LCPONO = objectRow["LCPONO"] as System.String;
            this.REMARKS = objectRow["REMARKS"] as System.String;
            if (objectRow["WAREHOUSEID"] != DBNull.Value) this.WAREHOUSEID = Convert.ToDecimal(objectRow["WAREHOUSEID"]);
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            if (objectRow["STOREID"] != DBNull.Value) this.STOREID = Convert.ToDecimal(objectRow["STOREID"]);
            if (objectRow["TRANSACTIONID"] != DBNull.Value) this.TRANSACTIONID = Convert.ToDecimal(objectRow["TRANSACTIONID"]);
            this.SUPPLIERCODE = objectRow["SUPPLIERCODE"] as System.String;
            this.SUPPLIERNAME = objectRow["SUPPLIERNAME"] as System.String;
            this.WAREHOUSECODE = objectRow["WAREHOUSECODE"] as System.String;
            this.WAREHOUSENAME = objectRow["WAREHOUSENAME"] as System.String;
            this.PONO = objectRow["PONO"] as System.String;
            this.APPROVEDBY = objectRow["APPROVEDBY"] as System.String;
            if (objectRow["APPROVEDDATE"] != DBNull.Value) this.APPROVEDDATE = Convert.ToDateTime(objectRow["APPROVEDDATE"]);
            this.Status = objectRow["Status"] as System.String;

        }
    }
}
