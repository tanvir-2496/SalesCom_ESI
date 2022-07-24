using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class PromotionCycles
    {
        [DataMember] public System.Int32 PROMOTIONCYCLEID { get; set; }
        [DataMember] public System.Int32 PRODUCTPRICECODEID { get; set; }
        [DataMember] public System.String PRODUCTPRICECODE { get; set; }
        [DataMember] public System.Int32 PROMOTIONID { get; set; }
        [DataMember] public System.String PROMOTIONNAME { get; set; }
        [DataMember] public System.String PROMOTIONCYCLENAME { get; set; }
        [DataMember] public System.Int32 CHANNELID { get; set; }
        [DataMember] public System.DateTime STARTDATE { get; set; }
        [DataMember] public System.DateTime ENDDATE { get; set; }
        [DataMember] public System.String REMARKS { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.String CHANNELROOTPATH { get; set; }
        [DataMember] public System.String CHANNELNAME { get; set; }

        

        public PromotionCycles() { }
        public PromotionCycles(DataRow objectRow)
        {
            try
            {

                if (objectRow["PROMOTIONCYCLEID"] != DBNull.Value) this.PROMOTIONCYCLEID = Convert.ToInt32(objectRow["PROMOTIONCYCLEID"]);

                try
                {
                    if (objectRow["PRODUCTPRICECODEID"] != DBNull.Value) this.PRODUCTPRICECODEID = Convert.ToInt32(objectRow["PRODUCTPRICECODEID"]);
                }
                catch { }

                if (objectRow["PROMOTIONID"] != DBNull.Value) this.PROMOTIONID = Convert.ToInt32(objectRow["PROMOTIONID"]);
                this.PROMOTIONNAME = objectRow["PROMOTIONNAME"] as System.String;
                this.PROMOTIONCYCLENAME = objectRow["PROMOTIONCYCLENAME"] as System.String;
                if (objectRow["CHANNELID"] != DBNull.Value)
                    this.CHANNELID = Convert.ToInt32(objectRow["CHANNELID"]);
                if (objectRow["STARTDATE"] != DBNull.Value)
                    this.STARTDATE = Convert.ToDateTime(objectRow["STARTDATE"]);
                if (objectRow["ENDDATE"] != DBNull.Value)
                    this.ENDDATE = Convert.ToDateTime(objectRow["ENDDATE"]);
                this.REMARKS = objectRow["REMARKS"] as System.String;
                this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;

                this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
                try
                {
                    this.PRODUCTPRICECODE = objectRow["PRODUCTPRICECODE"] as System.String;
                }
                catch { }


                if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
                this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
                if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
                this.CHANNELROOTPATH = objectRow["ROOTPATH"] as System.String;
                this.CHANNELNAME = objectRow["CHANNELNAME"] as System.String;
            }
            catch (Exception ex)
            { 
            
            
            
            
            }
        }
    }
}