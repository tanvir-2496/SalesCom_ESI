using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Teller
    {
        [DataMember] public System.Int32 TELLERID { get; set; }
       
        [DataMember] public System.String TELLERCODE { get; set; }
        [DataMember] public System.String TELLERNAME { get; set; }
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.Int32 DEFAULTCOLLECTIONMODEID { get; set; }
        [DataMember] public System.Int32 DEFAULTCOLLECTIONTYPEID { get; set; }
        [DataMember] public System.String DEFAULTCOLLECTIONMODE { get; set; }
        [DataMember] public System.String DEFAULTCOLLECTIONTYPE { get; set; }
        [DataMember] public System.String ENABLEDYN { get; set; }
        [DataMember] public System.String ISVAULT { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.String CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.String LASTUPDATEDATE { get; set; }

        public Teller() { }
        public Teller(DataRow objectRow)
        {
            if (objectRow["TELLERID"] != DBNull.Value) this.TELLERID = Convert.ToInt32(objectRow["TELLERID"]);
            this.TELLERCODE = objectRow["TELLERCODE"] as System.String;
            this.TELLERNAME = objectRow["TELLERNAME"] as System.String;
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);

            if (objectRow["DEFAULTCOLLECTIONMODEID"] != DBNull.Value) this.DEFAULTCOLLECTIONMODEID = Convert.ToInt32(objectRow["DEFAULTCOLLECTIONMODEID"]);
            if (objectRow["DEFAULTCOLLECTIONTYPEID"] != DBNull.Value) this.DEFAULTCOLLECTIONTYPEID = Convert.ToInt32(objectRow["DEFAULTCOLLECTIONTYPEID"]);

            this.DEFAULTCOLLECTIONMODE = objectRow["DEFAULTCOLLECTIONNAME"] as System.String;
            this.DEFAULTCOLLECTIONTYPE = objectRow["DEFAULTCOLLECTIONTYPE"] as System.String;



            this.ENABLEDYN = objectRow["ENABLEDYN"] as System.String;
            this.ISVAULT = objectRow["ISVAULT"] as System.String;
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            this.CREATEDATE = objectRow["CREATEDATE"] as System.String;
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            this.LASTUPDATEDATE = objectRow["LASTUPDATEDATE"] as System.String;
               }
    }
}