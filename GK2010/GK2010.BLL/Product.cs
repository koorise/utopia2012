using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection;
namespace GK2010.BLL
{
	/// <summary>
	/// ҵ���߼���Product ��ժҪ˵����
	/// </summary>
	public class Product
	{
		#region  ˽�б���
		private readonly GK2010.DAL.Product dal=new GK2010.DAL.Product();
		#endregion
		
		#region  ���캯��
		public Product()
		{}
		#endregion
		
		
		#region  ��Ա����
      

        #region ��ȡ��Ʒ�ۿۺ�۸�
        public static decimal GetPriceDiscount( int MemberID, int ProductID)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@ProductID", SqlDbType.Int,4)
				};
            parameters[0].Value = MemberID;
            parameters[1].Value = ProductID;

            DataSet ds = DbHelperSQL.RunProcedure("UP_ProductMemberDiscount_GetPriceDiscount", parameters, "ds");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                return decimal.Parse(ds.Tables[0].Rows[0]["DiscountPrice"].ToString());
            else
                return 1;
        }

        #endregion

        #region ��ȡ��Ʒ�ۿۺ����
        public static decimal GetJFDiscount(int MemberID, int ProductID)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@ProductID", SqlDbType.Int,4)
				};
            parameters[0].Value = MemberID;
            parameters[1].Value = ProductID;

            DataSet ds = DbHelperSQL.RunProcedure("UP_ProductMemberDiscount_GetJFDiscount", parameters, "ds");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                return decimal.Parse(ds.Tables[0].Rows[0]["DiscountJF"].ToString());
            else
                return 1;
        }

        #endregion

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
		public int  Add(GK2010.Model.Product model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(GK2010.Model.Product model)
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

        #region ���ݿ��ձ�ŵõ�һ��ʵ��
        public GK2010.Model.Product GetModelByProductCacheID(long productCacheID)
        {
            DataSet ds = dal.GetModelByProductCacheID(productCacheID);
            List<GK2010.Model.Product> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.Product GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.Product> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.Product GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.Product> models = DataTableToList(ds.Tables[0]);
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
			GK2010.BLL.Product bll = new GK2010.BLL.Product();
			GK2010.Model.Product model = bll.GetModel(ID);
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

        #region ��ȡ���򱾲�Ʒ�Ĺ˿ͻ�����Ĳ�Ʒ
        public DataSet GetPayHistory(int productID) {
            return dal.GetPayHistory(productID);
        }
        #endregion

        #region ��Ʒ����
        public DataSet GetProductHotSale() {
            return dal.GetProductHotSale();
        }
        #endregion

        #region  �õ�һ������ʵ�壬�ӻ�����
        /// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public GK2010.Model.Product GetModelByCache(int ID)
		{
			
			string CacheKey = "ProductModel-" + ID;
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
			return (GK2010.Model.Product)objModel;
		}
		#endregion

		#region  �б�(����ҳ)
		/// <summary>
		/// �б�(����ҳ)
		/// </summary>
		public List<GK2010.Model.Product> GetList(string Keywords, string Type)
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
		public List<GK2010.Model.Product> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  ת�������б�
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.Product> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.Product> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.Product> modelList = new List<GK2010.Model.Product>();
			GK2010.Model.Product model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.Product();
				if(dr["ID"].ToString()!="")
				{
					model.ID=int.Parse(dr["ID"].ToString());
				}
				if(dr["CacheID"].ToString()!="")
				{
					model.CacheID=long.Parse(dr["CacheID"].ToString());
				}
				if(dr["RootID"].ToString()!="")
				{
					model.RootID=int.Parse(dr["RootID"].ToString());
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
                model.DefaultType = dr["DefaultType"].ToString();
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
                model.DiyTypeShowFlag = dr["DiyTypeShowFlag"].ToString();
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

        #region ת�����ݣ�listתΪdataset��
        public DataSet ToDataSet(IList p_List)
        {
            DataSet result = new DataSet();
            DataTable _DataTable = new DataTable();
            if (p_List.Count > 0)
            {
                PropertyInfo[] propertys = p_List[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    _DataTable.Columns.Add(pi.Name, pi.PropertyType);
                }
                for (int i = 0; i < p_List.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(p_List[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    _DataTable.LoadDataRow(array, true);
                }
            }
            result.Tables.Add(_DataTable);
            return result;
        }
        #endregion

        #endregion  ��Ա����

        #region  ǰ̨��ҳ
        /// <summary>
        /// ǰ̨��ҳ
        /// </summary>
        public List<GK2010.Model.Product> GetList(int PageSize, int PageIndex, int UserID, int BigID, int SmallID, int ThirdID, VirtualSearch VirtualSearch, int OrderType, out int totalRows)
        {
            DataSet ds = dal.GetList(PageSize, PageIndex, UserID,BigID, SmallID, ThirdID,VirtualSearch,OrderType,out totalRows);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion
       
	}
}

