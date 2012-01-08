using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.Brand
{
    public partial class Add : System.Web.UI.Page
    {
       
	    #region Page_Load
	    protected void Page_Load(object sender, EventArgs e)
	    {
		     BLL.SystemTree.CheckPermission("Brand");
	    }
	    #endregion

	    #region 添加
	    protected void btnAdd_Click(object sender, EventArgs e)
	    {
		    int CategoryID = 0;
		    string Title = txtTitle.Text;
		    string TitleEn = txtTitleEn.Text;
            string Detail = txtDetail.Value;
            decimal SortID = DecimalHelper.Parse(txtSortID.Text, 0);
            string PictureSmall = "";
            string PictureNormal = "";
            string PictureBig = "";		 

		    GK2010.Model.Brand model=new GK2010.Model.Brand();
		    model.CategoryID = CategoryID;
		    model.Title = Title;
		    model.TitleEn = TitleEn;		  
		    model.Detail = Detail;		   
		    model.PictureSmall = PictureSmall;
		    model.PictureNormal = PictureNormal;
		    model.PictureBig = PictureBig;
		    model.SortID = SortID;


            FileHelper _FileHelper = new FileHelper(FileUpload1.PostedFile);
            Model.File modelFile = new GK2010.Model.File();
            modelFile = _FileHelper.Save();
            if (modelFile != null)
            {                
                model.PictureSmall = modelFile.PictureSmall;
                model.PictureBig = modelFile.PictureBig;
                model.PictureNormal = modelFile.PictureNormal;                
            }
            model.SEOTitle = AdminSEO1.SEOTitle;
            model.SEOKeywords = AdminSEO1.SEOKeywords;
            model.SEODescription = AdminSEO1.SEODescription;

		    GK2010.BLL.Brand bll=new GK2010.BLL.Brand();
		    int ret = bll.Add(model);
    		
		    #region 转向到操作结果界面
		     if (ret > 0)
		    {
                AdminTag1.Save(TableName.Brand, ret);
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
