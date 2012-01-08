using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.Slide
{
    public partial class Modify : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("Slide");
            if (!IsPostBack)
            {
                GK2010.BLL.SlideCategory bll = new GK2010.BLL.SlideCategory();
                DropDownListHelper.Bind(dropCategory, "Title", "ID", bll.GetList("", ""));

                AdminTag1.TableName = TableName.Slide;
                AdminTag1.TableID = ConfigParam.ID;

                ShowInfo(ConfigParam.ID);
            }
        }
        #endregion


        #region 显示信息
        private void ShowInfo(int ID)
        {
            GK2010.BLL.Slide bll = new GK2010.BLL.Slide();
            GK2010.Model.Slide model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                dropCategory.SelectedValue = model.CategoryID.ToString();
                txtTitle.Text = model.Title;
                txtDetail.Value = model.Detail;
                txtSummary.Text = model.Summary;
                AdminParam1.IndexFlag = model.IndexFlag;
                AdminParam1.ChannelFlag = model.ChannelFlag;
                AdminParam1.HotFlag = model.HotFlag;
                AdminParam1.CommendFlag = model.CommendFlag ;
                AdminSEO1.SEOTitle = model.SEOTitle;
                AdminSEO1.SEOKeywords = model.SEOKeywords;
                AdminSEO1.SEODescription = model.SEODescription;
                AdminUpload1.Picture = model.PictureNormal;
                txtUrl.Text = model.Url ;
                txtSortID.Text = model.SortID.ToString();
            }
        }
        #endregion


        #region 修改
        public void btnAdd_Click(object sender, EventArgs e)
        {
            int CategoryID = IntHelper.Parse(dropCategory.SelectedValue, 0);
            string Title = txtTitle.Text;
            string Detail = txtDetail.Value;
         
          
            long PostDate = DatetimeHelper.Now;
            int PostUserID = LoginHelper.UserID;          


            GK2010.BLL.Slide bll = new GK2010.BLL.Slide();
            GK2010.Model.Slide model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                model.CategoryID = CategoryID;
                model.Title = Title;
                model.Detail = Detail;
                model.Summary = txtSummary.Text;
                model.IndexFlag = AdminParam1.IndexFlag;
                model.ChannelFlag = AdminParam1.ChannelFlag;
                model.HotFlag = AdminParam1.HotFlag;
                model.CommendFlag = AdminParam1.CommendFlag;
                model.SEOTitle = AdminSEO1.SEOTitle;
                model.SEOKeywords = AdminSEO1.SEOKeywords;
                model.SEODescription = AdminSEO1.SEODescription;
                model.EditDate = PostDate;
                model.EditUserID = PostUserID;
                model.Url = txtUrl.Text;
                model.SortID = DecimalHelper.Parse(this.txtSortID.Text, 0); 

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
                    AdminTag1.Save(TableName.Slide, ConfigParam.ID);
                    string ReturnUrl = ConfigParam.ReturnUrl;
                    if (ReturnUrl == "") { ReturnUrl = "manage.aspx"; }
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
