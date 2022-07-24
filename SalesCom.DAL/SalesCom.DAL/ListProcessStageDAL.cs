using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ListProcessStageDAL
    {
        public static List<SetupProcessEnt> GetSetupProcessList(int id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_SetupProcess");
            procedure.AddInputParameter("pNUMID", id, System.Data.OracleClient.OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<SetupProcessEnt> results = new List<SetupProcessEnt>();

                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new SetupProcessEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<SetupStageViewEnt> GetSetupStageView(int id, int numProcessId, int numStageOrder)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_SetupStageView");
            procedure.AddInputParameter("pNUMID", id, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pNUMPROCESSID", numProcessId, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pNUMSTAGEORDER", numStageOrder, System.Data.OracleClient.OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<SetupStageViewEnt> results = new List<SetupStageViewEnt>();

                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new SetupStageViewEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<SetupStageEnt> GetSetupStageByProcessId(int numProcessId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_SetupStageByProcessId");
            procedure.AddInputParameter("pNUMPROCESSID", numProcessId, System.Data.OracleClient.OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<SetupStageEnt> result = new List<SetupStageEnt>();

                foreach (DataRow dr in dt.Rows)
                {
                    result.Add(new SetupStageEnt(dr));
                }

                return result;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<SetupStageEnt> GetSetupStageByNumId(int numId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_SetupStageByNumId");
            procedure.AddInputParameter("pNUMID", numId, System.Data.OracleClient.OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<SetupStageEnt> result = new List<SetupStageEnt>();

                foreach (DataRow dr in dt.Rows)
                {
                    result.Add(new SetupStageEnt(dr));
                }

                return result;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveSetupStage(SetupStageEnt obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addSetupStage");
            procedure.AddInputParameter("pNUMID", obj.NumId, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pNUMPROCESSID", obj.NumProcessId, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pSTRSTAGENAME", obj.StrStageName, System.Data.OracleClient.OracleType.VarChar);
            procedure.AddInputParameter("pNUMSTAGEORDER", obj.NumStageOrder, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pNUMCREATEUSER", obj.NumCreateUser, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pNUMEDITUSER", obj.NumEditUser, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("p_Str_Mode", strMode, System.Data.OracleClient.OracleType.VarChar);

            try
            {
                procedure.ExecuteNonQuery();
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
