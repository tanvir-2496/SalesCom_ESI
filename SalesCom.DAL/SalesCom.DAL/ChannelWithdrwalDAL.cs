using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ChannelWithdrwalDAL
    {
        public static List<ChannelWithdrawalEnt> GetItemList(int Id, int reportId, Int32 reportCycle)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_ChannelWithdrawal");
            procedure.AddInputParameter("pId", Id, OracleType.Number);
            procedure.AddInputParameter("pReportId", reportId, OracleType.Number);
            procedure.AddInputParameter("pReportCycle", reportCycle, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ChannelWithdrawalEnt> results = new List<ChannelWithdrawalEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ChannelWithdrawalEnt(dr));
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
