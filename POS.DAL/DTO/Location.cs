using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Location
    {
        [DataMember] public System.Int32 LOCATIONID { get; set; }
        [DataMember] public System.String LOCATIONNAME { get; set; }
        [DataMember] public System.Int32 PARENTLOCATIONID { get; set; }
        [DataMember] public System.String LOCATIONCODE { get; set; }
        
        [DataMember] public System.String ISLEAF { get; set; }
        [DataMember] public System.String ROOTPATH { get; set; }
        [DataMember] public System.Int32 LOCATIONTYPEID { get; set; }
        [DataMember] public System.Int32 SUBLOCATIONTYPEID { get; set; }

        [DataMember] public System.String LOCATIONTYPENAME { get; set; }
        [DataMember] public System.String SUBLOCATIONTYPENAME { get; set; }

        public Location() { }
        public Location(DataRow objectRow)
        {
            if (objectRow["LOCATIONID"] != DBNull.Value) this.LOCATIONID = Convert.ToInt32(objectRow["LOCATIONID"]);
            this.LOCATIONNAME = objectRow["LOCATIONNAME"] as System.String;
            if (objectRow["PARENTLOCATIONID"] != DBNull.Value) this.PARENTLOCATIONID = Convert.ToInt32(objectRow["PARENTLOCATIONID"]);
            this.LOCATIONCODE = objectRow["LOCATIONCODE"] as System.String;
            
            this.ISLEAF = objectRow["ISLEAF"] as System.String;
            this.ROOTPATH = objectRow["ROOTPATH"] as System.String;
            if (objectRow["LOCATIONTYPEID"] != DBNull.Value) this.LOCATIONTYPEID = Convert.ToInt32(objectRow["LOCATIONTYPEID"]);
            if (objectRow["SUBLOCATIONTYPEID"] != DBNull.Value) this.SUBLOCATIONTYPEID = Convert.ToInt32(objectRow["SUBLOCATIONTYPEID"]);
            this.LOCATIONTYPENAME = objectRow["LOCATIONTYPENAME"] as System.String;
            this.SUBLOCATIONTYPENAME = objectRow["SUBLOCATIONTYPENAME"] as System.String;
        }
    }
}