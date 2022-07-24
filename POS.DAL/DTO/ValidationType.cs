using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class ValidationType
    {
        [DataMember]
        public int VALIDATIONID { get; set; }
        
        [DataMember]
        public string VALIDATIONNAME { get; set; }
  
        [DataMember]
        public string DESCRIPTION { get; set; }
  
        [DataMember]
        public int PRIORITY { get; set; }
  
      
         [DataMember]
        public int RETURNPRODUCTID { get; set; }
  
      
        

        
            
     

        public ValidationType()
        { }

        public ValidationType(DataRow row)
        {
            if (row["VALIDATIONID"] != DBNull.Value) VALIDATIONID = int.Parse(row["VALIDATIONID"].ToString());

            if (row["VALIDATIONNAME"] != DBNull.Value) VALIDATIONNAME = row["VALIDATIONNAME"].ToString();

            if (row["DESCRIPTION"] != DBNull.Value) DESCRIPTION = row["DESCRIPTION"].ToString();



            if (row["PRIORITY"] != DBNull.Value) PRIORITY = int.Parse( row["PRIORITY"].ToString());

            try
            {
                if (row["RETURNPRODUCTID"] != DBNull.Value) RETURNPRODUCTID = int.Parse(row["RETURNPRODUCTID"].ToString());
            }
            catch { }
        }
    }
}
