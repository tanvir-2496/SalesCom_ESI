using System; 
using System.Runtime.Serialization;
using System.Data;

namespace POS.DAL
{    
    [DataContract]
    public class BankAccountCenter
    {
        [DataMember]public System.Int32 BANKACCOUNTCENTERID { get; set; }
        [DataMember]public System.Int32 ACCOUNTID { get; set; }
        [DataMember]public System.Int32 CENTERID { get; set; }        

        public BankAccountCenter() { }
        public BankAccountCenter(DataRow objectRow)
        {
            if (objectRow["BANKACCOUNTCENTERID"] != DBNull.Value) this.BANKACCOUNTCENTERID = Convert.ToInt32(objectRow["BANKACCOUNTCENTERID"]);
            if (objectRow["ACCOUNTID"] != DBNull.Value) this.ACCOUNTID = Convert.ToInt32(objectRow["ACCOUNTID"]);
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
        }
    }
}
