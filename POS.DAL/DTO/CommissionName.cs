using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class CommissionName
    {
        [DataMember]
        public int COMNAMEID { get; set; }
        
        [DataMember]
        public string COMNAME{get;set;}
  
        [DataMember]
        public string COMCODE{get;set;}
  
        [DataMember]
        public int ISAITINCLUSIVE{get;set;}
  
        [DataMember]
        public decimal AMOUNT{get;set;}  
            
        [DataMember]
        public string CREATEDBY { get; set; }

        [DataMember]
        public DateTime CREATEDDATE { get; set; }

        [DataMember]
        public string LASTUPDATEBY { get; set; }

        [DataMember]
        public DateTime LASTUPDATEDATE { get; set; }       

        public CommissionName()
        { }

        public CommissionName(DataRow row)
        {
            if (row["COMNAMEID"] != DBNull.Value) COMNAMEID = int.Parse(row["COMNAMEID"].ToString());
            if (row["COMNAME"] != DBNull.Value) COMNAME = row["COMNAME"].ToString();
            if (row["COMCODE"] != DBNull.Value) COMCODE = row["COMCODE"].ToString();
            if (row["ISAITINCLUSIVE"] != DBNull.Value) ISAITINCLUSIVE = Convert.ToInt32(row["ISAITINCLUSIVE"]);
            if (row["AMOUNT"] != DBNull.Value) AMOUNT = Convert.ToDecimal(row["AMOUNT"].ToString());
            if (row["CREATEDBY"] != DBNull.Value) CREATEDBY = row["CREATEDBY"].ToString();
            if (row["CREATEDDATE"] != DBNull.Value) CREATEDDATE = Convert.ToDateTime(row["CREATEDDATE"].ToString());
            if (row["LASTUPDATEBY"] != DBNull.Value) LASTUPDATEBY = row["LASTUPDATEBY"].ToString();
            if (row["LASTUPDATEDATE"] != DBNull.Value) LASTUPDATEDATE = Convert.ToDateTime(row["LASTUPDATEDATE"].ToString());
        }
    }
}
