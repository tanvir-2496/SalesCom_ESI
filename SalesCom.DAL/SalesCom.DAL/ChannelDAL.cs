using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;


namespace SalesCom.DAL
{
    public class ChannelDAL
    {
        public static List<ViewChannelEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_Channel");
            procedure.AddInputParameter("pCHANNELID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ViewChannelEnt> results = new List<ViewChannelEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ViewChannelEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<ChannelEnt> GetItemListForEdit(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_ChannelForEdit");
            procedure.AddInputParameter("pCHANNELID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ChannelEnt> results = new List<ChannelEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ChannelEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public static int SaveItem(ChannelEnt obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addChannel");

            procedure.AddInputParameter("pCHANNELID", obj.ChannelId, OracleType.Number);
            procedure.AddInputParameter("pPARENTCHANNELID", obj.ParentChannelId, OracleType.Number);
            procedure.AddInputParameter("pCHANNELTYPEID", obj.ChannelTypeId, OracleType.Number);
            procedure.AddInputParameter("pCHANNELNAME", obj.ChannelName, OracleType.VarChar);
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
