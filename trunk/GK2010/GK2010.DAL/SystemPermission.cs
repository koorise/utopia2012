using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GK2010.Utility;
namespace GK2010.DAL
{
	/// <summary>
	/// ���ݷ�����SystemPermission��
	/// </summary>
	public class SystemPermission
	{
		#region  ���캯��
		public SystemPermission()
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

			int result= DbHelperSQL.RunProcedure("UP_SystemPermission_Exists",parameters,out rowsAffected);
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
		public int Add(GK2010.Model.SystemPermission model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@GroupID", SqlDbType.Int,4),
					new SqlParameter("@Permission", SqlDbType.NVarChar,100)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.GroupID;
			parameters[2].Value = model.Permission;

			DbHelperSQL.RunProcedure("UP_SystemPermission_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}
		#endregion

		#region  ����һ������
		/// <summary>
		///  ����һ������
		/// </summary>
		public bool Update(GK2010.Model.SystemPermission model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@GroupID", SqlDbType.Int,4),
					new SqlParameter("@Permission", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.GroupID;
			parameters[2].Value = model.Permission;

			DbHelperSQL.RunProcedure("UP_SystemPermission_Update",parameters,out rowsAffected);
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

			DbHelperSQL.RunProcedure("UP_SystemPermission_Delete",parameters,out rowsAffected);
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

			DataSet ds= DbHelperSQL.RunProcedure("UP_SystemPermission_GetModel",parameters,"ds");
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
            DataSet ds = DbHelperSQL.RunProcedure("UP_SystemPermission_GetList_ByCondition", parameters, "ds");
            return ds;
        }
        #endregion 			

		#endregion  ��Ա����

        #region  ��������

        #region  ���Ȩ��
        /// <summary>
        ///  ���Ȩ��
        /// </summary>
        public bool AddBatch(int GroupID, string strPermission)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@GroupID", SqlDbType.Int,4),
					new SqlParameter("@Permission", SqlDbType.NVarChar,4000)};
            parameters[0].Value = GroupID;
            parameters[1].Value = strPermission;

            DbHelperSQL.RunProcedure("UP_SystemPermission_ADD_Batch", parameters, out rowsAffected);
            return rowsAffected > 0;
        }
        #endregion

       

        #endregion  
	}
}

