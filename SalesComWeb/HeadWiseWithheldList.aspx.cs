using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;

public partial class HeadWiseWithheldList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Permissions.HeadWiseWithheldList)
        {
            MsgUtility.showNotPermittedMsg(this.Page);
            return;
        }

        if (!IsPostBack)
        {
            BindDummyRow();
        }
    }

    private void BindDummyRow()
    {
        DataTable dummy = new DataTable();
        dummy.Columns.Add("row_number");
        dummy.Columns.Add("reportname");
        dummy.Columns.Add("commission_month");
        dummy.Columns.Add("publish_month");
        dummy.Columns.Add("report_duration");
        dummy.Columns.Add("withheld_amount");
        dummy.Rows.Add();
        gvWithheldList.DataSource = dummy;
        gvWithheldList.DataBind();
    }

    [System.Web.Services.WebMethod(Description = "Get distributor wise withheld list")]
    public static List<HeadWiseWithheldListEnt> BindData(string distributorCode, int pageIndex)
    {
        return HeadWiseWithheldListDAL.Get_Withheld_Com_Head_Wise(distributorCode, pageIndex);
    }

}