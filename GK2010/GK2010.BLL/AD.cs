using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// 业务逻辑类AD 的摘要说明。
	/// </summary>
	public class AD
	{
		#region  私有变量
		private readonly GK2010.DAL.AD dal=new GK2010.DAL.AD();
		#endregion
		
		#region  构造函数
		public AD()
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
		public int  Add(GK2010.Model.AD model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.AD model)
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
		public GK2010.Model.AD GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.AD> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.AD GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.AD> models = DataTableToList(ds.Tables[0]);
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
			GK2010.BLL.AD bll = new GK2010.BLL.AD();
			GK2010.Model.AD model = bll.GetModel(ID);
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
		public GK2010.Model.AD GetModelByCache(int ID)
		{
			
			string CacheKey = "ADModel-" + ID;
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
			return (GK2010.Model.AD)objModel;
		}
		#endregion

		#region  列表(不分页)
		/// <summary>
		/// 列表(不分页)
		/// </summary>
		public List<GK2010.Model.AD> GetList(string Keywords, string Type)
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
		public List<GK2010.Model.AD> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  转换数据列表
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.AD> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.AD> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.AD> modelList = new List<GK2010.Model.AD>();
			GK2010.Model.AD model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.AD();
				if(dr["ID"].ToString()!="")
				{
					model.ID=int.Parse(dr["ID"].ToString());
				}
				if(dr["CategoryID"].ToString()!="")
				{
					model.CategoryID=int.Parse(dr["CategoryID"].ToString());
				}
				model.Title=dr["Title"].ToString();
				model.TitleEn=dr["TitleEn"].ToString();
				model.Author=dr["Author"].ToString();
				model.Source=dr["Source"].ToString();
				model.Summary=dr["Summary"].ToString();
				model.Detail=dr["Detail"].ToString();
				model.Tags=dr["Tags"].ToString();
				if(dr["Hits"].ToString()!="")
				{
					model.Hits=int.Parse(dr["Hits"].ToString());
				}
				model.Path=dr["Path"].ToString();
				model.Url=dr["Url"].ToString();
				if(dr["PictureID"].ToString()!="")
				{
					model.PictureID=int.Parse(dr["PictureID"].ToString());
				}
				model.PictureSmall=dr["PictureSmall"].ToString();
				model.PictureNormal=dr["PictureNormal"].ToString();
				model.PictureBig=dr["PictureBig"].ToString();
				if(dr["IndexFlag"].ToString()!="")
				{
					model.IndexFlag=int.Parse(dr["IndexFlag"].ToString());
				}
				if(dr["IndexSortID"].ToString()!="")
				{
					model.IndexSortID=decimal.Parse(dr["IndexSortID"].ToString());
				}
				if(dr["CommendFlag"].ToString()!="")
				{
					model.CommendFlag=int.Parse(dr["CommendFlag"].ToString());
				}
				if(dr["CommendSortID"].ToString()!="")
				{
					model.CommendSortID=decimal.Parse(dr["CommendSortID"].ToString());
				}
				if(dr["HotFlag"].ToString()!="")
				{
					model.HotFlag=int.Parse(dr["HotFlag"].ToString());
				}
				if(dr["HotSortID"].ToString()!="")
				{
					model.HotSortID=decimal.Parse(dr["HotSortID"].ToString());
				}
				if(dr["ChannelFlag"].ToString()!="")
				{
					model.ChannelFlag=int.Parse(dr["ChannelFlag"].ToString());
				}
				if(dr["ChannelSortID"].ToString()!="")
				{
					model.ChannelSortID=decimal.Parse(dr["ChannelSortID"].ToString());
				}
				if(dr["CategoryFlag"].ToString()!="")
				{
					model.CategoryFlag=int.Parse(dr["CategoryFlag"].ToString());
				}
				if(dr["CategorySortID"].ToString()!="")
				{
					model.CategorySortID=decimal.Parse(dr["CategorySortID"].ToString());
				}
				if(dr["SortID"].ToString()!="")
				{
					model.SortID=decimal.Parse(dr["SortID"].ToString());
				}
				model.SEOTitle=dr["SEOTitle"].ToString();
				model.SEOKeywords=dr["SEOKeywords"].ToString();
				model.SEODescription=dr["SEODescription"].ToString();
				if(dr["ShowFlag"].ToString()!="")
				{
					model.ShowFlag=int.Parse(dr["ShowFlag"].ToString());
				}
				if(dr["CheckFlag"].ToString()!="")
				{
					model.CheckFlag=int.Parse(dr["CheckFlag"].ToString());
				}
				if(dr["CheckDate"].ToString()!="")
				{
					model.CheckDate=long.Parse(dr["CheckDate"].ToString());
				}
				if(dr["CheckUserID"].ToString()!="")
				{
					model.CheckUserID=int.Parse(dr["CheckUserID"].ToString());
				}
				if(dr["PostDate"].ToString()!="")
				{
					model.PostDate=long.Parse(dr["PostDate"].ToString());
				}
				if(dr["PostUserID"].ToString()!="")
				{
					model.PostUserID=int.Parse(dr["PostUserID"].ToString());
				}
				if(dr["EditDate"].ToString()!="")
				{
					model.EditDate=long.Parse(dr["EditDate"].ToString());
				}
				if(dr["EditUserID"].ToString()!="")
				{
					model.EditUserID=int.Parse(dr["EditUserID"].ToString());
				}
				if(dr["DelDate"].ToString()!="")
				{
					model.DelDate=long.Parse(dr["DelDate"].ToString());
				}
				if(dr["DelUserID"].ToString()!="")
				{
					model.DelUserID=int.Parse(dr["DelUserID"].ToString());
				}
				if(dr["MemberFlag"].ToString()!="")
				{
					model.MemberFlag=int.Parse(dr["MemberFlag"].ToString());
				}
				modelList.Add(model);
			}
			return modelList;
		}
		#endregion

		#endregion  成员方法
	}
}

