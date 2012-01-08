using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GK2010.Utility;

namespace GK2010.Web.Controls
{
    public partial class ControlProductHotSale : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.Product bll = new BLL.Product();
            RepeaterList.DataSource = bll.GetProductHotSale();
            RepeaterList.DataBind();
        }

        #region 绑定数据
        protected void RepeaterList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    DataRowView drv = (DataRowView)e.Item.DataItem;

                    string Url = string.Format(ConfigUrl.UrlProductDetail, drv["ID"]);

                    string Text = drv["Title"].ToString();
                    string imgUrl = drv["PictureNormal"].ToString();
                    decimal defaultPrice = Convert.ToDecimal(drv["DefaultPrice"]);

                    Literal lit = (Literal)e.Item.FindControl("lit_productImg");
                    lit.Text = "<a title='"+Text+"' target='_blank' href='"+Url+"'><img src='"+imgUrl+"' class='pic120' /></a>";

                    Literal lit_right_Title = (Literal)e.Item.FindControl("lit_ProductTitle");
                    lit_right_Title.Text = "<a class='name' title='"+Text+"' target='_blank' href='"+Url+"'>"+Text+"</a>";

                    Literal lit_price = (Literal)e.Item.FindControl("litPrice");
                    lit_price.Text = defaultPrice.ToString("0.00");
                    break;
            }
        }
        #endregion
    }
}