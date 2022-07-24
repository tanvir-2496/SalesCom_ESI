using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class RoleGroup
    {
        [DataMember] public System.Int32 ROLEGROUPID { get; set; }
        [DataMember] public System.String ROLEGROUPNAME { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.String CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.String LASTUPDATEDATE { get; set; }
        [DataMember] public System.String DESCRIPTION { get; set; }

        public RoleGroup() { }
        public RoleGroup(DataRow objectRow)
        {
            if (objectRow["ROLEGROUPID"] != DBNull.Value) this.ROLEGROUPID = Convert.ToInt32(objectRow["ROLEGROUPID"]);
            this.ROLEGROUPNAME = objectRow["ROLEGROUPNAME"] as System.String;
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            this.CREATEDATE = objectRow["CREATEDATE"] as System.String;
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            this.LASTUPDATEDATE = objectRow["LASTUPDATEDATE"] as System.String;
            this.DESCRIPTION = objectRow["DESCRIPTION"] as System.String;
        }
    }
}