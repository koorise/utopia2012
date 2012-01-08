using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.Slide
{
    public partial class Add : System.Web.UI.Page
    {
       
	    #region Page_Load
	    protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("Slide");
            if (!IsPostBack)
            {
                GK2010.BLL.SlideCategory bll = new GK2010.BLL.SlideCategory();
                DropDownListHelper.Bind(dropCategory, "Title", "ID", bll.GetList("",""));               
            }
		    
	    }
	    #endregion

	    #region ���
	    protected void btnAdd_Click(object sender, EventArgs e)
	    {
            int CategoryID = IntHelper.Parse(dropCategory.SelectedValue, 0);
		    string Title = txtTitle.Text;
		    string Detail = txtDetail.Value;
		  
		   
		   
            long PostDate = DatetimeHelper.Now;
            int PostUserID = LoginHelper.UserID;          

		    GK2010.Model.Slide model=new GK2010.Model.Slide();
		    model.CategoryID = CategoryID;
		    model.Title = Title;
            model.Summary = txtSummary.Text;
		    model.Detail = Detail;
            model.IndexFlag = AdminParam1.IndexFlag;
            model.ChannelFlag = AdminParam1.ChannelFlag;
            model.HotFlag = AdminParam1.HotFlag;
            model.CommendFlag = AdminParam1.CommendFlag;
            model.SEOTitle = AdminSEO1.SEOTitle;
            model.SEOKeywords = AdminSEO1.SEOKeywords;
            model.SEODescription = AdminSEO1.SEODescription;	  
		    model.PostDate = PostDate;
		    model.PostUserID = PostUserID;
            model.Url = txtUrl.Text;
            model.SortID = DecimalHelper.Parse(this.txtSortID.Text, 0); 

            Model.File modelFile = AdminUpload1.Save();
            if (modelFile != null)
            {
                model.PictureSmall = modelFile.PictureSmall;
                model.PictureBig = modelFile.PictureBig;
                model.PictureNormal = modelFile.PictureNormal;
            }
		    

		    GK2010.BLL.Slide bll=new GK2010.BLL.Slide();
		    int ret = bll.Add(model);
    		
		    #region ת�򵽲����������
		     if (ret > 0)
             {
                AdminTag1.Save(TableName.Slide, ret);
                string ReturnUrl = ConfigParam.ReturnUrl;
                if (ReturnUrl == "") { ReturnUrl = "manage.aspx"; }
			    MessageBox.ShowAlertAndRedirect(this.Page, "��ӳɹ�", ReturnUrl);
		    }
		    else
		    {
		    MessageBox.ShowAlert(this.Page, "���ʧ��");
		    }
		    #endregion

	    }
	    #endregion

    }
}
