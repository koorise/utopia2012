using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.ProductPartsCache
{
    public partial class Manage : System.Web.UI.Page
    {
       
	#region PageLoad
	protected void Page_Load(object sender, EventArgs e)
	{
		BLL.SystemTree.CheckPermission("ProductPartsCache");
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
		GK2010.BLL.ProductPartsCache bll = new GK2010.BLL.ProductPartsCache();
		List<GK2010.Model.ProductPartsCache> models = bll.GetList(PageSize, PageIndex, ConfigParam.Keyword, "", out total);
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
			GK2010.Model.ProductPartsCache model = (GK2010.Model.ProductPartsCache)e.Row.DataItem;
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
		string UrlRedirect = ConfigUrl.AdminUrlSearch;
		UrlRedirect = string.Format(UrlRedirect,txtKey.Text);
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
