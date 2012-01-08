using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Common;
using GK2010.Utility;
namespace GK2010.Web
{
    public partial class register_step3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Text = ConfigParam.Email;
        }
    }
}
