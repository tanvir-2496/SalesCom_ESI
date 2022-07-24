using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ProductPricingDetail
    {
        [DataMember] public System.Int32 PRICEBREAKUPID { get; set; }
        [DataMember] public System.Int32 PRICINGMASTERID { get; set; }
        [DataMember] public System.String PRICEBREAKUP { get; set; }
        [DataMember] public System.String INCLUDEINVOICEYN { get; set; }
        [DataMember] public System.Decimal AMOUNT { get; set; }
        [DataMember] public System.String PRICEBREAKUPNAME { get; set; }
        [DataMember] public System.String DRORCR { get; set; }
          
        public ProductPricingDetail() { }
        public ProductPricingDetail(DataRow objectRow)
        {
            if (objectRow["PRICEBREAKUPID"] != DBNull.Value) this.PRICEBREAKUPID = Convert.ToInt32(objectRow["PRICEBREAKUPID"]);
            if (objectRow["PRICINGMASTERID"] != DBNull.Value) this.PRICINGMASTERID = Convert.ToInt32(objectRow["PRICINGMASTERID"]);
            this.PRICEBREAKUP = objectRow["PRICEBREAKUP"] as System.String;
            if (objectRow["AMOUNT"] != DBNull.Value) this.AMOUNT = Convert.ToDecimal(objectRow["AMOUNT"]);
            this.PRICEBREAKUPNAME = objectRow["PRICEBREAKUPNAME"] as System.String;
            this.INCLUDEINVOICEYN = objectRow["INCLUDEINVOICEYN"] as System.String;
            this.DRORCR = objectRow["DRORCR"] as System.String;
        }
    }
}