using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class DenoDriveDAL
    {
        public static List<RecipientTypeEnt> GetRecipientType()
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_RECIPIENTTYPE");

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<RecipientTypeEnt> results = new List<RecipientTypeEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new RecipientTypeEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public static List<ModalityTypeEnt> ModalityType()
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_MODALITYTYPE");

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ModalityTypeEnt> results = new List<ModalityTypeEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ModalityTypeEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<Modality> ApprovalFlowType()
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_APPROVAL_FLOW");

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<Modality> results = new List<Modality>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new Modality(dr));
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
