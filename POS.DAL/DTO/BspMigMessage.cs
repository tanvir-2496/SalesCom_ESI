using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class BspMigMessage
    {

        
        
    
   
       
       
    
  
             
      
       
   
            
           
        
          
         
        


        [DataMember]
        public string SENDER { get; set; }
        
        [DataMember]
        public string SMSMSG{get;set;}
  
        [DataMember]
        public string CUSTMSISDN{get;set;}
  
        [DataMember]
        public string REQUESTTYPE{get;set;}
  
        [DataMember]
        public string PACKAGE{get;set;}

        [DataMember]
        public string APICALL { get; set; }

          [DataMember]
        public string INFOUPDATE { get; set; }
          [DataMember]
        public DateTime MIGRATIONDATE { get; set; }
          [DataMember]
        public int ID { get; set; }
          [DataMember]
        public string FIRSTNAME { get; set; }

        [DataMember]
        public string LASTNAME { get; set; }


             [DataMember]
        public string ALTERNATIVENUMBER { get; set; }


        
             [DataMember]
        public string ADDRESS { get; set; }
        
             [DataMember]
        public int APINUMBER { get; set; }

           [DataMember]
        public string REPLYMESSAGE { get; set; }

          [DataMember]
        public string ASSIGNNAME { get; set; }

          [DataMember]
        public string SMSSTATUS { get; set; }
         [DataMember]
        public string SERVICECODE { get; set; }

        public BspMigMessage()
        { }

        public BspMigMessage(DataRow row)
        {
            if (row["SENDER"] != DBNull.Value) SENDER = row["SENDER"].ToString();

            if (row["SMSMSG"] != DBNull.Value) SMSMSG = row["SMSMSG"].ToString();

            if (row["CUSTMSISDN"] != DBNull.Value) CUSTMSISDN = row["CUSTMSISDN"].ToString();

            if (row["REQUESTTYPE"] != DBNull.Value) REQUESTTYPE = row["REQUESTTYPE"].ToString();

            if (row["PACKAGE"] != DBNull.Value) PACKAGE = row["PACKAGE"].ToString();

            if (row["APICALL"] != DBNull.Value) APICALL = row["APICALL"].ToString();

            if (row["INFOUPDATE"] != DBNull.Value) INFOUPDATE = row["INFOUPDATE"].ToString();

            if (row["MIGRATIONDATE"] != DBNull.Value) MIGRATIONDATE =Convert.ToDateTime(row["MIGRATIONDATE"]);


            if (row["ID"] != DBNull.Value) ID =int.Parse(row["ID"].ToString());
            if (row["FIRSTNAME"] != DBNull.Value) FIRSTNAME = row["FIRSTNAME"].ToString();
            if (row["LASTNAME"] != DBNull.Value) LASTNAME = row["LASTNAME"].ToString();


            if (row["LASTNAME"] != DBNull.Value) LASTNAME = row["LASTNAME"].ToString();
            if (row["LASTNAME"] != DBNull.Value) LASTNAME = row["LASTNAME"].ToString();
            if (row["ALTERNATIVENUMBER"] != DBNull.Value) ALTERNATIVENUMBER = row["ALTERNATIVENUMBER"].ToString();
            if (row["ADDRESS"] != DBNull.Value) ADDRESS = row["ADDRESS"].ToString();
            if (row["APINUMBER"] != DBNull.Value) APINUMBER = int.Parse(row["APINUMBER"].ToString());

            if (row["REPLYMESSAGE"] != DBNull.Value) REPLYMESSAGE = row["REPLYMESSAGE"].ToString();
            if (row["ASSIGNNAME"] != DBNull.Value) ASSIGNNAME = row["ASSIGNNAME"].ToString();
            if (row["SMSSTATUS"] != DBNull.Value) SMSSTATUS = row["SMSSTATUS"].ToString();
            if (row["SERVICECODE"] != DBNull.Value) SERVICECODE = row["SERVICECODE"].ToString();






        }
    }
}
