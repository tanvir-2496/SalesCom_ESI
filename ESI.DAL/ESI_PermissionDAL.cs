using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesCom.Entity;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using SalesCom.DAL;
using ESI.Entity;

namespace ESI.DAL
{
    public class ESI_PermissionDAL
    {
        public static int getRolePermission(int userId, int level_id)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETAPPROVEDPERMISSION");
            procedure.AddInputParameter("PUSER_ID", userId, OracleType.Number);
            procedure.AddInputParameter("PLEVEL_ID", level_id, OracleType.Number);
            //procedure.AddInputParameter("PLEVEL_NAME", levelName, OracleType.VarChar);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();

                return Convert.ToInt32(dt.Rows[0]["numOfPermission"]);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static int getUserRolePermission(int userId, int level_id)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETUSERAPPROVEDPERMISSION");
            
            procedure.AddOutputParameter("PO_RETURNVALUE", OracleType.Number);
            procedure.AddInputParameter("PUSER_ID", userId, OracleType.Number);
            procedure.AddInputParameter("PLEVEL_ID", level_id, OracleType.Number);

            try
            {
                procedure.ExecuteNonQuery();
                return procedure.ReturnValue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static int TargetRejectPermission(int reportCycleId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_TARGETREJECTPERMISSION");
            procedure.AddInputParameter("PREPORT_CYCLE_ID", reportCycleId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                return Convert.ToInt32(dt.Rows[0]["RESCOUNT"]);
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static int KpiRejectPermission(int reportCycleId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_KPIREJECTPERMISSION");
            procedure.AddOutputParameter("PO_RETURNVALUE", OracleType.Number);
            procedure.AddInputParameter("PREPORT_CYCLE_ID", reportCycleId, OracleType.Number);

            try
            {
                procedure.ExecuteNonQuery();
                return procedure.ReturnValue;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static int KpiApprovePermission(int reportCycleId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_KPIAPPROVEPERMISSION");
            procedure.AddOutputParameter("PO_RETURNVALUE", OracleType.Number);
            procedure.AddInputParameter("PREPORT_CYCLE_ID", reportCycleId, OracleType.Number);

            try
            {
                procedure.ExecuteNonQuery();
                return procedure.ReturnValue;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
