using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// 业务逻辑类ProductPartsCache 的摘要说明。
	/// </summary>
	public class ProductPartsCache
	{
		#region  私有变量
		private readonly GK2010.DAL.ProductPartsCache dal=new GK2010.DAL.ProductPartsCache();
		#endregion
		
		#region  构造函数
		public ProductPartsCache()
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
		public int  Add(GK2010.Model.ProductPartsCache model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.ProductPartsCache model)
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

        #region  根据购物车中获得的产品部件快照编号删除数据
        public bool DeleteByProductPartsCacheID(long ID)
        {
            return dal.DeleteByProductPartsCacheID(ID);
        }
        #endregion

		#region  得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GK2010.Model.ProductPartsCache GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.ProductPartsCache> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.ProductPartsCache GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.ProductPartsCache> models = DataTableToList(ds.Tables[0]);
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
			GK2010.BLL.ProductPartsCache bll = new GK2010.BLL.ProductPartsCache();
			GK2010.Model.ProductPartsCache model = bll.GetModel(ID);
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

        #region 根据产品快照编号和用户id进行查询
        public Model.ProductPartsCache GetModelByProductPartCacheIDAndUserID(long productPartCacheID, int userID) {
            DataSet ds = dal.GetModelByProductPartCacheIDAndUserID(productPartCacheID,userID);
            List<GK2010.Model.ProductPartsCache> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.ProductPartsCache GetModelByCache(int ID)
		{
			
			string CacheKey = "ProductPartsCacheModel-" + ID;
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
			return (GK2010.Model.ProductPartsCache)objModel;
		}
		#endregion

		#region  列表(不分页)
		/// <summary>
		/// 列表(不分页)
		/// </summary>
		public List<GK2010.Model.ProductPartsCache> GetList(string Keywords, string Type)
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
		public List<GK2010.Model.ProductPartsCache> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  转换数据列表
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.ProductPartsCache> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.ProductPartsCache> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.ProductPartsCache> modelList = new List<GK2010.Model.ProductPartsCache>();
			GK2010.Model.ProductPartsCache model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.ProductPartsCache();
				if(dr["ID"].ToString()!="")
				{
					model.ID=int.Parse(dr["ID"].ToString());
				}
				if(dr["CacheID"].ToString()!="")
				{
					model.CacheID=long.Parse(dr["CacheID"].ToString());
				}
				if(dr["OldID"].ToString()!="")
				{
					model.OldID=int.Parse(dr["OldID"].ToString());
				}
				if(dr["ProductCatchID"].ToString()!="")
				{
					model.ProductCatchID=long.Parse(dr["ProductCatchID"].ToString());
				}
				if(dr["RootID"].ToString()!="")
				{
					model.RootID=int.Parse(dr["RootID"].ToString());
				}
				if(dr["CategoryID"].ToString()!="")
				{
					model.CategoryID=int.Parse(dr["CategoryID"].ToString());
				}
				model.CategoryPath=dr["CategoryPath"].ToString();
				model.Title=dr["Title"].ToString();
				model.TitleEn=dr["TitleEn"].ToString();
				model.Summary=dr["Summary"].ToString();
				model.Detail=dr["Detail"].ToString();
				if(dr["PictureID"].ToString()!="")
				{
					model.PictureID=int.Parse(dr["PictureID"].ToString());
				}
				model.PictureSmall=dr["PictureSmall"].ToString();
				model.PictureNormal=dr["PictureNormal"].ToString();
				model.PictureBig=dr["PictureBig"].ToString();
				if(dr["SortID"].ToString()!="")
				{
					model.SortID=decimal.Parse(dr["SortID"].ToString());
				}
				if(dr["PostDate"].ToString()!="")
				{
					model.PostDate=long.Parse(dr["PostDate"].ToString());
				}
				if(dr["PostUserID"].ToString()!="")
				{
					model.PostUserID=int.Parse(dr["PostUserID"].ToString());
				}
				if(dr["ShowFlag"].ToString()!="")
				{
					model.ShowFlag=int.Parse(dr["ShowFlag"].ToString());
				}
				if(dr["DefaultFlag"].ToString()!="")
				{
					model.DefaultFlag=int.Parse(dr["DefaultFlag"].ToString());
				}
				if(dr["AttachmentFlag"].ToString()!="")
				{
					model.AttachmentFlag=int.Parse(dr["AttachmentFlag"].ToString());
				}
				if(dr["Flag"].ToString()!="")
				{
					model.Flag=int.Parse(dr["Flag"].ToString());
				}
				modelList.Add(model);
			}
			return modelList;
		}
		#endregion

		#endregion  成员方法
	}
}

