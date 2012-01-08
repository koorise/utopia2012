using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// ҵ���߼���ProductParts ��ժҪ˵����
	/// </summary>
	public class ProductParts
	{
		#region  ˽�б���
		private readonly GK2010.DAL.ProductParts dal=new GK2010.DAL.ProductParts();
		#endregion
		
		#region  ���캯��
		public ProductParts()
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
        public int Add(GK2010.Model.ProductParts model)
        {
            return dal.Add(model);
        }
        #endregion

        #region  ����һ������
        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(GK2010.Model.ProductParts model)
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
        public GK2010.Model.ProductParts GetModel(int ID)
        {

            DataSet ds = dal.GetModel(ID);
            List<GK2010.Model.ProductParts> models = DataTableToList(ds.Tables[0]);
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
        public GK2010.Model.ProductParts GetModel(string Keywords)
        {
            DataSet ds = dal.GetList(Keywords, "Keywords");
            List<GK2010.Model.ProductParts> models = DataTableToList(ds.Tables[0]);
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
            GK2010.BLL.ProductParts bll = new GK2010.BLL.ProductParts();
            GK2010.Model.ProductParts model = bll.GetModel(ID);
            if (model != null)
            {
                return model.Title;
            }
            else
            {
                return "�����";
            }
        }
        #endregion


        #region  �õ�һ������ʵ�壬�ӻ�����
        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public GK2010.Model.ProductParts GetModelByCache(int ID)
        {

            string CacheKey = "ProductPartsModel-" + ID;
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
                catch { }
            }
            return (GK2010.Model.ProductParts)objModel;
        }
        #endregion

        #region  �б�(����ҳ)
        /// <summary>
        /// �б�(����ҳ)
        /// </summary>
        public List<GK2010.Model.ProductParts> GetList(string Keywords, string Type)
        {
            DataSet ds = dal.GetList(Keywords, Type);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region  �б�(����ҳ)��ȡTabel
        /// <summary>
        /// �б�(����ҳ)��ȡTabel
        /// </summary>
        public DataTable GetTable(string Keywords, string Type)
        {
            DataSet ds = dal.GetList(Keywords, Type);
            return ds.Tables[0];
        }
        #endregion

        #region  ��������б�
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<GK2010.Model.ProductParts> GetList(int PageSize, int PageIndex, string Keywords, string Type, out int totalRows)
        {
            DataSet ds = dal.GetList(PageSize, PageIndex, Keywords, Type, out totalRows);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region  ת�������б�
        /// <summary>
        /// ת�������б�
        /// </summary>
        public List<GK2010.Model.ProductParts> DataTableToList(DataTable dt)
        {
            return DataTableToList(dt.Select());
        }
        /// <summary>
        /// ת�������б�
        /// </summary>
        public List<GK2010.Model.ProductParts> DataTableToList(DataRow[] drs)
        {
            List<GK2010.Model.ProductParts> modelList = new List<GK2010.Model.ProductParts>();
            GK2010.Model.ProductParts model;
            foreach (DataRow dr in drs)
            {
                model = new GK2010.Model.ProductParts();
                if (dr["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dr["ID"].ToString());
                }
                if (dr["CacheID"].ToString() != "")
                {
                    model.CacheID = long.Parse(dr["CacheID"].ToString());
                }
                if (dr["ProductID"].ToString() != "")
                {
                    model.ProductID = int.Parse(dr["ProductID"].ToString());
                }
                if (dr["RootID"].ToString() != "")
                {
                    model.RootID = int.Parse(dr["RootID"].ToString());
                }
                if (dr["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(dr["ParentID"].ToString());
                }
                if (dr["HasChild"].ToString() != "")
                {
                    model.HasChild = int.Parse(dr["HasChild"].ToString());
                }
                if (dr["HasParts"].ToString() != "")
                {
                    model.HasParts = int.Parse(dr["HasParts"].ToString());
                }
                model.Path = dr["Path"].ToString();
                model.Title = dr["Title"].ToString();
                model.TitleEn = dr["TitleEn"].ToString();
                if (dr["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(dr["Price"].ToString());
                }
                model.Summary = dr["Summary"].ToString();
                model.Detail = dr["Detail"].ToString();
                model.Url = dr["Url"].ToString();
                if (dr["PictureID"].ToString() != "")
                {
                    model.PictureID = int.Parse(dr["PictureID"].ToString());
                }
                model.PictureSmall = dr["PictureSmall"].ToString();
                model.PictureNormal = dr["PictureNormal"].ToString();
                model.PictureBig = dr["PictureBig"].ToString();
                if (dr["SortID"].ToString() != "")
                {
                    model.SortID = decimal.Parse(dr["SortID"].ToString());
                }
                if (dr["PostDate"].ToString() != "")
                {
                    model.PostDate = long.Parse(dr["PostDate"].ToString());
                }
                if (dr["PostUserID"].ToString() != "")
                {
                    model.PostUserID = int.Parse(dr["PostUserID"].ToString());
                }
                if (dr["EditDate"].ToString() != "")
                {
                    model.EditDate = long.Parse(dr["EditDate"].ToString());
                }
                if (dr["EditUserID"].ToString() != "")
                {
                    model.EditUserID = int.Parse(dr["EditUserID"].ToString());
                }
                if (dr["DelDate"].ToString() != "")
                {
                    model.DelDate = long.Parse(dr["DelDate"].ToString());
                }
                if (dr["DelUserID"].ToString() != "")
                {
                    model.DelUserID = int.Parse(dr["DelUserID"].ToString());
                }
                if (dr["ShowFlag"].ToString() != "")
                {
                    model.ShowFlag = int.Parse(dr["ShowFlag"].ToString());
                }
                if (dr["DefaultFlag"].ToString() != "")
                {
                    model.DefaultFlag = int.Parse(dr["DefaultFlag"].ToString());
                }
                if (dr["AttachmentFlag"].ToString() != "")
                {
                    model.AttachmentFlag = int.Parse(dr["AttachmentFlag"].ToString());
                }
                if (dr["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(dr["Flag"].ToString());
                }
                modelList.Add(model);
            }
            return modelList;
        }
        #endregion

        #region ��ȡ��Ʒ����������productID ��Flag
        public List<Model.ProductParts> GetProductPartsByProductIDAndFlag(int productID,int defaultFlag, int flag)
        {
            return DataTableToList(dal.GetProductPartsByProductIDAndFlag(productID,defaultFlag, flag).Tables[0]);
        }
        #endregion

        #endregion  ��Ա����

        #region ��������

        #region �������
        public List<GK2010.Model.ProductParts> GetListNew(int ProductID)
        {
            List<GK2010.Model.ProductParts> models_new = new List<GK2010.Model.ProductParts>();
            DataSet ds = dal.GetList(ProductID.ToString(), "ProductID");
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                List<GK2010.Model.ProductParts> models = DataTableToList(dt.Select("ParentID=0", "AttachmentFlag desc,SortID ASC"));//AttachmentFlag=1Ϊ������2Ϊ����
                foreach (GK2010.Model.ProductParts model in models)
                {
                    models_new.Add(model);
                    GetListNew(model.ID, models_new, dt);
                }
                return models_new;
            }
            return null;
           
        }

        private void GetListNew(int ParentID, List<GK2010.Model.ProductParts> models_new, DataTable dt)
        {
            List<GK2010.Model.ProductParts> models = DataTableToList(dt.Select("ParentID=" + ParentID, "SortID ASC"));
            foreach (GK2010.Model.ProductParts model in models)
            {
                models_new.Add(model);
                GetListNew(model.ID, models_new, dt);
            }
        }
        #endregion

        #region ������ϰ�dropdownlist��
        public List<GK2010.Model.ProductParts> GetListDropDownList(int CurrentID)
        {
            List<GK2010.Model.ProductParts> models_new = new List<GK2010.Model.ProductParts>();
            DataTable dt = dal.GetList("", "").Tables[0];
            List<GK2010.Model.ProductParts> models = DataTableToList(dt.Select("ParentID=0 and ID<>" + CurrentID + " and ParentID <>" + CurrentID, "SortID ASC"));

            foreach (GK2010.Model.ProductParts model in models)
            {
                model.Title = ">> " + model.Title;
                models_new.Add(model);
                GetListDropDownList(CurrentID, model.ID, models_new, dt);
            }
            return models_new;
        }

        private void GetListDropDownList(int CurrentID, int ParentID, List<GK2010.Model.ProductParts> models_new, DataTable dt)
        {
            //����������ǰ�����Ե�ǰ���Ϊ�������
            List<GK2010.Model.ProductParts> models = DataTableToList(dt.Select("ParentID=" + ParentID + " and ID<>" + CurrentID + " and ParentID <>" + CurrentID, "SortID ASC"));
            foreach (GK2010.Model.ProductParts model in models)
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

        #region  �޸�Ĭ����
        /// <summary>
        ///  �޸�Ĭ����
        /// </summary>
        public bool StaticDefault(int ID)
        {
            return dal.StaticDefault(ID);
        }
        #endregion

        #region ͳ�Ƴ�һ����Ʒ���ͺŵ�
        /// <summary>
        /// ͳ�Ƴ�һ����Ʒ���ͺŵ�
        /// </summary>
        /// <param name="ProductID">��Ʒ���</param>
        /// <returns></returns>
        public GK2010.Model.ProductDiy Static(int ProductID)
        {
            DataSet ds = dal.Static(ProductID);
            Model.ProductDiy model = null;

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    model = new Model.ProductDiy();
                    model.DiyTypeCn = StringHelper.DelLastChar( ds.Tables[0].Rows[0]["DiyTypeCn"].ToString());
                    model.DiyTypeEn = StringHelper.DelLastChar( ds.Tables[0].Rows[0]["DiyTypeEn"].ToString());
                    model.DiyTypePartsID = StringHelper.DelLastChar( ds.Tables[0].Rows[0]["DiyTypePartsID"].ToString());
                    model.DiyTypePrice = StringHelper.DelLastChar( ds.Tables[0].Rows[0]["DiyTypePrice"].ToString());
                    model.DiyTypeAttachmentFlag = StringHelper.DelLastChar( ds.Tables[0].Rows[0]["DiyTypeAttachmentFlag"].ToString());
                    model.DiyTypeShowFlag = StringHelper.DelLastChar(ds.Tables[0].Rows[0]["DiyTypeShowFlag"].ToString());
                    model.DiyExpression = ds.Tables[0].Rows[0]["DiyExpression"].ToString();
                    model.Price = DecimalHelper.Parse( ds.Tables[0].Rows[0]["Price"].ToString(),0);
                    model.Type = ds.Tables[0].Rows[0]["Type"].ToString();
                }
            }

            return model;
        }
        #endregion 

        #endregion
	}
}

