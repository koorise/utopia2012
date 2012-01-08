using System;
using System.Collections.Generic;
using System.Text;
using GK2010.Utility;
using System.Net;
using System.IO;
namespace GK2010.Common
{
    public class MobileHelper
    {
        #region 发送短信
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="Mobile">手机号码</param>
        /// <param name="MailSendType">发送类型</param>
        /// <param name="modelMsgHelper">替换的值</param>
        /// <returns></returns>
        public static bool Send(string Mobile, EnumSendType EnumSendType, Model.MsgHelper modelMsgHelper)
        {
            if (Mobile.Length < 11)
            {
                return false;
            }

            //先获取邮件内容
            BLL.ConfigMessageMobile bll = new GK2010.BLL.ConfigMessageMobile();
            Model.ConfigMessageMobile model = bll.GetModel(EnumSendType.ToString());
            if (model != null)
            {
                string Content = model.Summary;
                Content = MsgHelper.Replace(Content, modelMsgHelper);               
                if (Content.Length == 0)
                {
                    return false;
                }

                return Send( Mobile, Content);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="Mobile">手机号码</param>
        /// <param name="Content">短信内容</param>
        /// <returns></returns>
        public static bool Send(string Mobile, string Content)
        {
            if (Mobile.Length < 11)
            {
                return false;
            }

            if (Content.Length == 0)
            {
                return false;
            }

            return WoxpSDK(Mobile, Content);
        }
        #endregion

        #region 调用东时方短信SDK
        /// <summary>
        /// 调用东时方短信SDK
        /// </summary>
        /// <returns></returns>
        public static bool WoxpSDK(string Mobile, string Content)
        {
            return false;
        }

        //调用时只需要把拼成的URL传给该函数即可。判断返回值即可
        /// <summary>
        /// 调用HTTP发送短信
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHtmlFromUrl(string url)
        {
            string strRet = null;
            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                strRet = ser.ReadToEnd();
            }
            catch
            {
                strRet = null;
            }
            return strRet;
        }
        #endregion
        
    }
}
