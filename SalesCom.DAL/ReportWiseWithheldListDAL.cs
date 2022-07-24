using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ReportWiseWithheldListDAL
    {
        public static List<ReportWiseWithheldListEnt> Get_Report_Wise_Withheld_List(int cycleId, int page_index)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_Report_Wise_Withheld_List");
            procedure.AddInputParameter("p_cycleId", cycleId, OracleType.VarChar);
            procedure.AddInputParameter("p_page_index", page_index, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ReportWiseWithheldListEnt> result = new List<ReportWiseWithheldListEnt>();

                foreach (DataRow row in dt.Rows)
                {
                    result.Add(new ReportWiseWithheldListEnt(row));
                }
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static DataTable Get_Report_Wise_Withheld_dtls(int report_cycle_id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_Report_Wise_Withheld_dtls");
            procedure.AddInputParameter("p_report_cycle_id", report_cycle_id, OracleType.Number);

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
