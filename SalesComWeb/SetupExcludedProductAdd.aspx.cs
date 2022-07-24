using SalesCom.DAL;
using SalesCom.Entity;
using System;

public partial class SetupExcludedProductAdd : System.Web.UI.Page
{
    protected string editMode
    {
        get { return ViewState["editMode"].ToString(); }
        set { ViewState["editMode"] = value; }
    }

    protected int Id
    {
        get { return (int)ViewState["Id"]; }
        set { ViewState["Id"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.ExcludedProductsAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            editMode = "add";
            Id = -1;

            Common.PopulateProductDetail(ddlProductDetail);
            Common.AddSelectOne(ddlProductDetail);
            Common.PopulateCommissionReportId(ddlReportName);
            Common.AddSelectOne(ddlReportName);
            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                ExcludedProductEnt excludedProduct = ExcludedProductDAL.GetItemList(Id)[0];
                ddlReportName.SelectedValue = excludedProduct.ReportId.ToString();
                ddlProductDetail.SelectedValue = excludedProduct.ProductId.ToString();
                btnSave.Visible = Permissions.ExcludedProductsAdd;
            }


            if (!string.IsNullOrEmpty(Request["mode"]))
            {
                editMode = Request["mode"];
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int ErrorCode = SaveData();
        MsgUtility.msg(editMode, ErrorCode, "Event Information", this, lblMsg, ddlReportName.Text);
        if (editMode == "add")
        {
            if (ErrorCode >= 0)
            {
                ClearData();
            }
        }
    }

    private void ClearData()
    {
        editMode = "add";
        Id = -1;
        ddlReportName.SelectedIndex = ddlProductDetail.SelectedIndex = -1;
    }

    private int SaveData()
    {
        ExcludedProductEnt excludedProduct = new ExcludedProductEnt();
        excludedProduct.ExcludedProductId = Id;

        excludedProduct.ProductId = int.Parse(ddlProductDetail.SelectedValue);
        excludedProduct.ReportId = int.Parse(ddlReportName.SelectedValue);


        if (editMode == "edit")
        {
            return ExcludedProductDAL.SaveItem(excludedProduct, "U");
        }
        else
        {
            return ExcludedProductDAL.SaveItem(excludedProduct, "I");
        }

    }

}