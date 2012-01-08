using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web
{
    public partial class register_step2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Text = ConfigParam.Email;
            HL.NavigateUrl = StringHelper.EmailSuffix(ConfigParam.Email);
        }

       
    }
}
