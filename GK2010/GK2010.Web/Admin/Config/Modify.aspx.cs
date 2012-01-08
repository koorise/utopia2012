using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.Config
{
    public partial class Modify :System.Web.UI.Page
    {
       
	    #region Page_Load
	    protected void Page_Load(object sender, EventArgs e)
	    {
		    BLL.SystemTree.CheckPermission("Config");
		    if (!IsPostBack)
		    {
			    ShowInfo();
		    }
	    }
	    #endregion
    	

	    #region 显示信息
	    private void ShowInfo()
	    {
		    GK2010.BLL.Config bll=new GK2010.BLL.Config();
		    GK2010.Model.Config model=bll.GetModel(1);
		    if(model != null)
		    {
			    txtWebDomain.Text = model.WebDomain;
			    txtWebName.Text = model.WebName;
			    txtWebBeian.Text = model.WebBeian;
			    txtWebStatic.Text = model.WebStatic;
			    txtControlService.Text = model.ControlService;
                txtControlTop.Value = model.ControlTop;
			    txtControlBoot.Value = model.ControlBoot;
			    radShowPriceDiyFlag.SelectedValue = model.ShowPriceDiyFlag.ToString();
                radShowPriceWhenNotLogin.SelectedValue = model.ShowPriceWhenNotLogin.ToString();
                //txtAliPayAccount.Text = model.AliPayAccount;
                //txtAliPayPartnerID.Text = model.AliPayPartnerID;
                //txtAliPayKey.Text = model.AliPayKey;
                //txtAliPayUserName.Text = model.AliPayUserName;
                //txtAliPayUserPwd.Text = model.AliPayUserPwd;
			    txtEmailUserName.Text = model.EmailUserName;
			    txtEmailUserPwd.Text = model.EmailUserPwd;
			    txtEmailHost.Text = model.EmailHost;
			    txtEmailPort.Text = model.EmailPort;
                //txtMobileUserName.Text = model.MobileUserName;
                //txtMobileUserPwd.Text = model.MobileUserPwd;
                //txtMobileEID.Text = model.MobileEID;
		    }
	    }
	    #endregion


	    #region 修改
	    public void btnUpdate_Click(object sender, EventArgs e)
	    {
		    string WebDomain = txtWebDomain.Text;
		    string WebName = txtWebName.Text;
		    string WebBeian = txtWebBeian.Text;
		    string WebStatic = txtWebStatic.Text;
		    string ControlService = txtControlService.Text;
		    string ControlTop = txtControlTop.Value;
            string ControlBoot = txtControlBoot.Value;
		    int ShowPriceDiyFlag = IntHelper.Parse(radShowPriceDiyFlag.SelectedValue,0);
            int ShowPriceWhenNotLogin = IntHelper.Parse(radShowPriceWhenNotLogin.SelectedValue, 0);
            //string AliPayAccount = txtAliPayAccount.Text;
            //string AliPayPartnerID = txtAliPayPartnerID.Text;
            //string AliPayKey = txtAliPayKey.Text;
            //string AliPayUserName = txtAliPayUserName.Text;
            //string AliPayUserPwd = txtAliPayUserPwd.Text;
		    string EmailUserName = txtEmailUserName.Text;
		    string EmailUserPwd = txtEmailUserPwd.Text;
		    string EmailHost = txtEmailHost.Text;
		    string EmailPort = txtEmailPort.Text;
            //string MobileUserName = txtMobileUserName.Text;
            //string MobileUserPwd = txtMobileUserPwd.Text;
            //string MobileEID = txtMobileEID.Text;


		    GK2010.BLL.Config bll = new GK2010.BLL.Config();
		    GK2010.Model.Config model = bll.GetModel(1);
		    if(model != null)
		    {
			   
			    model.WebDomain=WebDomain;
			    model.WebName=WebName;
			    model.WebBeian=WebBeian;
			    model.WebStatic=WebStatic;
			    model.ControlService=ControlService;
			    model.ControlTop=ControlTop;
			    model.ControlBoot=ControlBoot;
			    model.ShowPriceDiyFlag=ShowPriceDiyFlag;
			    model.ShowPriceWhenNotLogin=ShowPriceWhenNotLogin;
                //model.AliPayAccount=AliPayAccount;
                //model.AliPayPartnerID=AliPayPartnerID;
                //model.AliPayKey=AliPayKey;
                //model.AliPayUserName=AliPayUserName;
                //model.AliPayUserPwd=AliPayUserPwd;
			    model.EmailUserName=EmailUserName;
			    model.EmailUserPwd=EmailUserPwd;
			    model.EmailHost=EmailHost;
			    model.EmailPort=EmailPort;
                //model.MobileUserName=MobileUserName;
                //model.MobileUserPwd=MobileUserPwd;
                //model.MobileEID=MobileEID;

			    bool ret = bll.Update(model);
    			
			    #region 转向到操作结果界面
			     if (ret)
			    {				  
				    MessageBox.ShowAlert(this.Page, "保存成功");
			    }
			    else
			    {
                    MessageBox.ShowAlert(this.Page, "保存失败");
			    }
			    #endregion
		    }

	    }
	    #endregion

    }
}
