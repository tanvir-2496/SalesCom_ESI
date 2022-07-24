using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract] public class WHPRODUCTIONMASTER
    {
        [DataMember] public System.Int32 WHPRODUCTIONID { get; set; }
        [DataMember] public System.String WHPRODUCTIONCODE { get; set; }
        [DataMember] public System.DateTime WHPRODUCTIONDATE { get; set; }
        [DataMember] public System.String PRODUCTIONCON { get; set; }
        [DataMember] public System.Decimal FROMPRODUCTID { get; set; }
        [DataMember] public System.Int32 TOPRODUCTID { get; set; }
        [DataMember] public System.Decimal TRANSACTIONRECEIVEID { get; set; }
        [DataMember] public System.Decimal TRANSACTIONISSUEID { get; set; }
        [DataMember] public System.String RFNO { get; set; }
        [DataMember] public System.String REMARKS { get; set; }
        [DataMember] public System.Int32 STOREID { get; set; }
        [DataMember] public System.Int32 WAREHOUSEID { get; set; }       
        [DataMember] public System.String CREATEBYUSER { get; set; }       
        [DataMember] public System.DateTime CREATEDATE { get; set; }       
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.DateTime STARTDATE { get; set; }
        [DataMember] public System.DateTime ENDDATE { get; set; }
       
        public WHPRODUCTIONMASTER() { }
        public WHPRODUCTIONMASTER(DataRow objectRow)
        {
            if (objectRow["WHPRODUCTIONID"] != DBNull.Value) this.WHPRODUCTIONID = Convert.ToInt32(objectRow["WHPRODUCTIONID"]);
            this.WHPRODUCTIONCODE = objectRow["WHPRODUCTIONCODE"] as System.String;
            if (objectRow["WHPRODUCTIONDATE"] != DBNull.Value) this.WHPRODUCTIONDATE = Convert.ToDateTime(objectRow["WHPRODUCTIONDATE"]);
            this.PRODUCTIONCON = objectRow["PRODUCTIONCON"] as System.String;
            if (objectRow["FROMPRODUCTID"] != DBNull.Value) this.FROMPRODUCTID = Convert.ToDecimal(objectRow["FROMPRODUCTID"]);
            if (objectRow["TOPRODUCTID"] != DBNull.Value) this.TOPRODUCTID = Convert.ToInt32(objectRow["TOPRODUCTID"]);
            if (objectRow["TRANSACTIONRECEIVEID"] != DBNull.Value) this.TRANSACTIONRECEIVEID = Convert.ToDecimal(objectRow["TRANSACTIONRECEIVEID"]);
            if (objectRow["TRANSACTIONISSUEID"] != DBNull.Value) this.TRANSACTIONISSUEID = Convert.ToDecimal(objectRow["TRANSACTIONISSUEID"]);
            this.RFNO = objectRow["RFNO"] as System.String;
            this.REMARKS = objectRow["REMARKS"] as System.String;
            if (objectRow["STOREID"] != DBNull.Value) this.STOREID = Convert.ToInt32(objectRow["STOREID"]);
            if (objectRow["WAREHOUSEID"] != DBNull.Value) this.WAREHOUSEID = Convert.ToInt32(objectRow["WAREHOUSEID"]);
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
              this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
              if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
              //if (objectRow["STARTDATE"] != DBNull.Value) this.STARTDATE = Convert.ToDateTime(objectRow["STARTDATE"]);
             // if (objectRow["ENDDATE"] != DBNull.Value) this.ENDDATE = Convert.ToDateTime(objectRow["ENDDATE"]);
               
   
        }
    }
}
