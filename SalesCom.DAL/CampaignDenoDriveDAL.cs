using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class CampaignDenoDriveDAL
    {

        public static string CheckReportNameValid(string reportName)
        {
            string Value = "";

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "CHECK_REPORT_NAME");
            procedure.AddInputParameter("P_RPT_NAME", reportName, OracleType.VarChar);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();

                foreach (DataRow dr in dt.Rows)
                {
                    Value = dr[0].ToString();
                }
                if (Value == reportName)
                {
                    return "SUCCESSFUL";
                }
                else
                {
                    return "FALSE";
                }



            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static string SaveReportMasterDetailItemData(ReportMaster obj, int operationBy, IList<ReportDetail> detailItem)
        {

            string reportName = obj.ReportName;
            string cycleId = obj.CyCleId;

            int Id = Convert.ToInt32(obj.Id);

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "ADD_COM_DET_MASTER");

            procedure.AddInputParameter("P_ID", Id, OracleType.Number);
            procedure.AddInputParameter("P_RPT_NAME", reportName, OracleType.VarChar);
            procedure.AddInputParameter("P_RPT_CID", cycleId, OracleType.VarChar);
            procedure.AddInputParameter("P_OPRATION_TYPE", obj.Mode, OracleType.VarChar);

            try
            {
                procedure.ExecuteNonQuery();
                if (procedure.ReturnMessage == "SUCCESSFUL" || procedure.ReturnMessage == "SUCCE")
                {
                    int MasterId = procedure.ErrorCode;

                    if (obj.Mode == "ADD")
                    {
                        Id = MasterId;
                    }

                    SaveDetailItem(detailItem, Id);

                }
                return procedure.ReturnMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string SaveDetailItem(IList<ReportDetail> obj, int MasterId)
        {
            int count = 0;

            foreach (ReportDetail item in obj)
            {

                string tableName = item.TableName;
                string levelName = item.LevelName;


                OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "ADD_Commision_detail_Mapdata");

                procedure.AddInputParameter("P_TBL_NAME", tableName, OracleType.VarChar);
                procedure.AddInputParameter("P_LEVEL_NAME", levelName, OracleType.VarChar);
                procedure.AddInputParameter("P_MASTER_ID", MasterId, OracleType.Number);
                procedure.AddInputParameter("P_COUNT", count, OracleType.Number);

                procedure.ExecuteNonQuery();
                count = count + 1;
            }
            try
            {
                return "SUCCESSFUL";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static int GetIsTableExist(string table_name)
        {
            string Value = "";
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GetIsTableExist");
            procedure.AddInputParameter("pTableName", table_name, OracleType.VarChar);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();

                foreach (DataRow dr in dt.Rows)
                {
                    Value = dr[0].ToString();
                }
                if (Value == table_name)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }



            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public static IList<ReportDetail> GetDetailSetupItemData(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_Detail_Mapper_Databyid");
            procedure.AddInputParameter("P_ID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();

                List<ReportDetail> results = new List<ReportDetail>();

                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ReportDetail(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static ReportMaster GetDailySetupById(int Id)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_Daily_setup_by_id");
            procedure.AddInputParameter("P_ID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();

                ReportMaster results = new ReportMaster();

                if (dt.Rows.Count > 0)
                {
                    results = new ReportMaster(dt.Rows[0]);
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<DetailSetupList> GetCommissionDetaiSetuplList()
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GetCommissionDetailSetupList");


            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<DetailSetupList> list = new List<DetailSetupList>();

                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new DetailSetupList(dr));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string SaveItem(DenoSetUpModel obj, int operationBy,IList<DenoListModel> denoItem)
        {
            int recipientTypeId= Convert.ToInt32(obj.RecipientTypeId);
            int modalityId = Convert.ToInt32(obj.ModalityId);
            int approvalFlow = Convert.ToInt32(obj.ApprovalFlowId);
            int Id = Convert.ToInt32(obj.Id);

            DateTime startDate = String.IsNullOrEmpty(obj.CamPaignStart) ? default(DateTime) : DateTime.ParseExact(obj.CamPaignStart, "dd-MM-yyyy", null);
            DateTime endDate = String.IsNullOrEmpty(obj.CamPaignEnd) ? default(DateTime) : DateTime.ParseExact(obj.CamPaignEnd, "dd-MM-yyyy", null);

            string campaignName = "";
            string mode = obj.Mode;

            if (obj.Mode == "ADD")
            {
                campaignName = obj.CamPaignName + "_from_" + startDate.ToString("dd_MMM_yy") + "_to_" + endDate.ToString("dd_MMM_yy");
            }
            else {
                campaignName = obj.CamPaignName;
            }
          

            int incentiveAmount = String.IsNullOrEmpty(obj.IncentiveAmount) ? 0 : Convert.ToInt32(obj.IncentiveAmount);
            int hitPercentage = String.IsNullOrEmpty(obj.HitPercentage) ? 0 : Convert.ToInt32(obj.HitPercentage);
            int maxCap = String.IsNullOrEmpty(obj.MaxCap) ? 0 : Convert.ToInt32(obj.MaxCap);
            int overHit = String.IsNullOrEmpty(obj.OverHit) ? 0 : Convert.ToInt32(obj.OverHit);

            int IsincentiveAmount = (obj.IsIncentiveAmount == "False") ? 0 : 1;
            int IshitPercentage = (obj.IsHitPercentage == "False") ? 0 : 1;
            int IsmaxCap = (obj.IsMaxCap == "False") ? 0 : 1;
            int IsoverHit = (obj.IsOverHit == "False") ? 0 : 1;
            int IsHitAmount = (obj.IsHitAmount == "False") ? 0 : 1;

            int IsSlab = (obj.IsSlab == "False") ? 0 : 1;
            int IsTargetSlab = (obj.IsTargetSlab == "False") ? 0 : 1;
            int IsAchivementSlab = (obj.IsAchivementSlab == "False") ? 0 : 1;

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "ADD_DENO_CAMP_IN_BASE");


            procedure.AddInputParameter("P_ID", Id, OracleType.Number);//P_ID NUMBER, 
            procedure.AddInputParameter("P_CAMP_NAME", campaignName, OracleType.VarChar); //P_CAMP_NAME VARCHAR2, 
            procedure.AddInputParameter("P_CAMP_START_DATE", startDate, OracleType.DateTime);//P_CAMP_START_DATE DATE,
            procedure.AddInputParameter("P_CAMP_END_DATE", endDate, OracleType.DateTime);//P_CAMP_END_DATE DATE,
            procedure.AddInputParameter("P_DENO_AMOUNT", obj.DenoAmount, OracleType.VarChar);//P_DENO_AMOUNT VARCHAR2,
            procedure.AddInputParameter("P_MODALITYID", modalityId, OracleType.Number);//P_MODALITYID NUMBER,
            procedure.AddInputParameter("P_DENOTYPEID", recipientTypeId, OracleType.Number);//P_DENOTYPEID NUMBER,
            procedure.AddInputParameter("P_APPROVAL_FLOW", approvalFlow, OracleType.Number);//P_APPROVAL_FLOW,            
            procedure.AddInputParameter("P_INCENTIVE_AMOUNT", incentiveAmount, OracleType.Number);//P_INCENTIVE_AMOUNT NUMBER,
            procedure.AddInputParameter("P_HIT_PERCENTAGE", hitPercentage, OracleType.Number);//P_HIT_PERCENTAGE NUMBER,
            procedure.AddInputParameter("P_UPPER_CAP", maxCap, OracleType.Number);//P_UPPER_CAP NUMBER,
            procedure.AddInputParameter("P_OPERATION_BY", operationBy, OracleType.Number);//P_OPERATION_BY NUMBER,
            procedure.AddInputParameter("P_OVER_HIT", overHit, OracleType.Number);//P_OVER_HIT NUMBER,            
            procedure.AddInputParameter("P_IS_SLAB_WISE", IsSlab, OracleType.Number);//P_IS_SLAB_WISE NUMBER,
            procedure.AddInputParameter("P_IS_HIT_PERCENTAGE", IshitPercentage, OracleType.Number);//P_IS_HIT_PERCENTAGE NUMBER,
            procedure.AddInputParameter("P_IS_INCENTIVE", IsincentiveAmount, OracleType.Number);//P_IS_INCENTIVE NUMBER,
            procedure.AddInputParameter("P_IS_UPPER_CAP", IsmaxCap, OracleType.Number);//P_IS_UPPER_CAP NUMBER,
            procedure.AddInputParameter("P_IS_OVER_HIT", IsoverHit, OracleType.Number);//P_IS_OVER_HIT NUMBER,
            procedure.AddInputParameter("P_IS_HIT_AMOUNT", IsHitAmount, OracleType.Number);//P_IS_HIT_AMOUNT NUMBER,
            procedure.AddInputParameter("P_IS_TARGET_SLAB", IsTargetSlab, OracleType.Number);//P_IS_TARGET_SLAB NUMBER, 
            procedure.AddInputParameter("P_IS_ACHIVEMENT_SLAB", IsAchivementSlab, OracleType.Number);//P_IS_ACHIVEMENT_SLAB, 
            procedure.AddInputParameter("P_OPRATION_TYPE", obj.Mode, OracleType.VarChar);//P_OPRATION_TYPE VARCHAR2,


            try
            {
                procedure.ExecuteNonQuery();
                if (procedure.ReturnMessage == "SUCCESSFUL" || procedure.ReturnMessage == "SUCCE")
                {
                    int denoId = procedure.ErrorCode;

                    if (modalityId == 1)
                    {
                        if (mode == "ADD")
                        {
                            Id = denoId;
                        }

                        SaveSlabItem(denoItem, Id);
                    }
                }
                return procedure.ReturnMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static string SaveSlabItem(IList<DenoListModel> obj,int denoId)
        {
            int count = 0;

            foreach(DenoListModel item in obj){

                int denoStatus = item.status;
                int denoStart = Convert.ToInt32(item.DenoStart);
                int denoEnd = Convert.ToInt32(item.DenoEnd);
                int denoIncentive = Convert.ToInt32(item.DenoIncentive);

                OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "ADD_SLAB");

                procedure.AddInputParameter("P_ISMORETHAN", denoStatus, OracleType.Number);
                procedure.AddInputParameter("P_START_HIT", denoStart, OracleType.Number);//P_START_HIT NUMBER,
                procedure.AddInputParameter("P_END_HIT", denoEnd, OracleType.Number);//P_END_HIT NUMBER,
                procedure.AddInputParameter("P_INCENTIVE", denoIncentive, OracleType.Number);//P_INCENTIVE NUMBER,
                procedure.AddInputParameter("P_DENOCAMPID", denoId, OracleType.Number);//P_DENOCAMPID NUMBER,
                procedure.AddInputParameter("P_COUNT", count, OracleType.Number);//P_COUNT NUMBER,

                procedure.ExecuteNonQuery();
                count = count + 1;
            }
            try
            {
                return "SUCCESSFUL";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static GetDenoSetUpModel GetItemData(int Id)
        {
            //OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_CommissionReport");
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_CAMPAIGN_DENO_REPORT");
            procedure.AddInputParameter("P_ID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();

                GetDenoSetUpModel results = new GetDenoSetUpModel();

                if (dt.Rows.Count > 0)
                {
                    results = new GetDenoSetUpModel(dt.Rows[0]);
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static int GetConFigValue() {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_CONFIG_VALUE");
            procedure.AddInputParameter("P_ID", 0, OracleType.Number);
            try
            {
                int denoId=0;
                procedure.ExecuteQueryToDataTable();
                if (procedure.ErrorCode > 0)
                {
                    denoId = procedure.ErrorCode;

                }
                return denoId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IList<DenoListModel> GetDenoItemData(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_SLAB_BY_CAMPID");
            procedure.AddInputParameter("P_ID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();

                List<DenoListModel> results = new List<DenoListModel>();

                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new DenoListModel(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public static List<Modality> GetModalityValue(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_MODALITY_BY_ID");
            procedure.AddInputParameter("P_ID", Id, OracleType.Number);

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

        public static IList<Modality> GetApprovalFlow()
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
