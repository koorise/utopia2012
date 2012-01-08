using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;

namespace GK2010.Web.Help
{
    public partial class _default : PageBase
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            ZPageBase_MainChannel.EnumNavigator = EnumNavigator.Help;

            #region SEO
            Model.SEO modelSeo = new GK2010.Model.SEO();
            BLL.ConfigSeo.Set("HelpIndex", modelSeo, out SeoTitle, out SeoKeywords, out SeoDescription);
            #endregion

            #region 帮助中心
            if (!IsPostBack)
            {
                BindHelp();
            }
            #endregion
        }
        #endregion

        #region 帮助中心
        private void BindHelp()
        {
            BLL.Help bll = new GK2010.BLL.Help();
            RepeaterList.DataSource = bll.GetList("", "Index_Top20");
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

                    string Url =string.Format(ConfigUrl.UrlHelpDetail, model.ID);

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
