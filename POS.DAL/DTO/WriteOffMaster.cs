using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class WriteOffMaster
    {
        [DataMember]
        public int WRITEOFFID{get;set;}

        [DataMember]
        public string  WRITEOFFCODE{get;set;}

        [DataMember]
        public DateTime  WRITEOFFDATE{get;set;}
  
        [DataMember]
        public string REFNO{get;set;}
        
        [DataMember]
        public string   REMARKS{get;set;}
  
        [DataMember]
        public char FROMWAREHOUSEORCENTER{get;set;}
  
        [DataMember]
        public int FROMWAREHOUSECENTERID{get;set;}
  
        [DataMember]
        public int FROMSTOREID{get;set;}
  
        [DataMember]
        public char TOWAREHOUSEORCENTER{get;set;}
  
        [DataMember]
        public int TOWAREHOUSECENTERID{get;set;}
      
        [DataMember]
        public int TOSTOREID {get;set;}
  
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

        [DataMember]
        public int WRITEOFFRECEIVEID { get; set; }

        [DataMember]
        public string WRITEOFFRECEIVECODE { get; set; }


        [DataMember]
        public int DISPOSEID { get; set; }

        [DataMember]
        public string DISPOSECODE { get; set; }

        [DataMember]
        public int TRANSACTIONID { get; set; }

        [DataMember]
        public string WRITEOFFYN { get; set; }

        [DataMember]
        public string RECORDSTATUS { get; set; }

         
        public WriteOffMaster()
        { }

        public WriteOffMaster(DataRow row)
        {
            if (row["WRITEOFFID"] != DBNull.Value) WRITEOFFID = int.Parse(row["WRITEOFFID"].ToString());
            if (row["WRITEOFFCODE"] != DBNull.Value) WRITEOFFCODE = row["WRITEOFFCODE"].ToString();
            if (row["WRITEOFFDATE"] != DBNull.Value) WRITEOFFDATE = DateTime.Parse(row["WRITEOFFDATE"].ToString());
            if (row["REFNO"] != DBNull.Value) REFNO = row["REFNO"].ToString();
            if (row["REMARKS"] != DBNull.Value) REMARKS = row["REMARKS"].ToString();
            if (row["FROMWAREHOUSEORCENTER"] != DBNull.Value) FROMWAREHOUSEORCENTER = char.Parse(row["FROMWAREHOUSEORCENTER"].ToString());
            if(row["FROMWAREHOUSECENTERID"] != DBNull.Value) FROMWAREHOUSECENTERID = int.Parse(row["FROMWAREHOUSECENTERID"].ToString());
            if(row["FROMSTOREID"] != DBNull.Value) FROMSTOREID = int.Parse(row["FROMSTOREID"].ToString());
            if (row["TOWAREHOUSEORCENTER"] != DBNull.Value) TOWAREHOUSEORCENTER = char.Parse(row["TOWAREHOUSEORCENTER"].ToString());
            if(row["TOWAREHOUSECENTERID"] != DBNull.Value) TOWAREHOUSECENTERID = int.Parse(row["TOWAREHOUSECENTERID"].ToString());
            if(row["TOSTOREID"] != DBNull.Value) TOSTOREID = int.Parse(row["TOSTOREID"].ToString());
            if(row["CREATEBYUSER"] != DBNull.Value) CREATEBYUSER = row["CREATEBYUSER"].ToString();
            if(row["CREATEDATE"] != DBNull.Value) CREATEDATE = DateTime.Parse(row["CREATEDATE"].ToString());
            if(row["LASTUPDATEBY"] != DBNull.Value) LASTUPDATEBY = row["LASTUPDATEBY"].ToString();
            if(row["LASTUPDATEDATE"] != DBNull.Value) LASTUPDATEDATE = DateTime.Parse(row["LASTUPDATEDATE"].ToString());
            if(row["RFID"] != DBNull.Value) RFID = int.Parse(row["RFID"].ToString());
            if(row["WRITEOFFYN"] !=DBNull.Value) WRITEOFFYN = row["WRITEOFFYN"].ToString();

            try
            {
                if (row["WRITEOFFRECEIVEID"] != DBNull.Value) WRITEOFFRECEIVEID = int.Parse(row["WRITEOFFRECEIVEID"].ToString());
                if (row["WRITEOFFRECEIVECODE"] != DBNull.Value) WRITEOFFRECEIVECODE = row["WRITEOFFRECEIVECODE"].ToString();

                if (row["DISPOSEID"] != DBNull.Value) DISPOSEID = int.Parse(row["DISPOSEID"].ToString());
                if (row["DISPOSECODE"] != DBNull.Value) DISPOSECODE = row["DISPOSECODE"].ToString();

                if (row["TRANSACTIONID"] != DBNull.Value) TRANSACTIONID = int.Parse(row["TRANSACTIONID"].ToString());
            }
            catch (Exception EX)
            {
                throw;
            }

            try
            {
                if (row["RECORDSTATUS"] != DBNull.Value) RECORDSTATUS = row["RECORDSTATUS"].ToString();
            }
            catch (Exception ex)
            { 
            
            }
            
        }
    }
}
