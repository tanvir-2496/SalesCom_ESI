using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Customer
    {
        [DataMember] public System.Int32 CUSTOMERID { get; set; }
        [DataMember] public System.String CUSTOMERCODE { get; set; }
        [DataMember] public System.String CONTACTMOBILENO { get; set; }
        [DataMember] public System.String CUSTOMERNAME { get; set; }
        [DataMember] public System.String ADDRESSLINE1 { get; set; }
        [DataMember] public System.String ADDRESSLINE2 { get; set; }
        [DataMember] public System.String EMAILADDRESS { get; set; }
        [DataMember] public System.Int32 CUSTOMERTYPEID { get; set; }
        [DataMember] public System.String CUSTOMERTYPENAME { get; set; }
        public Customer() { }
        public Customer(DataRow objectRow)
        {
            if (objectRow["CUSTOMERID"] != DBNull.Value) this.CUSTOMERID = Convert.ToInt32(objectRow["CUSTOMERID"]);
            this.CUSTOMERCODE = objectRow["CUSTOMERCODE"] as System.String;
            this.CONTACTMOBILENO = objectRow["CONTACTMOBILENO"] as System.String;
            this.CUSTOMERNAME = objectRow["CUSTOMERNAME"] as System.String;
            this.ADDRESSLINE1 = objectRow["ADDRESSLINE1"] as System.String;
            this.ADDRESSLINE2 = objectRow["ADDRESSLINE2"] as System.String;
            this.EMAILADDRESS = objectRow["EMAILADDRESS"] as System.String;
            if (objectRow["CUSTOMERTYPEID"] != DBNull.Value) this.CUSTOMERTYPEID = Convert.ToInt32(objectRow["CUSTOMERTYPEID"]);
            this.CUSTOMERTYPENAME = objectRow["CUSTOMERTYPENAME"] as System.String;
            
        }
    }
}