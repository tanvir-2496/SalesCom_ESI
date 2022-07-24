using System;
using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{
    [DataContract] public class Supplier
    {
        [DataMember] public System.Decimal SUPPLIERID { get; set; }
        [DataMember] public System.String SUPPLIERCODE { get; set; }
        [DataMember] public System.String SUPPLIERNAME { get; set; }
        [DataMember] public System.String ADDRESSLINE1 { get; set; }
        [DataMember] public System.String ADDRESSLINE2 { get; set; }
        [DataMember] public System.String TELEPHONENO { get; set; }
        [DataMember] public System.String CONTACTPERSON { get; set; }
        [DataMember] public System.String CONTACTNO { get; set; }
        [DataMember] public System.String FLEXFIELD1 { get; set; }
        [DataMember] public System.String FLEXFIELD2 { get; set; }

        public Supplier() { }
        public Supplier(DataRow objectRow)
        {
            if (objectRow["SUPPLIERID"] != DBNull.Value) this.SUPPLIERID = Convert.ToDecimal(objectRow["SUPPLIERID"]);
            this.SUPPLIERCODE = objectRow["SUPPLIERCODE"] as System.String;
            this.SUPPLIERNAME = objectRow["SUPPLIERNAME"] as System.String;
            this.ADDRESSLINE1 = objectRow["ADDRESSLINE1"] as System.String;
            this.ADDRESSLINE2 = objectRow["ADDRESSLINE2"] as System.String;
            this.TELEPHONENO = objectRow["TELEPHONENO"] as System.String;
            this.CONTACTPERSON = objectRow["CONTACTPERSON"] as System.String;
            this.CONTACTNO = objectRow["CONTACTNO"] as System.String;
            this.FLEXFIELD1 = objectRow["FLEXFIELD1"] as System.String;
            this.FLEXFIELD2 = objectRow["FLEXFIELD2"] as System.String;
        }
    }
}