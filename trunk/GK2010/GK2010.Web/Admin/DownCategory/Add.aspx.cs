using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.DownCategory
{
    public partial class Add : System.Web.UI.Page
    {
	    protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("DownCategory");
			
		}

       	protected void btnAdd_Click(object sender, EventArgs e)
		{
            int ParentID = ConfigParam.ParentID;
			string Title=this.txtTitle.Text;
			string TitleEn=txtTitleEn.Text;	
            decimal SortID = DecimalHelper.Parse(this.txtSortID.Text,0);          

            GK2010.Model.DownCategory model = new GK2010.Model.DownCategory();
			model.ParentID=ParentID;
			model.Title=Title;
			model.TitleEn=TitleEn;
			model.SortID=SortID;
            model.SEOTitle = AdminSEO1.SEOTitle;
            model.SEOKeywords = AdminSEO1.SEOKeywords;
            model.SEODescription = AdminSEO1.SEODescription;

            GK2010.BLL.DownCategory bll = new GK2010.BLL.DownCategory();
			int ret = bll.Add(model);

            #region 转向到操作结果界面
            if (ret > 0)
            {
                MessageBox.ShowAlertAndRedirect(this.Page, "添加成功", "manage.aspx");
            }
            else
            {
                MessageBox.ShowAlert(this.Page, "添加失败");
            }
            #endregion


		}

    }
}
