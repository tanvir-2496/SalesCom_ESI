using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Warehouse
    {
        [DataMember] public System.Int32 WAREHOUSEID { get; set; }
        [DataMember] public System.String WAREHOUSECODE { get; set; }
        [DataMember] public System.String WAREHOUSENAME { get; set; }
        [DataMember] public System.String ADDRESSLINE1 { get; set; }
        [DataMember] public System.String ADDRESSLINE2 { get; set; }
        [DataMember] public System.String TELEPHONENO { get; set; }
        [DataMember] public System.String CONTACTPERSON { get; set; }
        [DataMember] public System.String CONTACTNO { get; set; }
        [DataMember] public System.String FLEXFIELD1 { get; set; }
        [DataMember] public System.String FLEXFIELD2 { get; set; }
        [DataMember] public System.Int32 WHSTATUS { get; set; }
        
        public Warehouse() { }
        public Warehouse(DataRow objectRow)
        {
            if (objectRow["WAREHOUSEID"] != DBNull.Value) this.WAREHOUSEID = Convert.ToInt32(objectRow["WAREHOUSEID"]);
            this.WAREHOUSECODE = objectRow["WAREHOUSECODE"] as System.String;
            this.WAREHOUSENAME = objectRow["WAREHOUSENAME"] as System.String;
            this.ADDRESSLINE1 = objectRow["ADDRESSLINE1"] as System.String;
            this.ADDRESSLINE2 = objectRow["ADDRESSLINE2"] as System.String;
            this.TELEPHONENO = objectRow["TELEPHONENO"] as System.String;
            this.CONTACTPERSON = objectRow["CONTACTPERSON"] as System.String;
            this.CONTACTNO = objectRow["CONTACTNO"] as System.String;
            this.FLEXFIELD1 = objectRow["FLEXFIELD1"] as System.String;
            this.FLEXFIELD2 = objectRow["FLEXFIELD2"] as System.String;
            if (objectRow["WHSTATUS"] != DBNull.Value) this.WHSTATUS = Convert.ToInt32(objectRow["WHSTATUS"]);
        }
    }
}