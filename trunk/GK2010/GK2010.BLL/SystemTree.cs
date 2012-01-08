using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// ҵ���߼���SystemTree ��ժҪ˵����
	/// </summary>
	public class SystemTree
	{
		#region  ˽�б���
		private readonly GK2010.DAL.SystemTree dal=new GK2010.DAL.SystemTree();
		#endregion
		
		#region  ���캯��
		public SystemTree()
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
		public int  Add(GK2010.Model.SystemTree model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(GK2010.Model.SystemTree model)
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
		public GK2010.Model.SystemTree GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.SystemTree> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.SystemTree GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.SystemTree> models = DataTableToList(ds.Tables[0]);
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
			GK2010.BLL.SystemTree bll = new GK2010.BLL.SystemTree();
			GK2010.Model.SystemTree model = bll.GetModel(ID);
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
		public GK2010.Model.SystemTree GetModelByCache(int ID)
		{
			
			string CacheKey = "SystemTreeModel-" + ID;
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
			return (GK2010.Model.SystemTree)objModel;
		}
		#endregion

		#region  �б�(����ҳ)
		/// <summary>
		/// �б�(����ҳ)
		/// </summary>
		public List<GK2010.Model.SystemTree> GetList(string Keywords, string Type)
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

		#region  ת�������б�
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.SystemTree> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.SystemTree> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.SystemTree> modelList = new List<GK2010.Model.SystemTree>();
			GK2010.Model.SystemTree model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.SystemTree();
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

		#endregion  ��Ա����

        #region ��������

        #region �������
        public List<GK2010.Model.SystemTree> GetListNew()
        {
            List<GK2010.Model.SystemTree> models_new = new List<GK2010.Model.SystemTree>();
            DataTable dt = dal.GetList("", "").Tables[0];
            List<GK2010.Model.SystemTree> models = DataTableToList(dt.Select("ParentID=0", "SortID ASC"));
            foreach (GK2010.Model.SystemTree model in models)
            {
                models_new.Add(model);
                GetListNew(model.ID, models_new, dt);
            }
            return models_new;
        }

        private void GetListNew(int ParentID, List<GK2010.Model.SystemTree> models_new, DataTable dt)
        {
            List<GK2010.Model.SystemTree> models = DataTableToList(dt.Select("ParentID=" + ParentID, "SortID ASC"));
            foreach (GK2010.Model.SystemTree model in models)
            {
                models_new.Add(model);
                GetListNew(model.ID, models_new, dt);
            }
        }
        #endregion

        #region ������ϰ�dropdownlist��
        public List<GK2010.Model.SystemTree> GetListDropDownList(int CurrentID)
        {
            List<GK2010.Model.SystemTree> models_new = new List<GK2010.Model.SystemTree>();
            DataTable dt = dal.GetList("", "").Tables[0];
            List<GK2010.Model.SystemTree> models = DataTableToList(dt.Select("ParentID=0 and ID<>" + CurrentID + " and ParentID <>" + CurrentID, "SortID ASC"));

            foreach (GK2010.Model.SystemTree model in models)
            {
                model.Title = ">> " + model.Title;
                models_new.Add(model);
                GetListDropDownList(CurrentID, model.ID, models_new, dt);
            }
            return models_new;
        }

        private void GetListDropDownList(int CurrentID, int ParentID, List<GK2010.Model.SystemTree> models_new, DataTable dt)
        {
            //����������ǰ�����Ե�ǰ���Ϊ�������
            List<GK2010.Model.SystemTree> models = DataTableToList(dt.Select("ParentID=" + ParentID + " and ID<>" + CurrentID + " and ParentID <>" + CurrentID, "SortID ASC"));
            foreach (GK2010.Model.SystemTree model in models)
            {
                int len = model.Path.Split(',').Length;
                if (len == 2)
                {
                    model.Title = "��|-  " + model.Title;
                }
                if (len == 3)
                {
                    model.Title = "����|-  " + model.Title;
                }
                if (len == 4)
                {
                    model.Title = "������|-  " + model.Title;
                }
                if (len == 5)
                {
                    model.Title = "��������|-  " + model.Title;
                }
                models_new.Add(model);
                GetListDropDownList(CurrentID, model.ID, models_new, dt);
            }
        }
        #endregion

        #region �ж�Ȩ��
        private bool CheckAdminPermission(string Url)
        {
            
            return dal.CheckPermission(Url);
        }

        public static void CheckPermission(string Url)
        {
            BLL.SystemTree bll = new BLL.SystemTree();
            if (!bll.CheckAdminPermission(Url))
            {
                HttpContext.Current.Response.Write("<script>alert(\"��Ȩ����\"); history.go(-1);</script>");
                return;
                //GK2010.Utility.Redirect.Do("", "", "û��Ȩ�޲�����");
            }
        }
        #endregion

        #endregion
	}
}

