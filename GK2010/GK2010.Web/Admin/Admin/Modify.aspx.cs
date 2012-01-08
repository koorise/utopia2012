using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.Admin
{
    public partial class Modify : System.Web.UI.Page
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("Admin");
            if (!IsPostBack)
            {
                BLL.MemberGroup bll = new GK2010.BLL.MemberGroup();
                Object obj = bll.GetList("", "");
                RadioButtonListHelper.Bind(radGroupID, "Title", "ID", obj);
               
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
                radGroupID.SelectedValue = model.GroupID.ToString();
                txtUserName.Text = model.UserName;              
                
               
                txtRealName.Text = model.RealName;
                txtEmail.Text = model.Email;
                txtTelephone.Text = model.Telephone;
                txtMobile.Text = model.Mobile;
                txtAddress.Text = model.Address;
                txtPostCode.Text = model.PostCode;
                radLockFlag.SelectedValue = model.LockFlag.ToString();
               
            }
        }
        #endregion


        #region 修改
        public void btnUpdate_Click(object sender, EventArgs e)
        {
            int GroupID = IntHelper.Parse(radGroupID.SelectedValue, 0);         
           
          
            string RealName = txtRealName.Text;
            string Email = txtEmail.Text;
            string Telephone = txtTelephone.Text;
            string Mobile = txtMobile.Text;
            string Address = txtAddress.Text;
            string PostCode = txtPostCode.Text;  
            int LockFlag = IntHelper.Parse(radLockFlag.SelectedValue, 0);


            GK2010.BLL.Member bll = new GK2010.BLL.Member();
            GK2010.Model.Member model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                model.GroupID = GroupID;
           
                model.RealName = RealName;
                model.Email = Email;
                model.Telephone = Telephone;
                model.Mobile = Mobile;
                model.Address = Address;
                model.PostCode = PostCode;
                model.LockFlag = LockFlag;      

                bool ret = bll.Update(model);

                #region 转向到操作结果界面
                if (ret)
                {
                    string ReturnUrl = ConfigParam.ReturnUrl;
                    if (ReturnUrl == "") { ReturnUrl = "manage.aspx"; }
                    MessageBox.ShowAlertAndRedirect(this.Page, "修改成功", "manage.aspx");
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
