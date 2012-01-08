using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.AD
{
    public partial class Add : System.Web.UI.Page
    {
       
	    #region Page_Load
	    protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("AD");
            if (!IsPostBack)
            {
                GK2010.BLL.ADCategory bll = new GK2010.BLL.ADCategory();
                DropDownListHelper.Bind(dropCategory, "Title", "ID", bll.GetList("",""));               
            }
		    
	    }
	    #endregion

	    #region 添加
	    protected void btnAdd_Click(object sender, EventArgs e)
	    {
            int CategoryID = IntHelper.Parse(dropCategory.SelectedValue, 0);
		    string Title = txtTitle.Text;
		  
		   
		   
            long PostDate = DatetimeHelper.Now;
            int PostUserID = LoginHelper.UserID;          

		    GK2010.Model.AD model=new GK2010.Model.AD();
		    model.CategoryID = CategoryID;
		    model.Title = Title;
            model.Summary = txtSummary.Text;
		    model.PostDate = PostDate;
		    model.PostUserID = PostUserID;
            model.SortID = DecimalHelper.Parse(txtSortID.Text, 0);
            model.Url = txtUrl.Text;
                
            Model.File modelFile = AdminUpload1.Save();
            if (modelFile != null)
            {
                model.PictureSmall = modelFile.PictureSmall;
                model.PictureBig = modelFile.PictureBig;
                model.PictureNormal = modelFile.PictureNormal;
            }
		    

		    GK2010.BLL.AD bll=new GK2010.BLL.AD();
		    int ret = bll.Add(model);
    		
		    #region 转向到操作结果界面
		     if (ret > 0)
             {
              
                string ReturnUrl = ConfigParam.ReturnUrl;
                if (ReturnUrl == "") { ReturnUrl = "manage.aspx"; }
			    MessageBox.ShowAlertAndRedirect(this.Page, "添加成功", ReturnUrl);
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
