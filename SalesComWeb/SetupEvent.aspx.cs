using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupActivity : System.Web.UI.Page
{
    protected void pager_PreRender(object sender, EventArgs e)
    {
        //BindData(String.Empty, 0, 0);
        BindData(String.Empty, int.Parse(ddlChannelType.SelectedValue), int.Parse(ddlReportName.SelectedValue));
        lblNotFound.Text = String.Empty;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!Permissions.EventView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            Common.PopulateChannelType(ddlChannelType);
            Common.AddSelectAll(ddlChannelType);
            Common.PopulateCommissionReportId(ddlReportName);
            Common.AddSelectAll(ddlReportName);
        }
    }

    private void BindData(string eventName, int channelTypeId, int reportId)
    {
        List<EventEnt> list = new List<EventEnt>(); ;
        if (channelTypeId == 0 && String.IsNullOrEmpty(eventName) && reportId == 0)
        {
            list = EventDAL.GetItemList(0);
        }
        else
        {
            list = EventDAL.GetItemList(0, channelTypeId, eventName, reportId);
        }

        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        //BindData(String.Empty, 0, 0);
        //pager.SetPageProperties(0, pager.MaximumRows, false);
        BindData(String.Empty, int.Parse(ddlChannelType.SelectedValue), int.Parse(ddlReportName.SelectedValue));
        lblNotFound.Text = String.Empty;

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(txtEventName.Text))
        {
            BindData(txtEventName.Text.ToLower().Trim(), int.Parse(ddlChannelType.SelectedValue), int.Parse(ddlReportName.SelectedValue));
            lblNotFound.Text = String.Empty;
        }
        else
        {
            lv.DataSource = null;
            lv.DataBind();
            lblResults.Text = String.Format("Total results: {0}", 0);
            pager.Visible = false;
            lblNotFound.Text = "Event Name required";
        }
    }
    protected void ddlChannelType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlChannelType.SelectedIndex > 0)
        {
            BindData(String.Empty, int.Parse(ddlChannelType.SelectedValue), int.Parse(ddlReportName.SelectedValue));
            lblNotFound.Text = String.Empty;
        }
        else
        {
            BindData(String.Empty, 0, 0);
            lblNotFound.Text = String.Empty;
        }
    }
    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReportName.SelectedIndex > 0)
        {
            BindData(String.Empty, int.Parse(ddlChannelType.SelectedValue), int.Parse(ddlReportName.SelectedValue));
            lblNotFound.Text = String.Empty;
        }
        else
        {
            BindData(String.Empty, 0, 0);
            lblNotFound.Text = String.Empty;
        }
    }
}