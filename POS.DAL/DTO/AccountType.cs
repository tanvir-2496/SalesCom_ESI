using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class AccountType
    {
        [DataMember]
        public int ACCOUNTTYPEID{get;set;}
        
        [DataMember]
        public string ACCOUNTTYPENAME{get;set;}
  
        [DataMember]
        public string DESCRIPTION{get;set;}
  
        [DataMember]
        public string ENABLED{get;set;}
  
        [DataMember]
        public string REFACCOUNT{get;set;}

        


            
        [DataMember]
        public string DEFAULTTYPE { get; set; }



        [DataMember]
        public string ISRF { get; set; }



        [DataMember]
        public string ACCOUNTTYPECODE { get; set; }

        [DataMember]
        public char ISMAINCHANNEL { get; set; }

        [DataMember]
        public int ALTERNATECHANNELID { get; set; }

        public AccountType()
        { }

        public AccountType(DataRow row)
        {
            if (row["ACCOUNTTYPEID"] != DBNull.Value) ACCOUNTTYPEID = int.Parse(row["ACCOUNTTYPEID"].ToString());

            if (row["ACCOUNTTYPENAME"] != DBNull.Value) ACCOUNTTYPENAME = row["ACCOUNTTYPENAME"].ToString();

            if (row["DESCRIPTION"] != DBNull.Value) DESCRIPTION = row["DESCRIPTION"].ToString();

            if (row["ENABLED"] != DBNull.Value) ENABLED = row["ENABLED"].ToString();

            if (row["REFACCOUNT"] != DBNull.Value) REFACCOUNT = row["REFACCOUNT"].ToString();

            try
            {
                if (row["DEFAULTTYPE"] != DBNull.Value) DEFAULTTYPE = row["DEFAULTTYPE"].ToString();

            }
            catch (Exception ex)
            { 
            
            }


            try
            {
                if (row["ISRF"] != DBNull.Value) ISRF = row["ISRF"].ToString();

            }
            catch (Exception ex)
            {

            }


            if (row["ACCOUNTTYPECODE"] != DBNull.Value) ACCOUNTTYPECODE = row["ACCOUNTTYPECODE"].ToString();

            try
            {
                if (row["ISMAINCHANNEL"] != DBNull.Value) ISMAINCHANNEL = char.Parse(row["ISMAINCHANNEL"].ToString());

            }
            catch (Exception ex)
            {

            }

            try
            {
                if (row["ALTERNATECHANNELID"] != DBNull.Value) ALTERNATECHANNELID = int.Parse(row["ALTERNATECHANNELID"].ToString());

            }
            catch (Exception ex)
            {

            }
        }
    }
}
