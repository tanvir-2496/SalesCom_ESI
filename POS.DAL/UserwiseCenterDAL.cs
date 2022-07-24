using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace POS.DAL
{
    public class UserwiseCenterDAL
    {
        public static int SaveUserwiseCenter(UserwiseCenter obj, string strMode,DBTransaction transaction)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "SAVE_USERWISECENTERLIST");
            procedure.AddInputParameter("P_USERID", obj.USERID, OracleType.Int32);
            procedure.AddInputParameter("P_CENTERID", obj.CENTERID, OracleType.Int32);
            procedure.AddInputParameter("P_CREATEBY", obj.CREATEBY, OracleType.VarChar);
            procedure.AddInputParameter("P_STR_MODE", strMode, OracleType.VarChar);

            try
            {
                procedure.ExecuteNonQuery(transaction);

                if (procedure.ReturnMessage == "SUCCESSFUL")
                {
                    return procedure.ErrorCode;
                }

                return procedure.ErrorCode + Utility.ErrorCode;
            }
            catch (Exception ex)
            {

            }

            return -1;

        }

        public static List<UserwiseCenter> GetUserwiseCenterList(UserwiseCenter obj)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "GET_USERWISECENTERLIST");
            procedure.AddInputParameter("P_USERID", obj.USERID, OracleType.Int32);
            procedure.AddInputParameter("P_CENTERID", obj.CENTERID, OracleType.Int32);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<UserwiseCenter> list = new List<UserwiseCenter>();

                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new UserwiseCenter(row));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public static List<UserwiseCenter> GetUnAssignCenterList(UserwiseCenter obj)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "GET_USERUNASSIGNCENTER");
            procedure.AddInputParameter("P_USERID", obj.USERID, OracleType.Int32);
            procedure.AddInputParameter("P_CENTERID", obj.CENTERID, OracleType.Int32);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<UserwiseCenter> list = new List<UserwiseCenter>();

                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new UserwiseCenter(row));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }
    }
}
