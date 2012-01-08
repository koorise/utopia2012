using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GK2010.Utility;
namespace GK2010.DAL
{
	/// <summary>
	/// ���ݷ�����ProductParts��
	/// </summary>
	public class ProductParts
	{
		#region  ���캯��
		public ProductParts()
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

			int result= DbHelperSQL.RunProcedure("UP_ProductParts_Exists",parameters,out rowsAffected);
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
		public int Add(GK2010.Model.ProductParts model)
		{
			int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@CacheID", SqlDbType.BigInt,8),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@RootID", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@HasChild", SqlDbType.Int,4),
					new SqlParameter("@HasParts", SqlDbType.Int,4),
					new SqlParameter("@Path", SqlDbType.NVarChar,1000),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@TitleEn", SqlDbType.NVarChar,100),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Summary", SqlDbType.NVarChar,500),
					new SqlParameter("@Detail", SqlDbType.NText),
					new SqlParameter("@Url", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureID", SqlDbType.Int,4),
					new SqlParameter("@PictureSmall", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureNormal", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureBig", SqlDbType.NVarChar,300),
					new SqlParameter("@SortID", SqlDbType.Decimal,9),
					new SqlParameter("@PostDate", SqlDbType.BigInt,8),
					new SqlParameter("@PostUserID", SqlDbType.Int,4),
					new SqlParameter("@EditDate", SqlDbType.BigInt,8),
					new SqlParameter("@EditUserID", SqlDbType.Int,4),
					new SqlParameter("@DelDate", SqlDbType.BigInt,8),
					new SqlParameter("@DelUserID", SqlDbType.Int,4),
					new SqlParameter("@ShowFlag", SqlDbType.Int,4),
					new SqlParameter("@DefaultFlag", SqlDbType.Int,4),
					new SqlParameter("@AttachmentFlag", SqlDbType.Int,4),
					new SqlParameter("@Flag", SqlDbType.Int,4)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.CacheID;
            parameters[2].Value = model.ProductID;
            parameters[3].Value = model.RootID;
            parameters[4].Value = model.ParentID;
            parameters[5].Value = model.HasChild;
            parameters[6].Value = model.HasParts;
            parameters[7].Value = model.Path;
            parameters[8].Value = model.Title;
            parameters[9].Value = model.TitleEn;
            parameters[10].Value = model.Price;
            parameters[11].Value = model.Summary;
            parameters[12].Value = model.Detail;
            parameters[13].Value = model.Url;
            parameters[14].Value = model.PictureID;
            parameters[15].Value = model.PictureSmall;
            parameters[16].Value = model.PictureNormal;
            parameters[17].Value = model.PictureBig;
            parameters[18].Value = model.SortID;
            parameters[19].Value = model.PostDate;
            parameters[20].Value = model.PostUserID;
            parameters[21].Value = model.EditDate;
            parameters[22].Value = model.EditUserID;
            parameters[23].Value = model.DelDate;
            parameters[24].Value = model.DelUserID;
            parameters[25].Value = model.ShowFlag;
            parameters[26].Value = model.DefaultFlag;
            parameters[27].Value = model.AttachmentFlag;
            parameters[28].Value = model.Flag;
			DbHelperSQL.RunProcedure("UP_ProductParts_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}
		#endregion

		#region  ����һ������
		/// <summary>
		///  ����һ������
		/// </summary>
		public bool Update(GK2010.Model.ProductParts model)
		{
			int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@CacheID", SqlDbType.BigInt,8),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@RootID", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@HasChild", SqlDbType.Int,4),
					new SqlParameter("@HasParts", SqlDbType.Int,4),
					new SqlParameter("@Path", SqlDbType.NVarChar,1000),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@TitleEn", SqlDbType.NVarChar,100),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Summary", SqlDbType.NVarChar,500),
					new SqlParameter("@Detail", SqlDbType.NText),
					new SqlParameter("@Url", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureID", SqlDbType.Int,4),
					new SqlParameter("@PictureSmall", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureNormal", SqlDbType.NVarChar,300),
					new SqlParameter("@PictureBig", SqlDbType.NVarChar,300),
					new SqlParameter("@SortID", SqlDbType.Decimal,9),
					new SqlParameter("@PostDate", SqlDbType.BigInt,8),
					new SqlParameter("@PostUserID", SqlDbType.Int,4),
					new SqlParameter("@EditDate", SqlDbType.BigInt,8),
					new SqlParameter("@EditUserID", SqlDbType.Int,4),
					new SqlParameter("@DelDate", SqlDbType.BigInt,8),
					new SqlParameter("@DelUserID", SqlDbType.Int,4),
					new SqlParameter("@ShowFlag", SqlDbType.Int,4),
					new SqlParameter("@DefaultFlag", SqlDbType.Int,4),
					new SqlParameter("@AttachmentFlag", SqlDbType.Int,4),
					new SqlParameter("@Flag", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.CacheID;
            parameters[2].Value = model.ProductID;
            parameters[3].Value = model.RootID;
            parameters[4].Value = model.ParentID;
            parameters[5].Value = model.HasChild;
            parameters[6].Value = model.HasParts;
            parameters[7].Value = model.Path;
            parameters[8].Value = model.Title;
            parameters[9].Value = model.TitleEn;
            parameters[10].Value = model.Price;
            parameters[11].Value = model.Summary;
            parameters[12].Value = model.Detail;
            parameters[13].Value = model.Url;
            parameters[14].Value = model.PictureID;
            parameters[15].Value = model.PictureSmall;
            parameters[16].Value = model.PictureNormal;
            parameters[17].Value = model.PictureBig;
            parameters[18].Value = model.SortID;
            parameters[19].Value = model.PostDate;
            parameters[20].Value = model.PostUserID;
            parameters[21].Value = model.EditDate;
            parameters[22].Value = model.EditUserID;
            parameters[23].Value = model.DelDate;
            parameters[24].Value = model.DelUserID;
            parameters[25].Value = model.ShowFlag;
            parameters[26].Value = model.DefaultFlag;
            parameters[27].Value = model.AttachmentFlag;
            parameters[28].Value = model.Flag;

			DbHelperSQL.RunProcedure("UP_ProductParts_Update",parameters,out rowsAffected);
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

			DbHelperSQL.RunProcedure("UP_ProductParts_Delete",parameters,out rowsAffected);
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

			DataSet ds= DbHelperSQL.RunProcedure("UP_ProductParts_GetModel",parameters,"ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_ProductParts_GetList_ByCondition", parameters, "ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_ProductParts_GetList", parameters, "ds");
			totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
			return ds;
		}
		#endregion 

        #region ��ȡ��Ʒ����������productID ��Flag
        public DataSet GetProductPartsByProductIDAndFlag(int productID,int defaultFlag, int flag)
        {
            SqlParameter[] parameters = {
				new SqlParameter("@ProductID", SqlDbType.Int,4),
				new SqlParameter("@DefaultFlag", SqlDbType.Int,4),
				new SqlParameter("@Flag", SqlDbType.Int,4)
			};
            parameters[0].Value = productID;
            parameters[1].Value = defaultFlag;
            parameters[2].Value = flag;
            DataSet ds = DbHelperSQL.RunProcedure("UP_ProductParts_GetList_ByProductIDAndDefaultFlagAndFlag", parameters, "ds");
            return ds;
        }
        #endregion

		#endregion  ��Ա����

        #region  �޸�Ĭ����
		/// <summary>
        ///  �޸�Ĭ����
		/// </summary>
        public bool StaticDefault(int ID)
		{
			int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@DefaultFlag", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            parameters[1].Value = 1;

            DbHelperSQL.RunProcedure("UP_ProductParts_StaticDefault", parameters, out rowsAffected);
			return rowsAffected > 0;
		}
		#endregion

        #region ͳ�Ƴ�һ����Ʒ���ͺŵ�
        public DataSet Static(int ProductID)
        {
            SqlParameter[] parameters = {
				new SqlParameter("@ProductID", SqlDbType.Int, 4)
			};
            parameters[0].Value = ProductID;
            DataSet ds = DbHelperSQL.RunProcedure("UP_ProductParts_Static", parameters, "ds");
            return ds;
        }
        #endregion 
        
	}
}

