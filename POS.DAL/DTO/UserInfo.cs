using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class UserInfo
    {
        [DataMember] public System.Int32 USERID { get; set; }
        [DataMember] public System.String USERNAME { get; set; }
        [DataMember] public System.String CENTERNAME { get; set; }
        [DataMember] public System.Int32 CENTERTYPEID { get; set; }
        [DataMember] public System.String DESCRIPTION { get; set; }
        [DataMember] public System.String DEPARTMENT { get; set; }
        [DataMember] public System.String PASSWORD { get; set; }
        [DataMember] public System.Int32 USERGROUPID { get; set; }
        [DataMember] public System.String USERSTATUS { get; set; }
        [DataMember] public System.String EMAILADDR { get; set; }
        [DataMember] public System.String MOBILENO { get; set; }
        [DataMember] public System.String PASSWORDNEVEXP { get; set; }
        [DataMember] public System.String USERCHANGEDPASSYN { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.String LOGINNAME { get; set; }
        [DataMember] public System.String TELLERCODE { get; set; }
        [DataMember] public System.String TELLERNAME { get; set; }
        [DataMember] public System.String USERGROUPNAME { get; set; }
        [DataMember] public System.Int32 CURRENTCENTERID { get; set; }
        [DataMember] public System.Int32 CURRENTTELLERID { get; set; }
        [DataMember] public System.DateTime PASSWORDCHANGEDDATE { get; set; }
        [DataMember] public System.String CENTERCODE { get; set; }
        [DataMember] public System.Int32 WAREHOUSEID { get; set; }
        [DataMember] public System.String PASSWORDCHANGEDBY { get; set; }
        [DataMember] public System.String SMSPASSWORD { get; set; }
        [DataMember] public System.Int32 USERTYPE { get; set; }
        [DataMember] public System.Int32 DISTRIBUTOR { get; set; }
        [DataMember] public System.String DOMAIN { get; set; }
        [DataMember] public System.String Islocked { get; set; }
        [DataMember] public System.String IsInternal { get; set; }
        [DataMember] public System.Int32 PASSCNGALERTDAYS { get; set; }
        [DataMember]
        public System.Int32 PASSWORDWARNINGDAYS { get; set; }
        
        public UserInfo() { }
        public UserInfo(DataRow objectRow)
        {

            try
            {
                if (objectRow["USERID"] != DBNull.Value) this.USERID = Convert.ToInt32(objectRow["USERID"]);
                this.USERNAME = objectRow["USERNAME"] as System.String;
                this.DESCRIPTION = objectRow["DESCRIPTION"] as System.String;
                this.DEPARTMENT = objectRow["DEPARTMENT"] as System.String;
                this.PASSWORD = objectRow["PASSWORD"] as System.String;
                if (objectRow["USERGROUPID"] != DBNull.Value) this.USERGROUPID = Convert.ToInt32(objectRow["USERGROUPID"]);
                this.USERSTATUS = objectRow["USERSTATUS"] as System.String;
                this.EMAILADDR = objectRow["EMAILADDR"] as System.String;
                this.MOBILENO = objectRow["MOBILENO"] as System.String;
                this.PASSWORDNEVEXP = objectRow["PASSWORDNEVEXP"] as System.String;
                this.USERCHANGEDPASSYN = objectRow["USERCHANGEDPASSYN"] as System.String;
                this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
                if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
                this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
                if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
                if (objectRow["PASSWORDCHANGEDDATE"] != DBNull.Value) this.PASSWORDCHANGEDDATE = Convert.ToDateTime(objectRow["PASSWORDCHANGEDDATE"]);
                this.LOGINNAME = objectRow["LOGINNAME"] as System.String;
                this.USERGROUPNAME = objectRow["USERGROUPNAME"] as System.String;
                if (objectRow["CURRENTCENTERID"] != DBNull.Value)
                {
                    this.CURRENTCENTERID = Convert.ToInt32(objectRow["CURRENTCENTERID"]);
                }
                if (objectRow["CURRENTTELLERID"] != DBNull.Value)
                {
                    this.CURRENTTELLERID = Convert.ToInt32(objectRow["CURRENTTELLERID"]);
                }

                if (objectRow["CENTERTYPEID"] != DBNull.Value)
                {
                    this.CENTERTYPEID = Convert.ToInt32(objectRow["CENTERTYPEID"]);
                }
                if (objectRow["WAREHOUSEID"] != DBNull.Value)
                {
                    this.WAREHOUSEID = Convert.ToInt32(objectRow["WAREHOUSEID"]);
                }
                try
                {

                    this.SMSPASSWORD = objectRow["SMSPASSWORD"] as System.String;
                }
                catch { }

                this.TELLERCODE = objectRow["TELLERCODE"] as System.String;
                this.CENTERNAME = objectRow["CENTERNAME"] as System.String;
                this.TELLERNAME = objectRow["TELLERNAME"] as System.String;
                this.CENTERCODE = objectRow["CENTERCODE"] as System.String;
                this.PASSWORDCHANGEDBY = objectRow["PASSWORDCHANGEDBY"] as System.String;
                if (objectRow["USERTYPE"] != DBNull.Value)
                this.USERTYPE = Convert.ToInt32(objectRow["USERTYPE"]);
                if (objectRow["DISTRIBUTOR"] != DBNull.Value)
                this.DISTRIBUTOR = Convert.ToInt32(objectRow["DISTRIBUTOR"]);
                this.DOMAIN = objectRow["DOMAIN"] as System.String;
                try
                {
                    if (objectRow["IsLocked"] != DBNull.Value)
                    {
                        this.Islocked = objectRow["IsLocked"] as System.String;
                    }
                }
                catch (Exception ex)
                { }

                try
                {
                    if (objectRow["ISINTERNAL"] != DBNull.Value)
                    {
                        this.IsInternal = objectRow["ISINTERNAL"] as System.String;
                    }
                }
                catch (Exception ex)
                { }

                try
                {
                    if (objectRow["PASSCNGALERTDAYS"] != DBNull.Value)
                    {
                        this.PASSCNGALERTDAYS = Convert.ToInt32(objectRow["PASSCNGALERTDAYS"]);
                    }
                }
                catch (Exception ex)
                { }
                try
                {
                    if (objectRow["PASSWORDWARNINGDAYS"] != DBNull.Value)
                    {
                        this.PASSWORDWARNINGDAYS = Convert.ToInt32(objectRow["PASSWORDWARNINGDAYS"]);
                    }
                }
                catch (Exception ex)
                { }
            }
            catch (Exception ex)
            {
            
            
            
            }
            
        }
    }
}