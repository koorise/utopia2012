using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.Brand
{
    public partial class Modify : System.Web.UI.Page
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("Brand");
            if (!IsPostBack)
            {
                //标签
                AdminTag1.TableName = TableName.Brand;
                AdminTag1.TableID = ConfigParam.ID;


                ShowInfo(ConfigParam.ID);
            }
        }
        #endregion


        #region 显示信息
        private void ShowInfo(int ID)
        {
            GK2010.BLL.Brand bll = new GK2010.BLL.Brand();
            GK2010.Model.Brand model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {

                txtTitle.Text = model.Title;
                txtTitleEn.Text = model.TitleEn;
                txtDetail.Value = model.Detail;
                txtSortID.Text = model.SortID.ToString();
                if (model.PictureNormal != "")
                {
                    txtPicture.Text = "<br><img src='" + model.PictureNormal + "' >";
                }
                AdminSEO1.SEOTitle = model.SEOTitle;
                AdminSEO1.SEOKeywords = model.SEOKeywords;
                AdminSEO1.SEODescription = model.SEODescription;
            }
        }
        #endregion


        #region 修改
        public void btnUpdate_Click(object sender, EventArgs e)
        {
            string Title = txtTitle.Text;
            string TitleEn = txtTitleEn.Text;
            string Detail = txtDetail.Value;
            decimal SortID = DecimalHelper.Parse(txtSortID.Text, 0);


            GK2010.BLL.Brand bll = new GK2010.BLL.Brand();
            GK2010.Model.Brand model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {

                model.Title = Title;
                model.TitleEn = TitleEn;
                model.Detail = Detail;
                model.SortID = SortID;
                model.SEOTitle = AdminSEO1.SEOTitle;
                model.SEOKeywords = AdminSEO1.SEOKeywords;
                model.SEODescription = AdminSEO1.SEODescription;

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
                    AdminTag1.Save(TableName.Brand, ConfigParam.ID);
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
