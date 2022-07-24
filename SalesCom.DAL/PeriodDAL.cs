using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class PeriodDAL
    {
        public static List<PeriodEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_Period");
            procedure.AddInputParameter("pPERIODID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<PeriodEnt> results = new List<PeriodEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new PeriodEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static int SaveItem(PeriodEnt obj, string strMode)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addPeriod");
            procedure.AddInputParameter("pPERIODID", obj.PeriodId, OracleType.Number);
            procedure.AddInputParameter("pPERIODTYPEID", obj.PeriodTypeId, OracleType.Number);
            procedure.AddInputParameter("pSTARTDATE", obj.StartDate, OracleType.DateTime);
            procedure.AddInputParameter("pENDDATE", obj.EndDate, OracleType.DateTime);
            procedure.AddInputParameter("pMONTH", obj.Month, OracleType.VarChar);
            procedure.AddInputParameter("pPERIODDATE", obj.PeriodDate, OracleType.DateTime);
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
