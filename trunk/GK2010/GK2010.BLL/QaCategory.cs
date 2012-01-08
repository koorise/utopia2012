using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// 业务逻辑类QaCategory 的摘要说明。
	/// </summary>
	public class QaCategory
	{
		#region  私有变量
		private readonly GK2010.DAL.QaCategory dal=new GK2010.DAL.QaCategory();
		#endregion
		
		#region  构造函数
		public QaCategory()
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
		public int  Add(GK2010.Model.QaCategory model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.QaCategory model)
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
		public GK2010.Model.QaCategory GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.QaCategory> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.QaCategory GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.QaCategory> models = DataTableToList(ds.Tables[0]);
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
			GK2010.BLL.QaCategory bll = new GK2010.BLL.QaCategory();
			GK2010.Model.QaCategory model = bll.GetModel(ID);
			if (model != null)
			{
				return model.Title;
			}
			else
			{
				return "";
			}
		}
        public static string GetTitle(object ID)
        {
            return GetTitle(IntHelper.Parse(ID.ToString(), 0));
        }
		#endregion
		

		#region  得到一个对象实体，从缓存中
		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public GK2010.Model.QaCategory GetModelByCache(int ID)
		{
			
			string CacheKey = "QaCategoryModel-" + ID;
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
			return (GK2010.Model.QaCategory)objModel;
		}
		#endregion

		#region  列表(不分页)
		/// <summary>
		/// 列表(不分页)
		/// </summary>
		public List<GK2010.Model.QaCategory> GetList(string Keywords, string Type)
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

		#region  转换数据列表
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.QaCategory> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.QaCategory> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.QaCategory> modelList = new List<GK2010.Model.QaCategory>();
			GK2010.Model.QaCategory model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.QaCategory();
				if(dr["ID"].ToString()!="")
				{
					model.ID=int.Parse(dr["ID"].ToString());
				}
				if(dr["ParentID"].ToString()!="")
				{
					model.ParentID=int.Parse(dr["ParentID"].ToString());
				}
				model.Title=dr["Title"].ToString();
				model.TitleEn=dr["TitleEn"].ToString();
				model.Summary=dr["Summary"].ToString();
				model.Detail=dr["Detail"].ToString();
				if(dr["PictureID"].ToString()!="")
				{
					model.PictureID=int.Parse(dr["PictureID"].ToString());
				}
				model.Url=dr["Url"].ToString();
				model.Path=dr["Path"].ToString();
				if(dr["HasChild"].ToString()!="")
				{
					model.HasChild=int.Parse(dr["HasChild"].ToString());
				}
				if(dr["SortID"].ToString()!="")
				{
					model.SortID=decimal.Parse(dr["SortID"].ToString());
				}
				if(dr["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(dr["UserID"].ToString());
				}
				if(dr["IsShow"].ToString()!="")
				{
					model.IsShow=int.Parse(dr["IsShow"].ToString());
				}
				if(dr["IsDefault"].ToString()!="")
				{
					model.IsDefault=int.Parse(dr["IsDefault"].ToString());
				}
				modelList.Add(model);
			}
			return modelList;
		}
		#endregion

		#endregion  成员方法

        #region 其他方法

        #region 重新组合
        public List<GK2010.Model.QaCategory> GetListNew()
        {
            List<GK2010.Model.QaCategory> models_new = new List<GK2010.Model.QaCategory>();
            DataTable dt = dal.GetList("", "").Tables[0];
            List<GK2010.Model.QaCategory> models = DataTableToList(dt.Select("ParentID=0", "SortID ASC"));
            foreach (GK2010.Model.QaCategory model in models)
            {
                models_new.Add(model);
                GetListNew(model.ID, models_new, dt);
            }
            return models_new;
        }

        private void GetListNew(int ParentID, List<GK2010.Model.QaCategory> models_new, DataTable dt)
        {
            List<GK2010.Model.QaCategory> models = DataTableToList(dt.Select("ParentID=" + ParentID, "SortID ASC"));
            foreach (GK2010.Model.QaCategory model in models)
            {
                models_new.Add(model);
                GetListNew(model.ID, models_new, dt);
            }
        }
        #endregion

        #region 重新组合绑定dropdownlist用
        public List<GK2010.Model.QaCategory> GetListDropDownList(int CurrentID)
        {
            List<GK2010.Model.QaCategory> models_new = new List<GK2010.Model.QaCategory>();
            DataTable dt = dal.GetList("", "").Tables[0];
            List<GK2010.Model.QaCategory> models = DataTableToList(dt.Select("ParentID=0 and ID<>" + CurrentID + " and ParentID <>" + CurrentID, "SortID ASC"));

            foreach (GK2010.Model.QaCategory model in models)
            {
                model.Title = ">> " + model.Title;
                models_new.Add(model);
                GetListDropDownList(CurrentID, model.ID, models_new, dt);
            }
            return models_new;
        }

        private void GetListDropDownList(int CurrentID, int ParentID, List<GK2010.Model.QaCategory> models_new, DataTable dt)
        {
            //不包括：当前类别和以当前类别为父的类别
            List<GK2010.Model.QaCategory> models = DataTableToList(dt.Select("ParentID=" + ParentID + " and ID<>" + CurrentID + " and ParentID <>" + CurrentID, "SortID ASC"));
            foreach (GK2010.Model.QaCategory model in models)
            {
                int len = model.Path.Split(',').Length;
                if (len == 2)
                {
                    model.Title = "　|-  " + model.Title;
                }
                if (len == 3)
                {
                    model.Title = "　　|-  " + model.Title;
                }
                if (len == 4)
                {
                    model.Title = "　　　|-  " + model.Title;
                }
                if (len == 5)
                {
                    model.Title = "　　　　|-  " + model.Title;
                }
                models_new.Add(model);
                GetListDropDownList(CurrentID, model.ID, models_new, dt);
            }
        }
        #endregion

        #endregion
	}
}

