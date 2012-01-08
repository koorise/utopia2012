using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
    /// <summary>
    /// 业务逻辑类Config 的摘要说明。
    /// </summary>
    public class Config
    {
        #region  私有变量
        private readonly GK2010.DAL.Config dal = new GK2010.DAL.Config();
        #endregion

        #region  构造函数
        public Config()
        { }
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
        public int Add(GK2010.Model.Config model)
        {
            return dal.Add(model);
        }
        #endregion

        #region  更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GK2010.Model.Config model)
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
        public GK2010.Model.Config GetModel(int ID)
        {

            DataSet ds = dal.GetModel(ID);
            List<GK2010.Model.Config> models = DataTableToList(ds.Tables[0]);
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
        public GK2010.Model.Config GetModel()
        {
            DataSet ds = dal.GetList("", "");
            List<GK2010.Model.Config> models = DataTableToList(ds.Tables[0]);
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
            GK2010.BLL.Config bll = new GK2010.BLL.Config();
            GK2010.Model.Config model = bll.GetModel(ID);
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
        public GK2010.Model.Config GetModelByCache(int ID)
        {

            string CacheKey = "ConfigModel-" + ID;
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
            return (GK2010.Model.Config)objModel;
        }
        #endregion

        #region  列表(不分页)
        /// <summary>
        /// 列表(不分页)
        /// </summary>
        public List<GK2010.Model.Config> GetList(string Keywords, string Type)
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
        public List<GK2010.Model.Config> GetList(int PageSize, int PageIndex, string Keywords, string Type, out int totalRows)
        {
            DataSet ds = dal.GetList(PageSize, PageIndex, Keywords, Type, out totalRows);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region  转换数据列表
        /// <summary>
        /// 转换数据列表
        /// </summary>
        public List<GK2010.Model.Config> DataTableToList(DataTable dt)
        {
            return DataTableToList(dt.Select());
        }
        /// <summary>
        /// 转换数据列表
        /// </summary>
        public List<GK2010.Model.Config> DataTableToList(DataRow[] drs)
        {
            List<GK2010.Model.Config> modelList = new List<GK2010.Model.Config>();
            GK2010.Model.Config model;
            foreach (DataRow dr in drs)
            {
                model = new GK2010.Model.Config();
                if (dr["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dr["ID"].ToString());
                }
                model.Title = dr["Title"].ToString();
                model.TitleEn = dr["TitleEn"].ToString();
                model.WebDomain = dr["WebDomain"].ToString();
                model.WebName = dr["WebName"].ToString();
                model.WebBeian = dr["WebBeian"].ToString();
                model.WebStatic = dr["WebStatic"].ToString();
                model.ControlService = dr["ControlService"].ToString();
                model.ControlTop = dr["ControlTop"].ToString();
                model.ControlBoot = dr["ControlBoot"].ToString();
                if (dr["ShowPriceDiyFlag"].ToString() != "")
                {
                    model.ShowPriceDiyFlag = int.Parse(dr["ShowPriceDiyFlag"].ToString());
                }
                if (dr["ShowPriceWhenNotLogin"].ToString() != "")
                {
                    model.ShowPriceWhenNotLogin = int.Parse(dr["ShowPriceWhenNotLogin"].ToString());
                }
                model.AliPayAccount = dr["AliPayAccount"].ToString();
                model.AliPayPartnerID = dr["AliPayPartnerID"].ToString();
                model.AliPayKey = dr["AliPayKey"].ToString();
                model.AliPayUserName = dr["AliPayUserName"].ToString();
                model.AliPayUserPwd = dr["AliPayUserPwd"].ToString();
                model.EmailUserName = dr["EmailUserName"].ToString();
                model.EmailUserPwd = dr["EmailUserPwd"].ToString();
                model.EmailHost = dr["EmailHost"].ToString();
                model.EmailPort = dr["EmailPort"].ToString();
                model.MobileUserName = dr["MobileUserName"].ToString();
                model.MobileUserPwd = dr["MobileUserPwd"].ToString();
                model.MobileEID = dr["MobileEID"].ToString();
                modelList.Add(model);
            }
            return modelList;
        }
        #endregion

        #endregion  成员方法
    }
}

