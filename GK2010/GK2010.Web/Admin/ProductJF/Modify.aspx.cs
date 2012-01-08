using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.ProductJF
{
    public partial class Modify :System.Web.UI.Page
    {
       
	    #region Page_Load
	    protected void Page_Load(object sender, EventArgs e)
	    {
		    BLL.SystemTree.CheckPermission("ProductJF");
		    if (!IsPostBack)
            {
                //标签
                AdminTag1.TableName = TableName.ProductJF;
                AdminTag1.TableID = ConfigParam.ID;

			    ShowInfo(ConfigParam.ID);
		    }
	    }
	    #endregion
    	

	    #region 显示信息
	    private void ShowInfo(int ID)
        {
            GK2010.BLL.ProductJF bll = new GK2010.BLL.ProductJF();
            GK2010.Model.ProductJF model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                chkIndexFlag.Checked = model.IndexFlag == 1;
                chkCommendFlag.Checked = model.CommendFlag == 1;
                txtTitle.Text = model.Title;
                txtDefaultJF.Text = model.DefaultJF.ToString();
                txtDetail.Value = model.Detail;

                AdminSEO1.SEOTitle = model.SEOTitle;
                AdminSEO1.SEOKeywords = model.SEOKeywords;
                AdminSEO1.SEODescription = model.SEODescription;

                if (model.PictureNormal != "")
                {
                    txtPicture.Text = "<br><img src='" + model.PictureNormal + "' width='120' height='90'>";
                }
            }

	    }
	    #endregion


	    #region 修改
	    public void btnUpdate_Click(object sender, EventArgs e)
	    {
            string Title = txtTitle.Text;
            string Detail = txtDetail.Value;
            decimal DefaultJF = DecimalHelper.Parse(txtDefaultJF.Text, 0);


		    GK2010.BLL.ProductJF bll = new GK2010.BLL.ProductJF();
		    GK2010.Model.ProductJF model = bll.GetModel(ConfigParam.ID);
		    if(model != null)
		    {
                model.Title = Title;
                model.Detail = Detail;
                model.DefaultJF = DefaultJF;
                model.EditDate = DatetimeHelper.Now;
                model.EditUserID = LoginHelper.UserID;
                model.SEOTitle = AdminSEO1.SEOTitle;
                model.SEOKeywords = AdminSEO1.SEOKeywords;
                model.SEODescription = AdminSEO1.SEODescription;
                model.IndexFlag =chkIndexFlag.Checked?1:0;
                model.CommendFlag = chkCommendFlag.Checked ? 1 : 0;
			    

                FileHelper _FileHelper = new FileHelper(FileUpload1.PostedFile);
                Model.File modelFile = new GK2010.Model.File();
                modelFile = _FileHelper.Save();
                if (modelFile != null)
                {
                    model.PictureSmall = modelFile.PictureSmall;
                    model.PictureBig = modelFile.PictureBig;
                    model.PictureNormal = modelFile.PictureNormal;
                }

                bool ret = bll.Update(model);

			    #region 转向到操作结果界面
			     if (ret)
                 {
                     AdminTag1.Save(TableName.ProductJF, ConfigParam.ID);

				    string ReturnUrl = ConfigParam.ReturnUrl;
				    if (ReturnUrl == ""){ReturnUrl = "manage.aspx";}
                    MessageBox.ShowAlertAndRedirect(this.Page, "修改成功", ReturnUrl);
			    }
			    else
			    {
				    MessageBox.ShowAlert(this.Page, "修改失败");
			    }
			    #endregion
		    }

	    }
	    #endregion

    }
}
