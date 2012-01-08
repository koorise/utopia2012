using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GK2010.Web.Member.MemberInvoiceMail
{
    public partial class member_InvoiceMail_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Model.MemberInvoiceMail model = new Model.MemberInvoiceMail();
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
                BLL.MemberInvoiceMail bll = new BLL.MemberInvoiceMail();
                bll.Add(model);

                Response.Redirect("default.aspx");
            }
        }
    }
}