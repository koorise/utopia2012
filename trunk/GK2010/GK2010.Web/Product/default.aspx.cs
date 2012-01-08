using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Product
{
    public partial class _default : PageBase
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            ZPageBase_MainChannel.EnumNavigator = EnumNavigator.Product;

            #region SEO
            Model.SEO modelSeo = new GK2010.Model.SEO();
            BLL.ConfigSeo.Set("ProductIndex", modelSeo, out SeoTitle, out SeoKeywords, out SeoDescription);
            #endregion

            BindCategory();

            BindABC();
        }
        #endregion

        #region 绑定类别

        private void BindCategory()
        {
            BLL.ProductCategory bll = new BLL.ProductCategory();
            RepeaterList.DataSource = bll.GetList("0", "ParentID");
            RepeaterList.DataBind();
        }

        protected void RepeaterList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.ProductCategory model = (Model.ProductCategory)e.Item.DataItem;

                    BLL.ProductCategory bll = new BLL.ProductCategory();
                    Repeater RepeaterListChild = (Repeater)e.Item.FindControl("RepeaterListChild");
                    RepeaterListChild.DataSource = bll.GetList(model.ID.ToString(), "ParentID");
                    RepeaterListChild.DataBind();

                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    HyperLinkTitle.Text =  model.Title;
                    HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory, model.ID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1);

                    break;
            }
        }

        protected void RepeaterListChild_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.ProductCategory model = (Model.ProductCategory)e.Item.DataItem;

                    //标题
                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    HyperLinkTitle.Text =  StringHelper.SubString( model.Title,16);
                    HyperLinkTitle.ToolTip = model.Title;
                    HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory, model.ParentID, model.ID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1);

                    break;
            }
        }
        #endregion

        #region 绑定字母

        private void BindABC()
        {
            BLL.ConfigABC bll = new BLL.ConfigABC();
            List<Model.ConfigABC> models = bll.GetList("", "");

            RepeaterListABC_First.DataSource = models;
            RepeaterListABC_First.DataBind();

            RepeaterListABC.DataSource = models;
            RepeaterListABC.DataBind();

            
        }

        #region 只绑定字母
        protected void RepeaterListABC_First_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.ConfigABC model = (Model.ConfigABC)e.Item.DataItem;
                    Literal txtTitle = (Literal)e.Item.FindControl("txtTitle");
                    txtTitle.Text = "<a href='#" + model.Title + "'>" + model.Title + "</a>";
                    break;
            }
        }
        #endregion

        #region 绑定字母及类别
        protected void RepeaterListABC_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.ConfigABC model = (Model.ConfigABC)e.Item.DataItem;

                    Literal txtTitle = (Literal)e.Item.FindControl("txtTitle");
                    txtTitle.Text = model.Title+"<a name='" + model.Title + "'></a>";

                    BLL.ProductCategory bll = new BLL.ProductCategory();
                    Repeater RepeaterListABCChild = (Repeater)e.Item.FindControl("RepeaterListABCChild");
                    RepeaterListABCChild.DataSource = bll.GetList(model.Title, "ABC");
                    RepeaterListABCChild.DataBind();

                    break;
            }
        }

        protected void RepeaterListABCChild_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.ProductCategory model = (Model.ProductCategory)e.Item.DataItem;

                    //标题
                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    HyperLinkTitle.Text = StringHelper.SubString(model.Title, 16);
                    HyperLinkTitle.ToolTip = model.Title;
                    HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory, model.ParentID, model.ID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1);

                    break;
            }
        }
        #endregion

        #endregion
    }
}
