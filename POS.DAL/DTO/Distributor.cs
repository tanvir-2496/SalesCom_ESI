using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Distributor
    {
        [DataMember] public System.Int32 DISTRIBUTORID { get; set; }
        [DataMember] public System.String DISTRIBUTORCODE { get; set; }
        [DataMember] public System.String DISTRIBUTORNAME { get; set; }
        [DataMember] public System.Int32 CHANNELID { get; set; }
        [DataMember] public System.Int32 RFRAISERID { get; set; }
        [DataMember] public System.Int32 CUSTOMERID { get; set; }
        [DataMember] public System.String CUSTOMERNAME { get; set; }
        
        [DataMember] public System.String ERPACCOUNTNO { get; set; }
        [DataMember] public System.String ERPPROJCODE { get; set; }
        [DataMember] public System.String OFFICEADDRESS { get; set; }
        [DataMember] public System.Int32 TERRITORY { get; set; }
        [DataMember] public System.String FINANCEDEALERCODE { get; set; }

        [DataMember] public System.String TERMINATEIONSTATUS { get; set; }

        
        public Distributor() { }
        public Distributor(DataRow objectRow)
        {
            if (objectRow["DISTRIBUTORID"] != DBNull.Value) this.DISTRIBUTORID = Convert.ToInt32(objectRow["DISTRIBUTORID"]);


            try
            {
                this.TERMINATEIONSTATUS = objectRow["TERMINATEIONSTATUS"] as System.String;
            }
            catch { }

            try
            {
                this.DISTRIBUTORCODE = objectRow["DISTRIBUTORCODE"] as System.String;
            }
            catch { }


            this.DISTRIBUTORNAME = objectRow["DISTRIBUTORNAME"] as System.String;
            try
            {
                if (objectRow["CHANNELID"] != DBNull.Value) this.CHANNELID = Convert.ToInt32(objectRow["CHANNELID"]);
            }
            catch
            { }

            try
            {
                if (objectRow["RFRAISERID"] != DBNull.Value) this.RFRAISERID = Convert.ToInt32(objectRow["RFRAISERID"]);
            }
            catch
            {

            }

            try
            {
                if (objectRow["CUSTOMERID"] != DBNull.Value) this.CUSTOMERID = Convert.ToInt32(objectRow["CUSTOMERID"]);

            }
            catch
            { }



            try
            {
                this.CUSTOMERNAME = objectRow["CUSTOMERNAME"] as System.String;
            }
            catch
            { }

            try
            {
                this.FINANCEDEALERCODE = objectRow["FINANCEDEALERCODE"] as System.String;
                this.ERPACCOUNTNO = objectRow["ERPACCOUNTNO"] as System.String;
                this.ERPPROJCODE = objectRow["ERPPROJCODE"] as System.String;
                if (objectRow["TERRITORY"] != DBNull.Value) this.TERRITORY = Convert.ToInt32(objectRow["TERRITORY"]);
                this.OFFICEADDRESS = objectRow["OFFICEADDRESS"] as System.String;
                this.FINANCEDEALERCODE = objectRow["FINANCEDEALERCODE"] as System.String;
            }
            catch (Exception ex)
            { }
        }
    }
}