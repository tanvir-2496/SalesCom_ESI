using SalesCom.DAL;
using ESI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESI.DAL;

public partial class SetupKpiAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!Permissions.ESISetupKpiAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            var userId = LoginInfo.Current.UserId;
            Common.PopulateSalesGroup(ddlSalesGroup, userId);
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int ErrorCode = SaveData();
            MsgUtility.msg(ErrorCode, "KPI Information", this, lblMsg, txtKpiName.Text);
        
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
        txtKpiName.Text = String.Empty;
        txtKpiRemarks.Text = String.Empty;
        txtDisplayName.Text = String.Empty;
    }

    private int SaveData()
    {
        try
        {
            KPIEnt kpiInfo = new KPIEnt();
            kpiInfo.Kpi_Name = txtKpiName.Text.Trim();
            kpiInfo.Display_Name = String.Join("_", txtDisplayName.Text.Trim().Split(' '));
            kpiInfo.Kpi_Type = 1;
            kpiInfo.Is_Active = 1;
            kpiInfo.Is_Financial = Convert.ToInt32(ddlIsFinancial.SelectedValue);
            kpiInfo.Is_Source_Manual = 1;
            kpiInfo.Created_By = LoginInfo.Current.UserId;
            kpiInfo.Created_Date = DateTime.Now;
            kpiInfo.Remarks = txtKpiRemarks.Text.Trim();
            kpiInfo.Sales_Group_Id = Convert.ToInt32(ddlSalesGroup.SelectedValue);
            //SessionData.getUserSalesGroup().SALES_GROUP_ID;

            return ESI_KPIDAL.SaveItem(kpiInfo);
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
        
    }
}