using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.AD
{
    public partial class Manage : System.Web.UI.Page
    {
       
	    #region PageLoad
	    protected void Page_Load(object sender, EventArgs e)
	    {
		    BLL.SystemTree.CheckPermission("AD");
		    if (!IsPostBack)
		    {
                GK2010.BLL.ADCategory bll = new GK2010.BLL.ADCategory();
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

            #region 参数
            if (ConfigParam.IndexFlag > -1)
            {
                AdminParamSearch1.IndexFlag = ConfigParam.IndexFlag;
                sql += " and IndexFlag = " + ConfigParam.IndexFlag;
            }
            if (ConfigParam.CommendFlag > -1)
            {
                AdminParamSearch1.CommendFlag = ConfigParam.CommendFlag;
                sql += " and CommendFlag = " + ConfigParam.CommendFlag;
            }
            if (ConfigParam.ChannelFlag > -1)
            {
                AdminParamSearch1.ChannelFlag = ConfigParam.ChannelFlag;
                sql += " and ChannelFlag = " + ConfigParam.ChannelFlag;
            }
            if (ConfigParam.HotFlag > -1)
            {
                AdminParamSearch1.HotFlag = ConfigParam.HotFlag;
                sql += " and HotFlag = " + ConfigParam.HotFlag;
            }
            #endregion

		    int total = 0;
		    int PageIndex = ConfigParam.Page;
		    int PageSize = grid.PageSize;
		    GK2010.BLL.AD bll = new GK2010.BLL.AD();
            List<GK2010.Model.AD> models = bll.GetList(PageSize, PageIndex, sql, "Admin", out total);
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
			    GK2010.Model.AD model = (GK2010.Model.AD)e.Row.DataItem;
			    string UrlRedirect = string.Format(ConfigUrl.AdminUrlModify, model.ID, ConfigUrl.CurrentUrl);  
			    HyperLink HyperLinkModify = (HyperLink)e.Row.FindControl("HyperLinkModify");   
			    HyperLinkModify.NavigateUrl = UrlRedirect;
    			
			    UrlRedirect = string.Format(ConfigUrl.AdminUrlDelete, model.ID, ConfigUrl.CurrentUrl);
			    HyperLink HyperLinkDelete = (HyperLink)e.Row.FindControl("HyperLinkDelete"); 
			    HyperLinkDelete.NavigateUrl = UrlRedirect;
			    HyperLinkDelete.Attributes.Add("onclick", "return confirm('" + ResultMsg.DeleteConfirm + "')");
		    }
	    }
	    #endregion

	    #endregion

	    #region 批量删除
	    protected void btnDelete_Click(object sender, EventArgs e)
	    {
		    string strIDs = "";
		    for (int i = 0; i <= grid.Rows.Count - 1; i++)
		    {
			    CheckBox chkID = (CheckBox)grid.Rows[i].FindControl("chkID");
			    if (chkID.Checked)
			    {
				    strIDs += grid.DataKeys[i].Value.ToString() + ",";
			    }
		    }
		    strIDs = StringHelper.DelLastChar(strIDs);
		    string UrlRedirect = string.Format(ConfigUrl.AdminUrlDeleteBatch, strIDs, ConfigUrl.CurrentUrl); 
		    Response.Redirect(UrlRedirect);
	    }
	    #endregion

	    #region 搜索
	    protected void btnSearch_Click(object sender, EventArgs e)
	    {
            string UrlRedirect = "manage.aspx?Keyword={0}&CategoryID={1}&IndexFlag={2}&ChannelFlag={3}&CommendFlag={4}&HotFlag={5}";
            UrlRedirect = string.Format(UrlRedirect, txtKey.Text, dropCategory.SelectedValue, AdminParamSearch1.IndexFlag, AdminParamSearch1.ChannelFlag, AdminParamSearch1.CommendFlag, AdminParamSearch1.HotFlag);
		    Response.Redirect(UrlRedirect);
	    }
	    #endregion

	    #region 新增
	    protected void btnAdd_Click(object sender, EventArgs e)
	    {
		    string UrlRedirect = "add.aspx";
		    Response.Redirect(UrlRedirect);
	    }
	    #endregion


    }
}
