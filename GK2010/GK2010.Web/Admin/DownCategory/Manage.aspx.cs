using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.DownCategory
{
    public partial class Manage : System.Web.UI.Page
    {
        #region PageLoad
		protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("DownCategory");
			if (!IsPostBack)
			{
                GK2010.BLL.DownCategory bll = new GK2010.BLL.DownCategory();
                RepeaterList.DataSource = bll.GetList("","");
                RepeaterList.DataBind();
			}
		}
        #endregion
		
		#region ����
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			string UrlRedirect = "add.aspx";
			Response.Redirect(UrlRedirect);
		}
		#endregion

        #region ����
        protected void btnSave_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in RepeaterList.Items)
            {
                HtmlInputHidden txtID = (HtmlInputHidden)item.FindControl("txtID");
                HtmlInputText txtSortID = (HtmlInputText)item.FindControl("txtSortID");
                HtmlInputText txtTitleEn = (HtmlInputText)item.FindControl("txtTitleEn");
                GK2010.BLL.DownCategory bll = new GK2010.BLL.DownCategory();
                GK2010.Model.DownCategory model = bll.GetModel(int.Parse(txtID.Value));
                if (model != null)
                {
                    model.SortID = DecimalHelper.Parse(txtSortID.Value, 0);
                    model.TitleEn = txtTitleEn.Value;
                    bll.Update(model);
                }
            }

            #region ת�򵽲����������
            Response.Redirect(Request.RawUrl);
            #endregion
        }
        #endregion
        
    }
}