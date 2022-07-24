using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
namespace POS.DAL
{
   [DataContract]  public class SupplierReceivechild
    {
   
        [DataMember]   public System.Decimal RECEIVEID { get; set; }
       [DataMember]  public System.Decimal CHILDID { get; set; }
        [DataMember]  public System.Decimal PRODUCTID { get; set; }
        [DataMember]  public System.Decimal QTY { get; set; }
        [DataMember]  public System.String SIMSTART { get; set; }
        [DataMember]  public System.String SIMEND { get; set; }
        [DataMember]  public System.String WAREHOUSEID { get; set; }       
        [DataMember]  public System.String CREATEBYUSER { get; set; }       
        [DataMember]  public System.String CREATEDATE { get; set; }       
        [DataMember]  public System.String LASTUPDATEBY { get; set; }
        [DataMember]  public System.String LASTUPDATEDATE { get; set; }
        [DataMember]  public System.Decimal STOREID { get; set; }
        [DataMember]  public System.Decimal TRANSACTIONID { get; set; }
        [DataMember]  public System.String SERIALIZEDYN { get; set; }
        [DataMember]  public System.String PRODUCTCODE { get; set; }
        [DataMember]  public System.String PRODUCTNAME { get; set; }
       public  SupplierReceivechild(){}
       public SupplierReceivechild(DataRow objectRow)
        {
            if (objectRow["RECEIVEID"] != DBNull.Value) this.RECEIVEID = Convert.ToDecimal(objectRow["RECEIVEID"]);
            if (objectRow["CHILDID"] != DBNull.Value) this.CHILDID = Convert.ToDecimal(objectRow["CHILDID"]);
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToDecimal(objectRow["PRODUCTID"]);
            if (objectRow["QTY"] != DBNull.Value) this.QTY = Convert.ToDecimal(objectRow["QTY"]);
            if (objectRow["SIMSTART"] != DBNull.Value) this.SIMSTART = objectRow["SIMSTART"].ToString();
            if (objectRow["SIMEND"] != DBNull.Value) this.SIMEND = objectRow["SIMEND"].ToString();
             this.WAREHOUSEID = objectRow["WAREHOUSEID"] as System.String;
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            this.CREATEDATE = objectRow["CREATEDATE"] as System.String;
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            this.LASTUPDATEDATE = objectRow["LASTUPDATEDATE"] as System.String;
            if (objectRow["STOREID"] != DBNull.Value) this.STOREID = Convert.ToDecimal(objectRow["STOREID"]);
            if (objectRow["TRANSACTIONID1"] != DBNull.Value) this.TRANSACTIONID = Convert.ToDecimal(objectRow["TRANSACTIONID1"]);
            this.SERIALIZEDYN = objectRow["SERIALIZEDYN"] as System.String;
            this.PRODUCTCODE = objectRow["PRODUCTCODE"] as System.String;
            this.PRODUCTNAME = objectRow["PRODUCTNAME"] as System.String;
           
            
       }
    }
}
