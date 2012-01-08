using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Json;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Service
{
    public partial class ProductCategory_Handle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //中文解码 Server.UrlDecode();
            string jsonResult = "{}";
            string jsoncall = ConfigParam.callback;
            string type = ConfigParam.Type;
            string BigID = Server.UrlDecode(ConfigParam.GetStrGet("BigID"));
            string SmallID = Server.UrlDecode(ConfigParam.GetStrGet("SmallID"));
            if (type != "")
            {
                switch (type)
                {
                    case "ListBigCategory":
                        jsonResult = ListBigCategory();
                        break;
                    case "ListSmallCategory":
                        jsonResult = ListSmallCategory(BigID);
                        break;
                    case "DefaultCategory":
                        jsonResult = DefaultCategory(SmallID);
                        break;                 
                }
            }
            Response.ContentType = "text/plain";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(jsoncall + "(" + jsonResult + ")");
        }

        #region 获取大列表
        public string ListBigCategory()
        {
            List<GK2010.Model.ProductCategory> models = new List<GK2010.Model.ProductCategory>();
            GK2010.BLL.ProductCategory bll = new GK2010.BLL.ProductCategory();
            models = bll.GetList("0", "ParentID");
            return Utility.JsonHelper.ListToJson(models);
        }
        #endregion

        #region 获取小列表
        public string ListSmallCategory(string ParentID)
        {
            List<GK2010.Model.ProductCategory> models = new List<GK2010.Model.ProductCategory>();
            GK2010.BLL.ProductCategory bll = new GK2010.BLL.ProductCategory();
            models = bll.GetList(ParentID, "ParentID");
            return Utility.JsonHelper.ListToJson(models);
        }
        #endregion

        #region 获取默认
        public string DefaultCategory(string SmallID)
        {
            List<Model.ProductCategory> models = new List<Model.ProductCategory>();
            BLL.ProductCategory bll = new BLL.ProductCategory();
            models = bll.GetList(SmallID, "SmallID");
            return Utility.JsonHelper.ListToJson(models);
        }
        #endregion
    }
}
