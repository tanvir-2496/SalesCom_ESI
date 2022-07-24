using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class UserwiseCenter
    {
        public UserwiseCenter() { }

        [DataMember]
        public int USERID { get; set; }


        [DataMember]
        public int CENTERID { get; set; }

        [DataMember]
        public string CENTERNAME { get; set; }
        [DataMember]
        public string CREATEBY { get; set; }

        public UserwiseCenter(DataRow row)
        {
            if (row["USERID"] != DBNull.Value)
                USERID = int.Parse(row["USERID"].ToString());

            if (row["CENTERID"] != DBNull.Value)
                CENTERID =int.Parse(row["CENTERID"].ToString());

            if (row["CENTERNAME"] != DBNull.Value)
                CENTERNAME = row["CENTERNAME"].ToString();
          
        }
    }
}
