using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Reason
    {
        [DataMember] public System.Int32 REASONID { get; set; }
        [DataMember] public System.String REASON { get; set; }
        [DataMember] public System.Int32 PRICINGPOLICYID { get; set; }
        [DataMember] public System.String PRICINGPOLICY { get; set; }
        public Reason() { }
        public Reason(DataRow objectRow)
        {
            if (objectRow["REASONID"] != DBNull.Value) this.REASONID = Convert.ToInt32(objectRow["REASONID"]);
            this.REASON = objectRow["REASON"] as System.String;
            if (objectRow["PRICINGPOLICYID"] != DBNull.Value) this.PRICINGPOLICYID = Convert.ToInt32(objectRow["PRICINGPOLICYID"]);
            this.PRICINGPOLICY = objectRow["PRICINGPOLICY"] as System.String;
        }
    }
}