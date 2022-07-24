using SalesCom.DAL;
using System;
using System.Data;
using System.IO;

public partial class SetupActivity : System.Web.UI.Page
{


    protected Int32 ReportId
    {
        get { return (Int32)ViewState["ReportId"]; }
        set { ViewState["ReportId"] = value; }
    }

    protected Int32 CycleId
    {
        get { return (Int32)ViewState["CycleId"]; }
        set { ViewState["CycleId"] = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.Page.IsPostBack)
        {

            crvDigitalApproval.HasToggleGroupTreeButton = false;
            crvDigitalApproval.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
            crvDigitalApproval.HasToggleParameterPanelButton = false;



            if (!String.IsNullOrEmpty(Request["reportId"]) && !String.IsNullOrEmpty(Request["cycleId"]))
            {
                ReportId = Int32.Parse(Request["reportId"]);
                CycleId = Int32.Parse(Request["cycleId"]);

                DataTable dt = DigitalApprovalDAL.GetDigitalApproval(ReportId, CycleId);
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

}