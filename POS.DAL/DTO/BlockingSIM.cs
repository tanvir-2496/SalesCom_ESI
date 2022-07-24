using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class BlockingSIM
    {
        public BlockingSIM()
        { }


        [DataMember]
        public int ID { get; set;}

        [DataMember]
        public string MSISDN { get; set; }

        [DataMember]
        public string ENABLEDISABLE { get; set; }

        [DataMember]
        public string REMARKS { get; set; }

        [DataMember]
        public DateTime CREATIONDATE { get; set; }

        [DataMember]
        public string CREATEBYUSER { get; set; }

        [DataMember]
        public string LASTUPDATEBY { get; set; }

        [DataMember]
        public DateTime LASTUPDATEDATE { get; set; }


        public BlockingSIM(DataRow row)
        {
            if (row["ID"] != DBNull.Value) ID = int.Parse(row["ID"].ToString());
            if (row["MSISDN"] != DBNull.Value) MSISDN = row["MSISDN"].ToString();
            if (row["REMARKS"] != DBNull.Value) REMARKS = row["REMARKS"].ToString();
            if (row["ENABLEDISABLE"] != DBNull.Value) ENABLEDISABLE = row["ENABLEDISABLE"].ToString();
            if (row["CREATIONDATE"] != DBNull.Value) CREATIONDATE = DateTime.Parse(row["CREATIONDATE"].ToString());
            if (row["CREATEBYUSER"] != DBNull.Value) CREATEBYUSER = row["CREATEBYUSER"].ToString();
            if (row["LASTUPDATEBY"] != DBNull.Value) LASTUPDATEBY = row["LASTUPDATEBY"].ToString();
            if (row["LASTUPDATEDATE"] != DBNull.Value) LASTUPDATEDATE = DateTime.Parse(row["LASTUPDATEDATE"].ToString());
        }
    }
}
