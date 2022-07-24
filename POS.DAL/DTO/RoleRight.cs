using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class RoleRight
    {
        [DataMember] public System.Int32 ROLEID { get; set; }
        [DataMember] public System.Int32 RIGHTID { get; set; }
        [DataMember] public System.Int32 RIGHTGROUPID { get; set; }
        [DataMember] public System.String UPDATEBY { get; set; }
        [DataMember] public System.DateTime UPDATEDATE { get; set; }

        public RoleRight() { }
        public RoleRight(DataRow objectRow)
        {
            if (objectRow["ROLEID"] != DBNull.Value) this.ROLEID = Convert.ToInt32(objectRow["ROLEID"]);
            if (objectRow["RIGHTGROUPID"] != DBNull.Value) this.RIGHTGROUPID = Convert.ToInt32(objectRow["RIGHTGROUPID"]);
            if (objectRow["RIGHTID"] != DBNull.Value) this.RIGHTID = Convert.ToInt32(objectRow["RIGHTID"]);
            this.UPDATEBY = objectRow["UPDATEBY"] as System.String;
            if (objectRow["UPDATEDATE"] != DBNull.Value) this.UPDATEDATE = Convert.ToDateTime(objectRow["UPDATEDATE"]);
        }
    }
}