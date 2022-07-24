using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class InventoryTransactionRef
    {
        [DataMember] public System.Int32 TRANSACTIONREFTYPEID { get; set; }
        [DataMember] public System.String TRANSACTIONREFTYPENAME { get; set; }
        [DataMember] public System.String DESCRIPTION { get; set; }

        public InventoryTransactionRef() { }
        public InventoryTransactionRef(DataRow objectRow)
        {
            if (objectRow["TRANSACTIONREFTYPEID"] != DBNull.Value) this.TRANSACTIONREFTYPEID = Convert.ToInt32(objectRow["TRANSACTIONREFTYPEID"]);
            this.TRANSACTIONREFTYPENAME = objectRow["TRANSACTIONREFTYPENAME"] as System.String;
            this.DESCRIPTION = objectRow["DESCRIPTION"] as System.String;
        }
    }
}