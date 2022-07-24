using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class PackagePromotion
    {
        [DataMember]
        public System.Int32 PROMOTIONID { get; set; }
        [DataMember]
        public System.Int32 PACKAGEID { get; set; }

        public PackagePromotion() { }
        public PackagePromotion(DataRow objectRow)
        {
            if (objectRow["PROMOTIONID"] != DBNull.Value) this.PROMOTIONID = Convert.ToInt32(objectRow["PROMOTIONID"]);
            if (objectRow["PACKAGEID"] != DBNull.Value) this.PACKAGEID = Convert.ToInt32(objectRow["PACKAGEID"]);
        }
    }
}