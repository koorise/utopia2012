using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web
{
    public partial class register_active : System.Web.UI.Page
    {
        
        #region 邮箱验证
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int UserID = ConfigParam.UserID;
                string strEmail = ConfigParam.Email;
                string strActiveCode = ConfigParam.ActiveCode;

                BLL.MemberValid bllMember = new GK2010.BLL.MemberValid();
                if (bllMember.Operator(UserID, EnumSendType.Valid, strEmail, strActiveCode))
                {
                    Response.Redirect("/register_step3.aspx");
                }
                else
                {
                    Response.Write("激活失败！");
                    Response.End();
                }
            }
        }
        #endregion
    }
}
