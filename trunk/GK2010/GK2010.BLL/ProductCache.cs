using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// ҵ���߼���ProductCache ��ժҪ˵����
	/// </summary>
	public class ProductCache
	{
		#region  ˽�б���
		private readonly GK2010.DAL.ProductCache dal=new GK2010.DAL.ProductCache();
		#endregion
		
		#region  ���캯��
		public ProductCache()
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
		public int  Add(GK2010.Model.ProductCache model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(GK2010.Model.ProductCache model)
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

        #region  ɾ����Ʒ���ո��ݴӹ��ﳵ�л�ȡ���Ŀ��ձ��
        public bool DeleteByProductCacheID(long productCacheID)
        {
            return dal.DeleteByProductCacheID(productCacheID);
        }
        #endregion

        #region �����û�id�Ͳ�Ʒid��ѯ���ձ��Ƿ��������
        public Model.ProductCache GetModelByUserIDAndProductID(int userID, int productID)
        {
            DataSet ds = dal.GetModelByUserIDAndProductID(userID, productID);
            List<Model.ProductCache> models = DataTableToList(ds.Tables[0]);
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

        #region  �õ�һ������ʵ��
        /// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public GK2010.Model.ProductCache GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.ProductCache> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.ProductCache GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.ProductCache> models = DataTableToList(ds.Tables[0]);
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
			GK2010.BLL.ProductCache bll = new GK2010.BLL.ProductCache();
			GK2010.Model.ProductCache model = bll.GetModel(ID);
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
		public GK2010.Model.ProductCache GetModelByCache(int ID)
		{
			
			string CacheKey = "ProductCacheModel-" + ID;
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
			return (GK2010.Model.ProductCache)objModel;
		}
		#endregion

		#region  �б�(����ҳ)
		/// <summary>
		/// �б�(����ҳ)
		/// </summary>
		public List<GK2010.Model.ProductCache> GetList(string Keywords, string Type)
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
		public List<GK2010.Model.ProductCache> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  ת�������б�
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.ProductCache> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.ProductCache> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.ProductCache> modelList = new List<GK2010.Model.ProductCache>();
			GK2010.Model.ProductCache model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.ProductCache();
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
				if(dr["CategoryID"].ToString()!="")
				{
					model.CategoryID=int.Parse(dr["CategoryID"].ToString());
				}
				model.Title=dr["Title"].ToString();
				model.TitleEn=dr["TitleEn"].ToString();
				model.Summary=dr["Summary"].ToString();
				model.Detail=dr["Detail"].ToString();
				model.Tags=dr["Tags"].ToString();
				if(dr["Hits"].ToString()!="")
				{
					model.Hits=int.Parse(dr["Hits"].ToString());
				}
				model.Url=dr["Url"].ToString();
				model.DefaultBrand=dr["DefaultBrand"].ToString();
				model.DefaultPeriod=dr["DefaultPeriod"].ToString();
				if(dr["DefaultPriceOld"].ToString()!="")
				{
					model.DefaultPriceOld=decimal.Parse(dr["DefaultPriceOld"].ToString());
				}
				if(dr["DefaultPrice"].ToString()!="")
				{
					model.DefaultPrice=decimal.Parse(dr["DefaultPrice"].ToString());
				}
				if(dr["DefaultJF"].ToString()!="")
				{
					model.DefaultJF=decimal.Parse(dr["DefaultJF"].ToString());
				}
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
				if(dr["ShowFlag"].ToString()!="")
				{
					model.ShowFlag=int.Parse(dr["ShowFlag"].ToString());
				}
				if(dr["PostDate"].ToString()!="")
				{
					model.PostDate=long.Parse(dr["PostDate"].ToString());
				}
				if(dr["PostUserID"].ToString()!="")
				{
					model.PostUserID=int.Parse(dr["PostUserID"].ToString());
				}
				if(dr["MemberFlag"].ToString()!="")
				{
					model.MemberFlag=int.Parse(dr["MemberFlag"].ToString());
				}
				if(dr["DiyFlag"].ToString()!="")
				{
					model.DiyFlag=int.Parse(dr["DiyFlag"].ToString());
				}
				model.DiyTypeCn=dr["DiyTypeCn"].ToString();
				model.DiyTypeEn=dr["DiyTypeEn"].ToString();
				model.DiyTypePartsID=dr["DiyTypePartsID"].ToString();
				model.DiyTypePrice=dr["DiyTypePrice"].ToString();
				model.DiyTypeAttachmentFlag=dr["DiyTypeAttachmentFlag"].ToString();
				model.DiyExpression=dr["DiyExpression"].ToString();
				if(dr["BasicDiscountPrice"].ToString()!="")
				{
					model.BasicDiscountPrice=int.Parse(dr["BasicDiscountPrice"].ToString());
				}
				if(dr["BasicDiscountJF"].ToString()!="")
				{
					model.BasicDiscountJF=int.Parse(dr["BasicDiscountJF"].ToString());
				}
				modelList.Add(model);
			}
			return modelList;
		}
		#endregion

		#endregion  ��Ա����
	}
}

