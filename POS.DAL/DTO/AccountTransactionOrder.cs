using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class AccountTransactionOrder
    {
        public AccountTransactionOrder() { }

        [DataMember]
        public int ACCTRANSACTIONORDERID { get; set; }

        [DataMember]
        public int ACCOUNTTYPEID { get; set; }

        [DataMember]
        public int TRANSACTIONORDER { get; set; }

        public AccountTransactionOrder(DataRow row)
        {
            if (row["ACCTRANSACTIONORDERID"] != DBNull.Value) ACCTRANSACTIONORDERID = int.Parse(row["ACCTRANSACTIONORDERID"].ToString());

            if (row["ACCOUNTTYPEID"] != DBNull.Value) ACCOUNTTYPEID = int.Parse(row["ACCOUNTTYPEID"].ToString());

            if (row["TRANSACTIONORDER"] != DBNull.Value) TRANSACTIONORDER = int.Parse(row["TRANSACTIONORDER"].ToString());

        }
    }
}
