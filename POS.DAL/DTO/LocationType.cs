using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class LocationType
    {
        [DataMember] public System.Int32 LOCATIONTYPEID { get; set; }
        [DataMember] public System.String LOCATIONTYPENAME { get; set; }

        public LocationType() { }
        public LocationType(DataRow objectRow)
        {
            if (objectRow["LOCATIONTYPEID"] != DBNull.Value) this.LOCATIONTYPEID = Convert.ToInt32(objectRow["LOCATIONTYPEID"]);
            this.LOCATIONTYPENAME = objectRow["LOCATIONTYPENAME"] as System.String;
        }
    }
}