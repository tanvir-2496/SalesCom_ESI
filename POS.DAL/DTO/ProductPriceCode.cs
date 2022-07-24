using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class ProductPriceCode
    {
        [DataMember]
        public int PRODUCTPRICECODEID { get; set; }
        
        [DataMember]
        public string PRODUCTPRICECODE { get; set; }
  
        [DataMember]
        public string DESCRIPTION { get; set; }
  
        [DataMember]
        public string ENABLEDYN{get;set;}
  
        [DataMember]
        public DateTime PRICECODEDATE { get; set; }




        public ProductPriceCode()
        { }

        public ProductPriceCode(DataRow row)
        {
            if (row["PRODUCTPRICECODEID"] != DBNull.Value) PRODUCTPRICECODEID = int.Parse(row["PRODUCTPRICECODEID"].ToString());

            if (row["PRODUCTPRICECODE"] != DBNull.Value) PRODUCTPRICECODE = row["PRODUCTPRICECODE"].ToString();

            if (row["DESCRIPTION"] != DBNull.Value) DESCRIPTION = row["DESCRIPTION"].ToString();

            if (row["ENABLEDYN"] != DBNull.Value) ENABLEDYN = row["ENABLEDYN"].ToString();

            if (row["PRICECODEDATE"] != DBNull.Value) PRICECODEDATE =Convert.ToDateTime(row["PRICECODEDATE"].ToString());

           
        }
    }
}
