using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class PayableReceivableExcel
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
        public string REMARKS { get; set; }

        public PayableReceivableExcel()
        { }

        public PayableReceivableExcel(DataRow row,bool LoadExcel)
        {
            if (LoadExcel)
            {
                if (row["Distributor Code"] != DBNull.Value)
                    DISTRIBUTORCODE = row["Distributor Code"].ToString();

                if (row["Distributor Name"] != DBNull.Value)
                    DISTRIBUTORNAME = row["Distributor Name"].ToString();

                if (row["Amount"] != DBNull.Value)
                    AMOUNT = decimal.Parse(row["Amount"].ToString());

                if (row["Remarks"] != DBNull.Value)
                    REMARKS = row["Remarks"].ToString();
            }
        }

        public PayableReceivableExcel(DataRow row)
        {
            
            try
            {
                if (row["DISTRIBUTORID"] != DBNull.Value)
                    DISTRIBUTORID = int.Parse(row["DISTRIBUTORID"].ToString());
            }
            catch (Exception ex)
            {

            }

            try
            {
                if (row["DISTRIBUTORCODE"] != DBNull.Value)
                    DISTRIBUTORCODE = row["DISTRIBUTORCODE"].ToString();
            }
            catch (Exception ex)
            {

            }

            try
            {
                if (row["DISTRIBUTORNAME"] != DBNull.Value)
                    DISTRIBUTORNAME = row["DISTRIBUTORNAME"].ToString();
            }
            catch (Exception ex)
            {

            }

            try
            {
                if (row["AMOUNT"] != DBNull.Value)
                    AMOUNT = decimal.Parse(row["AMOUNT"].ToString());
            }
            catch (Exception ex)
            {

            }

            try
            {
                if (row["REMARKS"] != DBNull.Value)
                    REMARKS = row["REMARKS"].ToString();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
