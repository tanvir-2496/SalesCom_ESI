using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class SegmentTypeDAL
    {
        public static List<SegmentTypeEntForView> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_SegmentType");
            procedure.AddInputParameter("pSEGMENTTYPEID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<SegmentTypeEntForView> results = new List<SegmentTypeEntForView>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new SegmentTypeEntForView(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static int SaveItem(SegmentTypeEnt obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addSegmentType");
            procedure.AddInputParameter("pSEGMENTTYPEID", obj.SegmentTypeId, OracleType.Number);
            procedure.AddInputParameter("pTYPENAME", obj.TypeName, OracleType.VarChar);
            procedure.AddInputParameter("pCHANNELTYPEID", obj.ChannelTypeId, OracleType.Number);
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
