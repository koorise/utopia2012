using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Controls
{
    public partial class ControlProductCommend : System.Web.UI.UserControl
    {
        public int Num = 4;

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 推荐产品
                BindCommend();
                #endregion
            }
        }
        #endregion

        #region 推荐产品
        private void BindCommend()
        {
            BLL.Product bllProduct = new BLL.Product();
            List<Model.Product> modelProducts = bllProduct.GetList("", "Commend_Top6");
            rptCommendProduct.DataSource = modelProducts;
            rptCommendProduct.DataBind();
        }

        protected void rptCommendProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.Product model = (Model.Product)e.Item.DataItem;

                    string url = string.Format(ConfigUrl.UrlProductDetail, model.ID.ToString());

                    HyperLink productUrl = (HyperLink)e.Item.FindControl("productUrl");
                    productUrl.NavigateUrl = url;
                    HyperLink productUrl1 = (HyperLink)e.Item.FindControl("productUrl1");
                    productUrl1.NavigateUrl = url;

                    Image productPic = (Image)e.Item.FindControl("productPic");
                    productPic.ImageUrl = model.PictureSmall;

                    Literal productTitle = (Literal)e.Item.FindControl("productTitle");
                    productTitle.Text = model.Title;
                    break;
            }
        }
        #endregion
    }
}