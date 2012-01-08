using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// ҵ���߼���ConfigLog ��ժҪ˵����
	/// </summary>
	public class ConfigLog
	{
		#region  ˽�б���
		private readonly GK2010.DAL.ConfigLog dal=new GK2010.DAL.ConfigLog();
		#endregion
		
		#region  ���캯��
		public ConfigLog()
		{}
		#endregion		
		
		#region  ��Ա����

		#region  �Ƿ���ڸü�¼
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}
		#endregion  �Ƿ���ڸü�¼

		#region  ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(GK2010.Model.ConfigLog model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(GK2010.Model.ConfigLog model)
		{
			return dal.Update(model);
		}
		#endregion

		#region  ɾ��һ������
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		#endregion

		#region  �õ�һ������ʵ��
		/// <summary>
		/// �õ�һ������ʵ��
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
		
		#region  �õ�һ������ʵ��(�ؼ���)
		/// <summary>
		/// �õ�һ������ʵ��(�ؼ���)
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
		
		#region ��ȡ����
		/// <summary>
		///  ��ȡ����
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

		#region  �õ�һ������ʵ�壬�ӻ�����
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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

		#region  �б�(����ҳ)
		/// <summary>
		/// �б�(����ҳ)
		/// </summary>
		public List<GK2010.Model.ConfigLog> GetList(string Keywords, string Type)
		{
			DataSet ds = dal.GetList(Keywords,Type);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  �б�(����ҳ)��ȡTabel
		/// <summary>
		/// �б�(����ҳ)��ȡTabel
		/// </summary>
		public DataTable GetTable(string Keywords, string Type)
		{
			DataSet ds = dal.GetList(Keywords,Type);
			return ds.Tables[0];
		}
		#endregion

		#region  ��������б�
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<GK2010.Model.ConfigLog> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  ת�������б�
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.ConfigLog> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// ת�������б�
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

		#endregion  ��Ա����

        #region ��������

        #region �����־
        /// <summary>
        /// ���ټ�¼��־
        /// </summary>
        /// <param name="Title">��־����</param>
        /// <param name="Detail">��־����</param>
        /// <param name="UserID">��¼��</param>
        /// <returns></returns>
        public static bool Add(string Title, string Detail,int UserID)
        {
            BLL.ConfigLog bll = new BLL.ConfigLog();
            Model.ConfigLog model = new Model.ConfigLog();
            model.Title = Title;
            model.Detail = Detail;
            model.UserID = UserID;//������־�Ķ���
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

