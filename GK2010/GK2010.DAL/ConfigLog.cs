using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GK2010.Utility;
namespace GK2010.DAL
{
	/// <summary>
	/// 数据访问类ConfigLog。
	/// </summary>
	public class ConfigLog
	{
		#region  构造函数
		public ConfigLog()
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

			int result= DbHelperSQL.RunProcedure("UP_ConfigLog_Exists",parameters,out rowsAffected);
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
		public int Add(GK2010.Model.ConfigLog model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Detail", SqlDbType.NText),
					new SqlParameter("@PostDate", SqlDbType.BigInt,8),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@IsRead", SqlDbType.Int,4),
					new SqlParameter("@IsSolve", SqlDbType.Int,4),
					new SqlParameter("@SolveDetail", SqlDbType.NText),
					new SqlParameter("@SolveDate", SqlDbType.BigInt,8),
					new SqlParameter("@SolveUserID", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Detail;
			parameters[3].Value = model.PostDate;
			parameters[4].Value = model.UserID;
			parameters[5].Value = model.IsRead;
			parameters[6].Value = model.IsSolve;
			parameters[7].Value = model.SolveDetail;
			parameters[8].Value = model.SolveDate;
			parameters[9].Value = model.SolveUserID;

			DbHelperSQL.RunProcedure("UP_ConfigLog_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.ConfigLog model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Detail", SqlDbType.NText),
					new SqlParameter("@PostDate", SqlDbType.BigInt,8),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@IsRead", SqlDbType.Int,4),
					new SqlParameter("@IsSolve", SqlDbType.Int,4),
					new SqlParameter("@SolveDetail", SqlDbType.NText),
					new SqlParameter("@SolveDate", SqlDbType.BigInt,8),
					new SqlParameter("@SolveUserID", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Detail;
			parameters[3].Value = model.PostDate;
			parameters[4].Value = model.UserID;
			parameters[5].Value = model.IsRead;
			parameters[6].Value = model.IsSolve;
			parameters[7].Value = model.SolveDetail;
			parameters[8].Value = model.SolveDate;
			parameters[9].Value = model.SolveUserID;

			DbHelperSQL.RunProcedure("UP_ConfigLog_Update",parameters,out rowsAffected);
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

			DbHelperSQL.RunProcedure("UP_ConfigLog_Delete",parameters,out rowsAffected);
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

			DataSet ds= DbHelperSQL.RunProcedure("UP_ConfigLog_GetModel",parameters,"ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_ConfigLog_GetList_ByCondition", parameters, "ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_ConfigLog_GetList", parameters, "ds");
			totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
			return ds;
		}
		#endregion 

		#endregion  成员方法
	}
}

