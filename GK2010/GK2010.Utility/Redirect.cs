using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
namespace GK2010.Utility
{
    public class Redirect
    {
        #region 转向到操作结果界面
        
        /// <summary>
        /// 转向到操作结果界面
        /// </summary>
        /// <param name="UrlGo">点击确定后的地址</param>
        /// <param name="UrlBack">返回继续操作的地址</param>
        /// <param name="ErrorMsg">错误信息</param>
        public static void Do(string UrlGo, string UrlBack, string ErrorMsg)
        {           
            string UrlRedirect = string.Format(ConfigUrl.AdminUrlResult, UrlGo, UrlBack, ErrorMsg);
            HttpContext.Current.Response.Redirect(UrlRedirect);
            return;
        }

        /// <summary>
        /// 转向到操作结果界面（发生错误）
        /// </summary>
        public static void Do_Error( string ErrorMsg)
        {
            string UrlGo = ConfigUrl.CurrentUrl;
            string UrlBack = ConfigUrl.CurrentUrl;
            Do(UrlGo, UrlBack, ErrorMsg);
        }

        /// <summary>
        /// 转向到操作结果界面（添加成功）
        /// </summary>
        public static void Do_Add(string UrlGo,string ErrorMsg)
        {           
            string UrlBack = ConfigUrl.CurrentUrl;
            Do(UrlGo, UrlBack, ErrorMsg);
        }

        /// <summary>
        /// 转向到操作结果界面（修改成功）
        /// </summary>
        public static void Do_Update( string ErrorMsg)
        {
            string UrlGo = ConfigParam.ReturnUrl;
            string UrlBack = ConfigUrl.CurrentUrl;
            Do(UrlGo, UrlBack, ErrorMsg);
        }

        /// <summary>
        /// 转向到操作结果界面（删除成功）
        /// </summary>
        public static void Do_Delete(string ErrorMsg)
        {
            string UrlGo = ConfigParam.ReturnUrl;
            string UrlBack = ConfigParam.ReturnUrl;
            Do(UrlGo, UrlBack, ErrorMsg);

        }
        #endregion

        #region 转向到登录页面
        public static void Do_CheckAdminLogin()
        {
            #region 判断登录
            if (ConfigParam.Admin == null)
            {
                HttpContext.Current.Response.Write("<script>top.location.href='/login.aspx';</script>");
                return;
            }
            #endregion
        }
        #endregion

    }
}
