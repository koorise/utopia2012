using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// 业务逻辑类Library_Tag 的摘要说明。
	/// </summary>
	public class Library_Tag
	{
		#region  私有变量
		private readonly GK2010.DAL.Library_Tag dal=new GK2010.DAL.Library_Tag();
		#endregion
		
		#region  构造函数
		public Library_Tag()
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
		public int  Add(GK2010.Model.Library_Tag model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.Library_Tag model)
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
		public GK2010.Model.Library_Tag GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.Library_Tag> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.Library_Tag GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.Library_Tag> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.Library_Tag GetModelByCache(int ID)
		{
			
			string CacheKey = "Library_TagModel-" + ID;
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
			return (GK2010.Model.Library_Tag)objModel;
		}
		#endregion

		#region  列表(不分页)
		/// <summary>
		/// 列表(不分页)
		/// </summary>
		public List<GK2010.Model.Library_Tag> GetList(string Keywords, string Type)
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
		public List<GK2010.Model.Library_Tag> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  转换数据列表
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.Library_Tag> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.Library_Tag> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.Library_Tag> modelList = new List<GK2010.Model.Library_Tag>();
			GK2010.Model.Library_Tag model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.Library_Tag();
				if(dr["ID"].ToString()!="")
				{
					model.ID=int.Parse(dr["ID"].ToString());
				}
				model.TableName=dr["TableName"].ToString();
				if(dr["TableID"].ToString()!="")
				{
					model.TableID=int.Parse(dr["TableID"].ToString());
				}
				model.Tag=dr["Tag"].ToString();
				model.TagEn=dr["TagEn"].ToString();
				modelList.Add(model);
			}
			return modelList;
		}
		#endregion

		#endregion  成员方法

        #region  列表(不分页)
        /// <summary>
        /// 列表(不分页)
        /// </summary>
        public List<GK2010.Model.Library_Tag> GetList(TableName TableName, int TableID)
        {
            DataSet ds = dal.GetList(TableName, TableID);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region  批量添加标签
        /// <summary>
        ///  批量添加应用行业
        /// </summary>
        public bool AddBatch(TableName TableName, int TableID, string Select)
        {
            return dal.AddBatch(TableName, TableID, Select);
        }
        #endregion

        #region  获取标题（根据表名）
        /// <summary>
        /// 获取标题（根据表名）
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="TableID">表ID</param>
        /// <returns></returns>
        public string GetTitle(TableName TableName, int TableID)
        {
            return dal.GetTitle(TableName, TableID);
        }
        #endregion
	}
}

