using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EJ_Enterprise_MANAGEMENT_SYSTEM
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogoutLink_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("logIn.aspx");
        }
    }
}