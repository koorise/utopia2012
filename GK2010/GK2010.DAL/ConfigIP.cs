using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GK2010.Utility;
namespace GK2010.DAL
{
	/// <summary>
	/// ���ݷ�����ConfigIP��
	/// </summary>
	public class ConfigIP
	{
		#region  ���캯��
		public ConfigIP()
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

			int result= DbHelperSQL.RunProcedure("UP_ConfigIP_Exists",parameters,out rowsAffected);
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
		public int Add(GK2010.Model.ConfigIP model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@IP_Dec1", SqlDbType.Decimal,9),
					new SqlParameter("@IP_Dec2", SqlDbType.Decimal,9),
					new SqlParameter("@IP_Varchar1", SqlDbType.VarChar,50),
					new SqlParameter("@IP_Varchar2", SqlDbType.VarChar,50),
					new SqlParameter("@Country", SqlDbType.VarChar,100),
					new SqlParameter("@Province", SqlDbType.VarChar,100),
					new SqlParameter("@City", SqlDbType.VarChar,100)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.IP_Dec1;
			parameters[2].Value = model.IP_Dec2;
			parameters[3].Value = model.IP_Varchar1;
			parameters[4].Value = model.IP_Varchar2;
			parameters[5].Value = model.Country;
			parameters[6].Value = model.Province;
			parameters[7].Value = model.City;

			DbHelperSQL.RunProcedure("UP_ConfigIP_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}
		#endregion

		#region  ����һ������
		/// <summary>
		///  ����һ������
		/// </summary>
		public bool Update(GK2010.Model.ConfigIP model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@IP_Dec1", SqlDbType.Decimal,9),
					new SqlParameter("@IP_Dec2", SqlDbType.Decimal,9),
					new SqlParameter("@IP_Varchar1", SqlDbType.VarChar,50),
					new SqlParameter("@IP_Varchar2", SqlDbType.VarChar,50),
					new SqlParameter("@Country", SqlDbType.VarChar,100),
					new SqlParameter("@Province", SqlDbType.VarChar,100),
					new SqlParameter("@City", SqlDbType.VarChar,100)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.IP_Dec1;
			parameters[2].Value = model.IP_Dec2;
			parameters[3].Value = model.IP_Varchar1;
			parameters[4].Value = model.IP_Varchar2;
			parameters[5].Value = model.Country;
			parameters[6].Value = model.Province;
			parameters[7].Value = model.City;

			DbHelperSQL.RunProcedure("UP_ConfigIP_Update",parameters,out rowsAffected);
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

			DbHelperSQL.RunProcedure("UP_ConfigIP_Delete",parameters,out rowsAffected);
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

			DataSet ds= DbHelperSQL.RunProcedure("UP_ConfigIP_GetModel",parameters,"ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_ConfigIP_GetList_ByCondition", parameters, "ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_ConfigIP_GetList", parameters, "ds");
			totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
			return ds;
		}
		#endregion 

		#endregion  ��Ա����
	}
}

