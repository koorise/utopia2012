using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;

namespace GK2010.Web
{
    public partial class MemberCart_checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 收件人信息

            if (RequestParam.Action == "showForm_Consignee")
            {
                Response.Write(StringHelper.CreareJson(BLL.MemberCart.showForm_Consignee(), 1));
                Response.End();
            }

            if (RequestParam.Action == "saveForm_Consignee")
            {
                string i = BLL.MemberCart.saveForm_Consignee();
                Response.Write(i);
                Response.End();
            }

            if (RequestParam.Action == "closeForm_Consignee")
            {
                Response.Write(StringHelper.CreareJson(BLL.MemberCart.closeForm_Consignee(), 1));
                Response.End();
            }

            if (RequestParam.Action == "saveForm_Consignee")
            {
                Response.Write(BLL.MemberCart.saveForm_Consignee());
                Response.End();
            }
            if (RequestParam.Action == "changeArea_province")
            {
                string Province = RequestParam.ConsigneeProvince;
                string ret = BLL.MemberProvince.BindProvince(Province, "Consignee") + BLL.MemberCity.BindCity(Province, "", "Consignee") + BLL.MemberArea.BindArea("", "", "Consignee");
                Response.Write(StringHelper.CreareJson(ret, 1));
                Response.End();
            }
            if (RequestParam.Action == "changeArea_city")
            {
                string Province = RequestParam.ConsigneeProvince;
                string City = RequestParam.ConsigneeCity;
                string ret = BLL.MemberProvince.BindProvince(Province, "Consignee") + BLL.MemberCity.BindCity(Province, City, "Consignee") + BLL.MemberArea.BindArea(City, "", "Consignee");
                Response.Write(StringHelper.CreareJson(ret, 1));
                Response.End();
            }
            if (RequestParam.Action == "changeConsignee")
            {
                int ConsigneeID = RequestParam.ConsigneeID;
                string ret = BLL.MemberConsignee.showForm_Consignee(ConsigneeID);
                Response.Write(StringHelper.CreareJson(ret, 1));
                Response.End();
            }
            #endregion

            #region 发票邮寄信息

            if (RequestParam.Action == "showForm_InvoiceMail")
            {
                Response.Write(StringHelper.CreareJson(BLL.MemberCart.showForm_InvoiceMail(), 1));
                Response.End();
            }

            if (RequestParam.Action == "changeInvoiceMail")
            {
                int InvoiceMailID = RequestParam.InvoiceMailID;
                string ret = BLL.MemberInvoiceMail.showForm_InvoiceMail(InvoiceMailID);
                Response.Write(StringHelper.CreareJson(ret, 1));
                Response.End();
            }

            if (RequestParam.Action == "changeInvoiceMailToConsignee")
            {

                string ret = BLL.MemberInvoiceMail.showForm_InvoiceMailToConsignee();
                Response.Write(StringHelper.CreareJson(ret, 1));
                Response.End();
            }

            if (RequestParam.Action == "saveForm_InvoiceMail")
            {
                Response.Write(BLL.MemberCart.saveForm_InvoiceMail());
                Response.End();
            }

            if (RequestParam.Action == "changeArea_InvoiceMailProvince")
            {
                string Province = RequestParam.InvoiceMailProvince;
                string ret = BLL.MemberProvince.BindProvince(Province, "InvoiceMail") + BLL.MemberCity.BindCity(Province, "", "InvoiceMail") + BLL.MemberArea.BindArea("", "", "InvoiceMail");
                Response.Write(StringHelper.CreareJson(ret, 1));
                Response.End();
            }
            if (RequestParam.Action == "changeArea_InvoiceMailCity")
            {
                string Province = RequestParam.InvoiceMailProvince;
                string City = RequestParam.InvoiceMailCity;
                string ret = BLL.MemberProvince.BindProvince(Province, "InvoiceMail") + BLL.MemberCity.BindCity(Province, City, "InvoiceMail") + BLL.MemberArea.BindArea(City, "", "InvoiceMail");
                Response.Write(StringHelper.CreareJson(ret, 1));
                Response.End();
            }

            if (RequestParam.Action == "closeForm_InvoiceMail")
            {
                Response.Write(StringHelper.CreareJson(BLL.MemberCart.closeForm_InvoiceMail(), 1));
                Response.End();
            }

            #endregion
        }
    }
}