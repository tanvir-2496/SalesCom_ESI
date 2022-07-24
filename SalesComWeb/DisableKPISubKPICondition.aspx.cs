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

public partial class DisableKPISubKPICondition : System.Web.UI.Page
{
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

        lvSubKPIView.DataSource = null;
        lvSubKPIView.DataBind();

        lvConditionView.DataSource = null;
        lvConditionView.DataBind();
    }

    protected void LoadListView()
    {
        try 
        {
            lblMsg.Text = "";
            ClearAllDropdown();

            int salesGroupId = int.Parse(ddlSalesGroup.SelectedValue);
            int searchType = 0;
            try { searchType = Convert.ToInt16(rblSearchType.SelectedValue); }
            catch (Exception ex) { }
            string searchName = txtSeachName.Text;

            if (salesGroupId == 0)
            {
                lblMsg.Font.Bold = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Please select Sales Group";
            }
            else if (searchType == 0)
            {
                lblMsg.Font.Bold = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Please select search Type";
            }
            else if (searchType == 1)
            {
                DataTable list = ESI_KPIDAL.GetItemListActiveInactive(salesGroupId, searchType, searchName);
                lvKPIView.DataSource = list;
                lvKPIView.DataBind();
            }
            else if (searchType == 2)
            {
                DataTable list = ESI_KPIDAL.GetItemListActiveInactive(salesGroupId, searchType, searchName);
                lvSubKPIView.DataSource = list;
                lvSubKPIView.DataBind();
            }
            else if (searchType == 3)
            {
                DataTable list = ESI_KPIDAL.GetItemListActiveInactive(salesGroupId, searchType, searchName);
                lvConditionView.DataSource = list;
                lvConditionView.DataBind();
            }
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
        LoadListView();
    }


    protected void btnActivateKPI_Click(object sender, EventArgs e)
    {
        try{
            Button btnLoad = sender as Button;
            int kpi_id = Convert.ToInt16(btnLoad.CommandArgument.ToString());
            ESI_KPIDAL.SaveKPISubKPIConditionStatus(1, kpi_id, 1);
            LoadListView();
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = ex.Message;
        }
    }

    protected void btnDeactivateKPI_Click(object sender, EventArgs e)
    {
        try{
            Button btnLoad = sender as Button;
            int kpi_id = Convert.ToInt16(btnLoad.CommandArgument.ToString());
            ESI_KPIDAL.SaveKPISubKPIConditionStatus(1, kpi_id, 0);
            LoadListView();
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = ex.Message;
        }
    }

    protected void btnActivateSubKPI_Click(object sender, EventArgs e)
    {
        try{
            Button btnLoad = sender as Button;
            int subkpi_id = Convert.ToInt16(btnLoad.CommandArgument.ToString());
            ESI_KPIDAL.SaveKPISubKPIConditionStatus(2, subkpi_id, 1);
            LoadListView();
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = ex.Message;
        }
    }

    protected void btnDeactivateSubKPI_Click(object sender, EventArgs e)
    {
        try{
            Button btnLoad = sender as Button;
            int subkpi_id = Convert.ToInt16(btnLoad.CommandArgument.ToString());
            ESI_KPIDAL.SaveKPISubKPIConditionStatus(2, subkpi_id, 0);
            LoadListView();
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = ex.Message;
        }
    }

    protected void btnActivateCondition_Click(object sender, EventArgs e)
    {
        try{
            Button btnLoad = sender as Button;
            int condition_id = Convert.ToInt16(btnLoad.CommandArgument.ToString());
            ESI_KPIDAL.SaveKPISubKPIConditionStatus(3, condition_id, 1);
            LoadListView();
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = ex.Message;
        }
    }

    protected void btnDeactivateCondition_Click(object sender, EventArgs e)
    {
        try
        {
            Button btnLoad = sender as Button;
            int condition_id = Convert.ToInt16(btnLoad.CommandArgument.ToString());
            ESI_KPIDAL.SaveKPISubKPIConditionStatus(3, condition_id, 0);
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