using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// ҵ���߼���MemberValid ��ժҪ˵����
	/// </summary>
	public class MemberValid
	{
		#region  ˽�б���
		private readonly GK2010.DAL.MemberValid dal=new GK2010.DAL.MemberValid();
		#endregion
		
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
			return dal.Exists(ID);
		}
		#endregion  �Ƿ���ڸü�¼

		#region  ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(GK2010.Model.MemberValid model)
		{
            if (model.ValidValue.Length > 0)
            {
                model.ValidValue = Utility.DEncryptHelper.DESEncrypt.Encrypt(model.ValidValue);
            }
			return dal.Add(model);
		}
		#endregion

		#region  ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(GK2010.Model.MemberValid model)
		{
            if (model.ValidValue.Length > 0)
            {
                model.ValidValue = Utility.DEncryptHelper.DESEncrypt.Encrypt(model.ValidValue);
            }
			return dal.Update(model);
		}
		#endregion

		#region  ɾ��һ������
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		#endregion

		#region  �õ�һ������ʵ��
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public GK2010.Model.MemberValid GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.MemberValid> models = DataTableToList(ds.Tables[0]);
			if (models.Count > 0)
			{
				return models[0];
			}
			else
			{
				return null;
			}
		}
		#endregion
		
		#region  �õ�һ������ʵ��(�ؼ���)
		/// <summary>
		/// �õ�һ������ʵ��(�ؼ���)
		/// </summary>
		public GK2010.Model.MemberValid GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.MemberValid> models = DataTableToList(ds.Tables[0]);
			if (models.Count > 0)
			{
				return models[0];
			}
			else
			{
				return null;
			}
		}
		#endregion
		
		#region ��ȡ����
		/// <summary>
		///  ��ȡ����
		/// </summary>
		public static string GetTitle(int ID)
		{
			GK2010.BLL.MemberValid bll = new GK2010.BLL.MemberValid();
			GK2010.Model.MemberValid model = bll.GetModel(ID);
			if (model != null)
			{
				return model.ActiveCode;
			}
			else
			{
				return "";
			}
		}
		#endregion
		

		#region  �õ�һ������ʵ�壬�ӻ�����
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public GK2010.Model.MemberValid GetModelByCache(int ID)
		{
			
			string CacheKey = "MemberValidModel-" + ID;
			object objModel = Utility.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Utility.ConfigHelper.GetConfigInt("ModelCache");
						Utility.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (GK2010.Model.MemberValid)objModel;
		}
		#endregion

		#region  �б�(����ҳ)
		/// <summary>
		/// �б�(����ҳ)
		/// </summary>
		public List<GK2010.Model.MemberValid> GetList(string Keywords, string Type)
		{
			DataSet ds = dal.GetList(Keywords,Type);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  �б�(����ҳ)��ȡTabel
		/// <summary>
		/// �б�(����ҳ)��ȡTabel
		/// </summary>
		public DataTable GetTable(string Keywords, string Type)
		{
			DataSet ds = dal.GetList(Keywords,Type);
			return ds.Tables[0];
		}
		#endregion

		#region  ��������б�
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<GK2010.Model.MemberValid> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  ת�������б�
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.MemberValid> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.MemberValid> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.MemberValid> modelList = new List<GK2010.Model.MemberValid>();
			GK2010.Model.MemberValid model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.MemberValid();
				if(dr["ID"].ToString()!="")
				{
					model.ID=int.Parse(dr["ID"].ToString());
				}
				if(dr["ValidType"].ToString()!="")
				{
					model.ValidType=int.Parse(dr["ValidType"].ToString());
				}
				model.ValidValue=dr["ValidValue"].ToString();
				if(dr["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(dr["UserID"].ToString());
				}
				model.ActiveCode=dr["ActiveCode"].ToString();
				if(dr["StartDate"].ToString()!="")
				{
					model.StartDate=long.Parse(dr["StartDate"].ToString());
				}
				if(dr["EndDate"].ToString()!="")
				{
					model.EndDate=long.Parse(dr["EndDate"].ToString());
				}
				modelList.Add(model);
			}
			return modelList;
		}
		#endregion

		#endregion  ��Ա����

        #region ��������

        #region �ۺϲ���(������ȡ������)
        /// <summary>
        /// �ۺϲ���(������ȡ������)
        /// </summary>
        /// <param name="UserID">�û����</param>
        /// <param name="ValidType">����|ȡ������</param>
        /// <param name="ObjectValue">ֵ</param>
        /// <param name="ActiveCode">������</param>
        /// <returns></returns>
        public bool Operator(int UserID, EnumSendType ValidType, string ObjectValue, string ActiveCode)
        {
            ObjectValue = Utility.DEncryptHelper.DESEncrypt.Encrypt(ObjectValue);//����
            return dal.Operator(UserID, ValidType,  ObjectValue, ActiveCode);
        }
        #endregion

        #region �������Ƿ����

        /// <summary>
        /// �������Ƿ����
        /// </summary>
        /// <param name="UserID">�û����</param>
        /// <param name="ValidType">����|ȡ������</param>
        /// <param name="ObjectValue">ֵ</param>
        /// <param name="ActiveCode">������</param>
        /// <returns></returns>
        public bool ActiveCodeExpired(int UserID, EnumSendType ValidType,  string ObjectValue, string ActiveCode)
        {
            ObjectValue = Utility.DEncryptHelper.DESEncrypt.Encrypt(ObjectValue);//����
            return dal.ActiveCodeExpired(UserID, ValidType,  ObjectValue, ActiveCode);
        }
        #endregion

        #endregion
	}
}

