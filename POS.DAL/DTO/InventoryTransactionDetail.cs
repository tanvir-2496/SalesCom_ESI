using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class InventoryTransactionDetail
    {
        [DataMember] public System.Int32 TRANSACTIONID { get; set; }
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.Int32 TRANSACTIONQTY { get; set; }
        [DataMember] public System.String STARTSERIAL { get; set; }
        [DataMember] public System.String ENDSERIAL { get; set; }
        [DataMember] public System.Int32 CHDID { get; set; }
        [DataMember] public System.Int32 X_STOREID { get; set; }
        [DataMember]
        public System.String SERIALIZEDYN { get; set; }

        public InventoryTransactionDetail() { }
        public InventoryTransactionDetail(DataRow objectRow)
        {
            if (objectRow["TRANSACTIONID"] != DBNull.Value) this.TRANSACTIONID = Convert.ToInt32(objectRow["TRANSACTIONID"]);
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            if (objectRow["TRANSACTIONQTY"] != DBNull.Value) this.TRANSACTIONQTY = Convert.ToInt32(objectRow["TRANSACTIONQTY"]);
            if (objectRow["STARTSERIAL"] != DBNull.Value) this.STARTSERIAL = objectRow["STARTSERIAL"].ToString();
            if (objectRow["ENDSERIAL"] != DBNull.Value) this.ENDSERIAL = objectRow["ENDSERIAL"].ToString();
            if (objectRow["CHDID"] != DBNull.Value) this.CHDID = Convert.ToInt32(objectRow["CHDID"]);
        }
    }
}