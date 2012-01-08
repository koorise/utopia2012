using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.ProductMemberDiscount
{
    public partial class ManageMember : System.Web.UI.Page
    {

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("ProductMemberDiscount");
            if (!IsPostBack)
            {
                BindData();
            }
        }
        #endregion

        #region 绑定列表

        #region 绑定数据
        private void BindData()
        {
            if (ConfigParam.Keyword != "")
            {
                txtKey.Text = ConfigParam.Keyword;
            }
            int total = 0;
            int PageIndex = ConfigParam.Page;
            int PageSize = grid.PageSize;
            GK2010.BLL.Member bll = new GK2010.BLL.Member();
            List<GK2010.Model.Member> models = bll.GetList(PageSize, PageIndex, ConfigParam.Keyword, "member", out total);
            AspNetPager1.PageSize = PageSize;
            AspNetPager1.RecordCount = total;
            grid.DataKeyNames = "id".Split(',');
            grid.DataSource = models;
            grid.DataBind();
        }
        #endregion

        #region grid_RowDataBound
        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GK2010.Model.Member model = (GK2010.Model.Member)e.Row.DataItem;
                string UrlRedirect = string.Format("manage.aspx?UserID={0}&ReturnUrl={1}", model.ID, ConfigUrl.CurrentUrl);
                HyperLink HyperLinkModify = (HyperLink)e.Row.FindControl("HyperLinkModify");
                HyperLinkModify.NavigateUrl = UrlRedirect;
            }
        }
        #endregion

        #endregion

        #region 搜索
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string UrlRedirect = "ManageMember.aspx?Keyword={0}";
            UrlRedirect = string.Format(UrlRedirect, txtKey.Text);
            Response.Redirect(UrlRedirect);
        }
        #endregion
    }
}
