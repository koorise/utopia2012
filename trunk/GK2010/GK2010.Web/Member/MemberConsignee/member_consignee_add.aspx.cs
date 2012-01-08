using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.MobileControls;

namespace GK2010.Web.Member.MemberConsignee
{
    public partial class member_consignee_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Model.MemberConsignee model = new Model.MemberConsignee();
                model.UserID = Common.LoginHelper.UserID;
                model.Company = txtCompany.Text;
                model.RealName = txtRealName.Text;
                model.Province = "";
                model.City = "";
                model.Area = "";
                model.Address = txtAddress.Text;
                model.PostCode = txtPostCode.Text;
                model.Telephone = txtTelephone.Text;
                model.Mobile = txtMobile.Text;
                model.Email = txtEmail.Text;
                model.DefaultFlag = chkDefaultFlag.Checked ? 1 : 0;
                BLL.MemberConsignee bll = new BLL.MemberConsignee();
                bll.Add(model);

                Response.Redirect("default.aspx");
            }
        }

    }
}