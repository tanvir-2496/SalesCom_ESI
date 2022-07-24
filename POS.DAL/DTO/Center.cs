using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Center
    {
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.String CENTERCODE { get; set; }
        [DataMember] public System.String CENTERNAME { get; set; }
        [DataMember] public System.Int32 CENTERTYPEID { get; set; }
        [DataMember] public System.Int32 CENTERSUBTYPEID { get; set; }
        [DataMember] public System.String RFRAISERYN { get; set; }
        [DataMember] public System.Int32 RFRAISERID { get; set; }
        [DataMember] public System.String ENABLEDYN { get; set; }
        [DataMember] public System.String ADDRESSLINE1 { get; set; }
        [DataMember] public System.String ADDRESSLINE2 { get; set; }
        [DataMember] public System.String PHONE { get; set; }
        [DataMember] public System.String MAINTAININVENTORYYN { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.String CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.String LASTUPDATEDATE { get; set; }
        [DataMember] public System.Int32 LOCATIONID { get; set; }
        [DataMember] public System.Int32 STOREID { get; set; }
        [DataMember] public System.String LOCATIONROOTPATH { get; set; }
        [DataMember] public System.String LOCATIONNAME { get; set; }
        [DataMember] public System.String CENTERTYPENAME { get; set; }
        [DataMember] public System.String CENTERSUBTYPENAME { get; set; }
        [DataMember] public System.String CHANNEL_NAME { get; set; }

        [DataMember] public System.Int32 WAREHOUSEID { get; set; }
        [DataMember] public System.String WAREHOUSENAME { get; set; }

        [DataMember] public System.String AUTOMRNO{ get; set; }
        [DataMember] public System.String AUTOPRINT{ get; set; }
        [DataMember] public System.Int32 DEALERID{ get; set; }      
        [DataMember] public System.String  BANK_CODE{ get; set; }
        [DataMember] public System.Int32 THANAID { get; set; }
        [DataMember] public System.String MRNO_PREFIX { get; set; }

        [DataMember] public System.Int32 BUFFERSTOREID { get; set; }
        [DataMember]public System.Boolean ISASSIGNEDTOBANK { get; set; }


        public Center() { }
        public Center(DataRow objectRow)
        {
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            this.CENTERCODE = objectRow["CENTERCODE"] as System.String;
            this.CENTERNAME = objectRow["CENTERNAME"] as System.String;
            if (objectRow["CENTERTYPEID"] != DBNull.Value)
            this.CENTERTYPEID =Convert.ToInt32(objectRow["CENTERTYPEID"]);
            if (objectRow["CENTERSUBTYPEID"] != DBNull.Value)
            this.CENTERSUBTYPEID =Convert.ToInt32(objectRow["CENTERSUBTYPEID"] );
            this.RFRAISERYN = objectRow["RFRAISERYN"] as System.String;
            if (objectRow["RFRAISERID"] != DBNull.Value) this.RFRAISERID = Convert.ToInt32(objectRow["RFRAISERID"]);
            this.ENABLEDYN = objectRow["ENABLEDYN"] as System.String;
            this.ADDRESSLINE1 = objectRow["ADDRESSLINE1"] as System.String;
            this.ADDRESSLINE2 = objectRow["ADDRESSLINE2"] as System.String;
            this.PHONE = objectRow["PHONE"] as System.String;
            this.MAINTAININVENTORYYN = objectRow["MAINTAININVENTORYYN"] as System.String;
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            this.CREATEDATE = objectRow["CREATEDATE"] as System.String;
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            this.LASTUPDATEDATE = objectRow["LASTUPDATEDATE"] as System.String;
            if (objectRow["LOCATIONID"] != DBNull.Value) this.LOCATIONID = Convert.ToInt32(objectRow["LOCATIONID"]);
            if (objectRow["STOREID"] != DBNull.Value) this.STOREID = Convert.ToInt32(objectRow["STOREID"]);
            this.LOCATIONROOTPATH = objectRow["LOCATIONROOTPATH"] as System.String;
            this.LOCATIONNAME = objectRow["LOCATIONNAME"] as System.String;
            this.CENTERTYPENAME = objectRow["CENTERTYPENAME"] as System.String;
            this.CENTERSUBTYPENAME = objectRow["CENTERSUBTYPENAME"] as System.String;
            this.CHANNEL_NAME = objectRow["CHANNEL_NAME"] as System.String;
            this.WAREHOUSENAME = objectRow["WAREHOUSENAME"] as System.String;
            if (objectRow["WAREHOUSEID"] != DBNull.Value) this.WAREHOUSEID = Convert.ToInt32(objectRow["WAREHOUSEID"]);

            try
            {
                if (objectRow["BUFFERSTOREID"] != DBNull.Value) this.BUFFERSTOREID = Convert.ToInt32(objectRow["BUFFERSTOREID"]);
            }
            catch { }

            this.ISASSIGNEDTOBANK = objectRow["ISASSIGNEDTOBANK"] != DBNull.Value ? Convert.ToBoolean(objectRow["ISASSIGNEDTOBANK"]) : this.ISASSIGNEDTOBANK;

            this.BANK_CODE = objectRow["BANK_CODE"] as System.String;
            this.THANAID = objectRow["THANA"] != DBNull.Value ? Convert.ToInt32(objectRow["THANA"]) : 0;
            this.DEALERID = objectRow["DEALER"] != DBNull.Value ? Convert.ToInt32(objectRow["DEALER"]) : 0;

        }

        public Center(DataRow objectRow,int i)
        {
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            this.AUTOMRNO = objectRow["AUTOMRNO"] as System.String;
            this.AUTOPRINT = objectRow["AUTOPRINT"] as System.String;
            this.BANK_CODE = objectRow["BANK_CODE"] as System.String;
            this.MRNO_PREFIX = objectRow["MRNO_PREFIX"] as System.String;
        }
    }
}