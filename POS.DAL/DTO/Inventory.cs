using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Inventory
    {
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.Int32 STOREID { get; set; }
        [DataMember] public System.Int32 WAREHOUSECENTERID { get; set; }
        [DataMember] public System.Decimal STOCKQTY { get; set; }
        [DataMember] public System.Decimal AVAILABLEQTY { get; set; }
        [DataMember] public System.String PRODUCTCODE { get; set; }
        [DataMember] public System.String PRODUCTNAME { get; set; }
        [DataMember]
        public System.String CENTERNAME { get; set; }
        [DataMember]
        public System.String SERIALIZEDYN { get; set; }



        public Inventory() { }
        public Inventory(DataRow objectRow)
        {
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            try
            {
                if (objectRow["STOREID"] != DBNull.Value) this.STOREID = Convert.ToInt32(objectRow["STOREID"]);
            }
            catch { }
            if (objectRow["WAREHOUSECENTERID"] != DBNull.Value) this.WAREHOUSECENTERID = Convert.ToInt32(objectRow["WAREHOUSECENTERID"]);
            if (objectRow["STOCKQTY"] != DBNull.Value) this.STOCKQTY = Convert.ToDecimal(objectRow["STOCKQTY"]);
            if (objectRow["AVAILABLEQTY"] != DBNull.Value) this.AVAILABLEQTY = Convert.ToDecimal(objectRow["AVAILABLEQTY"]);


            try {
                this.PRODUCTCODE = objectRow["PRODUCTCODE"] as String;
                this.PRODUCTNAME =objectRow["PRODUCTNAME"] as String;
                this.CENTERNAME = objectRow["CENTERNAME"] as String;
                this.SERIALIZEDYN = objectRow["SERIALIZEDYN"] as String;
            }
            catch { }
        }
    }
}