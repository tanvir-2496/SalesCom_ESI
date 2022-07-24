using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class RightInfo
    {
        [DataMember] public System.Int32 RIGHTID { get; set; }
        [DataMember] public System.Int32 RIGHTGROUPID { get; set; }
        [DataMember] public System.String RIGHTNAME { get; set; }
        [DataMember] public System.String DESCRIPTION { get; set; }
        [DataMember] public System.String ACTIVEYN { get; set; }

        public RightInfo() { }
        public RightInfo(DataRow objectRow)
        {
            if (objectRow["RIGHTID"] != DBNull.Value) this.RIGHTID = Convert.ToInt32(objectRow["RIGHTID"]);
            if (objectRow["RIGHTGROUPID"] != DBNull.Value) this.RIGHTGROUPID = Convert.ToInt32(objectRow["RIGHTGROUPID"]);
            this.RIGHTNAME = objectRow["RIGHTNAME"] as System.String;
            this.DESCRIPTION = objectRow["DESCRIPTION"] as System.String;
            this.ACTIVEYN = objectRow["ACTIVEYN"] as System.String;
        }
    }
}