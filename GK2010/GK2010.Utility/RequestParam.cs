using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;

namespace GK2010.Utility
{
   public class RequestParam:Page
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

        #region ConsigneeCompany
        /// <summary>
        /// ConsigneeCompany
        /// </summary>
        public static string ConsigneeCompany
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["ConsigneeCompany"];
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

        #region ConsigneeRealName
        /// <summary>
        /// ConsigneeRealName
        /// </summary>
        public static string ConsigneeRealName
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["ConsigneeRealName"];
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

        #region ConsigneeAddress
        /// <summary>
        /// ConsigneeAddress
        /// </summary>
        public static string ConsigneeAddress
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["ConsigneeAddress"];
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

        #region ConsigneePostCode
        /// <summary>
        /// ConsigneePostCode
        /// </summary>
        public static string ConsigneePostCode
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["ConsigneePostCode"];
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

        #region ConsigneeTelephone
        /// <summary>
        /// ConsigneeTelephone
        /// </summary>
        public static string ConsigneeTelephone
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["ConsigneeTelephone"];
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

        #region ConsigneeMobile
        /// <summary>
        /// ConsigneeMobile
        /// </summary>
        public static string ConsigneeMobile
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["ConsigneeMobile"];
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

        #region ConsigneeEmail
        /// <summary>
        /// ConsigneeEmail
        /// </summary>
        public static string ConsigneeEmail
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["ConsigneeEmail"];
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

        #region ConsigneeProvince
        /// <summary>
        /// ConsigneeProvince
        /// </summary>
        public static string ConsigneeProvince
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["ConsigneeProvince"];
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

        #region ConsigneeCity
        /// <summary>
        /// ConsigneeCity
        /// </summary>
        public static string ConsigneeCity
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["ConsigneeCity"];
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

        #region ConsigneeArae
        /// <summary>
        /// ConsigneeArae
        /// </summary>
        public static string ConsigneeArae
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["ConsigneeArae"];
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

        #region ConsigneeID
        /// <summary>
        /// ConsigneeID
        /// </summary>
        public static int ConsigneeID
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["ConsigneeID"];
                if (o != null && o.ToString() != "")
                {
                    return int.Parse(o.ToString());
                }
                else
                {
                    return 0;
                }
            }
        }

        #endregion


        #region InvoiceID
        /// <summary>
        /// InvoiceID
        /// </summary>
        public static int InvoiceID
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["InvoiceID"];
                if (o != null && o.ToString() != "")
                {
                    return int.Parse(o.ToString());
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion


        #region InvoiceMailID
        /// <summary>
        /// InvoiceMailID
        /// </summary>
        public static int InvoiceMailID
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["InvoiceMailID"];
                if (o != null && o.ToString() != "")
                {
                    return int.Parse(o.ToString());
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion

        #region InvoiceMailCompany
        /// <summary>
        /// InvoiceMailCompany
        /// </summary>
        public static string InvoiceMailCompany
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["InvoiceMailCompany"];
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

        #region InvoiceMailAddress
        /// <summary>
        /// InvoiceMailAddress
        /// </summary>
        public static string InvoiceMailAddress
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["InvoiceMailAddress"];
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

        #region InvoiceMailTelephone
        /// <summary>
        /// InvoiceMailTelephone
        /// </summary>
        public static string InvoiceMailTelephone
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["InvoiceMailTelephone"];
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

        #region InvoiceMailRealName
        /// <summary>
        /// InvoiceMailRealName
        /// </summary>
        public static string InvoiceMailRealName
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["InvoiceMailRealName"];
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

        #region InvoiceMailProvince
        /// <summary>
        /// InvoiceMailProvince
        /// </summary>
        public static string InvoiceMailProvince
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["InvoiceMailProvince"];
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

        #region InvoiceMailCity
        /// <summary>
        /// InvoiceMailCity
        /// </summary>
        public static string InvoiceMailCity
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["InvoiceMailCity"];
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

        #region InvoiceMailArae
        /// <summary>
        /// InvoiceMailArae
        /// </summary>
        public static string InvoiceMailArae
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["InvoiceMailArae"];
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

        #region InvoiceMailPostCode
        /// <summary>
        /// InvoiceMailPostCode
        /// </summary>
        public static string InvoiceMailPostCode
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["InvoiceMailPostCode"];
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

        #region InvoiceMailMobile
        /// <summary>
        /// InvoiceMailMobile
        /// </summary>
        public static string InvoiceMailMobile
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["InvoiceMailMobile"];
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

        #region InvoiceMailEmail
        /// <summary>
        /// InvoiceMailEmail
        /// </summary>
        public static string InvoiceMailEmail
        {
            get
            {
                object o = HttpContext.Current.Request.QueryString["InvoiceMailEmail"];
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
    }
}
