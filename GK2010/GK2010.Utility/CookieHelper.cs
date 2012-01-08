using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Collections;
namespace GK2010.Utility
{
    public class CookieHelper
    {
        #region Cookies清除
        public static void ClearCookies(string cookiename)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (cookie != null)
            {
                cookie.Value = "";
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        #endregion

        #region Cookies设置
        public static void SetCookies(string cookiename, string value)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (cookie == null)
            {
                cookie = new HttpCookie(cookiename);
                cookie.Value = value;
                cookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            else
            {
                cookie.Value = value;
                cookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        #endregion

        #region Cookies获得
        public static string GetCookies(string cookiename)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (cookie != null)
            {
                return cookie.Value;
            }
            else
                return "";
        }
        #endregion

        #region Cookies设置UserID
        public static void SetCookiesUserID(string cookiename, int value)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (cookie == null)
            {
                cookie = new HttpCookie(cookiename);
                cookie.Value = value.ToString();
                cookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            else
            {
                cookie.Value = value.ToString();
                cookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        #endregion

        #region Cookies获得UserID
        public static int GetCookiesUserID(string cookiename)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (cookie != null)
            {
                return int.Parse(cookie.Value);
            }
            else
                return 0;
        }
        #endregion

        #region 插入cookie的代码,存储产品的浏览记录
        public static void addcookie(string cookiename, string value)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (cookie == null)
            {
                cookie = new HttpCookie(cookiename);
                cookie.Value = value;
                cookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            else
            {
                if (value != null)
                {
                    string[] cookies = cookie.Value.Split(',');
                    string newcookies = "";
                    for (int i = 0; i < cookies.Length; i++)
                    {
                        if (value != cookies[i])
                        {
                            if (newcookies == "")
                                newcookies = cookies[i];
                            else
                                newcookies = newcookies + "," + cookies[i];
                        }
                    }
                    if (newcookies == "") 
                        newcookies = value;
                    else
                    newcookies = newcookies + "," + value;
                    if (cookies.Length > 8)
                        newcookies = newcookies.Substring(newcookies.IndexOf(',') + 1);
                    ClearCookies(cookiename);
                    cookie.Value = newcookies;
                    cookie.Expires = DateTime.Now.AddDays(1);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }
        }

        #endregion

        #region 获取cookie的代码,存储产品的浏览记录
        public static ArrayList playcookie(string cookiename)
        {
            int num = 0;
            string myvalue = "";
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            myvalue = cookie.Value;
            ArrayList resultvalue = new ArrayList();
            if (myvalue != "")
            {
                string[] cookievalue;
                cookievalue = myvalue.Split(',');
                if (cookievalue.Length <= 8)
                {
                    num = cookievalue.Length;
                }
                else
                {
                    num = 8;
                }
                for (int i = 0; i < num; i++)
                {
                    resultvalue.Add(Convert.ToInt32(cookievalue[i].ToString()));
                }
            }
            return resultvalue;
        }
        #endregion
    }
}
