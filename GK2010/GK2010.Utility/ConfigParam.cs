using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI;

namespace GK2010.Utility
{
    public class ConfigParam
    {

        #region Action
        /// <summary>
        /// Action
        /// </summary>
        public static string Action
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["Action"];
                if (o != null && o.ToString() != "")
                {
                    return o.ToString();
                }
                else
                {
                    return "";
                }
            }
        }

        #endregion

        #region ProductTitle
        /// <summary>
        /// ����
        /// </summary>
        public static string Title
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["Title"];
                if (o != null && o.ToString() != "")
                {
                    return o.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        #endregion

        #region UserName
        /// <summary>
        /// �û���
        /// </summary>
        public static string UserName
        {
            get
            {
                return GetStrGet("UserName");
            }
        }
        #endregion

        #region Email
        /// <summary>
        /// ����
        /// </summary>
        public static string Email
        {
            get
            {
                return GetStrGet("Email");
            }
        }
        #endregion

        #region Mobile
        /// <summary>
        /// �ֻ�
        /// </summary>
        public static string Mobile
        {
            get
            {
                return GetStrGet("Mobile");
            }
        }
        #endregion

        #region ActiveCode
        /// <summary>
        /// ������
        /// </summary>
        public static string ActiveCode
        {
            get
            {
                return GetStrGet("ActiveCode");
            }
        }
        #endregion        

        #region UserID
        /// <summary>
        /// ��Ա���
        /// </summary>
        public static int UserID
        {
            get
            {
                return GetIntGet("UserID", 0);
            }
        }
        #endregion

        #region MemberID
        public static int MemberID
        {
            get
            {
                return GetIntGet("MemberID", 0);
            }
        }
        #endregion

        #region Admin
        public static object Admin
        {
            get
            {               
                return HttpContext.Current.Session["Admin"];               
            }
            set
            {
                HttpContext.Current.Session["Admin"] = value;
            }
        }
        #endregion

        #region Member
        public static object Member
        {
            get
            {
                return HttpContext.Current.Session["Member"];
            }
            set
            {
                HttpContext.Current.Session["Member"] = value;
            }
        }
        #endregion

        #region ID   
        public static int ID
        {
            get
            {
                return GetIntGet("ID",0);
            }
        }
        #endregion

        #region CategoryID
        public static int CategoryID
        {
            get
            {
                return GetIntGet("CategoryID", 0);
            }
        }
        #endregion

        #region OrderType
        public static int OrderType
        {
            get
            {
                //0����id desc��1�������� hits desc��2���ս��� hotFlag desc,3�����Ƽ� commendflag desc
                return GetIntGet("OrderType", 0);
            }
        }
        #endregion

        #region IndexFlag
        public static int IndexFlag
        {
            get
            {
                return GetIntGet("IndexFlag",-1);
            }
        }
        #endregion


        #region ChannelFlag
        public static int ChannelFlag
        {
            get
            {
                return GetIntGet("ChannelFlag", -1);
            }
        }
        #endregion


        #region CommendFlag
        public static int CommendFlag
        {
            get
            {
                return GetIntGet("CommendFlag", -1);
            }
        }
        #endregion


        #region HotFlag
        public static int HotFlag
        {
            get
            {
                return GetIntGet("HotFlag", -1);
            }
        }
        #endregion


        #region BigID
        public static int BigID
        {
            get
            {
                return GetIntGet("BigID", 0);
            }
        }
        #endregion

        #region SmallID
        public static int SmallID
        {
            get
            {
                return GetIntGet("SmallID", 0);
            }
        }
        #endregion

        #region ApplicationFlag
        public static int ApplicationFlag
        {
            get
            {
                return GetIntGet("ApplicationFlag", 0);
            }
        }
        #endregion

        #region FirstCategoryID
        public static int FirstCategoryID
        {
            get
            {
                return GetIntGet("FirstCategoryID", 0);
            }
        }
        #endregion

        #region SecondCategoryID
        public static int SecondCategoryID
        {
            get
            {
                return GetIntGet("SecondCategoryID", 0);
            }
        }
        #endregion
        

        #region ProductID
        public static int ProductID
        {
            get
            {
                return GetIntGet("ProductID", 1);
            }
        }
        #endregion


        #region ParentID
        public static int ParentID
        {
            get
            {
                return GetIntGet("ParentID",0);
            }
        }
        #endregion

        #region PhotoID
        public static int PhotoID
        {
            get
            {
                return GetIntGet("PhotoID", 0);
            }
        }
        #endregion

        #region IDs
        public static string IDs
        {
            get
            {
                return GetStrGet("IDs");
            }
        }
        #endregion

        #region ProvinceID
        public static string ProvinceID
        {
            get
            {
                return GetStrGet("ProvinceID");
            }
        }
        #endregion

        #region CityID
        public static string CityID
        {
            get
            {
                return GetStrGet("CityID");
            }
        }
        #endregion

        #region MsgTitle
        public static string MsgTitle
        {
            get
            {
                return GetStrGet("MsgTitle");
            }
        }
        #endregion

        #region MsgDetail
        public static string MsgDetail
        {
            get
            {
                return GetStrGet("MsgDetail");
            }
        }
        #endregion

        #region MsgUrl
        public static string MsgUrl
        {
            get
            {
                return GetStrGet("MsgUrl");
            }
        }
        #endregion

        #region Tag
        public static string Tag
        {
            get
            {
                return GetStrGet("Tag");
            }
        }
        #endregion

        #region CheckCode
        public static string CheckCode
        {
            get
            {
                if (HttpContext.Current.Session["CheckCode"] != null && HttpContext.Current.Session["CheckCode"].ToString() != "")
                {
                    return HttpContext.Current.Session["CheckCode"].ToString().ToLower();
                }
                else
                {
                    return "";
                }
            }
        }
        #endregion

        #region Type
        public static string Type
        {
            get
            {
                return GetStrGet("Type");
            }
        }
        #endregion

        #region callback
        public static string callback
        {
            get
            {
                return GetStrGet("callback");
            }
        }
        #endregion

        #region Page
        public static int Page
        {
            get
            {
                return GetIntGet("Page",1);
            }
        }
        #endregion

        #region ShowType
        public static int ShowType
        {
            get
            {
                return GetIntGet("ShowType", 0);
            }
        }
        #endregion

        #region Flag
        public static int Flag
        {
            get
            {
                return GetIntGet("Flag", 0);
            }
        }
        #endregion

        #region AttachmentFlag
        public static int AttachmentFlag
        {
            get
            {
                return GetIntGet("AttachmentFlag", 0);
            }
        }
        #endregion
        
        

        #region �ؼ���
        public static string Keyword
        {
            get
            {
                return GetStrGet("Keyword");
            }
        }
        #endregion

        #region �������

        #region �������ID
        public static string Result
        {
            get
            {
                return GetStrGet("Result");
            }
        }
        #endregion

        #region �������ID
        public static int ResultID
        {
            get
            {
                return GetIntGet("ResultID");
            }
        }
        #endregion

        #region ����������
        public static string ResultType
        {
            get
            {
                return GetStrGet("ResultType");
            }
        }
        #endregion

        #region ���������ʾ��
        public static string ResultMsg
        {
            get
            {
                return GetStrGet("ResultMsg");
            }
        }
        #endregion
        #endregion
       
        #region ���ص�ַ
        public static string ReturnUrl
        {
            get
            {
                return GetStrGet("ReturnUrl");
            }
        }
        #endregion

        #region ���ص�ַ
        public static string UrlBack
        {
            get
            {
                return GetStrGet("UrlBack");
            }
        }
        #endregion

        #region ���ص�ַ
        public static string UrlGo
        {
            get
            {
                return GetStrGet("UrlGo");
            }
        }
        #endregion

        #region ������Ϣ
        public static string ErrorMsg
        {
            get
            {
                return GetStrGet("ErrorMsg");
            }
        }
        #endregion

        #region IP
        public static string IP
        {
            get
            {
                if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null
                    && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString() != "")
                {
                    return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                }
                else
                {
                    return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
            }
        }
        #endregion

        #region ��ȡ���β���
        public static int GetIntGet(string strParam)
        {
            return GetIntGet(strParam,-1);
        }

        /// <summary>
        /// ��ȡ���β���
        /// </summary>
        public static int GetIntGet(string strParam,int defaultValue)
        {
            object o = HttpContext.Current.Request.QueryString[strParam];
            if (o != null && o.ToString() != "")
            {
                try
                {
                    return int.Parse(o.ToString());
                }
                catch
                {
                    return defaultValue;
                }
            }
            else
            {
                return defaultValue;
            }            
        }
        #endregion

        #region ��ȡ�ַ�����
        /// <summary>
        /// ��ȡ���β���
        /// </summary>
        public static string GetStrGet(string strParam)
        {
            object o = HttpContext.Current.Request.QueryString[strParam];
            if (o != null && o.ToString() != "")
            {
                try
                {
                    return o.ToString();
                }
                catch
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region ��ȡ���β���(Post)
        public static int GetIntPost(string strParam)
        {
            return GetIntPost(strParam, -1);
        }

        /// <summary>
        /// ��ȡ���β���(Post)
        /// </summary>
        public static int GetIntPost(string strParam, int defaultValue)
        {
            object o = HttpContext.Current.Request[strParam];
            if (o != null && o.ToString() != "")
            {
                try
                {
                    return int.Parse(o.ToString());
                }
                catch
                {
                    return defaultValue;
                }
            }
            else
            {
                return defaultValue;
            }
        }
        #endregion

        #region ��ȡ�ַ�����(Post)
        /// <summary>
        /// ��ȡ�ַ�����
        /// </summary>
        public static string GetStrPost(string strParam)
        {
            object o = HttpContext.Current.Request[strParam];
            if (o != null && o.ToString() != "")
            {
                try
                {
                    return o.ToString();
                }
                catch
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        #endregion
        
    }
}
