using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web
{
    public partial class ZSiteBaseAdmin : System.Web.UI.MasterPage
    {
        #region 控件及变量
        /// <summary>
        /// 编辑器控件的ID
        /// </summary>
        public static string strControlDetailID = "";
        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 检查后台管理权限
            if (!LoginHelper.IsAdmin)
            {
                Response.Write("您不是网站后台管理员，无权操作！");
                Response.End();
            }
            #endregion

            #region 加载编辑器
            txtEditor.Text = EditorHelper.LoadAdminEditor(strControlDetailID);
            #endregion
        }
        #endregion
    }
}
