using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Product
{
    public partial class list_pic : PageBase
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ZPageBase_MainChannel.EnumNavigator = EnumNavigator.Product;

                HyperLinkBig.Text = BLL.ProductCategory.GetTitle(ConfigParam.BigID);
                HyperLinkBig.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory, ConfigParam.BigID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ConfigParam.OrderType, ConfigParam.ShowType, 1);

                HyperLinkSmall.Text = BLL.ProductCategory.GetTitle(ConfigParam.SmallID);
                HyperLinkSmall.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory, ConfigParam.BigID, ConfigParam.SmallID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ConfigParam.OrderType, ConfigParam.ShowType, 1);

                BindProduct();
            }
        }
        #endregion

        #region 绑定产品
        private void BindProduct()
        {
            int total = 0;
		    int PageIndex = ConfigParam.Page;
		    int PageSize = 30;
            Model.VirtualSearch modelVirtualSearch = new GK2010.Model.VirtualSearch();
            modelVirtualSearch.VirtualCategoryID1 = ConfigParam.GetIntGet("VirtualCategoryID1", 0);
            modelVirtualSearch.VirtualCategoryID2 = ConfigParam.GetIntGet("VirtualCategoryID2", 0);
            modelVirtualSearch.VirtualCategoryID3 = ConfigParam.GetIntGet("VirtualCategoryID3", 0);
            modelVirtualSearch.VirtualCategoryID4 = ConfigParam.GetIntGet("VirtualCategoryID4", 0);
            modelVirtualSearch.VirtualCategoryID5 = ConfigParam.GetIntGet("VirtualCategoryID5", 0);
            modelVirtualSearch.VirtualCategoryID6 = ConfigParam.GetIntGet("VirtualCategoryID6", 0);
            modelVirtualSearch.VirtualCategoryID7 = ConfigParam.GetIntGet("VirtualCategoryID7", 0);
            modelVirtualSearch.VirtualCategoryID8 = ConfigParam.GetIntGet("VirtualCategoryID8", 0);
            modelVirtualSearch.VirtualCategoryID9 = ConfigParam.GetIntGet("VirtualCategoryID9", 0);
            modelVirtualSearch.VirtualCategoryID10 = ConfigParam.GetIntGet("VirtualCategoryID10", 0);

		    BLL.Product bll = new BLL.Product();
            List<GK2010.Model.Product> models = bll.GetList(PageSize, PageIndex, LoginHelper.UserID, ConfigParam.BigID, ConfigParam.SmallID, 0, modelVirtualSearch, 0, out total);
            AspNetPager1.PageSize = PageSize;
            AspNetPager1.RecordCount = total;

            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlPaging = true;
            AspNetPager1.UrlRewritePattern = string.Format(ConfigUrl.UrlProductCategory, ConfigParam.BigID, ConfigParam.SmallID,0,
                modelVirtualSearch.VirtualCategoryID1,
                modelVirtualSearch.VirtualCategoryID2,
                modelVirtualSearch.VirtualCategoryID3,
                modelVirtualSearch.VirtualCategoryID4,
                modelVirtualSearch.VirtualCategoryID5,
                modelVirtualSearch.VirtualCategoryID6,
                modelVirtualSearch.VirtualCategoryID7,
                modelVirtualSearch.VirtualCategoryID8,
                modelVirtualSearch.VirtualCategoryID9,
                modelVirtualSearch.VirtualCategoryID10,
                ConfigParam.OrderType,
                ConfigParam.ShowType,               
                "{0}");
            //2-0-0-0-0-0-0-0-0-0-0-0-0-1-1-1
            //2-0-0-0-0-0-0-0-0-0-0-0-0-1-0-2.html

            RepeaterListProduct.DataSource = models;
            RepeaterListProduct.DataBind();

            if (models.Count == 0)
            {
                AspNetPager1.Visible = false;
            }

            #region SEO

            string CategoryTitle = "";
            if (ConfigParam.BigID > 0)
            {
                CategoryTitle = BLL.ProductCategory.GetTitle(ConfigParam.BigID);
            }
            if (ConfigParam.SmallID > 0)
            {
                CategoryTitle = BLL.ProductCategory.GetTitle(ConfigParam.SmallID) + " - " + CategoryTitle;
            }

            Model.SEO modelSeo = new GK2010.Model.SEO();
            modelSeo.DetailTitle = "";
            modelSeo.CategoryTitle = CategoryTitle; ;
            modelSeo.Tags = "";
            modelSeo.SEOTitle = "";
            modelSeo.SEOKeywords = "";
            modelSeo.SEODescription = "";
            BLL.ConfigSeo.Set("ProductList", modelSeo, out SeoTitle, out SeoKeywords, out SeoDescription);
            #endregion
        }

        protected void RepeaterListProduct_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.Product model = (Model.Product)e.Item.DataItem;

                    string Picture = StringHelper.GetPicture_100_100(model.PictureSmall);
                    string Url = string.Format(ConfigUrl.UrlProductDetail, model.ID,1);

                    HyperLink HyperLinkImage = (HyperLink)e.Item.FindControl("HyperLinkImage");
                    HyperLinkImage.ImageUrl = Picture;
                    HyperLinkImage.NavigateUrl = Url;
                  
                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    HyperLinkTitle.Text = model.Title;
                    HyperLinkTitle.NavigateUrl = Url;

                    Literal txtPriceOld = (Literal)e.Item.FindControl("txtPriceOld");
                    txtPriceOld.Text = model.DefaultPriceOld.ToString("￥0.00");

                    Literal txtPrice = (Literal)e.Item.FindControl("txtPrice");
                    txtPrice.Text = model.DefaultPrice.ToString("￥0.00");

                    break;
            }
        }
        #endregion
    }
}
