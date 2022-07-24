using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Bank
    {
        [DataMember] public System.Int32 BANKID { get; set; }
        [DataMember] public System.String BANKNAME { get; set; }

        public Bank() { }
        public Bank(DataRow objectRow)
        {
            if (objectRow["BANKID"] != DBNull.Value) this.BANKID = Convert.ToInt32(objectRow["BANKID"]);
            this.BANKNAME = objectRow["BANKNAME"] as System.String;
        }
    }
}