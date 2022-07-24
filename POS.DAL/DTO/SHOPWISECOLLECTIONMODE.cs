using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ShopWiseCollectionMode
    {
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.Int32 COLLECTIONMODEID { get; set; }
        [DataMember] public System.String COLLECTIOMMODECODE { get; set; }

        public ShopWiseCollectionMode() { }
        public ShopWiseCollectionMode(DataRow objectRow)
        {
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            if (objectRow["COLLECTIONMODEID"] != DBNull.Value) this.COLLECTIONMODEID = Convert.ToInt32(objectRow["COLLECTIONMODEID"]);
            this.COLLECTIOMMODECODE = objectRow["COLLECTIOMMODECODE"] as System.String;
        }
    }
}