using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GK2010.Web
{
    public partial class ZPageBase : System.Web.UI.MasterPage
    {
        public string SeoTitle = "";
        public string SeoKeywords = "";
        public string SeoDescription = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //在客户端注册提交到服务器的脚本
            this.Page.ClientScript.GetPostBackEventReference(this.Page.Form, "");
        }
    }
}
