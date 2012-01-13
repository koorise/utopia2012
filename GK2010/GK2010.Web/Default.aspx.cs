using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
using GK2010.BLL;

namespace GK2010.Web
{
    public partial class _default:PageBase
    {
        private static readonly BLL.Product bllProduct = new BLL.Product();
        private static readonly BLL.Tech bllTech = new BLL.Tech();

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            ZPageBase_MainChannel.EnumNavigator = EnumNavigator.Index;
            #region 绑定产品类别
            BindCategory();
            #endregion
            #region 绑定产品
            BindNewProducts();
            BindCommendProducts();
            BindHotProduct();
            #endregion

            #region 绑定文章
            BindTech();
            //BindQa();
            BindDown();
            #endregion

            #region SEO
            Model.SEO modelSeo = new GK2010.Model.SEO();
            BLL.ConfigSeo.Set("Index", modelSeo, out SeoTitle, out SeoKeywords, out SeoDescription);
            #endregion
        }
        #endregion
        #region 不同类别产品
        /// <summary>
        /// 绑定类别
        /// </summary>
        private void BindCategory()
        {
            BLL.ProductCategory bll = new BLL.ProductCategory();
            Repeater1.DataSource = bll.GetList("0", "ParentID");
            Repeater1.DataBind();

        }
        /// <summary>
        /// 类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.ProductCategory model = (Model.ProductCategory)e.Item.DataItem;
                    Literal Literal1 = (Literal)e.Item.FindControl("Literal1");
                    Literal1.Text = model.Title;

                    HyperLink HyperLink1 = (HyperLink)e.Item.FindControl("HyperLink1");
                    HyperLink1.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory, model.ID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1);
                    BLL.Product bll = new BLL.Product();

                    Repeater RepeaterListChildProduct = (Repeater)e.Item.FindControl("RepeaterListChildProduct");
                    //RepeaterListChildProduct.DataSource = bll.GetList(model.ID.ToString(), "RootID");
                    RepeaterListChildProduct.DataSource = bll.GetList(model.ID.ToString(), "RootID");
                    RepeaterListChildProduct.DataBind();
                    break;
            }
        }
        /// <summary>
        /// 产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RepeaterListChildProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {

                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.Product model = (Model.Product)e.Item.DataItem;

                    string Picture = StringHelper.GetPicture_100_100(model.PictureSmall);
                    string Url = string.Format(ConfigUrl.UrlProductDetail, model.ID, 1);

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
        #region 技术支持
        private void BindTech()
        {
            int totalRows;
            List<GK2010.Model.Tech> techs = bllTech.GetList(8, 1, "", "", out totalRows);
            reptTech.DataSource = techs;
            reptTech.DataBind();
        }

        protected void reptTech_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.Tech model = (Model.Tech)e.Item.DataItem;
                    string url = string.Format(ConfigUrl.UrlTechDetail, model.ID);

                    Literal litTitle = (Literal)e.Item.FindControl("litTitle");
                    litTitle.Text = "<a href=\""+ url +"\">"+ model.Title +"</a>";
                    break;
            }
        }
        #endregion

        //#region 解答中心
        //private void BindQa()
        //{
        //    BLL.Qa bll = new BLL.Qa();
        //    List<GK2010.Model.Qa> qas = bll.GetList("", "");
        //    reptQa.DataSource = qas;
        //    reptQa.DataBind();
        //}

        //protected void reptQa_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.Item:
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.EditItem:
        //            Model.Qa model = (Model.Qa)e.Item.DataItem;
        //            string url = string.Format(ConfigUrl.UrlQaDetail, model.ID);

        //            Label lblState = (Label)e.Item.FindControl("lblState");
        //            lblState.Text = StringHelper.GetStrFlag(model.CheckFlag, "已解答", "未解答");

        //            HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlTitle");
        //            hlTitle.NavigateUrl = url;
        //            hlTitle.Text = model.Title;
        //            break;
        //    }
        //}
        //#endregion

        #region 最新产品
        private void BindNewProducts()
        {
            //List<GK2010.Model.Product> products = bllProduct.GetList("", "Index_NewProducts");
            //reptNewProduct.DataSource = products;
            //reptNewProduct.DataBind();
        }

        protected void reptNewProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //switch (e.Item.ItemType)
            //{
            //    case ListItemType.Item:
            //    case ListItemType.AlternatingItem:
            //    case ListItemType.EditItem:
            //        Model.Product model = (Model.Product)e.Item.DataItem;
            //        string url = string.Format(ConfigUrl.UrlProductDetail, model.ID);

            //        Literal litProdName = (Literal)e.Item.FindControl("litProdName");
            //        litProdName.Text = "<a href=\""+ url +"\">"+ model.Title +"</a>";

            //        Literal litProdImg = (Literal)e.Item.FindControl("litProdImg");
            //        litProdImg.Text = "<a href=\""+ url +"\"><img src=\"" + model.PictureSmall + "\" height=\"96\" width=\"120\" /></a>";

            //        Literal litDftPriceOld = (Literal)e.Item.FindControl("litDftPriceOld");
            //        litDftPriceOld.Text = Convert.ToString(model.DefaultPriceOld);

            //        Literal litDftPrice = (Literal)e.Item.FindControl("litDftPrice");
            //        litDftPrice.Text = Convert.ToString(model.DefaultPrice);
            //        break;
            //}
        }
        #endregion

        #region 推荐产品
        private void BindCommendProducts()
        {
            //List<GK2010.Model.Product> products = bllProduct.GetList("", "Index_CommendProducts");
            //reptCommendProducts.DataSource = products;
            //reptCommendProducts.DataBind();
        }

        protected void reptCommendProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //switch (e.Item.ItemType)
            //{
            //    case ListItemType.Item:
            //    case ListItemType.AlternatingItem:
            //    case ListItemType.EditItem:
            //        Model.Product model = (Model.Product)e.Item.DataItem;
            //        string url = string.Format(ConfigUrl.UrlProductDetail, model.ID);

            //        Literal litPic = (Literal)e.Item.FindControl("litPic");
            //        litPic.Text = "<a href=\"" + url + "\"><img src=\"" + model.PictureSmall + "\" height=\"96\" width=\"120\" /></a>";

            //        Literal litTitle = (Literal)e.Item.FindControl("litTitle");
            //        litTitle.Text = "<a href=\"" + url + "\">" + model.Title + "</a>";

            //        Literal litDftPriceOld = (Literal)e.Item.FindControl("litDftPriceOld");
            //        litDftPriceOld.Text = Convert.ToString(model.DefaultPriceOld);

            //        Literal litDftPrice = (Literal)e.Item.FindControl("litDftPrice");
            //        litDftPrice.Text = Convert.ToString(model.DefaultPrice);
            //        break;
            //}
        }
        #endregion

        #region 疯狂抢购
        private void BindHotProduct()
        {
            //List<GK2010.Model.Product> products = bllProduct.GetList("", "Index_Hot");
            //reptHotProduct.DataSource = products;
            //reptHotProduct.DataBind();
        }

        protected void reptHotProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //switch (e.Item.ItemType)
            //{
            //    case ListItemType.Item:
            //    case ListItemType.AlternatingItem:
            //    case ListItemType.EditItem:
            //        Model.Product model = (Model.Product)e.Item.DataItem;
            //        string url = string.Format(ConfigUrl.UrlProductDetail, model.ID);

            //        Literal litPic = (Literal)e.Item.FindControl("litPic");
            //        litPic.Text = "<a href=\"" + url + "\"><img src=\"" + model.PictureSmall + "\" height=\"96\" width=\"120\" /></a>";

            //        Literal litTitle = (Literal)e.Item.FindControl("litTitle");
            //        litTitle.Text = "<a href=\"" + url + "\">" + model.Title + "</a>";

            //        Literal litDftPriceOld = (Literal)e.Item.FindControl("litDftPriceOld");
            //        litDftPriceOld.Text = Convert.ToString(model.DefaultPriceOld);

            //        Literal litDftPrice = (Literal)e.Item.FindControl("litDftPrice");
            //        litDftPrice.Text = Convert.ToString(model.DefaultPrice);
            //        break;
            //}
        }
        #endregion

        #region 下载中心
        private void BindDown()
        {
            BLL.Down bllDown = new BLL.Down();
            List<GK2010.Model.Down> downs = bllDown.GetList("", "");
            reptDown.DataSource = downs;
            reptDown.DataBind();
        }

        protected void reptDown_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.Down model = (Model.Down)e.Item.DataItem;
                    string url = string.Format(ConfigUrl.UrlDownDetail, model.ID);

                    HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlTitle");
                    hlTitle.Text = model.Title;
                    hlTitle.NavigateUrl = url;
                    break;
            }
        }
        #endregion

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

   
    }
}
