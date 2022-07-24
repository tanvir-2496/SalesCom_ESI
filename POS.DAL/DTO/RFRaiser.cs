using System; using System.Runtime.Serialization; 
using System.Data;
namespace POS.DAL
{
[DataContract] public class RFRaiser{
[DataMember] public System.Int32 RFRAISERID{get ; set ;}
[DataMember] public System.String RFRAISERCODE{get ; set ;}
[DataMember] public System.Int32 LOCATIONID{get ; set ;}
[DataMember] public System.String LOCATION { get; set; }
[DataMember] public System.Int32 CHANNELID{get ; set ;}
[DataMember] public System.String CHANNEL { get; set; }
[DataMember] public System.String SEGMENTNAME{get ; set ;}

[DataMember] public System.String ADDRESSLINE1 { get; set; }
[DataMember] public System.String ADDRESSLINE2 { get; set; }
    [DataMember] public System.String SEGMENTTYPE{get ; set ;}
    [DataMember] public System.String RAISERTYPE { get; set; }


public RFRaiser(){}
public RFRaiser(DataRow objectRow){
 if (objectRow["RFRAISERID"] !=DBNull.Value) this.RFRAISERID = Convert.ToInt32(objectRow["RFRAISERID"]);
this.RFRAISERCODE = objectRow["RFRAISERCODE"] as System.String;
this.LOCATION = objectRow["LOCATION"] as System.String;
this.CHANNEL = objectRow["CHANNEL"] as System.String;
 if (objectRow["LOCATIONID"] !=DBNull.Value) this.LOCATIONID = Convert.ToInt32(objectRow["LOCATIONID"]);
 //if (objectRow["CHANNELID"] !=DBNull.Value) this.CHANNELID = Convert.ToInt32(objectRow["CHANNELID"]);
this.SEGMENTNAME = objectRow["SEGMENTNAME"] as System.String;
this.SEGMENTTYPE = objectRow["SEGMENTTYPE"] as System.String;
this.ADDRESSLINE1 = objectRow["ADDRESSLINE1"] as System.String;
this.ADDRESSLINE2 = objectRow["ADDRESSLINE2"] as System.String;
    switch(this.SEGMENTTYPE.Trim())
    {
        case "100": this.RAISERTYPE = "Distributor";
            break;
        case "200": this.RAISERTYPE = "Internal";
            break;
        default:
            this.RAISERTYPE = "Shop";
            break;
    }
    
}
}}