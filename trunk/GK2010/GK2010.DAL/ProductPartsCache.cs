using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GK2010.Utility;
namespace GK2010.DAL
{
	/// <summary>
	/// ���ݷ�����ProductPartsCache��
	/// </summary>
	public class ProductPartsCache
	{
		#region  ���캯��
		public ProductPartsCache()
		{}
		#endregion
		
		#region  ��Ա����

		#region  �Ƿ���ڸü�¼
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			int result= DbHelperSQL.RunProcedure("UP_ProductPartsCache_Exists",parameters,out rowsAffected);
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

		#region  ����һ������
		/// <summary>
		///  ����һ������
		/// </summary>
		public int Add(GK2010.Model.ProductPartsCache model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@CacheID", SqlDbType.BigInt,8),
					new SqlParameter("@OldID", SqlDbType.Int,4),
					new SqlParameter("@ProductCatchID", SqlDbType.BigInt,8),
					new SqlParameter("@RootID", SqlDbType.Int,4),
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@CategoryPath", SqlDbType.NVarChar,1000),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@TitleEn", SqlDbType.NVarChar,100),
					new SqlParameter("@Summary", SqlDbType.NVarChar,500),
					new SqlParameter("@Detail", SqlDbType.NText),
					new SqlParameter("@PictureID", SqlDbType.Int,4),
					new SqlParameter("@PictureSmall", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureNormal", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureBig", SqlDbType.NVarChar,300),
					new SqlParameter("@SortID", SqlDbType.Decimal,9),
					new SqlParameter("@PostDate", SqlDbType.BigInt,8),
					new SqlParameter("@PostUserID", SqlDbType.Int,4),
					new SqlParameter("@ShowFlag", SqlDbType.Int,4),
					new SqlParameter("@DefaultFlag", SqlDbType.Int,4),
					new SqlParameter("@AttachmentFlag", SqlDbType.Int,4),
					new SqlParameter("@Flag", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.CacheID;
			parameters[2].Value = model.OldID;
			parameters[3].Value = model.ProductCatchID;
			parameters[4].Value = model.RootID;
			parameters[5].Value = model.CategoryID;
			parameters[6].Value = model.CategoryPath;
			parameters[7].Value = model.Title;
			parameters[8].Value = model.TitleEn;
			parameters[9].Value = model.Summary;
			parameters[10].Value = model.Detail;
			parameters[11].Value = model.PictureID;
			parameters[12].Value = model.PictureSmall;
			parameters[13].Value = model.PictureNormal;
			parameters[14].Value = model.PictureBig;
			parameters[15].Value = model.SortID;
			parameters[16].Value = model.PostDate;
			parameters[17].Value = model.PostUserID;
			parameters[18].Value = model.ShowFlag;
			parameters[19].Value = model.DefaultFlag;
			parameters[20].Value = model.AttachmentFlag;
			parameters[21].Value = model.Flag;

			DbHelperSQL.RunProcedure("UP_ProductPartsCache_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}
		#endregion

		#region  ����һ������
		/// <summary>
		///  ����һ������
		/// </summary>
		public bool Update(GK2010.Model.ProductPartsCache model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@CacheID", SqlDbType.BigInt,8),
					new SqlParameter("@OldID", SqlDbType.Int,4),
					new SqlParameter("@ProductCatchID", SqlDbType.BigInt,8),
					new SqlParameter("@RootID", SqlDbType.Int,4),
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@CategoryPath", SqlDbType.NVarChar,1000),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@TitleEn", SqlDbType.NVarChar,100),
					new SqlParameter("@Summary", SqlDbType.NVarChar,500),
					new SqlParameter("@Detail", SqlDbType.NText),
					new SqlParameter("@PictureID", SqlDbType.Int,4),
					new SqlParameter("@PictureSmall", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureNormal", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureBig", SqlDbType.NVarChar,300),
					new SqlParameter("@SortID", SqlDbType.Decimal,9),
					new SqlParameter("@PostDate", SqlDbType.BigInt,8),
					new SqlParameter("@PostUserID", SqlDbType.Int,4),
					new SqlParameter("@ShowFlag", SqlDbType.Int,4),
					new SqlParameter("@DefaultFlag", SqlDbType.Int,4),
					new SqlParameter("@AttachmentFlag", SqlDbType.Int,4),
					new SqlParameter("@Flag", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.CacheID;
			parameters[2].Value = model.OldID;
			parameters[3].Value = model.ProductCatchID;
			parameters[4].Value = model.RootID;
			parameters[5].Value = model.CategoryID;
			parameters[6].Value = model.CategoryPath;
			parameters[7].Value = model.Title;
			parameters[8].Value = model.TitleEn;
			parameters[9].Value = model.Summary;
			parameters[10].Value = model.Detail;
			parameters[11].Value = model.PictureID;
			parameters[12].Value = model.PictureSmall;
			parameters[13].Value = model.PictureNormal;
			parameters[14].Value = model.PictureBig;
			parameters[15].Value = model.SortID;
			parameters[16].Value = model.PostDate;
			parameters[17].Value = model.PostUserID;
			parameters[18].Value = model.ShowFlag;
			parameters[19].Value = model.DefaultFlag;
			parameters[20].Value = model.AttachmentFlag;
			parameters[21].Value = model.Flag;

			DbHelperSQL.RunProcedure("UP_ProductPartsCache_Update",parameters,out rowsAffected);
			return rowsAffected > 0;
		}
		#endregion

		#region  ɾ��һ������
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int ID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.RunProcedure("UP_ProductPartsCache_Delete",parameters,out rowsAffected);
			return rowsAffected > 0;
		}
		#endregion

        #region  ���ݹ��ﳵ�л�õĲ�Ʒ�������ձ��ɾ������
        public bool DeleteByProductPartsCacheID(long productPartsCacheID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ProductPartsCacheID", SqlDbType.BigInt,8)};
            parameters[0].Value = productPartsCacheID;
            int rowsAffected;
            DbHelperSQL.RunProcedure("UP_ProductPartsCache_DeleteByProductPartsCacheID", parameters, out rowsAffected);
            return rowsAffected > 0;
        }
        #endregion



		#region  �õ�һ������ʵ��
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public DataSet GetModel(int ID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DataSet ds= DbHelperSQL.RunProcedure("UP_ProductPartsCache_GetModel",parameters,"ds");
			return ds;
		}
		#endregion

        #region ���ݲ�Ʒ���ձ�ź��û�id���в�ѯ
        public DataSet GetModelByProductPartCacheIDAndUserID(long productPartCacheID, int userID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@productPartCacheID", SqlDbType.BigInt,8),
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = productPartCacheID;
            parameters[1].Value = userID;

            DataSet ds = DbHelperSQL.RunProcedure("UP_ProductPartsCache_GetModelByProductPartCacheIDAndUserID", parameters, "ds");
            return ds;
        }
        #endregion 

		#region �б�(����ҳ)
		public DataSet GetList(string Keywords, string Type)
		{
			SqlParameter[] parameters = {
				new SqlParameter("@Keywords", SqlDbType.VarChar, 50),
				new SqlParameter("@Type", SqlDbType.VarChar,50)
			};
			parameters[0].Value = Keywords;
			parameters[1].Value = Type;
			DataSet ds = DbHelperSQL.RunProcedure("UP_ProductPartsCache_GetList_ByCondition", parameters, "ds");
			return ds;
		}
		#endregion 
		
		#region �б�(��̨��ҳ����)
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_ProductPartsCache_GetList", parameters, "ds");
			totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
			return ds;
		}
		#endregion 

		#endregion  ��Ա����
	}
}

