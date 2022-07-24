using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;

namespace POS.DAL
{
    [DataContract]
    public class MAPPINGDISTMOBILECHILD
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int MAPPINGDISTMOBILEMASTERID { get; set; }

        [DataMember]
        public string DISTRIBUTORMOBILENO { get; set; }

        public MAPPINGDISTMOBILECHILD(DataRow objectRow)
        {
            if (objectRow["ID"] != DBNull.Value) this.ID = Convert.ToInt32(objectRow["ID"]);
            if (objectRow["MAPPINGDISTMOBILEMASTERID"] != DBNull.Value) this.MAPPINGDISTMOBILEMASTERID = Convert.ToInt32(objectRow["MAPPINGDISTMOBILEMASTERID"]);
            this.DISTRIBUTORMOBILENO = objectRow["DISTRIBUTORMOBILENO"] as System.String;
            
        }
    }
}
