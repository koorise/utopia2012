using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.BLL;
using GK2010.Utility;
using GK2010.Common;  

namespace GK2010.Web.Product
{
    public partial class product_modelselect_handle : PageBase
    {
        protected readonly BLL.MemberProductEvaluate mpe = new BLL.MemberProductEvaluate();
        protected readonly BLL.MemberProductBrowse mpb = new BLL.MemberProductBrowse();
        protected readonly BLL.ProductMemberDiscount pmd = new BLL.ProductMemberDiscount();
        protected readonly BLL.ProductCache bll_pc = new BLL.ProductCache();
        protected readonly BLL.ProductParts bll_pp = new BLL.ProductParts();
        protected readonly BLL.ProductPartsCache bll_ppc = new BLL.ProductPartsCache();
        protected readonly BLL.MemberCartDetail bll_mcd = new BLL.MemberCartDetail();
        protected readonly BLL.MemberCart bll_mc = new BLL.MemberCart();
        private static Model.Product model = new Model.Product();
        protected void Page_Load(object sender, EventArgs e)
        {
            int ProductID = int.Parse(Request["pid"]);//产品ID
            List<int> pp=new List<int>();//部件ID
            for (int i = 0; i < Request["ppid"].Split('|').Length;i++ )
            {
                pp.Add(int.Parse(Request["ppid"].Split('|')[i]));
               
            }
            if (LoginHelper.HasLogin)
            {
                BLL.Product bll = new BLL.Product();
                model = bll.GetModel(ProductID);
                
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
                //mpc.PictureSmall = model.PictureSmall;
                mpc.PictureSmall = "";
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
                Model.ProductCache model_productCache = bll_pc.GetModelByUserIDAndProductID(Common.LoginHelper.UserID, model.ID);
                if (model_productCache == null)
                    bll_pc.Add(mpc);//执行方法,向产品快照表插入数据并返回产品快照表的ID
                #endregion

                #endregion
               
                #region 产品部件快照表,添加数据
                
                List<Model.ProductParts> list_mpp = new List<Model.ProductParts>();
                string ppEN = "";
                string ppCN = "";
                string ppPrice = "";
                decimal price = 0;
                string ppID = "";
                foreach (int i in pp)
                {
                    Model.ProductParts _parts = bll_pp.GetModel(i);
                    list_mpp.Add(_parts);
                    ppEN += _parts.TitleEn+",";
                    ppCN += _parts.Title + ",";
                    ppPrice += _parts.Price + ",";
                    price += _parts.Price;
                    ppID += _parts.ID + ",";
                }
                ppEN = ppEN.Substring(0, ppEN.Length - 1);
                ppCN = ppCN.Substring(0, ppCN.Length - 1);
                ppPrice = ppPrice.Substring(0, ppPrice.Length - 1);
                ppID = ppID.Substring(0, ppID.Length - 1);

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
                        //ppc.PictureSmall = list_mpp[i].PictureSmall;
                        ppc.PictureSmall = "";
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
                if (mod_pmd == null)
                {//如果没有折扣，则为默认
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
                //mod_mcart.DiyTypeCn = model.DiyTypeCn;
                //mod_mcart.DiyTypeEn = model.DiyTypeEn;
                //mod_mcart.DiyTypePartsID = model.DiyTypePartsID;
                //mod_mcart.DiyTypePrice = model.DiyTypePrice;
                mod_mcart.DiyTypeCn = ppCN;
                mod_mcart.DiyTypeEn = ppEN;
                mod_mcart.DiyTypePartsID = ppID;
                mod_mcart.DiyTypePrice = ppPrice;
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
                Model.MemberCartDetail model_mcd = bll_mcd.GetMemberCartDetailByProductCacheIDAndProductPartCacheID(mod_mcart.ProductCacheID, mod_mcart.ProductPartsCacheID);

                if (model_mcd != null)
                {
                    Model.MemberCartDetail model_Membercd = new Model.MemberCartDetail();
                    model_Membercd.Id = model_mcd.Id;
                    model_Membercd.Num = model_mcd.Num + 1;
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
                else
                {

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
                
               Response.Redirect("~/cart.aspx");
            }
            else
            {
                Response.Write("<script>alert('您还没有登录，请登录！');</script>");
            }


             
            Response.End();
        }
    }
}