using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using GK2010.Utility;
using System.Data;

namespace GK2010.DAL
{
   public class MemberProductFavorites
    {

        private Message message;

        public MemberProductFavorites()
        {
            message = new Message();
        }

        #region 添加
        public Message Add(Model.MemberProductFavorite model)
        {
            int rowsAffected;
            int rowsAffected1;

            SqlParameter[] parameters1 ={
                                       new SqlParameter("@userID",SqlDbType.Int,4),
                                       new SqlParameter("@productID",SqlDbType.Int,4)};

            parameters1[0].Value = model.MemberID;
            parameters1[1].Value = model.ProductID;

            int countID =DbHelperSQL.RunProcedure("UP_MemberProductFavorites_GetCountByProductIdAndUserID", parameters1, out rowsAffected1);
            if (countID == 0)
            {
                SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@BigCategoryID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@ProductTitle", SqlDbType.NVarChar),
					new SqlParameter("@Addtime", SqlDbType.DateTime),
					new SqlParameter("@IP", SqlDbType.NVarChar)};
                parameters[0].Direction = ParameterDirection.Output;
                parameters[1].Value = model.MemberID;
                parameters[2].Value = model.BigCategoryID;
                parameters[3].Value = model.ProductID;
                parameters[4].Value = model.ProductTitle;
                parameters[5].Value = model.Addtime;
                parameters[6].Value = model.IP;
                DbHelperSQL.RunProcedure("UP_MemberProductFavorites_ADD", parameters, out rowsAffected);
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
            }
            else {
                message.State = State.Error;
                message.Msg = "添加失败！";
            }
            return message;
        }
        #endregion

        #region Model 获取收藏人气
        /// <summary>
        /// 获取收藏人气
        /// </summary>
        public static int GetCount(int BigCategoryID, int ProductID)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@BigCategoryID", SqlDbType.Int,4),
                    new SqlParameter("@ProductID", SqlDbType.Int,4)
				};
            parameters[0].Value = BigCategoryID;
            parameters[1].Value = ProductID;
            DataSet ds = DbHelperSQL.RunProcedure("UP_MemberProductFavorites_GetCount", parameters, "ds");

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Num"].ToString() != "")
                {
                    return int.Parse(ds.Tables[0].Rows[0]["Num"].ToString());
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}
