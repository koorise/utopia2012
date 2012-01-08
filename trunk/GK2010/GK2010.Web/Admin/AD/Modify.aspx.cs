using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.AD
{
    public partial class Modify : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("AD");
            if (!IsPostBack)
            {
                GK2010.BLL.ADCategory bll = new GK2010.BLL.ADCategory();
                DropDownListHelper.Bind(dropCategory, "Title", "ID", bll.GetList("", ""));

              

                ShowInfo(ConfigParam.ID);
            }
        }
        #endregion


        #region ��ʾ��Ϣ
        private void ShowInfo(int ID)
        {
            GK2010.BLL.AD bll = new GK2010.BLL.AD();
            GK2010.Model.AD model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                dropCategory.SelectedValue = model.CategoryID.ToString();
                txtTitle.Text = model.Title;
                AdminUpload1.Picture = model.PictureNormal;
                txtSortID.Text = model.SortID.ToString();
                txtUrl.Text = model.Url;
            }
        }
        #endregion


        #region �޸�
        public void btnAdd_Click(object sender, EventArgs e)
        {
            int CategoryID = IntHelper.Parse(dropCategory.SelectedValue, 0);
            string Title = txtTitle.Text;
          
         
          
            long PostDate = DatetimeHelper.Now;
            int PostUserID = LoginHelper.UserID;          


            GK2010.BLL.AD bll = new GK2010.BLL.AD();
            GK2010.Model.AD model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                model.CategoryID = CategoryID;
                model.Title = Title;
                model.SortID = DecimalHelper.Parse(txtSortID.Text, 0);
                model.Summary = txtSummary.Text;
                model.Url = txtUrl.Text;
                
                model.EditDate = PostDate;
                model.EditUserID = PostUserID;

                Model.File modelFile = AdminUpload1.Save();
                if (modelFile != null)
                {
                    model.PictureSmall = modelFile.PictureSmall;
                    model.PictureBig = modelFile.PictureBig;
                    model.PictureNormal = modelFile.PictureNormal;
                }

                bool ret = bll.Update(model);

                #region ת�򵽲����������
                if (ret)
                {
                  
                    string ReturnUrl = ConfigParam.ReturnUrl;
                    if (ReturnUrl == "") { ReturnUrl = "manage.aspx"; }
                    MessageBox.ShowAlertAndRedirect(this.Page, "�޸ĳɹ�", ReturnUrl);
                }
                else
                {
                    MessageBox.ShowAlert(this.Page, "�޸�ʧ��");
                }
                #endregion
            }

        }
        #endregion

    }
}
