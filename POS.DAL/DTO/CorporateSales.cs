using System; 
using System.Data;

using System.Runtime.Serialization;
namespace POS.DAL
{

    [DataContract]
    public class CorporateSales
    {
        [DataMember]
        public System.Int32 CORPORATESALESID { get; set; }
        [DataMember]
        public System.DateTime CORPORATESALESDATE { get; set; }
        [DataMember]
        public System.Decimal VIRTUALAMOUNT { get; set; }
        [DataMember]
        public System.String COMPANYNAME { get; set; }
        [DataMember]
        public System.String CONTACTPERSON { get; set; }
        [DataMember]
        public System.String BILLCYCLE { get; set; }
        [DataMember]
        public System.String ALTERNATECONTACTNO { get; set; }
        [DataMember]
        public System.String CUSTOMERCATEGORY { get; set; }
        [DataMember]
        public System.Int32 SALESPERSONID { get; set; }
        [DataMember]
        public System.String BDOCODE { get; set; }
        [DataMember]
        public System.String EXECUTIVECODE { get; set; }
        [DataMember]
        public System.String PACKAGECODE { get; set; }
        [DataMember]
        public System.String MOBILENO { get; set; }
        [DataMember]
        public System.Decimal SIMNO { get; set; }
        [DataMember]
        public System.Decimal CREDITLIMIT { get; set; }
        [DataMember]
        public System.Decimal SECURITYDEPOSIT { get; set; }
        [DataMember]
        public System.String CUGAPPLIED { get; set; }
        [DataMember]
        public System.Decimal CONNECTIONPRICE { get; set; }
        [DataMember]
        public System.Decimal SIMTAX { get; set; }
        [DataMember]
        public System.Decimal DISCOUNT { get; set; }
        [DataMember]
        public System.Decimal DISCOUNAMOUNTONCONNPRICE { get; set; }
        [DataMember]
        public System.Decimal CONNECTIONPRICERECEIVED { get; set; }
        [DataMember]
        public System.Decimal AMOUNTRECEIVEDWITHSIM { get; set; }
        [DataMember]
        public System.Decimal MONEYRECEIPT { get; set; }
        [DataMember]
        public System.String REMARKS { get; set; }
        [DataMember]
        public System.Int32 INVOICEID { get; set; }
        [DataMember]
        public System.Int32 CENTERID { get; set; }
        [DataMember]
        public System.String CREATEBYUSER { get; set; }
        [DataMember]
        public System.DateTime CREATEDATE { get; set; }
        [DataMember]
        public System.String LASTUPDATEBY { get; set; }
        [DataMember]
        public System.DateTime LASTUPDATEDDATE { get; set; }
        [DataMember]
        public System.Int32 PRODUCTID { get; set; }

        public CorporateSales() { }
        public CorporateSales(DataRow objectRow)
        {
            if (objectRow["CORPORATESALESID"] != DBNull.Value) this.CORPORATESALESID = Convert.ToInt32(objectRow["CORPORATESALESID"]);
            if (objectRow["CORPORATESALESDATE"] != DBNull.Value) this.CORPORATESALESDATE = Convert.ToDateTime(objectRow["CORPORATESALESDATE"]);
            if (objectRow["VIRTUALAMOUNT"] != DBNull.Value) this.VIRTUALAMOUNT = Convert.ToDecimal(objectRow["VIRTUALAMOUNT"]);
            this.COMPANYNAME = objectRow["COMPANYNAME"] as System.String;
            this.CONTACTPERSON = objectRow["CONTACTPERSON"] as System.String;
            this.BILLCYCLE = objectRow["BILLCYCLE"] as System.String;
            this.ALTERNATECONTACTNO = objectRow["ALTERNATECONTACTNO"] as System.String;
            this.CUSTOMERCATEGORY = objectRow["CUSTOMERCATEGORY"] as System.String;
            if (objectRow["SALESPERSONID"] != DBNull.Value) this.SALESPERSONID = Convert.ToInt32(objectRow["SALESPERSONID"]);
            this.BDOCODE = objectRow["BDOCODE"] as System.String;
            this.EXECUTIVECODE = objectRow["EXECUTIVECODE"] as System.String;
            this.PACKAGECODE = objectRow["PACKAGECODE"] as System.String;
            this.MOBILENO = objectRow["MOBILENO"] as System.String;
            if (objectRow["SIMNO"] != DBNull.Value) this.SIMNO = Convert.ToDecimal(objectRow["SIMNO"]);
            if (objectRow["CREDITLIMIT"] != DBNull.Value) this.CREDITLIMIT = Convert.ToDecimal(objectRow["CREDITLIMIT"]);
            if (objectRow["SECURITYDEPOSIT"] != DBNull.Value) this.SECURITYDEPOSIT = Convert.ToDecimal(objectRow["SECURITYDEPOSIT"]);
            this.CUGAPPLIED = objectRow["CUGAPPLIED"] as System.String;
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            
        }
    }
}