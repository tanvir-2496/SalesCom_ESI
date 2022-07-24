using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract]
    public class InventorySerials
    {
        [DataMember] public System.String SERIALNO { get; set; }
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.Int32 STOREID { get; set; }
        [DataMember] public System.String AVAILABLEYN { get; set; }
        [DataMember] public System.Int32 WAREHOUSECENTERID { get; set; }
        [DataMember] public System.String STARTSERIALNO { get; set; }
        [DataMember] public System.String ENDSERIALNO { get; set; }
        public InventorySerials() { }
        public InventorySerials(DataRow objectRow)
        {
            if (objectRow["SERIALNO"] != DBNull.Value) this.SERIALNO = objectRow["SERIALNO"].ToString();
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            if (objectRow["STOREID"] != DBNull.Value) this.STOREID = Convert.ToInt32(objectRow["STOREID"]);
             this.AVAILABLEYN = objectRow["AVAILABLEYN"] as String;
            if (objectRow["WAREHOUSECENTERID"] != DBNull.Value) this.WAREHOUSECENTERID = Convert.ToInt32(objectRow["WAREHOUSECENTERID"]);
        }
    }
}