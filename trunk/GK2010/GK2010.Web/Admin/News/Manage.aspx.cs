using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.News
{
    public partial class Manage : System.Web.UI.Page
    {
       
	    #region PageLoad
	    protected void Page_Load(object sender, EventArgs e)
	    {
		    BLL.SystemTree.CheckPermission("News");
		    if (!IsPostBack)
		    {
                GK2010.BLL.NewsCategory bll = new GK2010.BLL.NewsCategory();
                DropDownListHelper.Bind(dropCategory, "Title", "ID", bll.GetList("", ""));           

			    BindData();
		    }
	    }
	    #endregion

	    #region ���б�
    	
	    #region ������
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

            #region ����
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
		    GK2010.BLL.News bll = new GK2010.BLL.News();
            List<GK2010.Model.News> models = bll.GetList(PageSize, PageIndex, sql, "Admin", out total);
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
			    GK2010.Model.News model = (GK2010.Model.News)e.Row.DataItem;
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

	    #region ����ɾ��
	    protected void btnDelete_Click(object sender, EventArgs e)
	    {
            int n = 0;
		    for (int i = 0; i <= grid.Rows.Count - 1; i++)
		    {
			    CheckBox chkID = (CheckBox)grid.Rows[i].FindControl("chkID");
			    if (chkID.Checked)
			    {
                    BLL.News bll = new GK2010.BLL.News();
                    bll.Delete(int.Parse(grid.DataKeys[i].Value.ToString()));
                    n++;
			    }
		    }

            if (n > 0)
            {
                MessageBox.ShowAlert(this.Page, "�ɹ�ɾ��"+n+"����¼��");
                BindData();
            }
            else
            {
                MessageBox.ShowAlert(this.Page, "û��ɾ���κμ�¼��");
            }		    
	    }
	    #endregion

	    #region ����
	    protected void btnSearch_Click(object sender, EventArgs e)
	    {
            string UrlRedirect = "manage.aspx?Keyword={0}&CategoryID={1}&IndexFlag={2}&ChannelFlag={3}&CommendFlag={4}&HotFlag={5}";
            UrlRedirect = string.Format(UrlRedirect, txtKey.Text, dropCategory.SelectedValue, AdminParamSearch1.IndexFlag, AdminParamSearch1.ChannelFlag, AdminParamSearch1.CommendFlag, AdminParamSearch1.HotFlag);
		    Response.Redirect(UrlRedirect);
	    }
	    #endregion

	    #region ����
	    protected void btnAdd_Click(object sender, EventArgs e)
	    {
		    string UrlRedirect = "add.aspx";
		    Response.Redirect(UrlRedirect);
	    }
	    #endregion


    }
}
