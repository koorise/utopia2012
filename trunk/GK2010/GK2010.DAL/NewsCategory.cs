using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GK2010.Utility;
namespace GK2010.DAL
{
	/// <summary>
	/// 数据访问类NewsCategory。
	/// </summary>
	public class NewsCategory
	{
		#region  构造函数
		public NewsCategory()
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

			int result= DbHelperSQL.RunProcedure("UP_NewsCategory_Exists",parameters,out rowsAffected);
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
		public int Add(GK2010.Model.NewsCategory model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@TitleEn", SqlDbType.NVarChar,100),
					new SqlParameter("@Author", SqlDbType.NVarChar,100),
					new SqlParameter("@Source", SqlDbType.NVarChar,300),
					new SqlParameter("@Summary", SqlDbType.NVarChar,500),
					new SqlParameter("@Detail", SqlDbType.NText),
					new SqlParameter("@Tags", SqlDbType.NVarChar,500),
					new SqlParameter("@Hits", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.NVarChar,300),
					new SqlParameter("@Path", SqlDbType.NVarChar,1000),
					new SqlParameter("@PictureID", SqlDbType.Int,4),
					new SqlParameter("@PictureSmall", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureNormal", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureBig", SqlDbType.NVarChar,300),
					new SqlParameter("@IndexFlag", SqlDbType.Int,4),
					new SqlParameter("@IndexSortID", SqlDbType.Decimal,9),
					new SqlParameter("@CommendFlag", SqlDbType.Int,4),
					new SqlParameter("@CommendSortID", SqlDbType.Decimal,9),
					new SqlParameter("@HotFlag", SqlDbType.Int,4),
					new SqlParameter("@HotSortID", SqlDbType.Decimal,9),
					new SqlParameter("@ChannelFlag", SqlDbType.Int,4),
					new SqlParameter("@ChannelSortID", SqlDbType.Decimal,9),
					new SqlParameter("@CategoryFlag", SqlDbType.Int,4),
					new SqlParameter("@CategorySortID", SqlDbType.Decimal,9),
					new SqlParameter("@SortID", SqlDbType.Decimal,9),
					new SqlParameter("@SEOTitle", SqlDbType.NVarChar,200),
					new SqlParameter("@SEOKeywords", SqlDbType.NVarChar,300),
					new SqlParameter("@SEODescription", SqlDbType.NVarChar,500),
					new SqlParameter("@ShowFlag", SqlDbType.Int,4),
					new SqlParameter("@CheckFlag", SqlDbType.Int,4),
					new SqlParameter("@CheckDate", SqlDbType.BigInt,8),
					new SqlParameter("@CheckUserID", SqlDbType.Int,4),
					new SqlParameter("@PostDate", SqlDbType.BigInt,8),
					new SqlParameter("@PostUserID", SqlDbType.Int,4),
					new SqlParameter("@EditDate", SqlDbType.BigInt,8),
					new SqlParameter("@EditUserID", SqlDbType.Int,4),
					new SqlParameter("@DelDate", SqlDbType.BigInt,8),
					new SqlParameter("@DelUserID", SqlDbType.Int,4),
					new SqlParameter("@MemberFlag", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.ParentID;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.TitleEn;
			parameters[4].Value = model.Author;
			parameters[5].Value = model.Source;
			parameters[6].Value = model.Summary;
			parameters[7].Value = model.Detail;
			parameters[8].Value = model.Tags;
			parameters[9].Value = model.Hits;
			parameters[10].Value = model.Url;
			parameters[11].Value = model.Path;
			parameters[12].Value = model.PictureID;
			parameters[13].Value = model.PictureSmall;
			parameters[14].Value = model.PictureNormal;
			parameters[15].Value = model.PictureBig;
			parameters[16].Value = model.IndexFlag;
			parameters[17].Value = model.IndexSortID;
			parameters[18].Value = model.CommendFlag;
			parameters[19].Value = model.CommendSortID;
			parameters[20].Value = model.HotFlag;
			parameters[21].Value = model.HotSortID;
			parameters[22].Value = model.ChannelFlag;
			parameters[23].Value = model.ChannelSortID;
			parameters[24].Value = model.CategoryFlag;
			parameters[25].Value = model.CategorySortID;
			parameters[26].Value = model.SortID;
			parameters[27].Value = model.SEOTitle;
			parameters[28].Value = model.SEOKeywords;
			parameters[29].Value = model.SEODescription;
			parameters[30].Value = model.ShowFlag;
			parameters[31].Value = model.CheckFlag;
			parameters[32].Value = model.CheckDate;
			parameters[33].Value = model.CheckUserID;
			parameters[34].Value = model.PostDate;
			parameters[35].Value = model.PostUserID;
			parameters[36].Value = model.EditDate;
			parameters[37].Value = model.EditUserID;
			parameters[38].Value = model.DelDate;
			parameters[39].Value = model.DelUserID;
			parameters[40].Value = model.MemberFlag;

			DbHelperSQL.RunProcedure("UP_NewsCategory_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.NewsCategory model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@TitleEn", SqlDbType.NVarChar,100),
					new SqlParameter("@Author", SqlDbType.NVarChar,100),
					new SqlParameter("@Source", SqlDbType.NVarChar,300),
					new SqlParameter("@Summary", SqlDbType.NVarChar,500),
					new SqlParameter("@Detail", SqlDbType.NText),
					new SqlParameter("@Tags", SqlDbType.NVarChar,500),
					new SqlParameter("@Hits", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.NVarChar,300),
					new SqlParameter("@Path", SqlDbType.NVarChar,1000),
					new SqlParameter("@PictureID", SqlDbType.Int,4),
					new SqlParameter("@PictureSmall", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureNormal", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureBig", SqlDbType.NVarChar,300),
					new SqlParameter("@IndexFlag", SqlDbType.Int,4),
					new SqlParameter("@IndexSortID", SqlDbType.Decimal,9),
					new SqlParameter("@CommendFlag", SqlDbType.Int,4),
					new SqlParameter("@CommendSortID", SqlDbType.Decimal,9),
					new SqlParameter("@HotFlag", SqlDbType.Int,4),
					new SqlParameter("@HotSortID", SqlDbType.Decimal,9),
					new SqlParameter("@ChannelFlag", SqlDbType.Int,4),
					new SqlParameter("@ChannelSortID", SqlDbType.Decimal,9),
					new SqlParameter("@CategoryFlag", SqlDbType.Int,4),
					new SqlParameter("@CategorySortID", SqlDbType.Decimal,9),
					new SqlParameter("@SortID", SqlDbType.Decimal,9),
					new SqlParameter("@SEOTitle", SqlDbType.NVarChar,200),
					new SqlParameter("@SEOKeywords", SqlDbType.NVarChar,300),
					new SqlParameter("@SEODescription", SqlDbType.NVarChar,500),
					new SqlParameter("@ShowFlag", SqlDbType.Int,4),
					new SqlParameter("@CheckFlag", SqlDbType.Int,4),
					new SqlParameter("@CheckDate", SqlDbType.BigInt,8),
					new SqlParameter("@CheckUserID", SqlDbType.Int,4),
					new SqlParameter("@PostDate", SqlDbType.BigInt,8),
					new SqlParameter("@PostUserID", SqlDbType.Int,4),
					new SqlParameter("@EditDate", SqlDbType.BigInt,8),
					new SqlParameter("@EditUserID", SqlDbType.Int,4),
					new SqlParameter("@DelDate", SqlDbType.BigInt,8),
					new SqlParameter("@DelUserID", SqlDbType.Int,4),
					new SqlParameter("@MemberFlag", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
            parameters[1].Value = model.ParentID;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.TitleEn;
			parameters[4].Value = model.Author;
			parameters[5].Value = model.Source;
			parameters[6].Value = model.Summary;
			parameters[7].Value = model.Detail;
			parameters[8].Value = model.Tags;
			parameters[9].Value = model.Hits;
			parameters[10].Value = model.Url;
			parameters[11].Value = model.Path;
			parameters[12].Value = model.PictureID;
			parameters[13].Value = model.PictureSmall;
			parameters[14].Value = model.PictureNormal;
			parameters[15].Value = model.PictureBig;
			parameters[16].Value = model.IndexFlag;
			parameters[17].Value = model.IndexSortID;
			parameters[18].Value = model.CommendFlag;
			parameters[19].Value = model.CommendSortID;
			parameters[20].Value = model.HotFlag;
			parameters[21].Value = model.HotSortID;
			parameters[22].Value = model.ChannelFlag;
			parameters[23].Value = model.ChannelSortID;
			parameters[24].Value = model.CategoryFlag;
			parameters[25].Value = model.CategorySortID;
			parameters[26].Value = model.SortID;
			parameters[27].Value = model.SEOTitle;
			parameters[28].Value = model.SEOKeywords;
			parameters[29].Value = model.SEODescription;
			parameters[30].Value = model.ShowFlag;
			parameters[31].Value = model.CheckFlag;
			parameters[32].Value = model.CheckDate;
			parameters[33].Value = model.CheckUserID;
			parameters[34].Value = model.PostDate;
			parameters[35].Value = model.PostUserID;
			parameters[36].Value = model.EditDate;
			parameters[37].Value = model.EditUserID;
			parameters[38].Value = model.DelDate;
			parameters[39].Value = model.DelUserID;
			parameters[40].Value = model.MemberFlag;

			DbHelperSQL.RunProcedure("UP_NewsCategory_Update",parameters,out rowsAffected);
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

			DbHelperSQL.RunProcedure("UP_NewsCategory_Delete",parameters,out rowsAffected);
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

			DataSet ds= DbHelperSQL.RunProcedure("UP_NewsCategory_GetModel",parameters,"ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_NewsCategory_GetList_ByCondition", parameters, "ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_NewsCategory_GetList", parameters, "ds");
			totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
			return ds;
		}
		#endregion 

		#endregion  成员方法
	}
}

