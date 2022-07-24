using ESI.DAL;
using ESI.Entity;
using ESI.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupConditionAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!Permissions.ESISetupConditionAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            var userId = LoginInfo.Current.UserId;
            Common.PopulateSalesGroup(ddlSalesGroup, userId);

            //Common.PopulateKpiList(ddlKpiName);
        }
    }
    protected void ddl_SalesGroup_IndexChanged(object sender, EventArgs e)
    {
        Common.PopulateKpiList(ddlKpiName,Convert.ToInt32(ddlSalesGroup.SelectedValue));
        //Common.PopulateSalesChannel(ddlSalesChannel, Convert.ToInt32(ddlSalesGroup.SelectedValue));
    }
    protected void ddlKpiName_SelectedIndexChanged(object sender, EventArgs e)
    {
        int kpiId = Convert.ToInt32(ddlKpiName.SelectedValue);
        Common.PopulateSubKpiList(ddlSubKpiName, kpiId);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int ErrorCode = SaveData();
            MsgUtility.msg(ErrorCode, "Condition Information", this, lblMsg, txtConditionName.Text);

            if (ErrorCode >= 0)
            {
                ClearData();
            }
        }
        catch (ArgumentException ex)
        {
            MsgUtility.msg(400, "Provide Unique Data", this, lblMsg);
        }
        catch (Exception ex)
        {
            MsgUtility.msg(400, ex.Message, this, lblMsg);
        }
        
    }

    private void ClearData()
    {
        ddlKpiName.SelectedIndex = -1;
        ddlSubKpiName.SelectedIndex = -1;
        txtConditionName.Text = String.Empty;
        txtConditionRemarks.Text = String.Empty;
        txtDisplayName.Text = String.Empty;
    }

    private int SaveData()
    {
        try
        {
            ConditionViewModel conditionInfo = new ConditionViewModel();

            if (Convert.ToInt32(ddlSubKpiName.SelectedIndex) == 0)
            {
                conditionInfo.Kpi_id = Convert.ToInt32(ddlKpiName.SelectedValue);
            }
            else
            {
                conditionInfo.Kpi_id = Convert.ToInt32(ddlSubKpiName.SelectedValue);
            }
            conditionInfo.Condition_Name = txtConditionName.Text.Trim();
            conditionInfo.Display_Name = String.Join("_", txtDisplayName.Text.Trim().Split(' '));
            conditionInfo.Remarks = txtConditionRemarks.Text.Trim();
            conditionInfo.Is_Active = 1;
            conditionInfo.Created_By = LoginInfo.Current.UserId;
            conditionInfo.Created_Date = DateTime.Now;

            return ESI_KPIDAL.SaveCondition(conditionInfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }

}