using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web
{
    public partial class ZPageBase_MainChannel : System.Web.UI.MasterPage
    {
        #region 控件变量
        public static EnumNavigator EnumNavigator = EnumNavigator.Index;
        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            Top1.EnumNavigator = EnumNavigator;

            #region 只有首页才显示友情链接
            if (EnumNavigator == EnumNavigator.Index)
            {
                BootFriendLink1.Visible = true;
            }
            else
            {
                BootFriendLink1.Visible = false;
            }
            #endregion
            
        }
        #endregion
        
    }
}
