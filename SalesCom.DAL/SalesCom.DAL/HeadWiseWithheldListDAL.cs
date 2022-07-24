using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class HeadWiseWithheldListDAL
    {
        public static List<HeadWiseWithheldListEnt> Get_Withheld_Com_Head_Wise(string distributorCode, int page_index)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_Withheld_Com_Head_Wise");
            procedure.AddInputParameter("p_distributor_code", distributorCode, OracleType.VarChar);
            procedure.AddInputParameter("p_page_index", page_index, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<HeadWiseWithheldListEnt> result = new List<HeadWiseWithheldListEnt>();

                foreach (DataRow row in dt.Rows)
                {
                    result.Add(new HeadWiseWithheldListEnt(row));
                }
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static DataTable Get_Withheld_Com_Channel_Wise(int report_cycle_id, string recipient_code)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_Withheld_Com_Channel_Wise");
            procedure.AddInputParameter("p_report_cycle_id", report_cycle_id, OracleType.Number);
            procedure.AddInputParameter("p_recipient_code", recipient_code, OracleType.VarChar);

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

        public static DataTable Get_Withheld_Com_Summary(string recipient_code)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_Withheld_Com_Summary");
            procedure.AddInputParameter("p_recipient_code", recipient_code, OracleType.VarChar);

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

        public static DataTable Get_Withheld_Com_Recipient_all(string recipient_code)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_Withheld_Com_Recipient_all");
            procedure.AddInputParameter("p_recipient_code", recipient_code, OracleType.VarChar);

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
