using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;

namespace GK2010.Web.Member.MemberConsignee
{
    public partial class member_consignee_modify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BLL.MemberConsignee bll = new BLL.MemberConsignee();
                Model.MemberConsignee model = bll.GetModel(RequestParam.ConsigneeID);
                if (model != null && model.UserID == Common.LoginHelper.UserID)
                {
                    txtCompany.Text = model.Company;
                    txtRealName.Text = model.RealName;
                    txtAddress.Text = model.Address;
                    txtPostCode.Text = model.PostCode;
                    txtTelephone.Text = model.Telephone;
                    txtMobile.Text = model.Mobile;
                    txtEmail.Text = model.Email;
                    chkDefaultFlag.Checked = model.DefaultFlag == 1;
                }
                else
                    Response.Write("<script>alert('无权查看');history.go(-1);</script>");
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BLL.MemberConsignee bll = new BLL.MemberConsignee();
                Model.MemberConsignee model = bll.GetModel(RequestParam.ConsigneeID);
                if (model != null && model.UserID == Common.LoginHelper.UserID)
                {
                    model.Company = txtCompany.Text;
                    model.RealName = txtRealName.Text;
                    model.Address = txtAddress.Text;
                    model.PostCode = txtPostCode.Text;
                    model.Telephone = txtTelephone.Text;
                    model.Mobile = txtMobile.Text;
                    model.Email = txtEmail.Text;
                    model.DefaultFlag = chkDefaultFlag.Checked ? 1 : 0;

                    bll.Update(model);
                    MessageBox.ShowAlertAndRedirect(this, "修改成功！", "default.aspx");
                }
            }
        }
    }
}