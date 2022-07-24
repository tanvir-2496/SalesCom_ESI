using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace POS.DAL
{
    public class WHRETURNMASTERDAL
    {
        public static List<WHRETURNMASTER> GetItemListMaster(WHRETURNMASTER objenter)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaInventory(), "GET_TBLWHRETURNMASTER");
            procedure.AddInputParameter("p_WHRETURNID", objenter.WHRETURNID, OracleType.Number);
            procedure.AddInputParameter("p_RFNO", objenter.RFNO, OracleType.VarChar);
            procedure.AddInputParameter("p_RFRAISERID", objenter.RFRAISERID, OracleType.Number);
            procedure.AddInputParameter("po_startdate", objenter.STARTDATE, OracleType.DateTime);
            procedure.AddInputParameter("po_enddate", objenter.ENDDATE, OracleType.DateTime);
            procedure.AddInputParameter("po_warehouseid", objenter.WAREHOUSECENTERID, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<WHRETURNMASTER> results = new List<WHRETURNMASTER>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new WHRETURNMASTER(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<WHRETURNCHILD> GetItemListChild(int p_WHRETURNID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaInventory(), "GET_TBLWHRETURNCHILD");
            procedure.AddInputParameter("p_WHRETURNID", p_WHRETURNID, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<WHRETURNCHILD> results = new List<WHRETURNCHILD>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new WHRETURNCHILD(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }



        public static string SaveItemMaster(WHRETURNMASTER objenter, string strMode, DBTransaction transaction)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaInventory(), "SAVE_TBLWHRETURNMASTER");
            procedure.AddInputParameter("p_WHRETURNID", objenter.WHRETURNID, OracleType.Number);
            procedure.AddInputParameter("p_WHRETURNDATE", objenter.WHRETURNDATE, OracleType.DateTime);
            procedure.AddInputParameter("p_RFRAISERID", objenter.RFRAISERID, OracleType.Number);
            procedure.AddInputParameter("p_RFNO", objenter.RFNO, OracleType.VarChar);
            procedure.AddInputParameter("p_RETURNREASON", objenter.RETURNREASON, OracleType.VarChar);
            procedure.AddInputParameter("p_REMARKS", objenter.REMARKS, OracleType.VarChar);
            procedure.AddInputParameter("p_WAREHOUSECENTERID", objenter.WAREHOUSECENTERID, OracleType.VarChar);
            procedure.AddInputParameter("p_CREATEBYUSER", objenter.CREATEBYUSER, OracleType.VarChar);
            procedure.AddInputParameter("p_LASTUPDATEBY", objenter.LASTUPDATEBY, OracleType.VarChar);
            procedure.AddInputParameter("p_STOREID", objenter.STOREID, OracleType.Number);
            procedure.AddInputParameter("p_RECORDSTATUS", "P", OracleType.VarChar);
            procedure.AddInputParameter("p_Str_Mode", strMode, OracleType.VarChar);
            try
            {
                procedure.ExecuteNonQuery(transaction);
                if (procedure.ReturnMessage.Split('|')[0] == "SUCCESSFUL")
                {
                    return procedure.ErrorCode + "|" + procedure.ReturnMessage.Split('|')[1];
                }
                return (procedure.ErrorCode.ToString() + "|" + Utility.ErrorCode.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static int SaveItemChild(WHRETURNCHILD objenter, string strMode, DBTransaction transaction)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaInventory(), "SAVE_TBLWHRETURNCHILD");
            procedure.AddInputParameter("p_WHRETURNID", objenter.WHRETURNID, OracleType.Number);
            procedure.AddInputParameter("p_CHILDID", objenter.CHILDID, OracleType.Number);
            procedure.AddInputParameter("p_PRODUCTID", objenter.PRODUCTID, OracleType.Number);
            procedure.AddInputParameter("p_REFNO", objenter.REFNO, OracleType.VarChar);
            procedure.AddInputParameter("p_SIM_START", objenter.SIMSTART, OracleType.VarChar);
            procedure.AddInputParameter("p_SIM_END", objenter.SIMEND, OracleType.VarChar);
            procedure.AddInputParameter("p_WAREHOUSECENTERID", objenter.WAREHOUSECENTERID, OracleType.VarChar);
            procedure.AddInputParameter("p_CREATEBYUSER", objenter.CREATEBYUSER, OracleType.VarChar);
            procedure.AddInputParameter("p_LASTUPDATEBY", objenter.LASTUPDATEBY, OracleType.VarChar);
            procedure.AddInputParameter("p_STOREID", objenter.STOREID, OracleType.Number);
            procedure.AddInputParameter("p_Str_Mode", strMode, OracleType.VarChar);
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
