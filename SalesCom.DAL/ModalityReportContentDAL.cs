using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ModalityReportContentDAL
    {
        public static List<ModalityReportContentEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_ModalityReportContent");
            procedure.AddInputParameter("pID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ModalityReportContentEnt> results = new List<ModalityReportContentEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ModalityReportContentEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static byte[] GetFile(int Id)
        {
            dllOracle dll = new dllOracle();
            string sql = "select filecontent from MODALITYREPORTCONTENT where id=" + Id;
            return dll.GetBytes(sql);

        }


        public static byte[] GetAdHocSR(int Id)
        {
            dllOracle dll = new dllOracle();
            string sql = "select SR_CONTENT from ad_hoc_report where ad_hoc_report_id = " + Id;
            return dll.GetBytes(sql);
        }

        public static byte[] GetReportApprovalSR(int Id)
        {
            dllOracle dll = new dllOracle();
            string sql = "select srcontent from report_approval where report_approval_id = " + Id;
            return dll.GetBytes(sql);
        }

        public static byte[] GetHRReportApproval(int Id)
        {
            dllOracle dll = new dllOracle();
            string sql = "select srcontent from esiapprovalstatuslog where approval_status_log_id = " + Id;
            return dll.GetBytes(sql);
        }


        public static byte[] GetSR(int Id)
        {
            dllOracle dll = new dllOracle();
            string sql = "select SRCONTENT from COMMISSIONREPORT where REPORTID = " + Id;
            return dll.GetBytes(sql);

        }


        public static int SaveItem(ModalityReportContentEnt obj, string strMode)
        {
            OracleConnection conn = new OracleConnection(Connection.ConnectionString);
            conn.Open();
            OracleCommand comd;
            string sqlQuery = String.Format("INSERT INTO MODALITYREPORTCONTENT (ID,REPORTNAME,ISACTIVE,FILECONTENT, FILETYPE,CREATEDATE,CREATEBY)VALUES(MODELITYREPORTCONTENT_ID.NEXTVAL,'{0}',{1},:BlobParameter,'{2}',sysdate,'{3}')", obj.ReportName, obj.IsActive == true ? 1 : 0, obj.FileType, obj.CreateBy);
            OracleParameter blobParameter = new OracleParameter();
            blobParameter.OracleType = OracleType.Blob;
            blobParameter.ParameterName = "BlobParameter";
            blobParameter.Value = obj.FileContent;
            comd = new OracleCommand(sqlQuery, conn);
            comd.Parameters.Add(blobParameter);

            try
            {
                comd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
