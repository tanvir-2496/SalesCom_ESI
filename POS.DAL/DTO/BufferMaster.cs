using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class BufferMaster
    {
        [DataMember] public System.Int32 SOURCEID { get; set; }
        [DataMember] public System.String SOURCETYPE { get; set; }
        [DataMember] public System.Int32 DESTINATIONID { get; set; }
        [DataMember] public System.String DESTINATIONTYPE { get; set; }
        [DataMember] public System.Int32 TRANSACTIONREFTYPEID { get; set; }
        [DataMember] public System.String TRANSACTIONREF { get; set; }
        [DataMember] public System.String DESTINATIONRECEIVEYN { get; set; }
        [DataMember] public System.Int32 BUFFERID { get; set; }
        [DataMember] public System.DateTime DESTRECVDATE { get; set; }
        [DataMember] public System.String BUFFERCODE { get; set; }
        [DataMember]
        public System.String TRANSFERCODE { get; set; }
        [DataMember]
        public System.DateTime TRANSFERDATE { get; set; }

        public BufferMaster() { }
        public BufferMaster(DataRow objectRow)
        {
            if (objectRow["SOURCEID"] != DBNull.Value) this.SOURCEID = Convert.ToInt32(objectRow["SOURCEID"]);
            this.SOURCETYPE = objectRow["SOURCETYPE"] as System.String;
            if (objectRow["DESTINATIONID"] != DBNull.Value) this.DESTINATIONID = Convert.ToInt32(objectRow["DESTINATIONID"]);
            this.DESTINATIONTYPE = objectRow["DESTINATIONTYPE"] as System.String;
            if (objectRow["TRANSACTIONREFTYPEID"] != DBNull.Value) this.TRANSACTIONREFTYPEID = Convert.ToInt32(objectRow["TRANSACTIONREFTYPEID"]);
            this.TRANSACTIONREF = objectRow["TRANSACTIONREF"] as System.String;
            this.DESTINATIONRECEIVEYN = objectRow["DESTINATIONRECEIVEYN"] as System.String;
            if (objectRow["BUFFERID"] != DBNull.Value) this.BUFFERID = Convert.ToInt32(objectRow["BUFFERID"]);
            if (objectRow["DESTRECVDATE"] != DBNull.Value) this.DESTRECVDATE = Convert.ToDateTime(objectRow["DESTRECVDATE"]);
            this.BUFFERCODE = objectRow["BUFFERCODE"] as System.String;
            //



            try
            {
                this.TRANSFERCODE = objectRow["TRANSFERCODE"] as System.String;
                if (objectRow["TRANSFERDATE"] != DBNull.Value) this.TRANSFERDATE = Convert.ToDateTime(objectRow["TRANSFERDATE"]);
            }
            catch
            { }



        }
    }
}