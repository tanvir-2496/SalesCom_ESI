using SalesCom.DAL;
using SalesCom.Entity;
using System;

public partial class CampaignDenoDriveSetupEdit : System.Web.UI.Page
{
    protected string editMode
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

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                DailyDenoCampaignEnt CampaignInfo = DailyDenoCampaignDAL.GetItemList(Id)[0];
                txtCampainName.Text = CampaignInfo.CampaignName;
                txtCampainStartDate.Text = CampaignInfo.CampaignStartDate.ToString("dd-MM-yyyy");
                txtCampainEndDate.Text = CampaignInfo.CampaignEndDate.ToString("dd-MM-yyyy");
                txtUpperCap.Text = CampaignInfo.UpperCap.ToString();
                btnSave.Visible = Permissions.CampaignDenoAdd;
            }

            if (!string.IsNullOrEmpty(Request["mode"]))
            {
                editMode = Request["mode"];
            }
        }
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
                    if (CampaignDuration <= 10)
                    {
                        int ErrorCode = SaveData();
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
                        MsgUtility.msgCommon(this, lblMsg, " Max campaign duration is 10 days.");
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
        txtCampainName.Text = txtCampainStartDate.Text = txtCampainEndDate.Text = txtUpperCap.Text = String.Empty;
    }

    private int SaveData()
    {
        try
        {
            DailyDenoCampaign2 CampaignInfo = new DailyDenoCampaign2();
            CampaignInfo.CampaignID = Id;
            CampaignInfo.CampaignName = txtCampainName.Text.Trim();
            CampaignInfo.UpperCap = int.Parse(txtUpperCap.Text.Trim());
            CampaignInfo.CampaignStartDate = String.IsNullOrEmpty(txtCampainStartDate.Text) ? default(DateTime) : DateTime.Parse(txtCampainStartDate.Text);
            CampaignInfo.CampaignEndDate = String.IsNullOrEmpty(txtCampainEndDate.Text) ? default(DateTime) : DateTime.Parse(txtCampainEndDate.Text);

            CampaignInfo.CampaignName = CampaignInfo.CampaignName + "_from_" + CampaignInfo.CampaignStartDate.ToString("dd_MMM_yy") + "_to_" + CampaignInfo.CampaignEndDate.ToString("dd_MMM_yy");

            CampaignInfo.CreateBy = LoginInfo.Current.UserId;
            return DailyDenoCampaignDAL.SaveItem(CampaignInfo, "I");
        }
        catch (Exception EX)
        {
            throw EX;
        }

    }

}