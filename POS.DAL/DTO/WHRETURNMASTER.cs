using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract] public class WHRETURNMASTER
    {
        [DataMember]  public System.Int32 WHRETURNID { get; set; }
        [DataMember]  public System.String WHRETURNCODE { get; set; }
        [DataMember] public System.DateTime WHRETURNDATE { get; set; }
         [DataMember] public System.Int32 RFRAISERID { get; set; }
         [DataMember] public System.String RFNO { get; set; }
        [DataMember] public System.String REMARKS { get; set; }
        [DataMember] public System.String RETURNREASON { get; set; }
        [DataMember] public System.Int32 STOREID { get; set; }
        [DataMember] public System.Int32 WAREHOUSECENTERID { get; set; }       
        [DataMember] public System.String CREATEBYUSER { get; set; }       
        [DataMember] public System.DateTime CREATEDATE { get; set; }       
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.DateTime STARTDATE { get; set; }
        [DataMember] public System.DateTime ENDDATE { get; set; }
        [DataMember] public System.String RECORDSTATUS { get; set; }     
       
        public WHRETURNMASTER() { }
        public WHRETURNMASTER(DataRow objectRow)
        {
            if (objectRow["WHRETURNID"] != DBNull.Value) this.WHRETURNID = Convert.ToInt32(objectRow["WHRETURNID"]);
            this.WHRETURNCODE = objectRow["WHRETURNCODE"] as System.String;
            if (objectRow["WHRETURNDATE"] != DBNull.Value) this.WHRETURNDATE = Convert.ToDateTime(objectRow["WHRETURNDATE"]);
            if (objectRow["RFRAISERID"] != DBNull.Value) this.RFRAISERID = Convert.ToInt32(objectRow["RFRAISERID"]);
            this.RFNO = objectRow["RFNO"] as System.String;
            this.REMARKS = objectRow["REMARKS"] as System.String;
            this.RETURNREASON = objectRow["RETURNREASON"] as System.String;
            if (objectRow["STOREID"] != DBNull.Value) this.STOREID = Convert.ToInt32(objectRow["STOREID"]);
            if (objectRow["WAREHOUSECENTERID"] != DBNull.Value) this.WAREHOUSECENTERID = Convert.ToInt32(objectRow["WAREHOUSECENTERID"]);
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
              //if (objectRow["STARTDATE"] != DBNull.Value) this.STARTDATE = Convert.ToDateTime(objectRow["STARTDATE"]);
             // if (objectRow["ENDDATE"] != DBNull.Value) this.ENDDATE = Convert.ToDateTime(objectRow["ENDDATE"]);
            try
            {
                if (objectRow["RECORDSTATUS"] != DBNull.Value) this.RECORDSTATUS = objectRow["RECORDSTATUS"].ToString();
            }
            catch (Exception ex)
            { }
   
        }
    }
}
