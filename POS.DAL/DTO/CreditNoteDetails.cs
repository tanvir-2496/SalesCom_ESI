using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class CreditNoteDetails
    {
        [DataMember] public System.Int32 CREDITNOTEID { get; set; }
        [DataMember] public System.String CHALLANNO { get; set; }
        [DataMember] public System.DateTime CHALLANISSUEDATE { get; set; }
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.Int32 QTY { get; set; }
        [DataMember] public System.Decimal ASSVALUE { get; set; }
        [DataMember] public System.Decimal SD { get; set; }
        [DataMember] public System.Decimal VAT { get; set; }
        [DataMember] public System.Int32 RETURNID { get; set; }
        [DataMember] public System.String CUSTOMERNAME { get; set; }
        [DataMember] public System.String ADDRESS { get; set; }
        [DataMember] public System.Decimal PREVIOUSVAT { get; set; }
        [DataMember] public System.String CREDITRETURNPURPOSE { get; set; }
        [DataMember] public System.DateTime ISSUEDATE { get; set; }
        [DataMember] public System.String SLNO { get; set; }
        
        public CreditNoteDetails() { }
        public CreditNoteDetails(DataRow objectRow)
        {
            try
            {
            if (objectRow["CREDITNOTEID"] != DBNull.Value) this.CREDITNOTEID = Convert.ToInt32(objectRow["CREDITNOTEID"]);
            }
            catch{}
            this.CHALLANNO = objectRow["CHALLANNO"] as System.String;
            try
            {
                this.SLNO = objectRow["SLNO"] as System.String;
            }
            catch { }
            try
            {
                if (objectRow["ISSUEDATE"] != DBNull.Value) this.ISSUEDATE = Convert.ToDateTime(objectRow["ISSUEDATE"]);
            }catch{}
            try
            {
                if (objectRow["CHALLANISSUEDATE"] != DBNull.Value) this.CHALLANISSUEDATE = Convert.ToDateTime(objectRow["CHALLANISSUEDATE"]);
            }
            catch { }
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            if (objectRow["QTY"] != DBNull.Value) this.QTY = Convert.ToInt32(objectRow["QTY"]);
            if (objectRow["ASSVALUE"] != DBNull.Value) this.ASSVALUE = Convert.ToDecimal(objectRow["ASSVALUE"]);
            if (objectRow["SD"] != DBNull.Value) this.SD = Convert.ToDecimal(objectRow["SD"]);
            if (objectRow["VAT"] != DBNull.Value) this.VAT = Convert.ToDecimal(objectRow["VAT"]);
            if (objectRow["PREVIOUSVAT"] != DBNull.Value) this.PREVIOUSVAT = Convert.ToDecimal(objectRow["PREVIOUSVAT"]);


            try
            {
                if (objectRow["RETURNID"] != DBNull.Value) this.RETURNID = Convert.ToInt32(objectRow["RETURNID"]);
            }
            catch
            { }

            try
            {
                this.CUSTOMERNAME = objectRow["CUSTOMERNAME"] as System.String;
            }
            catch { }
            try
            {
                this.ADDRESS = objectRow["ADDRESS"] as System.String;
            }
            catch { }

            try
            {
                this.CREDITRETURNPURPOSE = objectRow["CREDITRETURNPURPOSE"] as System.String;
            }
            catch { }
            
            
            
            
        }
    }
}