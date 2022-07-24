using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Promotions
    {
        [DataMember] public System.Int32 PROMOTIONID { get; set; }
        [DataMember] public System.String PROMOTIONNAME { get; set; }
        [DataMember] public System.String  ALLPREPAIDPACKAGESYN {get;set;}
        [DataMember] public System.String  ALLPOSTPAIDPACKAGESYN {get;set;}
        [DataMember] public System.String  ALLCCPACKAGESYN {get;set;}
        [DataMember] public System.String  SELECTEDPACKAGESYN {get;set;}
        [DataMember]public System.String ISDEFAULT { get; set; }
    
        public Promotions() { }
        public Promotions(DataRow objectRow)
        {
            if (objectRow["PROMOTIONID"] != DBNull.Value) this.PROMOTIONID = Convert.ToInt32(objectRow["PROMOTIONID"]);
            this.PROMOTIONNAME = objectRow["PROMOTIONNAME"] as System.String;
            this.ALLPREPAIDPACKAGESYN = objectRow["ALLPREPAIDPACKAGESYN"] as System.String;
            this.ALLPOSTPAIDPACKAGESYN = objectRow["ALLPOSTPAIDPACKAGESYN"] as System.String;
            this.ALLCCPACKAGESYN = objectRow["ALLCCPACKAGESYN"] as System.String;
            this.SELECTEDPACKAGESYN = objectRow["SELECTEDPACKAGESYN"] as System.String;
            this.ISDEFAULT = objectRow["ISDEFAULT"] as System.String;
        }
    }
}