using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using GK2010.Utility;
namespace GK2010.Common
{
    #region 编辑器
    public class EditorHelper
    {
        /// <summary>
        /// 加载编辑器（会员及店铺后台）
        /// </summary>
        /// <param name="strControlDetailID">编辑器控件ID</param>
        /// <returns>编辑器系列代码</returns>
        public static string LoadMemberEditor(string strControlDetailID)
        {
            string strEditor = "";           
            if (strControlDetailID != "")
            {
                strEditor = "<script src=\"/editor.js\" type=\"text/javascript\" charset=\"utf-8\" ></script>";
                strEditor += "<script type=\"text/javascript\">";
                strEditor += "KE.show({";
                strEditor += "id:'" + strControlDetailID + "',";
                strEditor += "cssPath:'/css/editor.css',";
                strEditor += "items: [";
                strEditor += "'fontname', 'fontsize', '|', 'textcolor', 'bgcolor', 'bold', 'italic', 'underline',";
                strEditor += "'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',";
                strEditor += "'insertunorderedlist', '|', 'emoticons', 'image', 'link', 'source']";
                strEditor += "});";
                strEditor += "</script>";

                strEditor += "<style type=\"text/css\">";
                strEditor += "#" + strControlDetailID + "{width:640px; height:350px; visibility:hidden}";
                strEditor += "</style>";
            }
            return strEditor;
        }

        /// <summary>
        /// 加载编辑器(管理员后台)
        /// </summary>
        /// <param name="strControlDetailID">编辑器控件ID</param>
        /// <returns>编辑器系列代码</returns>
        public static string LoadAdminEditor(string strControlDetailID)
        {
            string strEditor = "";
            if (strControlDetailID != "")
            {
                strEditor = "<script src=\"/editor.js\" type=\"text/javascript\" charset=\"utf-8\" ></script>";
                strEditor += "<script type=\"text/javascript\">";
                strEditor += "KE.show({";
                strEditor += "id:'" + strControlDetailID + "',";
                strEditor += "cssPath:'/css/editor.css',";
                strEditor += "items: [";
                strEditor += "'fontname', 'fontsize', '|', 'textcolor', 'bgcolor', 'bold', 'italic', 'underline',";
                strEditor += "'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',";
                strEditor += "'insertunorderedlist', '|', 'emoticons', 'image', 'link', 'source']";
                strEditor += "});";
                strEditor += "</script>";

                strEditor += "<style type=\"text/css\">";
                strEditor += "#" + strControlDetailID + "{width:750px; height:350px; visibility:hidden}";
                strEditor += "</style>";
            }
            return strEditor;
        }
    }

    #endregion
}
