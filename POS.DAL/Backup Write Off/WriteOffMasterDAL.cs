using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace POS.DAL
{
    public class WriteOffMasterDAL
    {
        public static List<WriteOffMaster> GetItemList(int WRITEOFFID, string WRITEOFFCODE, string WriteOffYN, string FROMWAREHOUSEORCENTER, int FROMWAREHOUSECENTERID, DateTime FROMDATE, DateTime TODATE, string SORTEXPRESSION, string SORTDIRECTION, int STARTROW, int MAXROWS)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaInventory(), "GET_WRITEOFFMASTER");
            procedure.AddInputParameter("p_WRITEOFFID", WRITEOFFID, OracleType.Number);
            procedure.AddInputParameter("p_WRITEOFFCODE", WRITEOFFCODE, OracleType.VarChar);
            procedure.AddInputParameter("p_WRITEOFFYN", WriteOffYN, OracleType.VarChar);
            procedure.AddInputParameter("p_FROMWAREHOUSEORCENTER", FROMWAREHOUSEORCENTER, OracleType.VarChar);
            procedure.AddInputParameter("p_FROMWAREHOUSECENTERID", FROMWAREHOUSECENTERID, OracleType.Number);
            procedure.AddInputParameter("p_FROMDATE", FROMDATE, OracleType.DateTime);
            procedure.AddInputParameter("p_TODATE", TODATE, OracleType.DateTime);
            procedure.AddInputParameter("p_SORTEXPRESSION", SORTEXPRESSION, OracleType.VarChar);
            procedure.AddInputParameter("p_SORTDIRECTION", SORTDIRECTION, OracleType.VarChar);
            procedure.AddInputParameter("p_STARTROW", STARTROW, OracleType.Number);
            procedure.AddInputParameter("p_MAXROWS", MAXROWS, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<WriteOffMaster> results = new List<WriteOffMaster>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new WriteOffMaster(dr));
                }

                return results;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static int GetItemListCount(int WRITEOFFID, string WRITEOFFCODE, string WriteOffYN, string FROMWAREHOUSEORCENTER, int FROMWAREHOUSECENTERID, DateTime FROMDATE, DateTime TODATE)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaInventory(), "GET_WRITEOFFMASTER_COUNT");
            procedure.AddInputParameter("p_WRITEOFFID", WRITEOFFID, OracleType.Number);
            procedure.AddInputParameter("p_WRITEOFFCODE", WRITEOFFCODE, OracleType.VarChar);
            procedure.AddInputParameter("p_WRITEOFFYN", WriteOffYN, OracleType.VarChar);
            procedure.AddInputParameter("p_FROMWAREHOUSEORCENTER", FROMWAREHOUSEORCENTER, OracleType.VarChar);
            procedure.AddInputParameter("p_FROMWAREHOUSECENTERID", FROMWAREHOUSECENTERID, OracleType.Number);
            procedure.AddInputParameter("p_FROMDATE", FROMDATE, OracleType.DateTime);
            procedure.AddInputParameter("p_TODATE", TODATE, OracleType.DateTime);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                return Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static string SaveItem(WriteOffMaster objransferMaster, string strMode, DBTransaction transaction)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaInventory(), "SAVE_WRITEOFFMASTER");
            procedure.AddInputParameter("p_WRITEOFFID", objransferMaster.WRITEOFFID, OracleType.Number);
            procedure.AddInputParameter("p_WRITEOFFCODE", objransferMaster.WRITEOFFCODE, OracleType.VarChar);
            procedure.AddInputParameter("p_WRITEOFFDATE", objransferMaster.WRITEOFFDATE, OracleType.DateTime);
            procedure.AddInputParameter("p_REFNO", objransferMaster.REFNO, OracleType.VarChar);
            procedure.AddInputParameter("p_RFID", objransferMaster.RFID, OracleType.Number);
            procedure.AddInputParameter("p_WRITEOFFYN", objransferMaster.WRITEOFFYN, OracleType.VarChar);
            procedure.AddInputParameter("p_REMARKS", objransferMaster.REMARKS, OracleType.VarChar);
            procedure.AddInputParameter("p_FROMWAREHOUSEORCENTER", objransferMaster.FROMWAREHOUSEORCENTER, OracleType.Char);
            procedure.AddInputParameter("p_FROMWAREHOUSECENTERID", objransferMaster.FROMWAREHOUSECENTERID, OracleType.Number);
            procedure.AddInputParameter("p_FROMSTOREID", objransferMaster.FROMSTOREID, OracleType.Number);
            procedure.AddInputParameter("p_TOWAREHOUSEORCENTER", objransferMaster.TOWAREHOUSEORCENTER, OracleType.Char);
            procedure.AddInputParameter("p_TOWAREHOUSECENTERID", objransferMaster.TOWAREHOUSECENTERID, OracleType.Number);
            procedure.AddInputParameter("p_TOSTOREID", objransferMaster.TOSTOREID, OracleType.Number);

            procedure.AddInputParameter("p_CREATEBYUSER", objransferMaster.CREATEBYUSER, OracleType.VarChar);
            procedure.AddInputParameter("p_CREATEDATE", objransferMaster.CREATEDATE, OracleType.DateTime);
            procedure.AddInputParameter("p_LASTUPDATEBY", objransferMaster.LASTUPDATEBY, OracleType.VarChar);
            procedure.AddInputParameter("p_LASTUPDATEDATE", objransferMaster.LASTUPDATEDATE, OracleType.DateTime);
            procedure.AddInputParameter("p_RECORDSTATUS", objransferMaster.RECORDSTATUS, OracleType.VarChar);
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
            return "0";
        }

    }
}
