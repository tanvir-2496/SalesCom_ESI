using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class TransactionType
    {
        [DataMember]
        public int ACCTRANSACTIONTYPEID { get; set; }

        [DataMember]
        public string PAYABLEORRECEIVEABLE { get; set; }

        [DataMember]
        public string DESCRIPTION { get; set; }

        [DataMember]
        public string ACCTRANSACTIONTYPENAME { get; set; }

        [DataMember]
        public string ACCTRANSACTIONTYPECODE { get; set; }

        public TransactionType()
        { }

        public TransactionType(DataRow row)
        {
            if (row["ACCTRANSACTIONTYPEID"] != DBNull.Value) ACCTRANSACTIONTYPEID = int.Parse(row["ACCTRANSACTIONTYPEID"].ToString());

            if (row["PAYABLEORRECEIVEABLE"] != DBNull.Value) PAYABLEORRECEIVEABLE = row["PAYABLEORRECEIVEABLE"].ToString();

            if (row["DESCRIPTION"] != DBNull.Value) DESCRIPTION = row["DESCRIPTION"].ToString();

            if (row["ACCTRANSACTIONTYPENAME"] != DBNull.Value) ACCTRANSACTIONTYPENAME = row["ACCTRANSACTIONTYPENAME"].ToString();

            if (row["ACCTRANSACTIONTYPECODE"] != DBNull.Value) ACCTRANSACTIONTYPECODE = row["ACCTRANSACTIONTYPECODE"].ToString();
        }
    }
}
