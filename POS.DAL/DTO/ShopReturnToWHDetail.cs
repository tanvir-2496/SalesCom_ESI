using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ShopReturnToWHDetail
    {
        [DataMember] public System.Int32 RETURNID { get; set; }
        [DataMember] public System.Int32 SLNO { get; set; }
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.Int32 RETURNQTY { get; set; }
        [DataMember] public System.String STARTSERIAL { get; set; }
        [DataMember] public System.String ENDSERIAL { get; set; }

        public ShopReturnToWHDetail() { }
        public ShopReturnToWHDetail(DataRow objectRow)
        {
            if (objectRow["SHOPRETURNID"] != DBNull.Value) this.RETURNID = Convert.ToInt32(objectRow["SHOPRETURNID"]);
            if (objectRow["SLNO"] != DBNull.Value) this.SLNO = Convert.ToInt32(objectRow["SLNO"]);
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            if (objectRow["RETURNQTY"] != DBNull.Value) this.RETURNQTY = Convert.ToInt32(objectRow["RETURNQTY"]);
            if (objectRow["STARTSERIAL"] != DBNull.Value) this.STARTSERIAL = objectRow["STARTSERIAL"].ToString();
            if (objectRow["ENDSERIAL"] != DBNull.Value) this.ENDSERIAL = objectRow["ENDSERIAL"].ToString();
        }
    }
}