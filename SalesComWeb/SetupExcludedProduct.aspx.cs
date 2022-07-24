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
        BindData();
    }
    int counter;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Permissions.ExcludedProductsView)
        {
            MsgUtility.showNotPermittedMsg(this.Page);
            return;
        }
    }

    private void BindData()
    {
        List<ExcludedProductEnt> list = ExcludedProductDAL.GetItemList(0);

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