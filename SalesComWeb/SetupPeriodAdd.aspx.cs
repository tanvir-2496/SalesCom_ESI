using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            if (!Permissions.PeriodAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            editMode = "add";
            Id = -1;

            Common.PopulatePeriodType(ddlPeriodTypeId);
            Common.AddSelectOne(ddlPeriodTypeId);

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                PeriodEnt PeriodInfo = PeriodDAL.GetItemList(Id)[0];
                ddlPeriodTypeId.SelectedValue = PeriodInfo.PeriodTypeId.ToString();
                txtStartDate.Text = PeriodInfo.StartDate.ToString("dd-MM-yyyy");
                txtEndDate.Text = PeriodInfo.EndDate.ToString("dd-MM-yyyy");
                ddlMonth.SelectedValue = (PeriodInfo.Month == null || PeriodInfo.Month == String.Empty) ? "SELECT" : PeriodInfo.Month.ToString();
                txtPeriodDate.Text = PeriodInfo.PeriodDate.ToString("dd-MM-yyyy");
                btnSave.Visible = Permissions.PeriodAdd;
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
        MsgUtility.msg(editMode, ErrorCode, "Period Information", this, lblMsg, "Period");
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
        ddlPeriodTypeId.SelectedIndex = -1;
        ddlMonth.SelectedIndex = -1;
        txtStartDate.Text = txtEndDate.Text = txtPeriodDate.Text = String.Empty;

    }

    private int SaveData()
    {

        PeriodEnt PeriodInfo = new PeriodEnt();
        PeriodInfo.PeriodId = Id;
        PeriodInfo.PeriodTypeId = int.Parse(ddlPeriodTypeId.SelectedValue);
        PeriodInfo.StartDate = DateTime.Parse(txtStartDate.Text);
        PeriodInfo.EndDate = DateTime.Parse(txtEndDate.Text);
        PeriodInfo.Month = ddlMonth.SelectedValue == "SELECT" ? String.Empty : ddlMonth.SelectedValue;
        PeriodInfo.PeriodDate = DateTime.Parse(txtPeriodDate.Text);


        if (editMode == "edit")
        {
            return PeriodDAL.SaveItem(PeriodInfo, "U");
        }
        else
        {
            return PeriodDAL.SaveItem(PeriodInfo, "I");
        }

    }


}