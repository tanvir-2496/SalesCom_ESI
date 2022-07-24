using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;

namespace POS.DAL
{
     [DataContract]
    public class AlternativeChannel
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string CODE { get; set; }

        [DataMember]
        public string NAME { get; set; }

        [DataMember]
        public char ISACTIVE { get; set; }


        public AlternativeChannel(DataRow row)
        {
            if (row["ID"] != DBNull.Value) ID = int.Parse(row["ID"].ToString());
            if (row["CODE"] != DBNull.Value) CODE = row["CODE"].ToString();
            if (row["NAME"] != DBNull.Value) NAME = row["NAME"].ToString();
            if (row["ISACTIVE"] != DBNull.Value) ISACTIVE = char.Parse(row["ISACTIVE"].ToString());
        }
    }
}
