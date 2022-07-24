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
            if (!Permissions.SIMValidationRuleAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            
            editMode = "add";
            Id = -1;
            Common.PopulateActivity(ddlActivity);
            Common.AddSelectOne(ddlActivity);
            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                ValidationRuleEnt SimValidationRuleInfo = ValidationRuleDAL.GetItemList(Id)[0];
                txtValidationName.Text = SimValidationRuleInfo.ValidationName;
                txtEffectiveDate.Text = SimValidationRuleInfo.EffectiveDate.ToString("dd-MM-yyyy");
                txtExpireDate.Text = SimValidationRuleInfo.ExpireDate.ToString("dd-MM-yyyy");
                txtProcedure.Text = SimValidationRuleInfo.Procedure;
                chkIsActive.Checked = Convert.ToBoolean(SimValidationRuleInfo.IsActive);
                ddlActivity.SelectedValue = SimValidationRuleInfo.ActivityId.ToString();
                chkIsDynamic.Checked = SimValidationRuleInfo.IsDynamic == "Y" ? true : false;
                btnSave.Visible = Permissions.SIMValidationRuleAdd;
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
        MsgUtility.msg(editMode, ErrorCode, "Event Information", this, lblMsg, txtValidationName.Text);
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
        txtValidationName.Text = txtProcedure.Text = txtExpireDate.Text = txtEffectiveDate.Text = string.Empty;
        chkIsActive.Checked = false;
        ddlActivity.SelectedIndex = -1;
    }

    private int SaveData()
    {

        ValidationRule2 SimValidationRuleInfo = new ValidationRule2();
        SimValidationRuleInfo.ValidationRuleId = Id;
        SimValidationRuleInfo.ValidationName = txtValidationName.Text.Trim();
        SimValidationRuleInfo.EffectiveDate = DateTime.Parse(txtEffectiveDate.Text.Trim());
        SimValidationRuleInfo.ExpireDate = DateTime.Parse(txtExpireDate.Text);
        SimValidationRuleInfo.Procedure = txtProcedure.Text;
        SimValidationRuleInfo.IsActive = chkIsActive.Checked == true ? 1 : 0;
        SimValidationRuleInfo.ActivityId = int.Parse(ddlActivity.SelectedValue);
        SimValidationRuleInfo.IsDynamic = chkIsDynamic.Checked == true ? "Y" : "N";


        if (editMode == "edit")
        {
            SimValidationRuleInfo.UpdateBy = LoginInfo.Current.UserId;
            return ValidationRuleDAL.SaveItem(SimValidationRuleInfo, "U");
        }
        else
        {
            SimValidationRuleInfo.CreateBy = LoginInfo.Current.UserId;
            return ValidationRuleDAL.SaveItem(SimValidationRuleInfo, "I");
        }

    }


}