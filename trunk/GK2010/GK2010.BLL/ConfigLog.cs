using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// 业务逻辑类ConfigLog 的摘要说明。
	/// </summary>
	public class ConfigLog
	{
		#region  私有变量
		private readonly GK2010.DAL.ConfigLog dal=new GK2010.DAL.ConfigLog();
		#endregion
		
		#region  构造函数
		public ConfigLog()
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
		public int  Add(GK2010.Model.ConfigLog model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.ConfigLog model)
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
		public GK2010.Model.ConfigLog GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.ConfigLog> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.ConfigLog GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.ConfigLog> models = DataTableToList(ds.Tables[0]);
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
			GK2010.BLL.ConfigLog bll = new GK2010.BLL.ConfigLog();
			GK2010.Model.ConfigLog model = bll.GetModel(ID);
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
		public GK2010.Model.ConfigLog GetModelByCache(int ID)
		{
			
			string CacheKey = "ConfigLogModel-" + ID;
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
			return (GK2010.Model.ConfigLog)objModel;
		}
		#endregion

		#region  列表(不分页)
		/// <summary>
		/// 列表(不分页)
		/// </summary>
		public List<GK2010.Model.ConfigLog> GetList(string Keywords, string Type)
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
		public List<GK2010.Model.ConfigLog> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  转换数据列表
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.ConfigLog> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.ConfigLog> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.ConfigLog> modelList = new List<GK2010.Model.ConfigLog>();
			GK2010.Model.ConfigLog model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.ConfigLog();
				if(dr["ID"].ToString()!="")
				{
					model.ID=int.Parse(dr["ID"].ToString());
				}
				model.Title=dr["Title"].ToString();
				model.Detail=dr["Detail"].ToString();
				if(dr["PostDate"].ToString()!="")
				{
					model.PostDate=long.Parse(dr["PostDate"].ToString());
				}
				if(dr["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(dr["UserID"].ToString());
				}
				if(dr["IsRead"].ToString()!="")
				{
					model.IsRead=int.Parse(dr["IsRead"].ToString());
				}
				if(dr["IsSolve"].ToString()!="")
				{
					model.IsSolve=int.Parse(dr["IsSolve"].ToString());
				}
				model.SolveDetail=dr["SolveDetail"].ToString();
				if(dr["SolveDate"].ToString()!="")
				{
					model.SolveDate=long.Parse(dr["SolveDate"].ToString());
				}
				if(dr["SolveUserID"].ToString()!="")
				{
					model.SolveUserID=int.Parse(dr["SolveUserID"].ToString());
				}
				modelList.Add(model);
			}
			return modelList;
		}
		#endregion

		#endregion  成员方法

        #region 其他方法

        #region 添加日志
        /// <summary>
        /// 快速记录日志
        /// </summary>
        /// <param name="Title">日志标题</param>
        /// <param name="Detail">日志内容</param>
        /// <param name="UserID">记录人</param>
        /// <returns></returns>
        public static bool Add(string Title, string Detail,int UserID)
        {
            BLL.ConfigLog bll = new BLL.ConfigLog();
            Model.ConfigLog model = new Model.ConfigLog();
            model.Title = Title;
            model.Detail = Detail;
            model.UserID = UserID;//发生日志的对象
            model.PostDate = DatetimeHelper.Now;
            model.IsRead = 0;
            model.IsSolve = 0;
            model.SolveDate = 0;
            model.SolveUserID = 0;
            model.SolveDetail = "";
            int ret = bll.Add(model);
            return ret > 0;
        }
        #endregion

        #endregion
	}
}

