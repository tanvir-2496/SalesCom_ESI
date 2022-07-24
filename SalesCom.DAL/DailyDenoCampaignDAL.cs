using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class DailyDenoCampaignDAL
    {

        public static List<DailyDenoCampaignEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_DAILYDENOCAMPAIGNSETUP");
            procedure.AddInputParameter("PCAMPAIGN_ID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<DailyDenoCampaignEnt> results = new List<DailyDenoCampaignEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new DailyDenoCampaignEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<DailyDenoCampaignEnt> GetActiveItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_ACTIVEDAILYDENOCAMPAIGN");
            procedure.AddInputParameter("PCAMPAIGN_ID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<DailyDenoCampaignEnt> results = new List<DailyDenoCampaignEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new DailyDenoCampaignEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        


        public static int SaveItem(DailyDenoCampaign2 obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "ADDDAILYDENOCAMPAIGN");
            procedure.AddInputParameter("PCAMPAIGN_ID", obj.CampaignID, OracleType.Number);
            procedure.AddInputParameter("PCAMPAIGN_NAME", obj.CampaignName, OracleType.VarChar);
            procedure.AddInputParameter("PCAMPAIGN_START_DATE", obj.CampaignStartDate, OracleType.DateTime);
            procedure.AddInputParameter("PCAMPAIGN_END_DATE", obj.CampaignEndDate, OracleType.DateTime);
            procedure.AddInputParameter("PUPPUR_CAP", obj.UpperCap, OracleType.Number);
            procedure.AddInputParameter("pCreateBy", obj.CreateBy, OracleType.Number);
            procedure.AddInputParameter("pUpdateBy", obj.UpdateBy, OracleType.Number);
            procedure.AddInputParameter("p_Str_Mode", strMode, OracleType.VarChar);


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

        public static int InactiveCampaign(int campaignId, int update_by)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "INACTIVE_DAILY_DENO_CAM");
            procedure.AddInputParameter("PCAMPAIGN_ID", campaignId, OracleType.Number);
            procedure.AddInputParameter("pupdateby", update_by, OracleType.Number);

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

        public static DataTable DownloadCampaignTarget(int campaignId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GENERATE_DAILY_DENO_CAM_TARGET");
            procedure.AddInputParameter("PCAMPAIGN_ID", campaignId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
