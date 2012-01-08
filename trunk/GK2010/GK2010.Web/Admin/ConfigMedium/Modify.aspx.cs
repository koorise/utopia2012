using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.ConfigMedium
{
    public partial class Modify : System.Web.UI.Page
    {
       	protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("ConfigMedium");
			if (!IsPostBack)
			{
                GK2010.BLL.ConfigMedium bll = new GK2010.BLL.ConfigMedium();
                DropDownListHelper.Bind(dropParentID, "Title", "ID", bll.GetListDropDownList(ConfigParam.ID));          

				ShowInfo(ConfigParam.ID);
			}
		}
			
		private void ShowInfo(int ID)
		{
            GK2010.BLL.ConfigMedium bll = new GK2010.BLL.ConfigMedium();
            GK2010.Model.ConfigMedium model = bll.GetModel(ConfigParam.ID);
			if(model != null)
			{
                dropParentID.SelectedValue = model.ParentID.ToString();
				txtTitle.Text=model.Title;
                txtTitleEn.Text = model.TitleEn;		
				txtSortID.Text=model.SortID.ToString();
                AdminSEO1.SEOTitle = model.SEOTitle;
                AdminSEO1.SEOKeywords = model.SEOKeywords;
                AdminSEO1.SEODescription = model.SEODescription;
                AdminUpload1.Picture = model.PictureNormal;
			}
		}

		public void btnUpdate_Click(object sender, EventArgs e)
		{
            int ParentID = int.Parse(dropParentID.SelectedValue);
			string Title=this.txtTitle.Text;
            string TitleEn = this.txtTitleEn.Text;	
            decimal SortID = DecimalHelper.Parse(this.txtSortID.Text,0);

            GK2010.BLL.ConfigMedium bll = new GK2010.BLL.ConfigMedium();
            GK2010.Model.ConfigMedium model = bll.GetModel(ConfigParam.ID);
			if(model != null)
			{
			    model.ParentID=ParentID;
			    model.Title=Title;
                model.TitleEn = TitleEn;
			    model.SortID=SortID;
                model.SEOTitle = AdminSEO1.SEOTitle;
                model.SEOKeywords = AdminSEO1.SEOKeywords;
                model.SEODescription = AdminSEO1.SEODescription;
                Model.File modelFile = AdminUpload1.Save();
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
                    string ReturnUrl = ConfigParam.ReturnUrl;
                    if (ReturnUrl == "")
                    {
                        ReturnUrl = "manage.aspx";
                    }
                    MessageBox.ShowAlertAndRedirect(this.Page, "修改成功", ReturnUrl);
                }
                else
                {
                    MessageBox.ShowAlert(this.Page, "修改失败");
                }
                #endregion
			}

		}

    }
}
