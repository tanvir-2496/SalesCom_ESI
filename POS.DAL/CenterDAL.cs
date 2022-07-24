using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;


namespace POS.DAL
{
    public class DAL_CENTER
    {
        public static List<Center> GetItemList(int CENTERID, int CENTERTYPEID, int CENTERSUBTYPEID, string CENTERNAME, int ACCOUNTID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "GET_CENTER");
            procedure.AddInputParameter("p_CENTERID", CENTERID, OracleType.Number);
            procedure.AddInputParameter("p_CENTERTYPEID", CENTERTYPEID, OracleType.Number);
            procedure.AddInputParameter("p_CENTERSUBTYPEID", CENTERSUBTYPEID, OracleType.Number);
            procedure.AddInputParameter("p_CENTERNAME", CENTERNAME, OracleType.VarChar);
            procedure.AddInputParameter("p_ACCOUNTID", ACCOUNTID, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<Center> results = new List<Center>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new Center(dr));
                }

                return results;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public static Center GetCenterDetail(int CENTERID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "GET_CENTERDETAILINFO");
            procedure.AddInputParameter("p_CENTERID", CENTERID, OracleType.Number);
           
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                Center results = new Center(dt.Rows[0], 0);
                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static int SaveItem(Center objenter, string strMode)
        {
            return SaveItem(objenter, strMode, null);
           
        }

        public static int SaveItem(Center objenter, string strMode, DBTransaction transaction)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "SAVE_CENTER");
            procedure.AddInputParameter("p_CENTERID", objenter.CENTERID, OracleType.Number);
            procedure.AddInputParameter("p_CENTERCODE", objenter.CENTERCODE, OracleType.VarChar);
            procedure.AddInputParameter("p_CENTERNAME", objenter.CENTERNAME, OracleType.VarChar);
            procedure.AddInputParameter("p_CENTERTYPEID", objenter.CENTERTYPEID, OracleType.Number);
            procedure.AddInputParameter("p_CENTERSUBTYPEID", objenter.CENTERSUBTYPEID, OracleType.Number);
            procedure.AddInputParameter("p_RFRAISERYN", objenter.RFRAISERYN, OracleType.VarChar);
            procedure.AddInputParameter("p_RFRAISERID", objenter.RFRAISERID, OracleType.Number);
            procedure.AddInputParameter("p_ENABLEDYN", objenter.ENABLEDYN, OracleType.VarChar);
            procedure.AddInputParameter("p_ADDRESSLINE1", objenter.ADDRESSLINE1, OracleType.VarChar);
            procedure.AddInputParameter("p_ADDRESSLINE2", objenter.ADDRESSLINE2, OracleType.VarChar);
            procedure.AddInputParameter("p_PHONE", objenter.PHONE, OracleType.VarChar);
            procedure.AddInputParameter("p_MAINTAININVENTORYYN", objenter.MAINTAININVENTORYYN, OracleType.VarChar);
            procedure.AddInputParameter("p_CREATEBYUSER", objenter.CREATEBYUSER, OracleType.VarChar);
            procedure.AddInputParameter("p_CREATEDATE", objenter.CREATEDATE, OracleType.DateTime);
            procedure.AddInputParameter("p_LASTUPDATEBY", objenter.LASTUPDATEBY, OracleType.VarChar);
            procedure.AddInputParameter("p_LASTUPDATEDATE", objenter.LASTUPDATEDATE, OracleType.DateTime);
            procedure.AddInputParameter("p_LOCATIONID", objenter.LOCATIONID, OracleType.Number);
            procedure.AddInputParameter("p_STOREID", objenter.STOREID, OracleType.Number);
            procedure.AddInputParameter("p_WAREHOUSEID", objenter.WAREHOUSEID, OracleType.Number);
            procedure.AddInputParameter("p_BUFFERSTOREID", objenter.BUFFERSTOREID, OracleType.Number);
            procedure.AddInputParameter("p_Str_Mode", strMode, OracleType.VarChar);

            procedure.AddInputParameter("p_THANA", objenter.THANAID, OracleType.Number);
            procedure.AddInputParameter("p_DEALER", objenter.DEALERID, OracleType.Number);
            procedure.AddInputParameter("p_BANK_CODE", objenter.BANK_CODE, OracleType.VarChar);

            try
            {
                procedure.ExecuteNonQuery(transaction);
                if (procedure.ReturnMessage == "SUCCESSFUL")
                {
                    return procedure.ErrorCode;
                }
                return procedure.ErrorCode + Utility.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
