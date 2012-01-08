using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using System.Web;
using GK2010.Utility;
using System.Data;
using System.Net.Json;
namespace GK2010.Common
{
    public class LoginHelper
    {
        #region 是否登录
        public static bool HasLogin
        {
            get
            {
                return IntHelper.Parse(HttpContext.Current.User.Identity.Name, -1) > 0;
            }
        }
        #endregion

        #region 获取登录UserID
        /// <summary>
        /// 获取登录UserID
        /// </summary>
        public static int UserID
        {
            get
            {
                return IntHelper.Parse(HttpContext.Current.User.Identity.Name, -1);
            }
        }
        #endregion

        #region 是否管理员
        /// <summary>
        /// 是否管理员
        /// </summary>
        public static bool IsAdmin
        {
            get
            {
                GK2010.BLL.Member bllMember = new GK2010.BLL.Member();
                GK2010.Model.Member modelMember = bllMember.GetModel(UserID);
                if (modelMember != null && modelMember.AdminFlag > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region 会员基本信息
        /// <summary>
        /// 会员基本信息
        /// </summary>
        public static GK2010.Model.Member Member
        {
            get
            {
                GK2010.BLL.Member bllMember = new GK2010.BLL.Member();
                GK2010.Model.Member modelMember = bllMember.GetModel(UserID);
                return modelMember;
            }
        }
        #endregion

        #region 单点登录
        /// <summary>
        /// 单点登录
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <param name="IsPersistent">是否记住密码</param>
        public static void Login(string UserID, bool IsPersistent)
        {
            //单点登录           
            FormsAuthentication.SetAuthCookie(UserID, IsPersistent);

            //获取用户的Cookie 
            HttpCookie cookie = FormsAuthentication.GetAuthCookie(UserID, IsPersistent);

            //给用户的cookie的值加上Cookie的域和过期日期,向客户端重写同名的用户Cookie          
            FormsAuthenticationTicket oldTicket = FormsAuthentication.Decrypt(cookie.Value);
            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(1,
                oldTicket.Name,
                oldTicket.IssueDate,
                DateTime.Now.AddMinutes(20160),//14天=20160分钟//此时间在timeout中设置，在此设置好像不起作用
                oldTicket.IsPersistent,
                oldTicket.UserData,
                FormsAuthentication.FormsCookiePath);
            
            cookie.Value = FormsAuthentication.Encrypt(newTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);

        }
        #endregion

        #region 单点退出
        /// <summary>
        /// 单点退出
        /// </summary>
        public static void LoginOut()
        {
            HttpCookie cookie = HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName];            
            cookie.Value = null;
            cookie.Expires = DateTime.Now.AddDays(-1);

            //更新cookie
            HttpContext.Current.Response.Cookies.Add(cookie);
            FormsAuthentication.SignOut();

        }
        #endregion
    }
}
