using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.Down
{
    public partial class Manage_ChannelFlag : System.Web.UI.Page
    {
       
	    #region PageLoad
	    protected void Page_Load(object sender, EventArgs e)
	    {
		    BLL.SystemTree.CheckPermission("Down");
		    if (!IsPostBack)
		    {
                GK2010.BLL.DownCategory bll = new GK2010.BLL.DownCategory();
                DropDownListHelper.Bind(dropCategory, "Title", "ID", bll.GetList("", ""));           

			    BindData();
		    }
	    }
	    #endregion

	    #region 绑定列表
    	
	    #region 绑定数据
	    private void BindData()
	    {
            string sql = "1=1";
		    if (ConfigParam.Keyword != "")
		    {
			    txtKey.Text = ConfigParam.Keyword;
                sql += " and Title like '%" + ConfigParam.Keyword + "%'";
		    }
            if (ConfigParam.CategoryID > 0)
            {
                dropCategory.SelectedValue = ConfigParam.CategoryID.ToString();
                sql += " and CategoryID = " + ConfigParam.CategoryID;
            }

            sql += " order by Channelflag desc,ChannelSortID asc,id desc";

		    int total = 0;
		    int PageIndex = ConfigParam.Page;
		    int PageSize = grid.PageSize;
		    GK2010.BLL.Down bll = new GK2010.BLL.Down();
            List<GK2010.Model.Down> models = bll.GetList(PageSize, PageIndex, sql, "AdminParam", out total);
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
			    GK2010.Model.Down model = (GK2010.Model.Down)e.Row.DataItem;
			    string UrlRedirect = string.Format(ConfigUrl.AdminUrlModify, model.ID, ConfigUrl.CurrentUrl);  
			    HyperLink HyperLinkModify = (HyperLink)e.Row.FindControl("HyperLinkModify");   
			    HyperLinkModify.NavigateUrl = UrlRedirect;
    			
			    UrlRedirect = string.Format(ConfigUrl.AdminUrlDelete, model.ID, ConfigUrl.CurrentUrl);
			    HyperLink HyperLinkDelete = (HyperLink)e.Row.FindControl("HyperLinkDelete"); 
			    HyperLinkDelete.NavigateUrl = UrlRedirect;
			    HyperLinkDelete.Attributes.Add("onclick", "return confirm('" + ResultMsg.DeleteConfirm + "')");


                if (model.ChannelFlag == 0)
                {
                    TextBox txtSortID = (TextBox)e.Row.FindControl("txtSortID");
                    txtSortID.Visible = false;
                }
		    }
	    }
	    #endregion

	    #endregion

	    #region 批量保存
        protected void btnSave_Click(object sender, EventArgs e)
	    {
		    for (int i = 0; i <= grid.Rows.Count - 1; i++)
		    {
                int ID = IntHelper.Parse(grid.DataKeys[i].Value.ToString(), 0);
                TextBox txtSortID = (TextBox)grid.Rows[i].FindControl("txtSortID");
                BLL.Down bll = new GK2010.BLL.Down();
                Model.Down model = bll.GetModel(ID);
                if (model != null)
                {
                    model.ChannelSortID = DecimalHelper.Parse(txtSortID.Text, 0);
                    bll.Update(model);
                }
		    }
		    Response.Redirect(Request.RawUrl);
	    }
	    #endregion

	    #region 搜索
	    protected void btnSearch_Click(object sender, EventArgs e)
	    {
            string UrlRedirect = "Manage_HotFlag.aspx?Keyword={0}&CategoryID={1}";
		    UrlRedirect = string.Format(UrlRedirect,txtKey.Text,dropCategory.SelectedValue);
		    Response.Redirect(UrlRedirect);
	    }
	    #endregion

        #region 新增
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string UrlRedirect = "add.aspx?ReturnUrl="+ConfigUrl.CurrentUrl;
            Response.Redirect(UrlRedirect);
        }
        #endregion

    }
}
