using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Common;
using GK2010.Utility;
namespace GK2010.Web.Help
{
    public partial class detail : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ZPageBase_MainChannel.EnumNavigator = EnumNavigator.Help;

            BLL.Help bll = new GK2010.BLL.Help();
            Model.Help model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                txtTitle.Text = model.Title;
                txtDetail.Text = model.Detail;

                #region SEO
                Model.SEO modelSeo = new GK2010.Model.SEO();
                modelSeo.DetailTitle = model.Title;
                modelSeo.CategoryTitle = BLL.HelpCategory.GetTitle(model.CategoryID);
                modelSeo.Tags = model.Tags;
                modelSeo.SEOTitle = model.SEOTitle;
                modelSeo.SEOKeywords = model.SEOKeywords;
                modelSeo.SEODescription = model.SEODescription;

                BLL.ConfigSeo.Set("HelpDetail", modelSeo, out SeoTitle, out SeoKeywords, out SeoDescription);
                #endregion

            }
        }
    }
}
