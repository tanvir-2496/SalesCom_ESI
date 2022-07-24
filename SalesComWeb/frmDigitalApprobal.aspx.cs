using CrystalDecisions.Web;
using SalesCom.DAL;
using System;
using System.Data;
using System.IO;

public partial class SetupActivity : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:refreshWindow(); ", true);
        Common.PopulateCommissionReportId(ddlReportName);
        Common.AddSelectOne(ddlReportName);
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        if (this.Page.IsPostBack)
        {
            if (ddlReportName.SelectedIndex > 0 && ddlReportCycle.SelectedIndex > 0)
            {
                DataTable dt = DigitalApprovalDAL.GetDigitalApproval(Int32.Parse(ddlReportName.SelectedValue), Int32.Parse(ddlReportCycle.SelectedValue));
                this.errorMessage.Text = String.Empty;
                string reportPath = "Reports/crDigitalApproval.rpt";

                if (File.Exists(Server.MapPath(reportPath)))
                {
                    this.crsDigitalApproval.ReportDocument.SetDataSource(dt);
                    this.crvDigitalApproval.ReportSourceID = "crsDigitalApproval";
                    this.crvDigitalApproval.RefreshReport();
                }
                else
                {
                    this.errorMessage.Text = String.Format("Report at {} not found!", reportPath);
                }
            }


        }
    }

    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReportName.SelectedIndex > 0)
        {
            Common.PopulateCommissionCycleByReportId(ddlReportCycle, int.Parse(ddlReportName.SelectedValue));
            Common.AddSelectOne(ddlReportCycle);
        }
        else
        {
            ddlReportCycle.Items.Clear();
        }
    }
}