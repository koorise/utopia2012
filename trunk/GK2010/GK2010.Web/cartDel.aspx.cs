using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;

namespace GK2010.Web
{
    public partial class cartDel : System.Web.UI.Page
    {

        protected readonly BLL.MemberCartDetail bll_mcd = new BLL.MemberCartDetail();
        protected readonly BLL.MemberCart bll_mc = new BLL.MemberCart();
        protected readonly BLL.ProductPartsCache bll_ppc = new BLL.ProductPartsCache();
        protected readonly BLL.ProductCache bll_pc = new BLL.ProductCache();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.LoginHelper.HasLogin)
            {
                if (Request.QueryString["Modth"] != null)
                {
                    if (Request.QueryString["Modth"].ToString() == "del")
                    {
                        if (Request.QueryString["ID"] != null)
                        {
                            int memberCartDetail = int.Parse(Request.QueryString["ID"].ToString());
                            if (memberCartDetail > 0)
                            {
                                Model.MemberCartDetail model_mcd = bll_mcd.GetModelByID(memberCartDetail);
                                string cartNum = model_mcd.CartNum;//购物车编号
                                #region 删除产品的一些信息
                                if (model_mcd != null)
                                {
                                    //删除产品部件快照
                                    if (model_mcd.ProductPartsCacheID != 0)
                                        bll_ppc.DeleteByProductPartsCacheID(model_mcd.ProductPartsCacheID);
                                    //删除产品快照
                                    if (model_mcd.ProductCacheID != 0)
                                        bll_pc.DeleteByProductCacheID(model_mcd.ProductCacheID);
                                    //删除购物详细表的产品
                                    if (model_mcd.Id != 0)
                                        bll_mcd.DeleteByID(model_mcd.Id);
                                }
                                #endregion

                                #region 根据购物车编号查询所有购物详细表里面的产品
                                List<Model.MemberCartDetail> list = bll_mcd.GetMemberCartDetailByCartNum(cartNum);
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

                                    Model.MemberCart mmc = new Model.MemberCart();
                                    mmc.CartNum = cartNum;
                                    mmc.TotalJF = mc_TotalJF;
                                    mmc.TotalNum = mc_TotalNum;
                                    mmc.TotalPrice = mc_TotalProductPrice;
                                    mmc.TotalProductPrice = mc_TotalProductPrice;

                                    bll_mc.UpdateMemberCartByPart(mmc);//更新购物车表中的数据
                                }
                                else
                                {
                                    //删除购物车中的数据
                                    bll_mc.DeleteByCartNum(cartNum);
                                }

                                #endregion

                                Response.Redirect("/cart.aspx");
                            }
                        }
                    }
                }
                else
                {
                    Utility.MessageBox.ShowAlertAndRedirect(this, "删除失败", "cart.aspx");
                }
            }
        }
    }
}