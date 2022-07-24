using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ActivityDAL
    {


        public static List<ActivityEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_Activity");
            procedure.AddInputParameter("pACTIVITYID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ActivityEnt> results = new List<ActivityEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ActivityEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<ActivityWithJoinEnt> GetItemListWithJoin(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_ActivityWithJoin");
            procedure.AddInputParameter("pACTIVITYID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ActivityWithJoinEnt> results = new List<ActivityWithJoinEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ActivityWithJoinEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public static int SaveItem(Activity2 obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addActivity");
            procedure.AddInputParameter("pACTIVITYID", obj.ActivityID, OracleType.Number);
            procedure.AddInputParameter("pname", obj.ActivityName, OracleType.VarChar);
            procedure.AddInputParameter("pPERIODTYPEID", obj.PeriodtypeID, OracleType.Number);
            procedure.AddInputParameter("pAmountType", obj.ActivityAmountType, OracleType.Number);
            procedure.AddInputParameter("pEFFECTIVEDATE", obj.EffectiveDate, OracleType.DateTime);
            procedure.AddInputParameter("pEXPIRYDATE", obj.ExpiryDate, OracleType.DateTime);
            procedure.AddInputParameter("pCreateBy", obj.CreateBy, OracleType.Number);
            procedure.AddInputParameter("pUpdateBy", obj.UpdateBy, OracleType.Number);
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
