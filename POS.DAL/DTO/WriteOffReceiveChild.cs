using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class WriteOffReceiveChild
    {
         [DataMember]
        public int WRITEOFFRECEIVEID { get; set; }

        [DataMember]
        public int CHILDID { get; set; }

        [DataMember]
        public int PRODUCTID { get; set; }
  
        [DataMember]
        public int QTY { get; set; }
        
        [DataMember]
        public string SIMSTART { get; set; }
  
        [DataMember]
        public string SIMEND { get; set; }
  
        [DataMember]
        public int WAREHOUSECENTERID { get; set; }
          
        [DataMember]
        public int STOREID { get; set; }  
          
        [DataMember]
        public string CREATEBYUSER {get;set;}
  
        [DataMember]
        public DateTime CREATEDATE{get;set;}
        
        [DataMember]
        public string LASTUPDATEBY{get;set;}
  
        [DataMember]
        public DateTime LASTUPDATEDATE{get;set;}

        
        public WriteOffReceiveChild()
        { }

        public WriteOffReceiveChild(DataRow row)
        {
            if (row["WRITEOFFRECEIVEID"] != DBNull.Value) WRITEOFFRECEIVEID = int.Parse(row["WRITEOFFRECEIVEID"].ToString());
            if (row["CHILDID"] != DBNull.Value) CHILDID = int.Parse(row["CHILDID"].ToString());
            if (row["PRODUCTID"] != DBNull.Value) PRODUCTID = int.Parse(row["PRODUCTID"].ToString());
            if (row["QTY"] != DBNull.Value) QTY = int.Parse(row["QTY"].ToString());
            if (row["SIMSTART"] != DBNull.Value) SIMSTART = row["SIMSTART"].ToString();
            if (row["SIMEND"] != DBNull.Value) SIMEND = row["SIMEND"].ToString();
            if (row["WAREHOUSECENTERID"] != DBNull.Value) WAREHOUSECENTERID = int.Parse(row["WAREHOUSECENTERID"].ToString());
            if (row["STOREID"] != DBNull.Value) STOREID = int.Parse(row["STOREID"].ToString());            
            if(row["CREATEBYUSER"] != DBNull.Value) CREATEBYUSER = row["CREATEBYUSER"].ToString();
            if(row["CREATEDATE"] != DBNull.Value) CREATEDATE = DateTime.Parse(row["CREATEDATE"].ToString());
            if(row["LASTUPDATEBY"] != DBNull.Value) LASTUPDATEBY = row["LASTUPDATEBY"].ToString();
            if(row["LASTUPDATEDATE"] != DBNull.Value) LASTUPDATEDATE = DateTime.Parse(row["LASTUPDATEDATE"].ToString());
            
            
        }
    }
}
