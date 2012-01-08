using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.SystemPermission
{
    public partial class manage : System.Web.UI.Page
    {
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("SystemPermission");
            if (!IsPostBack)
            {
                PageCommon.GridViewSetProperty(grid);
                BindData();
            }
        }
        #endregion

        #region 绑定列表

        #region 绑定数据
        private void BindData()
        {            
            GK2010.BLL.MemberGroup bll = new GK2010.BLL.MemberGroup();
            List<GK2010.Model.MemberGroup> models = bll.GetList("", "Type");           
            grid.DataSource = models;
            grid.DataBind();
        }
        #endregion

        #region grid_RowDataBound
        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GK2010.Model.MemberGroup model = (GK2010.Model.MemberGroup)e.Row.DataItem;
                string UrlRedirect = string.Format(ConfigUrl.AdminUrlModify, model.ID, ConfigUrl.CurrentUrl);
                HyperLink HyperLinkModify = (HyperLink)e.Row.FindControl("HyperLinkModify");
                HyperLinkModify.NavigateUrl = UrlRedirect;
            }
        }
        #endregion

        #endregion
    }
}
