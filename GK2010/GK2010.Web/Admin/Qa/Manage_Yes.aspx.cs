using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.Qa
{
    public partial class Manage_Yes : System.Web.UI.Page
    {
       
	    #region PageLoad
	    protected void Page_Load(object sender, EventArgs e)
	    {
		    BLL.SystemTree.CheckPermission("Qa");
		    if (!IsPostBack)
		    {
                GK2010.BLL.QaCategory bll = new GK2010.BLL.QaCategory();
                DropDownListHelper.Bind(dropCategory, "Title", "ID", bll.GetList("", ""));           

			    BindData();
		    }
	    }
	    #endregion

	    #region 绑定列表
    	
	    #region 绑定数据
	    private void BindData()
	    {
            string sql = "checkflag=1";
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

            sql += " order by id desc";

		    int total = 0;
		    int PageIndex = ConfigParam.Page;
		    int PageSize = grid.PageSize;
		    GK2010.BLL.Qa bll = new GK2010.BLL.Qa();
            List<GK2010.Model.Qa> models = bll.GetList(PageSize, PageIndex, sql, "AdminParam", out total);
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
			    GK2010.Model.Qa model = (GK2010.Model.Qa)e.Row.DataItem;
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

	    #region 搜索
	    protected void btnSearch_Click(object sender, EventArgs e)
	    {
            string UrlRedirect = "Manage_Yes.aspx?Keyword={0}&CategoryID={1}";
		    UrlRedirect = string.Format(UrlRedirect,txtKey.Text,dropCategory.SelectedValue);
		    Response.Redirect(UrlRedirect);
	    }
	    #endregion

       

    }
}
