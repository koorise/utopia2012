using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GK2010.Utility;

namespace GK2010.Web
{
    public partial class cart : System.Web.UI.Page
    {

        #region 私有变量
        protected readonly BLL.MemberCart bll_mc = new BLL.MemberCart();
        protected readonly BLL.MemberCartDetail bll_mcd = new BLL.MemberCartDetail();
        protected readonly BLL.Product bll_p = new BLL.Product();
        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.LoginHelper.HasLogin)
            {
                #region 显示会员购物车中的产品
                Model.MemberCart model_mc = bll_mc.GetModelByUserID(Common.LoginHelper.UserID);
                if (model_mc != null)
                {
                    lit_totalNum.Text = "<span id='zsl" + model_mc.CartNum.ToString() + "'>" + model_mc.TotalNum.ToString() + "</span>";
                    lit_totalJF.Text = "<span id='zjf" + model_mc.CartNum.ToString() + "'>" + model_mc.TotalJF.ToString("0.00") + "</span>";
                    lit_totalProductsPrice.Text = "<span id='zjg" + model_mc.CartNum.ToString().ToString() + "'>" + model_mc.TotalProductPrice.ToString("0.00") + "</span>";


                    RepeaterCartList.DataSource = bll_mcd.GetMemberCartDetailDataSetByCartNum(model_mc.CartNum);
                    RepeaterCartList.DataBind();
                }
                #endregion
            }
        }
        #endregion

        #region 绑定数据
        protected void RepeaterCartList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    DataRowView drv = (DataRowView)e.Item.DataItem;

                    long productCacheID = long.Parse(drv["ProductCacheID"].ToString());//产品快照表id
                    Model.Product model_p = bll_p.GetModelByProductCacheID(productCacheID);
                    if (model_p != null)
                    {
                        string Url = string.Format(ConfigUrl.UrlProductDetail, model_p.ID);

                        string Title = model_p.Title.ToString();//标题
                        string DefaultType = model_p.DefaultType.ToString();//型号
                        string imgUrl = model_p.PictureSmall.ToString();//图片
                        decimal defaultPrice = model_p.DefaultPriceOld;//原价
                        decimal MemberPrice = decimal.Parse(drv["Price"].ToString());//会员价
                        decimal totalPrice = decimal.Parse(drv["TotalPrice"].ToString());//总金额
                        decimal totalJF = decimal.Parse(drv["TotalJF"].ToString());//总金额

                        Literal lit_img = (Literal)e.Item.FindControl("lit_img");
                        lit_img.Text = "<img src='" + imgUrl + "' alt='" + Title + "' />";

                        Literal lit_title = (Literal)e.Item.FindControl("lit_title");
                        lit_title.Text = Title;

                        Literal lit_DefaultType = (Literal)e.Item.FindControl("lit_DefaultType");
                        lit_DefaultType.Text = DefaultType;

                        Literal lit_oldPrice = (Literal)e.Item.FindControl("lit_oldPrice");
                        lit_oldPrice.Text = defaultPrice.ToString("0.00");

                        Literal lit_memberPrice = (Literal)e.Item.FindControl("lit_memberPrice");
                        lit_memberPrice.Text = MemberPrice.ToString("0.00");

                        Literal lit_TotalPrice = (Literal)e.Item.FindControl("lit_TotalPrice");
                        lit_TotalPrice.Text = "<span id='je" + drv["ID"].ToString() + "'>" + totalPrice.ToString("0.00") + "</span>";

                        Literal lit_totalJF = (Literal)e.Item.FindControl("lit_totalJF");
                        lit_totalJF.Text = "<span id='jf" + drv["ID"].ToString() + "'>" + totalJF.ToString("0.00") + "</span>";

                        Literal lit_del = (Literal)e.Item.FindControl("lit_del");
                        lit_del.Text = "<a href='/cartDel.aspx?Modth=del&ID=" + drv["ID"].ToString() + "'>删除</a>";
                    }
                    break;
            }
        }
        #endregion

    }
}