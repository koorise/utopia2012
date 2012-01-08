using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GK2010.Utility;
using GK2010.Model;
namespace GK2010.DAL
{
	/// <summary>
	/// 数据访问类Product。
	/// </summary>
	public class Product
	{
		#region  构造函数
		public Product()
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

			int result= DbHelperSQL.RunProcedure("UP_Product_Exists",parameters,out rowsAffected);
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
		public int Add(GK2010.Model.Product model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@CacheID", SqlDbType.BigInt,8),
					new SqlParameter("@RootID", SqlDbType.Int,4),
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
					new SqlParameter("@MemberFlag", SqlDbType.Int,4),
					new SqlParameter("@DiyFlag", SqlDbType.Int,4),
					new SqlParameter("@DiyTypeCn", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypeEn", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypePartsID", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypePrice", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypeAttachmentFlag", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyExpression", SqlDbType.NVarChar,1000),
					new SqlParameter("@BasicDiscountPrice", SqlDbType.Int,4),
					new SqlParameter("@BasicDiscountJF", SqlDbType.Int,4),
                    new SqlParameter("@DiyTypeShowFlag", SqlDbType.NVarChar,2000),
                    new SqlParameter("@DefaultType", SqlDbType.NVarChar,1000)                
            };
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.CacheID;
			parameters[2].Value = model.RootID;
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
			parameters[20].Value = model.IndexFlag;
			parameters[21].Value = model.IndexSortID;
			parameters[22].Value = model.CommendFlag;
			parameters[23].Value = model.CommendSortID;
			parameters[24].Value = model.HotFlag;
			parameters[25].Value = model.HotSortID;
			parameters[26].Value = model.ChannelFlag;
			parameters[27].Value = model.ChannelSortID;
			parameters[28].Value = model.CategoryFlag;
			parameters[29].Value = model.CategorySortID;
			parameters[30].Value = model.SortID;
			parameters[31].Value = model.SEOTitle;
			parameters[32].Value = model.SEOKeywords;
			parameters[33].Value = model.SEODescription;
			parameters[34].Value = model.ShowFlag;
			parameters[35].Value = model.CheckFlag;
			parameters[36].Value = model.CheckDate;
			parameters[37].Value = model.CheckUserID;
			parameters[38].Value = model.PostDate;
			parameters[39].Value = model.PostUserID;
			parameters[40].Value = model.EditDate;
			parameters[41].Value = model.EditUserID;
			parameters[42].Value = model.DelDate;
			parameters[43].Value = model.DelUserID;
			parameters[44].Value = model.MemberFlag;
			parameters[45].Value = model.DiyFlag;
			parameters[46].Value = model.DiyTypeCn;
			parameters[47].Value = model.DiyTypeEn;
			parameters[48].Value = model.DiyTypePartsID;
			parameters[49].Value = model.DiyTypePrice;
			parameters[50].Value = model.DiyTypeAttachmentFlag;
			parameters[51].Value = model.DiyExpression;
			parameters[52].Value = model.BasicDiscountPrice;
			parameters[53].Value = model.BasicDiscountJF;
            parameters[54].Value = model.DiyTypeShowFlag;
            parameters[55].Value = model.DefaultType;

			DbHelperSQL.RunProcedure("UP_Product_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.Product model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@CacheID", SqlDbType.BigInt,8),
					new SqlParameter("@RootID", SqlDbType.Int,4),
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
					new SqlParameter("@MemberFlag", SqlDbType.Int,4),
					new SqlParameter("@DiyFlag", SqlDbType.Int,4),
					new SqlParameter("@DiyTypeCn", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypeEn", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypePartsID", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypePrice", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypeAttachmentFlag", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyExpression", SqlDbType.NVarChar,1000),
					new SqlParameter("@BasicDiscountPrice", SqlDbType.Int,4),
					new SqlParameter("@BasicDiscountJF", SqlDbType.Int,4),
                    new SqlParameter("@DiyTypeShowFlag", SqlDbType.NVarChar,2000),
                    new SqlParameter("@DefaultType", SqlDbType.NVarChar,1000)                
            };
			parameters[0].Value = model.ID;
			parameters[1].Value = model.CacheID;
			parameters[2].Value = model.RootID;
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
			parameters[20].Value = model.IndexFlag;
			parameters[21].Value = model.IndexSortID;
			parameters[22].Value = model.CommendFlag;
			parameters[23].Value = model.CommendSortID;
			parameters[24].Value = model.HotFlag;
			parameters[25].Value = model.HotSortID;
			parameters[26].Value = model.ChannelFlag;
			parameters[27].Value = model.ChannelSortID;
			parameters[28].Value = model.CategoryFlag;
			parameters[29].Value = model.CategorySortID;
			parameters[30].Value = model.SortID;
			parameters[31].Value = model.SEOTitle;
			parameters[32].Value = model.SEOKeywords;
			parameters[33].Value = model.SEODescription;
			parameters[34].Value = model.ShowFlag;
			parameters[35].Value = model.CheckFlag;
			parameters[36].Value = model.CheckDate;
			parameters[37].Value = model.CheckUserID;
			parameters[38].Value = model.PostDate;
			parameters[39].Value = model.PostUserID;
			parameters[40].Value = model.EditDate;
			parameters[41].Value = model.EditUserID;
			parameters[42].Value = model.DelDate;
			parameters[43].Value = model.DelUserID;
			parameters[44].Value = model.MemberFlag;
			parameters[45].Value = model.DiyFlag;
			parameters[46].Value = model.DiyTypeCn;
			parameters[47].Value = model.DiyTypeEn;
			parameters[48].Value = model.DiyTypePartsID;
			parameters[49].Value = model.DiyTypePrice;
			parameters[50].Value = model.DiyTypeAttachmentFlag;
			parameters[51].Value = model.DiyExpression;
			parameters[52].Value = model.BasicDiscountPrice;
			parameters[53].Value = model.BasicDiscountJF;
            parameters[54].Value = model.DiyTypeShowFlag;
            parameters[55].Value = model.DefaultType;

			DbHelperSQL.RunProcedure("UP_Product_Update",parameters,out rowsAffected);
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

			DbHelperSQL.RunProcedure("UP_Product_Delete",parameters,out rowsAffected);
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

			DataSet ds= DbHelperSQL.RunProcedure("UP_Product_GetModel",parameters,"ds");
			return ds;
		}
		#endregion

        #region 根据快照编号得到一个实体
        public DataSet GetModelByProductCacheID(long productCacheID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ProductCatchID", SqlDbType.BigInt,8)};
            parameters[0].Value = productCacheID;

            DataSet ds = DbHelperSQL.RunProcedure("UP_Product_GetModelByProductCacheID", parameters, "ds");
            return ds;
        }
        #endregion

        #region 获取购买本产品的顾客还购买的产品
        public DataSet GetPayHistory(int productID) {
            SqlParameter[] parameter = { 
                                       new SqlParameter("ID",SqlDbType.Int,4)
                                       };
            parameter[0].Value = productID;
            return DbHelperSQL.RunProcedure("UP_MemberProductPayHistory", parameter, "ds");
        }
        #endregion

        #region 商品热卖
        public DataSet GetProductHotSale() {
            return DbHelperSQL.Query("UP_MemberProductHotSale");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_Product_GetList_ByCondition", parameters, "ds");
			return ds;
		}
		#endregion 
    
		
		#region 列表(后台分页管理)
		public DataSet GetList(int PageSize, int PageIndex, string Keywords, string Type, out int totalRows)
		{
			SqlParameter[] parameters = {
				new SqlParameter("@PageSize", SqlDbType.Int),
				new SqlParameter("@PageIndex", SqlDbType.Int),
				new SqlParameter("@Keywords", SqlDbType.VarChar,1000),
				new SqlParameter("@Type", SqlDbType.VarChar,50),
			};
			parameters[0].Value = PageSize;
			parameters[1].Value = PageIndex;
			parameters[2].Value = Keywords;
			parameters[3].Value = Type;
			DataSet ds = DbHelperSQL.RunProcedure("UP_Product_GetList", parameters, "ds");
			totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
			return ds;
		}
		#endregion 

		#endregion  成员方法

        #region  前台分页
        /// <summary>
        /// 前台分页
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, int UserID, int BigID, int SmallID, int ThirdID, VirtualSearch VirtualSearch, int OrderType, out int totalRows)
        {
            SqlParameter[] parameters = {
				new SqlParameter("@PageSize", SqlDbType.Int),
				new SqlParameter("@PageIndex", SqlDbType.Int),
				new SqlParameter("@UserID", SqlDbType.Int,4),
				new SqlParameter("@BigID", SqlDbType.Int,4),
                new SqlParameter("@SmallID", SqlDbType.Int,4),
                new SqlParameter("@ThirdID", SqlDbType.Int,4),
                new SqlParameter("@VirtualCategoryID1", SqlDbType.Int,4),
                new SqlParameter("@VirtualCategoryID2", SqlDbType.Int,4),
                new SqlParameter("@VirtualCategoryID3", SqlDbType.Int,4),
                new SqlParameter("@VirtualCategoryID4", SqlDbType.Int,4),
                new SqlParameter("@VirtualCategoryID5", SqlDbType.Int,4),
                new SqlParameter("@VirtualCategoryID6", SqlDbType.Int,4),
                new SqlParameter("@VirtualCategoryID7", SqlDbType.Int,4),
                new SqlParameter("@VirtualCategoryID8", SqlDbType.Int,4),
                new SqlParameter("@VirtualCategoryID9", SqlDbType.Int,4),
                new SqlParameter("@VirtualCategoryID10", SqlDbType.Int,4),
                new SqlParameter("@OrderType", SqlDbType.Int,4)
			};
            parameters[0].Value = PageSize;
            parameters[1].Value = PageIndex;
            parameters[2].Value = UserID;
            parameters[3].Value = BigID;
            parameters[4].Value = SmallID;
            parameters[5].Value = ThirdID;
            parameters[6].Value = VirtualSearch.VirtualCategoryID1;
            parameters[7].Value = VirtualSearch.VirtualCategoryID2;
            parameters[8].Value = VirtualSearch.VirtualCategoryID3;
            parameters[9].Value = VirtualSearch.VirtualCategoryID4;
            parameters[10].Value = VirtualSearch.VirtualCategoryID5;
            parameters[11].Value = VirtualSearch.VirtualCategoryID6;
            parameters[12].Value = VirtualSearch.VirtualCategoryID7;
            parameters[13].Value = VirtualSearch.VirtualCategoryID8;
            parameters[14].Value = VirtualSearch.VirtualCategoryID9;
            parameters[15].Value = VirtualSearch.VirtualCategoryID10;
            parameters[16].Value = OrderType;
            DataSet ds = DbHelperSQL.RunProcedure("UP_Product_GetListByUserID", parameters, "ds");
            totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
            return ds;
        }
        #endregion
	}
}

