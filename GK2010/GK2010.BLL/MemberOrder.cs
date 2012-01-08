using System;
using System.Collections.Generic;
using System.Text;
using GK2010.Model;
using GK2010.DAL;
using System.Data;
using System.Data.SqlClient;
using GK2010.Utility;


namespace GK2010.BLL
{
   public class MemberOrder
   {
       #region 私有变量
       private readonly GK2010.DAL.MemberOrder mc = new DAL.MemberOrder();
       #endregion

       #region 增加一条数据
       public int Add(Model.MemberOrder model) {
           return mc.Add(model);
       }
       #endregion

      // #region 根据用户id返回数据,得到一个实体
      // public Model.MemberOrder GetModelByUserID(int userID)
      // {
      //     List<Model.MemberOrder> list = DataTableToList(mc.GetDataSetByUserID(userID).Tables[0]);
      //     if (list.Count > 0)
      //         return list[0];
      //     else
      //         return null;
      // }
      // #endregion

      // #region 根据购物车编号返回数据,得到一个实体
      // public Model.MemberOrder GetModelByCartNum(string cartNum)
      // {
      //     List<Model.MemberOrder> list = DataTableToList(mc.GetDataSetByCartNum(cartNum).Tables[0]);
      //     if (list.Count > 0)
      //         return list[0];
      //     else
      //         return null;
      // }
      // #endregion

      // #region 根据购物车编号和会员id返回数据，得到一个实体
      // /// <summary>
      // /// 得到一个对象实体
      // /// </summary>
      // public Model.MemberOrder GetModelByCartNumAndUserID(string cartNum, int userID)
      // {
      //     SqlParameter[] parameters = {
      //              new SqlParameter("@cartNum", SqlDbType.NVarChar,50),
      //              new SqlParameter("@UserID", SqlDbType.Int,4)
      //          };
      //     parameters[0].Value = cartNum;
      //     parameters[1].Value = userID;
      //     Model.MemberOrder model = new Model.MemberOrder();

      //     DataSet ds = DbHelperSQL.RunProcedure("UP_MemberOrderConsignee_GetModelByCartNumAndUserID", parameters, "ds");
      //     model.CartNum = cartNum;
      //     model.UserID = userID;
      //     if (ds.Tables[0].Rows.Count > 0)
      //     {
      //         if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
      //         {
      //             model.Id = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
      //         }
      //         model.ConsigneeCompany = ds.Tables[0].Rows[0]["ConsigneeCompany"].ToString();
      //         model.ConsigneeRealName = ds.Tables[0].Rows[0]["ConsigneeRealName"].ToString();
      //         model.ConsigneeProvince = ds.Tables[0].Rows[0]["ConsigneeProvince"].ToString();
      //         model.ConsigneeCity = ds.Tables[0].Rows[0]["ConsigneeCity"].ToString();
      //         model.ConsigneeArea = ds.Tables[0].Rows[0]["ConsigneeArea"].ToString();
      //         model.ConsigneeAddress = ds.Tables[0].Rows[0]["ConsigneeAddress"].ToString();
      //         model.ConsigneePostCode = ds.Tables[0].Rows[0]["ConsigneePostCode"].ToString();
      //         model.ConsigneeTelephone = ds.Tables[0].Rows[0]["ConsigneeTelephone"].ToString();
      //         model.ConsigneeMobile = ds.Tables[0].Rows[0]["ConsigneeMobile"].ToString();
      //         model.ConsigneeEmail = ds.Tables[0].Rows[0]["ConsigneeEmail"].ToString();
      //         return model;
      //     }
      //     else
      //     {
      //         return null;
      //     }
      // }
      // #endregion

      // #region 加入购物车时，更新购物车里面的部分信息
      // public bool UpdateMemberOrderByPart(Model.MemberOrder mod_mc){
      //     return mc.UpdateMemberOrderByPart(mod_mc);
      // }
      // #endregion

      // #region 根据购物车编号删除数据
      // public bool DeleteByCartNum(string cartNum)
      // {
      //     return mc.DeleteByCartNum(cartNum);
      // }
      // #endregion

      // #region  转换数据列表
      // /// <summary>
      // /// 转换数据列表
      // /// </summary>
      // public List<GK2010.Model.MemberOrder> DataTableToList(DataTable dt)
      // {
      //     return DataTableToList(dt.Select());
      // }
      // /// <summary>
      // /// 转换数据列表
      // /// </summary>
      // public List<GK2010.Model.MemberOrder> DataTableToList(DataRow[] drs)
      // {
      //     List<GK2010.Model.MemberOrder> modelList = new List<GK2010.Model.MemberOrder>();
      //     GK2010.Model.MemberOrder model;
      //     foreach (DataRow dr in drs)
      //     {
      //         model = new GK2010.Model.MemberOrder();
      //         if (dr["Id"].ToString() != "")
      //         {
      //             model.Id = int.Parse(dr["Id"].ToString());
      //         }
      //         model.CartNum = dr["CartNum"].ToString();
      //         model.ConsigneeAddress = dr["ConsigneeAddress"].ToString();
      //         model.ConsigneeArea = dr["ConsigneeArea"].ToString();
      //         model.ConsigneeCity = dr["ConsigneeCity"].ToString();
      //         model.ConsigneeCompany = dr["ConsigneeCompany"].ToString();
      //         model.ConsigneeEmail = dr["ConsigneeEmail"].ToString();
      //         model.ConsigneeMobile = dr["ConsigneeMobile"].ToString();
      //         model.ConsigneePostCode = dr["ConsigneePostCode"].ToString();
      //         model.ConsigneeProvince = dr["ConsigneeProvince"].ToString();
      //         model.ConsigneeRealName = dr["ConsigneeRealName"].ToString();
      //         model.ConsigneeTelephone = dr["ConsigneeTelephone"].ToString();
      //         model.InvoiceAddress = dr["InvoiceAddress"].ToString();

      //         if (dr["EditUserID"].ToString() != "")
      //         {
      //             model.EditUserID = int.Parse(dr["EditUserID"].ToString());
      //         }

      //         if (dr["EditDate"].ToString() != "")
      //         {
      //             model.EditDate = long.Parse(dr["EditDate"].ToString());
      //         }

      //         model.InvoiceBank = dr["InvoiceBank"].ToString();
      //         model.InvoiceBankAccount = dr["InvoiceBankAccount"].ToString();
      //         model.InvoiceCompany = dr["InvoiceCompany"].ToString();
      //         model.InvoiceContent = dr["InvoiceContent"].ToString();
      //         model.InvoiceMailAddress = dr["InvoiceMailAddress"].ToString();
      //         model.InvoiceMailArea = dr["InvoiceMailArea"].ToString();
      //         model.InvoiceMailCity = dr["InvoiceMailCity"].ToString();
      //         model.InvoiceMailCompany = dr["InvoiceMailCompany"].ToString();
      //         model.InvoiceMailEmail = dr["InvoiceMailEmail"].ToString();
      //         model.InvoiceMailMobile = dr["InvoiceMailMobile"].ToString();
      //         model.InvoiceMailPostCode = dr["InvoiceMailPostCode"].ToString();
      //         model.InvoiceMailProvince = dr["InvoiceMailProvince"].ToString();
      //         model.InvoiceMailRealName = dr["InvoiceMailRealName"].ToString();
      //         model.InvoiceMailTelephone = dr["InvoiceMailTelephone"].ToString();
      //         model.InvoiceNum = dr["InvoiceNum"].ToString();
      //         model.InvoiceTelephone = dr["InvoiceTelephone"].ToString();
      //         model.InvoiceType = dr["InvoiceType"].ToString();
      //         model.Liuyan = dr["Liuyan"].ToString();
      //         model.PayType = dr["PayType"].ToString();
      //         model.Remark = dr["Remark"].ToString();
      //         model.ShipType = dr["ShipType"].ToString();
      //         if (dr["PostDate"].ToString() != "")
      //         {
      //             model.PostDate = long.Parse(dr["PostDate"].ToString());
      //         }
      //         if (dr["PostUserID"].ToString() != "")
      //         {
      //             model.PostUserID = int.Parse(dr["PostUserID"].ToString());
      //         }
      //         if (dr["StatusDate"].ToString() != "")
      //         {
      //             model.StatusDate = long.Parse(dr["StatusDate"].ToString());
      //         }

      //         if (dr["StatusFlag"].ToString() != "")
      //         {
      //             model.StatusFlag = int.Parse(dr["StatusFlag"].ToString());
      //         }
      //         if (dr["StatusUserID"].ToString() != "")
      //         {
      //             model.StatusUserID = int.Parse(dr["StatusUserID"].ToString());
      //         }
      //         if (dr["TotalNum"].ToString() != "")
      //         {
      //             model.TotalNum = int.Parse(dr["TotalNum"].ToString());
      //         }
      //         if (dr["TotalOtherPrice"].ToString() != "")
      //         {
      //             model.TotalOtherPrice = decimal.Parse(dr["TotalOtherPrice"].ToString());
      //         }
      //         if (dr["TotalJF"].ToString() != "")
      //         {
      //             model.TotalJF = decimal.Parse(dr["TotalJF"].ToString());
      //         }

      //         if (dr["TotalPrice"].ToString() != "")
      //         {
      //             model.TotalPrice = decimal.Parse(dr["TotalPrice"].ToString());
      //         }
      //         if (dr["TotalProductPrice"].ToString() != "")
      //         {
      //             model.TotalProductPrice = decimal.Parse(dr["TotalProductPrice"].ToString());
      //         }
      //         if (dr["TotalShipPrice"].ToString() != "")
      //         {
      //             model.TotalShipPrice = decimal.Parse(dr["TotalShipPrice"].ToString());
      //         }
      //         if (dr["UserID"].ToString() != "")
      //         {
      //             model.UserID = int.Parse(dr["UserID"].ToString());
      //         }
      //         modelList.Add(model);
      //     }
      //     return modelList;
      // }
      // #endregion

      //#region 收件人收货信息
      // #region 收件人保存
      // public static string saveForm_Consignee()
      // {
      //     #region 验证输入
      //     if (RequestParam.ConsigneeCompany == "")
      //     {
      //         return StringHelper.CreareJson("请输入公司名称！", 0);
      //     }
      //     if (RequestParam.ConsigneeRealName == "")
      //     {
      //         return StringHelper.CreareJson("请输入收货人姓名！", 0);
      //     }
      //     if (RequestParam.ConsigneeProvince == "0")
      //     {
      //         return StringHelper.CreareJson("地区信息不完整！", 0);
      //     }
      //     if (RequestParam.ConsigneeCity == "0")
      //     {
      //         return StringHelper.CreareJson("地区信息不完整！", 0);
      //     }
      //     if (RequestParam.ConsigneeArae == "0")
      //     {
      //         return StringHelper.CreareJson("地区信息不完整！", 0);
      //     }
      //     if (RequestParam.ConsigneeAddress == "")
      //     {
      //         return StringHelper.CreareJson("请输入地址！", 0);
      //     }
      //     if (RequestParam.ConsigneePostCode == "")
      //     {
      //         return StringHelper.CreareJson("请输入邮政编码！", 0);
      //     }
      //     if (RequestParam.ConsigneeTelephone == "")
      //     {
      //         return StringHelper.CreareJson("请输入电话号码！", 0);
      //     }
      //     if (RequestParam.ConsigneeMobile == "")
      //     {
      //         return StringHelper.CreareJson("请输入手机号码！", 0);
      //     }
      //     if (RequestParam.ConsigneeEmail == "")
      //     {
      //         return StringHelper.CreareJson("请输入电子邮件！", 0);
      //     }
      //     #endregion

      //     BLL.MemberOrder bll = new MemberOrder();
      //     DAL.MemberOrder dal =  new DAL.MemberOrder();
      //     Model.MemberOrder model = bll.GetModelByCartNum(CookieHelper.GetCookies("cartNum"));
      //     if (model != null && model.UserID == CookieHelper.GetCookiesUserID("UserID"))
      //     {
      //         model.UserID = CookieHelper.GetCookiesUserID("UserID");
      //         model.CartNum = CookieHelper.GetCookies("cartNum");
      //         model.ConsigneeCompany = RequestParam.ConsigneeCompany;
      //         model.ConsigneeRealName = RequestParam.ConsigneeRealName;
      //         model.ConsigneeProvince = RequestParam.ConsigneeProvince;
      //         model.ConsigneeCity = RequestParam.ConsigneeCity;
      //         model.ConsigneeArea = RequestParam.ConsigneeArae;
      //         model.ConsigneeAddress = RequestParam.ConsigneeAddress;
      //         model.ConsigneePostCode = RequestParam.ConsigneePostCode;
      //         model.ConsigneeTelephone = RequestParam.ConsigneeTelephone;
      //         model.ConsigneeMobile = RequestParam.ConsigneeMobile;
      //         model.ConsigneeEmail = RequestParam.ConsigneeEmail;
      //         Message msg = dal.UpdateConsignee(model);

      //         if (msg.State == State.Success)
      //         {
      //             return StringHelper.CreareJson(closeForm_Consignee(), 1);
      //         }
      //         else
      //         {
      //             return StringHelper.CreareJson("保存失败", 0);
      //         }
      //     }
      //     else
      //     {
      //         return StringHelper.CreareJson("购物车信息不存在！", 0);
      //     }
      // }
      // #endregion

      // #region 收件人Label
      // public static string closeForm_Consignee()
      // {
      //     StringBuilder sb = new StringBuilder();
      //     BLL.MemberOrder bll = new MemberOrder();
      //     Model.MemberOrder model = bll.GetModelByCartNum(Utility.CookieHelper.GetCookies("cartNum"));

      //     if (model != null && model.UserID == Utility.CookieHelper.GetCookiesUserID("UserID"))
      //     {
      //         string strProvinceCity = BLL.MemberProvince.GetProvinceName(model.ConsigneeProvince) + BLL.MemberCity.GetCityName(model.ConsigneeCity) + BLL.MemberArea.GetAreaName(model.ConsigneeArea);
      //         sb.Append("<h2><span><a href='javascript:void(0)' onclick='showForm_Consignee(this)'>[修改]</a></span> &nbsp;收货人信息（以下带*的为必填内容!）</h2>");
      //         sb.Append("<table border='0' cellspacing='0' cellpadding='0' class='wp95 m_center table2'>");
      //         sb.Append("  <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>公司名称：</td>");
      //         sb.Append("      <td>"+model.ConsigneeCompany+"</td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>收货人姓名：</td>");
      //         sb.Append("      <td>"+model.ConsigneeRealName+"</td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>省 份：</td>");
      //         sb.Append("      <td>" + strProvinceCity + "</td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>地 址：</td>");
      //         sb.Append("      <td>" + strProvinceCity + model.ConsigneeAddress + "</td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>邮 编：</td>");
      //         sb.Append("      <td>"+model.ConsigneePostCode+"</td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>固定电话：</td>");
      //         sb.Append("      <td>"+model.ConsigneeTelephone+"</td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>手机号码：</td>");
      //         sb.Append("      <td>"+model.ConsigneeMobile+"</td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>电子邮件：</td>");
      //         sb.Append("      <td>"+model.ConsigneeEmail+"</td>");
      //         sb.Append(" </tr>");
      //         sb.Append("</table>");

      //     }

      //     return sb.ToString();
      // }
      // #endregion

      // #region 收件人表单
      // public static string showForm_Consignee()
      // {
      //     StringBuilder sb = new StringBuilder();

      //     sb.Append("<h2><span><a target='_blank' href='/Member/MemberConsignee/default.aspx'>[管理收货人地址] </a><a href='javascript:void(0)' onclick='closeForm_Consignee(this)'>[关闭]</a></span> &nbsp;收货人信息（以下带*的为必填内容!）</h2>");
      //     sb.Append(" <div id='consignee_addr'>");
      //     BLL.MemberOrder bll = new MemberOrder();
      //     Model.MemberOrder model = bll.GetModelByCartNumAndUserID(Utility.CookieHelper.GetCookies("cartNum"), Utility.CookieHelper.GetCookiesUserID("UserID"));
      //     if (model != null && model.UserID == Utility.CookieHelper.GetCookiesUserID("UserID"))
      //     {
      //         //表单部份start
      //         sb.Append("<table border='0' cellspacing='0' cellpadding='0' class='wp95 m_center table2'>");
      //         //常用收件人地址
      //         sb.Append("<tr><td>");
      //         sb.Append(BLL.MemberConsignee.BindMemberConsignee(Utility.CookieHelper.GetCookiesUserID("UserID")));
      //         sb.Append("</td></tr>");
      //         sb.Append("  <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>公司名称：</td>");
      //         sb.Append("      <td><input type='text' id='ConsigneeCompany' name='ConsigneeCompany' size='50' class='input w200' value='" + model.ConsigneeCompany + "' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>收货人姓名：</td>");
      //         sb.Append("      <td><input type='text' name='ConsigneeRealName' id='ConsigneeRealName' class='input w200' size='50' value='" + model.ConsigneeRealName + "' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>省 份：</td>");
      //         sb.Append("      <td><span id='ConsigneeArea'>" + BLL.MemberProvince.BindProvince(model.ConsigneeProvince, "Consignee") + BLL.MemberCity.BindCity(model.ConsigneeProvince, model.ConsigneeCity, "Consignee") + BLL.MemberArea.BindArea(model.ConsigneeCity, model.ConsigneeArea, "Consignee") + "</span></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>地 址：</td>");
      //         sb.Append("      <td><span id='ConsigneeAddress'>" + BLL.MemberProvince.GetProvinceName(model.ConsigneeProvince) + BLL.MemberCity.GetCityName(model.ConsigneeCity) + BLL.MemberArea.GetAreaName(model.ConsigneeArea) + "</span><input type='text' name='address' id='address' class='input w200' value='" + model.ConsigneeAddress + "' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>邮 编：</td>");
      //         sb.Append("      <td><input type='text' name='ConsigneePostCode' id='ConsigneePostCode' class='input w200' value='" + model.ConsigneePostCode + "' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>固定电话：</td>");
      //         sb.Append("      <td><input type='text' name='ConsigneeTelephone' id='ConsigneeTelephone' class='input w200' value='" + model.ConsigneeTelephone + "' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>手机号码：</td>");
      //         sb.Append("      <td><input type='text' name='ConsigneeMobile' id='ConsigneeMobile' class='input w200' value='" + model.ConsigneeMobile + "' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>电子邮件：</td>");
      //         sb.Append("      <td><input type='text' name='ConsigneeEmail' id='ConsigneeEmail' class='input w200' value='" + model.ConsigneeEmail + "' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td>&nbsp;</td>");
      //         sb.Append("      <td><input type='button' name='button' value='保存收货人信息' class='btn_org_big1 B'  onclick='saveForm_Consignee(this)'/></td>");
      //         sb.Append(" </tr>");
      //         sb.Append("</table>");
      //         //表单部份end
      //     }
      //     else
      //     {
      //         //表单部份start
      //         sb.Append("<table border='0' cellspacing='0' cellpadding='0' class='wp95 m_center table2'>");
      //         sb.Append("  <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>公司名称：</td>");
      //         sb.Append("      <td><input type='text' id='ConsigneeCompany' name='ConsigneeCompany' size='50' class='input w200'  /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>收货人姓名：</td>");
      //         sb.Append("      <td><input type='text' name='ConsigneeRealName' id='ConsigneeRealName' class='input w200' size='50'  /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>省 份：</td>");
      //         sb.Append("      <td><span id='ConsigneeArea'>" + BLL.MemberProvince.BindProvince("", "Consignee") + BLL.MemberCity.BindCity("", "", "Consignee") + BLL.MemberArea.BindArea("", "", "Consignee") + "</span></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>地 址：</td>");
      //         sb.Append("      <td><span id='ConsigneeAddress'></span><input type='text' name='address' id='address' class='input w200'  /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>邮 编：</td>");
      //         sb.Append("      <td><input type='text' name='ConsigneePostCode' id='ConsigneePostCode' class='input w200'  /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>固定电话：</td>");
      //         sb.Append("      <td><input type='text' name='ConsigneeTelephone' id='ConsigneeTelephone' class='input w200'  /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>手机号码：</td>");
      //         sb.Append("      <td><input type='text' name='ConsigneeMobile' id='ConsigneeMobile' class='input w200' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>电子邮件：</td>");
      //         sb.Append("      <td><input type='text' name='ConsigneeEmail' id='ConsigneeEmail' class='input w200' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td>&nbsp;</td>");
      //         sb.Append("      <td><input type='Button' name='button' value='保存收货人信息' class='btn_org_big1 B'  onclick='saveForm_Consignee(this)'/></td>");
      //         sb.Append(" </tr>");
      //         sb.Append("</table>");          
      //     }
 
      //     //表单部份end
      //     sb.Append("</div>");

      //     return sb.ToString();
      // }

      // #endregion
      //#endregion
       

      // #region 发票邮寄信息
      // #region 收件人保存
      // public static string saveForm_InvoiceMail()
      // {
      //     #region 验证输入
      //     if (RequestParam.InvoiceMailCompany == "")
      //     {
      //         return StringHelper.CreareJson("请输入公司名称！", 0);
      //     }
      //     if (RequestParam.InvoiceMailRealName == "")
      //     {
      //         return StringHelper.CreareJson("请输入收件人信息！", 0);
      //     }
      //     if (RequestParam.InvoiceMailProvince == "0")
      //     {
      //         return StringHelper.CreareJson("地区信息不完整！", 0);
      //     }
      //     if (RequestParam.InvoiceMailCity == "0")
      //     {
      //         return StringHelper.CreareJson("地区信息不完整！", 0);
      //     }
      //     if (RequestParam.InvoiceMailArae == "0")
      //     {
      //         return StringHelper.CreareJson("地区信息不完整！", 0);
      //     }
      //     if (RequestParam.InvoiceMailAddress == "")
      //     {
      //         return StringHelper.CreareJson("请输入地址！", 0);
      //     }
      //     if (RequestParam.InvoiceMailPostCode == "")
      //     {
      //         return StringHelper.CreareJson("请输入邮政编码！", 0);
      //     }
      //     if (RequestParam.InvoiceMailTelephone == "")
      //     {
      //         return StringHelper.CreareJson("请输入电话号码！", 0);
      //     }
      //     if (RequestParam.InvoiceMailMobile == "")
      //     {
      //         return StringHelper.CreareJson("请输入手机号码！", 0);
      //     }
      //     if (RequestParam.InvoiceMailEmail == "")
      //     {
      //         return StringHelper.CreareJson("请输入电子邮件！", 0);
      //     }
      //     #endregion

      //     BLL.MemberOrder bll = new MemberOrder();
      //     DAL.MemberOrder dal = new DAL.MemberOrder();
      //     Model.MemberOrder model = bll.GetModelByCartNum(CookieHelper.GetCookies("cartNum"));
      //     if (model != null)
      //     {
      //         model.UserID = CookieHelper.GetCookiesUserID("UserID");
      //         model.CartNum = CookieHelper.GetCookies("cartNum");
      //         model.InvoiceMailCompany = RequestParam.InvoiceMailCompany;
      //         model.InvoiceMailRealName = RequestParam.InvoiceMailRealName;
      //         model.InvoiceMailProvince = RequestParam.InvoiceMailProvince;
      //         model.InvoiceMailCity = RequestParam.InvoiceMailCity;
      //         model.InvoiceMailArea = RequestParam.InvoiceMailArae;
      //         model.InvoiceMailAddress = RequestParam.InvoiceMailAddress;
      //         model.InvoiceMailPostCode = RequestParam.InvoiceMailPostCode;
      //         model.InvoiceMailTelephone = RequestParam.InvoiceMailTelephone;
      //         model.InvoiceMailMobile = RequestParam.InvoiceMailMobile;
      //         model.InvoiceMailEmail = RequestParam.InvoiceMailEmail;
      //         Message msg = dal.UpdateInvoiceMail(model);

      //         if (msg.State == State.Success)
      //         {
      //             return StringHelper.CreareJson(closeForm_InvoiceMail(), 1);
      //         }
      //         else
      //         {
      //             return StringHelper.CreareJson("保存失败", 0);
      //         }
      //     }
      //     else
      //     {
      //         return StringHelper.CreareJson("购物车信息不存在！", 0);
      //     }
      // }
      // #endregion

      // #region 收件人表单
      // public static string showForm_InvoiceMail()
      // {
      //     StringBuilder sb = new StringBuilder();
      //     sb.Append("<h2><span><a target='_blank' href='/Member/MemberInvoiceMail/default.aspx'>[管理发票邮寄地址] </a><a href='javascript:void(0)' onclick='closeForm_InvoiceMail(this)'>[关闭]</a></span> &nbsp;收货人信息（以下带*的为必填内容!）</h2>");
      //     sb.Append("<div id='InvoiceMail_addr'>");
           
      //      BLL.MemberOrder bll = new MemberOrder();
      //     Model.MemberOrder model = bll.GetModelByCartNumAndUserID(Utility.CookieHelper.GetCookies("cartNum"), Utility.CookieHelper.GetCookiesUserID("UserID"));
      //     if (model != null && model.UserID == Utility.CookieHelper.GetCookiesUserID("UserID"))
      //     {
      //         //表单部份start
      //         sb.Append("<table border='0' cellspacing='0' cellpadding='0' class='wp95 m_center table2'>");
      //         //常用收件人地址
      //         sb.Append("<tr><td>");
      //         sb.Append(BLL.MemberInvoiceMail.BindMemberInvoiceMail(Utility.CookieHelper.GetCookiesUserID("UserID")));
      //         sb.Append("</td></tr>");
      //         sb.Append("  <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>公司名称：</td>");
      //         sb.Append("      <td><input type='text' id='InvoiceMailCompany' name='InvoiceMailCompany' size='50' class='input w200' value='" + model.InvoiceMailCompany + "' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>收货人姓名：</td>");
      //         sb.Append("      <td><input type='text' name='InvoiceMailRealName' id='InvoiceMailRealName' class='input w200' size='50' value='" + model.InvoiceMailRealName + "' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>省 份：</td>");
      //         sb.Append("      <td><span id='InvoiceMailArea'>" + BLL.MemberProvince.BindProvince(model.InvoiceMailProvince, "InvoiceMail") + BLL.MemberCity.BindCity(model.InvoiceMailProvince, model.InvoiceMailCity, "InvoiceMail") + BLL.MemberArea.BindArea(model.InvoiceMailCity, model.InvoiceMailArea, "InvoiceMail") + "</span></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>地 址：</td>");
      //         sb.Append("      <td><span id='InvoiceMailAddress'>" + BLL.MemberProvince.GetProvinceName(model.InvoiceMailProvince) + BLL.MemberCity.GetCityName(model.InvoiceMailCity) + BLL.MemberArea.GetAreaName(model.InvoiceMailArea) + "</span><input type='text' name='address' id='address' class='input w200' value='" + model.InvoiceMailAddress + "' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>邮 编：</td>");
      //         sb.Append("      <td><input type='text' name='InvoiceMailPostCode' id='InvoiceMailPostCode' class='input w200' value='" + model.InvoiceMailPostCode + "' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>固定电话：</td>");
      //         sb.Append("      <td><input type='text' name='InvoiceMailTelephone' id='InvoiceMailTelephone' class='input w200' value='" + model.InvoiceMailTelephone + "' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>手机号码：</td>");
      //         sb.Append("      <td><input type='text' name='InvoiceMailMobile' id='InvoiceMailMobile' class='input w200' value='" + model.InvoiceMailMobile + "' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>电子邮件：</td>");
      //         sb.Append("      <td><input type='text' name='InvoiceMailEmail' id='InvoiceMailEmail' class='input w200' value='" + model.InvoiceMailEmail + "' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td>&nbsp;</td>");
      //         sb.Append("      <td><input type='button' name='button' value='保存收货人信息' class='btn_org_big1 B'  onclick='saveForm_InvoiceMail(this)'/></td>");
      //         sb.Append(" </tr>");
      //         sb.Append("</table>");
      //         //表单部份end
      //     }
      //     else
      //     {
      //         //表单部份start
      //         sb.Append("<table border='0' cellspacing='0' cellpadding='0' class='wp95 m_center table2'>");
      //         sb.Append("  <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>公司名称：</td>");
      //         sb.Append("      <td><input type='text' id='InvoiceMailCompany' name='InvoiceMailCompany' size='50' class='input w200'  /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>收货人姓名：</td>");
      //         sb.Append("      <td><input type='text' name='InvoiceMailRealName' id='InvoiceMailRealName' class='input w200' size='50'  /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>省 份：</td>");
      //         sb.Append("      <td><span id='ConsigneeArea'>" + BLL.MemberProvince.BindProvince("", "InvoiceMail") + BLL.MemberCity.BindCity("", "", "InvoiceMail") + BLL.MemberArea.BindArea("", "", "InvoiceMail") + "</span></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>地 址：</td>");
      //         sb.Append("      <td><span id='InvoiceMailAddress'></span><input type='text' name='address' id='address' class='input w200'  /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>邮 编：</td>");
      //         sb.Append("      <td><input type='text' name='InvoiceMailPostCode' id='InvoiceMailPostCode' class='input w200'  /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>固定电话：</td>");
      //         sb.Append("      <td><input type='text' name='InvoiceMailTelephone' id='InvoiceMailTelephone' class='input w200'  /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>手机号码：</td>");
      //         sb.Append("      <td><input type='text' name='InvoiceMailMobile' id='InvoiceMailMobile' class='input w200' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>电子邮件：</td>");
      //         sb.Append("      <td><input type='text' name='InvoiceMailEmail' id='InvoiceMailEmail' class='input w200' /></td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td>&nbsp;</td>");
      //         sb.Append("      <td><input type='Button' name='button' value='保存收货人信息' class='btn_org_big1 B'  onclick='saveForm_InvoiceMail(this)'/></td>");
      //         sb.Append(" </tr>");
      //         sb.Append("</table>");          
      //     }


      //     sb.Append("</div>");  
      //     //表单部份end
      //     return sb.ToString();
      //     //return StringHelper.CreareJson(sb.ToString(), 1);
      // }




      // #endregion

      // #region 收件人Label
      // public static string closeForm_InvoiceMail()
      // {
      //     StringBuilder sb = new StringBuilder();
      //     BLL.MemberOrder bll = new MemberOrder();
      //     Model.MemberOrder model = bll.GetModelByCartNum(Utility.CookieHelper.GetCookies("cartNum"));
      //     if (model != null)
      //     {
      //         string strProvinceCity = BLL.MemberProvince.GetProvinceName(model.InvoiceMailProvince) + BLL.MemberCity.GetCityName(model.InvoiceMailCity) + BLL.MemberArea.GetAreaName(model.InvoiceMailArea);
      //         sb.Append("<h2><span><a href='javascript:void(0)' onclick='showForm_InvoiceMail(this)'>修改</a></span> &nbsp;发票邮寄信息</h2>");
      //         sb.Append("<table border='0' cellspacing='0' cellpadding='0' class='wp95 m_center table2'>");
      //         sb.Append("  <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>公司名称：</td>");
      //         sb.Append("      <td>" + model.InvoiceMailCompany + "</td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>收货人姓名：</td>");
      //         sb.Append("      <td>" + model.InvoiceMailRealName + "</td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>省 份：</td>");
      //         sb.Append("      <td>" + strProvinceCity + "</td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>地 址：</td>");
      //         sb.Append("      <td>" + strProvinceCity + model.InvoiceMailAddress + "</td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>邮 编：</td>");
      //         sb.Append("      <td>" + model.InvoiceMailPostCode + "</td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>固定电话：</td>");
      //         sb.Append("      <td>" + model.InvoiceMailTelephone + "</td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>手机号码：</td>");
      //         sb.Append("      <td>" + model.InvoiceMailMobile + "</td>");
      //         sb.Append(" </tr>");
      //         sb.Append(" <tr>");
      //         sb.Append("      <td class='td1'><em>* </em>电子邮件：</td>");
      //         sb.Append("      <td>" + model.InvoiceMailEmail + "</td>");
      //         sb.Append(" </tr>");
      //         sb.Append("</table>");
      //     }
      //     return sb.ToString();
      // }
      // #endregion
      // #endregion
   }
}
