using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// ҵ���߼���ConfigProvince ��ժҪ˵����
	/// </summary>
	public class ConfigProvince
	{
		#region  ˽�б���
		private readonly GK2010.DAL.ConfigProvince dal=new GK2010.DAL.ConfigProvince();
		#endregion
		
		#region  ���캯��
		public ConfigProvince()
		{}
		#endregion		
		
		#region  ��Ա����

		#region  �Ƿ���ڸü�¼
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string ProvinceID,int ID)
		{
			return dal.Exists(ProvinceID,ID);
		}
		#endregion  �Ƿ���ڸü�¼

		#region  ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(GK2010.Model.ConfigProvince model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(GK2010.Model.ConfigProvince model)
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
		public GK2010.Model.ConfigProvince GetModel(int ID)
		{
            DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.ConfigProvince> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.ConfigProvince GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.ConfigProvince> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.ConfigProvince GetModelByCache(int ID)
		{
			
			string CacheKey = "ConfigProvinceModel-" + ID;
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
			return (GK2010.Model.ConfigProvince)objModel;
		}
		#endregion

		#region  �б�(����ҳ)
		/// <summary>
		/// �б�(����ҳ)
		/// </summary>
		public List<GK2010.Model.ConfigProvince> GetList(string Keywords, string Type)
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
		public List<GK2010.Model.ConfigProvince> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  ת�������б�
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.ConfigProvince> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.ConfigProvince> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.ConfigProvince> modelList = new List<GK2010.Model.ConfigProvince>();
			GK2010.Model.ConfigProvince model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.ConfigProvince();
				if(dr["ID"].ToString()!="")
				{
					model.ID=int.Parse(dr["ID"].ToString());
				}
				model.ProvinceID=dr["ProvinceID"].ToString();
				model.ProvinceName=dr["ProvinceName"].ToString();
				model.ProvinceEn=dr["ProvinceEn"].ToString();
				if(dr["SortID"].ToString()!="")
				{
					model.SortID=decimal.Parse(dr["SortID"].ToString());
				}
				modelList.Add(model);
			}
			return modelList;
		}
		#endregion

		#endregion  ��Ա����

        #region ��������

        #region  ��ȡʡ������     
        /// <summary>
        /// ��ȡʡ������
        /// </summary>
        /// <param name="ProvinceID">ʡ�ݱ��</param>
        /// <returns></returns>
        public static string ProvinceName(string ProvinceID)
        {
            BLL.ConfigProvince bll = new BLL.ConfigProvince();
            List<GK2010.Model.ConfigProvince> models = bll.GetList(ProvinceID, "ProvinceID");
            if (models.Count > 0)
            {
                return models[0].ProvinceName;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// ��ȡʡ������
        /// </summary>
        /// <param name="ProvinceID">ʡ�ݱ��</param>
        /// <returns></returns>
        public static string ProvinceName(object ProvinceID)
        {
           return ProvinceName( ProvinceID.ToString());
        }
        #endregion

        #endregion
	}
}

