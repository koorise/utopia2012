using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GK2010.Utility;
using System.Web;
namespace GK2010.DAL
{
	/// <summary>
	/// ���ݷ�����SystemTree��
	/// </summary>
	public class SystemTree
	{
		#region  ���캯��
		public SystemTree()
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

			int result= DbHelperSQL.RunProcedure("UP_SystemTree_Exists",parameters,out rowsAffected);
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
		public int Add(GK2010.Model.SystemTree model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@TitleEn", SqlDbType.NVarChar,100),
					new SqlParameter("@Summary", SqlDbType.NVarChar,500),
					new SqlParameter("@Detail", SqlDbType.NText),
					new SqlParameter("@PictureID", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.NVarChar,300),
					new SqlParameter("@Path", SqlDbType.NVarChar,1000),
					new SqlParameter("@HasChild", SqlDbType.Int,4),
					new SqlParameter("@SortID", SqlDbType.Decimal,9),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@IsShow", SqlDbType.Int,4),
					new SqlParameter("@IsDefault", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.ParentID;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.TitleEn;
			parameters[4].Value = model.Summary;
			parameters[5].Value = model.Detail;
			parameters[6].Value = model.PictureID;
			parameters[7].Value = model.Url;
			parameters[8].Value = model.Path;
			parameters[9].Value = model.HasChild;
			parameters[10].Value = model.SortID;
			parameters[11].Value = model.UserID;
			parameters[12].Value = model.IsShow;
			parameters[13].Value = model.IsDefault;

			DbHelperSQL.RunProcedure("UP_SystemTree_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}
		#endregion

		#region  ����һ������
		/// <summary>
		///  ����һ������
		/// </summary>
		public bool Update(GK2010.Model.SystemTree model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@TitleEn", SqlDbType.NVarChar,100),
					new SqlParameter("@Summary", SqlDbType.NVarChar,500),
					new SqlParameter("@Detail", SqlDbType.NText),
					new SqlParameter("@PictureID", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.NVarChar,300),
					new SqlParameter("@Path", SqlDbType.NVarChar,1000),
					new SqlParameter("@HasChild", SqlDbType.Int,4),
					new SqlParameter("@SortID", SqlDbType.Decimal,9),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@IsShow", SqlDbType.Int,4),
					new SqlParameter("@IsDefault", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ParentID;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.TitleEn;
			parameters[4].Value = model.Summary;
			parameters[5].Value = model.Detail;
			parameters[6].Value = model.PictureID;
			parameters[7].Value = model.Url;
			parameters[8].Value = model.Path;
			parameters[9].Value = model.HasChild;
			parameters[10].Value = model.SortID;
			parameters[11].Value = model.UserID;
			parameters[12].Value = model.IsShow;
			parameters[13].Value = model.IsDefault;

			DbHelperSQL.RunProcedure("UP_SystemTree_Update",parameters,out rowsAffected);
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

			DbHelperSQL.RunProcedure("UP_SystemTree_Delete",parameters,out rowsAffected);
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

			DataSet ds= DbHelperSQL.RunProcedure("UP_SystemTree_GetModel",parameters,"ds");
			return ds;
		}
		#endregion	
	

        #region �б�(����ҳ)
        public DataSet GetList(string Keywords, string Type)
        {
            SqlParameter[] parameters = {				
				new SqlParameter("@Keywords", SqlDbType.VarChar,50),
                new SqlParameter("@Type", SqlDbType.VarChar,50)			
				
			};
            parameters[0].Value = Keywords;
            parameters[1].Value = Type;
            DataSet ds = DbHelperSQL.RunProcedure("UP_SystemTree_GetList_ByCondition", parameters, "ds");
            return ds;
        }
        #endregion 	

        #region ��������

        #region �ж�Ȩ��
        public  bool CheckPermission(string Url)
        {
            int UserID = IntHelper.Parse(HttpContext.Current.User.Identity.Name, -1);
           
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@Url", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserID", SqlDbType.Int,4)
                                        };
            parameters[0].Value = Url;
            parameters[1].Value = UserID;

            int result = DbHelperSQL.RunProcedure("UP_SystemTree_CheckPermission", parameters, out rowsAffected);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion


        #endregion

        #endregion
    }
}

