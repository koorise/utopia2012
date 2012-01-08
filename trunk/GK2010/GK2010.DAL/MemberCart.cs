using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using GK2010.Utility;

namespace GK2010.DAL
{
    public class MemberCart
    {
        private Message message;
        public MemberCart()
        {
            message = new Message();
        }

        #region 添加一条数据
        public int Add(GK2010.Model.MemberCart model)
        {
            int rowsAffected;
            SqlParameter[] parameters ={
           new SqlParameter("@ID",SqlDbType.Int,4),
           new SqlParameter("@UserID",SqlDbType.Int,4),
          new SqlParameter("@CartNum",SqlDbType.NVarChar,100),
          new SqlParameter("@TotalNum",SqlDbType.Int,4),
          new SqlParameter("@TotalShipPrice",SqlDbType.Decimal,9),
          new SqlParameter("@TotalProductPrice",SqlDbType.Decimal,9),
          new SqlParameter("@TotalOtherPrice",SqlDbType.Decimal,9),
          new SqlParameter("@TotalPrice",SqlDbType.Decimal,9),
          new SqlParameter("@TotalJF",SqlDbType.Decimal,9),
          new SqlParameter("@ConsigneeCompany",SqlDbType.NVarChar,100),
          new SqlParameter("@ConsigneeRealName",SqlDbType.NVarChar,100),
          new SqlParameter("@ConsigneeProvince",SqlDbType.NVarChar,100),
          new SqlParameter("@ConsigneeCity",SqlDbType.NVarChar,100),
          new SqlParameter("@ConsigneeArea",SqlDbType.NVarChar,100),
          new SqlParameter("@ConsigneeAddress",SqlDbType.NVarChar,100),
          new SqlParameter("@ConsigneePostCode",SqlDbType.NVarChar,50),
          new SqlParameter("@ConsigneeTelephone",SqlDbType.NVarChar,100),
          new SqlParameter("@ConsigneeMobile",SqlDbType.NVarChar,100),
          new SqlParameter("@ConsigneeEmail",SqlDbType.NVarChar,100),
          new SqlParameter("@PayType",SqlDbType.NVarChar,50),
          new SqlParameter("@ShipType",SqlDbType.NVarChar,50),
          new SqlParameter("@InvoiceType",SqlDbType.NVarChar,50),
          new SqlParameter("@InvoiceCompany",SqlDbType.NVarChar,50),
          new SqlParameter("@InvoiceNum",SqlDbType.NVarChar,50),
          new SqlParameter("@InvoiceAddress",SqlDbType.NVarChar,50),
          new SqlParameter("@InvoiceTelephone",SqlDbType.NVarChar,50),
          new SqlParameter("@InvoiceBank",SqlDbType.NVarChar,50),
          new SqlParameter("@InvoiceBankAccount",SqlDbType.NVarChar,50),
          new SqlParameter("@InvoiceContent",SqlDbType.NVarChar,50),
          new SqlParameter("@InvoiceMailCompany",SqlDbType.NVarChar,100),
          new SqlParameter("@InvoiceMailRealName",SqlDbType.NVarChar,100),
          new SqlParameter("@InvoiceMailProvince",SqlDbType.NVarChar,100),
          new SqlParameter("@InvoiceMailCity",SqlDbType.NVarChar,100),
          new SqlParameter("@InvoiceMailArea",SqlDbType.NVarChar,100),
          new SqlParameter("@InvoiceMailAddress",SqlDbType.NVarChar,100),
          new SqlParameter("@InvoiceMailPostCode",SqlDbType.NVarChar,50),
          new SqlParameter("@InvoiceMailTelephone",SqlDbType.NVarChar,100),
          new SqlParameter("@InvoiceMailMobile",SqlDbType.NVarChar,100),
          new SqlParameter("@InvoiceMailEmail",SqlDbType.NVarChar,100),
          new SqlParameter("@Liuyan",SqlDbType.NVarChar,100),
          new SqlParameter("@StatusFlag",SqlDbType.Int,4),
          new SqlParameter("@StatusDate",SqlDbType.BigInt,8),
          new SqlParameter("@StatusUserID",SqlDbType.Int,4),
          new SqlParameter("@PostDate",SqlDbType.BigInt,8),
          new SqlParameter("@PostUserID",SqlDbType.Int,4),
          new SqlParameter("@EditDate",SqlDbType.BigInt,8),
          new SqlParameter("@EditUserID",SqlDbType.Int,4),
          new SqlParameter("@Remark",SqlDbType.NText)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.CartNum;
            parameters[3].Value = model.TotalNum;
            parameters[4].Value = model.TotalShipPrice;
            parameters[5].Value = model.TotalProductPrice;
            parameters[6].Value = model.TotalOtherPrice;
            parameters[7].Value = model.TotalPrice;
            parameters[8].Value = model.TotalJF;
            parameters[9].Value = model.ConsigneeCompany;
            parameters[10].Value = model.ConsigneeRealName;
            parameters[11].Value = model.ConsigneeProvince;
            parameters[12].Value = model.ConsigneeCity;
            parameters[13].Value = model.ConsigneeArea;
            parameters[14].Value = model.ConsigneeAddress;
            parameters[15].Value = model.ConsigneePostCode;
            parameters[16].Value = model.ConsigneeTelephone;
            parameters[17].Value = model.ConsigneeMobile;
            parameters[18].Value = model.ConsigneeEmail;
            parameters[19].Value = model.PayType;
            parameters[20].Value = model.ShipType;
            parameters[21].Value = model.InvoiceType;
            parameters[22].Value = model.InvoiceCompany;
            parameters[23].Value = model.InvoiceNum;
            parameters[24].Value = model.InvoiceAddress;
            parameters[25].Value = model.InvoiceTelephone;
            parameters[26].Value = model.InvoiceBank;
            parameters[27].Value = model.InvoiceBankAccount;
            parameters[28].Value = model.InvoiceContent;
            parameters[29].Value = model.InvoiceMailCompany;
            parameters[30].Value = model.InvoiceMailRealName;
            parameters[31].Value = model.InvoiceMailProvince;
            parameters[32].Value = model.InvoiceMailCity;
            parameters[33].Value = model.InvoiceMailArea;
            parameters[34].Value = model.InvoiceMailAddress;
            parameters[35].Value = model.InvoiceMailPostCode;
            parameters[36].Value = model.InvoiceMailTelephone;
            parameters[37].Value = model.InvoiceMailMobile;
            parameters[38].Value = model.InvoiceMailEmail;
            parameters[39].Value = model.Liuyan;
            parameters[40].Value = model.StatusFlag;
            parameters[41].Value = model.StatusDate;
            parameters[42].Value = model.StatusUserID;
            parameters[43].Value = model.PostDate;
            parameters[44].Value = model.PostUserID;
            parameters[45].Value = model.EditDate;
            parameters[46].Value = model.EditUserID;
            parameters[47].Value = model.Remark;
            DbHelperSQL.RunProcedure("UP_MemberCart_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }
        #endregion

        #region 根据用户id返回数据,得到一个实体
        public DataSet GetDataSetByUserID(int userID)
        {
            SqlParameter[] p = { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            p[0].Value = userID;
            DataSet ds = DbHelperSQL.RunProcedure("Up_MemberCart_GetListByUserID", p, "ds");
            return ds;
        }
        #endregion

        #region 修改收件人信息
        /// <summary>
        ///  更新一条数据
        /// </summary>
        public Message UpdateConsignee(Model.MemberCart model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@cartNum", SqlDbType.NVarChar),
					new SqlParameter("@ConsigneeCompany", SqlDbType.NVarChar),
					new SqlParameter("@ConsigneeRealName", SqlDbType.NVarChar),
					new SqlParameter("@ConsigneeProvince", SqlDbType.NVarChar),
					new SqlParameter("@ConsigneeCity", SqlDbType.NVarChar),
					new SqlParameter("@ConsigneeArea", SqlDbType.NVarChar),
					new SqlParameter("@ConsigneeAddress", SqlDbType.NVarChar),
					new SqlParameter("@ConsigneePostCode", SqlDbType.NVarChar),
					new SqlParameter("@ConsigneeTelephone", SqlDbType.NVarChar),
					new SqlParameter("@ConsigneeMobile", SqlDbType.NVarChar),
					new SqlParameter("@ConsigneeEmail", SqlDbType.NVarChar)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.CartNum;
            parameters[3].Value = model.ConsigneeCompany;
            parameters[4].Value = model.ConsigneeRealName;
            parameters[5].Value = model.ConsigneeProvince;
            parameters[6].Value = model.ConsigneeCity;
            parameters[7].Value = model.ConsigneeArea;
            parameters[8].Value = model.ConsigneeAddress;
            parameters[9].Value = model.ConsigneePostCode;
            parameters[10].Value = model.ConsigneeTelephone;
            parameters[11].Value = model.ConsigneeMobile;
            parameters[12].Value = model.ConsigneeEmail;

            DbHelperSQL.RunProcedure("UP_MemberCartConsignee_Update", parameters, out rowsAffected);

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

        #region 修改发票邮寄信息
        /// <summary>
        ///  更新一条数据
        /// </summary>
        public Message UpdateInvoiceMail(Model.MemberCart model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@CartNum", SqlDbType.NVarChar),
					new SqlParameter("@InvoiceMailCompany", SqlDbType.NVarChar),
					new SqlParameter("@InvoiceMailRealName", SqlDbType.NVarChar),
					new SqlParameter("@InvoiceMailProvince", SqlDbType.NVarChar),
					new SqlParameter("@InvoiceMailCity", SqlDbType.NVarChar),
					new SqlParameter("@InvoiceMailArea", SqlDbType.NVarChar),
					new SqlParameter("@InvoiceMailAddress", SqlDbType.NVarChar),
					new SqlParameter("@InvoiceMailPostCode", SqlDbType.NVarChar),
					new SqlParameter("@InvoiceMailTelephone", SqlDbType.NVarChar),
					new SqlParameter("@InvoiceMailMobile", SqlDbType.NVarChar),
					new SqlParameter("@InvoiceMailEmail", SqlDbType.NVarChar)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.CartNum;
            parameters[3].Value = model.InvoiceMailCompany;
            parameters[4].Value = model.InvoiceMailRealName;
            parameters[5].Value = model.InvoiceMailProvince;
            parameters[6].Value = model.InvoiceMailCity;
            parameters[7].Value = model.InvoiceMailArea;
            parameters[8].Value = model.InvoiceMailAddress;
            parameters[9].Value = model.InvoiceMailPostCode;
            parameters[10].Value = model.InvoiceMailTelephone;
            parameters[11].Value = model.InvoiceMailMobile;
            parameters[12].Value = model.InvoiceMailEmail;

            DbHelperSQL.RunProcedure("UP_MemberCartInvoiceMail_Update", parameters, out rowsAffected);

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

        #region 根据购物车编号返回数据,得到一个实体
        public DataSet GetDataSetByCartNum(string cartNum)
        {
            SqlParameter[] p = { new SqlParameter("@CartNum", SqlDbType.NVarChar, 100) };
            p[0].Value = cartNum;
            DataSet ds = DbHelperSQL.RunProcedure("Up_MemberCart_GetListByCartNum", p, "ds");
            return ds;
        }
        #endregion

        #region 加入购物车时，更新购物车里面的部分信息
        public bool UpdateMemberCartByPart(Model.MemberCart mod_mc)
        {
            SqlParameter[] parameter = {
                                      new SqlParameter("@TotalJF",SqlDbType.Decimal,18),
                                      new SqlParameter("@TotalNum",SqlDbType.Int,4),
                                      new SqlParameter("@TotalPrice",SqlDbType.Decimal,18),
                                      new SqlParameter("@TotalProductPrice",SqlDbType.Decimal,18),
                                      new SqlParameter("@CartNum",SqlDbType.NVarChar,100)
                                      };
            parameter[0].Value = mod_mc.TotalJF;
            parameter[1].Value = mod_mc.TotalNum;
            parameter[2].Value = mod_mc.TotalPrice;
            parameter[3].Value = mod_mc.TotalProductPrice;
            parameter[4].Value = mod_mc.CartNum;
            int rowsAffected = 0;
            DbHelperSQL.RunProcedure("UP_MemberCart_Update_MemberCartByPart", parameter, out rowsAffected);
            return rowsAffected > 0;
        }
        #endregion

        #region 根据购物车编号删除数据
        public bool DeleteByCartNum(string cartNum)
        {
            int rowsAffected = 0;
            SqlParameter[] p = { new SqlParameter("@cartNum", SqlDbType.NVarChar, 100) };
            p[0].Value = cartNum;
            DbHelperSQL.RunProcedure("Up_MemberCart_DeleteByCartNum", p, out rowsAffected);
            return rowsAffected > 0;
        }
        #endregion
    }
}