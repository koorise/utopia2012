using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Help
{
    public partial class list : PageBase
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ZPageBase_MainChannel.EnumNavigator = EnumNavigator.Help;
                Bind();
            }
        }
        #endregion

        #region 绑定帮助
        private void Bind()
        {
            //帮助类别标题
            int CategoryID = ConfigParam.CategoryID;

            BLL.HelpCategory bllCategory = new GK2010.BLL.HelpCategory();
            Model.HelpCategory modelCategory = bllCategory.GetModel(CategoryID);
            if (modelCategory != null)
            {
                txtCategory.Text = modelCategory.Title;

                #region SEO
                Model.SEO modelSeo = new GK2010.Model.SEO();
                modelSeo.DetailTitle = modelCategory.Title;
                modelSeo.CategoryTitle = modelCategory.Title;
                modelSeo.Tags = modelCategory.Tags;
                modelSeo.SEOTitle = modelCategory.SEOTitle;
                modelSeo.SEOKeywords = modelCategory.SEOKeywords;
                modelSeo.SEODescription = modelCategory.SEODescription;

                BLL.ConfigSeo.Set("HelpList", modelSeo, out SeoTitle, out SeoKeywords, out SeoDescription);
                #endregion
            }

            

            //分页
            int total = 0;
            int PageIndex = ConfigParam.Page;
            int PageSize = 20;

            BLL.Help bll = new BLL.Help();
            List<GK2010.Model.Help> models = bll.GetList(PageSize, PageIndex, CategoryID.ToString(), "CategoryID", out total);

         
            AspNetPager1.PageSize = PageSize;
            AspNetPager1.RecordCount = total;

            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlPaging = true;
            AspNetPager1.UrlRewritePattern = string.Format(ConfigUrl.UrlHelpList, ConfigParam.CategoryID, 0, "{0}");

            RepeaterList.DataSource = models;
            RepeaterList.DataBind();
        }

        protected void RepeaterList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.Help model = (Model.Help)e.Item.DataItem;

                    string Url = string.Format(ConfigUrl.UrlHelpDetail, model.ID);

                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    HyperLinkTitle.Text = model.Title;
                    HyperLinkTitle.Target = "_blank";
                    HyperLinkTitle.NavigateUrl = Url;
                    break;
            }
        }
        #endregion
    }
}
