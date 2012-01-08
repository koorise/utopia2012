using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GK2010.Utility
{
	public class MessageBox
	{
		private MessageBox() { }

		/// <summary>
		/// 显示消息提示对话框
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		public static void ShowAlert(Page page, string msg)
		{
           // page.ClientScript.RegisterStartupScript(page.GetType() ,"message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
            page.RegisterStartupScript("message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
		}

		/// <summary>
		/// 控件点击 消息确认提示框
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		public static void ShowConfirm(WebControl Control, string msg)
		{
			//Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
			Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
		}

		/// <summary>
		/// 显示消息提示对话框，并进行页面跳转
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		/// <param name="url">跳转的目标URL</param>
		public static void ShowAlertAndRedirect(Page page, string msg, string url)
		{
			StringBuilder Builder = new StringBuilder();
			Builder.Append("<script language='javascript' defer>");
			Builder.AppendFormat("alert('{0}');", msg);
			Builder.AppendFormat("location.href='{0}'", url);
			Builder.Append("</script>");
			page.RegisterStartupScript("message", Builder.ToString());

		}

		/// <summary>
		/// 输出自定义脚本信息
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="script">输出脚本</param>
		public static void ResponseScript(Page page, string script)
		{
			page.RegisterStartupScript("message", "<script language='javascript' defer>" + script + "</script>");
		}

		/// <summary>
		/// 显示消息
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="controlID">显示控件ID,默认为"lbMsg"</param>
		/// <param name="msg">输出脚本</param>
		public static void ShowMessage(Page page, string controlID, string msg)
		{
			ShowMessage(page, controlID, msg, State.Unkown);
		}

		/// <summary>
		/// 显示消息
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="controlID">显示控件ID,默认为"lbMsg"</param>
		/// <param name="msg">输出脚本</param>
		/// <param name="state">0-success;1-warning;2-error.</param>
		public static void ShowMessage(Page page, string controlID, string msg, State state)
		{
			if (controlID ==null || controlID.ToString() == "")
			{
				controlID = "lbMsg";
			}
			WebControl control = (WebControl)page.FindControl(controlID);
			if (control == null)
			{
				msg = System.Text.RegularExpressions.Regex.Replace(msg, "<[^>]+>", "");
				ShowAlert(page, msg);
			}
			else
			{
				page.RegisterStartupScript("message", "<script language='javascript' defer>document.getElementById('" + control.ClientID + "').innerHTML='" + msg + "';</script>");
				if (state == State.Success)
				{
					control.CssClass = "success";
				}
				else if (state == State.Warning)
				{
					control.CssClass = "warning";
				}
				else if (state == State.Error)
				{
					control.CssClass = "error";
				}
			}
		}
	}
}
