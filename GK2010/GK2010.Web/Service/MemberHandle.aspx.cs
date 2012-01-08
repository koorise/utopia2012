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
    public partial class MemberHandle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //中文解码 Server.UrlDecode();
            string jsonResult = "{}";
            string jsoncall = ConfigParam.callback;
            string Type = ConfigParam.Type;
            string Content = Server.UrlDecode(ConfigParam.GetStrGet("Content"));
            if (Type != "")
            {
                switch (Type)
                {
                    //检查用户名是否存在
                    case "CheckUserName":
                        jsonResult = CheckUserName(Content, EnumLoginType.UserName);
                        break;
                    //检查手机号是否存在
                    case "CheckMobile":
                        jsonResult = CheckUserName(Content, EnumLoginType.Mobile);
                        break;
                    //检查Email是否存在
                    case "CheckEmail":
                        jsonResult = CheckUserName(Content, EnumLoginType.Email);
                        break;
                    //检查验证码是否正确
                    case "CheckCode":
                        jsonResult = CheckCode(Content);
                        break;         
                }
            }
            Response.ContentType = "text/plain";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(jsoncall + "(" + jsonResult + ")");
           
        }

        #region 判断用户名|邮箱|手机是否存在
        /// <summary>
        /// 判断用户名|邮箱|手机是否存在
        /// </summary>
        /// <returns></returns>
        public string CheckUserName(string Content, EnumLoginType LoginType)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            BLL.Member bll = new GK2010.BLL.Member();
            bool ok = bll.CheckUserName(Content, LoginType);
            if (ok)
                collection.Add(new JsonStringValue("Result", "Fail"));
            else
                collection.Add(new JsonStringValue("Result", "OK"));

            //if (Content.IndexOf("138") >= 0)
            //{
            //    collection.Add(new JsonStringValue("Result", "OK"));
            //}
            //else
            //    collection.Add(new JsonStringValue("Result", "Fail"));           
            return collection.ToString();
        }
        #endregion

        #region 判断验证码
        /// <summary>
        /// 判断验证码
        /// </summary>
        /// <returns></returns>
        public string CheckCode(string Content)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            if (Content.ToLower()== ConfigParam.CheckCode.ToLower())
            {
                collection.Add(new JsonStringValue("Result", "OK"));
            }
            else
                collection.Add(new JsonStringValue("Result", "Fail"));
            return collection.ToString();
        }
        #endregion
    }
}
