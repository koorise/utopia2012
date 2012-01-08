using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;

namespace GK2010.Web
{
    public partial class MemberCartNum_UpdateNum : System.Web.UI.Page
    {
        protected readonly BLL.MemberCart bll_mc = new BLL.MemberCart();
        protected readonly BLL.MemberCartDetail bll_mcd = new BLL.MemberCartDetail();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Action"] != null && Request.QueryString["Action"] != "" && Request.QueryString["Num"] != null && Request.QueryString["Num"] != "" && Request.QueryString["CartNum"] != null && Request.QueryString["CartNum"] !="" && Request.QueryString["MemberCartDetail_ID"] != null &&Request.QueryString["MemberCartDetail_ID"] != "")
            {
                if (Request.QueryString["Action"].ToString() == "update")
                {
                    string ret = update();
                    Response.Write(ret);
                    Response.End();
                }
            }
        }


        #region 更新数据
        protected string update()
        {
            int num = int.Parse(Request.QueryString["Num"].ToString());
            int memberCartDetail_ID = int.Parse(Request.QueryString["MemberCartDetail_ID"].ToString());
            string cartNum = Request.QueryString["CartNum"].ToString();

            #region 更新购物详细表的数据
            Model.MemberCartDetail model_mcd = bll_mcd.GetModelByID(memberCartDetail_ID);
            if (model_mcd != null)
            {
                model_mcd.Num = num;
                model_mcd.TotalPrice = model_mcd.Price * num;
                model_mcd.TotalJF = model_mcd.JF * num;
            }
            bool result = bll_mcd.UpdatePartDataByID(model_mcd);//更新购物车详细表

            #endregion

            #region 更新购物表的数据
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
            }

            Model.MemberCart model_mc = new Model.MemberCart();
            model_mc.TotalJF = mc_TotalJF;
            model_mc.CartNum = cartNum;
            model_mc.TotalNum = mc_TotalNum;
            model_mc.TotalProductPrice = mc_TotalProductPrice;
            model_mc.TotalPrice = mc_TotalProductPrice;

            bool result1 = bll_mc.UpdateMemberCartByPart(model_mc);//更新购物车表
            #endregion

            Utility.Message msg = new Utility.Message();
            if (result == true && result1 == true)
            {
                msg.State = State.Success;
                string ms= model_mcd.TotalPrice.ToString() + "|" + model_mcd.TotalJF.ToString() + "|" 
                    + model_mc.TotalNum.ToString() + "|" + model_mc.TotalJF.ToString() + "|" 
                    + model_mc.TotalProductPrice.ToString();
                return ms;
            }
            else
            {
                msg.State = State.Error;
                return "";
            }
        }
        #endregion
    }

}