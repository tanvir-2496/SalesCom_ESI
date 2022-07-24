using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Return
    {
        [DataMember] public System.Int32 RETURNID { get; set; }
        [DataMember] public System.Int32 RFRAISERID { get; set; }
        [DataMember] public System.DateTime RETURNDATE { get; set; }
        [DataMember] public System.String REMARKS { get; set; }
        [DataMember] public System.DateTime STARTRFDATE { get; set; }
        [DataMember] public System.DateTime ENDRFDATE { get; set; }
        [DataMember] public System.String RAISERNAME { get; set; } 
      
            [DataMember] public System.Int32 REASONID { get; set; }
            [DataMember] public System.String RETURNNO { get; set; }
            [DataMember] public System.String CUSTOMERNAME { get; set; }
            [DataMember] public System.String INVOICESTATUS { get; set; }
            [DataMember] public System.Int32 CENTERID { get; set; }
            [DataMember] public System.String CREDITRETURNPURPOSE { get; set; }
            [DataMember] public System.Int32 CREDITNOTESTATUS { get; set; }
            [DataMember] public System.String CREATEBYUSER { get; set; }
            [DataMember] public System.DateTime CREATEDATE { get; set; }
            [DataMember] public System.String LASTUPDATEBY { get; set; }
            [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
            
        public Return() { }
        public Return(DataRow objectRow)
        {
            if (objectRow["RETURNID"] != DBNull.Value) this.RETURNID = Convert.ToInt32(objectRow["RETURNID"]);
            if (objectRow["RFRAISERID"] != DBNull.Value) this.RFRAISERID = Convert.ToInt32(objectRow["RFRAISERID"]);
            if (objectRow["RETURNID"] != DBNull.Value) this.RETURNDATE =Convert.ToDateTime(objectRow["RETURNDATE"]) ;
            this.REMARKS = objectRow["REMARKS"] as System.String;
            this.RAISERNAME = objectRow["RAISERNAME"] as System.String;
         
            if (objectRow["REASONID"] != DBNull.Value) this.REASONID = Convert.ToInt32(objectRow["REASONID"]);
            try
            {
                this.RETURNNO = objectRow["RETURNNO"] as string;
            }
            catch { }
            try
            {
                this.CUSTOMERNAME = objectRow["CUSTOMERNAME"] as string;
            }
            catch { }
            try
            {
                this.INVOICESTATUS = objectRow["INVOICESTATUS"] as System.String;
            }
            catch { }
            this.CREDITRETURNPURPOSE = objectRow["CREDITRETURNPURPOSE"] as System.String;
            if (objectRow["CREDITNOTESTATUS"] != DBNull.Value) this.CREDITNOTESTATUS = Convert.ToInt32(objectRow["CREDITNOTESTATUS"]);

            if (this.CREDITNOTESTATUS > 0)
                this.CREDITNOTESTATUS = 1;
            
            
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);

        }
    }
}