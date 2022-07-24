using System; using System.Runtime.Serialization; 
using System.Data;
namespace POS.DAL
{
    
    [DataContract] public class Adjustment
    {
     [DataMember] public System.Int32 RFID { get; set; }
        [DataMember] public System.Int32 ADJUSTMENTID { get; set; }
        [DataMember] public System.DateTime ADJUSTMENTDATE { get; set; }
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.Int32 ADJUSTMENTAMOUNT { get; set; }
        [DataMember] public System.Int32 ADJUSTMENTTYPEID { get; set; }
        [DataMember] public System.String INVOICENO { get; set; }
        [DataMember] public System.Int32 RFRAISERID { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.String ACTIVEYN { get; set; }
        [DataMember] public System.String ADJUSTMENTNO { get; set; }


        [DataMember] public System.String RFCODE { get; set; }

        [DataMember] public System.Int32 CUSTOMERID { get; set; }
        [DataMember] public System.String COLLECTIONTYPE { get; set; }
        [DataMember] public System.String COLLECTIONMODE { get; set; }
        [DataMember] public System.String ADJUSTMENTTYPE { get; set; }
        [DataMember] public System.String CUSTOMER { get; set; }
        [DataMember] public System.String CENTER { get; set; }
        [DataMember] public System.String TELLER { get; set; }
        
        
        
        
        [DataMember] public System.String CUSTOMERNAME { get; set; }
        [DataMember] public System.String ISCOLLECTIONACTIVEYN { get; set; }
        [DataMember] public System.DateTime FROMDATE { get; set; }
        [DataMember] public System.DateTime TODATE { get; set; }
        [DataMember] public System.Int32 DISBURSEACCOUNTID { get; set; }
        [DataMember] public System.String CENTERCODE { get; set; }

        public Adjustment() { }
        public Adjustment(DataRow objectRow)
        {
            if (objectRow["ADJUSTMENTID"] != DBNull.Value) this.ADJUSTMENTID = Convert.ToInt32(objectRow["ADJUSTMENTID"]);
            if (objectRow["ADJUSTMENTDATE"] != DBNull.Value) this.ADJUSTMENTDATE = Convert.ToDateTime(objectRow["ADJUSTMENTDATE"]);
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            if (objectRow["ADJUSTMENTAMOUNT"] != DBNull.Value) this.ADJUSTMENTAMOUNT = Convert.ToInt32(objectRow["ADJUSTMENTAMOUNT"]);
            if (objectRow["ADJUSTMENTTYPEID"] != DBNull.Value) this.ADJUSTMENTTYPEID = Convert.ToInt32(objectRow["ADJUSTMENTTYPEID"]);
            this.INVOICENO = objectRow["INVOICENO"] as System.String;
            if (objectRow["RFRAISERID"] != DBNull.Value) this.RFRAISERID = Convert.ToInt32(objectRow["RFRAISERID"]);
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            this.ACTIVEYN = objectRow["ACTIVEYN"] as System.String;
            this.ADJUSTMENTNO = objectRow["ADJUSTMENTNO"] as System.String;


            this.RFCODE = objectRow["RFCODE"] as System.String;
            this.INVOICENO = objectRow["INVOICENO"] as System.String;
            //if (objectRow["CUSTOMERID"] != DBNull.Value) this.CUSTOMERID = Convert.ToInt32(objectRow["CUSTOMERID"]);
          
            this.ADJUSTMENTTYPE = objectRow["ADJUSTMENTTYPENAME"] as System.String;
           // this.CENTER = objectRow["CENTERNAME"] as System.String;
           // this.TELLER = objectRow["TELLERNAME"] as System.String;
           // this.CUSTOMER = objectRow["CUSTOMERNAME"] as System.String;
            
           // if (this.CUSTOMERID > 0)
              //  this.CUSTOMERNAME = objectRow["CUSTOMERNAME"] as System.String;
           // else
//this.CUSTOMERNAME = objectRow["CUSTOMERCARECUSTOMER"] as System.String;
            
            
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            //try
            //{
            //    if (objectRow["DISBURSEACCOUNTID"] != DBNull.Value) this.DISBURSEACCOUNTID = Convert.ToInt32(objectRow["DISBURSEACCOUNTID"]);
            //}
            //catch { }
        }
    }
}