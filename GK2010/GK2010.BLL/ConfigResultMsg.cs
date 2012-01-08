using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// ҵ���߼���ConfigResultMsg ��ժҪ˵����
	/// </summary>
	public class ConfigResultMsg
	{
		#region  ˽�б���
		private readonly GK2010.DAL.ConfigResultMsg dal=new GK2010.DAL.ConfigResultMsg();
		#endregion
		
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
			return dal.Exists(ID);
		}
		#endregion  �Ƿ���ڸü�¼

		#region  ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(GK2010.Model.ConfigResultMsg model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(GK2010.Model.ConfigResultMsg model)
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
		public GK2010.Model.ConfigResultMsg GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.ConfigResultMsg> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.ConfigResultMsg GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.ConfigResultMsg> models = DataTableToList(ds.Tables[0]);
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
			GK2010.BLL.ConfigResultMsg bll = new GK2010.BLL.ConfigResultMsg();
			GK2010.Model.ConfigResultMsg model = bll.GetModel(ID);
			if (model != null)
			{
				return model.Title;
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
		public GK2010.Model.ConfigResultMsg GetModelByCache(int ID)
		{
			
			string CacheKey = "ConfigResultMsgModel-" + ID;
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
			return (GK2010.Model.ConfigResultMsg)objModel;
		}
		#endregion

		#region  �б�(����ҳ)
		/// <summary>
		/// �б�(����ҳ)
		/// </summary>
		public List<GK2010.Model.ConfigResultMsg> GetList(string Keywords, string Type)
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
		public List<GK2010.Model.ConfigResultMsg> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  ת�������б�
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.ConfigResultMsg> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.ConfigResultMsg> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.ConfigResultMsg> modelList = new List<GK2010.Model.ConfigResultMsg>();
			GK2010.Model.ConfigResultMsg model;
			foreach (DataRow dr in drs)
			{
                model = new GK2010.Model.ConfigResultMsg();
                if (dr["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dr["ID"].ToString());
                }
                model.Category = dr["Category"].ToString();
                model.Title = dr["Title"].ToString();
                model.TitleEn = dr["TitleEn"].ToString();
                model.Summary = dr["Summary"].ToString();
                model.Detail = dr["Detail"].ToString();
                if (dr["Type"].ToString() != "")
                {
                    model.Type = int.Parse(dr["Type"].ToString());
                }
                model.Url1Text = dr["Url1Text"].ToString();
                model.Url1 = dr["Url1"].ToString();
                model.Url2Text = dr["Url2Text"].ToString();
                model.Url2 = dr["Url2"].ToString();
                model.Url3Text = dr["Url3Text"].ToString();
                model.Url3 = dr["Url3"].ToString();
                modelList.Add(model);
			}
			return modelList;
		}
		#endregion

		#endregion  ��Ա����

        #region ��������

        /// <summary>
        /// ��ȡ��ϸ��Ϣ
        /// </summary>
        /// <param name="TitleEn">��Ϣƴ��</param>
        /// <returns></returns>
        public static string GetModel_Detail(string TitleEn)
        {
            GK2010.BLL.ConfigResultMsg bll = new GK2010.BLL.ConfigResultMsg();
            List<GK2010.Model.ConfigResultMsg> models = bll.GetList(TitleEn, "TitleEn");
            if (models.Count > 0)
            {
                Model.ConfigResultMsg model = models[0];
                if (model != null)
                {
                    return model.Detail;
                }
            }
            return "";
        }
	

        #endregion


	}
}

