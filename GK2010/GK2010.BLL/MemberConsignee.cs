using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using GK2010.Utility;

namespace GK2010.BLL
{
   public class MemberConsignee
   {
       protected Message message;
       public MemberConsignee(){
           message = new Message();
       }

       #region 添加
       public Message Add(Model.MemberConsignee model)
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

           DbHelperSQL.RunProcedure("UP_MemberConsignee_ADD", parameters, out rowsAffected);
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
       public Message Update(Model.MemberConsignee model)
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

           DbHelperSQL.RunProcedure("UP_MemberConsignee_Update", parameters, out rowsAffected);

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

       #region 判断是否存在UserID记录
       /// <summary>
        /// 得到一个对象实体
        /// </summary>
       public bool Exists(int UserID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
				};
            parameters[0].Value = UserID;

            DataSet ds = DbHelperSQL.RunProcedure("UP_MemberConsignee_ExistsUserID", parameters, "ds");

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString() == "1";
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 常用收件人列表
        public static string BindMemberConsignee(int UserID)
        {
            StringBuilder sb = new StringBuilder();
            DataSet ds = DbHelperSQL.Query("select * from MemberConsignee where UserID=" + UserID);

            sb.Append("<ul id='addrList'>");
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string strID = ds.Tables[0].Rows[i]["ID"].ToString();
                    string strRealName = ds.Tables[0].Rows[i]["RealName"].ToString();
                    string strAddress = BLL.MemberProvince.GetProvinceName(ds.Tables[0].Rows[i]["Province"].ToString()) + BLL.MemberCity.GetCityName(ds.Tables[0].Rows[i]["City"].ToString()) + BLL.MemberArea.GetAreaName(ds.Tables[0].Rows[i]["Area"].ToString());
                    sb.Append("<li style='border:1px solid #ccc; background:#ffffff; float:left;margin:5px;padding:5px'>");
                    sb.Append("<span>");
                    sb.Append("<input id='addr_" + i + "' type='radio' name='rbtnAddr' onclick='changeConsignee(this," + strID + ");'  />");
                    sb.Append("<label for='addr_" + i + "'><strong>常用地址" + (i + 1) + "</strong></label>");
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

        #region Model
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.MemberConsignee GetModel(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            Model.MemberConsignee model = new Model.MemberConsignee();

            DataSet ds = DbHelperSQL.RunProcedure("UP_MemberConsignee_GetModel", parameters, "ds");
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
                if (ds.Tables[0].Rows[0]["SortID"].ToString() != "")
                {
                    model.SortID = decimal.Parse(ds.Tables[0].Rows[0]["SortID"].ToString());
                }
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

        #region 点击更换选项
        public static string showForm_Consignee(int ConsigneeID)
        {
            StringBuilder sb = new StringBuilder();
            BLL.MemberConsignee bll = new MemberConsignee();
            Model.MemberConsignee model = bll.GetModel(ConsigneeID);
            if (model != null)
            {
                //表单部份start
                sb.Append(" <form id='frmConsignee' name='frmConsignee'>");
                sb.Append("<table border='0' cellspacing='0' cellpadding='0' class='wp95 m_center table2'>");
                sb.Append("  <tr>");
                sb.Append("      <td class='td1'><em>* </em>公司名称：</td>");
                sb.Append("      <td><input type='text' id='ConsigneeCompany' name='ConsigneeCompany' size='50' class='input w200' value='" + model.Company + "' /></td>");
                sb.Append(" </tr>");
                sb.Append(" <tr>");
                sb.Append("      <td class='td1'><em>* </em>收货人姓名：</td>");
                sb.Append("      <td><input type='text' name='ConsigneeRealName' id='ConsigneeRealName' class='input w200' size='50' value='" + model.RealName + "' /></td>");
                sb.Append(" </tr>");
                sb.Append(" <tr>");
                sb.Append("      <td class='td1'><em>* </em>省 份：</td>");
                sb.Append("      <td><span id='ConsigneeArea'>" + BLL.MemberProvince.BindProvince(model.Province, "Consignee") + BLL.MemberCity.BindCity(model.Province, model.City, "Consignee") + BLL.MemberArea.BindArea(model.City, model.Area, "Consignee") + "</span></td>");
                sb.Append(" </tr>");
                sb.Append(" <tr>");
                sb.Append("      <td class='td1'><em>* </em>地 址：</td>");
                sb.Append("      <td><span id='ConsigneeAddress'>" + BLL.MemberProvince.GetProvinceName(model.Province) + BLL.MemberCity.GetCityName(model.City) + BLL.MemberArea.GetAreaName(model.Area) + "</span><input type='text' name='address' id='address' class='input w200' value='" + model.Address + "' /></td>");
                sb.Append(" </tr>");
                sb.Append(" <tr>");
                sb.Append("      <td class='td1'><em>* </em>邮 编：</td>");
                sb.Append("      <td><input type='text' name='ConsigneePostCode' id='ConsigneePostCode' class='input w200' value='" + model.PostCode + "' /></td>");
                sb.Append(" </tr>");
                sb.Append(" <tr>");
                sb.Append("      <td class='td1'><em>* </em>固定电话：</td>");
                sb.Append("      <td><input type='text' name='ConsigneeTelephone' id='ConsigneeTelephone' class='input w200' value='" + model.Telephone + "' /></td>");
                sb.Append(" </tr>");
                sb.Append(" <tr>");
                sb.Append("      <td class='td1'><em>* </em>手机号码：</td>");
                sb.Append("      <td><input type='text' name='ConsigneeMobile' id='ConsigneeMobile' class='input w200' value='" + model.Mobile + "' /></td>");
                sb.Append(" </tr>");
                sb.Append(" <tr>");
                sb.Append("      <td class='td1'><em>* </em>电子邮件：</td>");
                sb.Append("      <td><input type='text' name='ConsigneeEmail' id='ConsigneeEmail' class='input w200' value='" + model.Email + "' /></td>");
                sb.Append(" </tr>");
                sb.Append(" <tr>");
                sb.Append("      <td>&nbsp;</td>");
                sb.Append("      <td><input type='submit' name='Submit' value='保存收货人信息' class='btn_org_big1 B'  onclick='saveForm_Consignee(this)'/></td>");
                sb.Append(" </tr>");
                sb.Append("</table>");
                sb.Append(" </form>");
                //表单部份end
            }
            else
            {
                //表单部份start
                sb.Append(" <form id='frmConsignee' name='frmConsignee'>");
                sb.Append("<table border='0' cellspacing='0' cellpadding='0' class='wp95 m_center table2'>");
                sb.Append("  <tr>");
                sb.Append("      <td class='td1'><em>* </em>公司名称：</td>");
                sb.Append("      <td><input type='text' id='ConsigneeCompany' name='ConsigneeCompany' size='50' class='input w200'  /></td>");
                sb.Append(" </tr>");
                sb.Append(" <tr>");
                sb.Append("      <td class='td1'><em>* </em>收货人姓名：</td>");
                sb.Append("      <td><input type='text' name='ConsigneeRealName' id='ConsigneeRealName' class='input w200' size='50'  /></td>");
                sb.Append(" </tr>");
                sb.Append(" <tr>");
                sb.Append("      <td class='td1'><em>* </em>省 份：</td>");
                sb.Append("      <td><span id='ConsigneeArea'>" + BLL.MemberProvince.BindProvince("", "Consignee") + BLL.MemberCity.BindCity("", "", "Consignee") + BLL.MemberArea.BindArea("", "", "Consignee") + "</span></td>");
                sb.Append(" </tr>");
                sb.Append(" <tr>");
                sb.Append("      <td class='td1'><em>* </em>地 址：</td>");
                sb.Append("      <td><span id='ConsigneeAddress'></span><input type='text' name='address' id='address' class='input w200'  /></td>");
                sb.Append(" </tr>");
                sb.Append(" <tr>");
                sb.Append("      <td class='td1'><em>* </em>邮 编：</td>");
                sb.Append("      <td><input type='text' name='ConsigneePostCode' id='ConsigneePostCode' class='input w200'  /></td>");
                sb.Append(" </tr>");
                sb.Append(" <tr>");
                sb.Append("      <td class='td1'><em>* </em>固定电话：</td>");
                sb.Append("      <td><input type='text' name='ConsigneeTelephone' id='ConsigneeTelephone' class='input w200'  /></td>");
                sb.Append(" </tr>");
                sb.Append(" <tr>");
                sb.Append("      <td class='td1'><em>* </em>手机号码：</td>");
                sb.Append("      <td><input type='text' name='ConsigneeMobile' id='ConsigneeMobile' class='input w200' /></td>");
                sb.Append(" </tr>");
                sb.Append(" <tr>");
                sb.Append("      <td class='td1'><em>* </em>电子邮件：</td>");
                sb.Append("      <td><input type='text' name='ConsigneeEmail' id='ConsigneeEmail' class='input w200' /></td>");
                sb.Append(" </tr>");
                sb.Append(" <tr>");
                sb.Append("      <td>&nbsp;</td>");
                sb.Append("      <td><input type='submit' name='Submit' value='保存收货人信息' class='btn_org_big1 B'  onclick='saveForm_Consignee(this)'/></td>");
                sb.Append(" </tr>");
                sb.Append("</table>");      
                sb.Append(" </form>");
            }

            return sb.ToString();

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
            DbHelperSQL.RunProcedure("UP_MemberConsignee_Delete", parameters, out rowsAffected);
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
    }
}
