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

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Permissions.ChannelView)
        {
            MsgUtility.showNotPermittedMsg(this.Page);
            return;
        }
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {

    }
}