using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
using System.Data;
using System.Web.UI.MobileControls;
namespace GK2010.Web.Product
{
    public partial class detail : PageBase
    {
        #region 变量
        public int I = 1;
        protected static string Product_Content = "";
        protected static string Product_Title = "";
        protected static int Product_CategoryID = 0;
        protected static Int32 Product_Favorites_Count = 0;
        protected static Int32 EvaluateZongSorce = 5;
        protected static Int32 EvaluateZongCount = 0;
        protected readonly BLL.MemberProductEvaluate mpe = new BLL.MemberProductEvaluate();
        protected readonly BLL.MemberProductBrowse mpb = new BLL.MemberProductBrowse();
        protected readonly BLL.ProductMemberDiscount pmd = new BLL.ProductMemberDiscount();
        protected readonly BLL.ProductCache bll_pc = new BLL.ProductCache();
        protected readonly BLL.ProductParts bll_pp = new BLL.ProductParts();
        protected readonly BLL.ProductPartsCache bll_ppc = new BLL.ProductPartsCache();
        protected readonly BLL.MemberCartDetail bll_mcd = new BLL.MemberCartDetail();
        protected readonly BLL.MemberCart bll_mc = new BLL.MemberCart();
        private static Model.Product model = new Model.Product();
        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
                ZPageBase_MainChannel.EnumNavigator = EnumNavigator.Product;

                int ProductID = ConfigParam.ID;
                if (ProductID != 0)
                    Utility.CookieHelper.addcookie("PROID", ProductID.ToString());
               

                //显示详细
                ShowInfo(ProductID);
                //显示图片
                ShowPic(ProductID);
                //显示评分
                showSorce(ProductID);
                //显示评价内容
                showEvaluate(ProductID);
        }
        #endregion

        #region 显示详细
        private void ShowInfo(int ProductID)
        {
            BLL.Product bll = new BLL.Product();
            model = bll.GetModel(ProductID);
            if (model != null)
            {
                HttpCookie cookie = new HttpCookie("");
                if (LoginHelper.HasLogin)
                {
                    //获取产品折扣后价格,(即：会员价)
                    decimal priceDis = BLL.Product.GetPriceDiscount(Common.LoginHelper.UserID, ProductID);
                    decimal discountPrice = 0;
                    if (priceDis == 1)
                        discountPrice = model.DefaultPrice * priceDis;
                    else
                        discountPrice = model.DefaultPrice * priceDis / 100;
                    //获取产品折扣后积分
                    decimal jfDis=BLL.Product.GetJFDiscount(Common.LoginHelper.UserID, ProductID);
                    decimal jf = 0;
                    if (jfDis == 1)
                        jf = model.DefaultJF * jfDis;
                    else
                        jf = model.DefaultJF * jfDis / 100;

                    Literal4.Text = "￥" + discountPrice.ToString("0.00");
                    Literal6.Text = jf.ToString("0.00");
                }
                else
                {
                    Literal4.Text = "<a href='../register.aspx'>请注册</a>";
                    Literal6.Text = model.DefaultJF.ToString("0.00");
                }
                txtTitle.Text = model.Title;
                txtBrand.Text = model.DefaultBrand;
                //Literal1.Text = model.DefaultBrand;
                Literal2.Text = model.DefaultPeriod;
                litProduct_huoqi.Text=model.DefaultPeriod;
                litBrand.Text=model.DefaultBrand;
                Literal3.Text = "￥" + model.DefaultPriceOld.ToString();

                Literal5.Text = model.DefaultType;
                litProduct_xinhao.Text=model.DefaultType;

                Product_Content = model.Detail.ToString();
                Product_Title = model.Title;

                 if (Common.LoginHelper.HasLogin) { 
                    Model.MemberProductBrowse mod_mpb=new Model.MemberProductBrowse();
                    mod_mpb.Addtime=DateTime.Now;
                    mod_mpb.BigCategoryID=model.CategoryID;
                    mod_mpb.DefaultPrice=model.DefaultPrice;
                     mod_mpb.IP=Utility.ConfigParam.IP;
                     mod_mpb.MemberID=Common.LoginHelper.UserID;
                     mod_mpb.ProductID=model.ID;
                     mod_mpb.ProductImgUrl=model.PictureSmall;
                     mod_mpb.ProductTitle=model.Title;
                    // if (mod_mpb != null)
                       // Utility.MessageBox.ShowAlert(this.Page, mpb.Add(mod_mpb).ToString());
                }

                #region 收藏人气
                Product_Favorites_Count = GK2010.BLL.MemberProductFavorites.GetCount(model.CategoryID, model.ID);
                #endregion

                #region 分类
                BLL.ProductCategory productCategory = new BLL.ProductCategory();
                Model.ProductCategory model_Product_Category = productCategory.GetModel(model.CategoryID);
                Product_CategoryID = model_Product_Category.ID;
                txtCategory.Text = " <a href=" + string.Format(ConfigUrl.UrlProductCategory, model_Product_Category.ID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1) + ">" + model_Product_Category.Title + "</a>";
                #endregion

                #region SEO
                Model.SEO modelSeo = new GK2010.Model.SEO();
                modelSeo.DetailTitle = model.Title;
                modelSeo.CategoryTitle = "";
                modelSeo.Tags = model.Tags;
                modelSeo.SEOTitle = model.SEOTitle;
                modelSeo.SEOKeywords = model.SEOKeywords;
                modelSeo.SEODescription = model.SEODescription;
                BLL.ConfigSeo.Set("ProductDetail", modelSeo, out SeoTitle, out SeoKeywords, out SeoDescription);
                #endregion
            }
        }
        #endregion

        #region 产品5张图片
        private void ShowPic(int ProductID)
        {
            BLL.ProductPicture bll = new BLL.ProductPicture();
            RepeaterListPicture.DataSource = bll.GetList(ProductID.ToString(), "ProductID");
            RepeaterListPicture.DataBind();
        }
        #endregion

        #region 加入购物车
        protected void iBJoinShoppongCart_Click(object sender, ImageClickEventArgs e)
        {

            if (LoginHelper.HasLogin)
            {
                #region 产品快照表,添加数据
                Model.ProductCache mpc = new Model.ProductCache();
                mpc.BasicDiscountJF = model.BasicDiscountJF;
                mpc.BasicDiscountPrice = model.BasicDiscountPrice;
                mpc.CacheID = model.CacheID;
                mpc.CategoryID = model.CategoryID;
                mpc.DefaultBrand = model.DefaultBrand;
                mpc.DefaultJF = model.DefaultJF;
                mpc.DefaultPeriod = model.DefaultPeriod;
                mpc.DefaultPrice = model.DefaultPrice;
                mpc.DefaultPriceOld = model.DefaultPriceOld;
                mpc.Detail = model.Detail;
                mpc.DiyExpression = model.DiyExpression;
                mpc.DiyFlag = model.DiyFlag;
                mpc.DiyTypeAttachmentFlag = model.DiyTypeAttachmentFlag;
                mpc.DiyTypeCn = model.DiyTypeCn;
                mpc.DiyTypeEn = model.DiyTypeEn;
                mpc.DiyTypePartsID = model.DiyTypePartsID;
                mpc.DiyTypePrice = model.DiyTypePrice;
                mpc.Hits = model.Hits;
                mpc.MemberFlag = model.MemberFlag;
                mpc.OldID = model.ID;
                mpc.PictureBig = model.PictureBig;
                mpc.PictureID = model.PictureID;
                mpc.PictureNormal = model.PictureNormal;
                mpc.PictureSmall = model.PictureSmall;
                mpc.PostDate = model.PostDate;
                mpc.PostUserID = Common.LoginHelper.UserID;
                mpc.ShowFlag = model.ShowFlag;
                mpc.SortID = model.SortID;
                mpc.Summary = model.Summary;
                mpc.Tags = model.Tags;
                mpc.Title = model.Title;
                mpc.TitleEn = model.TitleEn;
                mpc.Url = model.Url;

                #region 针对于产品快照表，根据用户和产品id的查询是否存在
                long productCacheID = model.CacheID;
                Model.ProductCache model_productCache=bll_pc.GetModelByUserIDAndProductID(Common.LoginHelper.UserID,model.ID);
                if (model_productCache == null)
                bll_pc.Add(mpc);//执行方法,向产品快照表插入数据并返回产品快照表的ID
                #endregion

                #endregion

                #region 产品部件快照表,添加数据
                List<Model.ProductParts> list_mpp = bll_pp.GetProductPartsByProductIDAndFlag(model.ID, 1, 2);
                long partsCacheID = 0;//产品部件快照表的快照编号
                if (list_mpp.Count > 0)
                    partsCacheID = Utility.DatetimeHelper.Now;

                 Model.ProductPartsCache model_ppc = bll_ppc.GetModelByProductPartCacheIDAndUserID(productCacheID, Common.LoginHelper.UserID);
                 if (model_ppc == null)
                 {
                     for (int i = 0; i < list_mpp.Count; i++)
                     {
                         Model.ProductPartsCache ppc = new Model.ProductPartsCache();
                         ppc.AttachmentFlag = list_mpp[i].AttachmentFlag;
                         ppc.CacheID = partsCacheID;
                         ppc.CategoryID = list_mpp[i].ParentID;
                         ppc.CategoryPath = list_mpp[i].Path;
                         ppc.DefaultFlag = list_mpp[i].DefaultFlag;
                         ppc.Detail = list_mpp[i].Detail;
                         ppc.Flag = list_mpp[i].Flag;
                         ppc.OldID = list_mpp[i].ID;
                         ppc.PictureBig = list_mpp[i].PictureBig;

                         ppc.PictureID = list_mpp[i].PictureID;
                         ppc.PictureNormal = list_mpp[i].PictureNormal;
                         ppc.PictureSmall = list_mpp[i].PictureSmall;
                         ppc.PostDate = Utility.DatetimeHelper.Now;
                         ppc.PostUserID = Common.LoginHelper.UserID;
                         ppc.ProductCatchID = productCacheID;
                         ppc.RootID = list_mpp[i].RootID;
                         ppc.ShowFlag = list_mpp[i].ShowFlag;
                         ppc.SortID = list_mpp[i].SortID;
                         ppc.Summary = list_mpp[i].Summary;
                         ppc.Title = list_mpp[i].Title;
                         ppc.TitleEn = list_mpp[i].TitleEn;


                         bll_ppc.Add(ppc);//插入数据
                     }
                 }
                 else
                 {
                     partsCacheID = model_ppc.CacheID;//返回部件快照编号
                 }
                #endregion

                #region 会员购物详细表
                Model.MemberCartDetail mod_mcart = new Model.MemberCartDetail();
                Model.ProductMemberDiscount mod_pmd = pmd.GetModel(Common.LoginHelper.UserID, model.ID);
                if (mod_pmd == null) {//如果没有折扣，则为默认
                    mod_pmd = new Model.ProductMemberDiscount();
                    mod_pmd.DiscountJF = 100;
                    mod_pmd.DiscountPrice = 100;
                }
                Model.MemberCart mod_mc = bll_mc.GetModelByUserID(Common.LoginHelper.UserID); //根据用户id查询购物列表是否已存在购物信息

                mod_mcart.BasicDiscountJF = model.BasicDiscountJF;
                mod_mcart.BasicDiscountPrice = model.BasicDiscountPrice;
                if (mod_mc == null)//判断购物车编号是否已存在，并获取购物车编号
                    mod_mcart.CartNum = Utility.DatetimeHelper.Now.ToString();
                else
                    mod_mcart.CartNum = mod_mc.CartNum;
                mod_mcart.DiyExpression = model.DiyExpression;
                mod_mcart.DiyFlag = model.DiyFlag;
                mod_mcart.DiyTypeAttachmentFlag = model.DiyTypeAttachmentFlag;
                mod_mcart.DiyTypeCn = model.DiyTypeCn;
                mod_mcart.DiyTypeEn = model.DiyTypeEn;
                mod_mcart.DiyTypePartsID = model.DiyTypePartsID;
                mod_mcart.DiyTypePrice = model.DiyTypePrice;
                mod_mcart.JF = model.DefaultJF * Convert.ToDecimal(Convert.ToDecimal(model.BasicDiscountJF) / 100);
                mod_mcart.JFOld = model.DefaultJF;//默认积分
                mod_mcart.Num = 1;//数量
                mod_mcart.Price = model.DefaultPrice * Convert.ToDecimal(Convert.ToDecimal(mod_pmd.DiscountPrice) / 100);
                mod_mcart.PriceOld = model.DefaultPriceOld;//原价
                mod_mcart.ProductCacheID = productCacheID;//产品快照编号
                mod_mcart.ProductPartsCacheID = partsCacheID;//产品部件快照编号
                mod_mcart.TotalJF = mod_mcart.JF;
                mod_mcart.TotalPrice = mod_mcart.Price;

                #region 根据产品快照编号和产品部件编号查询产品详细表的产品是否存在
                Model.MemberCartDetail model_mcd=bll_mcd.GetMemberCartDetailByProductCacheIDAndProductPartCacheID(mod_mcart.ProductCacheID, mod_mcart.ProductPartsCacheID);

                if (model_mcd != null)
                {
                    Model.MemberCartDetail model_Membercd = new Model.MemberCartDetail();
                    model_Membercd.Id = model_mcd.Id;
                    model_Membercd.Num = model_mcd.Num+1;
                    model_Membercd.TotalJF = mod_mcart.TotalJF * model_Membercd.Num;
                    model_Membercd.TotalPrice = mod_mcart.TotalPrice * model_Membercd.Num;

                    bll_mcd.UpdatePartDataByID(model_Membercd);
                }
                else
                {
                    bll_mcd.Add(mod_mcart);//向购物详细表里插入数据
                }
                #endregion
                #endregion

                #region 添加到会员购物表
                #region 根据购物车编号查询所有购物车里面的产品
                List<Model.MemberCartDetail> list = bll_mcd.GetMemberCartDetailByCartNum(mod_mcart.CartNum);
                decimal mc_TotalJF = 0;//总积分
                int mc_TotalNum = 0;//总数量
                decimal mc_TotalProductPrice = 0;//所有产品总价格
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        mc_TotalJF += list[i].TotalJF;
                        mc_TotalNum += list[i].Num;
                        mc_TotalProductPrice += list[i].TotalPrice;
                    }
                }
                else { 
                
                }
                #endregion

                Model.MemberCart mmc = new Model.MemberCart();
                mmc.CartNum = mod_mcart.CartNum;
                mmc.EditDate = Utility.DatetimeHelper.Now;
                mmc.EditUserID = Common.LoginHelper.UserID;
                mmc.TotalJF = mc_TotalJF;
                mmc.TotalNum = mc_TotalNum;
                mmc.TotalOtherPrice = 0;
                mmc.TotalPrice = mc_TotalProductPrice;
                mmc.TotalProductPrice = mc_TotalProductPrice;
                mmc.TotalShipPrice = 0;
                mmc.UserID = Common.LoginHelper.UserID;

                mmc.PostUserID = 0;
                mmc.PostDate = 0;
                mmc.EditDate = 0;
                mmc.EditUserID = 0;


                if (mod_mc == null)
                {
                    mmc.ConsigneeAddress = "";
                    mmc.ConsigneeArea = "";
                    mmc.ConsigneeCity = "";
                    mmc.ConsigneeCompany = "";
                    mmc.ConsigneeEmail = "";
                    mmc.ConsigneeMobile = "";
                    mmc.ConsigneePostCode = "";
                    mmc.ConsigneeProvince = "";
                    mmc.ConsigneeRealName = "";
                    mmc.ConsigneeTelephone = "";

                    mmc.InvoiceAddress = "";
                    mmc.InvoiceBank = "";
                    mmc.InvoiceBankAccount = "";
                    mmc.InvoiceCompany = "";
                    mmc.InvoiceContent = "";
                    mmc.InvoiceMailAddress = "";
                    mmc.InvoiceMailArea = "";
                    mmc.InvoiceMailCity = "";
                    mmc.InvoiceMailCompany = "";
                    mmc.InvoiceMailEmail = "";
                    mmc.InvoiceMailMobile = "";
                    mmc.InvoiceMailPostCode = "";
                    mmc.InvoiceMailProvince = "";
                    mmc.InvoiceMailRealName = "";
                    mmc.InvoiceMailTelephone = "";
                    mmc.InvoiceNum = "";
                    mmc.InvoiceTelephone = "";
                    mmc.InvoiceType = "";
                    mmc.Liuyan = "";
                    mmc.PayType = "";
                    mmc.Remark = "";
                    mmc.ShipType = "";

                    bll_mc.Add(mmc);
                    MessageBox.ShowAlertAndRedirect(this, "产品已经成功加入购物车", String.Format(Utility.ConfigUrl.UrlProductDetail, ConfigParam.ID));
                }
                else
                {
                    bll_mc.UpdateMemberCartByPart(mmc);
                    MessageBox.ShowAlertAndRedirect(this, "产品已经成功加入购物车", String.Format(Utility.ConfigUrl.UrlProductDetail, ConfigParam.ID));
                }
                #endregion
            }
            else
                MessageBox.ShowAlert(this, "您还没有登录，请登录！");
        }
        #endregion

        #region 自助选型
        protected void iBSelfHelpSelectType_Click(object sender, ImageClickEventArgs e)
        {
            if (LoginHelper.HasLogin)
            {
                int ProductID = ConfigParam.ID;
                if (ProductID <= 0)
                {
                    MessageBox.ShowAlert(this, "参数错误！");
                }
                string Url = string.Format(ConfigUrl.UrlProductDiy, ProductID);
                Response.Redirect(Url);
            }
            else
                MessageBox.ShowAlert(this, "您还没有登录，请登录！");
        }
        #endregion

        #region 显示评分
        private void showSorce(int productID)
        {
            float zongPinFen = mpe.GetSorce(productID);//总评分
            float pinFenCount = mpe.GetSorceCount(productID);//评分次数
            if (pinFenCount == 0)
            {
                litScroe.Text = "5.0";
                EvaluateZongSorce = 5;
            }
            else
            {
                litScroe.Text = (zongPinFen / pinFenCount).ToString("#.#");
                EvaluateZongSorce = Convert.ToInt32((float)zongPinFen / (float)pinFenCount);
            }
            litScroe1_0.Text = litScroe.Text;//商品评价页面的得分
            int good = mpe.GetCommentCountByComment(productID, 1);//好评次数
            int center = mpe.GetCommentCountByComment(productID, 2);//中评次数
            int poor = mpe.GetCommentCountByComment(productID, 3);//差评次数
            EvaluateZongCount= mpe.GetCommentCount(productID);//总评次数

            #region 好评显示
            if (good == 0 || EvaluateZongCount == 0)
            {
                litGoodScroe.Text = "100%";
                litGoodScroe1.Text = "100%";
                litGoodWith.Text = "<div style='width: 260px;'>  </div>";
            }
            else
            {
                litGoodScroe.Text = (Convert.ToInt64((float)good / (float)EvaluateZongCount * 100)).ToString() + "%";//好评百分比
                litGoodScroe1.Text = litGoodScroe.Text;
                litGoodWith.Text = "<div style='width: " + ((float)good / (float)EvaluateZongCount * 260).ToString() + "px;'>  </div>";
            }
            litGoodScroe1_1.Text = litGoodScroe.Text;
            litGoodScroe1_2.Text = litGoodScroe.Text;
            litGoodWith1_1.Text = litGoodWith.Text;
            #endregion

            #region 中评显示
            if (center == 0 || EvaluateZongCount == 0)
            {
                litCenterScroe.Text = "0%";
                litCenterWith.Text = "<div style='width: 0px;'>  </div>";
            }
            else
            {
                litCenterScroe.Text = (Convert.ToInt64((float)center / (float)EvaluateZongCount * 100)).ToString() + "%";//好评百分比
                litCenterWith.Text = "<div style='width: " + ((float)center / (float)EvaluateZongCount * 260).ToString() + "px;'>  </div>";
            }
            litCenterScroe1.Text = litCenterScroe.Text;
            litCenterWith1.Text = litCenterWith.Text;
            #endregion

            #region 差评显示
            if (poor == 0 || EvaluateZongCount == 0)
            {
                litPoorScroe.Text = "0%";
                litPoorWith.Text = "<div style='width: 0px;'>  </div>";
            }
            else
            {
                litPoorScroe.Text = (Convert.ToInt64((float)poor / (float)EvaluateZongCount * 100)).ToString() + "%";//好评百分比
                litPoorWith.Text = "<div style='width: " + ((float)poor / (float)EvaluateZongCount * 260).ToString() + "px;'>  </div>";
            }
            litPoorScroe1.Text = litPoorScroe.Text;
            litPoorWith1.Text=litPoorWith.Text;
            #endregion
        }
        #endregion

        #region 显示评价内容

        private void showEvaluate(int ProductID)
        {
            List<GK2010.Model.MemberProductEvaluate> list=mpe.GetTopNumDataSetByProductID(ProductID);
            if (list.Count == 0)
            {
                litgdsppj.Visible = false;
                litgdsppj1.Visible = false;
            }
            else
            {
                repeaterEvaluateList.DataSource = list;
                repeaterEvaluateList.DataBind();
                repeaterEvaluateList1.DataSource = list;
                repeaterEvaluateList1.DataBind();
                string url = string.Format(ConfigUrl.UrlMemberProductEvaluateList, ProductID, ConfigParam.Page);
                litgdsppj.Text = "<span><a class='gdsppj' href='" + url + "' title='点击查看更多商品评价' style='cursor:pointer'>更多商品评价>></a></span>";
                litgdsppj1.Text = litgdsppj.Text;
            }
        }

        #endregion

        #region 商品详情栏目的repeater控件事件
        protected void repeaterEvaluateList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
            switch (e.Item.ItemType) { 
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.MemberProductEvaluate model = (Model.MemberProductEvaluate)e.Item.DataItem;
                    if (model.Reply.ToString().Trim().Length >1)
                    {
                        Literal literal = (Literal)e.Item.FindControl("lit_JieShi");
                        literal.Text = "<dl> <dt>掌柜解释：</dt>  <dd> " + model.Reply.ToString() + "</dd></dl>";

                    }
                    break;
            }
        }
        #endregion

        #region 商品评价栏目的repeater控件事件
        protected void repeaterEvaluateList1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.MemberProductEvaluate model1 = (Model.MemberProductEvaluate)e.Item.DataItem;
                    if (model1.Reply.ToString().Trim().Length > 1)
                    {
                        Literal literal1 = (Literal)e.Item.FindControl("lit_JieShi1");
                        literal1.Text = "<dl> <dt>掌柜解释：</dt>  <dd> " + model1.Reply.ToString() + "</dd></dl>";

                    }
                    break;
            }
        }
        #endregion

        

    }
}