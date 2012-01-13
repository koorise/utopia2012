using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GK2010.Utility;

namespace GK2010.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCategory();
        }
        /// <summary>
        /// 绑定类别
        /// </summary>
        private void BindCategory()
        {
            BLL.ProductCategory bll = new BLL.ProductCategory();
            Repeater1.DataSource = bll.GetList("0", "ParentID");
            Repeater1.DataBind();
            
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.ProductCategory model = (Model.ProductCategory)e.Item.DataItem;

                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkCTitle");
                    HyperLinkTitle.Text =  model.Title;
                    HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory, model.ID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1);


                    BLL.Product bll = new BLL.Product();
                      
                    Repeater RepeaterListChildProduct = (Repeater)e.Item.FindControl("RepeaterListChildProduct");
                    RepeaterListChildProduct.DataSource = bll.GetList(model.ID.ToString(), "RootID");
                    RepeaterListChildProduct.DataBind();
                    break;
            }
        }
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
        
       

    }
}