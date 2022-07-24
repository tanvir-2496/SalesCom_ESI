using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class PriceBreakups
    {
        [DataMember] public System.Int32 PRICEBREAKUPID { get; set; }
        [DataMember] public System.String PRICEBREAKUPNAME { get; set; }
        [DataMember] public System.String DESCRIPTION { get; set; }
        [DataMember] public System.String DISPLAYNAME { get; set; }
        [DataMember] public System.String DRCR { get; set; }
        [DataMember] public System.Int32 ARRANGEORDER { get; set; }
        [DataMember] public System.String PROJCODE { get; set; }
        [DataMember] public System.String ACCNUMBER { get; set; }
        
        public PriceBreakups() { }
        public PriceBreakups(DataRow objectRow)
        {
            if (objectRow["PRICEBREAKUPID"] != DBNull.Value) this.PRICEBREAKUPID = Convert.ToInt32(objectRow["PRICEBREAKUPID"]);
            if (objectRow["ARRANGEORDER"] != DBNull.Value) this.ARRANGEORDER = Convert.ToInt32(objectRow["ARRANGEORDER"]);
            this.PROJCODE = objectRow["PROJCODE"] as System.String;
            this.ACCNUMBER = objectRow["ACCNUMBER"] as System.String;
            this.DRCR = objectRow["DRCR"] as System.String;
            this.PRICEBREAKUPNAME = objectRow["PRICEBREAKUPNAME"] as System.String;
            this.DESCRIPTION = objectRow["DESCRIPTION"] as System.String;
            this.DISPLAYNAME = objectRow["DISPLAYNAME"] as System.String;
        }
    }
}