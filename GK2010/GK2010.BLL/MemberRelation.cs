using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// 业务逻辑类MemberRelation 的摘要说明。
	/// </summary>
	public class MemberRelation
	{
		#region  私有变量
		private readonly GK2010.DAL.MemberRelation dal=new GK2010.DAL.MemberRelation();
		#endregion
		
		#region  构造函数
		public MemberRelation()
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
		public int  Add(GK2010.Model.MemberRelation model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.MemberRelation model)
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
		public GK2010.Model.MemberRelation GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.MemberRelation> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.MemberRelation GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.MemberRelation> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.MemberRelation GetModelByCache(int ID)
		{
			
			string CacheKey = "MemberRelationModel-" + ID;
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
			return (GK2010.Model.MemberRelation)objModel;
		}
		#endregion

		#region  列表(不分页)
		/// <summary>
		/// 列表(不分页)
		/// </summary>
		public List<GK2010.Model.MemberRelation> GetList(string Keywords, string Type)
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
		public List<GK2010.Model.MemberRelation> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  转换数据列表
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.MemberRelation> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.MemberRelation> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.MemberRelation> modelList = new List<GK2010.Model.MemberRelation>();
			GK2010.Model.MemberRelation model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.MemberRelation();
				if(dr["ID"].ToString()!="")
				{
					model.ID=int.Parse(dr["ID"].ToString());
				}
				if(dr["AdminID"].ToString()!="")
				{
					model.AdminID=int.Parse(dr["AdminID"].ToString());
				}
				if(dr["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(dr["UserID"].ToString());
				}
				modelList.Add(model);
			}
			return modelList;
		}
		#endregion

		#endregion  成员方法

        #region  批量添加管理员
        /// <summary>
        ///  批量添加管理员
        /// </summary>
        public bool AddBatch(int UserID,string Select)
        {
            return dal.AddBatch(UserID, Select);
        }
        #endregion
	}
}

