using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL1
{

    [DataContract] public class UserGroup
    {
        [DataMember] public System.Int32 USERGROUPID { get; set; }
        [DataMember] public System.String USERGROUPNAME { get; set; }
        [DataMember] public System.String DESCRIPTION { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.String CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.String LASTUPDATEDATE { get; set; }

        public UserGroup() { }
        public UserGroup(DataRow objectRow)
        {
            if (objectRow["USERGROUPID"] != DBNull.Value) this.USERGROUPID = Convert.ToInt32(objectRow["USERGROUPID"]);
            this.USERGROUPNAME = objectRow["USERGROUPNAME"] as System.String;
            this.DESCRIPTION = objectRow["DESCRIPTION"] as System.String;
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            this.CREATEDATE = objectRow["CREATEDATE"] as System.String;
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            this.LASTUPDATEDATE = objectRow["LASTUPDATEDATE"] as System.String;
        }
    }
}