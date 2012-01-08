using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GK2010.Utility;
namespace GK2010.DAL
{
	/// <summary>
	/// 数据访问类Library_Tag。
	/// </summary>
	public class Library_Tag
	{
		#region  构造函数
		public Library_Tag()
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

			int result= DbHelperSQL.RunProcedure("UP_Library_Tag_Exists",parameters,out rowsAffected);
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
		public int Add(GK2010.Model.Library_Tag model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@TableName", SqlDbType.NVarChar,100),
					new SqlParameter("@TableID", SqlDbType.Int,4),
					new SqlParameter("@Tag", SqlDbType.NVarChar,100),
					new SqlParameter("@TagEn", SqlDbType.NVarChar,200)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.TableName;
			parameters[2].Value = model.TableID;
			parameters[3].Value = model.Tag;
			parameters[4].Value = model.TagEn;

			DbHelperSQL.RunProcedure("UP_Library_Tag_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.Library_Tag model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@TableName", SqlDbType.NVarChar,100),
					new SqlParameter("@TableID", SqlDbType.Int,4),
					new SqlParameter("@Tag", SqlDbType.NVarChar,100),
					new SqlParameter("@TagEn", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.TableName;
			parameters[2].Value = model.TableID;
			parameters[3].Value = model.Tag;
			parameters[4].Value = model.TagEn;

			DbHelperSQL.RunProcedure("UP_Library_Tag_Update",parameters,out rowsAffected);
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

			DbHelperSQL.RunProcedure("UP_Library_Tag_Delete",parameters,out rowsAffected);
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

			DataSet ds= DbHelperSQL.RunProcedure("UP_Library_Tag_GetModel",parameters,"ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_Library_Tag_GetList_ByCondition", parameters, "ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_Library_Tag_GetList", parameters, "ds");
			totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
			return ds;
		}
		#endregion 

		#endregion  成员方法

        #region  列表(不分页)根据表名和表ID

        /// <summary>
        /// 列表(不分页)根据表名和表ID
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="TableID">表ID</param>
        /// <returns></returns>
        public DataSet GetList(TableName TableName, int TableID)
        {
            SqlParameter[] parameters = {
				new SqlParameter("@TableName", SqlDbType.VarChar, 50),
				new SqlParameter("@TableID", SqlDbType.Int,4)
			};
            parameters[0].Value = TableName.ToString();
            parameters[1].Value = TableID;
            DataSet ds = DbHelperSQL.RunProcedure("UP_Library_Tag_GetList_ByTable", parameters, "ds");
            return ds;
        }

        #endregion

        #region  批量添加标签
        /// <summary>
        ///  批量添加标签
        /// </summary>
        public bool AddBatch(TableName TableName, int TableID, string Select)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@TableName", SqlDbType.NVarChar,50),
                    new SqlParameter("@TableID", SqlDbType.Int,4),
					new SqlParameter("@Select", SqlDbType.NVarChar,4000)};
            parameters[0].Value = TableName;
            parameters[1].Value = TableID;
            parameters[2].Value = Select;

            DbHelperSQL.RunProcedure("UP_Library_Tag_ADD_Batch", parameters, out rowsAffected);
            return rowsAffected > 0;
        }
        #endregion

        #region  获取标题（根据表名）
        /// <summary>
        /// 获取标题（根据表名）
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="TableID">表ID</param>
        /// <returns></returns>
        public string GetTitle(TableName TableName, int TableID)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@TableName", SqlDbType.NVarChar,50),
					new SqlParameter("@TableID", SqlDbType.Int,4)};
            parameters[0].Value = TableName.ToString();
            parameters[1].Value = TableID;

            DataSet ds = DbHelperSQL.RunProcedure("UP_Library_Tag_GetTitleByTable", parameters, "ds");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    string ret = ds.Tables[0].Rows[0]["RET"].ToString();
                    if(ret.EndsWith(","))
                    {
                        ret = StringHelper.DelLastChar(ret);
                        return ret;
                    }
                    
                }
            }
            return "";
        }
        #endregion
	}
}

