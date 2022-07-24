
using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CampaignDenoDriveSetupAdd : System.Web.UI.Page
{
    private static Action SaveData;

    public string editMode
    {
        get
        {
            return ViewState["editMode"].ToString();
        }
        set
        {
            ViewState["editMode"] = value;
        }
    }
    protected int Id
    {
        get
        {
            return (int)ViewState["Id"];
        }
        set
        {
            ViewState["Id"] = value;
        }
    }

    protected int ConfigValue
    {
        get
        {
            return (int)ViewState["ConfigValue"];
        }
        set
        {
            ViewState["ConfigValue"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.CampaignDenoAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            editMode = "add";
            Id = -1;
            Common.RecipientType(ddlRecipientTypeId);
            Common.AddSelectOne(ddlRecipientTypeId);

            Common.ModalityType(ddlModality);
            Common.AddSelectOne(ddlModality);

            Common.ApprovalFlowType(ddlApprovalFlow);
            Common.AddSelectOne(ddlApprovalFlow);

            hdnConfigValue.Value =CampaignDenoDriveDAL.GetConFigValue().ToString();

            try { 
                 if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                GetDenoSetUpModel CampaignInfo = CampaignDenoDriveDAL.GetItemData(Id);

                hdnOperationId.Value = Id.ToString();
                ddlRecipientTypeId.SelectedValue = CampaignInfo.RecipientTypeId.ToString();
                txtCampainName.Text = CampaignInfo.CamPaignName;
                txtCampainStartDate.Text = CampaignInfo.CamPaignStart.Value.ToString("dd-MM-yyyy");
                txtCampainEndDate.Text = CampaignInfo.CamPaignEnd.Value.ToString("dd-MM-yyyy");
                txtDenoAmount.Text = CampaignInfo.DenoAmount.ToString();
                ddlModality.SelectedValue = CampaignInfo.ModalityId.ToString();

                ddlApprovalFlow.SelectedValue = CampaignInfo.ApprovalId.ToString();

                chkHitAmount.Checked = CampaignInfo.IsOverHit.Value;

                chkPlaneHitAmount.Checked = CampaignInfo.IsHitAmount.Value;


                if (CampaignInfo.IsOverHit.Value == true || CampaignInfo.IsHitAmount.Value == true)
                {
                    txtHitAmount.Text = CampaignInfo.OverHit.ToString();
                }


                chkMaxCap.Checked = CampaignInfo.IsMaxCap.Value;

                if (CampaignInfo.IsMaxCap.Value == true)
                {
                    txtMaxCap.Text = CampaignInfo.MaxCap.ToString();
                }

                chkIncentive.Checked = CampaignInfo.IsIncentiveAmount.Value;

                if (CampaignInfo.IsIncentiveAmount.Value == true)
                {
                    txtIncentive.Text = CampaignInfo.IncentiveAmount.ToString();
                }

                chkPercentage.Checked = CampaignInfo.IsHitPercentage.Value;

                if (CampaignInfo.IsHitPercentage.Value == true)
                {
                    txtPercentage.Text = CampaignInfo.HitPercentage.ToString();
                }


                chkHitTarget.Checked= CampaignInfo.IsTargetSlab.Value;
                chkAchivement.Checked = CampaignInfo.IsAchivementSlab.Value;

                if (CampaignInfo.ModalityId.ToString()=="1") {
                    hdnSlabData.Value = BindSlabData(Id);
                }

             
             
            }
            }catch(Exception ex){
                throw ex;
            }

            if (!string.IsNullOrEmpty(Request["mode"]))
            {
                editMode = Request["mode"];
                hdnEditMode.Value = editMode;
            }
        }
    }

    public string BindSlabData(int getId) {
        int rowSL = 0;
        string denoStart="0";
        string denoEnd="5";
        string denoIncentive = "150";
        string actionLink = "<button type='button' class='btn' style='background-color: ff9933; margin-left: 5px;height: 18px !important;width: 42px;'  onclick='RemoveThisDenoItem(this)'><a class='fa fa-trash' style='font-size: 10px;font-style: normal !important;'>Delete</a></button></div>";
        string tableRow = "";
        int denoStatus = 0;
        IList<DenoListModel> results = CampaignDenoDriveDAL.GetDenoItemData(getId);

        for (int i = 0; i < results.Count; i++)
        {
            rowSL = i;
            denoStart = results[i].DenoStart;
            denoEnd = results[i].DenoEnd;
            denoIncentive = results[i].DenoIncentive;

            if (results[i].status == 1) {
                denoStatus = 1;
            }

            tableRow = tableRow + "<tr class='dummy_row_line_item' id='deno_" + (rowSL + 1) + "'>";
            tableRow = tableRow + "<td class='dummy_sl_no' style='display: none'> <span>" + (rowSL + 1) + " </span></td>";
            tableRow = tableRow + "<td class='dummy_item_denostatus' style='display: none'><input type='hidden' name='DenoInfo[" + (rowSL) + "].DenoStatus' value='" + results[i].status + "'> <span>" + results[i].status + "</span></td>";
            tableRow = tableRow + "<td class='dummy_item_denostart'><input type='hidden' name='DenoInfo[" + (rowSL) + "].DenoStart' value='" + denoStart + "'> <span>" + denoStart + "</span></td>";
            if (results[i].status == 1)
            {
                denoStatus = 1;
                tableRow = tableRow + "<td class='dummy_item_denoend'><input type='hidden' name='DenoInfo[" + (rowSL) + "].DenoEnd' value='" + denoEnd + "'> <span>More...</span></td>";
            }
            else {
                tableRow = tableRow + "<td class='dummy_item_denoend'><input type='hidden' name='DenoInfo[" + (rowSL) + "].DenoEnd' value='" + denoEnd + "'> <span>" + denoEnd + "</span></td>";
            }
           
            tableRow = tableRow + "<td class='dummy_item_incentive'><input type='hidden' name='DenoInfo[" + (rowSL) + "].DenoIncentive' value='" + denoIncentive + "'> <span>" + denoIncentive + "</span></td>";

            tableRow = tableRow + "<td class='dummy_model_link'>" + actionLink + "</td>";
            tableRow = tableRow + "</tr>";
        }

        hdnRowId.Value = rowSL.ToString();
        hdnStatus.Value = denoStatus.ToString();

      return tableRow;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime CampaignStartDate = String.IsNullOrEmpty(txtCampainStartDate.Text) ? default(DateTime) : DateTime.Parse(txtCampainStartDate.Text);
            DateTime CampaignEndDate = String.IsNullOrEmpty(txtCampainEndDate.Text) ? default(DateTime) : DateTime.Parse(txtCampainEndDate.Text);
            double CampaignDuration = ((CampaignEndDate.Date - CampaignStartDate.Date).TotalDays) + 1;
            if (CampaignStartDate <= CampaignEndDate)
            {
                if (CampaignStartDate >= DateTime.Now.Date)
                {
                    if (CampaignDuration <= 30)
                    {
                        int ErrorCode = 0;// SaveData(true);
                        MsgUtility.msg(editMode, ErrorCode, "Campaign Setup Information", this, lblMsg, txtCampainName.Text);
                        if (editMode == "add")
                        {
                            if (ErrorCode >= 0)
                            {
                                ClearData();
                            }
                        }
                    }
                    else
                        MsgUtility.msgCommon(this, lblMsg, " Max campaign duration is 30 days.");
                }
                else
                    MsgUtility.msgCommon(this, lblMsg, "Campaign start date must be minimum today and onwards.");
            }
            else
                MsgUtility.msgCommon(this, lblMsg, "Start date must be grater or equal from end date.");
        }
        catch (Exception EX)
        {
            MsgUtility.msgCommon(this, lblMsg, "Error Occured!!!" + EX.Message);
        }


    }



    private void ClearData()
    {
        editMode = "add";
        Id = -1;
        txtCampainName.Text = txtCampainStartDate.Text = txtCampainEndDate.Text = txtDenoAmount.Text = String.Empty;
    }

    [WebMethod]
    public static string GETConditionBy(List<DenoSetUpModel> dataItem, IList<DenoListModel> denoItem)
    {
        CampaignDenoDriveSetupAdd obj = new CampaignDenoDriveSetupAdd();
        var isSuccess = obj.SaveDataMethod(dataItem, denoItem);
        return isSuccess;
    }


    public string SaveDataMethod(List<DenoSetUpModel> dataItem, IList<DenoListModel> denoItem)
    {
        try
        {
            DenoSetUpModel CampaignInfo = new DenoSetUpModel();

            CampaignInfo.Id = dataItem[0].Id;

            CampaignInfo.RecipientTypeId = dataItem[0].RecipientTypeId;
            CampaignInfo.ApprovalFlowId = dataItem[0].ApprovalFlowId;
            CampaignInfo.CamPaignName = dataItem[0].CamPaignName.Trim();
            CampaignInfo.DenoAmount = dataItem[0].DenoAmount.Trim();
            CampaignInfo.CamPaignStart = dataItem[0].CamPaignStart;
            CampaignInfo.CamPaignEnd = dataItem[0].CamPaignEnd;
            CampaignInfo.ModalityId = dataItem[0].ModalityId;

            CampaignInfo.MaxCap = dataItem[0].MaxCap;
            CampaignInfo.HitPercentage = dataItem[0].HitPercentage;
            CampaignInfo.OverHit = dataItem[0].OverHit;            
            CampaignInfo.IncentiveAmount = dataItem[0].IncentiveAmount;
            CampaignInfo.IsMaxCap = dataItem[0].IsMaxCap;
            CampaignInfo.IsHitPercentage = dataItem[0].IsHitPercentage;
            CampaignInfo.IsOverHit = dataItem[0].IsOverHit;
            CampaignInfo.IsHitAmount = dataItem[0].IsHitAmount;
            CampaignInfo.IsIncentiveAmount = dataItem[0].IsIncentiveAmount;
            CampaignInfo.IsSlab = dataItem[0].IsSlab;
            CampaignInfo.IsTargetSlab = dataItem[0].IsTargetSlab;
            CampaignInfo.IsAchivementSlab = dataItem[0].IsAchivementSlab;

            CampaignInfo.Mode = dataItem[0].Mode;

            int CreateBy = LoginInfo.Current.UserId;
            string getStatus = CampaignDenoDriveDAL.SaveItem(CampaignInfo, CreateBy, denoItem);

           return getStatus;
        }
        catch (Exception EX)
        {
            return EX.Message.ToString();
        }

    }
    //btnRefresh_Click

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        int ErrorCode = 0;
        if (editMode == "add")
        {
            MsgUtility.msg(editMode, ErrorCode, "Campaign data ", this, lblMsg, "Campaign SetUp");
        }
        else {
            MsgUtility.msg("update", ErrorCode, "Campaign data ", this, lblMsg, "Campaign SetUp");
            
        }
        
        
    }

     [WebMethod]
    public static IList<Modality> GetModalityValue(string currentData)
    {
        try {
             IList<Modality> obj = new List<Modality>();
             int getId = Convert.ToInt32(currentData);
             obj = CampaignDenoDriveDAL.GetModalityValue(getId);
             return obj;
            }
         catch(Exception ex){
             throw ex;
            }        
    }

}


