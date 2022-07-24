using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class AttachCenter
    {
        [DataMember]
        public System.Int32 ROOTCENTERID { get; set; }
        [DataMember]
        public System.Int32 ATTACHCENTERID { get; set; }
        [DataMember]
        public System.String ATTACHCENTERNAME { get; set; }

        public AttachCenter() { }
        public AttachCenter(DataRow objectRow)
        {
            if (objectRow["ROOTCENTERID"] != DBNull.Value) this.ROOTCENTERID = Convert.ToInt32(objectRow["ROOTCENTERID"]);
            if (objectRow["ATTACHCENTERID"] != DBNull.Value) this.ATTACHCENTERID = Convert.ToInt32(objectRow["ATTACHCENTERID"]);
            this.ATTACHCENTERNAME = objectRow["ATTACHCENTERNAME"] as System.String;
        }
    }
}