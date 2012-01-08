using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;

namespace GK2010.BLL
{
	/// <summary>
	/// 业务逻辑类ConfigSeo 的摘要说明。
	/// </summary>
	public class ConfigSeo
	{
		#region  私有变量
		private readonly GK2010.DAL.ConfigSeo dal=new GK2010.DAL.ConfigSeo();
		#endregion
		
		#region  构造函数
		public ConfigSeo()
		{}
		#endregion		
		
		#region  成员方法

		#region  是否存在该记录
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}
		#endregion  是否存在该记录

		#region  增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(GK2010.Model.ConfigSeo model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.ConfigSeo model)
		{
			return dal.Update(model);
		}
		#endregion

		#region  删除一条数据
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		#endregion

		#region  得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
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

        #region  得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
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
		
		#region 获取标题
		/// <summary>
		///  获取标题
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

		#region  得到一个对象实体，从缓存中
		/// <summary>
		/// 得到一个对象实体，从缓存中。
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

		#region  列表(不分页)
		/// <summary>
		/// 列表(不分页)
		/// </summary>
		public List<GK2010.Model.ConfigSeo> GetList(string Keywords, string Type)
		{
			DataSet ds = dal.GetList(Keywords,Type);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  列表(不分页)获取Tabel
		/// <summary>
		/// 列表(不分页)获取Tabel
		/// </summary>
		public DataTable GetTable(string Keywords, string Type)
		{
			DataSet ds = dal.GetList(Keywords,Type);
			return ds.Tables[0];
		}
		#endregion

		#region  获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GK2010.Model.ConfigSeo> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  转换数据列表
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.ConfigSeo> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// 转换数据列表
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

		#endregion  成员方法

        #region 设置SEO
        /// <summary>
        /// 设置SEO
        /// </summary>
        /// <param name="Type">类型为表configseo表中的titleEn</param>
        /// <param name="modelSeo">用于替换的对象</param>
        /// <param name="SEOTitle">返回</param>
        /// <param name="SEOKeywords">返回</param>
        /// <param name="SEODetail">返回</param>
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
        /// 替换
        /// </summary>
        /// <param name="strOld"></param>
        /// <param name="modelSeo"></param>
        /// <returns></returns>
        private static string SEOReplace(string strOld, Model.SEO modelSeo)
        {
            //网站名称
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

            //若后台设置从原始表中有读取，则按原始表中的数据来
            strOld = strOld.Replace("$SEOTitle$", modelSeo.SEOTitle);
            strOld = strOld.Replace("$SEOKeywords$", modelSeo.SEOKeywords);
            strOld = strOld.Replace("$SEODescription$", modelSeo.SEODescription);

            

            return strOld;
        }
        #endregion
	}
}

