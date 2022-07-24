using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

   [DataContract] public class WarehouseCenterStore
    {
     
        [DataMember] public System.Int32 WAREHOUSECENTERID { get; set; }
        [DataMember] public System.Int32 STOREID { get; set; }         
        [DataMember] public System.String STORETYPE { get; set; }
        [DataMember] public System.String WAREHOUSENAME { get; set; }
        [DataMember] public System.String STORENAME { get; set; }
        [DataMember] public System.String CENTERNAME { get; set; }
        [DataMember] public System.String BUFFERYN { get; set; }
        public WarehouseCenterStore() { }
        public WarehouseCenterStore(DataRow objectRow)
        {
            if (objectRow["WAREHOUSECENTERID"] != DBNull.Value) this.WAREHOUSECENTERID = Convert.ToInt32(objectRow["WAREHOUSECENTERID"]);
            if (objectRow["STOREID"] != DBNull.Value) this.STOREID = Convert.ToInt32(objectRow["STOREID"]);
            this.STORETYPE = objectRow["STORETYPE"] as string;
            this.WAREHOUSENAME = objectRow["WAREHOUSENAME"] as string;
            this.STORENAME = objectRow["STORENAME"] as string;
            this.CENTERNAME = objectRow["CENTERNAME"] as string;
            try
            {
                this.BUFFERYN = objectRow["BUFFERYN"] as string;
            }
            catch { 
            }
            
        }
    }
}