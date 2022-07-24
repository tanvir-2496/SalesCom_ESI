using ESI.Entity;
using SalesCom.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.DAL
{
    public class ESI_SalesChannelDAL
    {
        public static List<SalesChannelEnt> GetItemList(int SalesGroupId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETSALESCHANNEL");
            procedure.AddInputParameter("SSALES_GROUP_ID", SalesGroupId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<SalesChannelEnt> results = new List<SalesChannelEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new SalesChannelEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

       
    }
}
