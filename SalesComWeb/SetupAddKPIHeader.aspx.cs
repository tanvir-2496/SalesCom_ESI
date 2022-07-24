using SalesCom.DAL;
using ESI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESI.DAL;

public partial class SetupAddKPIHeader : System.Web.UI.Page
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
            MsgUtility.msg("HearderAdd", ErrorCode, "Hearder Add Information", this, lblMsg, txtKpiName.Text);
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
        ddlSalesGroup.SelectedValue = "0";
    }

    private int SaveData()
    {
        try
        {
            int salesGroupId = Convert.ToInt32(ddlSalesGroup.SelectedValue);
            string kpiHeaderName = txtKpiName.Text.Trim();
            return ESI.DAL.ESI_ManualDataDAL.SaveESIManualDataHeader(salesGroupId, kpiHeaderName);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }
}