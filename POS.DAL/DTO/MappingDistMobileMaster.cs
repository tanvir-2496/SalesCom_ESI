using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;

namespace POS.DAL
{
    [DataContract]
    public class MAPPINGDISTMOBILEMASTER
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int DISTRIBUTORID { get; set; }

        [DataMember]
        public string ZSMMOBILENO { get; set; }

        [DataMember]
        public string RSMMOBILENO { get; set; }

        [DataMember]
        public string CREATEBYUSER { get; set; }

        [DataMember]
        public DateTime CREATEDATE { get; set; }

        [DataMember]
        public string LASTUPDATEBY { get; set; }

        [DataMember]
        public DateTime LASTUPDATEDATE { get; set; }

        public MAPPINGDISTMOBILEMASTER(DataRow objectRow)
        {
            if (objectRow["ID"] != DBNull.Value) this.ID = Convert.ToInt32(objectRow["ID"]);
            if (objectRow["DISTRIBUTORID"] != DBNull.Value) this.DISTRIBUTORID = Convert.ToInt32(objectRow["DISTRIBUTORID"]);
            this.ZSMMOBILENO = objectRow["ZSMMOBILENO"] as System.String;
            this.RSMMOBILENO = objectRow["RSMMOBILENO"] as System.String;
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;

            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
        }
    }
}
