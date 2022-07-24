using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class BufferChild
    {
        [DataMember] public System.Int32 BUFFERID { get; set; }
        [DataMember] public System.Int32 CHDID { get; set; }
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.Decimal TRANSACTIONQTY { get; set; }
        [DataMember] public System.String STARTSERIAL { get; set; }
        [DataMember] public System.String ENDSERIAL { get; set; }
        [DataMember]
        public System.String SERIALIZEDYN { get; set; }
        public BufferChild() { }
        public BufferChild(DataRow objectRow)
        {
            if (objectRow["BUFFERID"] != DBNull.Value) this.BUFFERID = Convert.ToInt32(objectRow["BUFFERID"]);
            if (objectRow["CHDID"] != DBNull.Value) this.CHDID = Convert.ToInt32(objectRow["CHDID"]);
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            if (objectRow["TRANSACTIONQTY"] != DBNull.Value) this.TRANSACTIONQTY = Convert.ToDecimal(objectRow["TRANSACTIONQTY"]);
            if (objectRow["STARTSERIAL"] != DBNull.Value) this.STARTSERIAL = objectRow["STARTSERIAL"].ToString();
            if (objectRow["ENDSERIAL"] != DBNull.Value) this.ENDSERIAL = objectRow["ENDSERIAL"].ToString();
        }
    }
}