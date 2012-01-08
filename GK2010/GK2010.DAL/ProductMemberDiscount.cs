using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GK2010.Utility;
namespace GK2010.DAL
{
	/// <summary>
	/// 数据访问类ProductMemberDiscount。
	/// </summary>
	public class ProductMemberDiscount
	{
		#region  构造函数
		public ProductMemberDiscount()
		{}
		#endregion
		
		#region  成员方法

		#region  是否存在该记录
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			int result= DbHelperSQL.RunProcedure("UP_ProductMemberDiscount_Exists",parameters,out rowsAffected);
			if(result==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion

		#region  增加一条数据
		/// <summary>
		///  增加一条数据
		/// </summary>
		public int Add(GK2010.Model.ProductMemberDiscount model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@DiscountPrice", SqlDbType.Int,4),
					new SqlParameter("@DiscountJF", SqlDbType.Int,4),
					new SqlParameter("@CheckFlag", SqlDbType.Int,4),
					new SqlParameter("@CheckDate", SqlDbType.BigInt,8),
					new SqlParameter("@CheckUserID", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.ProductID;
			parameters[3].Value = model.DiscountPrice;
			parameters[4].Value = model.DiscountJF;
			parameters[5].Value = model.CheckFlag;
			parameters[6].Value = model.CheckDate;
			parameters[7].Value = model.CheckUserID;

			DbHelperSQL.RunProcedure("UP_ProductMemberDiscount_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.ProductMemberDiscount model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@DiscountPrice", SqlDbType.Int,4),
					new SqlParameter("@DiscountJF", SqlDbType.Int,4),
					new SqlParameter("@CheckFlag", SqlDbType.Int,4),
					new SqlParameter("@CheckDate", SqlDbType.BigInt,8),
					new SqlParameter("@CheckUserID", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.ProductID;
			parameters[3].Value = model.DiscountPrice;
			parameters[4].Value = model.DiscountJF;
			parameters[5].Value = model.CheckFlag;
			parameters[6].Value = model.CheckDate;
			parameters[7].Value = model.CheckUserID;

			DbHelperSQL.RunProcedure("UP_ProductMemberDiscount_Update",parameters,out rowsAffected);
			return rowsAffected > 0;
		}
		#endregion

		#region  删除一条数据
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.RunProcedure("UP_ProductMemberDiscount_Delete",parameters,out rowsAffected);
			return rowsAffected > 0;
		}
		#endregion

		#region  得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DataSet GetModel(int ID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DataSet ds= DbHelperSQL.RunProcedure("UP_ProductMemberDiscount_GetModel",parameters,"ds");
			return ds;
		}
		#endregion

		#region 列表(不分页)
		public DataSet GetList(string Keywords, string Type)
		{
			SqlParameter[] parameters = {
				new SqlParameter("@Keywords", SqlDbType.VarChar, 50),
				new SqlParameter("@Type", SqlDbType.VarChar,50)
			};
			parameters[0].Value = Keywords;
			parameters[1].Value = Type;
			DataSet ds = DbHelperSQL.RunProcedure("UP_ProductMemberDiscount_GetList_ByCondition", parameters, "ds");
			return ds;
		}
		#endregion 
		
		#region 列表(后台分页管理)
		public DataSet GetList(int PageSize, int PageIndex, string Keywords, string Type, out int totalRows)
		{
			SqlParameter[] parameters = {
				new SqlParameter("@PageSize", SqlDbType.Int),
				new SqlParameter("@PageIndex", SqlDbType.Int),
				new SqlParameter("@Keywords", SqlDbType.VarChar,50),
				new SqlParameter("@Type", SqlDbType.VarChar,50),
			};
			parameters[0].Value = PageSize;
			parameters[1].Value = PageIndex;
			parameters[2].Value = Keywords;
			parameters[3].Value = Type;
			DataSet ds = DbHelperSQL.RunProcedure("UP_ProductMemberDiscount_GetList", parameters, "ds");
			totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
			return ds;
		}
		#endregion 

		#endregion  成员方法

        #region 列表（所有产品）
        public DataSet GetList(int PageSize, int PageIndex, int UserID,string Sql, out int totalRows)
        {
            SqlParameter[] parameters = {
				new SqlParameter("@PageSize", SqlDbType.Int),
				new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@UserID", SqlDbType.Int),
				new SqlParameter("@Sql", SqlDbType.VarChar,2000)
			};
            parameters[0].Value = PageSize;
            parameters[1].Value = PageIndex;
            parameters[2].Value = UserID;
            parameters[3].Value = Sql;
            DataSet ds = DbHelperSQL.RunProcedure("UP_ProductMemberDiscount_GetListByUserID", parameters, "ds");
            totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
            return ds;
        }
        #endregion 

        #region 增加或修改数据
        public bool Operator(GK2010.Model.ProductMemberDiscount model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@DiscountPrice", SqlDbType.Int,4),
					new SqlParameter("@DiscountJF", SqlDbType.Int,4),
					new SqlParameter("@CheckFlag", SqlDbType.Int,4),
					new SqlParameter("@CheckDate", SqlDbType.BigInt,8),
					new SqlParameter("@CheckUserID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.ProductID;
            parameters[2].Value = model.DiscountPrice;
            parameters[3].Value = model.DiscountJF;
            parameters[4].Value = model.CheckFlag;
            parameters[5].Value = model.CheckDate;
            parameters[6].Value = model.CheckUserID;

            DbHelperSQL.RunProcedure("UP_ProductMemberDiscount_Operator", parameters, out rowsAffected);
            return rowsAffected > 0;
        }
        #endregion 

        #region  得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DataSet GetModel(int UserID, int ProductID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@ProductID", SqlDbType.Int,4)
                                        };
            parameters[0].Value = UserID;
            parameters[1].Value = ProductID;

            DataSet ds = DbHelperSQL.RunProcedure("UP_ProductMemberDiscount_GetModelByUserIDAndProductID", parameters, "ds");
            return ds;
        }
        #endregion
	}
}

