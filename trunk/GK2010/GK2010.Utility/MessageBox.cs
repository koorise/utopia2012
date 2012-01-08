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
		/// ��ʾ��Ϣ��ʾ�Ի���
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="msg">��ʾ��Ϣ</param>
		public static void ShowAlert(Page page, string msg)
		{
           // page.ClientScript.RegisterStartupScript(page.GetType() ,"message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
            page.RegisterStartupScript("message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
		}

		/// <summary>
		/// �ؼ���� ��Ϣȷ����ʾ��
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="msg">��ʾ��Ϣ</param>
		public static void ShowConfirm(WebControl Control, string msg)
		{
			//Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
			Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
		}

		/// <summary>
		/// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����ת
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="msg">��ʾ��Ϣ</param>
		/// <param name="url">��ת��Ŀ��URL</param>
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
		/// ����Զ���ű���Ϣ
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="script">����ű�</param>
		public static void ResponseScript(Page page, string script)
		{
			page.RegisterStartupScript("message", "<script language='javascript' defer>" + script + "</script>");
		}

		/// <summary>
		/// ��ʾ��Ϣ
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="controlID">��ʾ�ؼ�ID,Ĭ��Ϊ"lbMsg"</param>
		/// <param name="msg">����ű�</param>
		public static void ShowMessage(Page page, string controlID, string msg)
		{
			ShowMessage(page, controlID, msg, State.Unkown);
		}

		/// <summary>
		/// ��ʾ��Ϣ
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="controlID">��ʾ�ؼ�ID,Ĭ��Ϊ"lbMsg"</param>
		/// <param name="msg">����ű�</param>
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
