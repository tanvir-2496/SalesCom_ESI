using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class PayableReceivableMaster
    {
        [DataMember]
        public System.Int32 PAYABLERECEIVEABLEID { get; set; }

        [DataMember]
        public System.Int32 ACCTRANSACTIONTYPEID { get; set; }

        [DataMember]
        public System.String ACCTRANSACTIONTYPENAME { get; set; }


        [DataMember]
        public System.Int32 ACCOUNTTYPEID { get; set; }

        [DataMember]
        public System.String ACCOUNTTYPENAME { get; set; }

        [DataMember]
        public System.DateTime TRANSACTIONDATE { get; set; }

        [DataMember]
        public System.String TRANSACTIONREFNO { get; set; }

        [DataMember]
        public System.String REMARKS { get; set; }

        [DataMember]
        public System.String PAYABLEORRECEIVABLE { get; set; }

        [DataMember]
        public System.String APPROVEDBY { get; set; }

        [DataMember]
        public System.DateTime APPROVEDDATE { get; set; }

        [DataMember]
        public System.String RECORDSTATUS { get; set; }

        [DataMember]
        public System.String CREATEBYUSER { get; set; }

        [DataMember]
        public System.DateTime CREATEDATE { get; set; }

        [DataMember]
        public System.String LASTUPDATEBY { get; set; }

        [DataMember]
        public System.DateTime LASTUPDATEDATE { get; set; }




        public PayableReceivableMaster() { }
        public PayableReceivableMaster(DataRow objectRow)
        {
            if (objectRow["PAYABLERECEIVEABLEID"] != DBNull.Value)
                this.PAYABLERECEIVEABLEID = Convert.ToInt32(objectRow["PAYABLERECEIVEABLEID"]);

            if (objectRow["ACCTRANSACTIONTYPEID"] != DBNull.Value)
                this.ACCTRANSACTIONTYPEID = int.Parse(objectRow["ACCTRANSACTIONTYPEID"].ToString());

            if (objectRow["ACCTRANSACTIONTYPENAME"] != DBNull.Value)
                this.ACCTRANSACTIONTYPENAME = objectRow["ACCTRANSACTIONTYPENAME"].ToString();

            if (objectRow["ACCOUNTTYPEID"] != DBNull.Value)
                this.ACCOUNTTYPEID = Int32.Parse(objectRow["ACCOUNTTYPEID"].ToString());

            if (objectRow["ACCOUNTTYPENAME"] != DBNull.Value)
                this.ACCOUNTTYPENAME = objectRow["ACCOUNTTYPENAME"].ToString();

            if (objectRow["TRANSACTIONDATE"] != DBNull.Value)
                this.TRANSACTIONDATE = DateTime.Parse(objectRow["TRANSACTIONDATE"].ToString());

            if (objectRow["TRANSACTIONREFNO"] != DBNull.Value) 
                TRANSACTIONREFNO = objectRow["TRANSACTIONREFNO"].ToString();

            if (objectRow["REMARKS"] != DBNull.Value)
                this.REMARKS = objectRow["REMARKS"] as System.String;

            if (objectRow["PAYABLEORRECEIVABLE"] != DBNull.Value)
                this.PAYABLEORRECEIVABLE = objectRow["PAYABLEORRECEIVABLE"] as System.String;

            if (objectRow["APPROVEDBY"] != DBNull.Value)
                this.APPROVEDBY = objectRow["APPROVEDBY"].ToString();

            if (objectRow["APPROVEDDATE"] != DBNull.Value)
                this.APPROVEDDATE = DateTime.Parse(objectRow["APPROVEDDATE"].ToString());

            if (objectRow["RECORDSTATUS"] != DBNull.Value)
                this.RECORDSTATUS = objectRow["RECORDSTATUS"] as System.String;

            if (objectRow["CREATEBYUSER"] != DBNull.Value)
                this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;

            if (objectRow["CREATEDATE"] != DBNull.Value)
                this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);

            if (objectRow["LASTUPDATEBY"] != DBNull.Value)
                this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;

            if (objectRow["LASTUPDATEDATE"] != DBNull.Value)
                this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
        }
    }
}
