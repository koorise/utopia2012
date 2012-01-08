using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// 业务逻辑类MemberValid 的摘要说明。
	/// </summary>
	public class MemberValid
	{
		#region  私有变量
		private readonly GK2010.DAL.MemberValid dal=new GK2010.DAL.MemberValid();
		#endregion
		
		#region  构造函数
		public MemberValid()
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
		public int  Add(GK2010.Model.MemberValid model)
		{
            if (model.ValidValue.Length > 0)
            {
                model.ValidValue = Utility.DEncryptHelper.DESEncrypt.Encrypt(model.ValidValue);
            }
			return dal.Add(model);
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.MemberValid model)
		{
            if (model.ValidValue.Length > 0)
            {
                model.ValidValue = Utility.DEncryptHelper.DESEncrypt.Encrypt(model.ValidValue);
            }
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
		public GK2010.Model.MemberValid GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.MemberValid> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.MemberValid GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.MemberValid> models = DataTableToList(ds.Tables[0]);
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
			GK2010.BLL.MemberValid bll = new GK2010.BLL.MemberValid();
			GK2010.Model.MemberValid model = bll.GetModel(ID);
			if (model != null)
			{
				return model.ActiveCode;
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
		public GK2010.Model.MemberValid GetModelByCache(int ID)
		{
			
			string CacheKey = "MemberValidModel-" + ID;
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
			return (GK2010.Model.MemberValid)objModel;
		}
		#endregion

		#region  列表(不分页)
		/// <summary>
		/// 列表(不分页)
		/// </summary>
		public List<GK2010.Model.MemberValid> GetList(string Keywords, string Type)
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
		public List<GK2010.Model.MemberValid> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  转换数据列表
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.MemberValid> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.MemberValid> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.MemberValid> modelList = new List<GK2010.Model.MemberValid>();
			GK2010.Model.MemberValid model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.MemberValid();
				if(dr["ID"].ToString()!="")
				{
					model.ID=int.Parse(dr["ID"].ToString());
				}
				if(dr["ValidType"].ToString()!="")
				{
					model.ValidType=int.Parse(dr["ValidType"].ToString());
				}
				model.ValidValue=dr["ValidValue"].ToString();
				if(dr["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(dr["UserID"].ToString());
				}
				model.ActiveCode=dr["ActiveCode"].ToString();
				if(dr["StartDate"].ToString()!="")
				{
					model.StartDate=long.Parse(dr["StartDate"].ToString());
				}
				if(dr["EndDate"].ToString()!="")
				{
					model.EndDate=long.Parse(dr["EndDate"].ToString());
				}
				modelList.Add(model);
			}
			return modelList;
		}
		#endregion

		#endregion  成员方法

        #region 其他方法

        #region 综合操作(激活与取回密码)
        /// <summary>
        /// 综合操作(激活与取回密码)
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <param name="ValidType">激活|取回密码</param>
        /// <param name="ObjectValue">值</param>
        /// <param name="ActiveCode">激活码</param>
        /// <returns></returns>
        public bool Operator(int UserID, EnumSendType ValidType, string ObjectValue, string ActiveCode)
        {
            ObjectValue = Utility.DEncryptHelper.DESEncrypt.Encrypt(ObjectValue);//加密
            return dal.Operator(UserID, ValidType,  ObjectValue, ActiveCode);
        }
        #endregion

        #region 激活码是否过期

        /// <summary>
        /// 激活码是否过期
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <param name="ValidType">激活|取回密码</param>
        /// <param name="ObjectValue">值</param>
        /// <param name="ActiveCode">激活码</param>
        /// <returns></returns>
        public bool ActiveCodeExpired(int UserID, EnumSendType ValidType,  string ObjectValue, string ActiveCode)
        {
            ObjectValue = Utility.DEncryptHelper.DESEncrypt.Encrypt(ObjectValue);//加密
            return dal.ActiveCodeExpired(UserID, ValidType,  ObjectValue, ActiveCode);
        }
        #endregion

        #endregion
	}
}

