using System; using System.Runtime.Serialization; 
using System.Data;
namespace POS.DAL
{

[DataContract] public class TellerOpeningAndClosing{
[DataMember] public System.Int32 TELLEROPENCLOSEID{get ; set ;}
[DataMember] public System.Int32 TELLERID{get ; set ;}
[DataMember] public System.String TELLERCODE { get; set; }
[DataMember] public System.DateTime WORKINGDATE{get ; set ;}
[DataMember] public System.DateTime OPENINGTIME{get ; set ;}
[DataMember] public System.DateTime CLOSINGTIME{get ; set ;}
[DataMember] public System.String OPENEDBYUSER{get ; set ;}
[DataMember] public System.String CLOSEDBYUSER{get ; set ;}

public TellerOpeningAndClosing(){}
public TellerOpeningAndClosing(DataRow objectRow)
{
 if (objectRow["TELLEROPENCLOSEID"] !=DBNull.Value) this.TELLEROPENCLOSEID = Convert.ToInt32(objectRow["TELLEROPENCLOSEID"]);
 if (objectRow["TELLERID"] !=DBNull.Value) this.TELLERID = Convert.ToInt32(objectRow["TELLERID"]);
 if (objectRow["WORKINGDATE"] !=DBNull.Value)this.WORKINGDATE = Convert.ToDateTime(objectRow["WORKINGDATE"]);
 if (objectRow["OPENINGTIME"] !=DBNull.Value)this.OPENINGTIME = Convert.ToDateTime(objectRow["OPENINGTIME"]);
 if (objectRow["CLOSINGTIME"] !=DBNull.Value)this.CLOSINGTIME = Convert.ToDateTime(objectRow["CLOSINGTIME"]);
this.OPENEDBYUSER = objectRow["OPENEDBYUSER"] as System.String;
this.CLOSEDBYUSER = objectRow["CLOSEDBYUSER"] as System.String;
this.TELLERCODE = objectRow["TELLERCODE"] as System.String;
}
}}
