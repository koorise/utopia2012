using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GK2010.Utility;
namespace GK2010.DAL
{
	/// <summary>
	/// ���ݷ�����MemberValid��
	/// </summary>
	public class MemberValid
	{
		#region  ���캯��
		public MemberValid()
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

			int result= DbHelperSQL.RunProcedure("UP_MemberValid_Exists",parameters,out rowsAffected);
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
		public int Add(GK2010.Model.MemberValid model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ValidType", SqlDbType.Int,4),
					new SqlParameter("@ValidValue", SqlDbType.NVarChar,200),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@ActiveCode", SqlDbType.NVarChar,100),
					new SqlParameter("@StartDate", SqlDbType.BigInt,8),
					new SqlParameter("@EndDate", SqlDbType.BigInt,8)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.ValidType;
			parameters[2].Value = model.ValidValue;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.ActiveCode;
			parameters[5].Value = model.StartDate;
			parameters[6].Value = model.EndDate;

			DbHelperSQL.RunProcedure("UP_MemberValid_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}
		#endregion

		#region  ����һ������
		/// <summary>
		///  ����һ������
		/// </summary>
		public bool Update(GK2010.Model.MemberValid model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ValidType", SqlDbType.Int,4),
					new SqlParameter("@ValidValue", SqlDbType.NVarChar,200),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@ActiveCode", SqlDbType.NVarChar,100),
					new SqlParameter("@StartDate", SqlDbType.BigInt,8),
					new SqlParameter("@EndDate", SqlDbType.BigInt,8)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ValidType;
			parameters[2].Value = model.ValidValue;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.ActiveCode;
			parameters[5].Value = model.StartDate;
			parameters[6].Value = model.EndDate;

			DbHelperSQL.RunProcedure("UP_MemberValid_Update",parameters,out rowsAffected);
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

			DbHelperSQL.RunProcedure("UP_MemberValid_Delete",parameters,out rowsAffected);
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

			DataSet ds= DbHelperSQL.RunProcedure("UP_MemberValid_GetModel",parameters,"ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_MemberValid_GetList_ByCondition", parameters, "ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_MemberValid_GetList", parameters, "ds");
			totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
			return ds;
		}
		#endregion 

		#endregion  ��Ա����

        #region �ۺϲ���(������ȡ������)

        /// <summary>
        /// �ۺϲ���(������ȡ������)
        /// </summary>
        /// <param name="UserID">�û����</param>
        /// <param name="ValidType">����|ȡ������</param>
        /// <param name="ValidObject">�ֻ�|����</param>
        /// <param name="ObjectValue">ֵ</param>
        /// <param name="ActiveCode">������</param>
        /// <returns></returns>
        public bool Operator(int UserID, EnumSendType ValidType, string ValidValue, string ActiveCode)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                            new SqlParameter("@UserID", SqlDbType.Int,4),
                                            new SqlParameter("@ValidType", SqlDbType.Int,4),
											new SqlParameter("@ValidValue", SqlDbType.NVarChar,200),
											new SqlParameter("@ActiveCode", SqlDbType.NVarChar,100),
                                            new SqlParameter("@Date", SqlDbType.BigInt,4)
										};
            parameters[0].Value = UserID;
            parameters[1].Value = ValidType;
            parameters[2].Value = ValidValue;
            parameters[3].Value = ActiveCode;
            parameters[4].Value = DatetimeHelper.Now;

            int result = DbHelperSQL.RunProcedure("UP_MemberValid_Operator", parameters, out rowsAffected);
            return result == 1;
        }
        #endregion

        #region �������Ƿ����

        /// <summary>
        /// �������Ƿ����
        /// </summary>
        /// <param name="UserID">�û����</param>
        /// <param name="ValidType">����|ȡ������</param>
        /// <param name="ValidObject">�ֻ�|����</param>
        /// <param name="ObjectValue">ֵ</param>
        /// <param name="ActiveCode">������</param>
        /// <returns></returns>
        public bool ActiveCodeExpired(int UserID, EnumSendType ValidType, string ValidValue, string ActiveCode)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                            new SqlParameter("@UserID", SqlDbType.Int,4),
                                            new SqlParameter("@ValidType", SqlDbType.Int,4),
											new SqlParameter("@ValidValue", SqlDbType.NVarChar,200),
											new SqlParameter("@ActiveCode", SqlDbType.NVarChar,100),
                                            new SqlParameter("@Date", SqlDbType.BigInt,4)
										};
            parameters[0].Value = UserID;
            parameters[1].Value = ValidType;
            parameters[2].Value = ValidValue;
            parameters[3].Value = ActiveCode;
            parameters[4].Value = DatetimeHelper.Now;

            int result = DbHelperSQL.RunProcedure("UP_MemberValid_ActiveCodeExpired", parameters, out rowsAffected);
            return result == 1;
        }
        #endregion  
	}
}

