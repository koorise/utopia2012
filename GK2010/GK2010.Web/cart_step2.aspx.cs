using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GK2010.Utility;

namespace GK2010.Web
{
    public partial class cart_step2 : System.Web.UI.Page
    {
        protected readonly BLL.MemberCart bll_mc = new BLL.MemberCart();
        protected readonly BLL.MemberCartDetail bll_mcd = new BLL.MemberCartDetail();
        protected readonly BLL.MemberOrder bll_mod= new BLL.MemberOrder();
        protected readonly BLL.Product bll_p = new BLL.Product();
        protected int xuhao = 0;//序号
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.LoginHelper.HasLogin)
            {

                if (!IsPostBack)
                {

               
                Model.MemberCart model_mc = bll_mc.GetModelByUserID(Common.LoginHelper.UserID);
                if (model_mc != null)
                { 
                    #region 显示会员购物车中的产品
                    lit_totalJF.Text = model_mc.TotalJF.ToString("0.00");
                    lit_totalProductsPrice.Text = model_mc.TotalProductPrice.ToString("0.00");

                    RepeaterCartList.DataSource = bll_mcd.GetMemberCartDetailDataSetByCartNum(model_mc.CartNum);
                    RepeaterCartList.DataBind();

                    #endregion

                    Utility.CookieHelper.SetCookies("cartNum", model_mc.CartNum);//向COOKIES中存储购物车编号
                    Utility.CookieHelper.SetCookiesUserID("UserID", model_mc.UserID);//向COOKIES中存储会员编号

                    //收件人信息
                    BLL.MemberConsignee bll = new BLL.MemberConsignee();
                    if (bll.Exists(Common.LoginHelper.UserID))
                        txtConsignee.Text = BLL.MemberCart.closeForm_Consignee();
                    else
                        txtConsignee.Text = BLL.MemberCart.showForm_Consignee();

                    //发票邮寄信息
                    txtInvoiceMail.Text = BLL.MemberCart.closeForm_InvoiceMail();


                }else
                    Response.Redirect("cart.aspx");
                }
            }
            else
                Response.Redirect("login.aspx");
        }

        #region 绑定数据
        protected void RepeaterCartList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    DataRowView drv = (DataRowView)e.Item.DataItem;
                    xuhao += 1;

                    long productCacheID = long.Parse(drv["ProductCacheID"].ToString());//产品快照表id
                    Model.Product model_p = bll_p.GetModelByProductCacheID(productCacheID);
                    if (model_p != null)
                    {
                       // string Url = string.Format(ConfigUrl.UrlProductDetail, model_p.ID);

                        string Title = model_p.Title.ToString();//标题
                        string DefaultType = model_p.DefaultType.ToString();//型号
                        decimal defaultPrice = model_p.DefaultPriceOld;//原价
                        decimal MemberPrice = decimal.Parse(drv["Price"].ToString());//会员价
                        decimal totalPrice = decimal.Parse(drv["TotalPrice"].ToString());//总金额
                        decimal totalJF = decimal.Parse(drv["TotalJF"].ToString());//总金额

                        Literal lit_xuhao = (Literal)e.Item.FindControl("lit_xuhao");
                        lit_xuhao.Text = xuhao.ToString();

                        Literal lit_title = (Literal)e.Item.FindControl("lit_title");
                        lit_title.Text = Title;

                        Literal lit_DefaultType = (Literal)e.Item.FindControl("lit_DefaultType");
                        lit_DefaultType.Text = DefaultType;

                        Literal lit_oldPrice = (Literal)e.Item.FindControl("lit_oldPrice");
                        lit_oldPrice.Text = defaultPrice.ToString("0.00");

                        Literal lit_memberPrice = (Literal)e.Item.FindControl("lit_memberPrice");
                        lit_memberPrice.Text = MemberPrice.ToString("0.00");

                        Literal lit_TotalPrice = (Literal)e.Item.FindControl("lit_TotalPrice");
                        lit_TotalPrice.Text = totalPrice.ToString("0.00") ;

                        Literal lit_totalJF = (Literal)e.Item.FindControl("lit_totalJF");
                        lit_totalJF.Text = totalJF.ToString("0.00");

                    }
                    break;
            }
        }
        #endregion

        protected void btnSubOrder_Click(object sender, EventArgs e)
        {
            if (Common.LoginHelper.HasLogin)
            {
                 Model.MemberCart mc = bll_mc.GetModelByUserID(Common.LoginHelper.UserID);
                if (mc != null)
                {
                    long orderNum = 0;
                    orderNum = Utility.DatetimeHelper.Now;
                    Model.MemberOrder mo = new Model.MemberOrder();
                    mo.UserID = mc.UserID;
                    mo.OrderNum = orderNum.ToString();//订单号
                    mo.TotalNum = mc.TotalNum;
                    mo.ShipPrice = mc.TotalShipPrice;
                    mo.ProductPrice = mc.TotalProductPrice;
                    mo.OtherPrice = mc.TotalOtherPrice;
                    mo.TotalPriceHasPay = 0;
                    mo.TotalPrice = mc.TotalPrice;
                    mo.TotalJF = mc.TotalJF;
                    mo.ConsigneeCompany = mc.ConsigneeCompany;
                    mo.ConsigneeRealName = mc.ConsigneeRealName;
                    mo.ConsigneeProvince = mc.ConsigneeProvince;
                    mo.ConsigneeCity = mc.ConsigneeCity;
                    mo.ConsigneeArea = mc.ConsigneeArea;
                    mo.ConsigneeAddress = mc.ConsigneeAddress;
                    mo.ConsigneePostCode = mc.ConsigneePostCode;
                    mo.ConsigneeTelephone = mc.ConsigneeTelephone;
                    mo.ConsigneeMobile = mc.ConsigneeMobile;
                    mo.ConsigneeEmail = mc.ConsigneeEmail;
                    mo.PayType = mc.PayType;
                    mo.ShipType = mc.ShipType;
                    mo.InvoiceType = mc.InvoiceType;
                    mo.InvoiceCompany = mc.InvoiceCompany;
                    mo.InvoiceNum = mc.InvoiceNum;
                    mo.InvoiceAddress = mc.InvoiceAddress;
                    mo.InvoiceTelephone = mc.InvoiceTelephone;
                    mo.InvoiceBank = mc.InvoiceBank;
                    mo.InvoiceBankAccount = mc.InvoiceBankAccount;
                    mo.InvoiceContent = mc.InvoiceContent;
                    mo.InvoiceMailCompany = mc.InvoiceMailCompany;
                    mo.InvoiceMailRealName = mc.InvoiceMailRealName;
                    mo.InvoiceMailProvince = mc.InvoiceMailProvince;
                    mo.InvoiceMailCity = mc.InvoiceMailCity;
                    mo.InvoiceMailArea = mc.InvoiceMailArea;
                    mo.InvoiceMailAddress = mc.InvoiceMailAddress;
                    mo.InvoiceMailPostCode = mc.InvoiceMailPostCode;
                    mo.InvoiceMailTelephone= mc.InvoiceMailTelephone;
                    mo.InvoiceMailMobile = mc.InvoiceMailMobile;
                    mo.InvoiceMailEmail = mc.InvoiceMailEmail;
                    mo.Liuyan = mc.Liuyan;
                    mo.StatusFlag = mc.StatusFlag;
                    mo.StatusDate = mc.StatusDate;
                    mo.StatusUserID = mc.StatusUserID;
                    mo.PostDate = mc.PostDate;
                    mo.PostUserID = mc.PostUserID;
                    mo.Remark = mc.Remark;
                    bll_mod.Add(mo);

                }
            }
            else
                Response.Redirect("login.aspx");
        }
    }
}
