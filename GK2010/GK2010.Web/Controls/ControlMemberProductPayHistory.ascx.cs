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
    public partial class ControlMemberProductPayHistory : System.Web.UI.UserControl
    {
        public Int32 id_Browse = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.Product bll = new BLL.Product();
            RepeaterList.DataSource = bll.GetPayHistory(Utility.ConfigParam.ID);
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

                    Int32 id = Convert.ToInt32(drv["ID"]);
                    if (id_Browse == 0) id_Browse = id;
                    string Text = drv["Title"].ToString();
                    string imgUrl = drv["PictureSmall"].ToString();
                    decimal defaultPrice = Convert.ToDecimal(drv["DefaultPrice"]);

                    Literal lit = (Literal)e.Item.FindControl("lit_Title");
                    lit.Text = "<li id='buy_" + id.ToString() + "' onmouseover='buy_change(" + id.ToString() + ")' style='display: list-item;' class='t1'>·<a target='_blank' href='" + Url + "'>" + Text.ToString() + "</a></li> <li id='buy_" + id.ToString() + "_pic' class='t2' style='display: none;'>";

                    Literal lit_ProductImg = (Literal)e.Item.FindControl("lit_Product_Img");
                    lit_ProductImg.Text = "<a title='" + Text + "' target='_blank' href='" + Url + "'><img src='" + imgUrl + "' class='pic'></a>";

                    Literal lit_right_Title = (Literal)e.Item.FindControl("lit_right_Title");
                    lit_right_Title.Text = "<a class='name' title='" + Text + "' target='_blank' href='" + Url + "'>" + Text + "</a>";

                    Literal lit_price = (Literal)e.Item.FindControl("litPrice");
                    lit_price.Text = defaultPrice.ToString("0.00");
                    break;
            }
        }
        #endregion
    }
}