using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class ReturnVatChallan
    {
        [DataMember]
        public int RETURNPRODUCTID { get; set; }
  
  
        [DataMember]
        public DateTime RETURNDATE { get; set; }



        
  
        [DataMember]
        public string REMARKS { get; set; }
  
        [DataMember]
        public string CHALLANSTATUS { get; set; }


        [DataMember]
        public DateTime FROMDATE { get; set; }

        [DataMember]
        public DateTime TODATE { get; set; }


        [DataMember]
        public string TRANSACTIONREFNO { get; set; }





        [DataMember]
        public Int32 DISTRIBUTORID { get; set; }



        [DataMember]
        public String DISTRIBUTORNAME { get; set; }


        [DataMember]
        public Int32 WAREHOUSEID { get; set; }

      

         [DataMember]
         public String WAREHOUSENAME { get; set; }

         [DataMember]
         public String WAREHOUSECODE { get; set; }

         [DataMember]
         public Int32 RFRAISERID { get; set; }
   
        [DataMember]
         public String RETURNPRODUCT { get; set; }


        

        public ReturnVatChallan()
        { }

        public ReturnVatChallan(DataRow row)
        {
            if (row["RETURNPRODUCTID"] != DBNull.Value) RETURNPRODUCTID = int.Parse(row["RETURNPRODUCTID"].ToString());



            if (row["RETURNDATE"] != DBNull.Value) RETURNDATE = Convert.ToDateTime(row["RETURNDATE"].ToString());



            if (row["CHALLANSTATUS"] != DBNull.Value) CHALLANSTATUS = row["CHALLANSTATUS"].ToString();

            if (row["TRANSACTIONREFNO"] != DBNull.Value) TRANSACTIONREFNO = row["TRANSACTIONREFNO"].ToString();

        

            if (row["WAREHOUSEID"] !=   DBNull.Value) WAREHOUSEID = int.Parse(row["WAREHOUSEID"].ToString());
            if (row["DISTRIBUTORID"] != DBNull.Value) DISTRIBUTORID = int.Parse(row["DISTRIBUTORID"].ToString());
            
            
            
            this.CHALLANSTATUS = row["CHALLANSTATUS"] as System.String;
            this.WAREHOUSECODE = row["WAREHOUSECODE"] as System.String;
            this.WAREHOUSENAME = row["WAREHOUSENAME"] as System.String;


            if (row["RFRAISERID"] != DBNull.Value) RFRAISERID = int.Parse(row["RFRAISERID"].ToString());
            this.DISTRIBUTORNAME = row["DISTRIBUTORNAME"] as System.String;

            this.RETURNPRODUCT = row["RETURNPRODUCT"] as System.String;

            

            
            
            


        }
    }
}
