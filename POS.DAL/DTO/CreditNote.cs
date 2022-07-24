using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class CreditNote
    {
        [DataMember] public System.Int32 CREDITNOTEID { get; set; }
        [DataMember] public System.Int32 RETURNID { get; set; }
        [DataMember] public System.String SLNO { get; set; }
        [DataMember] public System.DateTime ISSUEDATE { get; set; }
        [DataMember] public System.String CUSTOMERNAME { get; set; }
        [DataMember] public System.String ADDRESS { get; set; }
        [DataMember] public System.String CREDITRETURNPURPOSE { get; set; }

        public CreditNote() { }
        public CreditNote(DataRow objectRow)
        {
            if (objectRow["CREDITNOTEID"] != DBNull.Value) this.CREDITNOTEID = Convert.ToInt32(objectRow["CREDITNOTEID"]);
            if (objectRow["RETURNID"] != DBNull.Value) this.RETURNID = Convert.ToInt32(objectRow["RETURNID"]);
            this.SLNO = objectRow["SLNO"] as System.String;
            if (objectRow["ISSUEDATE"] != DBNull.Value) this.ISSUEDATE = Convert.ToDateTime(objectRow["ISSUEDATE"]);
            this.CUSTOMERNAME = objectRow["CUSTOMERNAME"] as System.String;
            this.ADDRESS = objectRow["ADDRESS"] as System.String;
            this.CREDITRETURNPURPOSE = objectRow["CREDITRETURNPURPOSE"] as System.String;
        }
    }
}