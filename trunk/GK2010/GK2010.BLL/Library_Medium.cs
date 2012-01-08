using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// ҵ���߼���Library_Medium ��ժҪ˵����
	/// </summary>
	public class Library_Medium
	{
		#region  ˽�б���
		private readonly GK2010.DAL.Library_Medium dal=new GK2010.DAL.Library_Medium();
		#endregion
		
		#region  ���캯��
		public Library_Medium()
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
		public int  Add(GK2010.Model.Library_Medium model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(GK2010.Model.Library_Medium model)
		{
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
		public GK2010.Model.Library_Medium GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.Library_Medium> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.Library_Medium GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.Library_Medium> models = DataTableToList(ds.Tables[0]);
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
		

		#region  �õ�һ������ʵ�壬�ӻ�����
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public GK2010.Model.Library_Medium GetModelByCache(int ID)
		{
			
			string CacheKey = "Library_MediumModel-" + ID;
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
			return (GK2010.Model.Library_Medium)objModel;
		}
		#endregion

		#region  �б�(����ҳ)
		/// <summary>
		/// �б�(����ҳ)
		/// </summary>
		public List<GK2010.Model.Library_Medium> GetList(string Keywords, string Type)
		{
			DataSet ds = dal.GetList(Keywords,Type);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion


        #region  �б�(����ҳ)
        /// <summary>
        /// �б�(����ҳ)
        /// </summary>
        public List<GK2010.Model.Library_Medium> GetList(TableName TableName, int TableID)
        {
            DataSet ds = dal.GetList(TableName, TableID);
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
		public List<GK2010.Model.Library_Medium> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  ת�������б�
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.Library_Medium> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.Library_Medium> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.Library_Medium> modelList = new List<GK2010.Model.Library_Medium>();
			GK2010.Model.Library_Medium model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.Library_Medium();
				if(dr["ID"].ToString()!="")
				{
					model.ID=int.Parse(dr["ID"].ToString());
				}
				model.TableName=dr["TableName"].ToString();
				if(dr["TableID"].ToString()!="")
				{
					model.TableID=int.Parse(dr["TableID"].ToString());
				}
				if(dr["CategoryID"].ToString()!="")
				{
					model.CategoryID=int.Parse(dr["CategoryID"].ToString());
				}
				modelList.Add(model);
			}
			return modelList;
		}
		#endregion

		#endregion  ��Ա����

        #region  �������Ӧ����ҵ
        /// <summary>
        ///  �������Ӧ����ҵ
        /// </summary>
        public bool AddBatch(TableName TableName, int TableID, string Select)
        {
            return dal.AddBatch(TableName, TableID, Select);
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
            return dal.GetTitle(TableName, TableID);
        }
        #endregion
	}
}

