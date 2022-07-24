using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class PriceAdjustment
    {
        [DataMember]
        public int PRICEADJUSTMENTID { get; set; }
  
  
        [DataMember]
        public DateTime ADJUSTMENTDATE { get; set; }
  
        [DataMember]
        public string REMARKS { get; set; }
  
        [DataMember]
        public string RECORDSTATUS { get; set; }


        [DataMember]
        public DateTime FROMDATE { get; set; }

        [DataMember]
        public DateTime TODATE { get; set; }


        [DataMember]
        public string TRANSACTIONREFNO { get; set; }

        [DataMember]
        public string ACCOUNTTYPENAME { get; set; }

        [DataMember]
        public string ACCTRANSACTIONTYPENAME { get; set; }

        [DataMember]
        public Int32 ACCOUNTTYPEID { get; set; }

        [DataMember]
        public Int32 ACCTRANSACTIONTYPEID { get; set; }

        [DataMember]
        public System.String CREATEBYUSER { get; set; }
        [DataMember]
        public System.DateTime CREATEDATE { get; set; }
        [DataMember]
        public System.String LASTUPDATEBY { get; set; }
        [DataMember]
        public System.DateTime LASTUPDATEDATE { get; set; }

        [DataMember]
        public System.String PAYABLEORRECEIVEABLE { get; set; }
        

        public PriceAdjustment()
        { }

        public PriceAdjustment(DataRow row)
        {
            if (row["PRICEADJUSTMENTID"] != DBNull.Value) PRICEADJUSTMENTID = int.Parse(row["PRICEADJUSTMENTID"].ToString());

          

            if (row["ADJUSTMENTDATE"] != DBNull.Value) ADJUSTMENTDATE =Convert.ToDateTime( row["ADJUSTMENTDATE"].ToString());

            if (row["REMARKS"] != DBNull.Value) REMARKS = row["REMARKS"].ToString();

            if (row["RECORDSTATUS"] != DBNull.Value) RECORDSTATUS = row["RECORDSTATUS"].ToString();

            if (row["TRANSACTIONREFNO"] != DBNull.Value) TRANSACTIONREFNO = row["TRANSACTIONREFNO"].ToString();

            if (row["ACCOUNTTYPEID"] != DBNull.Value) ACCOUNTTYPEID = int.Parse(row["ACCOUNTTYPEID"].ToString());

            if (row["ACCTRANSACTIONTYPEID"] != DBNull.Value) ACCTRANSACTIONTYPEID = int.Parse(row["ACCTRANSACTIONTYPEID"].ToString());
            this.CREATEBYUSER = row["CREATEBYUSER"] as System.String;
            this.LASTUPDATEBY = row["LASTUPDATEBY"] as System.String;

            this.ACCOUNTTYPENAME = row["ACCOUNTTYPENAME"] as System.String;
            this.ACCTRANSACTIONTYPENAME = row["ACCTRANSACTIONTYPENAME"] as System.String;
            this.PAYABLEORRECEIVEABLE = row["PAYABLEORRECEIVEABLE"] as System.String;



            if (row["CREATEDATE"] != DBNull.Value) CREATEDATE = Convert.ToDateTime(row["CREATEDATE"].ToString());
            this.CREATEBYUSER = row["CREATEBYUSER"] as System.String;
            this.LASTUPDATEBY = row["LASTUPDATEBY"] as System.String;

            if (row["LASTUPDATEDATE"] != DBNull.Value) LASTUPDATEDATE = Convert.ToDateTime(row["LASTUPDATEDATE"].ToString());
          
        }
    }
}
