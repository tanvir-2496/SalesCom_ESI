using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ProductPriceBreakupDetail
    {
        [DataMember] public System.Int32 BREAKUPMASTERID { get; set; }
        [DataMember] public System.Int32 PRICEBREAKUPID { get; set; }
        [DataMember] public System.String INCLUDEINVOICEYN { get; set; }
        [DataMember] public System.String ACCOUNTNO { get; set; }
        [DataMember] public System.String INVOICECAPTION { get; set; }
        [DataMember] public System.String PROJCODE { get; set; }
        [DataMember] public System.Decimal AMOUNT { get; set; }
        [DataMember] public System.String DRORCR { get; set; }
        [DataMember] public System.String CHANNELNAME { get; set; }
        [DataMember] public System.String PRODUCTNAME { get; set; }
        [DataMember] public System.String PRICEBREAKUPNAME { get; set; }
        [DataMember] public System.Int32 CHANNELID { get; set; }
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.String ENABLEDYN { get; set; }
        [DataMember] public System.String APPROVEDBY { get; set; }
        [DataMember] public System.DateTime APPROVEDDATE { get; set; }
        public ProductPriceBreakupDetail() { }
        public ProductPriceBreakupDetail(DataRow objectRow)
        {
            if (objectRow["BREAKUPMASTERID"] != DBNull.Value) this.BREAKUPMASTERID = Convert.ToInt32(objectRow["BREAKUPMASTERID"]);
            if (objectRow["PRICEBREAKUPID"] != DBNull.Value) this.PRICEBREAKUPID = Convert.ToInt32(objectRow["PRICEBREAKUPID"]);
            if (objectRow["CHANNELID"] != DBNull.Value) this.CHANNELID = Convert.ToInt32(objectRow["CHANNELID"]);
            
            this.INCLUDEINVOICEYN = objectRow["INCLUDEINVOICEYN"] as System.String;
            this.ACCOUNTNO = objectRow["ACCOUNTNO"] as System.String;
            this.INVOICECAPTION = objectRow["INVOICECAPTION"] as System.String;
            this.PROJCODE = objectRow["PROJCODE"] as System.String;
            this.DRORCR = objectRow["DRORCR"] as System.String;
            this.CHANNELNAME = objectRow["CHANNELNAME"] as System.String;
            this.PRODUCTNAME = objectRow["PRODUCTNAME"] as System.String;
            this.PRICEBREAKUPNAME = objectRow["PRICEBREAKUPNAME"] as System.String;
            this.APPROVEDBY = objectRow["APPROVEDBY"] as System.String;
            if (objectRow["APPROVEDDATE"] != DBNull.Value) this.APPROVEDDATE = Convert.ToDateTime(objectRow["APPROVEDDATE"]);
            this.ENABLEDYN = objectRow["ENABLEDYN"] as System.String;
        }
    }
}