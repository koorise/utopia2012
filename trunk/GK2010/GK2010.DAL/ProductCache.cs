using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GK2010.Utility;
namespace GK2010.DAL
{
	/// <summary>
	/// 数据访问类ProductCache。
	/// </summary>
	public class ProductCache
	{
		#region  构造函数
		public ProductCache()
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

			int result= DbHelperSQL.RunProcedure("UP_ProductCache_Exists",parameters,out rowsAffected);
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
		public int Add(GK2010.Model.ProductCache model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@CacheID", SqlDbType.BigInt,8),
					new SqlParameter("@OldID", SqlDbType.Int,4),
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@TitleEn", SqlDbType.NVarChar,500),
					new SqlParameter("@Summary", SqlDbType.NVarChar,500),
					new SqlParameter("@Detail", SqlDbType.NText),
					new SqlParameter("@Tags", SqlDbType.NVarChar,1000),
					new SqlParameter("@Hits", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.NVarChar,300),
					new SqlParameter("@DefaultBrand", SqlDbType.NVarChar,100),
					new SqlParameter("@DefaultPeriod", SqlDbType.NVarChar,100),
					new SqlParameter("@DefaultPriceOld", SqlDbType.Decimal,9),
					new SqlParameter("@DefaultPrice", SqlDbType.Decimal,9),
					new SqlParameter("@DefaultJF", SqlDbType.Decimal,9),
					new SqlParameter("@PictureID", SqlDbType.Int,4),
					new SqlParameter("@PictureSmall", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureNormal", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureBig", SqlDbType.NVarChar,300),
					new SqlParameter("@SortID", SqlDbType.Decimal,9),
					new SqlParameter("@ShowFlag", SqlDbType.Int,4),
					new SqlParameter("@PostDate", SqlDbType.BigInt,8),
					new SqlParameter("@PostUserID", SqlDbType.Int,4),
					new SqlParameter("@MemberFlag", SqlDbType.Int,4),
					new SqlParameter("@DiyFlag", SqlDbType.Int,4),
					new SqlParameter("@DiyTypeCn", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypeEn", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypePartsID", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypePrice", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypeAttachmentFlag", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyExpression", SqlDbType.NVarChar,1000),
					new SqlParameter("@BasicDiscountPrice", SqlDbType.Int,4),
					new SqlParameter("@BasicDiscountJF", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.CacheID;
			parameters[2].Value = model.OldID;
			parameters[3].Value = model.CategoryID;
			parameters[4].Value = model.Title;
			parameters[5].Value = model.TitleEn;
			parameters[6].Value = model.Summary;
			parameters[7].Value = model.Detail;
			parameters[8].Value = model.Tags;
			parameters[9].Value = model.Hits;
			parameters[10].Value = model.Url;
			parameters[11].Value = model.DefaultBrand;
			parameters[12].Value = model.DefaultPeriod;
			parameters[13].Value = model.DefaultPriceOld;
			parameters[14].Value = model.DefaultPrice;
			parameters[15].Value = model.DefaultJF;
			parameters[16].Value = model.PictureID;
			parameters[17].Value = model.PictureSmall;
			parameters[18].Value = model.PictureNormal;
			parameters[19].Value = model.PictureBig;
			parameters[20].Value = model.SortID;
			parameters[21].Value = model.ShowFlag;
			parameters[22].Value = model.PostDate;
			parameters[23].Value = model.PostUserID;
			parameters[24].Value = model.MemberFlag;
			parameters[25].Value = model.DiyFlag;
			parameters[26].Value = model.DiyTypeCn;
			parameters[27].Value = model.DiyTypeEn;
			parameters[28].Value = model.DiyTypePartsID;
			parameters[29].Value = model.DiyTypePrice;
			parameters[30].Value = model.DiyTypeAttachmentFlag;
			parameters[31].Value = model.DiyExpression;
			parameters[32].Value = model.BasicDiscountPrice;
			parameters[33].Value = model.BasicDiscountJF;

			DbHelperSQL.RunProcedure("UP_ProductCache_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.ProductCache model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@CacheID", SqlDbType.BigInt,8),
					new SqlParameter("@OldID", SqlDbType.Int,4),
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@TitleEn", SqlDbType.NVarChar,500),
					new SqlParameter("@Summary", SqlDbType.NVarChar,500),
					new SqlParameter("@Detail", SqlDbType.NText),
					new SqlParameter("@Tags", SqlDbType.NVarChar,1000),
					new SqlParameter("@Hits", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.NVarChar,300),
					new SqlParameter("@DefaultBrand", SqlDbType.NVarChar,100),
					new SqlParameter("@DefaultPeriod", SqlDbType.NVarChar,100),
					new SqlParameter("@DefaultPriceOld", SqlDbType.Decimal,9),
					new SqlParameter("@DefaultPrice", SqlDbType.Decimal,9),
					new SqlParameter("@DefaultJF", SqlDbType.Decimal,9),
					new SqlParameter("@PictureID", SqlDbType.Int,4),
					new SqlParameter("@PictureSmall", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureNormal", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureBig", SqlDbType.NVarChar,300),
					new SqlParameter("@SortID", SqlDbType.Decimal,9),
					new SqlParameter("@ShowFlag", SqlDbType.Int,4),
					new SqlParameter("@PostDate", SqlDbType.BigInt,8),
					new SqlParameter("@PostUserID", SqlDbType.Int,4),
					new SqlParameter("@MemberFlag", SqlDbType.Int,4),
					new SqlParameter("@DiyFlag", SqlDbType.Int,4),
					new SqlParameter("@DiyTypeCn", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypeEn", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypePartsID", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypePrice", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypeAttachmentFlag", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyExpression", SqlDbType.NVarChar,1000),
					new SqlParameter("@BasicDiscountPrice", SqlDbType.Int,4),
					new SqlParameter("@BasicDiscountJF", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.CacheID;
			parameters[2].Value = model.OldID;
			parameters[3].Value = model.CategoryID;
			parameters[4].Value = model.Title;
			parameters[5].Value = model.TitleEn;
			parameters[6].Value = model.Summary;
			parameters[7].Value = model.Detail;
			parameters[8].Value = model.Tags;
			parameters[9].Value = model.Hits;
			parameters[10].Value = model.Url;
			parameters[11].Value = model.DefaultBrand;
			parameters[12].Value = model.DefaultPeriod;
			parameters[13].Value = model.DefaultPriceOld;
			parameters[14].Value = model.DefaultPrice;
			parameters[15].Value = model.DefaultJF;
			parameters[16].Value = model.PictureID;
			parameters[17].Value = model.PictureSmall;
			parameters[18].Value = model.PictureNormal;
			parameters[19].Value = model.PictureBig;
			parameters[20].Value = model.SortID;
			parameters[21].Value = model.ShowFlag;
			parameters[22].Value = model.PostDate;
			parameters[23].Value = model.PostUserID;
			parameters[24].Value = model.MemberFlag;
			parameters[25].Value = model.DiyFlag;
			parameters[26].Value = model.DiyTypeCn;
			parameters[27].Value = model.DiyTypeEn;
			parameters[28].Value = model.DiyTypePartsID;
			parameters[29].Value = model.DiyTypePrice;
			parameters[30].Value = model.DiyTypeAttachmentFlag;
			parameters[31].Value = model.DiyExpression;
			parameters[32].Value = model.BasicDiscountPrice;
			parameters[33].Value = model.BasicDiscountJF;

			DbHelperSQL.RunProcedure("UP_ProductCache_Update",parameters,out rowsAffected);
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

			DbHelperSQL.RunProcedure("UP_ProductCache_Delete",parameters,out rowsAffected);
			return rowsAffected > 0;
		}
		#endregion

        #region  删除产品快照根据从购物车中获取来的快照编号
        public bool DeleteByProductCacheID(long productCacheID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ProductCacheID", SqlDbType.BigInt,8)};
			parameters[0].Value = productCacheID;

            DbHelperSQL.RunProcedure("UP_ProductCache_DeleteByProductCacheID", parameters, out rowsAffected);
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

			DataSet ds= DbHelperSQL.RunProcedure("UP_ProductCache_GetModel",parameters,"ds");
			return ds;
		}
		#endregion

        #region 根据用户id和产品id查询快照表是否存在数据
        public DataSet GetModelByUserIDAndProductID(int userID, int productID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                                        new SqlParameter("@ProductID", SqlDbType.Int,4)};
            parameters[0].Value = userID;
            parameters[1].Value = productID;

            DataSet ds = DbHelperSQL.RunProcedure("UP_ProductCache_GetModelByUserIDAndProductID", parameters, "ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_ProductCache_GetList_ByCondition", parameters, "ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_ProductCache_GetList", parameters, "ds");
			totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
			return ds;
		}
		#endregion 

		#endregion  成员方法
	}
}

