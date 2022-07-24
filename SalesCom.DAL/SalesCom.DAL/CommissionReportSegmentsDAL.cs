using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class CommissionReportSegmentsDAL
    {
        public static List<CommissionReportSegmentsEnt> GetItemList(int Id, int segmentId, int eventId, int minP )
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_CommissionReportSegments_N");
            procedure.AddInputParameter("pReportId", Id, OracleType.Number);
            procedure.AddInputParameter("pSegmentId", segmentId, OracleType.Number);
            procedure.AddInputParameter("pEVENTTYPEID", eventId, OracleType.Number);
            procedure.AddInputParameter("pMINIMUMTARGETPERCENTAGE", minP, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<CommissionReportSegmentsEnt> results = new List<CommissionReportSegmentsEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new CommissionReportSegmentsEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static int SaveItem(CommissionReportSegmentsEnt obj, int repotrId, int segmnetId, int eventId, int minP, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "AddCommissionReportSegments");

            procedure.AddInputParameter("pOldReportId", repotrId, OracleType.Number);
            procedure.AddInputParameter("pOldSegmentId", segmnetId, OracleType.Number);
            procedure.AddInputParameter("pOldEventTypeId", eventId, OracleType.Number);
            procedure.AddInputParameter("pOldMinP", minP, OracleType.Number);

            procedure.AddInputParameter("pReportId", obj.ReportId, OracleType.Number);
            procedure.AddInputParameter("pSegmentId", obj.SegmentId, OracleType.Number);
            procedure.AddInputParameter("pEventTypeId", obj.EventTypeId, OracleType.Number);
            procedure.AddInputParameter("pMinimumTargetPercentage", obj.MinimumTargetPercentage, OracleType.Number);
            procedure.AddInputParameter("pMaximumTargetPercentage", obj.MaximumTargetPercentage, OracleType.Number);
            procedure.AddInputParameter("pMinimumTargetAmount", obj.MinimumTargetAmount, OracleType.Number);
            procedure.AddInputParameter("pMaximumTargetAmount", obj.MaximumTargetAmount, OracleType.Number);

            procedure.AddInputParameter("pSegmentAmount", obj.SegmentAmount, OracleType.Number);
            procedure.AddInputParameter("pEventPercentage", obj.EventPercentage, OracleType.Number);
                
            procedure.AddInputParameter("pAmount", obj.Amount, OracleType.Number);
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
