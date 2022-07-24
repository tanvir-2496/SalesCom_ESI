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
            if (!Permissions.CommissionCycleAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            editMode = "add";
            Id = -1;

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                CommissionCycleEnt commissionCycle = CommissionCycleDAL.GetItemList(Id)[0];
                txtDescription.Text = commissionCycle.CycleDescription;
                txtPeriodStartDate.Text = commissionCycle.PeriodStartDate.ToString("dd-MM-yyyy");
                txtPeriodEndDate.Text = commissionCycle.PeriodEndDate.ToString("dd-MM-yyyy");
                ddlCycleStatusId.SelectedValue = commissionCycle.CycleStatusId == 1 ? "1" : "2";
                btnSave.Visible = Permissions.CommissionCycleAdd;
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
        MsgUtility.msg(editMode, ErrorCode, "Commission Cycle Information", this, lblMsg, txtDescription.Text);
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
        txtDescription.Text = txtPeriodEndDate.Text = txtPeriodStartDate.Text = String.Empty;
        ddlCycleStatusId.SelectedIndex = 0;
    }

    private int SaveData()
    {

        CommissionCycle2 commissionCycle = new CommissionCycle2();
        commissionCycle.CycleId = Id;
        commissionCycle.CycleDescription = txtDescription.Text.Trim();
        commissionCycle.PeriodStartDate = DateTime.Parse(txtPeriodStartDate.Text);
        commissionCycle.PeriodEndDate = DateTime.Parse(txtPeriodEndDate.Text);
        if (ddlCycleStatusId.SelectedIndex > 0)
            commissionCycle.CycleStatusId = int.Parse(ddlCycleStatusId.SelectedValue);
        else
            commissionCycle.CycleStatusId = 2;

        if (editMode == "edit")
        {
            commissionCycle.UpdateBy = LoginInfo.Current.UserId;
            return CommissionCycleDAL.SaveItem(commissionCycle, "U");
        }
        else
        {
            commissionCycle.CreateBy = LoginInfo.Current.UserId;
            return CommissionCycleDAL.SaveItem(commissionCycle, "I");
        }

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //SegmentEnt obj = new SegmentEnt();
        //obj.SegmentID = Id;
        //obj.SegmentName = txtSegmentName.Text;
        //obj.SegmentTypeID = int.Parse(ddlSegmentType.SelectedValue);
        ////   obj.EventValidationID = -1;
        //int ErrorCode = SegmentDAL.SaveItem(obj, "I");
        //if (ErrorCode <= -1)
        //    lblMsg.Text = "Data Can not Add !!";
        //else
        //{
        //    lblMsg.Text = "Data Add Successful!!";
        //}

    }

}