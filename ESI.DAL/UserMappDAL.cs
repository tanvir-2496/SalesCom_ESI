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
    public static class UserMappDAL
    {
        public static EmployeeViewModel GetEmployeeByUserId(int id)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETEMPLOYEEID");
            procedure.AddInputParameter("R_USERID", id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                return new EmployeeViewModel(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static List<EmployeeViewModel> GetSalesEmployeeRoles(int employeeId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETSaleEmployeeBYCD");//To Do
            procedure.AddInputParameter("P_CD_ID", employeeId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<EmployeeViewModel> results = new List<EmployeeViewModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new EmployeeViewModel(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static List<EmployeeViewModel> GetRegionalHead(int employeeId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETRHBYCD");//To Do
            procedure.AddInputParameter("P_CD_ID", employeeId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<EmployeeViewModel> results = new List<EmployeeViewModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new EmployeeViewModel(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static List<EmployeeViewModel> GetHoDnDirectorRoles(int employeeId) //Sales & Distribution Director= Head of Monobrand, Cluster Directors,Head of SME
        {                                                                           //Enterprise Business Director='Head of Strategic Business,Head of Key Segment,Head of Medium Segment
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("esi_get_teamfordirector");//To Do
            procedure.AddInputParameter("P_EMPLOYEEID", employeeId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<EmployeeViewModel> results = new List<EmployeeViewModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new EmployeeViewModel(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static List<EmployeeViewModel> GetCXODirectorRoles(int employeeId) //Sales & Distribution Director= Head of Monobrand, Cluster Directors,Head of SME
        {                                                                           //Enterprise Business Director='Head of Strategic Business,Head of Key Segment,Head of Medium Segment
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("esi_get_teamforcxo");//To Do
            procedure.AddInputParameter("P_EMPLOYEEID", employeeId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<EmployeeViewModel> results = new List<EmployeeViewModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new EmployeeViewModel(dr));
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
