using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GK2010.Utility;
namespace GK2010.DAL
{
	/// <summary>
	/// ���ݷ�����Library_Industry��
	/// </summary>
	public class Library_Industry
	{
		#region  ���캯��
		public Library_Industry()
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

			int result= DbHelperSQL.RunProcedure("UP_Library_Industry_Exists",parameters,out rowsAffected);
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
		public int Add(GK2010.Model.Library_Industry model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@TableName", SqlDbType.NVarChar,100),
					new SqlParameter("@TableID", SqlDbType.Int,4),
					new SqlParameter("@CategoryID", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.TableName;
			parameters[2].Value = model.TableID;
			parameters[3].Value = model.CategoryID;

			DbHelperSQL.RunProcedure("UP_Library_Industry_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}
		#endregion

		#region  ����һ������
		/// <summary>
		///  ����һ������
		/// </summary>
		public bool Update(GK2010.Model.Library_Industry model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@TableName", SqlDbType.NVarChar,100),
					new SqlParameter("@TableID", SqlDbType.Int,4),
					new SqlParameter("@CategoryID", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.TableName;
			parameters[2].Value = model.TableID;
			parameters[3].Value = model.CategoryID;

			DbHelperSQL.RunProcedure("UP_Library_Industry_Update",parameters,out rowsAffected);
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

			DbHelperSQL.RunProcedure("UP_Library_Industry_Delete",parameters,out rowsAffected);
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

			DataSet ds= DbHelperSQL.RunProcedure("UP_Library_Industry_GetModel",parameters,"ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_Library_Industry_GetList_ByCondition", parameters, "ds");
			return ds;
		}
		#endregion 


        #region  �б�(����ҳ)���ݱ����ͱ�ID

        /// <summary>
        /// �б�(����ҳ)���ݱ����ͱ�ID
        /// </summary>
        /// <param name="TableName">����</param>
        /// <param name="TableID">��ID</param>
        /// <returns></returns>
        public DataSet GetList(TableName TableName, int TableID)
        {
            SqlParameter[] parameters = {
				new SqlParameter("@TableName", SqlDbType.VarChar, 50),
				new SqlParameter("@TableID", SqlDbType.Int,4)
			};
            parameters[0].Value = TableName.ToString();
            parameters[1].Value = TableID;
            DataSet ds = DbHelperSQL.RunProcedure("UP_Library_Industry_GetList_ByTable", parameters, "ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_Library_Industry_GetList", parameters, "ds");
			totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
			return ds;
		}
		#endregion 

		#endregion  ��Ա����

        #region  ��������Ӧ����ҵ
        /// <summary>
        ///  ��������Ӧ����ҵ
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

            DbHelperSQL.RunProcedure("UP_Library_Industry_ADD_Batch", parameters, out rowsAffected);
            return rowsAffected > 0;
        }
        #endregion

        #region  ��ȡ���⣨���ݱ�����
        /// <summary>
        /// ��ȡ���⣨���ݱ�����
        /// </summary>
        /// <param name="TableName">����</param>
        /// <param name="TableID">��ID</param>
        /// <returns></returns>
        public string GetTitle(TableName TableName, int TableID)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@TableName", SqlDbType.NVarChar,50),
					new SqlParameter("@TableID", SqlDbType.Int,4)};
            parameters[0].Value = TableName.ToString();
            parameters[1].Value = TableID;

            DataSet ds = DbHelperSQL.RunProcedure("UP_Library_Industry_GetTitleByTable", parameters, "ds");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["RET"].ToString();
                }
            }
            return "";
        }
        #endregion
	}
}
