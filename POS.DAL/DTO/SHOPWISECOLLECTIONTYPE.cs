using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ShopWiseCollectionType
    {
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.Int32 COLLECTIONTYPEID { get; set; }
        [DataMember] public System.String COLLECTIONTYPENAME { get; set; }

        public ShopWiseCollectionType() { }
        public ShopWiseCollectionType(DataRow objectRow)
        {
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            if (objectRow["COLLECTIONTYPEID"] != DBNull.Value) this.COLLECTIONTYPEID = Convert.ToInt32(objectRow["COLLECTIONTYPEID"]);
            this.COLLECTIONTYPENAME = objectRow["COLLECTIONTYPENAME"] as System.String;
        }
    }
}