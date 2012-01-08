using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GK2010.Utility;
namespace GK2010.DAL
{
	/// <summary>
	/// ���ݷ�����ConfigResultMsg��
	/// </summary>
	public class ConfigResultMsg
	{
		#region  ���캯��
		public ConfigResultMsg()
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

			int result= DbHelperSQL.RunProcedure("UP_ConfigResultMsg_Exists",parameters,out rowsAffected);
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
		public int Add(GK2010.Model.ConfigResultMsg model)
		{
			int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Category", SqlDbType.NVarChar,100),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@TitleEn", SqlDbType.NVarChar,100),
					new SqlParameter("@Summary", SqlDbType.NVarChar,1000),
					new SqlParameter("@Detail", SqlDbType.NText),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@Url1Text", SqlDbType.NVarChar,100),
					new SqlParameter("@Url1", SqlDbType.NVarChar,300),
					new SqlParameter("@Url2Text", SqlDbType.Char,100),
					new SqlParameter("@Url2", SqlDbType.NVarChar,300),
					new SqlParameter("@Url3Text", SqlDbType.NVarChar,100),
					new SqlParameter("@Url3", SqlDbType.NVarChar,300)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.Category;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.TitleEn;
            parameters[4].Value = model.Summary;
            parameters[5].Value = model.Detail;
            parameters[6].Value = model.Type;
            parameters[7].Value = model.Url1Text;
            parameters[8].Value = model.Url1;
            parameters[9].Value = model.Url2Text;
            parameters[10].Value = model.Url2;
            parameters[11].Value = model.Url3Text;
            parameters[12].Value = model.Url3;

			DbHelperSQL.RunProcedure("UP_ConfigResultMsg_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}
		#endregion

		#region  ����һ������
		/// <summary>
		///  ����һ������
		/// </summary>
		public bool Update(GK2010.Model.ConfigResultMsg model)
		{
			int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Category", SqlDbType.NVarChar,100),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@TitleEn", SqlDbType.NVarChar,100),
					new SqlParameter("@Summary", SqlDbType.NVarChar,1000),
					new SqlParameter("@Detail", SqlDbType.NText),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@Url1Text", SqlDbType.NVarChar,100),
					new SqlParameter("@Url1", SqlDbType.NVarChar,300),
					new SqlParameter("@Url2Text", SqlDbType.Char,100),
					new SqlParameter("@Url2", SqlDbType.NVarChar,300),
					new SqlParameter("@Url3Text", SqlDbType.NVarChar,100),
					new SqlParameter("@Url3", SqlDbType.NVarChar,300)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Category;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.TitleEn;
            parameters[4].Value = model.Summary;
            parameters[5].Value = model.Detail;
            parameters[6].Value = model.Type;
            parameters[7].Value = model.Url1Text;
            parameters[8].Value = model.Url1;
            parameters[9].Value = model.Url2Text;
            parameters[10].Value = model.Url2;
            parameters[11].Value = model.Url3Text;
            parameters[12].Value = model.Url3;

			DbHelperSQL.RunProcedure("UP_ConfigResultMsg_Update",parameters,out rowsAffected);
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

			DbHelperSQL.RunProcedure("UP_ConfigResultMsg_Delete",parameters,out rowsAffected);
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

			DataSet ds= DbHelperSQL.RunProcedure("UP_ConfigResultMsg_GetModel",parameters,"ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_ConfigResultMsg_GetList_ByCondition", parameters, "ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_ConfigResultMsg_GetList", parameters, "ds");
			totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
			return ds;
		}
		#endregion 

		#endregion  ��Ա����
	}
}

