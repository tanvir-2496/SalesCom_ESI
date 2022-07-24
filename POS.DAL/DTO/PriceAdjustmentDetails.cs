using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class PriceAdjustmentDetails
    {
        [DataMember]
        public int PRICEADJUSTMENTDETAILSID { get; set; }

        [DataMember]
        public int PRICEADJUSTMENTID { get; set; }

        [DataMember]
        public int DISTRIBUTORID { get; set; }

        [DataMember]
        public int PRODUCTID { get; set; }


        [DataMember]
        public int PROMOTIONID { get; set; }

        [DataMember]
        public int PROMOTIONCYCLEID { get; set; }


        [DataMember]
        public int CURRPROMOTIONCYCLEID { get; set; }


        [DataMember]
        public int PREVPROMOTIONCYCLEID { get; set; }

        [DataMember]
        public string SERIALNO { get; set; }

        [DataMember]
        public string PREVIOUSPRICECODE { get; set; }

        [DataMember]
        public decimal PREVIOUSPRICE { get; set; }

        [DataMember]
        public string CURRENTPRICECODE { get; set; }

        [DataMember]
        public decimal CURRENTPRICE { get; set; }

         [DataMember]
         public string PRODUCTCODE { get; set; }

          [DataMember]
         public string DISTRIBUTORCODE { get; set; }

            [DataMember]
          public string DISTRIBUTORNAME { get; set; }

             [DataMember]
            public decimal PRICEDIFF { get; set; }
        
        


        


        public PriceAdjustmentDetails()
        { }
        public PriceAdjustmentDetails(DataRow row, bool LoadExcel)
        {
            if (LoadExcel)
            {
                if (row["Distributor Code"] != DBNull.Value)
                    DISTRIBUTORCODE = row["Distributor Code"].ToString();


                if (row["Serial No"] != DBNull.Value)
                    SERIALNO = row["Serial No"].ToString();


                try
                {
                    if (row["Distributor Name"] != DBNull.Value)
                        DISTRIBUTORNAME = row["Distributor Name"].ToString();
                }
                catch { }

                if (row["PRODUCT CODE"] != DBNull.Value)
                    PRODUCTCODE = row["PRODUCT CODE"].ToString();

                if (row["DISTRIBUTOR CODE"] != DBNull.Value)
                    DISTRIBUTORCODE = row["DISTRIBUTOR CODE"].ToString();

                if (row["PREVIOUSPRICE CODE"] != DBNull.Value)
                    PREVIOUSPRICECODE = row["PREVIOUSPRICE CODE"].ToString();

                if (row["CURRENTPRICE CODE"] != DBNull.Value)
                    CURRENTPRICECODE = row["CURRENTPRICE CODE"].ToString();
              
              



            }
        }
        public PriceAdjustmentDetails(DataRow row)
        {
            if (row["PRICEADJUSTMENTDETAILSID"] != DBNull.Value) PRICEADJUSTMENTDETAILSID = int.Parse(row["PRICEADJUSTMENTDETAILSID"].ToString());

            if (row["PRICEADJUSTMENTID"] != DBNull.Value) PRICEADJUSTMENTID = int.Parse(row["PRICEADJUSTMENTID"].ToString());


            if (row["DISTRIBUTORID"] != DBNull.Value) DISTRIBUTORID = int.Parse(row["DISTRIBUTORID"].ToString());

            if (row["PRODUCTID"] != DBNull.Value) PRODUCTID = int.Parse(row["PRODUCTID"].ToString());
            if (row["PROMOTIONID"] != DBNull.Value) PROMOTIONID = int.Parse(row["PROMOTIONID"].ToString());
            if (row["PROMOTIONCYCLEID"] != DBNull.Value) PROMOTIONCYCLEID = int.Parse(row["PROMOTIONCYCLEID"].ToString());

            if (row["SERIALNO"] != DBNull.Value) SERIALNO = row["SERIALNO"].ToString();
            if (row["PREVIOUSPRICECODE"] != DBNull.Value) PREVIOUSPRICECODE = row["PREVIOUSPRICECODE"].ToString();

            if (row["PREVIOUSPRICE"] != DBNull.Value) PREVIOUSPRICE = Convert.ToDecimal(row["PREVIOUSPRICE"].ToString());

            if (row["CURRENTPRICECODE"] != DBNull.Value) CURRENTPRICECODE = row["CURRENTPRICECODE"].ToString();
            if (row["CURRENTPRICE"] != DBNull.Value) CURRENTPRICE = Convert.ToDecimal(row["CURRENTPRICE"].ToString());

            try
            {
                if (row["PRICEDIFF"] != DBNull.Value) PRICEDIFF = Convert.ToDecimal(row["PRICEDIFF"].ToString());
            }
            catch
            { }


        }
    }
}
