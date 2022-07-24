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
            if (!Permissions.AdhocReportView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
        }
    }

    private void BindData()
    {
        List<AdHocReportEnt> list = AdHocReportDAL.GetItemList(0).OrderBy(x => x.report_name).ToList();
        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        BindData();
        pager.SetPageProperties(0, pager.MaximumRows, false);

    }
}