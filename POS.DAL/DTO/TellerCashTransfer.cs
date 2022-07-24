using System; using System.Runtime.Serialization; 
using System.Data;
namespace POS.DAL
{
    [DataContract] public class TellerCashTransfer
    {
        [DataMember] public System.Int32 CASHTRANSFERID { get; set; }
        [DataMember] public System.Int32 TELLERID { get; set; }
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.DateTime WORKINGDATE { get; set; }
        [DataMember] public System.DateTime TRANSFERTIME { get; set; }
        [DataMember] public System.String TELLERUSER { get; set; }
        [DataMember] public System.String AUTHORIZER { get; set; }
        [DataMember] public System.Decimal TRANSFERAMOUNT { get; set; }
        [DataMember] public System.String INOROUT { get; set; }
        [DataMember] public System.String REMARKS { get; set; }
        [DataMember] public System.String TRANSFERBY { get; set; }
        [DataMember] public System.String TELLERCODE { get; set; }
        [DataMember] public System.Int32 TRANSFERTOTELLERID { get; set; }
        [DataMember] public System.Int32 BANKACCOUNTID { get; set; }
        
        [DataMember] public System.String TRANSFERTOTELLERCODE { get; set; }

        [DataMember]
        public System.String FROMTELLER { get; set; }

        [DataMember]
        public System.String TOTELLER { get; set; }

        public TellerCashTransfer() { }
        public TellerCashTransfer(DataRow objectRow)
        {
            if (objectRow["CASHTRANSFERID"] != DBNull.Value) this.CASHTRANSFERID = Convert.ToInt32(objectRow["CASHTRANSFERID"]);
            if (objectRow["TELLERID"] != DBNull.Value) this.TELLERID = Convert.ToInt32(objectRow["TELLERID"]);

            if (objectRow["TRANSFERTOTELLERID"] != DBNull.Value) this.TRANSFERTOTELLERID = Convert.ToInt32(objectRow["TRANSFERTOTELLERID"]);

            if (objectRow["BANKACCOUNTID"] != DBNull.Value) this.BANKACCOUNTID = Convert.ToInt32(objectRow["BANKACCOUNTID"]);

            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            if (objectRow["WORKINGDATE"] != DBNull.Value) this.WORKINGDATE = Convert.ToDateTime(objectRow["WORKINGDATE"]);
            if (objectRow["TRANSFERTIME"] != DBNull.Value) this.TRANSFERTIME = Convert.ToDateTime(objectRow["TRANSFERTIME"]);
            this.TELLERUSER = objectRow["TELLERUSER"] as System.String;
            this.AUTHORIZER = objectRow["AUTHORIZER"] as System.String;
            if (objectRow["TRANSFERAMOUNT"] != DBNull.Value) this.TRANSFERAMOUNT = Convert.ToDecimal(objectRow["TRANSFERAMOUNT"]);
            this.INOROUT = objectRow["INOROUT"] as System.String;
            this.REMARKS = objectRow["REMARKS"] as System.String;
            this.TRANSFERBY = objectRow["TRANSFERBY"] as System.String;
          this.TELLERCODE = objectRow["TELLERCODE"] as System.String;
           this.TRANSFERTOTELLERCODE = objectRow["TRANSFERTOTELLERCODE"] as System.String;

           this.FROMTELLER = objectRow["FROMTELLER"] as System.String;
           this.TOTELLER = objectRow["TOTELLER"] as System.String;


        }
    }
}