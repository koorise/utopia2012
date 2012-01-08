using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// 业务逻辑类ProductParts 的摘要说明。
	/// </summary>
	public class ProductParts
	{
		#region  私有变量
		private readonly GK2010.DAL.ProductParts dal=new GK2010.DAL.ProductParts();
		#endregion
		
		#region  构造函数
		public ProductParts()
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
        public int Add(GK2010.Model.ProductParts model)
        {
            return dal.Add(model);
        }
        #endregion

        #region  更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GK2010.Model.ProductParts model)
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

        #region  得到一个对象实体(关键字)
        /// <summary>
        /// 得到一个对象实体(关键字)
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

        #region 获取标题
        /// <summary>
        ///  获取标题
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
                return "根类别";
            }
        }
        #endregion


        #region  得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中。
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

        #region  列表(不分页)
        /// <summary>
        /// 列表(不分页)
        /// </summary>
        public List<GK2010.Model.ProductParts> GetList(string Keywords, string Type)
        {
            DataSet ds = dal.GetList(Keywords, Type);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region  列表(不分页)获取Tabel
        /// <summary>
        /// 列表(不分页)获取Tabel
        /// </summary>
        public DataTable GetTable(string Keywords, string Type)
        {
            DataSet ds = dal.GetList(Keywords, Type);
            return ds.Tables[0];
        }
        #endregion

        #region  获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GK2010.Model.ProductParts> GetList(int PageSize, int PageIndex, string Keywords, string Type, out int totalRows)
        {
            DataSet ds = dal.GetList(PageSize, PageIndex, Keywords, Type, out totalRows);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region  转换数据列表
        /// <summary>
        /// 转换数据列表
        /// </summary>
        public List<GK2010.Model.ProductParts> DataTableToList(DataTable dt)
        {
            return DataTableToList(dt.Select());
        }
        /// <summary>
        /// 转换数据列表
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

        #region 获取产品部件，根据productID 和Flag
        public List<Model.ProductParts> GetProductPartsByProductIDAndFlag(int productID,int defaultFlag, int flag)
        {
            return DataTableToList(dal.GetProductPartsByProductIDAndFlag(productID,defaultFlag, flag).Tables[0]);
        }
        #endregion

        #endregion  成员方法

        #region 其他方法

        #region 重新组合
        public List<GK2010.Model.ProductParts> GetListNew(int ProductID)
        {
            List<GK2010.Model.ProductParts> models_new = new List<GK2010.Model.ProductParts>();
            DataSet ds = dal.GetList(ProductID.ToString(), "ProductID");
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                List<GK2010.Model.ProductParts> models = DataTableToList(dt.Select("ParentID=0", "AttachmentFlag desc,SortID ASC"));//AttachmentFlag=1为附件，2为正常
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

        #region 重新组合绑定dropdownlist用
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
            //不包括：当前类别和以当前类别为父的类别
            List<GK2010.Model.ProductParts> models = DataTableToList(dt.Select("ParentID=" + ParentID + " and ID<>" + CurrentID + " and ParentID <>" + CurrentID, "SortID ASC"));
            foreach (GK2010.Model.ProductParts model in models)
            {
                int len = model.Path.Split(',').Length;
                if (len == 2)
                {
                    model.Title = "　|-  " + model.Title;
                }
                if (len == 3)
                {
                    model.Title = "　　|-  " + model.Title;
                }
                if (len == 4)
                {
                    model.Title = "　　　|-  " + model.Title;
                }
                if (len == 5)
                {
                    model.Title = "　　　　|-  " + model.Title;
                }
                models_new.Add(model);
                GetListDropDownList(CurrentID, model.ID, models_new, dt);
            }
        }
        #endregion

        #region  修改默认项
        /// <summary>
        ///  修改默认项
        /// </summary>
        public bool StaticDefault(int ID)
        {
            return dal.StaticDefault(ID);
        }
        #endregion

        #region 统计出一个产品的型号等
        /// <summary>
        /// 统计出一个产品的型号等
        /// </summary>
        /// <param name="ProductID">产品编号</param>
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

