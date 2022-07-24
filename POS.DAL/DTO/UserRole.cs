using System; using System.Runtime.Serialization; 
using System.Data;
namespace POS.DAL
{
    [DataContract] public class UserRole
    {
        [DataMember] public System.Int32 USERID { get; set; }
        [DataMember] public System.String ROLENAME { get; set; }
        [DataMember] public System.Int32 ROLEID { get; set; }
        [DataMember] public System.String USERNAME { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.String LASTUPDATEDATE { get; set; }

        public UserRole() { }
        public UserRole(DataRow objectRow)
        {
            if (objectRow["USERID"] != DBNull.Value) this.USERID = Convert.ToInt32(objectRow["USERID"]);
            if (objectRow["ROLEID"] != DBNull.Value) this.ROLEID = Convert.ToInt32(objectRow["ROLEID"]);
            this.ROLENAME = objectRow["ROLENAME"] as System.String;
            this.USERNAME = objectRow["USERNAME"] as System.String;
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            this.LASTUPDATEDATE = objectRow["LASTUPDATEDATE"] as System.String;
        }
    }
}