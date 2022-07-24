using System;
using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract]
    public class Collection
    {
        [DataMember]
        public System.Int32 COLLECTIONID { get; set; }
        [DataMember]
        public System.Int32 COLLECTIONTYPEID { get; set; }
        [DataMember]
        public System.Int32 COLLECTIONMODEID { get; set; }
        [DataMember]
        public System.String COLLECTIONREF { get; set; }
        [DataMember]
        public System.DateTime COLLECTIONDATE { get; set; }
        [DataMember]
        public System.Int32 CENTERID { get; set; }
        [DataMember]
        public System.Int32 TELLERID { get; set; }
        [DataMember]
        public System.Int32 OWNERID { get; set; }
        [DataMember]
        public System.String OWNERNAME { get; set; }
        [DataMember]
        public System.Decimal COLLECTIONAMOUNT { get; set; }
        [DataMember]
        public System.String PODDNO { get; set; }
        [DataMember]
        public System.Int32 BANKID { get; set; }
        [DataMember]
        public System.Int32 RFID { get; set; }
        [DataMember]
        public System.String BANKNAME { get; set; }
        [DataMember]
        public System.String BRANCHNAME { get; set; }
        [DataMember]
        public System.String CHQNO { get; set; }
        [DataMember]
        public System.DateTime CHQDATE { get; set; }
        [DataMember]
        public System.String CARDNO { get; set; }
        [DataMember]
        public System.DateTime EXPIRYDATE { get; set; }
        [DataMember]
        public System.String CONTRNO { get; set; }
        [DataMember]
        public System.String INVOICENO { get; set; }
        [DataMember]
        public System.Int32 CUSTOMERID { get; set; }
        [DataMember]
        public System.String COLLECTIONTYPE { get; set; }
        [DataMember]
        public System.String COLLECTIONMODE { get; set; }
        [DataMember]
        public System.String CUSTOMER { get; set; }
        [DataMember]
        public System.String CENTER { get; set; }
        [DataMember]
        public System.String TELLER { get; set; }
        [DataMember]
        public System.String CREATEBYUSER { get; set; }
        [DataMember]
        public System.DateTime CREATEDATE { get; set; }
        [DataMember]
        public System.String LASTUPDATEBY { get; set; }
        [DataMember]
        public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember]
        public System.String CUSTOMERNAME { get; set; }
        [DataMember]
        public System.String ISCOLLECTIONACTIVEYN { get; set; }
        [DataMember]
        public System.DateTime FROMDATE { get; set; }
        [DataMember]
        public System.DateTime TODATE { get; set; }
        [DataMember]
        public System.Int32 DISBURSEACCOUNTID { get; set; }
        [DataMember]
        public System.String CENTERCODE { get; set; }
        [DataMember]
        public System.String REMARKS { get; set; }
        [DataMember]
        public System.String DDNO { get; set; }
        [DataMember]
        public System.String TRANSFERNO { get; set; }
        [DataMember]
        public System.String BLBANKACCOUNT { get; set; }
        [DataMember]
        public System.String FIELD1 { get; set; }
        [DataMember]
        public System.String FIELD2 { get; set; }
        [DataMember]
        public System.String FIELD3 { get; set; }
        [DataMember]
        public System.String FIELD4 { get; set; }
        [DataMember]
        public System.String FIELD5 { get; set; }
        [DataMember]
        public System.String BANKACCOUNTNO { get; set; }
        [DataMember]
        public System.Int32 RFRAISERID { get; set; }

        [DataMember]
        public System.Int32 PAYMODE { get; set; }
        [DataMember]
        public System.Int32 STATUS { get; set; }
        [DataMember]
        public System.String MSISDN { get; set; }
        [DataMember]
        public System.String PACKAGE { get; set; }
        [DataMember]
        public System.String CURRENCY { get; set; }
        [DataMember]
        public System.String PAYLEVEL { get; set; }
        [DataMember]
        public System.String SAFNO { get; set; }
        [DataMember]
        public System.Int32 QTY { get; set; }
        [DataMember]
        public System.Int32 PAYHEAD { get; set; }
        [DataMember]
        public System.Int32 COMMISSIONED { get; set; }
        [DataMember]
        public System.String REQUESTEDBY { get; set; }
        [DataMember]
        public System.String TABSBANKCODE { get; set; }
        [DataMember]
        public System.String PRODUCTSNAME { get; set; }
        [DataMember]
        public System.String PROMOTIONNAME { get; set; }
        [DataMember]
        public System.Int32 APISTATUS { get; set; }
        [DataMember]
        public System.Int32 ASSIGNEDTO { get; set; }
        [DataMember]
        public System.String ASSIGNEDTONAME { get; set; }
        [DataMember]
        public System.DateTime ASSIGNEDDATE { get; set; }
        [DataMember]
        public System.String ASSIGNEDREMARKS { get; set; }
        [DataMember]
        public System.String BILLINGSTATUS { get; set; }
        [DataMember]
        public System.Int32 ASSIGNEDBY { get; set; }
        [DataMember]
        public System.String ASSIGNEDBYNAME { get; set; }

        [DataMember]
        public System.String GLCODE { get; set; }
        [DataMember]
        public System.String CARDBANKNAME { get; set; }
        [DataMember]
        public System.String SERIALNO { get; set; }

        public Collection() { }
        public Collection(DataRow objectRow)
        {
            if (objectRow["COLLECTIONID"] != DBNull.Value) this.COLLECTIONID = Convert.ToInt32(objectRow["COLLECTIONID"]);
            if (objectRow["COLLECTIONTYPEID"] != DBNull.Value) this.COLLECTIONTYPEID = Convert.ToInt32(objectRow["COLLECTIONTYPEID"]);
            if (objectRow["COLLECTIONMODEID"] != DBNull.Value) this.COLLECTIONMODEID = Convert.ToInt32(objectRow["COLLECTIONMODEID"]);
            this.COLLECTIONREF = objectRow["COLLECTIONREF"] as System.String;
            if (objectRow["COLLECTIONDATE"] != DBNull.Value) this.COLLECTIONDATE = Convert.ToDateTime(objectRow["COLLECTIONDATE"]);
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            if (objectRow["TELLERID"] != DBNull.Value) this.TELLERID = Convert.ToInt32(objectRow["TELLERID"]);
            if (objectRow["COLLECTIONAMOUNT"] != DBNull.Value) this.COLLECTIONAMOUNT = Convert.ToDecimal(objectRow["COLLECTIONAMOUNT"]);
            this.PODDNO = objectRow["PODDNO"] as System.String;
            if (objectRow["BANKID"] != DBNull.Value) this.BANKID = Convert.ToInt32(objectRow["BANKID"]);

            this.BANKNAME = objectRow["BANKNAME"] as System.String;

            this.BRANCHNAME = objectRow["BRANCHNAME"] as System.String;
            this.CHQNO = objectRow["CHQNO"] as System.String;
            if (objectRow["CHQDATE"] != DBNull.Value) this.CHQDATE = Convert.ToDateTime(objectRow["CHQDATE"]);
            this.CARDNO = objectRow["CARDNO"] as System.String;
            if (objectRow["EXPIRYDATE"] != DBNull.Value) this.EXPIRYDATE = Convert.ToDateTime(objectRow["EXPIRYDATE"]);
            this.CONTRNO = objectRow["CONTRNO"] as System.String;
            this.INVOICENO = objectRow["INVOICENO"] as System.String;
            if (objectRow["CUSTOMERID"] != DBNull.Value) this.CUSTOMERID = Convert.ToInt32(objectRow["CUSTOMERID"]);
            if (objectRow["OWNERID"] != DBNull.Value) this.OWNERID = Convert.ToInt32(objectRow["OWNERID"]);
            this.COLLECTIONTYPE = objectRow["COLLECTIONTYPENAME"] as System.String;
            this.COLLECTIONMODE = objectRow["COLLECTIONMODENAME"] as System.String;
            this.CENTER = objectRow["CENTERNAME"] as System.String;
            //this.OWNERNAME = objectRow["OWNERNAME"] as System.String;
            this.REMARKS = objectRow["REMARKS"] as System.String;
            this.BANKACCOUNTNO = objectRow["BANKACCOUNTNO"] as System.String;
            this.TELLER = objectRow["TELLERNAME"] as System.String;
            try
            {
                this.CUSTOMER = objectRow["CUSTOMER"] as System.String;
            }
            catch (Exception ex)
            { }

            //this.CUSTOMER = objectRow["CUSTOMER"] as System.String;
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (this.CUSTOMERID > 0)
                this.CUSTOMERNAME = objectRow["CUSTOMERNAME"] as System.String;
            else
                this.CUSTOMERNAME = objectRow["CUSTOMERCARECUSTOMER"] as System.String;
            this.ISCOLLECTIONACTIVEYN = objectRow["ISCOLLECTIONACTIVEYN"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            try
            {
                if (objectRow["DISBURSEACCOUNTID"] != DBNull.Value) this.DISBURSEACCOUNTID = Convert.ToInt32(objectRow["DISBURSEACCOUNTID"]);
            }
            catch { }

            this.DDNO = objectRow["DDNO"] as System.String;
            this.TRANSFERNO = objectRow["TRANSFERNO"] as System.String;
            this.BLBANKACCOUNT = objectRow["BLBANKACCOUNT"] as System.String;
            this.FIELD1 = objectRow["FIELD1"] as System.String;
            this.FIELD2 = objectRow["FIELD2"] as System.String;
            this.FIELD3 = objectRow["FIELD3"] as System.String;
            this.FIELD4 = objectRow["FIELD4"] as System.String;
            this.FIELD5 = objectRow["FIELD5"] as System.String;
            this.TABSBANKCODE = objectRow["TABSBANKCODE"] as System.String;


            try
            {
                this.MSISDN = objectRow["MSISDN"] as System.String;
                this.PACKAGE = objectRow["PACKAGE"] as System.String;
                this.CURRENCY = objectRow["CURRENCY"] as System.String;
                this.SAFNO = objectRow["SAFNO"] as System.String;
                this.REQUESTEDBY = objectRow["REQUESTEDBY"] as System.String;


                if (objectRow["PAYMODE"] != DBNull.Value) this.PAYMODE = Convert.ToInt32(objectRow["PAYMODE"]);
                if (objectRow["STATUS"] != DBNull.Value) this.STATUS = Convert.ToInt32(objectRow["STATUS"]);
                if (objectRow["QTY"] != DBNull.Value) this.QTY = Convert.ToInt32(objectRow["QTY"]);
                if (objectRow["PAYHEAD"] != DBNull.Value) this.PAYHEAD = Convert.ToInt32(objectRow["PAYHEAD"]);
                if (objectRow["COMMISSIONED"] != DBNull.Value) this.COMMISSIONED = Convert.ToInt32(objectRow["COMMISSIONED"]);

            }
            catch { }
            try
            {
                this.PRODUCTSNAME = objectRow["PRODUCTSNAME"] as System.String;
                this.PROMOTIONNAME = objectRow["PROMOTIONNAME"] as System.String;
            }
            catch { }

            try
            {
                this.PAYLEVEL = objectRow["PAYLEVEL"] as System.String;
            }
            catch { }

            try
            {
                this.APISTATUS = objectRow["APISTATUS"] == DBNull.Value ? 0 : Convert.ToInt32(objectRow["APISTATUS"]);
            }
            catch { }

            try
            {
                this.ASSIGNEDTO = objectRow["ASSIGNEDTO"] != DBNull.Value ? Convert.ToInt32(objectRow["ASSIGNEDTO"]) : 0;
                this.ASSIGNEDDATE = objectRow["ASSIGNEDDATE"] != DBNull.Value ? Convert.ToDateTime(objectRow["ASSIGNEDDATE"]) : DateTime.MinValue;
                this.ASSIGNEDREMARKS = objectRow["ASSIGNEDREMARKS"] as System.String;
                this.BILLINGSTATUS = objectRow["BILLINGSTATUS"] as System.String;
                this.ASSIGNEDBY = objectRow["ASSIGNEDBY"] != DBNull.Value ? Convert.ToInt32(objectRow["ASSIGNEDBY"]) : 0;
                this.ASSIGNEDTONAME = objectRow["ASSIGNEDTONAME"] as System.String;
                this.ASSIGNEDBYNAME = objectRow["ASSIGNEDBYNAME"] as System.String;


            }
            catch { }

            try
            {
                this.GLCODE = objectRow["GLCODE"] as System.String;
                this.CARDBANKNAME = objectRow["CARDBANKNAME"] as System.String;
                this.SERIALNO = objectRow["SERIALNO"] as System.String;
            }
            catch { }
        }
    }
}