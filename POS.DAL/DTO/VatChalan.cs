using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class VatChalanValues
    {
        [DataMember] public System.Int32 CHALLANVALUEID { get; set; }
        [DataMember] public System.Int32 PROMOTIONCYCLEID { get; set; }
        [DataMember] public System.Int32 PROMOTIONID { get; set; }
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.String APPROVEDBY { get; set; }
        [DataMember] public System.DateTime APPROVEDDATE { get; set; }
        [DataMember] public System.String APPROVEDYN { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.Decimal FACEVALUE { get; set; }
        [DataMember] public System.Decimal SDRATE { get; set; }
        [DataMember] public System.Decimal VATRATE { get; set; }
        [DataMember] public System.Int32 VATPOLICYID { get; set; }
        [DataMember] public System.Decimal ASSVALUE { get; set; }
        [DataMember] public System.String PROMOTIONCYCLENAME { get; set; }
        [DataMember] public System.String PRODUCTNAME { get; set; }
        [DataMember] public System.String PROMOTIONNAME { get; set; }
        [DataMember] public System.String ISINCUSIVE { get; set; }
        
      
        public VatChalanValues() { }
        public VatChalanValues(DataRow objectRow)
        {
            if (objectRow["CHALLANVALUEID"] != DBNull.Value) this.CHALLANVALUEID = Convert.ToInt32(objectRow["CHALLANVALUEID"]);
            if (objectRow["PROMOTIONCYCLEID"] != DBNull.Value) this.PROMOTIONCYCLEID = Convert.ToInt32(objectRow["PROMOTIONCYCLEID"]);
            this.PROMOTIONCYCLENAME = objectRow["PROMOTIONCYCLENAME"] as System.String;
            this.PRODUCTNAME = objectRow["PRODUCTNAME"] as System.String;
            this.PROMOTIONNAME = objectRow["PROMOTIONNAME"] as System.String;
            if (objectRow["PROMOTIONID"] != DBNull.Value) this.PROMOTIONID = Convert.ToInt32(objectRow["PROMOTIONID"]);
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            this.APPROVEDBY = objectRow["APPROVEDBY"] as System.String;
            if (objectRow["APPROVEDDATE"] != DBNull.Value) this.APPROVEDDATE = Convert.ToDateTime(objectRow["APPROVEDDATE"]);
            this.APPROVEDYN = objectRow["APPROVEDYN"] as System.String;
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["FACEVALUE"] != DBNull.Value) this.FACEVALUE = Convert.ToDecimal(objectRow["FACEVALUE"]);
            if (objectRow["SDRATE"] != DBNull.Value) this.SDRATE = Convert.ToDecimal(objectRow["SDRATE"]);
            if (objectRow["VATRATE"] != DBNull.Value) this.VATRATE = Convert.ToDecimal(objectRow["VATRATE"]);
            if (objectRow["VATPOLICYID"] != DBNull.Value) this.VATPOLICYID = Convert.ToInt32(objectRow["VATPOLICYID"]);
            if (objectRow["ASSVALUE"] != DBNull.Value) this.ASSVALUE = Convert.ToDecimal(objectRow["ASSVALUE"]);
            this.ISINCUSIVE = objectRow["ISINCUSIVE"] as System.String;
           
        }
    }



    [DataContract] public class VatChallan
    {
        [DataMember] public System.Int32 VATCHALLANID { get; set; }
        [DataMember] public System.String CHALLANNO { get; set; }
        [DataMember] public System.String REFNO { get; set; }
        [DataMember] public System.String REFTYPE { get; set; }
        [DataMember] public System.DateTime CHALLANISSUEDATE { get; set; }
        [DataMember] public System.DateTime SEARCHSTARTDATE { get; set; }
        [DataMember] public System.DateTime SEARCHENDDATE { get; set; }
        [DataMember] public System.String NAMEOFBUYER { get; set; }
        [DataMember] public System.String DELIVERADDRESSLINE1 { get; set; }
        [DataMember] public System.String DELIVERYADDRESSLINE2 { get; set; }
        [DataMember] public System.String BUYERADDRESSLINE1 { get; set; }
        [DataMember] public System.String BUYERADDRESSLINE2 { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.String RECORDSTATUS { get; set; }
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.Int32 WAREHOUSEID { get; set; }
        [DataMember] public System.Int32 RFRAISERID { get; set; }    



        public VatChallan() { }
        public VatChallan(DataRow objectRow)
        {
            if (objectRow["VATCHALLANID"] != DBNull.Value) this.VATCHALLANID = Convert.ToInt32(objectRow["VATCHALLANID"]);
            this.CHALLANNO = objectRow["CHALLANNO"] as System.String;
            this.REFNO = objectRow["REFNO"] as System.String;
            this.REFTYPE = objectRow["REFTYPE"] as System.String;
            if (objectRow["CHALLANISSUEDATE"] != DBNull.Value) this.CHALLANISSUEDATE = Convert.ToDateTime(objectRow["CHALLANISSUEDATE"]);
            this.NAMEOFBUYER = objectRow["NAMEOFBUYER"] as System.String;
            this.DELIVERADDRESSLINE1 = objectRow["DELIVERADDRESSLINE1"] as System.String;
            this.DELIVERYADDRESSLINE2 = objectRow["DELIVERYADDRESSLINE2"] as System.String;
            this.BUYERADDRESSLINE1 = objectRow["BUYERADDRESSLINE1"] as System.String;
            this.BUYERADDRESSLINE2 = objectRow["BUYERADDRESSLINE2"] as System.String;
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            this.RECORDSTATUS = objectRow["RECORDSTATUS"] as System.String;
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            if (objectRow["RFRAISERID"] != DBNull.Value) this.RFRAISERID = Convert.ToInt32(objectRow["RFRAISERID"]);
            
            this.WAREHOUSEID = 0;
        }
    }




    [DataContract] public class VatChallanDetail
    {
        [DataMember] public System.Int32 VATCHALLANID { get; set; }
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.String PRODUCTNAME { get; set; }
        [DataMember] public System.Decimal FACEVALUE { get; set; }
        [DataMember] public System.Decimal SD { get; set; }
        [DataMember] public System.Int32 DELIVERYQTY { get; set; }
        [DataMember] public System.Decimal VAT { get; set; }
        [DataMember] public System.Decimal ASSVALUE { get; set; }

        public VatChallanDetail() { }
        public VatChallanDetail(DataRow objectRow)
        {
            if (objectRow["VATCHALLANID"] != DBNull.Value) this.VATCHALLANID = Convert.ToInt32(objectRow["VATCHALLANID"]);
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            if (objectRow["FACEVALUE"] != DBNull.Value) this.FACEVALUE = Convert.ToDecimal(objectRow["FACEVALUE"]);
            if (objectRow["SD"] != DBNull.Value) this.SD = Convert.ToDecimal(objectRow["SD"]);
            if (objectRow["DELIVERYQTY"] != DBNull.Value) this.DELIVERYQTY = Convert.ToInt32(objectRow["DELIVERYQTY"]);
            if (objectRow["VAT"] != DBNull.Value) this.VAT = Convert.ToDecimal(objectRow["VAT"]);
            if (objectRow["ASSVALUE"] != DBNull.Value) this.ASSVALUE = Convert.ToDecimal(objectRow["ASSVALUE"]);
            this.PRODUCTNAME = objectRow["PRODUCTNAME"] as System.String;
        }

    }
}

