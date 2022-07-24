using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class ProductPrice
    {
        [DataMember]
        public int PRODUCTPRICEID { get; set; }

     
        [DataMember]
        public int DISTRIBUTORID { get; set; }

        [DataMember]
        public int PRODUCTID { get; set; }


        [DataMember]
        public int PROMOTIONID { get; set; }

        [DataMember]
        public int PROMOTIONCYCLEID { get; set; }


        [DataMember]
        public string RECORDSTATUS { get; set; }

       
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
             public string LASTUPDATEBY { get; set; }
        


        public ProductPrice()
        { }

        public ProductPrice(DataRow row)
        {
            

            if (row["PRICEADJUSTMENTID"] != DBNull.Value) PRODUCTPRICEID = int.Parse(row["PRODUCTPRICEID"].ToString());


            if (row["DISTRIBUTORID"] != DBNull.Value) DISTRIBUTORID = int.Parse(row["DISTRIBUTORID"].ToString());

            if (row["PRODUCTID"] != DBNull.Value) PRODUCTID = int.Parse(row["PRODUCTID"].ToString());
            if (row["PROMOTIONID"] != DBNull.Value) PROMOTIONID = int.Parse(row["PROMOTIONID"].ToString());
            if (row["PROMOTIONCYCLEID"] != DBNull.Value) PROMOTIONCYCLEID = int.Parse(row["PROMOTIONCYCLEID"].ToString());

            if (row["SERIALNO"] != DBNull.Value) SERIALNO = row["SERIALNO"].ToString();
            if (row["PREVIOUSPRICECODE"] != DBNull.Value) PREVIOUSPRICECODE = row["PREVIOUSPRICECODE"].ToString();

            if (row["PREVIOUSPRICE"] != DBNull.Value) PREVIOUSPRICE = Convert.ToDecimal(row["PREVIOUSPRICE"].ToString());


            if (row["CURRENTPRICECODE"] != DBNull.Value) CURRENTPRICECODE = row["CURRENTPRICECODE"].ToString();
            if (row["CURRENTPRICE"] != DBNull.Value) CURRENTPRICE = Convert.ToDecimal(row["CURRENTPRICE"].ToString());


            this.RECORDSTATUS = row["RECORDSTATUS"] as string;
            this.LASTUPDATEBY = row["LASTUPDATEBY"] as string;


        }
    }
}
