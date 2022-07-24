using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class ReturnPrice
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
        public Int32 RETURNPRICEID{get;set;}
  
        [DataMember]
        public Int32 RETURNPRODUCTID{get;set;}


        [DataMember]
        public string PRODUCTCODE { get; set; }

        [DataMember]
        public string DISTRIBUTORCODE { get; set; }

        [DataMember]
        public string PRODUCTNAME { get; set; }

        [DataMember]
        public string DISTRIBUTORNAME { get; set; }

        [DataMember]
        public int PROMOTIONCYCLEID { get; set; }

        
        [DataMember]
        public string RETURNPRODUCT { get; set; }


        [DataMember]
        public string CHALLANSTATUS { get; set; }

        
       
        public ReturnPrice()
        { }

        public ReturnPrice(DataRow row)
        {

            try
            {
                if (row["PROMOTIONCYCLEID"] != DBNull.Value) PROMOTIONCYCLEID = int.Parse(row["PROMOTIONCYCLEID"].ToString());
            }
            catch { }



            if (row["DISTRIBUTORID"] != DBNull.Value) DISTRIBUTORID = int.Parse(row["DISTRIBUTORID"].ToString());
            if (row["RETURNPRICEID"] != DBNull.Value) RETURNPRICEID = int.Parse(row["RETURNPRICEID"].ToString());
            if (row["RETURNPRODUCTID"] != DBNull.Value) RETURNPRODUCTID = int.Parse(row["RETURNPRODUCTID"].ToString());

            if (row["TRANSACTIONREFNO"] != DBNull.Value) TRANSACTIONREFNO = row["TRANSACTIONREFNO"].ToString();


            if (row["PRODUCTID"] != DBNull.Value) PRODUCTID = int.Parse(row["PRODUCTID"].ToString());

            if (row["QTY"] != DBNull.Value) QTY = int.Parse(row["QTY"].ToString());

            if (row["AMOUNT"] != DBNull.Value) AMOUNT = decimal.Parse(row["AMOUNT"].ToString());



            if (row["PRODUCTCODE"] != DBNull.Value) PRODUCTCODE = row["PRODUCTCODE"].ToString();
            if (row["DISTRIBUTORCODE"] != DBNull.Value) DISTRIBUTORCODE = row["DISTRIBUTORCODE"].ToString();
            if (row["PRODUCTNAME"] != DBNull.Value) PRODUCTNAME = row["PRODUCTNAME"].ToString();
            if (row["DISTRIBUTORNAME"] != DBNull.Value) DISTRIBUTORNAME = row["DISTRIBUTORNAME"].ToString();

            if (row["RETURNPRODUCT"] != DBNull.Value) RETURNPRODUCT = row["RETURNPRODUCT"].ToString();

            if (row["CHALLANSTATUS"] != DBNull.Value) CHALLANSTATUS = row["CHALLANSTATUS"].ToString();
            
            
            

            

        }
    }
}
