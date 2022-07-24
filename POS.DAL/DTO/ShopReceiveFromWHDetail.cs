using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ShopReceiveFromWHDetail
    {
        [DataMember] public System.Int32 RECEIVINGID { get; set; }
        [DataMember] public System.Int32 SLNO { get; set; }
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.Int32 RECEIVEQTY { get; set; }
        [DataMember] public System.String STARTSERIAL { get; set; }
        [DataMember] public System.String ENDSERIAL { get; set; }

        public ShopReceiveFromWHDetail() { }
        public ShopReceiveFromWHDetail(DataRow objectRow)
        {
            if (objectRow["RECEIVINGID"] != DBNull.Value) this.RECEIVINGID = Convert.ToInt32(objectRow["RECEIVINGID"]);
            if (objectRow["SLNO"] != DBNull.Value) this.SLNO = Convert.ToInt32(objectRow["SLNO"]);
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            if (objectRow["RECEIVEQTY"] != DBNull.Value) this.RECEIVEQTY = Convert.ToInt32(objectRow["RECEIVEQTY"]);
            if (objectRow["STARTSERIAL"] != DBNull.Value) this.STARTSERIAL = objectRow["STARTSERIAL"].ToString();
            if (objectRow["ENDSERIAL"] != DBNull.Value) this.ENDSERIAL = objectRow["ENDSERIAL"].ToString();
        }
    }
}