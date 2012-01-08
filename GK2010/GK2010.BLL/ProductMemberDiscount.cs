using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// ҵ���߼���ProductMemberDiscount ��ժҪ˵����
	/// </summary>
	public class ProductMemberDiscount
	{
		#region  ˽�б���
		private readonly GK2010.DAL.ProductMemberDiscount dal=new GK2010.DAL.ProductMemberDiscount();
		#endregion
		
		#region  ���캯��
		public ProductMemberDiscount()
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
		public int  Add(GK2010.Model.ProductMemberDiscount model)
		{
			return dal.Add(model);
		}
		#endregion

		#region  ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(GK2010.Model.ProductMemberDiscount model)
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
		public GK2010.Model.ProductMemberDiscount GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.ProductMemberDiscount> models = DataTableToList(ds.Tables[0]);
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
		public GK2010.Model.ProductMemberDiscount GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.ProductMemberDiscount> models = DataTableToList(ds.Tables[0]);
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

		#region  �õ�һ������ʵ�壬�ӻ�����
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public GK2010.Model.ProductMemberDiscount GetModelByCache(int ID)
		{
			
			string CacheKey = "ProductMemberDiscountModel-" + ID;
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
			return (GK2010.Model.ProductMemberDiscount)objModel;
		}
		#endregion

		#region  �б�(����ҳ)
		/// <summary>
		/// �б�(����ҳ)
		/// </summary>
		public List<GK2010.Model.ProductMemberDiscount> GetList(string Keywords, string Type)
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
		public List<GK2010.Model.ProductMemberDiscount> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  ת�������б�
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.ProductMemberDiscount> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.ProductMemberDiscount> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.ProductMemberDiscount> modelList = new List<GK2010.Model.ProductMemberDiscount>();
			GK2010.Model.ProductMemberDiscount model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.ProductMemberDiscount();
				if(dr["ID"].ToString()!="")
				{
					model.ID=int.Parse(dr["ID"].ToString());
				}
				if(dr["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(dr["UserID"].ToString());
				}
				if(dr["ProductID"].ToString()!="")
				{
					model.ProductID=int.Parse(dr["ProductID"].ToString());
				}
				if(dr["DiscountPrice"].ToString()!="")
				{
					model.DiscountPrice=int.Parse(dr["DiscountPrice"].ToString());
				}
				if(dr["DiscountJF"].ToString()!="")
				{
					model.DiscountJF=int.Parse(dr["DiscountJF"].ToString());
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
				modelList.Add(model);
			}
			return modelList;
		}
		#endregion

		#endregion  ��Ա����

        #region �б����в�Ʒ��
        public DataSet GetList(int PageSize, int PageIndex,int UserID, string Sql, out int totalRows)
        {
            return dal.GetList(PageSize, PageIndex, UserID, Sql, out totalRows);
        }
        #endregion 

        #region  ���ӻ��޸�����
        /// <summary>
        /// ���ӻ��޸�����
        /// </summary>
        public bool Operator(GK2010.Model.ProductMemberDiscount model)
        {
            return dal.Operator(model);
        }
        #endregion

        #region  �õ�һ������ʵ��
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public GK2010.Model.ProductMemberDiscount GetModel(int UserID, int ProductID)
        {
            DataSet ds = dal.GetModel(UserID, ProductID);
            List<GK2010.Model.ProductMemberDiscount> models = DataTableToList(ds.Tables[0]);
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


	}
}

