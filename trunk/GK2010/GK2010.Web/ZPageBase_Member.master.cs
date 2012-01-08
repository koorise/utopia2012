using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Common;
using GK2010.Utility;

namespace GK2010.Web
{
    public partial class ZPageBase_Member : System.Web.UI.MasterPage
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 判断是否登录
            if (!LoginHelper.HasLogin)
            {
                Response.Write("<script>top.location.href = \"/\";</script>");
                return;
            }
            #endregion

            if (!IsPostBack)
            {
                Model.Member member = LoginHelper.Member;
                if (member != null)
                {
                    litUserName.Text = member.UserName;
                    litGroupName.Text = BLL.MemberGroup.GetTitle(member.GroupID);
                    litCredit.Text = member.TotalJF.ToString();
                }
            }
        }
        #endregion
    }
}
