using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class TellerBalance
    {
        [DataMember] public System.Int32 TELLERID { get; set; }
        [DataMember] public System.Decimal CASHBALANCE { get; set; }
        [DataMember] public System.DateTime WORKINGDATE { get; set; }

        public TellerBalance() { }
        public TellerBalance(DataRow objectRow)
        {
            if (objectRow["TELLERID"] != DBNull.Value) this.TELLERID = Convert.ToInt32(objectRow["TELLERID"]);
            if (objectRow["CASHBALANCE"] != DBNull.Value) this.CASHBALANCE = Convert.ToDecimal(objectRow["CASHBALANCE"]);
            if (objectRow["WORKINGDATE"] != DBNull.Value) this.WORKINGDATE = Convert.ToDateTime(objectRow["WORKINGDATE"]);
        }
    }
}
