using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class CommissionClaimDAL
    {
        public static List<CommissionClaimEnt> GetItemList(Int64 claimId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_CommissionClaim");
            procedure.AddInputParameter("pClaimId", claimId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<CommissionClaimEnt> results = new List<CommissionClaimEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new CommissionClaimEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public static int SaveItem(CommissionClaimEnt obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addCommissionClaim");
            procedure.AddInputParameter("pClaimId", obj.ClaimId, OracleType.Number);
            procedure.AddInputParameter("pReportId", obj.ReportId, OracleType.Number);
            procedure.AddInputParameter("pReferenceNumber", obj.ReferenceNumber, OracleType.VarChar);
            procedure.AddInputParameter("pCommissionCriterion", obj.CommissionCriterion, OracleType.VarChar);
            procedure.AddInputParameter("pCycleId", obj.CycleId, OracleType.Number);
            procedure.AddInputParameter("pModeOfPayment", obj.ModeOfPayment, OracleType.VarChar);
            procedure.AddInputParameter("pHasWithdrawalList", obj.HasWithdrawalList, OracleType.VarChar);
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
