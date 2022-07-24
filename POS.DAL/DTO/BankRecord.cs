using System;
using System.Runtime.Serialization;
using System.Data;

namespace POS.DAL
{
    [DataContract]
    public class BankRecord
    {
        [DataMember]
        public string BANKCODE { set; get; }
        [DataMember]
        public string BANK_NAME { set; get; }

        public BankRecord()
        {
        }

        public BankRecord(DataRow objectRow)
        {
            this.BANKCODE = objectRow["BANKCODE"] as System.String;
            this.BANK_NAME = objectRow["BANK_NAME"] as System.String;
        }
    }
}