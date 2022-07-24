using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class CollectionType
    {
        [DataMember] public System.Int32 COLLECTIONTYPEID { get; set; }
        [DataMember] public System.String COLLECTIONTYPENAME { get; set; }
        [DataMember] public System.String HAS_INVOICEID { get; set; }
        [DataMember] public System.String HAS_CUSTOMERID { get; set; }
        [DataMember] public System.String HAS_CONTRNO { get; set; }
        [DataMember] public System.String IS_INVOICEID_MANDETORY { get; set; }
        [DataMember] public System.String IS_CONTRNO_MANDETORY { get; set; }
        [DataMember] public System.String IS_CUSTOMERID_MANDETORY { get; set; }
        [DataMember] public System.String IS_RF_COLLECTION { get; set; }
        public CollectionType() { }
        public CollectionType(DataRow objectRow)
        {
            if (objectRow["COLLECTIONTYPEID"] != DBNull.Value) this.COLLECTIONTYPEID = Convert.ToInt32(objectRow["COLLECTIONTYPEID"]);
            this.COLLECTIONTYPENAME = objectRow["COLLECTIONTYPENAME"] as System.String;
            this.HAS_INVOICEID = objectRow["HAS_INVOICEID"] as System.String;
            this.HAS_CUSTOMERID = objectRow["HAS_CUSTOMERID"] as System.String;
            this.HAS_CONTRNO = objectRow["HAS_CONTRNO"] as System.String;
            this.IS_INVOICEID_MANDETORY = objectRow["IS_INVOICEID_MANDETORY"] as System.String;
            this.IS_CONTRNO_MANDETORY = objectRow["IS_CONTRNO_MANDETORY"] as System.String;
            this.IS_CUSTOMERID_MANDETORY = objectRow["IS_CUSTOMERID_MANDETORY"] as System.String;
            this.IS_RF_COLLECTION = objectRow["IS_RF_COLLECTION"] as System.String;
        }
    }
}