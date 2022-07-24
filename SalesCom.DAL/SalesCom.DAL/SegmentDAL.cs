using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class SegmentDAL
    {

        public static List<SegmentEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_SEGMENT");
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<SegmentEnt> results = new List<SegmentEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new SegmentEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<SegmentTypeSegmentEnt> SetSegmentByID(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_SegmentByID");
            procedure.AddInputParameter("pSEGMENTID", Id, OracleType.Number); 
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<SegmentTypeSegmentEnt> results = new List<SegmentTypeSegmentEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new SegmentTypeSegmentEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        public static int SaveItem(SegmentEnt obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addSegment");
            procedure.AddInputParameter("pSEGMENTID", obj.SegmentID, OracleType.Number);
            procedure.AddInputParameter("pSEGMENTTYPEID", obj.SegmentTypeID, OracleType.Number);
            procedure.AddInputParameter("pSEGMENTNAME", obj.SegmentName, OracleType.VarChar);
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
