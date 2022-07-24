using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class AdjustPrice
    {
        [DataMember]
        public int DISTRIBUTORID{get;set;}

        [DataMember]
        public int PRODUCTID{get;set;}

        [DataMember]
        public Int32 QTY{get;set;}

        [DataMember]
        public decimal AMOUNT{get;set;}
        
        [DataMember]
        public string TRANSACTIONREFNO{get;set;}
  
      
        [DataMember]
        public Int32 ADJUSTPRICEID{get;set;}
  
        [DataMember]
        public Int32 PRICEADJUSTMENTID{get;set;}


        [DataMember]
        public string PRODUCTCODE { get; set; }

        [DataMember]
        public string DISTRIBUTORCODE { get; set; }

        [DataMember]
        public string PRODUCTNAME { get; set; }

        [DataMember]
        public string DISTRIBUTORNAME { get; set; }


    
       
        public AdjustPrice()
        { }


        public AdjustPrice(DataRow row)
        {
            if (row["DISTRIBUTORID"] != DBNull.Value) DISTRIBUTORID = int.Parse(row["DISTRIBUTORID"].ToString());
            if (row["ADJUSTPRICEID"] != DBNull.Value) ADJUSTPRICEID = int.Parse(row["ADJUSTPRICEID"].ToString());
            if (row["PRICEADJUSTMENTID"] != DBNull.Value) PRICEADJUSTMENTID = int.Parse(row["PRICEADJUSTMENTID"].ToString());

            if (row["TRANSACTIONREFNO"] != DBNull.Value) TRANSACTIONREFNO = row["TRANSACTIONREFNO"].ToString();


            if (row["PRODUCTID"] != DBNull.Value) PRODUCTID = int.Parse(row["PRODUCTID"].ToString());

            if (row["QTY"] != DBNull.Value) QTY = int.Parse(row["QTY"].ToString());

            if (row["AMOUNT"] != DBNull.Value) AMOUNT = decimal.Parse(row["AMOUNT"].ToString());



            if (row["PRODUCTCODE"] != DBNull.Value) PRODUCTCODE = row["PRODUCTCODE"].ToString();
            if (row["DISTRIBUTORCODE"] != DBNull.Value) DISTRIBUTORCODE = row["DISTRIBUTORCODE"].ToString();
            if (row["PRODUCTNAME"] != DBNull.Value) PRODUCTNAME = row["PRODUCTNAME"].ToString();
            if (row["DISTRIBUTORNAME"] != DBNull.Value) DISTRIBUTORNAME = row["DISTRIBUTORNAME"].ToString();
            

            

            

        }
    }
}
