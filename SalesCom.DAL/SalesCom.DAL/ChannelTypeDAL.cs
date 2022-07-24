using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ChannelTypeDAL
    {
        public static List<ChannelTypeEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_ChannelType");
            procedure.AddInputParameter("pCHANNELTYPEID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ChannelTypeEnt> results = new List<ChannelTypeEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ChannelTypeEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static int SaveItem(ChannelTypeEnt obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addChannelType");
            procedure.AddInputParameter("pCHANNELTYPEID", obj.ChannelTypeId, OracleType.Number);
            procedure.AddInputParameter("pCHANNELTYPE", obj.ChannelType, OracleType.VarChar);
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
