using SalesCom.DAL;
using SalesCom.Entity;
using System;

public partial class SetupActivityAdd : System.Web.UI.Page
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
            if (!Permissions.ActivityAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            editMode = "add";
            Id = -1;
            Common.PopulatePeriodType(ddlPeriodtypeID);
            Common.AddSelectOne(ddlPeriodtypeID);
            Common.PopulateAmountType(ddlActivityAmountType);
            Common.AddSelectOne(ddlActivityAmountType);

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                ActivityEnt ActivityInfo = ActivityDAL.GetItemList(Id)[0];
                txtActivityName.Text = ActivityInfo.ActivityName;
                ddlActivityAmountType.SelectedValue = ActivityInfo.ActivityAmountType.ToString();
                ddlPeriodtypeID.SelectedValue = ActivityInfo.PeriodtypeID.ToString();
                txtEffectiveDate.Text = ActivityInfo.EffectiveDate.ToString("dd-MM-yyyy");
                txtExpiryDate.Text = ActivityInfo.ExpiryDate.ToString("dd-MM-yyyy");
                btnSave.Visible = Permissions.ActivityAdd;
            }

            if (!string.IsNullOrEmpty(Request["mode"]))
            {
                editMode = Request["mode"];
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int ErrorCode = SaveData();
        MsgUtility.msg(editMode, ErrorCode, "Activity Information", this, lblMsg, txtActivityName.Text);
        if (editMode == "add")
        {
            if (ErrorCode >= 0)
            {
                ClearData();
            }
        }
    }

    private void ClearData()
    {
        editMode = "add";
        Id = -1;
        txtActivityName.Text = txtEffectiveDate.Text = txtExpiryDate.Text = String.Empty;
        ddlPeriodtypeID.SelectedIndex = -1;
        ddlActivityAmountType.SelectedIndex = -1;

    }

    private int SaveData()
    {
        Activity2 ActivityInfo = new Activity2();
        ActivityInfo.ActivityID = Id;
        ActivityInfo.ActivityName = txtActivityName.Text.Trim();
        ActivityInfo.ActivityAmountType = int.Parse(ddlActivityAmountType.SelectedValue);
        ActivityInfo.PeriodtypeID = int.Parse(ddlPeriodtypeID.SelectedValue);
        ActivityInfo.EffectiveDate = String.IsNullOrEmpty(txtEffectiveDate.Text) ? default(DateTime) : DateTime.Parse(txtEffectiveDate.Text);
        ActivityInfo.ExpiryDate = String.IsNullOrEmpty(txtExpiryDate.Text) ? default(DateTime) : DateTime.Parse(txtExpiryDate.Text);
        

        if (editMode == "edit")
        {
            ActivityInfo.UpdateBy = LoginInfo.Current.UserId;
            return ActivityDAL.SaveItem(ActivityInfo, "U");
        }
        else
        {
            ActivityInfo.CreateBy = LoginInfo.Current.UserId;
            return ActivityDAL.SaveItem(ActivityInfo, "I");
        }
    }

}