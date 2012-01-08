using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// 业务逻辑类ConfigCity 的摘要说明。
	/// </summary>
	public class ConfigCity
	{
		#region  私有变量
		private readonly GK2010.DAL.ConfigCity dal=new GK2010.DAL.ConfigCity();
		#endregion
		
		#region  构造函数
		public ConfigCity()
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
		public int  Add(GK2010.Model.ConfigCity model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.ConfigCity model)
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
		public GK2010.Model.ConfigCity GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.ConfigCity> models = DataTableToList(ds.Tables[0]);
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
		
		#region  得到一个对象实体(关键字)
		/// <summary>
		/// 得到一个对象实体(关键字)
		/// </summary>
		public GK2010.Model.ConfigCity GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.ConfigCity> models = DataTableToList(ds.Tables[0]);
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
		

		#region  得到一个对象实体，从缓存中
		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public GK2010.Model.ConfigCity GetModelByCache(int ID)
		{
			
			string CacheKey = "ConfigCityModel-" + ID;
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
			return (GK2010.Model.ConfigCity)objModel;
		}
		#endregion

		#region  列表(不分页)
		/// <summary>
		/// 列表(不分页)
		/// </summary>
		public List<GK2010.Model.ConfigCity> GetList(string Keywords, string Type)
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
		public List<GK2010.Model.ConfigCity> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  转换数据列表
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.ConfigCity> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.ConfigCity> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.ConfigCity> modelList = new List<GK2010.Model.ConfigCity>();
			GK2010.Model.ConfigCity model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.ConfigCity();
				if(dr["ID"].ToString()!="")
				{
					model.ID=int.Parse(dr["ID"].ToString());
				}
				model.ProvinceID=dr["ProvinceID"].ToString();
				model.CityID=dr["CityID"].ToString();
				model.CityName=dr["CityName"].ToString();
				model.CityEn=dr["CityEn"].ToString();
				model.CityCharFull=dr["CityCharFull"].ToString();
				model.CityCharSub=dr["CityCharSub"].ToString();
				model.CityCode=dr["CityCode"].ToString();
				if(dr["HotFlag"].ToString()!="")
				{
					model.HotFlag=int.Parse(dr["HotFlag"].ToString());
				}
				if(dr["HotSortID"].ToString()!="")
				{
					model.HotSortID=decimal.Parse(dr["HotSortID"].ToString());
				}
				if(dr["OpenFlag"].ToString()!="")
				{
					model.OpenFlag=int.Parse(dr["OpenFlag"].ToString());
				}
				model.WebUrl=dr["WebUrl"].ToString();
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

        #region 其他方法

        #region 根据IP获取所在城市(多个)
        /// <summary>
        /// 获取IP集合
        /// </summary>
        /// <returns></returns>
        public static List<Model.ConfigCity> GetIPCitys()
        {
            string CityID = "320100";//取不到时的默认城市

            //根据IP获得城市
            List<GK2010.Model.ConfigCity> models = new List<GK2010.Model.ConfigCity>();
            GK2010.BLL.ConfigCity bll = new GK2010.BLL.ConfigCity();
            models = bll.GetList(CityID, "CityID");
            return models;
        }
        #endregion

        #region 根据IP获取所在城市(单个)
        /// <summary>
        /// 获取单个IP
        /// </summary>
        /// <returns></returns>
        public static Model.ConfigCity GetIPCity()
        {
            List<GK2010.Model.ConfigCity> models = GetIPCitys();
            if (models.Count > 0)
                return models[0];
            else
                return null;
        }
        #endregion

        #region  获取城市名称
        public static string CityName(string CityID)
        {
            BLL.ConfigCity bll = new BLL.ConfigCity();
            List<GK2010.Model.ConfigCity> models = bll.GetList(CityID, "CityID");
            if (models.Count > 0)
            {
                return models[0].CityName;
            }
            else
            {
                return "";
            }
        }
        #endregion

        #endregion
	}
}

