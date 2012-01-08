using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.ProductCategory
{
    public partial class Manage : System.Web.UI.Page
    {
        #region PageLoad
		protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("ProductCategory");
			if (!IsPostBack)
			{
                GK2010.BLL.ProductCategory bll = new GK2010.BLL.ProductCategory();
                RepeaterList.DataSource = bll.GetListNew();
                RepeaterList.DataBind();
			}
		}
        #endregion
		
		#region 新增
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			string UrlRedirect = "add.aspx";
			Response.Redirect(UrlRedirect);
		}
		#endregion

        #region 保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in RepeaterList.Items)
            {
                HtmlInputHidden txtID = (HtmlInputHidden)item.FindControl("txtID");
                HtmlInputText txtSortID = (HtmlInputText)item.FindControl("txtSortID");
                HtmlInputText txtTitleEn = (HtmlInputText)item.FindControl("txtTitleEn");
                GK2010.BLL.ProductCategory bll = new GK2010.BLL.ProductCategory();
                GK2010.Model.ProductCategory model = bll.GetModel(int.Parse(txtID.Value));
                if (model != null)
                {
                    model.SortID = DecimalHelper.Parse(txtSortID.Value, 0);
                    model.TitleEn = txtTitleEn.Value;
                    bll.Update(model);
                }
            }

            #region 转向到操作结果界面
            Response.Redirect(Request.RawUrl);
            #endregion
        }
        #endregion
        
    }
}
