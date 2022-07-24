using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Runtime.Serialization;
namespace POS.DAL
{
    [DataContract]
    public class DistributorCreditLimit
    {
        [DataMember]
        public int DISTRIBUTORID { get; set; }

        [DataMember]
        public string DISTRIBUTORCODE { get; set; }

        [DataMember]
        public string DISTRIBUTORNAME { get; set; }

        [DataMember]
        public decimal AMOUNT { get; set; }

        [DataMember]
        public DateTime EXPIREYDATE { get; set; }     
        
        [DataMember]
        public Decimal CREDITLIMIT { get; set; }

        [DataMember]
        public Decimal NEWCREDITLIMIT { get; set; }

        [DataMember]
        public DateTime NEWEXPIREYDATE { get; set; }

        [DataMember]
        public System.String CREATEBYUSER { get; set; }
        [DataMember]
        public System.DateTime CREATEDATE { get; set; }
        [DataMember]
        public System.String LASTUPDATEBY { get; set; }
        [DataMember]
        public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember]
        public System.String RECORDSTATUS { get; set; }

        [DataMember]
        public System.String NEWRECORDSTATUS { get; set; }

        [DataMember]
        public System.String REMARKS { get; set; }
        [DataMember]
        public System.String UPLOADREMARKS { get; set; }

        [DataMember]
        public System.String APPROVEDBY { get; set; }
        [DataMember]
        public System.DateTime APPROVEDDATE { get; set; }

        public DistributorCreditLimit()
        { }


        public DistributorCreditLimit(DataRow row, bool LoadExcel)
        {
            if (LoadExcel)
            {
                DISTRIBUTORCODE = row["Distributor Code"].ToString();


               // DISTRIBUTORNAME = row["Distributor Name"].ToString();

                AMOUNT = decimal.Parse(row["Credit Limit"].ToString());
                NEWEXPIREYDATE = DateTime.Parse(row["Expiry Date"].ToString());
                REMARKS = row["REMARKS"].ToString();
            }
        }

        public DistributorCreditLimit(DataRow row)
        {

            try
            {
                if (row["DISTRIBUTORID"] != DBNull.Value) DISTRIBUTORID = int.Parse(row["DISTRIBUTORID"].ToString());
            }
            catch (Exception ex)
            {

            }

            try
            {
                if (row["DISTRIBUTORCODE"] != DBNull.Value) DISTRIBUTORCODE = row["DISTRIBUTORCODE"].ToString();
            }
            catch (Exception ex)
            { }


            try
            {
                if (row["DISTRIBUTORNAME"] != DBNull.Value) DISTRIBUTORNAME = row["DISTRIBUTORNAME"].ToString();
            }
            catch (Exception ex)
            { }
            try
            {
                if (row["AMOUNT"] != DBNull.Value) AMOUNT = decimal.Parse(row["AMOUNT"].ToString());
            }
            catch (Exception ex)
            { }

            try
            {
                if (row["EXPIREYDATE"] != DBNull.Value) EXPIREYDATE = DateTime.Parse(row["EXPIREYDATE"].ToString());
            }
            catch
            { }


            try
            {
                if (row["RECORDSTATUS"] != DBNull.Value) RECORDSTATUS = row["RECORDSTATUS"].ToString();
            }
            catch
            { }
            try
            {
                if (row["REMARKS"] != DBNull.Value) REMARKS = row["REMARKS"].ToString();
            }
            catch
            { }

            try
            {
                if (row["UPLOADREMARKS"] != DBNull.Value) UPLOADREMARKS = row["UPLOADREMARKS"].ToString();
            }
            catch
            { }

            try
            {
                if (row["NEWEXPIREYDATE"] != DBNull.Value) NEWEXPIREYDATE = DateTime.Parse(row["NEWEXPIREYDATE"].ToString());
            }
            catch
            { }


            try
            {
                if (row["NEWRECORDSTATUS"] != DBNull.Value) NEWRECORDSTATUS = row["NEWRECORDSTATUS"].ToString();
            }
            catch
            { }

            try
            {
                this.CREATEBYUSER = row["CREATEBYUSER"] as System.String;
            }
            catch
            { }

            try
            {
                this.LASTUPDATEBY = row["LASTUPDATEBY"] as System.String;
            }
            catch { }

            try
            {
                this.APPROVEDBY = row["APPROVEDBY"] as System.String;
            }
            catch { }

            try
            {
                if (row["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(row["CREATEDATE"]);
            }
            catch { }

            try
            {

                if (row["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(row["LASTUPDATEDATE"]);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
