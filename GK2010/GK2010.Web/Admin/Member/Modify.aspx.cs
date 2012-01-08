using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.Member
{
    public partial class Modify : System.Web.UI.Page
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("Member");
            if (!IsPostBack)
            {
                AdminMember1.UserID = ConfigParam.ID;
                ShowInfo(ConfigParam.ID);
            }
        }
        #endregion


        #region 显示信息
        private void ShowInfo(int ID)
        {
            GK2010.BLL.Member bll = new GK2010.BLL.Member();
            GK2010.Model.Member model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                lblID.Text = model.ID.ToString();             
                txtUserName.Text = model.UserName;              
                txtProvinceID.Text = BLL.ConfigProvince.ProvinceName(model.ProvinceID);
                txtCityID.Text =BLL.ConfigCity.CityName( model.CityID);             
                txtCompany.Text = model.Company;
                txtRealName.Text = model.RealName;
                txtEmail.Text = model.Email;
                txtTelephone.Text = model.Telephone;
                txtMobile.Text = model.Mobile;
                txtAddress.Text = model.Address;
                txtPostCode.Text = model.PostCode;
                txtRegisterDate.Text = DatetimeHelper.Parse(model.RegisterDate, "yyyy-MM-dd HH:mm:ss");
                txtRegisterIP.Text = model.RegisterIP;
                txtLastIP.Text = model.LastIP;
                txtLastDate.Text = DatetimeHelper.Parse(model.LastDate, "yyyy-MM-dd HH:mm:ss");
                txtMobileFlag.Text = model.MobileFlag == 1 ? "已验证" : "未验证";
                txtEmailFlag.Text = model.EmailFlag == 1 ? "已验证" : "未验证";
                radVIPFlag.SelectedValue = model.VIPFlag.ToString();                
                radLockFlag.SelectedValue = model.LockFlag.ToString();
                txtTotalOrder.Text = model.TotalOrder.ToString();
                txtTotalJF.Text = model.TotalJF.ToString();
            }
        }
        #endregion


        #region 修改
        public void btnUpdate_Click(object sender, EventArgs e)
        {

            int VIPFlag = IntHelper.Parse(radVIPFlag.SelectedValue, 0);
            int LockFlag = IntHelper.Parse(radLockFlag.SelectedValue, 0);

            GK2010.BLL.Member bll = new GK2010.BLL.Member();
            GK2010.Model.Member model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                model.VIPFlag = VIPFlag;
                model.LockFlag = LockFlag;
                bool ret = bll.Update(model);

                #region 转向到操作结果界面
                if (ret)
                {
                    //保存相关管理员
                    AdminMember1.Save(ConfigParam.ID);

                    string ReturnUrl = ConfigParam.ReturnUrl;
                    if (ReturnUrl == "") { ReturnUrl = "manage.aspx"; }
                    MessageBox.ShowAlertAndRedirect(this.Page, "修改成功", ReturnUrl);
                }
                else
                {
                    MessageBox.ShowAlert(this.Page, "修改失败");
                }
                #endregion
            }

        }
        #endregion

    }
}
