using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.Help
{
    public partial class Add : System.Web.UI.Page
    {
       
	    #region Page_Load
	    protected void Page_Load(object sender, EventArgs e)
	    {
		     BLL.SystemTree.CheckPermission("Help");
             if (!IsPostBack)
             {
                 GK2010.BLL.HelpCategory bll = new GK2010.BLL.HelpCategory();
                 DropDownListHelper.Bind(dropCategory, "Title", "ID", bll.GetList("",""));
                 
             }
	    }
	    #endregion

	    #region 添加
	    protected void btnAdd_Click(object sender, EventArgs e)
	    {
            int CategoryID = IntHelper.Parse(dropCategory.SelectedValue, 0);
            string Title = txtTitle.Text;
            string TitleEn = txtTitleEn.Text;
            string Detail = txtDetail.Value;
            decimal SortID = DecimalHelper.Parse(txtSortID.Text, 0);

		    GK2010.Model.Help model=new GK2010.Model.Help();
            model.CategoryID = CategoryID;
            model.Title = Title;
            model.TitleEn = TitleEn;
            model.Detail = Detail;
            model.SortID = SortID;

            model.SEOTitle = AdminSEO1.SEOTitle;
            model.SEOKeywords = AdminSEO1.SEOKeywords;
            model.SEODescription = AdminSEO1.SEODescription;

            model.IndexFlag = AdminParam1.IndexFlag;
            model.IndexSortID = AdminParam1.IndexSortID;
            model.CommendFlag = AdminParam1.CommendFlag;
            model.CommendSortID = AdminParam1.CommendSortID;
            model.HotFlag = AdminParam1.HotFlag;
            model.HotSortID = AdminParam1.HotSortID;

		    GK2010.BLL.Help bll=new GK2010.BLL.Help();
		    int ret = bll.Add(model);
    		
		    #region 转向到操作结果界面
		     if (ret > 0)
             {
                 AdminTag1.Save(TableName.Help, ret);
			    MessageBox.ShowAlertAndRedirect(this.Page, "添加成功", "manage.aspx");
		    }
		    else
		    {
		    MessageBox.ShowAlert(this.Page, "添加失败");
		    }
		    #endregion

	    }
	    #endregion

    }
}
