using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using ESI.Entity;
using SalesCom.DAL;

namespace ESI.DAL
{
    public class ESI_ReportApprovalDAL
    {

        public static int KpiTargetApprovalAct(int approval_status_id, string comments, int userId, string userName, string FileType, byte[] srcontent)
        {
            //ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_UPDATEAPPROVAL");
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_UPDATETARGETAPPROVAL");
            procedure.AddOutputParameter("PO_RETURNVALUE", OracleType.Number);
            procedure.AddInputParameter("PAPPROVAL_STATUS_ID", approval_status_id, OracleType.Number);
            procedure.AddInputParameter("PCOMMENTS", comments, OracleType.VarChar);
            procedure.AddInputParameter("PCreatedBy", userId, OracleType.VarChar);
            procedure.AddInputParameter("PCreatedByName", userName, OracleType.VarChar);

            try
            {
                procedure.ExecuteNonQuery();
                //if (procedure.ReturnMessage == "SUCCESSFUL")
                //{
                //    return procedure.ErrorCode;
                //}
                if (procedure.ErrorCode == 0)
                {
                    if (FileType != "" && srcontent != null)
                    {

                        int result = 0;
                        int returnValue = procedure.ReturnValue;
                        string sqlFinalQuery = String.Empty;

                        sqlFinalQuery = String.Format(@"UPDATE ESIAPPROVALSTATUSLOG SET SRCONTENT = :BlobParameter, FTYPE = '{0}' WHERE approval_status_log_id = {1}", FileType, returnValue);

                        OracleConnection conn = new OracleConnection(Connection.ConnectionString);
                        conn.Open();
                        OracleTransaction trn = conn.BeginTransaction();
                        OracleCommand commd;
                        OracleParameter param = new OracleParameter();
                        param.OracleType = OracleType.Blob;
                        param.ParameterName = "BlobParameter";
                        param.Value = srcontent;
                        commd = new OracleCommand(sqlFinalQuery, conn);
                        commd.Parameters.Add(param);
                        commd.Transaction = trn;

                        try
                        {
                            result = commd.ExecuteNonQuery();
                            trn.Commit();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            trn.Rollback();
                            throw (ex);
                        }

                        return procedure.ErrorCode;
                    }
                }
                return procedure.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int KpiApprovalAct(int approval_status_id, string comments, int userId, string userName, string FileType, byte[] srcontent)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_UPDATEKPIAPPROVAL");
            procedure.AddOutputParameter("PO_RETURNVALUE", OracleType.Number);
            procedure.AddInputParameter("PAPPROVAL_STATUS_ID", approval_status_id, OracleType.Number);
            procedure.AddInputParameter("PCOMMENTS", comments, OracleType.VarChar);
            procedure.AddInputParameter("PCreatedBy", userId, OracleType.VarChar);
            procedure.AddInputParameter("PCreatedByName", userName, OracleType.VarChar);

            try
            {
                procedure.ExecuteNonQuery();
                if (procedure.ErrorCode == 0)
                {
                    if (FileType != "" && srcontent != null)
                    {

                        int result = 0;
                        int returnValue = procedure.ReturnValue;
                        string sqlFinalQuery = String.Empty;

                        sqlFinalQuery = String.Format(@"UPDATE ESIAPPROVALSTATUSLOG SET SRCONTENT = :BlobParameter, FTYPE = '{0}' WHERE approval_status_log_id = {1}", FileType, returnValue);

                        OracleConnection conn = new OracleConnection(Connection.ConnectionString);
                        conn.Open();
                        OracleTransaction trn = conn.BeginTransaction();
                        OracleCommand commd;
                        OracleParameter param = new OracleParameter();
                        param.OracleType = OracleType.Blob;
                        param.ParameterName = "BlobParameter";
                        param.Value = srcontent;
                        commd = new OracleCommand(sqlFinalQuery, conn);
                        commd.Parameters.Add(param);
                        commd.Transaction = trn;

                        try
                        {
                            result = commd.ExecuteNonQuery();
                            trn.Commit();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            trn.Rollback();
                            throw (ex);
                        }

                        return procedure.ErrorCode;
                    }
                }
                return procedure.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ReportApprovalAct(int approval_status_id, string comments, int userId, string userName)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_UPDATEREPORTAPPROVAL");
            procedure.AddInputParameter("PAPPROVAL_STATUS_ID", approval_status_id, OracleType.Number);
            procedure.AddInputParameter("PCOMMENTS", comments, OracleType.VarChar);
            procedure.AddInputParameter("PCreatedBy", userId, OracleType.VarChar);
            procedure.AddInputParameter("PCreatedByName", userName, OracleType.VarChar);

            try
            {
                procedure.ExecuteNonQuery();
                if (procedure.ReturnMessage == "SUCCESSFUL")
                {
                    return procedure.ErrorCode;
                }
                return procedure.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static int TargetRejectionAct(int approval_status_id, string comments, int userId, string userName)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_REJECTAPPROVALFORTARGET");
            procedure.AddInputParameter("PAPPROVAL_STATUS_ID", approval_status_id, OracleType.Number);
            procedure.AddInputParameter("PCOMMENTS", comments, OracleType.VarChar);
            procedure.AddInputParameter("PCreatedBy", userId, OracleType.VarChar);
            procedure.AddInputParameter("PCreatedByName", userName, OracleType.VarChar);

            try
            {
                procedure.ExecuteNonQuery();
                if (procedure.ReturnMessage == "SUCCESSFUL")
                {
                    return procedure.ErrorCode;
                }
                return procedure.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int KpiRejectionAct(int approval_status_id, string comments, int userId, string userName)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_REJECTAPPROVALFORKPI");
            procedure.AddInputParameter("PAPPROVAL_STATUS_ID", approval_status_id, OracleType.Number);
            procedure.AddInputParameter("PCOMMENTS", comments, OracleType.VarChar);
            procedure.AddInputParameter("PCreatedBy", userId, OracleType.VarChar);
            procedure.AddInputParameter("PCreatedByName", userName, OracleType.VarChar);

            try
            {
                procedure.ExecuteNonQuery();
                if (procedure.ReturnMessage == "SUCCESSFUL")
                {
                    return procedure.ErrorCode;
                }
                return procedure.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int KpiDeleteAct(int approval_status_id, string comments, int userId, string userName)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_DELETEAPPROVALFORKPI");
            procedure.AddInputParameter("PAPPROVAL_STATUS_ID", approval_status_id, OracleType.Number);
            procedure.AddInputParameter("PCOMMENTS", comments, OracleType.VarChar);
            procedure.AddInputParameter("PCreatedBy", userId, OracleType.VarChar);
            procedure.AddInputParameter("PCreatedByName", userName, OracleType.VarChar);

            try
            {
                procedure.ExecuteNonQuery();
                if (procedure.ReturnMessage == "SUCCESSFUL")
                {
                    return procedure.ErrorCode;
                }
                return procedure.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateRejectForRA(int approval_status_id, string comments, int userId, string userName)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_UPDATEREJECTFORRA");
            procedure.AddInputParameter("PAPPROVAL_STATUS_ID", approval_status_id, OracleType.Number);
            procedure.AddInputParameter("PCOMMENTS", comments, OracleType.VarChar);
            procedure.AddInputParameter("PCreatedBy", userId, OracleType.VarChar);
            procedure.AddInputParameter("PCreatedByName", userName, OracleType.VarChar);

            try
            {
                procedure.ExecuteNonQuery();
                if (procedure.ReturnMessage == "SUCCESSFUL")
                {
                    return procedure.ErrorCode;
                }
                return procedure.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int TargetReUploadAct(int approval_status_id, string comments, int userId, string userName)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_REUPLOADAPPROVAL");
            procedure.AddInputParameter("PAPPROVAL_STATUS_ID", approval_status_id, OracleType.Number);
            procedure.AddInputParameter("PCOMMENTS", comments, OracleType.VarChar);
            procedure.AddInputParameter("PCreatedBy", userId, OracleType.VarChar);
            procedure.AddInputParameter("PCreatedByName", userName, OracleType.VarChar);

            try
            {
                procedure.ExecuteNonQuery();
                if (procedure.ReturnMessage == "SUCCESSFUL")
                {
                    return procedure.ErrorCode;
                }
                return procedure.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ApprovalHistoryEnt> GetApprovalHistory(int approval_status_id, string approvalName) 
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_REPORTAPPROVALHIS");
            procedure.AddInputParameter("PAPPROVAL_STATUS_ID", approval_status_id, OracleType.Number);
            procedure.AddInputParameter("PAPPROVALNAME", approvalName, OracleType.VarChar);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ApprovalHistoryEnt> results = new List<ApprovalHistoryEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ApprovalHistoryEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public static List<ApprovalHistoryEnt> GetDetailApprovalHistory(int approval_status_id)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_DETAILAPPROVALHISTORY");
            procedure.AddInputParameter("PAPPROVAL_STATUS_ID", approval_status_id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ApprovalHistoryEnt> results = new List<ApprovalHistoryEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ApprovalHistoryEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


    }
}
