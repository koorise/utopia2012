using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;

namespace GK2010.BLL
{
	/// <summary>
	/// ҵ���߼���ConfigSeo ��ժҪ˵����
	/// </summary>
	public class ConfigSeo
	{
		#region  ˽�б���
		private readonly GK2010.DAL.ConfigSeo dal=new GK2010.DAL.ConfigSeo();
		#endregion
		
		#region  ���캯��
		public ConfigSeo()
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
		public int  Add(GK2010.Model.ConfigSeo model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(GK2010.Model.ConfigSeo model)
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
		public GK2010.Model.ConfigSeo GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.ConfigSeo> models = DataTableToList(ds.Tables[0]);
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

        #region  �õ�һ������ʵ��
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public GK2010.Model.ConfigSeo GetModel(string TitleEn)
        {
            DataSet ds = dal.GetModel(TitleEn);
            List<GK2010.Model.ConfigSeo> models = DataTableToList(ds.Tables[0]);
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
			GK2010.BLL.ConfigSeo bll = new GK2010.BLL.ConfigSeo();
			GK2010.Model.ConfigSeo model = bll.GetModel(ID);
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
		public GK2010.Model.ConfigSeo GetModelByCache(int ID)
		{
			
			string CacheKey = "ConfigSeoModel-" + ID;
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
			return (GK2010.Model.ConfigSeo)objModel;
		}
		#endregion

		#region  �б�(����ҳ)
		/// <summary>
		/// �б�(����ҳ)
		/// </summary>
		public List<GK2010.Model.ConfigSeo> GetList(string Keywords, string Type)
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
		public List<GK2010.Model.ConfigSeo> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  ת�������б�
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.ConfigSeo> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.ConfigSeo> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.ConfigSeo> modelList = new List<GK2010.Model.ConfigSeo>();
			GK2010.Model.ConfigSeo model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.ConfigSeo();
				if(dr["ID"].ToString()!="")
				{
					model.ID=int.Parse(dr["ID"].ToString());
				}
				model.Title=dr["Title"].ToString();
				model.TitleEn=dr["TitleEn"].ToString();
				model.SeoTitle=dr["SeoTitle"].ToString();
				model.SeoKeywords=dr["SeoKeywords"].ToString();
				model.SeoDescription=dr["SeoDescription"].ToString();
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

        #region ����SEO
        /// <summary>
        /// ����SEO
        /// </summary>
        /// <param name="Type">����Ϊ��configseo���е�titleEn</param>
        /// <param name="modelSeo">�����滻�Ķ���</param>
        /// <param name="SEOTitle">����</param>
        /// <param name="SEOKeywords">����</param>
        /// <param name="SEODetail">����</param>
        public static void Set(string Type,Model.SEO modelSeo, out string SEOTitle,out string SEOKeywords,out string SEODetail )
        {
            SEOTitle = "";
            SEOKeywords = "";
            SEODetail = "";
           
            BLL.ConfigSeo bllConfigSeo = new GK2010.BLL.ConfigSeo();
            Model.ConfigSeo modelConfigSeo = bllConfigSeo.GetModel(Type);
            if(modelConfigSeo != null)
            {
                SEOTitle = SEOReplace(modelConfigSeo.SeoTitle, modelSeo);
                SEOKeywords = SEOReplace(modelConfigSeo.SeoKeywords, modelSeo);
                SEODetail = SEOReplace(modelConfigSeo.SeoDescription, modelSeo);
            }
        }
        /// <summary>
        /// �滻
        /// </summary>
        /// <param name="strOld"></param>
        /// <param name="modelSeo"></param>
        /// <returns></returns>
        private static string SEOReplace(string strOld, Model.SEO modelSeo)
        {
            //��վ����
            string WebSiteTitle = "";
            GK2010.BLL.Config bll = new GK2010.BLL.Config();
            GK2010.Model.Config model = bll.GetModel();
            if (model != null)
            {
                WebSiteTitle =  model.WebName;
            }

            strOld = strOld.Replace("$DetailTitle$", modelSeo.DetailTitle);
            strOld = strOld.Replace("$CategoryTitle$", modelSeo.CategoryTitle);
            strOld = strOld.Replace("$Tags$", modelSeo.Tags);
            strOld = strOld.Replace("$WebSiteTitle$", WebSiteTitle);

            //����̨���ô�ԭʼ�����ж�ȡ����ԭʼ���е�������
            strOld = strOld.Replace("$SEOTitle$", modelSeo.SEOTitle);
            strOld = strOld.Replace("$SEOKeywords$", modelSeo.SEOKeywords);
            strOld = strOld.Replace("$SEODescription$", modelSeo.SEODescription);

            

            return strOld;
        }
        #endregion
	}
}

