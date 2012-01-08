using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.Admin
{
    public partial class Add : System.Web.UI.Page
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
            }
        }
        #endregion

        #region 添加
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int GroupID = IntHelper.Parse(radGroupID.SelectedValue, 0);
            string UserName = txtUserName.Text;
            string UserPwd = txtUserPwd.Text;
        
            string RealName = txtRealName.Text;
            string Email = txtEmail.Text;
            string Telephone = txtTelephone.Text;
            string Mobile = txtMobile.Text;
            string Address = txtAddress.Text;
            string PostCode = txtPostCode.Text;
            long RegisterDate = DatetimeHelper.Now;
            string RegisterIP = ConfigParam.IP;
            string LastIP = "";
            long LastDate = 0;
            int MobileFlag = 0;
            int EmailFlag = 0;
            int VIPFlag = 0;
            int AdminFlag = 2;
            int LockFlag = 0;
            int TotalOrder = 0;
            decimal TotalJF = 0;

            GK2010.Model.Member model = new GK2010.Model.Member();
            model.GroupID = GroupID;
            model.UserName = UserName;
            model.UserPwd = UserPwd;
           
           
            model.RealName = RealName;
            model.Email = Email;
            model.Telephone = Telephone;
            model.Mobile = Mobile;
            model.Address = Address;
            model.PostCode = PostCode;
            model.RegisterDate = RegisterDate;
            model.RegisterIP = RegisterIP;
            model.LastIP = LastIP;
            model.LastDate = LastDate;
            model.MobileFlag = MobileFlag;
            model.EmailFlag = EmailFlag;
            model.VIPFlag = VIPFlag;
            model.AdminFlag = AdminFlag;
            model.LockFlag = LockFlag;
            model.TotalOrder = TotalOrder;
            model.TotalJF = TotalJF;

            GK2010.BLL.Member bll = new GK2010.BLL.Member();
            int ret = bll.Add(model);
            #region 转向到操作结果界面
            if (ret > 0)
            {
                MessageBox.ShowAlertAndRedirect(this.Page, "添加成功", "manage.aspx");
            }
            else
            {
                MessageBox.ShowAlert(this.Page, "添加失败");
            }
            #endregion


        }
        #endregion

    }
}
