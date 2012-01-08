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
    public partial class Province_City_Handle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //中文解码 Server.UrlDecode();
            string jsonResult = "{}";
            string jsoncall = ConfigParam.callback;
            string type = ConfigParam.Type;
            string CityID = Server.UrlDecode(ConfigParam.GetStrGet("CityID"));
            if (type != "")
            {
                switch (type)
                {
                    case "ListProvince":
                        jsonResult = ListProvince();
                        break;
                    case "ListCity":
                        string ProvinceID = ConfigParam.ProvinceID;
                        jsonResult = ListCity(ProvinceID);
                        break;
                    case "DefaultProvinceCity":
                        jsonResult = DefaultProvinceCity();
                        break;
                    case "SearchCity":
                        jsonResult = SearchCity(CityID);
                        break;
                }
            }
            Response.ContentType = "text/plain";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(jsoncall + "(" + jsonResult + ")");
        }

        #region 获取省份列表
        public string ListProvince()
        {
            List<GK2010.Model.ConfigProvince> models = new List<GK2010.Model.ConfigProvince>();
            GK2010.BLL.ConfigProvince bll = new GK2010.BLL.ConfigProvince();
            models = bll.GetList("", "");
            return Utility.JsonHelper.ListToJson(models);
        }
        #endregion

        #region 获取城市列表
        public string ListCity(string ProvinceID)
        {
            List<GK2010.Model.ConfigCity> models = new List<GK2010.Model.ConfigCity>();
            GK2010.BLL.ConfigCity bll = new GK2010.BLL.ConfigCity();
            models = bll.GetList(ProvinceID, "ProvinceID");
            return Utility.JsonHelper.ListToJson(models);
        }
        #endregion

        #region 搜索城市列表
        public string SearchCity(string CityID)
        {
            List<GK2010.Model.ConfigCity> models = new List<GK2010.Model.ConfigCity>();
            GK2010.BLL.ConfigCity bll = new GK2010.BLL.ConfigCity();
            models = bll.GetList(CityID, "SearchCity");
            return Utility.JsonHelper.ListToJson(models);
        }
        #endregion


        #region 根据IP获取所在城市
        public string DefaultProvinceCity()
        {
            return Utility.JsonHelper.ListToJson(BLL.ConfigCity.GetIPCitys());
        }
        #endregion
    }
}
