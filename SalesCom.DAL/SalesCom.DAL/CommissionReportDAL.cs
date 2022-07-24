using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;

namespace SalesCom.DAL
{
    public class CommissionReportDAL
    {
        public static List<CommissionReportConciseEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_CommissionReport");
            procedure.AddInputParameter("pREPORTID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<CommissionReportConciseEnt> results = new List<CommissionReportConciseEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new CommissionReportConciseEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public static List<string> Get_Report_Name(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_Report_Name");
            procedure.AddInputParameter("pREPORTID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<string> results = new List<string>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(dr["reportname"] as string);
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public static int SaveItem(CommissionReportConciseEnt obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addCommissionReport");
            procedure.AddInputParameter("pREPORTID", obj.ReportId, OracleType.Number);
            procedure.AddInputParameter("pREPORTNAME", obj.ReportName, OracleType.VarChar);
            procedure.AddInputParameter("pReportTypeId", obj.report_type_id, OracleType.Number);
            procedure.AddInputParameter("pCHANNELTYPEID", obj.ChannelTypeId, OracleType.Number);
            procedure.AddInputParameter("pISACTIVE", obj.IsActive, OracleType.Number);
            procedure.AddInputParameter("pFREQUENCY", obj.Frequency, OracleType.Number);
            procedure.AddInputParameter("pKPIPROCEDURE", obj.KpiProcedure, OracleType.VarChar);
            procedure.AddInputParameter("pPROVISIONINGDAY", obj.ProvisioningDay, OracleType.Number);
            procedure.AddInputParameter("pGENERATIONDAY", obj.GenerationDay, OracleType.Number);
            procedure.AddInputParameter("pPeriodTypeID", obj.PeriodTypeID, OracleType.Number);
            procedure.AddInputParameter("pReportGenTypeID", obj.ReportGenTypeId, OracleType.Number);
            procedure.AddInputParameter("pApprovalFlowId", obj.ApprovalFlowId, OracleType.Number);
            procedure.AddInputParameter("pClaimApprovalFlowId", obj.ClaimApprovalFlowId, OracleType.Number);
            procedure.AddInputParameter("pDisburseApprovalFlowId", obj.DisburseApprovalFlowId, OracleType.Number);
            procedure.AddInputParameter("pDelayDay", obj.DelayDay, OracleType.Number);
            procedure.AddInputParameter("PStartDate", obj.StartDate, OracleType.DateTime);
            procedure.AddInputParameter("PEndDate", obj.EndDate, OracleType.DateTime);
            procedure.AddInputParameter("pCreateBy", obj.CreateBy, OracleType.Number);
            procedure.AddInputParameter("pUpdateBy", obj.UpdateBy, OracleType.Number);
            procedure.AddInputParameter("pUploadCommissionAtPos", obj.upload_commission_at_pos, OracleType.Char);
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

        public static int SaveItemWithFile(CommissionReportConciseEnt obj, string strMode, int userId)
        {
            int result = 0;


            if (obj.SRContent != null && obj.SRContent.Length > 0)
            {
                string sqlQuery = String.Empty;

                OracleConnection conn = new OracleConnection(Connection.ConnectionString);
                conn.Open();
                OracleCommand comd;

                if (strMode == "I")
                {
                    sqlQuery = String.Format("INSERT INTO COMMISSIONREPORT (REPORTID, REPORTNAME, CHANNELTYPEID, PERIODTYPEID, REPORTGENTYPEID, PROVISIONINGDAY, GENERATIONDAY, ISACTIVE, CREATEBY, CREATEDATE, SRCONTENT, FILETYPE, APPROVALFLOWID, CLAIMAPPROVALFLOWID, DISBURSEAPPROVALFLOWID, DELAYDAY, STARTDATE, ENDDATE, REPORT_TYPE_ID, upload_commission_at_pos,DISBURSE_BY_EV,SMSCONTENT,DISBURSETIME) VALUES (COMMISSIONREPORT_ID.NEXTVAL,'{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, sysdate, :BlobParameter,'{8}', {9}, {10}, {11}, {12}, to_date('{13}', 'dd/mm/yyyy hh24:mi:ss') , to_date('{14}', 'dd/mm/yyyy hh24:mi:ss'), {15}, '{16}',{17},'{18}',{19})", obj.ReportName, obj.ChannelTypeId, obj.PeriodTypeID, obj.ReportGenTypeId, obj.ProvisioningDay, obj.GenerationDay, obj.IsActive, userId, obj.FileType, obj.ApprovalFlowId, obj.ClaimApprovalFlowId, obj.DisburseApprovalFlowId, obj.DelayDay, obj.StartDate, obj.EndDate, obj.report_type_id, obj.upload_commission_at_pos, obj.disburseByEvSystem,obj.SMSContent,obj.DisburseTime);
                }
                else
                {
                    sqlQuery = String.Format("UPDATE COMMISSIONREPORT SET  REPORTNAME = '{0}', CHANNELTYPEID = {1},PERIODTYPEID = {2}," +
                                     "REPORTGENTYPEID = {3},PROVISIONINGDAY = {4},GENERATIONDAY = {5}, ISACTIVE = {6},  UPDATEBY={7}," +
                                     " UPDATEDATE = sysdate, SRCONTENT =:BlobParameter, FILETYPE = '{8}', APPROVALFLOWID={10}, CLAIMAPPROVALFLOWID={11}, " +
                                     "DISBURSEAPPROVALFLOWID={12}," +
                                     " DELAYDAY={13}, STARTDATE = to_date('{14}', 'dd/mm/yyyy hh24:mi:ss'), ENDDATE = to_date('{15}'," +
                                     " 'dd/mm/yyyy hh24:mi:ss'), REPORT_TYPE_ID = {16}," +
                                     " upload_commission_at_pos = '{17}',  DISBURSE_BY_EV = {18},SMSCONTENT= '{19}', DISBURSETIME= {20} where REPORTID = {9}",
                                     obj.ReportName, obj.ChannelTypeId, obj.PeriodTypeID, obj.ReportGenTypeId, obj.ProvisioningDay, obj.GenerationDay,
                                     obj.IsActive, userId, obj.FileType, obj.ReportId, obj.ApprovalFlowId, obj.ClaimApprovalFlowId,
                                     obj.DisburseApprovalFlowId, obj.DelayDay, obj.StartDate, obj.EndDate, obj.report_type_id, obj.upload_commission_at_pos, obj.disburseByEvSystem,obj.SMSContent,obj.DisburseTime);
                }
                OracleParameter blobParameter = new OracleParameter();
                blobParameter.OracleType = OracleType.Blob;
                blobParameter.ParameterName = "BlobParameter";
                blobParameter.Value = obj.SRContent;
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

        public static int CreateReportReplication(CommissionReportConciseEnt obj, string strMode, Int32 cycleId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "CreateReportReplication");
            procedure.AddInputParameter("pREPORTID", obj.ReportId, OracleType.Number);
            procedure.AddInputParameter("pREPORTNAME", obj.ReportName, OracleType.VarChar);
            procedure.AddInputParameter("pCycleId", cycleId, OracleType.Number);
            procedure.AddInputParameter("PStartDate", obj.StartDate, OracleType.DateTime);
            procedure.AddInputParameter("PEndDate", obj.EndDate, OracleType.DateTime);
            procedure.AddInputParameter("pCreateBy", obj.CreateBy, OracleType.Number);

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

    }

}
