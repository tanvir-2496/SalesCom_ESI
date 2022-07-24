using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class DistributorTransaction
    {
        [DataMember]
        public int TRANSACTIONID { get; set; }

        [DataMember]
        public Int32 ACCTRANSACTIONTYPEID { get; set; }

        [DataMember]
        public string ACCOUNTCODE { get; set; }

        [DataMember]
        public decimal DRAMOUNT { get; set; }

        [DataMember]
        public string REFNO { get; set; }



        [DataMember]
        public DateTime TRANSACTIONDATE { get; set; }



        [DataMember]
        public decimal UPDATEDBALANCE { get; set; }

        [DataMember]
        public decimal CRAMOUNT { get; set; }


        [DataMember]
        public string REMARKS { get; set; }





        public DistributorTransaction()
        { }

        public DistributorTransaction(DataRow row)
        {
            if (row["TRANSACTIONID"] != DBNull.Value) TRANSACTIONID = int.Parse(row["TRANSACTIONID"].ToString());
            if (row["ACCTRANSACTIONTYPEID"] != DBNull.Value) ACCTRANSACTIONTYPEID = int.Parse(row["ACCTRANSACTIONTYPEID"].ToString());
            if (row["ACCOUNTCODE"] != DBNull.Value) ACCOUNTCODE = row["ACCOUNTCODE"].ToString();
            if (row["DRAMOUNT"] != DBNull.Value) DRAMOUNT = decimal.Parse(row["DRAMOUNT"].ToString());
            if (row["REFNO"] != DBNull.Value) REFNO = row["REFNO"].ToString();
            if (row["TRANSACTIONDATE"] != DBNull.Value) TRANSACTIONDATE = DateTime.Parse(row["TRANSACTIONDATE"].ToString());
            if (row["UPDATEDBALANCE"] != DBNull.Value) UPDATEDBALANCE = decimal.Parse(row["UPDATEDBALANCE"].ToString());
            if (row["CRAMOUNT"] != DBNull.Value) CRAMOUNT = decimal.Parse(row["CRAMOUNT"].ToString());
            if (row["REMARKS"] != DBNull.Value) REMARKS = row["REMARKS"].ToString();
        }
    }
}
