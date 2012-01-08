using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// 业务逻辑类ConfigResultMsg 的摘要说明。
	/// </summary>
	public class ConfigResultMsg
	{
		#region  私有变量
		private readonly GK2010.DAL.ConfigResultMsg dal=new GK2010.DAL.ConfigResultMsg();
		#endregion
		
		#region  构造函数
		public ConfigResultMsg()
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
		public int  Add(GK2010.Model.ConfigResultMsg model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.ConfigResultMsg model)
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
		
		#region  得到一个对象实体(关键字)
		/// <summary>
		/// 得到一个对象实体(关键字)
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
		
		#region 获取标题
		/// <summary>
		///  获取标题
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

		#region  得到一个对象实体，从缓存中
		/// <summary>
		/// 得到一个对象实体，从缓存中。
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

		#region  列表(不分页)
		/// <summary>
		/// 列表(不分页)
		/// </summary>
		public List<GK2010.Model.ConfigResultMsg> GetList(string Keywords, string Type)
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
		public List<GK2010.Model.ConfigResultMsg> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  转换数据列表
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.ConfigResultMsg> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// 转换数据列表
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

		#endregion  成员方法

        #region 其他方法

        /// <summary>
        /// 获取详细信息
        /// </summary>
        /// <param name="TitleEn">信息拼音</param>
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

