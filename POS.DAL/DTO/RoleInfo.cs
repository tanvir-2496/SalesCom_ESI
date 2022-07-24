using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class RoleInfo
    {
        [DataMember] public System.Int32 ROLEID { get; set; }
        [DataMember] public System.Int32 ROLEGROUPID { get; set; }
        [DataMember] public System.String ROLENAME { get; set; }
        [DataMember] public System.String DISTRIBUTORNAME { get; set; }
        [DataMember] public System.String DESCRIPTION { get; set; }
        [DataMember] public System.String ACTIVEYN { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.String ROLEGROUPNAME { get; set; }
        [DataMember] public System.String GROUPEMAIL { get; set; }


        [DataMember]
        public System.String ROLEDISTRIBUTOR { get; set; }
        

        public RoleInfo() { }
        public RoleInfo(DataRow objectRow)
        {
            if (objectRow["ROLEID"] != DBNull.Value) this.ROLEID = Convert.ToInt32(objectRow["ROLEID"]);
            if (objectRow["ROLEGROUPID"] != DBNull.Value) this.ROLEGROUPID = Convert.ToInt32(objectRow["ROLEGROUPID"]);
            this.ROLENAME = objectRow["ROLENAME"] as System.String;
            try
            {
                this.DISTRIBUTORNAME = objectRow["DISTRIBUTORNAME"] as System.String;

            }
            catch (Exception ex)
            {
            
             this.DISTRIBUTORNAME="";
            }
            this.DESCRIPTION = objectRow["DESCRIPTION"] as System.String;
            this.ACTIVEYN = objectRow["ACTIVEYN"] as System.String;
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            this.ROLEGROUPNAME = objectRow["ROLEGROUPNAME"] as System.String;
            this.GROUPEMAIL = objectRow["GROUPEMAIL"] as System.String;


            try
            {

                if (!string.IsNullOrEmpty(DISTRIBUTORNAME))
                    this.ROLEDISTRIBUTOR = ROLENAME +"("+ DISTRIBUTORNAME+")";
                else
                    this.ROLEDISTRIBUTOR = ROLENAME;

            }
            catch (Exception ex)
            {

                this.ROLEDISTRIBUTOR = ROLENAME;
            }
        }
    }
}