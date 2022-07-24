using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ReturnInvoicePriceBreakup
    {
        [DataMember] public System.Int32 RETURNINVOICEDETAILID { get; set; }
        [DataMember] public System.Int32 PRICEBREAKUPID { get; set; }
        [DataMember] public System.Decimal AMOUNT { get; set; }
        [DataMember] public System.String ACCOUNTCODE { get; set; }
        [DataMember] public System.String PROJECTCODE { get; set; }
        [DataMember] public System.String DRCR { get; set; }
        [DataMember] public System.String ACCSTATUS { get; set; }
        [DataMember] public System.Int32 PROMOTIONCYCLEID { get; set; }
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.String DISPLAYNAME { get; set; }
   
        [DataMember] public System.String PRODUCTNAME { get; set; }
        public ReturnInvoicePriceBreakup() { }
        public ReturnInvoicePriceBreakup(DataRow objectRow)
        {
            try
            {
                if (objectRow["RETURNINVOICEDETAILID"] != DBNull.Value) this.RETURNINVOICEDETAILID = Convert.ToInt32(objectRow["RETURNINVOICEDETAILID"]);
            }
            catch { }
            try
            {
                if (objectRow["PRICEBREAKUPID"] != DBNull.Value) this.PRICEBREAKUPID = Convert.ToInt32(objectRow["PRICEBREAKUPID"]);
            }
            catch { }
            try
            {
                if (objectRow["AMOUNT"] != DBNull.Value) this.AMOUNT = Convert.ToDecimal(objectRow["AMOUNT"]);
            }
            catch { }
            try
            {
                this.ACCOUNTCODE = objectRow["ACCOUNTCODE"] as System.String;
            }
            catch { }
            try
            {
                this.PROJECTCODE = objectRow["PROJECTCODE"] as System.String;
            }
            catch { }
            try
            {
                this.DRCR = objectRow["DRCR"] as System.String;
            }
            catch { }
            try
            {
                this.ACCSTATUS = objectRow["ACCSTATUS"] as System.String;
            }
            catch { }
            try
            {
                if (objectRow["PROMOTIONCYCLEID"] != DBNull.Value) this.PROMOTIONCYCLEID = Convert.ToInt32(objectRow["PROMOTIONCYCLEID"]);
            }
            catch { }
            try
            {
                if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            }
            catch { }
            try
            {
                this.DISPLAYNAME = objectRow["DISPLAYNAME"] as String;
            }
            catch { }
            try
            {
                this.PRODUCTNAME = objectRow["PRODUCTNAME"] as String;
            }
            catch { }
        }
    }
}