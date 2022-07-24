using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class ReturnProductDetails
    {
        [DataMember]
        public int RETURNPRODUCTDETAILSID { get; set; }

        [DataMember]
        public int RETURNPRODUCTID { get; set; }

        [DataMember]
        public int VALIDATIONID { get; set; }

        [DataMember]
        public int DISTRIBUTORID { get; set; }

        [DataMember]
        public int PRODUCTID { get; set; }
        [DataMember]
        public int PRODUCTPRICECODEID { get; set; }

        [DataMember]
        public string REMARKS { get; set; }

        
        [DataMember]
        public int PROMOTIONID { get; set; }
               [DataMember]
        public int RFRAISERID { get; set; }

        [DataMember]
        public int PROMOTIONCYCLEID { get; set; }

                [DataMember]
        public int PRODFAMILYID { get; set; }
        

        [DataMember]
        public string PRODUCTNAME { get; set; }

        [DataMember]
        public string TRANSACTIONREFNO { get; set; }
        


        [DataMember]
        public string SERIALNO { get; set; }

        [DataMember]
        public string PRODUCTPRICECODE { get; set; }

          [DataMember]
        public string SERIALIZEDYN { get; set; }

  
        
  
        [DataMember]
        public decimal CURRENTPRICE { get; set; }

         [DataMember]
         public string PRODUCTCODE { get; set; }

          [DataMember]
         public string DISTRIBUTORCODE { get; set; }

            [DataMember]
          public string DISTRIBUTORNAME { get; set; }

            
        
            [DataMember]
            public string RECORDSTATUS { get; set; }



            [DataMember]
            public System.String CREATEBYUSER { get; set; }
            [DataMember]
            public System.DateTime CREATEDATE { get; set; }
            [DataMember]
            public System.String LASTUPDATEBY { get; set; }
            [DataMember]
            public System.DateTime LASTUPDATEDATE { get; set; }
        

        


        public ReturnProductDetails()
        { }
        public ReturnProductDetails(DataRow row, bool LoadExcel)
        {
            if (LoadExcel)
            {

                if (row["DISTRIBUTOR CODE"] != DBNull.Value)
                    DISTRIBUTORCODE = row["DISTRIBUTOR CODE"].ToString();


                if (row["PRODUCT CODE"] != DBNull.Value)
                    PRODUCTCODE = row["PRODUCT CODE"].ToString();


                if (row["SERIAL NO"] != DBNull.Value)
                    SERIALNO = row["SERIAL NO"].ToString();

                
              



            }
        }
        public ReturnProductDetails(DataRow row)
        {
            if (row["RETURNPRODUCTDETAILSID"] != DBNull.Value) RETURNPRODUCTDETAILSID = int.Parse(row["RETURNPRODUCTDETAILSID"].ToString());

            if (row["RETURNPRODUCTID"] != DBNull.Value) RETURNPRODUCTID = int.Parse(row["RETURNPRODUCTID"].ToString());


            if (row["DISTRIBUTORID"] != DBNull.Value) DISTRIBUTORID = int.Parse(row["DISTRIBUTORID"].ToString());

            if (row["PRODUCTID"] != DBNull.Value) PRODUCTID = int.Parse(row["PRODUCTID"].ToString());
            try
            {
                if (row["PROMOTIONID"] != DBNull.Value) PROMOTIONID = int.Parse(row["PROMOTIONID"].ToString());
            }
            catch { }

            try
            {
                if (row["PROMOTIONCYCLEID"] != DBNull.Value) PROMOTIONCYCLEID = int.Parse(row["PROMOTIONCYCLEID"].ToString());
            }
            catch { }
              try
            {
                if (row["RFRAISERID"] != DBNull.Value) RFRAISERID = int.Parse(row["RFRAISERID"].ToString());
            }
            catch { }

            

            if (row["SERIALNO"] != DBNull.Value) SERIALNO = row["SERIALNO"].ToString();
            if (row["TRANSACTIONREFNO"] != DBNull.Value) TRANSACTIONREFNO = row["TRANSACTIONREFNO"].ToString();
            
            try
            {
                if (row["PRODUCTPRICECODE"] != DBNull.Value) PRODUCTPRICECODE = row["PRODUCTPRICECODE"].ToString();
            }
            catch { }

            try
            {
                if (row["PRODUCTPRICECODEID"] != DBNull.Value) PRODUCTPRICECODEID = int.Parse(row["PRODUCTPRICECODEID"].ToString());
            }
            catch { }


            try
            {
                if (row["CURRENTPRICE"] != DBNull.Value) CURRENTPRICE = Convert.ToDecimal(row["CURRENTPRICE"].ToString());
            }
            catch { }
            this.SERIALIZEDYN = row["SERIALIZEDYN"] as string;

            this.RECORDSTATUS = row["RECORDSTATUS"] as string ;
            this.REMARKS = row["REMARKS"] as string;


            if (row["CREATEDATE"] != DBNull.Value) CREATEDATE = Convert.ToDateTime(row["CREATEDATE"].ToString());
            this.CREATEBYUSER = row["CREATEBYUSER"] as System.String;
            this.LASTUPDATEBY = row["LASTUPDATEBY"] as System.String;

            if (row["LASTUPDATEDATE"] != DBNull.Value) LASTUPDATEDATE = Convert.ToDateTime(row["LASTUPDATEDATE"].ToString());


            this.DISTRIBUTORCODE = row["DISTRIBUTORCODE"] as System.String;

            this.DISTRIBUTORNAME = row["DISTRIBUTORNAME"] as System.String;

            this.PRODUCTCODE = row["PRODUCTCODE"] as System.String;
            this.PRODUCTNAME = row["PRODUCTNAME"] as System.String;


            try
            {
                if (row["PRODFAMILYID"] != DBNull.Value) PRODFAMILYID = int.Parse(row["PRODFAMILYID"].ToString());
            }
            catch { }

        }
    }
}
