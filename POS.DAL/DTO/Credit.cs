using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Credit
    {
        [DataMember] public System.Int32 RFID { get; set; }
        [DataMember] public System.Int32 CREDITID { get; set; }
        [DataMember] public System.DateTime CREDITDATE { get; set; }
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.Decimal CREDITAMOUNT { get; set; }
        [DataMember] public System.String INVOICENO { get; set; }
        [DataMember] public System.Int32 RFRAISERID { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.String CREDITNO { get; set; }
        [DataMember] public System.String ACTIVEYN { get; set; }
        [DataMember] public System.String CENTERCODE { get; set; }
        [DataMember] public System.String RFCODE { get; set; }
        [DataMember] public System.DateTime STARTRFDATE { get; set; }
        [DataMember] public System.DateTime ENDRFDATE { get; set; }
        [DataMember] public System.Int32 INVOICEID { get; set; }
        [DataMember] public System.String COLLECTIONSTATUS { get; set; }

        [DataMember] public System.String REMARKS { get; set; }

        [DataMember] public System.String COLLECTIONSATUS { get; set; }
        [DataMember] public System.Int32 COLLECTEDAMOUNT { get; set; }
        [DataMember] public System.String RAISERNAME { get; set; }
        [DataMember] public System.String INSTRUMENTDETAIL { get; set; }
        //[DataMember] public System.String ISCOLLECTIONCOMPLETED { get; set; }
        public Credit() { }
        public Credit(DataRow objectRow)
        {
            if (objectRow["CREDITID"] != DBNull.Value) this.CREDITID = Convert.ToInt32(objectRow["CREDITID"]);
            if (objectRow["CREDITDATE"] != DBNull.Value) this.CREDITDATE = Convert.ToDateTime(objectRow["CREDITDATE"]);
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            if (objectRow["CREDITAMOUNT"] != DBNull.Value) this.CREDITAMOUNT = Convert.ToDecimal(objectRow["CREDITAMOUNT"]);
            this.INVOICENO = objectRow["INVOICENO"] as System.String;
            if (objectRow["RFRAISERID"] != DBNull.Value) this.RFRAISERID = Convert.ToInt32(objectRow["RFRAISERID"]);
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            this.CREDITNO = objectRow["CREDITNO"] as System.String;
            this.ACTIVEYN = objectRow["ACTIVEYN"] as System.String;

            this.RFCODE = objectRow["RFCODE"] as System.String;
            this.REMARKS = objectRow["REMARKS"] as System.String;
            //this.COLLECTIONSATUS = objectRow["COLLECTIONSATUS"] as System.String;
            this.RAISERNAME = objectRow["RAISERNAME"] as System.String;
            this.INSTRUMENTDETAIL = objectRow["INSTRUMENTDETAIL"] as System.String;
            //this.ISCOLLECTIONCOMPLETED = objectRow["ISCOLLECTIONCOMPLETED"] as System.String;

            if (objectRow["INVOICEID"] != DBNull.Value) this.INVOICEID = Convert.ToInt32(objectRow["INVOICEID"]);
            if (objectRow["COLLECTEDAMOUNT"] != DBNull.Value) this.COLLECTEDAMOUNT = Convert.ToInt32(objectRow["COLLECTEDAMOUNT"]);
            try
            {

                if (this.CREDITAMOUNT == COLLECTEDAMOUNT)
                {
                    this.COLLECTIONSTATUS = "Y";

                }
                else if (COLLECTEDAMOUNT == 0)
                {
                    this.COLLECTIONSTATUS = "N";
                }
                else
                {
                    this.COLLECTIONSTATUS = "P";
                }
            }
            catch { }

        }
    }
}