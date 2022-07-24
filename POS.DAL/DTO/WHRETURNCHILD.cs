using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract] public class WHRETURNCHILD
    {
        [DataMember] public System.Int32 WHRETURNID { get; set; }
        [DataMember] public System.Int32 CHILDID { get; set; }
        [DataMember]  public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.Decimal QTY { get; set; }
        [DataMember] public System.String SIMSTART { get; set; }
        [DataMember] public System.String SIMEND { get; set; }
        [DataMember] public System.Int32 WAREHOUSECENTERID { get; set; }       
        [DataMember] public System.String CREATEBYUSER { get; set; }       
        [DataMember] public System.String CREATEDATE { get; set; }       
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.String LASTUPDATEDATE { get; set; }
        [DataMember] public System.Int32 STOREID { get; set; }
        [DataMember] public System.Decimal TRANSACTIONID { get; set; }
        [DataMember] public System.String SERIALIZEDYN { get; set; }
        [DataMember] public System.String PRODUCTCODE { get; set; }
        [DataMember] public System.String REFNO { get; set; }
        [DataMember] public System.String PRODUCTNAME { get; set; }
        public  WHRETURNCHILD(){}
        public WHRETURNCHILD(DataRow objectRow)
        {
            if (objectRow["WHRETURNID"] != DBNull.Value) this.WHRETURNID = Convert.ToInt32(objectRow["WHRETURNID"]);
            if (objectRow["CHILDID"] != DBNull.Value) this.CHILDID = Convert.ToInt32(objectRow["CHILDID"]);
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            if (objectRow["QTY"] != DBNull.Value) this.QTY = Convert.ToDecimal(objectRow["QTY"]);
            if (objectRow["SIMSTART"] != DBNull.Value) this.SIMSTART = objectRow["SIMSTART"].ToString();
            if (objectRow["SIMEND"] != DBNull.Value) this.SIMEND = objectRow["SIMEND"].ToString();
            if (objectRow["WAREHOUSECENTERID"] != DBNull.Value) this.WAREHOUSECENTERID = Convert.ToInt32(objectRow["WAREHOUSECENTERID"]);
             this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            this.CREATEDATE = objectRow["CREATEDATE"] as System.String;
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            this.LASTUPDATEDATE = objectRow["LASTUPDATEDATE"] as System.String;
            if (objectRow["STOREID"] != DBNull.Value) this.STOREID = Convert.ToInt32(objectRow["STOREID"]);

            try
            {
                if (objectRow["TRANSACTIONID"] != DBNull.Value) this.TRANSACTIONID = Convert.ToDecimal(objectRow["TRANSACTIONID"]);
            }
            catch { }
            this.REFNO = objectRow["REFNO"] as System.String;
            this.SERIALIZEDYN = objectRow["SERIALIZEDYN"] as System.String;
            this.PRODUCTCODE = objectRow["PRODUCTCODE"] as System.String;
            this.PRODUCTNAME = objectRow["PRODUCTNAME"] as System.String;
           
            
       }
    }
}
