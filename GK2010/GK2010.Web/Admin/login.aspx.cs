using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
            if (ConfigParam.CheckCode != txtCheckCode.Value.ToLower())
            {
                MessageBox.ShowAlert(this.Page, "验证码错误！");
                return;
            }

            if (Page.IsValid)
            {
                BLL.Member bll = new GK2010.BLL.Member();
                Model.Member model = bll.Login(txtUsername.Value, txtPass.Value);
                if (model != null && model.AdminFlag > 0)
                {
                    if (model.LockFlag == 0)
                    {
                        LoginHelper.Login(model.ID.ToString(), false);
                        Response.Redirect("/Admin/");
                    }
                    else
                    {
                        lblMsg.Text = "您当前状态被锁定，不可以操作！";
                    }
                    
                }
                else
                {
                    lblMsg.Text = "登录失败";
                }
            }
        }
    }
}
