using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Common;
using GK2010.Utility;
namespace GK2010.Web.Corp
{
    public partial class _default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.Company bll = new GK2010.BLL.Company();
            Model.Company model = bll.GetModelDefault();
            if (model != null)
            {
                txtTitle.Text = model.Title;
                txtDetail.Text = model.Detail;

                #region SEO
                Model.SEO modelSeo = new GK2010.Model.SEO();
                modelSeo.DetailTitle = model.Title;
                modelSeo.Tags = model.Tags;
                modelSeo.SEOTitle = model.SEOTitle;
                modelSeo.SEOKeywords = model.SEOKeywords;
                modelSeo.SEODescription = model.SEODescription;

                BLL.ConfigSeo.Set("AboutIndex", modelSeo, out SeoTitle, out SeoKeywords, out SeoDescription);
                #endregion
            }

            #region SEO
            
            #endregion
        }
    }
}
