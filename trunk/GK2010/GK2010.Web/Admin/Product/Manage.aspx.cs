using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.Product
{
    public partial class Manage : System.Web.UI.Page
    {
        //小类别
        public string SmallID = "";
       
	    #region PageLoad
	    protected void Page_Load(object sender, EventArgs e)
	    {
		    BLL.SystemTree.CheckPermission("Product");
		    if (!IsPostBack)
		    {
                BLL.ProductCategory bll = new GK2010.BLL.ProductCategory();
                DropDownListHelper.Bind(dropBig, "Title", "ID", bll.GetList("0", "ParentID"));

                dropSmall.Items.Clear();
                dropSmall.Items.Insert(0, new ListItem("请选择", "0"));

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
            if (ConfigParam.BigID > 0)
            {
                dropBig.SelectedValue = ConfigParam.BigID.ToString();

                BLL.ProductCategory bllProductCategory = new GK2010.BLL.ProductCategory();
                DropDownListHelper.Bind(dropSmall, "Title", "ID", bllProductCategory.GetList(dropBig.SelectedValue, "ParentID"));

                sql += " and RootID = " + ConfigParam.BigID;
            }

            if (ConfigParam.SmallID > 0)
            {
                dropSmall.SelectedValue = ConfigParam.SmallID.ToString();
                sql += " and CategoryID = " + ConfigParam.SmallID;
            }

		    int total = 0;
		    int PageIndex = ConfigParam.Page;
		    int PageSize = grid.PageSize;
		    GK2010.BLL.Product bll = new GK2010.BLL.Product();
            List<GK2010.Model.Product> models = bll.GetList(PageSize, PageIndex, sql, "Admin", out total);
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
			    GK2010.Model.Product model = (GK2010.Model.Product)e.Row.DataItem;
			    string UrlRedirect = string.Format(ConfigUrl.AdminUrlModify, model.ID, ConfigUrl.CurrentUrl);  
			    HyperLink HyperLinkModify = (HyperLink)e.Row.FindControl("HyperLinkModify");   
			    HyperLinkModify.NavigateUrl = UrlRedirect;
    			
			    UrlRedirect = string.Format(ConfigUrl.AdminUrlDelete, model.ID, ConfigUrl.CurrentUrl);
			    HyperLink HyperLinkDelete = (HyperLink)e.Row.FindControl("HyperLinkDelete"); 
			    HyperLinkDelete.NavigateUrl = UrlRedirect;
			    HyperLinkDelete.Attributes.Add("onclick", "return confirm('" + ResultMsg.DeleteConfirm + "')");

                if (model.DiyFlag == 1)
                {
                    Literal txtParts = (Literal)e.Row.FindControl("txtParts");
                    txtParts.Text = "<a id='btnParts"+model.ID+"' href=\"javascript:void(0)\" >[部件]</a>";
                }
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
            Response.Redirect("manage.aspx?BigID=" + dropBig.SelectedValue + "&SmallID=" + dropSmall.SelectedValue + "&Keyword=" + txtKey.Text);
	    }
	    #endregion

	    #region 新增
	    protected void btnAdd_Click(object sender, EventArgs e)
	    {
		    string UrlRedirect = "add.aspx";
		    Response.Redirect(UrlRedirect);
	    }
	    #endregion

        #region 类别
        protected void dropBig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropBig.SelectedValue != "0")
            {
                BLL.ProductCategory bll = new GK2010.BLL.ProductCategory();
                DropDownListHelper.Bind(dropSmall, "Title", "ID", bll.GetList(dropBig.SelectedValue, "ParentID"));
                Response.Redirect("manage.aspx?BigID=" + dropBig.SelectedValue + "&Keyword=" + txtKey.Text);
            }
            else
            {
                dropSmall.Items.Clear();
                dropSmall.Items.Insert(0, new ListItem("请选择","0"));
                Response.Redirect("manage.aspx?Keyword=" + txtKey.Text);                
            }
                
        }

        protected void dropSmall_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropSmall.SelectedValue != "0")
            {
                Response.Redirect("manage.aspx?BigID=" + dropBig.SelectedValue + "&SmallID=" + dropSmall.SelectedValue + "&Keyword=" + txtKey.Text);
            }
            else
            {
                Response.Redirect("manage.aspx?BigID=" + dropBig.SelectedValue + "&Keyword=" + txtKey.Text);
            }
        }
        #endregion

    }
}
