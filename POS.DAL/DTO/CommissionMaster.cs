using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;

namespace POS.DAL.DTO
{
    [DataContract] 
    //[Serializable]
    public class CommissionMaster
    {
        [DataMember]
        public System.Int32 COMMISSIONID { get; set; }
        [DataMember]
        public System.Int32 COMMISSIONTYPEID { get; set; }

        [DataMember]
        public System.String COMTYPE { get; set; }

        [DataMember]
        public System.Int32 COMMISSIONNAMEID { get; set; }

        [DataMember]
        public System.String COMMISSIONNAME { get; set; }

        [DataMember]
        public System.String COMMISSIONREFNO { get; set; }
        [DataMember]
        public System.DateTime STARTDATE { get; set; }
        [DataMember]
        public System.DateTime ENDDATE { get; set; }

        [DataMember]
        public DateTime TRANSACTIONDATE { get; set; }

        [DataMember]
        public System.String RECORDSTATUS { get; set; }

        [DataMember]
        public string CREATEDBY { get; set; }
        [DataMember]
        public DateTime CREATEDDATE { get; set; }
        [DataMember]
        public string LASTUPDATEBY { get; set; }
        [DataMember]
        public DateTime LASTUPDATEDATE { get; set; }

        [DataMember]
        public System.String APPROVEDBY { get; set; }

        [DataMember]
        public System.DateTime APPROVEDDATE { get; set; }

        public CommissionMaster() { }
        
        public CommissionMaster(DataRow row)
        {
            if (row["COMMISSIONID"] != DBNull.Value) COMMISSIONID = int.Parse(row["COMMISSIONID"].ToString());

            if (row["COMMISSIONTYPEID"] != DBNull.Value) COMMISSIONTYPEID = int.Parse(row["COMMISSIONTYPEID"].ToString());

            if (row["COMTYPE"] != DBNull.Value) COMTYPE = row["COMTYPE"].ToString();

            if (row["COMMISSIONNAME"] != DBNull.Value) COMMISSIONNAME = row["COMMISSIONNAME"].ToString();

            if (row["COMMISSIONNAMEID"] != DBNull.Value) COMMISSIONNAMEID = int.Parse(row["COMMISSIONNAMEID"].ToString());

            if (row["COMMISSIONREFNO"] != DBNull.Value) COMMISSIONREFNO = row["COMMISSIONREFNO"].ToString();

            if (row["STARTDATE"] != DBNull.Value) STARTDATE = DateTime.Parse(row["STARTDATE"].ToString());

            if (row["ENDDATE"] != DBNull.Value) ENDDATE = DateTime.Parse(row["ENDDATE"].ToString());

            if (row["TRANSACTIONDATE"] != DBNull.Value) TRANSACTIONDATE = DateTime.Parse(row["TRANSACTIONDATE"].ToString());

            if (row["CREATEDBY"] != DBNull.Value) CREATEDBY = row["CREATEDBY"].ToString();

            if (row["CREATEDDATE"] != DBNull.Value) CREATEDDATE = DateTime.Parse(row["CREATEDDATE"].ToString());

            if (row["LASTUPDATEBY"] != DBNull.Value) LASTUPDATEBY = row["LASTUPDATEBY"].ToString();

            if (row["LASTUPDATEDATE"] != DBNull.Value) LASTUPDATEDATE = DateTime.Parse(row["LASTUPDATEDATE"].ToString());

            if (row["RECORDSTATUS"] != DBNull.Value)
                this.RECORDSTATUS = row["RECORDSTATUS"] as System.String;

            if (row["APPROVEDBY"] != DBNull.Value)
                this.APPROVEDBY = row["APPROVEDBY"].ToString();

            if (row["APPROVEDDATE"] != DBNull.Value)
                this.APPROVEDDATE = DateTime.Parse(row["APPROVEDDATE"].ToString());

        }
    }
}
