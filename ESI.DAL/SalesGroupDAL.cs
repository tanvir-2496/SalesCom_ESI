using ESI.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.DAL
{
    public class SalesGroupDAL
    {
        public static List<SalesGroupViewModel> GetSalesGroupByUserId(int UserId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETSALESGROUPBYUSER");
            procedure.AddInputParameter("PO_USER_ID", UserId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<SalesGroupViewModel> results = new List<SalesGroupViewModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new SalesGroupViewModel(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static SalesGroupViewModel GetSalesGroupByReportCycleId(int ReportCycleId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETSALESGROUPByRCycle");
            procedure.AddInputParameter("P_REPORT_CYCLE_ID", ReportCycleId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                SalesGroupViewModel results = new SalesGroupViewModel();

                results = new SalesGroupViewModel(dt.Rows[0]);

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
