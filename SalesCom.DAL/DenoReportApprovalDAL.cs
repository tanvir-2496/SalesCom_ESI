using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;

namespace SalesCom.DAL
{
    public class DenoReportApprovalDAL
    {
        public static List<DenoReportApprovalEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "get_deno_report_approval");
            procedure.AddInputParameter("preport_approval_id", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<DenoReportApprovalEnt> results = new List<DenoReportApprovalEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new DenoReportApprovalEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<DenoPendingApprovalList> PendingReportAprList(int user_id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_DenoPendingReportAprList");
            procedure.AddInputParameter("pUser_Id", user_id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<DenoPendingApprovalList> results = new List<DenoPendingApprovalList>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new DenoPendingApprovalList(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static Int16 GetFirstOrderLevel(int flowId)
        {
            Int16 firstOrderlevelId = 0;
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "get_firstOrderLevelId");
            procedure.AddInputParameter("pApprovalFlowId", flowId, OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0] != DBNull.Value) { firstOrderlevelId = Convert.ToInt16(dr[0]); }
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return firstOrderlevelId;
        }

        public static int SaveItem(ReportApprovalEnt obj, string strMode, int user_id, string user_name)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "save_report_approval");
            procedure.AddInputParameter("preport_approval_id", obj.report_approval_id, OracleType.Number);
            procedure.AddInputParameter("preport_name", obj.report_name, OracleType.VarChar);
            procedure.AddInputParameter("pchannel_type_id", obj.channel_type_id, OracleType.Number);
            procedure.AddInputParameter("pperiod_type_id", obj.period_type_id, OracleType.Number);
            procedure.AddInputParameter("peffective_date", obj.effective_date, OracleType.DateTime);
            procedure.AddInputParameter("pexpire_date", obj.expire_date, OracleType.DateTime);
            procedure.AddInputParameter("papproval_flow_id", obj.approval_flow_id, OracleType.Number);
            procedure.AddInputParameter("puser_id", user_id, OracleType.Number);
            procedure.AddInputParameter("puser_name", user_name, OracleType.VarChar);
            procedure.AddInputParameter("pUploadCommissionAtPos", obj.upload_commission_at_pos, OracleType.Char);
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

        //public static int SaveItemWithFile(ReportApprovalEnt obj, string strMode, int userId, string user_name)
        //{
        //    int result = 0;

        //    if (obj.srcontent != null && obj.srcontent.Length > 0)
        //    {
        //        string sqlQueryOne = String.Empty;
        //        string sqlQueryTwo = String.Empty;
        //        string sqlFinalQuery = String.Empty;
        //        obj.approval_level_id = GetFirstOrderLevel(obj.approval_flow_id);

        //        if (strMode == "I")
        //        {
        //            sqlFinalQuery = String.Format(@" insert into report_approval (REPORT_APPROVAL_ID, REPORT_NAME, CHANNEL_TYPE_ID, PERIOD_TYPE_ID, EFFECTIVE_DATE, EXPIRE_DATE, APPROVAL_FLOW_ID, APPROVAL_LEVEL_ID, STATUS, CURRENT_STATUS_DATE, FILETYPE, SRCONTENT, USER_ID, upload_commission_at_pos) values (seq_report_approvl_id.nextval, '{0}', {1}, {2}, to_date('{3}', 'dd/mm/yyyy hh24:mi:ss'), to_date('{4}', 'dd/mm/yyyy hh24:mi:ss'), {5}, {6}, 0, sysdate, '{7}', :BlobParameter, {8}, '{9}')", obj.report_name, obj.channel_type_id, obj.period_type_id, obj.effective_date, obj.expire_date, obj.approval_flow_id, obj.approval_level_id, obj.filetype, userId, obj.upload_commission_at_pos);
        //        }
        //        else
        //        {
        //            sqlQueryOne = String.Format(@" begin UPDATE report_approval SET REPORT_NAME = '{0}', CHANNEL_TYPE_ID = {1}, PERIOD_TYPE_ID = {2}, EFFECTIVE_DATE = to_date('{3}', 'dd/mm/yyyy hh24:mi:ss'), EXPIRE_DATE = to_date('{4}', 'dd/mm/yyyy hh24:mi:ss'),  comments = '', status = 0, current_status_date = sysdate, FILETYPE = '{5}', SRCONTENT = :BlobParameter, APPROVAL_FLOW_ID = {6}, APPROVAL_LEVEL_ID = {7}, upload_commission_at_pos = '{8}' WHERE REPORT_APPROVAL_ID = {9};", obj.report_name, obj.channel_type_id, obj.period_type_id, obj.effective_date, obj.expire_date, obj.filetype, obj.approval_flow_id, obj.approval_level_id, obj.upload_commission_at_pos, obj.report_approval_id);
        //            sqlQueryTwo = String.Format(@" INSERT INTO report_approval_detail (Id, report_approval_id, approval_level_id, status, user_id, user_name ) VALUES (seq_report_details_id.nextval, {0}, 0, 3, {1}, '{2}'); end;", obj.report_approval_id, userId, user_name);
        //            sqlFinalQuery = sqlQueryOne + sqlQueryTwo;

        //        }

        //        OracleConnection conn = new OracleConnection(Connection.ConnectionString);
        //        conn.Open();
        //        OracleTransaction trn = conn.BeginTransaction();
        //        OracleCommand commd;
        //        OracleParameter param = new OracleParameter();
        //        param.OracleType = OracleType.Blob;
        //        param.ParameterName = "BlobParameter";
        //        param.Value = obj.srcontent;
        //        commd = new OracleCommand(sqlFinalQuery, conn);
        //        commd.Parameters.Add(param);
        //        commd.Transaction = trn;

        //        try
        //        {
        //            result = commd.ExecuteNonQuery();
        //            trn.Commit();
        //            conn.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            trn.Rollback();
        //            throw (ex);
        //        }

        //    }
        //    else
        //    {
        //        result = SaveItem(obj, strMode, userId, user_name);
        //    }

        //    return result;
        //}

        public static List<ApprovalHistory> GetApprovalHistory(int report_approval_id)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "get_report_approval_his");
            procedure.AddInputParameter("preport_approval_id", report_approval_id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ApprovalHistory> results = new List<ApprovalHistory>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ApprovalHistory(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            
        }

        public static int ReportApprovalAct(DenoReportApprovalEnt obj, int user_id, string user_name)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "DenoReportApprovalAct");
            procedure.AddInputParameter("pId", obj.id, OracleType.Number);
            procedure.AddInputParameter("pReportName", obj.report_name, OracleType.VarChar);
            procedure.AddInputParameter("pDenotTypeId", obj.deno_type_id, OracleType.Number);
            procedure.AddInputParameter("pFlowId", obj.approval_flow_id, OracleType.Number);   
            procedure.AddInputParameter("pLevelName", obj.approvallevelname, OracleType.VarChar);
            procedure.AddInputParameter("pLevelId", obj.approval_level_id, OracleType.Number);
            procedure.AddInputParameter("pOrder", obj.orderid, OracleType.Number);
            procedure.AddInputParameter("pStatus", obj.status, OracleType.Number);
            procedure.AddInputParameter("pComment", obj.comments, OracleType.VarChar);
            procedure.AddInputParameter("pUserId", user_id, OracleType.Number);
            procedure.AddInputParameter("pUserName", user_name, OracleType.VarChar);

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
