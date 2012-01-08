using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using GK2010.Utility;

namespace GK2010.BLL
{
   public class MemberInvoiceMail
    {
        private Message message;

        public MemberInvoiceMail()
        {
            message = new Message();
        }

        #region Model
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.MemberInvoiceMail GetModel(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            Model.MemberInvoiceMail model = new Model.MemberInvoiceMail();

            DataSet ds = DbHelperSQL.RunProcedure("UP_MemberInvoiceMail_GetModel", parameters, "ds");
            model.Id = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.Company = ds.Tables[0].Rows[0]["Company"].ToString();
                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                model.Province = ds.Tables[0].Rows[0]["Province"].ToString();
                model.City = ds.Tables[0].Rows[0]["City"].ToString();
                model.Area = ds.Tables[0].Rows[0]["Area"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.PostCode = ds.Tables[0].Rows[0]["PostCode"].ToString();
                model.Telephone = ds.Tables[0].Rows[0]["Telephone"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["DefaultFlag"].ToString() != "")
                {
                    model.DefaultFlag = int.Parse(ds.Tables[0].Rows[0]["DefaultFlag"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 添加
        public Message Add(Model.MemberInvoiceMail model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Company", SqlDbType.NVarChar),
					new SqlParameter("@RealName", SqlDbType.NVarChar),
					new SqlParameter("@Province", SqlDbType.NVarChar),
					new SqlParameter("@City", SqlDbType.NVarChar),
					new SqlParameter("@Area", SqlDbType.NVarChar),
					new SqlParameter("@Address", SqlDbType.NVarChar),
					new SqlParameter("@PostCode", SqlDbType.NVarChar),
					new SqlParameter("@Telephone", SqlDbType.NVarChar),
					new SqlParameter("@Mobile", SqlDbType.NVarChar),
					new SqlParameter("@Email", SqlDbType.NVarChar),
					new SqlParameter("@DefaultFlag", SqlDbType.Int,4)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Company;
            parameters[3].Value = model.RealName;
            parameters[4].Value = model.Province;
            parameters[5].Value = model.City;
            parameters[6].Value = model.Area;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.PostCode;
            parameters[9].Value = model.Telephone;
            parameters[10].Value = model.Mobile;
            parameters[11].Value = model.Email;
            parameters[12].Value = model.DefaultFlag;

            DbHelperSQL.RunProcedure("UP_MemberInvoiceMail_ADD", parameters, out rowsAffected);
            int ID = (int)parameters[0].Value;
            if (rowsAffected > 0)
            {
                message.State = State.Success;
                message.Data = ID;
                message.Msg = "添加成功！";
            }
            else
            {
                message.State = State.Error;
                message.Msg = "添加失败！";
            }
            return message;
        }
        #endregion

        #region 修改
        /// <summary>
        ///  更新一条数据
        /// </summary>
        public Message Update(Model.MemberInvoiceMail model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Company", SqlDbType.NVarChar),
					new SqlParameter("@RealName", SqlDbType.NVarChar),
					new SqlParameter("@Province", SqlDbType.NVarChar),
					new SqlParameter("@City", SqlDbType.NVarChar),
					new SqlParameter("@Area", SqlDbType.NVarChar),
					new SqlParameter("@Address", SqlDbType.NVarChar),
					new SqlParameter("@PostCode", SqlDbType.NVarChar),
					new SqlParameter("@Telephone", SqlDbType.NVarChar),
					new SqlParameter("@Mobile", SqlDbType.NVarChar),
					new SqlParameter("@Email", SqlDbType.NVarChar),
					new SqlParameter("@DefaultFlag", SqlDbType.Int,4)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Company;
            parameters[3].Value = model.RealName;
            parameters[4].Value = model.Province;
            parameters[5].Value = model.City;
            parameters[6].Value = model.Area;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.PostCode;
            parameters[9].Value = model.Telephone;
            parameters[10].Value = model.Mobile;
            parameters[11].Value = model.Email;
            parameters[12].Value = model.DefaultFlag;

            DbHelperSQL.RunProcedure("UP_MemberInvoiceMail_Update", parameters, out rowsAffected);

            if (rowsAffected > 0)
            {
                message.State = State.Success;
                message.Msg = "修改成功！";
            }
            else
            {
                message.State = State.Error;
                message.Msg = "修改失败！";
            }
            return message;
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public Message Delete(int ID)
        {

            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            DbHelperSQL.RunProcedure("UP_MemberInvoiceMail_Delete", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                message.State = State.Success;
                message.Msg = "修改成功！";
            }
            else
            {
                message.State = State.Error;
                message.Msg = "修改失败！";
            }
            return message;
        }
        #endregion

       #region 常用收件人列表
       public static string BindMemberInvoiceMail(int UserID)
       {
           StringBuilder sb = new StringBuilder();
           DataSet ds = DbHelperSQL.Query("select * from MemberInvoiceMail where UserID=" + UserID);

           sb.Append("<ul id='addrList'>");
           sb.Append("<li style='border:1px solid #ccc; float:left;margin:0px;padding:5px'>");
           sb.Append("<input type='button' value='同收货人信息' onclick='changeInvoiceMailToConsignee()'>");
           sb.Append("<br />");
           sb.Append("&nbsp;");
           sb.Append("</li>");

           if (ds != null)
           {
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   string strID = ds.Tables[0].Rows[i]["ID"].ToString();
                   string strRealName = ds.Tables[0].Rows[i]["RealName"].ToString();
                   string strAddress = BLL.MemberProvince.GetProvinceName(ds.Tables[0].Rows[i]["Province"].ToString()) + BLL.MemberCity.GetCityName(ds.Tables[0].Rows[i]["City"].ToString()) + BLL.MemberArea.GetAreaName(ds.Tables[0].Rows[i]["Area"].ToString());
                   sb.Append("<li style='border:1px solid #ccc;background:#ffffff; float:left;margin:5px;padding:5px'>");
                   sb.Append("<span>");
                   sb.Append("<input id='radInvoiceMail" + i + "' type='radio' name='radInvoiceMail' onclick='changeInvoiceMail(this," + strID + ");'  />");
                   sb.Append("<label for='radInvoiceMail" + i + "'><strong>常用发票邮寄地址" + (i + 1) + "</strong></label>");
                   sb.Append("</span>");
                   sb.Append("<br />");
                   sb.Append(strRealName + "&nbsp;" + strAddress);
                   sb.Append("</li>");
               }
           }
           sb.Append("</ul><div style='clear:both'></div>");
           return sb.ToString();
       }
        #endregion

       #region 点击更换选项
       public static string showForm_InvoiceMail(int InvoiceMailID)
       {
           StringBuilder sb = new StringBuilder();
           BLL.MemberInvoiceMail bll = new MemberInvoiceMail();
           Model.MemberInvoiceMail model = bll.GetModel(InvoiceMailID);
           if (model != null)
           {
               //表单部份start
               sb.Append(" <form id='frmInvoiceMail' name='frmInvoiceMail'>");
               sb.Append(" <table  border='0' cellspacing='0' cellpadding='0' class='wp95 m_center table2'>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>公司名称：</td><td><input name='InvoiceMailCompany' id='InvoiceMailCompany' type='text' class='input w200' size='50' value='" + model.Company + "' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>收件人姓名：</td><td><input type='text' name='InvoiceMailRealName' id='InvoiceMailRealName' class='input w200' size='50' value='" + model.RealName + "' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>省　　份：</td><td><span id='InvoiceMailArea'>" + BLL.MemberProvince.BindProvince(model.Province, "InvoiceMail") + BLL.MemberCity.BindCity(model.Province, model.City, "InvoiceMail") + BLL.MemberArea.BindArea(model.City, model.Area, "InvoiceMail") + "</span></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>地　　址：</td><td><span id='InvoiceMailAddress'>" + BLL.MemberProvince.GetProvinceName(model.Province) + BLL.MemberCity.GetCityName(model.City) + BLL.MemberArea.GetAreaName(model.Area) + "</span><input type='text' name='InvoiceMailAddress' id='address' class='input w200' size='50' value='" + model.Address + "' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>邮　　编：</td><td><input type='text' class='input w200' name='InvoiceMailPostCode' id='InvoiceMailPostCode' size='20' value='" + model.PostCode + "' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>固定电话：</td><td><input type='text' class='input w200' name='InvoiceMailTelephone' id='InvoiceMailTelephone' size='50' value='" + model.Telephone + "' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>手机号码：</td><td><input type='text' class='input w200' name='InvoiceMailMobile' id='InvoiceMailMobile' size='50' value='" + model.Mobile + "' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>电子邮件：</td><td><input type='text' class='input w200' name='InvoiceMailEmail' id='InvoiceMailEmail' size='50' value='" + model.Email + "' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td>&nbsp;</td><td><input type='button' class='btn_org_big1 B' value='保存发票邮寄信息' onclick='saveForm_InvoiceMail(this)' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" </table>");
               sb.Append(" </form>");
               //表单部份end
           }
           else
           {
               //表单部份start
               sb.Append(" <form id='frmInvoiceMail' name='frmInvoiceMail'>");
               sb.Append(" <table  border='0' cellspacing='0' cellpadding='0' class='wp95 m_center table2'>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>公司名称：</td><td><input name='InvoiceMailCompany' id='InvoiceMailCompany' type='text' class='input w200' size='50'  /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>收件人姓名：</td><td><input type='text' name='InvoiceMailRealName' id='InvoiceMailRealName' class='input w200' size='50'  /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>省　　份：</td><td><span id='InvoiceMailArea'>" + BLL.MemberProvince.BindProvince("", "InvoiceMail") + BLL.MemberCity.BindCity("", "", "InvoiceMail") + BLL.MemberArea.BindArea("", "", "InvoiceMail") + "</span></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>地　　址：</td><td><span id='InvoiceMailAddress'></span><input type='text' name='address' id='address' class='input w200' size='50'  /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr >");
               sb.Append(" <td class='td1'><em>*</em>邮　　编：</td><td><input type='text' class='input w200' name='InvoiceMailPostCode' id='InvoiceMailPostCode' size='20'  /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>固定电话：</td><td><input type='text' class='input w200' name='InvoiceMailTelephone' id='InvoiceMailTelephone' size='50'  /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <tdclass='td1'><em>*</em>手机号码：</td><td><input type='text' class='input w200' name='InvoiceMailMobile' id='InvoiceMailMobile' size='50'  /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>电子邮件：</td><td><input type='text' class='input w200' name='InvoiceMailEmail' id='InvoiceMailEmail' size='50'  /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td>&nbsp;</td><td><input type='button' class='btn_org_big1 B' value='保存发票邮寄信息' onclick='saveForm_InvoiceMail(this)' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" </table>");
               sb.Append(" </form>");
           }

           return sb.ToString();

       }

       //同收货人信息
       public static string showForm_InvoiceMailToConsignee()
       {
           StringBuilder sb = new StringBuilder();
           BLL.MemberCart bll = new MemberCart();
           Model.MemberCart model = bll.GetModelByCartNumAndUserID(Utility.CookieHelper.GetCookies("cartNum"), Utility.CookieHelper.GetCookiesUserID("UserID"));
           if (model != null)
           {
               //表单部份start
               sb.Append(" <form id='frmInvoiceMail' name='frmInvoiceMail'>");
               sb.Append(" <table border='0' cellspacing='0' cellpadding='0' class='wp95 m_center table2'>");
               sb.Append(" <tr >");
               sb.Append(" <td class='td1'><em>*</em>公司名称：</td><td><input name='InvoiceMailCompany' id='InvoiceMailCompany' type='text' class='input w200' size='50' value='" + model.ConsigneeCompany + "' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr >");
               sb.Append(" <td class='td1'><em>*</em>收件人姓名：</td><td><input type='text' name='InvoiceMailRealName' id='InvoiceMailRealName' class='input w200' size='50' value='" + model.ConsigneeRealName + "' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>省　　份：</td><td><span id='InvoiceMailArea'>" + BLL.MemberProvince.BindProvince(model.ConsigneeProvince, "InvoiceMail") + BLL.MemberCity.BindCity(model.ConsigneeProvince, model.ConsigneeCity, "InvoiceMail") + BLL.MemberArea.BindArea(model.ConsigneeCity, model.ConsigneeArea, "InvoiceMail") + "</span></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>地　　址：</td><td><span id='InvoiceMailAddress'>" + BLL.MemberProvince.GetProvinceName(model.ConsigneeProvince) + BLL.MemberCity.GetCityName(model.ConsigneeCity) + BLL.MemberArea.GetAreaName(model.ConsigneeArea) + "</span><input type='text' name='address' id='address' class='input w200' size='50' value='" + model.ConsigneeAddress + "' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>邮　　编：</td><td><input type='text' class='input w200' name='InvoiceMailPostCode' id='InvoiceMailPostCode' size='20' value='" + model.ConsigneePostCode + "' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>固定电话：</td><td><input type='text' class='input w200' name='InvoiceMailTelephone' id='InvoiceMailTelephone' size='50' value='" + model.ConsigneeTelephone + "' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>手机号码：</td><td><input type='text'  class='input w200' name='InvoiceMailMobile' id='InvoiceMailMobile' size='50' value='" + model.ConsigneeMobile + "' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>电子邮件：</td><td><input type='text'  class='input w200' name='InvoiceMailEmail' id='InvoiceMailEmail' size='50' value='" + model.ConsigneeEmail + "' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td>&nbsp;</td><td><input type='button' class='btn_org_big1 B'  value='保存发票邮寄信息' onclick='saveForm_InvoiceMail(this)' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" </table>");
               sb.Append(" </form>");
               //表单部份end
           }
           else
           {
               //表单部份start
               sb.Append(" <form id='frmInvoiceMail' name='frmInvoiceMail'>");
               sb.Append(" <table  border='0' cellspacing='0' cellpadding='0' class='wp95 m_center table2'>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>公司名称：</td><td><input name='InvoiceMailCompany' id='InvoiceMailCompany' type='text' class='input w200' size='50'  /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>收件人姓名：</td><td><input type='text' name='InvoiceMailRealName' id='InvoiceMailRealName' class='input w200' size='50'  /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>省　　份：</td><td><span id='InvoiceMailArea'>" + BLL.MemberProvince.BindProvince("", "InvoiceMail") + BLL.MemberCity.BindCity("", "", "InvoiceMail") + BLL.MemberArea.BindArea("", "", "InvoiceMail") + "</span></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>地　　址：</td><td><span id='InvoiceMailAddress'></span><input type='text' name='address' id='address' class='input w200' size='50'  /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>邮　　编：</td><td><input type='text' class='input w200' name='InvoiceMailPostCode' id='InvoiceMailPostCode' size='20'  /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>固定电话：</td><td><input type='text' class='input w200' name='InvoiceMailTelephone' id='InvoiceMailTelephone' size='50'  /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>手机号码：</td><td><input type='text' class='input w200' name='InvoiceMailMobile' id='InvoiceMailMobile' size='50'  /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td class='td1'><em>*</em>电子邮件：</td><td><input type='text' class='input w200' name='InvoiceMailEmail' id='InvoiceMailEmail' size='50'  /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" <tr>");
               sb.Append(" <td>&nbsp;</td><td><input type='button' class='saveButton' value='保存发票邮寄信息' onclick='saveForm_InvoiceMail(this)' /></td><td></td>");
               sb.Append(" </tr>");
               sb.Append(" </table>");
               sb.Append(" </form>");
           }

           return sb.ToString();

       }
       #endregion
    }
}
