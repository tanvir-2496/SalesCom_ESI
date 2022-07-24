
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SalesCom.DAL;

using System.Collections;
using System.Data.OracleClient;
using System.DirectoryServices;
using System.Web.Security;
using ESI.DAL;
using System.Drawing;


public partial class CdpReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!Permissions.CdpReport)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            ddlReportname.DataSource = Get_CDP_Report_List();
            ddlReportname.DataTextField = "report_name";
            ddlReportname.DataValueField = "cdp_report_info_id";
            ddlReportname.DataBind();
            ddlReportname.Items.Insert(0, new ListItem("---Select----", "-1"));
        }
    }



    public List<CdpReportListEntity> Get_CDP_Report_List()
    {
        List<CdpReportListEntity> lstEntity = new List<CdpReportListEntity>();
        using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["SalesComConnectionString"].ToString()))
      
        using (OracleCommand cmd = new OracleCommand("CDP_GET_REPORT_LIST", connection))
        {
            OracleParameter param = new OracleParameter("PO_CURSOR", OracleType.Cursor);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);

            //OracleParameter param1 = new OracleParameter("PO_ERRORCODE", OracleType.Number);
            //param1.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(param1);

            //OracleParameter param2 = new OracleParameter("PO_ERRORMESSAGE", OracleType.VarChar, 100);
            //param2.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(param2);

      
          
                cmd.CommandType = CommandType.StoredProcedure;
                 connection.Open();
         
        using(OracleDataReader reader=cmd.ExecuteReader())
        {
            while(reader.Read())
            {
                CdpReportListEntity entity = new CdpReportListEntity();
                entity.cdp_report_info_id = Convert.ToInt32(reader["cdp_report_info_id"].ToString());
                entity.report_name = reader["report_name"].ToString();
                lstEntity.Add(entity);
            }
            connection.Close();
        }
        return lstEntity;   
        }      
    }

    private DateTime GetDateFromTextField(string textfieldContent)
    {
        DateTime datetimevalue = DateTime.Parse("01/01/2010");
        if (textfieldContent == null) 
        {
            return datetimevalue;        
        }
        else if (textfieldContent == "")
        {
            return datetimevalue;
        }
        try
        {
            datetimevalue = DateTime.Parse(textfieldContent);
        }
        catch(Exception ex) 
        {
            return datetimevalue;        
        }
        return datetimevalue;
    }

    protected void pager_PreRender(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            DateTime fDate = GetDateFromTextField(txtFromDate.Text);
            DateTime tDate = GetDateFromTextField(txtToDate.Text);
            DateTime disburseFromDate = GetDateFromTextField(txtDisburseFromDate.Text);
            DateTime disbursetoDate = GetDateFromTextField(txtDisburseToDate.Text);
            int rName = Convert.ToInt32(ddlReportname.SelectedValue);
            string rType = Convert.ToString(ddlReportType.SelectedValue);
            BindData(fDate, tDate, disburseFromDate, disbursetoDate, rName, rType);
        }

    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        DateTime fDate = GetDateFromTextField(txtFromDate.Text);
        DateTime tDate = GetDateFromTextField(txtToDate.Text);
        DateTime disburseFromDate = GetDateFromTextField(txtDisburseFromDate.Text);
        DateTime disbursetoDate = GetDateFromTextField(txtDisburseToDate.Text);
        int rName = Convert.ToInt32(ddlReportname.SelectedValue);
        string rType = Convert.ToString(ddlReportType.SelectedValue);
        BindData(fDate, tDate, disburseFromDate, disbursetoDate, rName, rType);
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        DateTime fDate = GetDateFromTextField(txtFromDate.Text);
        DateTime tDate = GetDateFromTextField(txtToDate.Text);
        DateTime disburseFromDate = GetDateFromTextField(txtDisburseFromDate.Text);
        DateTime disbursetoDate = GetDateFromTextField(txtDisburseToDate.Text);
        int rName = Convert.ToInt32(ddlReportname.SelectedValue);
        string rType = Convert.ToString(ddlReportType.SelectedValue);
        DataTable dt_excel = ReportData(fDate, tDate, disburseFromDate, disbursetoDate, rName, rType);
        try
        {
            Common.ExportToExcel(dt_excel, String.Format("Commission_DisbursementData_{0}_{1}", "", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));  
        }
        catch (Exception ex)
        {
            this.lblResults.Text = ex.Message;
        }
    }

    private void BindData(DateTime startDate, DateTime endDate, DateTime disburseFromDate, DateTime disbursetoDate, int rName, string rType)
    {
        List<CdpReportEntity> list = new List<CdpReportEntity>();
        list = GetCdpReport(startDate, endDate, disburseFromDate, disbursetoDate, rName, rType);
        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;

    }


    public static DataTable ReportData(DateTime startDate, DateTime endDate, DateTime disburseFromDate, DateTime disbursetoDate, int rName, string rType)
    {     
        using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["SalesComConnectionString"].ToString()))

        using (OracleCommand cmd = new OracleCommand("CDP_GET_REPORT", connection))
        {            
            OracleParameter param1 = new OracleParameter("P_CDP_REPORT_INFO_ID", OracleType.Number);
            param1.Value = rName;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);

            OracleParameter param2 = new OracleParameter("P_response_status", OracleType.VarChar);
            param2.Value = rType;
            param2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param2);

            OracleParameter param3 = new OracleParameter("P_FROMDATE", OracleType.DateTime);
            param3.Value = startDate;
            param3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param3);

            OracleParameter param4 = new OracleParameter("P_TODATE", OracleType.DateTime);
            param4.Value = endDate;
            param4.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param4);

            OracleParameter param5 = new OracleParameter("P_DISBURSEFROMDATE", OracleType.DateTime);
            param5.Value = disburseFromDate;
            param5.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param5);

            OracleParameter param6 = new OracleParameter("P_DISBURSETODATE", OracleType.DateTime);
            param6.Value = disbursetoDate;
            param6.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param6);


            OracleParameter param7 = new OracleParameter("PO_ERRORCODE", OracleType.Number);
            param7.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param7);

            OracleParameter param8 = new OracleParameter("PO_ERRORMESSAGE", OracleType.VarChar, 100);
            param8.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param8);

            OracleParameter param9 = new OracleParameter("PO_CURSOR", OracleType.Cursor);
            param9.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param9);

            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            DataTable dt = new DataTable("CDP_GET_REPORT");

            using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
            {            
                adapter.Fill(dt);
            }
            connection.Close();
            return dt;
        }      
    }


    public static List<CdpReportEntity> GetCdpReport(DateTime startDate, DateTime endDate, DateTime disburseFromDate, DateTime disbursetoDate, int rName, string rType)
    {
        List<CdpReportEntity> lstEntity = new List<CdpReportEntity>();
        using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["SalesComConnectionString"].ToString()))

        using (OracleCommand cmd = new OracleCommand("CDP_GET_REPORT", connection))
        {
            OracleParameter param1 = new OracleParameter("P_CDP_REPORT_INFO_ID", OracleType.Number);
            param1.Value = rName;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);

            OracleParameter param2 = new OracleParameter("P_response_status", OracleType.VarChar);
            param2.Value = rType;
            param2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param2);

            OracleParameter param3 = new OracleParameter("P_FROMDATE", OracleType.DateTime);
            param3.Value = startDate;
            param3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param3);

            OracleParameter param4 = new OracleParameter("P_TODATE", OracleType.DateTime);
            param4.Value = endDate;
            param4.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param4);

            OracleParameter param5 = new OracleParameter("P_DISBURSEFROMDATE", OracleType.DateTime);
            param5.Value = disburseFromDate;
            param5.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param5);

            OracleParameter param6 = new OracleParameter("P_DISBURSETODATE", OracleType.DateTime);
            param6.Value = disbursetoDate;
            param6.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param6);


            OracleParameter param7 = new OracleParameter("PO_ERRORCODE", OracleType.Number);
            param7.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param7);

            OracleParameter param8 = new OracleParameter("PO_ERRORMESSAGE", OracleType.VarChar, 100);
            param8.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param8);

            OracleParameter param9 = new OracleParameter("PO_CURSOR", OracleType.Cursor);
            param9.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param9);
         
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    CdpReportEntity entity = new CdpReportEntity();
                    if (reader["RETAILER_CODE"] == DBNull.Value)
                    {
                        entity.RETAILER_CODE = null;
                    }
                    else
                    {
                        entity.RETAILER_CODE = reader["RETAILER_CODE"].ToString();
                    }
                    if (reader["TOPUP_MSISDN"] == DBNull.Value)
                    {
                        entity.TOPUP_MSISDN = null;
                    }
                    else
                    {
                        entity.TOPUP_MSISDN = reader["TOPUP_MSISDN"].ToString();
                    }

                    if (reader["DISBURSE_AMOUNT"] == DBNull.Value)
                    {
                        entity.DISBURSE_AMOUNT = null;
                    }
                    else
                    {
                        entity.DISBURSE_AMOUNT = Convert.ToDecimal(reader["DISBURSE_AMOUNT"]);
                    }
                    if (reader["generate_date"] == DBNull.Value)
                    {
                        entity.create_date = null;
                    }
                    else
                    {
                        entity.create_date = Convert.ToDateTime(reader["generate_date"]);
                    }
                    if (reader["topup_date"] == DBNull.Value)
                    {
                        entity.disburse_date = null;
                    }
                    else
                    {
                        entity.disburse_date = Convert.ToDateTime(reader["topup_date"]);
                    }
                    if (reader["disburse_status"] == DBNull.Value)
                    {
                        entity.response_status = null;
                    }
                    else
                    {
                        entity.response_status = reader["disburse_status"].ToString();
                    }
                    if (reader["report_date"] == DBNull.Value)
                    {
                        entity.report_date = null;
                    }
                    else
                    {
                        DateTime date=Convert.ToDateTime(reader["report_date"]);
                       // entity.report_date = Convert.ToDateTime(reader["report_date"]);
                        entity.report_date = date.ToString("dd-MMM-yy");
                    }
                   
                    lstEntity.Add(entity);
                }
                connection.Close();
            }
            return lstEntity;       
        }         
    }



    public class CdpReportEntity
    {
        public string RETAILER_CODE { get; set; }
        public string TOPUP_MSISDN { get; set; }
        public Decimal? DISBURSE_AMOUNT { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? disburse_date { get; set; }
        //public string create_date { get; set; }
        //public string disburse_date { get; set; }
        public string response_status { get; set; }
        public string report_date { get; set; }
        //public DateTime? report_date { get; set; }
    }


    public class CdpReportListEntity
    {
        public Int32 cdp_report_info_id { get; set; }
        public string report_name { get; set; }
    }

}