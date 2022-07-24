using ESI.DAL;
using ESI.Entity;
using ESI.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisableKPIHeader : System.Web.UI.Page
{
    protected void pager_PreRender(object sender, EventArgs e)
    {
        LoadListView();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ClearAllDropdown();

        if (!this.Page.IsPostBack)
        {
            if (!Permissions.ESISetupConditionAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            var userId = LoginInfo.Current.UserId;
            Common.PopulateSalesGroup(ddlSalesGroup, userId);
        }
        else 
        {
            LoadListView();
        }
        
    }

    protected void ClearAllDropdown()
    {
        lvKPIView.DataSource = null;
        lvKPIView.DataBind();
    }

    protected void LoadListView()
    {
        try
        {
            lblMsg.Text = "";
            ClearAllDropdown();
            int salesGroupId = int.Parse(ddlSalesGroup.SelectedValue);
            string kpiHeaderName = txtSeachName.Text.Trim();
            DataTable list = ESI_ManualDataDAL.GetManualDataHeader(salesGroupId, kpiHeaderName);
            lvKPIView.DataSource = list;
            lvKPIView.DataBind();
            lblResults.Text = String.Format("Total results: {0}", list.Rows.Count);
            pager.Visible = list.Rows.Count > pager.PageSize;
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = ex.Message;
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (int.Parse(ddlSalesGroup.SelectedValue) == 0)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Please Select a Sales Group";
        }
        else
        {
            LoadListView();
        }
    }

    protected void btnDeactivateKPI_Click(object sender, EventArgs e)
    {
        try{
            Button btnLoad = sender as Button;
            int kpi_id = Convert.ToInt16(btnLoad.CommandArgument.ToString());
            int result = ESI_ManualDataDAL.UpdateESIManualDataHeader(kpi_id, 0);
            LoadListView();
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = ex.Message;
        }
    }
    protected void btnActivateKPI_Click(object sender, EventArgs e)
    {
        try{
            Button btnLoad = sender as Button;
            int kpi_id = Convert.ToInt16(btnLoad.CommandArgument.ToString());
            int result = ESI_ManualDataDAL.UpdateESIManualDataHeader(kpi_id, 1);
            LoadListView();
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = ex.Message;
        }
    }
}