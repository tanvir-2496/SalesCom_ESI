using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class DMSInventorySync
    {
        public DMSInventorySync()
        { }

        [DataMember]
        public int RFID { get; set; }

        [DataMember]
        public string RFCODE { get; set; }

        [DataMember]
        public DateTime RFDATE { get; set; }

        [DataMember]
        public DateTime WHISSUEDATE { get; set; }

        [DataMember]
        public string SEGMENTNAME {get;set;}

        [DataMember]
        public string RFSTATUS { get; set; }

        public DMSInventorySync(DataRow row)
        {
            if (row["RFID"] != DBNull.Value)
                RFID = int.Parse(row["RFID"].ToString());

            if (row["RFCODE"] != DBNull.Value)
                RFCODE = row["RFCODE"].ToString();

            if (row["RFDATE"] != DBNull.Value)
                RFDATE = DateTime.Parse(row["RFDATE"].ToString());

            if (row["WHISSUEDATE"] != DBNull.Value)
                WHISSUEDATE = DateTime.Parse(row["WHISSUEDATE"].ToString());

            if (row["SEGMENTNAME"] != DBNull.Value)
                SEGMENTNAME = row["SEGMENTNAME"].ToString();

            if (row["RFSTATUS"] != DBNull.Value)
                RFSTATUS = row["RFSTATUS"].ToString();
        }
    }
}
