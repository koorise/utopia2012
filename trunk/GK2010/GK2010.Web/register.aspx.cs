using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ZPageBase_MainChannel.EnumNavigator = EnumNavigator.Index;

        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            if (ConfigParam.CheckCode != txtCheckCode.Text.ToLower())
            {
                MessageBox.ShowAlert(this.Page, "验证码错误！");
                return;
            }

            if (Page.IsValid)
            {
                BLL.Member bll = new GK2010.BLL.Member();
                Model.Member model = new GK2010.Model.Member();              
                model.GroupID = 0;
                model.UserName = txtUserName.Text;
                model.UserPwd = txtUserPwd.Text;
                model.ProvinceID = Request[dropProvince.UniqueID];
                model.CityID = Request[dropCity.UniqueID];
                model.AreaID = "";
                model.Company = txtCompany.Text;
                model.RealName = txtRealName.Text;
                model.Email = txtEmail.Text;
                model.Telephone = txtTelephone.Text;
                model.Mobile = txtMobile.Text;
                model.Address = txtAddress.Text;
                model.PostCode = txtPostCode.Text;
                model.RegisterDate = DatetimeHelper.Now;
                model.RegisterIP = ConfigParam.IP;
                model.LastIP = "";
                model.LastDate = 0; 
                model.MobileFlag = 0;
                model.EmailFlag = 0;
                model.VIPFlag = 0;
                model.AdminFlag = 0;
                model.LockFlag = 0;
                model.TotalOrder = 0;
                model.TotalJF = 0;
                try
                {
                    int UserID = bll.Add(model);
                    if (UserID > 0)
                    {
                        //发送邮件
                        bool ok = EmailHelper.SendActive(UserID, txtEmail.Text);

                        //注册成功
                        Response.Redirect("register_step2.aspx?id=" + UserID + "&Email=" + txtEmail.Text);
                    }
                    else
                    {
                        MessageBox.ShowAlert(this.Page, "注册失败请与管理员联系");
                    }
                }
                catch(Exception ex)
                {
                    BLL.ConfigLog.Add("注册失败", ex.Message, 0);
                }
                
            }
        }
    }
}
