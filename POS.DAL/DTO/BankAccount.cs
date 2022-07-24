using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class BankAccount
    {
        [DataMember] public System.Int32 ACCOUNTID { get; set; }
        [DataMember] public System.String ACCOUNTNO { get; set; }
        [DataMember] public System.String ACCOUNTNAME { get; set; }
        [DataMember] public System.String BANKNAME { get; set; }
        [DataMember] public System.Int32 BANKID { get; set; }
        [DataMember] public System.String GLACCOUNTCODE { get; set; }
        [DataMember] public System.String PROJCODE { get; set; }
        [DataMember] public System.String ACTIVEYN { get; set; }
        [DataMember]public System.Int32 CENTERID { get; set; }

        public BankAccount() { }
        public BankAccount(DataRow objectRow)
        {
            if (objectRow["ACCOUNTID"] != DBNull.Value) this.ACCOUNTID = Convert.ToInt32(objectRow["ACCOUNTID"]);
            this.ACCOUNTNO = objectRow["ACCOUNTNO"] as System.String;
            this.ACCOUNTNAME = objectRow["ACCOUNTNAME"] as System.String;
            if (objectRow["BANKID"] != DBNull.Value) this.BANKID = Convert.ToInt32(objectRow["BANKID"]);
            this.GLACCOUNTCODE = objectRow["GLACCOUNTCODE"] as System.String;
            this.PROJCODE = objectRow["PROJCODE"] as System.String;
            this.ACTIVEYN = objectRow["ACTIVEYN"] as System.String;
            this.BANKNAME = objectRow["BANKNAME"] as System.String;
            this.CENTERID = objectRow["CENTERID"] != DBNull.Value ? Convert.ToInt32(objectRow["CENTERID"]) : 0;
        }
    }
}