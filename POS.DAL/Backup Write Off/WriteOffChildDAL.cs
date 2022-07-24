using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace POS.DAL
{
    public class WriteOffChildDAL
    {
        public static List<WriteOffChild> GetItemList(int WRITEOFFID, int CHILDID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaInventory(), "GET_WRITEOFFCHILD");
            procedure.AddInputParameter("p_WRITEOFFID", WRITEOFFID, OracleType.Number);
            procedure.AddInputParameter("p_CHILDID", CHILDID, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<WriteOffChild> results = new List<WriteOffChild>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new WriteOffChild(dr));
                }

                return results;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static int SaveItem(WriteOffChild objWriteOffChild, string strMode, DBTransaction transaction)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaInventory(), "SAVE_WRITEOFFCHILD");
            procedure.AddInputParameter("p_WRITEOFFID", objWriteOffChild.WRITEOFFID, OracleType.Number);
            procedure.AddInputParameter("p_CHILDID", objWriteOffChild.CHILDID, OracleType.Number);
            procedure.AddInputParameter("p_PRODUCTID", objWriteOffChild.PRODUCTID, OracleType.Number);
            procedure.AddInputParameter("p_QTY", objWriteOffChild.QTY, OracleType.Number);
            procedure.AddInputParameter("p_SIMSTART", objWriteOffChild.SIMSTART, OracleType.VarChar);
            procedure.AddInputParameter("p_SIMEND", objWriteOffChild.SIMEND, OracleType.VarChar);
            procedure.AddInputParameter("p_CREATEBYUSER", objWriteOffChild.CREATEBYUSER, OracleType.VarChar);
            procedure.AddInputParameter("p_CREATEDATE", objWriteOffChild.CREATEDATE, OracleType.DateTime);
            procedure.AddInputParameter("p_LASTUPDATEBY", objWriteOffChild.LASTUPDATEBY, OracleType.VarChar);
            procedure.AddInputParameter("p_LASTUPDATEDATE", objWriteOffChild.LASTUPDATEDATE, OracleType.DateTime);
            procedure.AddInputParameter("p_WAREHOUSECENTERID", objWriteOffChild.WAREHOUSECENTERID, OracleType.Number);
            procedure.AddInputParameter("p_STOREID", objWriteOffChild.STOREID, OracleType.Number);
            procedure.AddInputParameter("p_RECORDSTATUS", objWriteOffChild.RECORDSTATUS, OracleType.VarChar);
            procedure.AddInputParameter("p_Str_Mode", strMode, OracleType.VarChar);

            try
            {
                procedure.ExecuteNonQuery(transaction);
                if (procedure.ReturnMessage == "SUCCESSFUL")
                {
                    return procedure.ErrorCode;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 0;
        }

    }
}
