using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ZPageBase_MainChannel.EnumNavigator = EnumNavigator.Index;
        }

        #region 用户登录
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string userName = txtUserName.Text.Trim();
                string Password = txtUserPwd.Text.Trim();

                BLL.Member bllMember = new BLL.Member();
                Model.Member memberInfo = bllMember.Login(userName, Password);
                if (memberInfo != null)
                {
                    if (memberInfo.LockFlag == 0)
                    {
                        LoginHelper.Login(memberInfo.ID.ToString(), false);
                        Response.Redirect("/Member/");
                    }
                    else
                    {
                        lblMsg.Text = "您当前状态被销定，无法进行操作！";
                    }
                }
                else
                {
                    lblMsg.Text = "登录失败，帐号或密码错误！";
                }
            }
        }
        #endregion
    }
}
