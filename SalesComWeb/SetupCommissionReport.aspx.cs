using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Linq;
using System.Collections.Generic;

public partial class SetupActivity : System.Web.UI.Page
{
    protected void pager_PreRender(object sender, EventArgs e)
    {
        BindData();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (!Permissions.CommissionReportView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
        }
    }

    private void BindData()
    {
        List<CommissionReportConciseEnt> list = CommissionReportDAL.GetItemList(0);
        var records = list.Where(t => t.ReportName.ToLower().Contains(search_textbox.Text.Trim().ToString().ToLower())).OrderBy(x => x.ReportName).ToList();
        lv.DataSource = records;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", records.Count);
        pager.Visible = records.Count > pager.PageSize;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindData();
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        BindData();
        pager.SetPageProperties(0, pager.MaximumRows, false);

    }
}