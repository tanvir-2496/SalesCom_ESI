using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class InventoryTransaction
    {
        [DataMember] public System.Int32 TRANSACTIONID { get; set; }
        [DataMember] public System.Int32 STOREID { get; set; }
        [DataMember] public System.String ISSUEORRECEIVE { get; set; }
        [DataMember] public System.String TRANSACTIONREFNO { get; set; }
        [DataMember] public System.Int32 TRANSACTIONREFTYPEID { get; set; }
        [DataMember] public System.DateTime TRANSACTIONDATE { get; set; }

        public InventoryTransaction() { }
        public InventoryTransaction(DataRow objectRow)
        {
            if (objectRow["TRANSACTIONID"] != DBNull.Value) this.TRANSACTIONID = Convert.ToInt32(objectRow["TRANSACTIONID"]);
            if (objectRow["STOREID"] != DBNull.Value) this.STOREID = Convert.ToInt32(objectRow["STOREID"]);
            this.ISSUEORRECEIVE = objectRow["ISSUEORRECEIVE"] as System.String;
             this.TRANSACTIONREFNO = objectRow["TRANSACTIONREFNO"] as String;
            if (objectRow["TRANSACTIONREFTYPEID"] != DBNull.Value) this.TRANSACTIONREFTYPEID = Convert.ToInt32(objectRow["TRANSACTIONREFTYPEID"]);
            if (objectRow["TRANSACTIONDATE"] != DBNull.Value) this.TRANSACTIONDATE = Convert.ToDateTime(objectRow["TRANSACTIONDATE"]);
        }
    }
}