using System;
using System.Collections.Generic;
using System.Text;
using GK2010.Utility;
using System.Net;
using System.Web.UI.WebControls;
using System.IO;
namespace GK2010.Common
{
    /// <summary>
    /// 信息提示综合处理类
    /// </summary>
    public class MsgHelper
    {
        #region 错误信息发送

        /// <summary>
        /// 错误信息发送
        /// </summary>
        /// <param name="txtContent">出错提示控件</param>
        /// <param name="MsgType">出错类型</param>
        public static void SendError(Literal txtContent, string TitleEn)
        {
            Model.MsgHelper model = new GK2010.Model.MsgHelper();
            SendError(txtContent, TitleEn, model);
        }

        /// <summary>
        /// 错误信息发送
        /// </summary>
        /// <param name="txtContent">出错提示控件</param>
        /// <param name="MsgType">出错类型</param>
        /// <param name="model">替换信息</param>
        public static void SendError(Literal txtContent, string TitleEn, Model.MsgHelper model)
        {
            //错误详细信息
            string str = BLL.ConfigResultMsg.GetModel_Detail(TitleEn.ToString());
            str = Replace(str, model);

            //输出到前台
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("<div id=\"divError\" class=\"cer\">");
            //sb.AppendLine("<div class=\"zbj_safe_tips warning wp80\"><p class=\"f12 B mdTB13 red\">" + str + "</p></div>");
            //sb.AppendLine("</div>");

            sb.AppendLine("<div id=\"divError\" style=\"width: 95%; border: 1px solid #F69C9C; background: #FFF5F5; padding:5px; float: left;\">");
            sb.AppendLine("<div style=\"position: relative; margin: 0 auto;\">");
            sb.AppendLine("<div style=\"width: 24px; position: absolute; top: -18px; right: 5px;\"><img onclick=\"$('#divError').css('display','none');\" alt='关闭' style='cursor:pointer'  src=\"/images/share/error.gif\" alt=\"\" /></div>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div style=\"float: left; font-size: 12px; line-height: 21px; margin-top: 10px; margin-right: 15px;width: 95%; width: auto; color: #DB0606;\">");
            sb.AppendLine("<img src=\"/images/share/icon_remind.gif\" style=\"float: left; margin: 0px 6px;clear: both;\" />" + str);
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");   

            txtContent.Text = sb.ToString();

            //错误信息记录到数据库
        }
        #endregion

        #region 正确信息发送

        /// <summary>
        /// 正确信息发送
        /// </summary>
        /// <param name="txtContent">正确信息提示控件</param>
        /// <param name="MsgType">正确信息类型</param>
        public static void SendOK(Literal txtContent,string TitleEn)
        {
            Model.MsgHelper model = new GK2010.Model.MsgHelper();
            SendOK(txtContent, TitleEn, model);
        }

        /// <summary>
        /// 正确信息发送
        /// </summary>
        /// <param name="txtContent">正确信息提示控件</param>
        /// <param name="Type">正确信息类型</param>
        /// <param name="model">替换信息</param>
        public static void SendOK(Literal txtContent, string TitleEn, Model.MsgHelper model)
        {
            //详细信息
            string str = BLL.ConfigResultMsg.GetModel_Detail(TitleEn);
            str = Replace(str, model);

            //输出到前台
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div id=\"divOK\" class=\"zbj_safe_tips ok wp75\">");
            sb.AppendLine(str);
            sb.AppendLine("</div>");

            txtContent.Text = sb.ToString();
        }
        #endregion

        #region 替换字符
        /// <summary>
        /// 替换字符
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="model">待替换字符</param>
        /// <returns></returns>
        public static string Replace(string str, Model.MsgHelper model)
        {
            if (model.UserID != "") str = str.Replace("{UserID}", model.UserID);
            if (model.UserName != "") str = str.Replace("{UserName}", model.UserName);
            if (model.RealName != "") str = str.Replace("{RealName}", model.RealName);
            if (model.Mobile != "") str = str.Replace("{Mobile}", model.Mobile);
            if (model.MobileUrlModify != "") str = str.Replace("{MobileUrlModify}", model.MobileUrlModify);            
            if (model.Email != "") str = str.Replace("{Email}", model.Email);
            if (model.EmailUrlModify != "") str = str.Replace("{EmailUrlModify}", model.EmailUrlModify);
            if (model.EmailUrl != "") str = str.Replace("{EmailUrl}", model.EmailUrl);
            if (model.ActiveUrl != "") str = str.Replace("{ActiveUrl}", model.ActiveUrl);
            if (model.ActiveCode != "") str = str.Replace("{ActiveCode}", model.ActiveCode);
            if (model.Now != "") str = str.Replace("{Now}", model.Now);
            if (model.YYYYMMDD != "") str = str.Replace("{YYYYMMDD}", model.YYYYMMDD);

            return str;
        }
        #endregion
    }
}
