using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Common;
using GK2010.Utility;
using System.Text;
namespace GK2010.Web.Controls
{
    public partial class ControlTop : System.Web.UI.UserControl
    {
        public EnumNavigator EnumNavigator = EnumNavigator.Index;
        protected readonly BLL.MemberCart bll_mc = new BLL.MemberCart();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 登录状态
                if (LoginHelper.HasLogin)
                {
                    panHasLogin.Visible = true;
                    panHasNotLogin.Visible = false;

                    Model.Member modelMember = LoginHelper.Member;
                    lblRealName.Text = modelMember.RealName;
                    #region 查询用户购物车编号和产品数量
                    Model.MemberCart model_mc = bll_mc.GetModelByUserID(Common.LoginHelper.UserID);
                    if (model_mc != null)
                        litCart.Text = "<a href='/cart.aspx' >购物车有<span id='top_zsl'>" + model_mc.TotalNum + "</span>件商品</a>";
                    else
                        litCart.Text = "<a href='/cart.aspx'>购物车有0件商品</a>";
                    #endregion
                    lit_jz.Text = "<a href='/cart.aspx'>去结账</a>";
                }
                else
                {
                    panHasLogin.Visible = false;
                    panHasNotLogin.Visible = true;
                    litCart.Text = "购物车有0件商品";
                    lit_jz.Text = "<a href='/login.aspx'>去结账</a>";
                }
                #endregion
            }

            

            #region 网站导航
            StringBuilder sb = new StringBuilder();
            sb.AppendLine( "<ul>");
            BLL.ConfigNavigator bllConfigNavigator = new GK2010.BLL.ConfigNavigator();
            List<Model.ConfigNavigator> modelsConfigNavigator = bllConfigNavigator.GetList("", "Index");
            foreach (Model.ConfigNavigator model in modelsConfigNavigator)
            {
                string strCurrent = EnumNavigator.ToString().ToLower();
                string strCurrentDB = model.TitleEn.ToLower();
                string strClass = "";
                if (strCurrent == strCurrentDB) strClass = "class=\"select\"";                
                sb.AppendLine("<li " + strClass + "><a href=\"" + model.Url + "\">" + model.Title + "</a></li>");
            }
            sb.AppendLine("</ul>");
            txtNavigator.Text = sb.ToString();
            #endregion
        }

        #region 搜索
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Tag = txtTag.Value;
            if (Tag == "输入搜索关键字")
            {
                Tag = "";
            }
            string Url = string.Format(ConfigUrl.UrlSearch, Tag);
            Response.Redirect(Url);
        }
        #endregion
        
    }
}