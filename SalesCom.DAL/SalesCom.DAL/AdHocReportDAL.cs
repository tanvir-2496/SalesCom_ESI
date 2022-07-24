using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class AdHocReportDAL
    {
        public static List<AdHocReportEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_AdHocReports");
            procedure.AddInputParameter("pad_hoc_report_id", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<AdHocReportEnt> results = new List<AdHocReportEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new AdHocReportEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<AdHocReportList> Get_AdHoc_Report_List()
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_AdHoc_Report_List");
          

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<AdHocReportList> results = new List<AdHocReportList>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new AdHocReportList(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static int SaveItem(AdHocReportEnt obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "AddAdHocReport");
            procedure.AddInputParameter("pad_hoc_report_id", obj.ad_hoc_report_id, OracleType.Number);
            procedure.AddInputParameter("preport_name", obj.report_name, OracleType.VarChar);
            procedure.AddInputParameter("pchannel_type_id", obj.channel_type_id, OracleType.Number);
            procedure.AddInputParameter("pis_active", obj.is_active, OracleType.Number);
            procedure.AddInputParameter("pperiod_type_id", obj.period_type_id, OracleType.Number);
            procedure.AddInputParameter("preport_gen_type", obj.report_gen_type, OracleType.Number);
            procedure.AddInputParameter("preport_flow_id", obj.report_flow_id, OracleType.Number);
            procedure.AddInputParameter("pclaim_flow_id", obj.claim_flow_id, OracleType.Number);
            procedure.AddInputParameter("pdisburse_flow_id", obj.disburse_flow_id, OracleType.Number);
            procedure.AddInputParameter("pcreate_by", obj.create_by, OracleType.Number);
            procedure.AddInputParameter("pupdate_by", obj.update_by, OracleType.Number);
            procedure.AddInputParameter("pDisburseByEVSystem", obj.disburseByEvSystem, OracleType.Number);
            procedure.AddInputParameter("p_Str_Mode", strMode, OracleType.VarChar);
            procedure.AddInputParameter("p_SMS_Content", obj.SMSContent, OracleType.VarChar);
            procedure.AddInputParameter("p_Disburse_Time", obj.DisburseTime, OracleType.Number);

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

        public static int SaveItemWithFile(AdHocReportEnt obj, string strMode, int userId)
        {
            int result = 0;


            if (obj.sr_content != null && obj.sr_content.Length > 0)
            {
                string sqlQuery = String.Empty;

                OracleConnection conn = new OracleConnection(Connection.ConnectionString);
                conn.Open();
                OracleCommand comd;

                if (strMode == "I")
                {
                    sqlQuery = String.Format("INSERT INTO AD_HOC_REPORT (AD_HOC_REPORT_ID, REPORT_NAME, CHANNEL_TYPE_ID, IS_ACTIVE, PERIOD_TYPE_ID, REPORT_GEN_TYPE, REPORT_FLOW_ID, CLAIM_FLOW_ID, DISBURSE_FLOW_ID, CREATE_BY, CREATE_DATE, SR_CONTENT, FILE_TYPE, DISBURSE_BY_EV) VALUES(AD_HOC_REPORT_ID.NEXTVAL,'{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8},  sysdate, :BlobParameter,'{9}',{10},'{11}',{12})", obj.report_name, obj.channel_type_id, obj.is_active, obj.period_type_id, obj.report_gen_type, obj.report_flow_id, obj.claim_flow_id, obj.disburse_flow_id, userId, obj.file_type, obj.disburseByEvSystem,obj.SMSContent,obj.DisburseTime);
                }
                else
                {
                    sqlQuery = String.Format("UPDATE AD_HOC_REPORT SET  REPORT_NAME = '{0}', CHANNEL_TYPE_ID = {1}, IS_ACTIVE = {2}, PERIOD_TYPE_ID = {3}, REPORT_GEN_TYPE = {4}, REPORT_FLOW_ID = {5}, CLAIM_FLOW_ID = {6},  DISBURSE_FLOW_ID={7}, UPDATE_BY = {8}, UPDATE_DATE = sysdate, SR_CONTENT =:BlobParameter, FILE_TYPE = '{9}' , DISBURSE_BY_EV = {11},SMSCONTENT='{12}',DISBURSETIME={13} where AD_HOC_REPORT_ID = {10}", obj.report_name, obj.channel_type_id, obj.is_active, obj.period_type_id, obj.report_gen_type, obj.report_flow_id, obj.claim_flow_id, obj.disburse_flow_id, userId, obj.file_type, obj.ad_hoc_report_id, obj.disburseByEvSystem, obj.SMSContent, obj.DisburseTime);
                }
                OracleParameter blobParameter = new OracleParameter();
                blobParameter.OracleType = OracleType.Blob;
                blobParameter.ParameterName = "BlobParameter";
                blobParameter.Value = obj.sr_content;
                comd = new OracleCommand(sqlQuery, conn);
                comd.Parameters.Add(blobParameter);

                try
                {
                    comd.ExecuteNonQuery();
                    conn.Close();
                    result = 1;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                result = SaveItem(obj, strMode);
            }

            return result;
        }
    }
}
