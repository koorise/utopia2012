using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// ҵ���߼���ProductPicture ��ժҪ˵����
	/// </summary>
	public class ProductPicture
	{
		#region  ˽�б���
		private readonly GK2010.DAL.ProductPicture dal=new GK2010.DAL.ProductPicture();
		#endregion
		
		#region  ���캯��
		public ProductPicture()
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
		public int  Add(GK2010.Model.ProductPicture model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(GK2010.Model.ProductPicture model)
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
		public GK2010.Model.ProductPicture GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.ProductPicture> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.ProductPicture GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.ProductPicture> models = DataTableToList(ds.Tables[0]);
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
			GK2010.BLL.ProductPicture bll = new GK2010.BLL.ProductPicture();
			GK2010.Model.ProductPicture model = bll.GetModel(ID);
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
		public GK2010.Model.ProductPicture GetModelByCache(int ID)
		{
			
			string CacheKey = "ProductPictureModel-" + ID;
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
			return (GK2010.Model.ProductPicture)objModel;
		}
		#endregion

		#region  �б�(����ҳ)
		/// <summary>
		/// �б�(����ҳ)
		/// </summary>
		public List<GK2010.Model.ProductPicture> GetList(string Keywords, string Type)
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
		public List<GK2010.Model.ProductPicture> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  ת�������б�
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.ProductPicture> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.ProductPicture> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.ProductPicture> modelList = new List<GK2010.Model.ProductPicture>();
			GK2010.Model.ProductPicture model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.ProductPicture();
				if(dr["ID"].ToString()!="")
				{
					model.ID=int.Parse(dr["ID"].ToString());
				}
				if(dr["ProductID"].ToString()!="")
				{
					model.ProductID=int.Parse(dr["ProductID"].ToString());
				}
				model.Title=dr["Title"].ToString();
				model.Summary=dr["Summary"].ToString();
				model.Detail=dr["Detail"].ToString();
				if(dr["FileID"].ToString()!="")
				{
					model.FileID=int.Parse(dr["FileID"].ToString());
				}
				if(dr["SortID"].ToString()!="")
				{
					model.SortID=decimal.Parse(dr["SortID"].ToString());
				}
				if(dr["DefaultFlag"].ToString()!="")
				{
					model.DefaultFlag=int.Parse(dr["DefaultFlag"].ToString());
				}
				model.PictureSmall=dr["PictureSmall"].ToString();
				model.PictureBig=dr["PictureBig"].ToString();
				model.PictureNormal=dr["PictureNormal"].ToString();
				modelList.Add(model);
			}
			return modelList;
		}
		#endregion

		#endregion  ��Ա����
	}
}

