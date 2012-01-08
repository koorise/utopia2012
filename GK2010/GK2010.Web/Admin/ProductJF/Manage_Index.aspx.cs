using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.ProductJF
{
    public partial class Manage_Index : System.Web.UI.Page
    {

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("ProductJF");
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
            GK2010.BLL.ProductJF bll = new GK2010.BLL.ProductJF();
            List<GK2010.Model.ProductJF> models = bll.GetList(PageSize, PageIndex, ConfigParam.Keyword, "Index", out total);
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
                GK2010.Model.ProductJF model = (GK2010.Model.ProductJF)e.Row.DataItem;
                string UrlRedirect = string.Format(ConfigUrl.AdminUrlModify, model.ID, ConfigUrl.CurrentUrl);
                HyperLink HyperLinkModify = (HyperLink)e.Row.FindControl("HyperLinkModify");
                HyperLinkModify.NavigateUrl = UrlRedirect;
            }
        }
        #endregion

        #endregion


        #region 搜索
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string UrlRedirect = "Manage_Index.aspx?Keyword={0}";
            UrlRedirect = string.Format(UrlRedirect, txtKey.Text);
            Response.Redirect(UrlRedirect);
        }
        #endregion

        #region 保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= grid.Rows.Count - 1; i++)
            {
                TextBox txtSortID = (TextBox)grid.Rows[i].FindControl("txtSortID");
                BLL.ProductJF bll = new GK2010.BLL.ProductJF();
                Model.ProductJF model = bll.GetModel(IntHelper.Parse(grid.DataKeys[i].Value.ToString(), 0));
                if (model != null)
                {
                    model.IndexSortID = DecimalHelper.Parse(txtSortID.Text, 2000);
                    bll.Update(model);
                }
            }
            Response.Redirect(Request.RawUrl);
        }
        #endregion


    }
}
