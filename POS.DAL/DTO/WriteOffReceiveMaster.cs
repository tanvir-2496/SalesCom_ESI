using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class WriteOffReceiveMaster
    {
        [DataMember]
        public int WRITEOFFRECEIVEID{get;set;}

        [DataMember]
        public string WRITEOFFRECEIVECODE { get; set; }

        [DataMember]
        public DateTime WRITEOFFRECEIVEDATE { get; set; }
  
        [DataMember]
        public string WRITEOFFCODE{get;set;}
        
        [DataMember]
        public string   REMARKS{get;set;}
  
        [DataMember]
        public char FROMWAREHOUSEORCENTER{get;set;}
  
        [DataMember]
        public int FROMWAREHOUSECENTERID{get;set;}
  
        [DataMember]
        public int FROMSTOREID{get;set;}
  
        [DataMember]
        public char RECEIVEWAREHOUSEORCENTER { get; set; }
  
        [DataMember]
        public int RECEIVEWAREHOUSECENTERID { get; set; }
      
        [DataMember]
        public int RECEIVESTOREID { get; set; }
  
        [DataMember]
        public string CREATEBYUSER {get;set;}
  
        [DataMember]
        public DateTime CREATEDATE{get;set;}
        
        [DataMember]
        public string LASTUPDATEBY{get;set;}
  
        [DataMember]
        public DateTime LASTUPDATEDATE{get;set;}

        [DataMember]
        public int RFID { get; set; }

        public WriteOffReceiveMaster()
        { }

        public WriteOffReceiveMaster(DataRow row)
        {
            if (row["WRITEOFFRECEIVEID"] != DBNull.Value) WRITEOFFRECEIVEID = int.Parse(row["WRITEOFFRECEIVEID"].ToString());
            if (row["WRITEOFFRECEIVECODE"] != DBNull.Value) WRITEOFFRECEIVECODE = row["WRITEOFFRECEIVECODE"].ToString();
            if (row["WRITEOFFRECEIVEDATE"] != DBNull.Value) WRITEOFFRECEIVEDATE = DateTime.Parse(row["WRITEOFFRECEIVEDATE"].ToString());
            if (row["WRITEOFFCODE"] != DBNull.Value) WRITEOFFCODE = row["WRITEOFFCODE"].ToString();
            if (row["REMARKS"] != DBNull.Value) REMARKS = row["REMARKS"].ToString();
            if (row["FROMWAREHOUSEORCENTER"] != DBNull.Value) FROMWAREHOUSEORCENTER = char.Parse(row["FROMWAREHOUSEORCENTER"].ToString());
            if(row["FROMWAREHOUSECENTERID"] != DBNull.Value) FROMWAREHOUSECENTERID = int.Parse(row["FROMWAREHOUSECENTERID"].ToString());
            if(row["FROMSTOREID"] != DBNull.Value) FROMSTOREID = int.Parse(row["FROMSTOREID"].ToString());
            if (row["RECEIVEWAREHOUSEORCENTER"] != DBNull.Value) RECEIVEWAREHOUSEORCENTER = char.Parse(row["RECEIVEWAREHOUSEORCENTER"].ToString());
            if (row["RECEIVEWAREHOUSECENTERID"] != DBNull.Value) RECEIVEWAREHOUSECENTERID = int.Parse(row["RECEIVEWAREHOUSECENTERID"].ToString());
            if (row["RECEIVESTOREID"] != DBNull.Value) RECEIVESTOREID = int.Parse(row["RECEIVESTOREID"].ToString());
            if(row["CREATEBYUSER"] != DBNull.Value) CREATEBYUSER = row["CREATEBYUSER"].ToString();
            if(row["CREATEDATE"] != DBNull.Value) CREATEDATE = DateTime.Parse(row["CREATEDATE"].ToString());
            if(row["LASTUPDATEBY"] != DBNull.Value) LASTUPDATEBY = row["LASTUPDATEBY"].ToString();
            if(row["LASTUPDATEDATE"] != DBNull.Value) LASTUPDATEDATE = DateTime.Parse(row["LASTUPDATEDATE"].ToString());
            if(row["RFID"] != DBNull.Value) RFID = int.Parse(row["RFID"].ToString());


        }
    }
}
