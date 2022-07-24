using POS.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;

namespace POS.DAL
{
    public class ImportFromExcelDAL
    {
        public static List<SIMNO> GetItemList(String spathexcel)
        {       

            try
            {
                ImportFromExcel importExcel = new ImportFromExcel(spathexcel);
                DataTable dt = importExcel.LoadFromExcel();
                List<SIMNO> results = new List<SIMNO>(); 
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new SIMNO(dr));
                }

                return results;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static List<AltChannelBalance> GetAltChannelBalance(String spathexcel)
        {

            try
            {
                ImportFromExcel importExcel = new ImportFromExcel(spathexcel);
                DataTable dt = importExcel.LoadFromExcel();
                List<AltChannelBalance> results = new List<AltChannelBalance>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new AltChannelBalance(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<DistributorCreditLimit> GetDistributorCreditLimit(String spathexcel)
        {

            try
            {
                ImportFromExcel importExcel = new ImportFromExcel(spathexcel);
                DataTable dt = importExcel.LoadFromExcel();
               
                    
                        
                        
                List<DistributorCreditLimit> results = new List<DistributorCreditLimit>();
                foreach (DataRow dr in dt.Rows)
                {

                 
                    results.Add(new DistributorCreditLimit(dr,true));
                }

                return results;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<PayableReceivableChild> GetPayableReceivableFromExcel(String spathexcel)
        {

            try
            {
                ImportFromExcel importExcel = new ImportFromExcel(spathexcel);
                DataTable dt = importExcel.LoadFromExcel();




                List<PayableReceivableChild> results = new List<PayableReceivableChild>();
                foreach (DataRow dr in dt.Rows)
                {


                    results.Add(new PayableReceivableChild(dr, true));
                }

                return results;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<CommissionDetails> GetCommissionDetailsFromExcel(String spathexcel)
        {

            try
            {
                ImportFromExcel importExcel = new ImportFromExcel(spathexcel);
                DataTable dt = importExcel.LoadFromExcel();




                List<CommissionDetails> results = new List<CommissionDetails>();
                foreach (DataRow dr in dt.Rows)
                {


                    results.Add(new CommissionDetails(dr, true));
                }

                return results;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<PriceAdjustmentDetails> GetPriceAdjustmentFromExcel(String spathexcel)
        {

            try
            {
                ImportFromExcel importExcel = new ImportFromExcel(spathexcel);
                DataTable dt = importExcel.LoadFromExcel();




                List<PriceAdjustmentDetails> results = new List<PriceAdjustmentDetails>();
                foreach (DataRow dr in dt.Rows)
                {


                    results.Add(new PriceAdjustmentDetails (dr, true));
                }

                return results;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<ReturnProductDetails> GetReturnProductFromExcel(String spathexcel)
        {

            try
            {
                ImportFromExcel importExcel = new ImportFromExcel(spathexcel);
                DataTable dt = importExcel.LoadFromExcel();




                List<ReturnProductDetails> results = new List<ReturnProductDetails>();
                foreach (DataRow dr in dt.Rows)
                {


                    results.Add(new ReturnProductDetails(dr, true));
                }

                return results;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public static List<SIMDetails> GetItemList1(String spathexcel)
        {

            try
            {
                ImportFromExcel importExcel = new ImportFromExcel(spathexcel);
                DataTable dt = importExcel.LoadFromExcel();
                List<SIMDetails> results = new List<SIMDetails>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new SIMDetails(dr));
                }

                return results;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<MFSEnableSIM> GetMFSEnableSIM(String spathexcel)
        {

            try
            {
                ImportFromExcel importExcel = new ImportFromExcel(spathexcel);
                DataTable dt = importExcel.LoadFromExcel();
                List<MFSEnableSIM> results = new List<MFSEnableSIM>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new MFSEnableSIM(dr,"Excel"));
                }

                return results;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

           public static int UploadAggregationDetails(String spathexcel)
        {
            ImportFromExcel importExcel = new ImportFromExcel(spathexcel);
            DataTable excelInput = importExcel.LoadFromExcel();
            int rowsAffected = 0;

            OracleTransaction transOracle;
           // OracleConnection connection = null;
            //string sConnString = Connection.ConnectionString();
            using (OracleConnection connection = new OracleConnection(Connection.ConnectionString))
            {
                using (OracleCommand command = new OracleCommand("INSERT INTO tblbrealserial(SIMNO) VALUES (:SIM_NUMBER)", connection))
                {
                    command.Parameters.AddRange(new OracleParameter[]
                        {
                             new OracleParameter("SIM_NUMBER",OracleType.VarChar)                             
                        });

                    command.CommandType = CommandType.Text;
                    connection.Open();
                    transOracle = connection.BeginTransaction();
                    command.Transaction = transOracle;

                    try
                    {
                   foreach (DataRow dr in excelInput.Rows)
                        {

                            
                            command.Parameters["SIM_NUMBER"].Value = dr[0].ToString().Trim();
                          



                            //reqCommand.CommandText = BuildRequestCommand(CustomerRequstID, requestType, userID, requiredRole, dr["MSISDN"].ToString().Trim());
                            // reqCommand.ExecuteNonQuery();

                            rowsAffected = command.ExecuteNonQuery();

                            // CustomerRequstID += 1;
                        }

                        transOracle.Commit();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        transOracle.Rollback();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
            }

            return rowsAffected;
        }
           public static int UploadAggregationDetails1(String spathexcel)
           {
               ImportFromExcel importExcel = new ImportFromExcel(spathexcel);
               DataTable excelInput = importExcel.LoadFromExcel();
               int rowsAffected = 0;

               OracleTransaction transOracle;
               // OracleConnection connection = null;
               //string sConnString = Connection.ConnectionString();
               using (OracleConnection connection = new OracleConnection(Connection.ConnectionString))
               {
                   using (OracleCommand command = new OracleCommand("INSERT INTO TBLBREALDETAILS(SIM_ST,SIM_EN) VALUES (:SIM_ST,:SIM_EN)", connection))
                   {
                       command.Parameters.AddRange(new OracleParameter[]
                        {
                             new OracleParameter("SIM_ST",OracleType.VarChar)  ,
                              new OracleParameter("SIM_EN",OracleType.VarChar)   
                        });

                       command.CommandType = CommandType.Text;
                       connection.Open();
                       transOracle = connection.BeginTransaction();
                       command.Transaction = transOracle;

                       try
                       {
                           foreach (DataRow dr in excelInput.Rows)
                           {


                               command.Parameters["SIM_ST"].Value = dr[0].ToString().Trim();
                               command.Parameters["SIM_EN"].Value = dr[1].ToString().Trim();



                               //reqCommand.CommandText = BuildRequestCommand(CustomerRequstID, requestType, userID, requiredRole, dr["MSISDN"].ToString().Trim());
                               // reqCommand.ExecuteNonQuery();

                               rowsAffected = command.ExecuteNonQuery();

                               // CustomerRequstID += 1;
                           }

                           transOracle.Commit();
                           connection.Close();
                       }
                       catch (Exception ex)
                       {
                           transOracle.Rollback();
                           throw new Exception(ex.Message);
                       }
                       finally
                       {
                           connection.Close();
                       }

                   }
               }

               return rowsAffected;
           }
    }
}
