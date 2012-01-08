using System;
using System.Collections.Generic;
using System.Text;
using GK2010.Utility;
using System.Data.SqlClient;
using System.Data;

namespace GK2010.DAL
{
    public class MemberProductBrowse
    {
        private Message message;

        public MemberProductBrowse()
        {
            message = new Message();
        }

        #region 添加
        public Message Add(Model.MemberProductBrowse model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@BigCategoryID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@ProductTitle", SqlDbType.NVarChar),
					new SqlParameter("@ProductImgUrl", SqlDbType.NVarChar),
					new SqlParameter("@DefaultPrice", SqlDbType.Decimal),
					new SqlParameter("@Addtime", SqlDbType.DateTime),
					new SqlParameter("@IP", SqlDbType.NVarChar)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.MemberID;
            parameters[2].Value = model.BigCategoryID;
            parameters[3].Value = model.ProductID;
            parameters[4].Value = model.ProductTitle;
            parameters[5].Value = model.ProductImgUrl;
            parameters[6].Value = model.DefaultPrice;
            parameters[7].Value = model.Addtime;
            parameters[8].Value = model.IP;


            DbHelperSQL.RunProcedure("UP_MemberProductBrowse_ADD", parameters, out rowsAffected);
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
        public Message Update(Model.MemberProductBrowse model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@BigCategoryID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@ProductTitle", SqlDbType.NVarChar),
					new SqlParameter("@ProductImgUrl", SqlDbType.NVarChar),
					new SqlParameter("@DefaultPrice", SqlDbType.Decimal),
					new SqlParameter("@Addtime", SqlDbType.DateTime),
					new SqlParameter("@IP", SqlDbType.NVarChar)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.MemberID;
            parameters[2].Value = model.BigCategoryID;
            parameters[3].Value = model.ProductID;
            parameters[4].Value = model.ProductTitle;
            parameters[5].Value = model.ProductImgUrl;
            parameters[6].Value = model.DefaultPrice;
            parameters[7].Value = model.Addtime;
            parameters[8].Value = model.IP;

            DbHelperSQL.RunProcedure("UP_MemberProductBrowse_Update", parameters, out rowsAffected);

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
            DbHelperSQL.RunProcedure("UP_MemberProductBrowse_Delete", parameters, out rowsAffected);
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

        #region Model
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.MemberProductBrowse GetModel(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            Model.MemberProductBrowse model = new Model.MemberProductBrowse();

            DataSet ds = DbHelperSQL.RunProcedure("UP_MemberProductBrowse_GetModel", parameters, "ds");
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0]["MemberID"].ToString() != "")
                {
                    model.MemberID = int.Parse(ds.Tables[0].Rows[0]["MemberID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BigCategoryID"].ToString() != "")
                {
                    model.BigCategoryID = int.Parse(ds.Tables[0].Rows[0]["BigCategoryID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductID"].ToString() != "")
                {
                    model.ProductID = int.Parse(ds.Tables[0].Rows[0]["ProductID"].ToString());
                }
                model.ProductTitle = ds.Tables[0].Rows[0]["ProductTitle"].ToString();
                model.ProductImgUrl = ds.Tables[0].Rows[0]["ProductImgUrl"].ToString();

                if (ds.Tables[0].Rows[0]["DefaultPrice"].ToString() != "")
                {
                    model.DefaultPrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["DefaultPrice"].ToString());
                }

                if (ds.Tables[0].Rows[0]["Addtime"].ToString() != "")
                {

                    model.Addtime = DateTime.Parse(ds.Tables[0].Rows[0]["Addtime"].ToString());
                }
                model.IP = ds.Tables[0].Rows[0]["IP"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 列表(后台分页管理)
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string strOrder, out int totalRows)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@tblName", SqlDbType.VarChar, 255),
											new SqlParameter("@fldName", SqlDbType.VarChar, 255),
											new SqlParameter("@PageSize", SqlDbType.Int),
											new SqlParameter("@PageIndex", SqlDbType.Int),
											new SqlParameter("@OrderfldName", SqlDbType.VarChar,255),
											new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
											
			};
            parameters[0].Value = "MemberProductBrowse";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = strOrder;
            parameters[5].Value = strWhere;

            DataSet ds = DbHelperSQL.RunProcedure("UP_GetRecordByPage", parameters, "ds");
            totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
            return ds;
        }
        #endregion

        #region 获取浏览过此产品的会员还看过的产品
        public DataSet GetDataSetByProductID(int productID)
        {
            SqlParameter[] parameter = { 
                                       new SqlParameter("@ProductID",SqlDbType.Int,4)
                                       };
            parameter[0].Value = productID;
            return DbHelperSQL.RunProcedure("UP_MemberProductBorwse_GetList", parameter, "ds");
        }
        #endregion

        #region 最近浏览
        public DataSet GetList(int MemberID, string IP)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@MemberID", SqlDbType.Int),											
											new SqlParameter("@IP", SqlDbType.NVarChar,50),
											
			};
            parameters[0].Value = MemberID;
            parameters[1].Value = IP;

            DataSet ds = DbHelperSQL.RunProcedure("UP_MemberProductBrowse_GetListNew", parameters, "ds");
            return ds;
        }
        #endregion

    }
}
