using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class RFMain
    {
        [DataMember] public System.Int32 RFID { get; set; }
        [DataMember] public System.String RFCODE { get; set; }
        [DataMember] public System.DateTime RFDATE { get; set; }
        [DataMember] public System.Int32 RFRAISERID { get; set; }
        [DataMember] public System.Int32 WAREHOUSEID { get; set; }
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.Int32 RFTYPE { get; set; }
        [DataMember] public System.String RFSTATUS { get; set; }
        [DataMember] public System.DateTime DELIVERYDATE { get; set; }
        [DataMember] public System.String DELIVERYADDRESSLINE1 { get; set; }
        [DataMember] public System.String DELIVERYADDRESSLINE2 { get; set; }
        [DataMember] public System.String REMARKS { get; set; }
        [DataMember] public System.String CREATEDBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; } 
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.String RFRAISERCODE { get; set; }
        [DataMember] public System.String RECORDSTATUS { get; set; }
        [DataMember] public System.String COLLECTIONREF { get; set; }
        [DataMember] public System.DateTime STARTRFDATE { get; set; }
        [DataMember] public System.DateTime ENDRFDATE { get; set; }
        [DataMember] public System.String WAREHOUSENAME { get; set; }
        [DataMember] public System.String WAREHOUSECODE { get; set; }
        [DataMember] public System.String CENTERNAME { get; set; }
        [DataMember] public System.String CENTERCODE { get; set; }
        [DataMember] public System.String RAISERNAME { get; set; }
        [DataMember] public System.String INVOICESTATUS { get; set; }
        [DataMember] public System.String VATCHALLANSTATUS { get; set; }
        [DataMember] public System.String DELIVERYSTATUS { get; set; }
        [DataMember] public System.String PRODUCT { get; set; }

        [DataMember] public System.String INVOICEID { get; set; }
        [DataMember] public System.Decimal RFTotal { get; set; }
        [DataMember] public System.Int32 PAYMENTTYPE{ get; set; }
        [DataMember] public System.String EDITABLE { get; set; }
        [DataMember] public System.String COLLECTIONSTATUS { get; set; }
        [DataMember] public System.String ADJUSTMENTSTATUS { get; set; }
        [DataMember] public System.String CREDITSTATUS { get; set; }
        [DataMember] public System.Decimal COLLECTEDAMOUNT { get; set; }
      
        [DataMember] public System.DateTime STARTDVDATE { get; set; }
        [DataMember] public System.DateTime ENDDVDATE { get; set; }
        
         [DataMember] public System.Int32  PRODUCTID       { get; set; }
         [DataMember] public System.Int32  SUBCATEGORYID { get; set; }
         [DataMember] public System.Int32  CATEGORYID   { get; set; }
         [DataMember] public System.Int32 PRODFAMILYID { get; set; }
         [DataMember] public System.String PROMOTION { get; set; }
         [DataMember] public System.String AUTOTRANSACTIONMODE { get; set; }
         [DataMember] public System.String ISALTERNATIVECHANNEL { get; set; }
         [DataMember] public System.Int32 ALTCHANNELID { get; set; }
         [DataMember] public System.String STATUS { get; set; }
         [DataMember] public System.String REVERSESTATUS { get; set; }
         [DataMember]
         public System.String ISCOURIER { get; set; }
        public RFMain() { }
        public RFMain(DataRow objectRow)
        {

            try
            {
                this.PROMOTION = objectRow["PROMOTION"] as System.String;
            }
            catch { this.PROMOTION = ""; }


            try
            {
                this.AUTOTRANSACTIONMODE = objectRow["AUTOTRANSACTIONMODE"] as System.String;
            }
            catch { this.AUTOTRANSACTIONMODE = "Y"; }
            
            if (objectRow["RFID"] != DBNull.Value) this.RFID = Convert.ToInt32(objectRow["RFID"]);
            if (objectRow["RFTYPE"] != DBNull.Value) this.RFTYPE = Convert.ToInt32(objectRow["RFTYPE"]);
            if (objectRow["PAYMENTTYPE"] != DBNull.Value) this.PAYMENTTYPE = Convert.ToInt32(objectRow["PAYMENTTYPE"]);
            this.RFCODE = objectRow["RFCODE"] as System.String;
            if (objectRow["RFDATE"] != DBNull.Value) this.RFDATE = Convert.ToDateTime(objectRow["RFDATE"]);
            if (objectRow["RFRAISERID"] != DBNull.Value) this.RFRAISERID = Convert.ToInt32(objectRow["RFRAISERID"]);
            if (objectRow["WAREHOUSEID"] != DBNull.Value) this.WAREHOUSEID = Convert.ToInt32(objectRow["WAREHOUSEID"]);
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            this.RFSTATUS = objectRow["RFSTATUS"] as System.String;
            if (objectRow["DELIVERYDATE"] != DBNull.Value) this.DELIVERYDATE = Convert.ToDateTime(objectRow["DELIVERYDATE"]);
            this.DELIVERYADDRESSLINE1 = objectRow["DELIVERYADDRESSLINE1"] as System.String;
            this.DELIVERYADDRESSLINE2 = objectRow["DELIVERYADDRESSLINE2"] as System.String;
            this.REMARKS = objectRow["REMARKS"] as System.String;
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            this.CREATEDBYUSER = objectRow["CREATEDBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            if (objectRow["RFTOTAL"] != DBNull.Value) this.RFTotal = Convert.ToDecimal(objectRow["RFTOTAL"]);
            this.RECORDSTATUS = objectRow["RECORDSTATUS"] as System.String;
            try
            {
                this.COLLECTIONREF = objectRow["COLLECTIONREF"] as System.String;
            }
            catch { }
            this.WAREHOUSENAME = objectRow["WAREHOUSENAME"] as System.String;
            this.WAREHOUSECODE = objectRow["WAREHOUSECODE"] as System.String;
            this.CENTERNAME = objectRow["CENTERNAME"] as System.String;

            try
            {
                this.CENTERCODE = objectRow["CENTERCODE"] as System.String;
            }
            catch (Exception ex)
            { 
            
            }

            this.RAISERNAME = objectRow["RAISERNAME"] as System.String;
            this.INVOICESTATUS = objectRow["INVOICESTATUS"] as System.String;
            this.VATCHALLANSTATUS = objectRow["VATCHALLANSTATUS"] as System.String;
            this.DELIVERYSTATUS = objectRow["DELIVERYSTATUS"] as System.String;
        
          
            try { this.ADJUSTMENTSTATUS = objectRow["ADJUSTMENTSTATUS"] as System.String; }
            catch { }
            try { this.CREDITSTATUS = objectRow["CREDITSTATUS"] as System.String; }
            catch { }

            if (this.RFTYPE == 1)
            {
                try
                {
                    this.EDITABLE = int.Parse(this.INVOICESTATUS) > 0 ? "N" : "Y";
                }
                catch { }
            }
            else if (this.RFTYPE == 2)
            {
                this.EDITABLE = string.IsNullOrEmpty(this.VATCHALLANSTATUS) ? "Y" : "N";
            }
            else
            {
                this.EDITABLE = "Y";
            }

            this.RFRAISERCODE = objectRow["RFRAISERCODE"] as System.String;

            if (objectRow["COLLECTEDAMOUNT"] != DBNull.Value) this.COLLECTEDAMOUNT = Convert.ToDecimal(objectRow["COLLECTEDAMOUNT"]);

            try
            {

               

                if (this.RFTotal == COLLECTEDAMOUNT)
                {
                    if (RFTYPE == 1 && COLLECTEDAMOUNT == 0 && string.IsNullOrEmpty(INVOICESTATUS))
                    {
                        this.COLLECTIONSTATUS = "N";
                    }
                    else
                    {
                        this.COLLECTIONSTATUS = "Y";
                    }

                }
                else if (COLLECTEDAMOUNT == 0)
                {
                    this.COLLECTIONSTATUS = "N";
                }
                else
                {
                    this.COLLECTIONSTATUS = "P";
                }



               




            }
            catch { }


            this.INVOICEID = objectRow["INVOICEID"] as System.String;
            try
            {

                this.PRODUCT = objectRow["PRODUCT"] as System.String;
            }
            catch (Exception ex)
            { }


            this.ISALTERNATIVECHANNEL = objectRow["ISALTERNATIVECHANNEL"] as System.String;
            try
            {

                if (objectRow["ALTCHANNELID"] != DBNull.Value) this.ALTCHANNELID = Convert.ToInt32(objectRow["ALTCHANNELID"]);
            }
            catch (Exception ex)
            { }

            try
            {
                if (objectRow["STATUS"] != DBNull.Value) this.STATUS = objectRow["STATUS"].ToString();
            }
            catch (Exception ex)
            { }

            try
            {
                if (objectRow["REVERSESTATUS"] != DBNull.Value) this.REVERSESTATUS = objectRow["REVERSESTATUS"].ToString();
            }
            catch (Exception ex)
            { }
            try
            {
                if (objectRow["ISCOURIER"] != DBNull.Value) this.ISCOURIER = objectRow["ISCOURIER"].ToString();
            }
            catch (Exception ex)
            { }
        }
    }
}