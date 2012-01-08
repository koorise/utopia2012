using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web
{
    public partial class _default:PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ZPageBase_MainChannel.EnumNavigator = EnumNavigator.Index;

            #region SEO
            Model.SEO modelSeo = new GK2010.Model.SEO();
            BLL.ConfigSeo.Set("Index", modelSeo, out SeoTitle, out SeoKeywords, out SeoDescription);
            #endregion
        }
    }
}
