using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.ProductJF
{
    public partial class Add : System.Web.UI.Page
    {
       
	    #region Page_Load
	    protected void Page_Load(object sender, EventArgs e)
	    {
		     BLL.SystemTree.CheckPermission("ProductJF");
	    }
	    #endregion

	    #region 添加
	    protected void btnAdd_Click(object sender, EventArgs e)
	    {
		    string Title = txtTitle.Text;
		    string Detail = txtDetail.Value;
		    decimal DefaultJF = DecimalHelper.Parse(txtDefaultJF.Text,0);		   
		    string PictureSmall = "";
            string PictureNormal = "";
            string PictureBig = "";
            long PostDate = DatetimeHelper.Now;
		    int PostUserID = LoginHelper.UserID;
		 
		    GK2010.Model.ProductJF model=new GK2010.Model.ProductJF();
		    model.Title = Title;
		    model.Detail = Detail;
		    model.DefaultJF = DefaultJF;
		    model.PictureSmall = PictureSmall;
		    model.PictureNormal = PictureNormal;
		    model.PictureBig = PictureBig;
		    model.PostDate = PostDate;
		    model.PostUserID = PostUserID;
            model.IndexFlag = chkIndexFlag.Checked ? 1 : 0;
            model.CommendFlag = chkCommendFlag.Checked ? 1 : 0;
            AdminSEO1.SEOTitle = model.SEOTitle;
            AdminSEO1.SEOKeywords = model.SEOKeywords;
            AdminSEO1.SEODescription = model.SEODescription;

		    FileHelper _FileHelper = new FileHelper(FileUpload1.PostedFile);
            Model.File modelFile = new GK2010.Model.File();
            modelFile = _FileHelper.Save();
            if (modelFile != null)
            {                
                model.PictureSmall = modelFile.PictureSmall;
                model.PictureBig = modelFile.PictureBig;
                model.PictureNormal = modelFile.PictureNormal;                
            }


		    GK2010.BLL.ProductJF bll=new GK2010.BLL.ProductJF();
		    int ret = bll.Add(model);
    		
		    #region 转向到操作结果界面
		     if (ret > 0)
             {
                AdminTag1.Save(TableName.ProductJF, ret);

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
