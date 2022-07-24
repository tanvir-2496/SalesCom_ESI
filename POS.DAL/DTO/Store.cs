using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Store
    {
        [DataMember] public System.Int32 STOREID { get; set; }
        [DataMember] public System.String STORECODE { get; set; }
        [DataMember] public System.String STORENAME { get; set; }
        [DataMember] public System.String DESCRIPTION { get; set; }
        [DataMember] public System.String ENABLEDYN { get; set; }
        [DataMember] public System.String BUFFERYN { get; set; }
        [DataMember]
        public System.String ASIGNEDSTATUS { get; set; }


        
        
        public Store() { }
        public Store(DataRow objectRow)
        {
            if (objectRow["STOREID"] != DBNull.Value) this.STOREID = Convert.ToInt32(objectRow["STOREID"]);
            this.STORECODE = objectRow["STORECODE"] as System.String;
            this.STORENAME = objectRow["STORENAME"] as System.String;
            this.DESCRIPTION = objectRow["DESCRIPTION"] as System.String;
            this.ENABLEDYN = objectRow["ENABLEDYN"] as System.String;
            this.BUFFERYN = objectRow["BUFFERYN"] as System.String;
            try
            {
                this.ASIGNEDSTATUS = objectRow["ASIGNEDSTATUS"] as System.String;
            }
            catch { }
        }
    }
}