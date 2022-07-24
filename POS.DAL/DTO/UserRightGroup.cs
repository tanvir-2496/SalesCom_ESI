using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class UserRightGroup
    {
        [DataMember] public System.Int32 RIGHTGROUPID { get; set; }
        [DataMember] public System.String RIGHTGROUPNAME { get; set; }
        [DataMember] public System.String DESCRIPTION { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }

        public UserRightGroup() { }
        public UserRightGroup(DataRow objectRow)
        {
            if (objectRow["RIGHTGROUPID"] != DBNull.Value) this.RIGHTGROUPID = Convert.ToInt32(objectRow["RIGHTGROUPID"]);
            this.RIGHTGROUPNAME = objectRow["RIGHTGROUPNAME"] as System.String;
            this.DESCRIPTION = objectRow["DESCRIPTION"] as System.String;
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
        }
    }
}