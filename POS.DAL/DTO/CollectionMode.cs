using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{
    [DataContract] public class CollectionMode
    {
        [DataMember] public System.Int32 COLLECTIONMODEID { get; set; }
        [DataMember] public System.String COLLECTIONMODENAME { get; set; }
        [DataMember] public System.String COLLECTIOMMODECODE { get; set; }
        [DataMember] public System.String ISPODDMANDETORY { get; set; }
        [DataMember] public System.String ISBANKIDMANDETORY { get; set; }
        [DataMember] public System.String ISBRANCHNAMEMANDETORY { get; set; }
        [DataMember] public System.String ISCHQNOMANDETORY { get; set; }
        [DataMember] public System.String ISCHKDATEMANDETORY { get; set; }
        [DataMember] public System.String ISBANKACCOUNTMANDETORY { get; set; }
        [DataMember] public System.String ISCARDNOMANDETORY { get; set; }
        [DataMember] public System.String ISEXPIRYDATEMANDETORY { get; set; }
        [DataMember] public System.String HASPODDATTR { get; set; }
        [DataMember] public System.String HASBANKIDATTR { get; set; }
        [DataMember] public System.String HASBRANCHNAMEATTR { get; set; }
        [DataMember] public System.String HASCHQNOATTR { get; set; }
        [DataMember] public System.String HASCHKDATEATTR { get; set; }
        [DataMember] public System.String HASBANKACCOUNTATTR { get; set; }
        [DataMember] public System.String HASCARDNOATTR { get; set; }
        [DataMember] public System.String HASEXPIRYDATEATTR { get; set; }
        [DataMember] public System.String ISPAYMENTINCASH { get; set; }
        [DataMember] public System.String ISDDMANDETORY { get; set; }
        [DataMember] public System.String HASDDATTR { get; set; }
        [DataMember] public System.String HASTRANSFERNO { get; set; }
        [DataMember] public System.String ISTRANSFERMANDATORY { get; set; }
        [DataMember] public System.String HASFIELD1 { get; set; }
        [DataMember] public System.String HASFIELD2 { get; set; }
        [DataMember] public System.String HASFIELD3 { get; set; }
        [DataMember] public System.String HASFIELD4 { get; set; }
        [DataMember] public System.String HASFIELD5 { get; set; }
        [DataMember] public System.String ISFIELD1MANDATORY { get; set; }
        [DataMember] public System.String ISFIELD2MANDATORY { get; set; }
        [DataMember] public System.String ISFIELD3MANDATORY { get; set; }
        [DataMember] public System.String ISFIELD4MANDATORY { get; set; }
        [DataMember] public System.String ISFIELD5MANDATORY { get; set; }
        [DataMember] public System.String HASBLBANKACCOUNT { get; set; }
        [DataMember] public System.String ISBLBANKACCOUNTMANDATORY { get; set; }
        [DataMember] public System.String ISDISBURSABLE { get; set; }



        public CollectionMode() { }
        public CollectionMode(DataRow objectRow)
        {
            if (objectRow["COLLECTIONMODEID"] != DBNull.Value) this.COLLECTIONMODEID = Convert.ToInt32(objectRow["COLLECTIONMODEID"]);
            this.COLLECTIOMMODECODE = objectRow["COLLECTIOMMODECODE"] as System.String;
            this.COLLECTIONMODENAME = objectRow["COLLECTIONMODENAME"] as System.String;
            this.ISPODDMANDETORY = objectRow["ISPODDMANDETORY"] as System.String;
            this.ISBANKIDMANDETORY = objectRow["ISBANKIDMANDETORY"] as System.String;
            this.ISBRANCHNAMEMANDETORY = objectRow["ISBRANCHNAMEMANDETORY"] as System.String;
            this.ISCHQNOMANDETORY = objectRow["ISCHQNOMANDETORY"] as System.String;
            this.ISCHKDATEMANDETORY = objectRow["ISCHKDATEMANDETORY"] as System.String;
            this.ISCARDNOMANDETORY = objectRow["ISCARDNOMANDETORY"] as System.String;
            this.ISEXPIRYDATEMANDETORY = objectRow["ISEXPIRYDATEMANDETORY"] as System.String;
            this.HASPODDATTR = objectRow["HASPODDATTR"] as System.String;
            this.HASBANKIDATTR = objectRow["HASBANKIDATTR"] as System.String;
            this.HASBRANCHNAMEATTR = objectRow["HASBRANCHNAMEATTR"] as System.String;
            this.HASCHQNOATTR = objectRow["HASCHQNOATTR"] as System.String;
            this.HASCHKDATEATTR = objectRow["HASCHKDATEATTR"] as System.String;
            this.HASCARDNOATTR = objectRow["HASCARDNOATTR"] as System.String;
            this.HASEXPIRYDATEATTR = objectRow["HASEXPIRYDATEATTR"] as System.String;
            this.ISPAYMENTINCASH = objectRow["ISPAYMENTINCASH"] as System.String;
            this.ISBANKACCOUNTMANDETORY = objectRow["ISBANKACCOUNTMANDETORY"] as System.String;
            this.HASBANKACCOUNTATTR = objectRow["HASBANKACCOUNTATTR"] as System.String;
            this.ISDDMANDETORY = objectRow["ISDDMANDETORY"] as System.String;
            this.HASDDATTR = objectRow["HASDDATTR"] as System.String;
            this.HASTRANSFERNO = objectRow["HASTRANSFERNO"] as System.String;
            this.ISTRANSFERMANDATORY = objectRow["ISTRANSFERMANDATORY"] as System.String;
            this.HASFIELD1 = objectRow["HASFIELD1"] as System.String;
            this.HASFIELD2 = objectRow["HASFIELD2"] as System.String;
            this.HASFIELD3 = objectRow["HASFIELD3"] as System.String;
            this.HASFIELD4 = objectRow["HASFIELD4"] as System.String;
            this.HASFIELD5 = objectRow["HASFIELD5"] as System.String;
            this.ISFIELD1MANDATORY = objectRow["ISFIELD1MANDATORY"] as System.String;
            this.ISFIELD2MANDATORY = objectRow["ISFIELD2MANDATORY"] as System.String;
            this.ISFIELD3MANDATORY = objectRow["ISFIELD3MANDATORY"] as System.String;
            this.ISFIELD4MANDATORY = objectRow["ISFIELD4MANDATORY"] as System.String;
            this.ISFIELD5MANDATORY = objectRow["ISFIELD5MANDATORY"] as System.String;
            this.HASBLBANKACCOUNT = objectRow["HASBLBANKACCOUNT"] as System.String;
            this.ISBLBANKACCOUNTMANDATORY = objectRow["ISBLBANKACCOUNTMANDATORY"] as System.String;

            this.ISDISBURSABLE = objectRow["ISDISBURSABLE"] as System.String;
        }
    }
}