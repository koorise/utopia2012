using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace GK2010.Common
{
    public class PageBase:Page
    {
        protected string SeoTitle = "";
        protected string SeoKeywords = "";
        protected string SeoDescription = "";

        protected override void OnInit(EventArgs e)
        {
            SeoTitle = "";
            SeoKeywords = "";
            SeoDescription = "";
        }
    }
}
