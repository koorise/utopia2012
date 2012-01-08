using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GK2010.Web
{
    public partial class loginOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GK2010.Common.LoginHelper.LoginOut();
            Response.Redirect("/");
        }
    }
}
