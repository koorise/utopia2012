using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.Company
{
    public partial class Modify : System.Web.UI.Page
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("Company");
            if (!IsPostBack)
            {
                //标签
                AdminTag1.TableName = TableName.Company;
                AdminTag1.TableID = ConfigParam.ID;


                ShowInfo(ConfigParam.ID);
            }
        }
        #endregion


        #region 显示信息
        private void ShowInfo(int ID)
        {
            GK2010.BLL.Company bll = new GK2010.BLL.Company();
            GK2010.Model.Company model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                txtTitle.Text = model.Title;
                txtTitleEn.Text = model.TitleEn;
                txtDetail.Value = model.Detail;
                txtUrl.Text = model.Url;
                txtSortID.Text = model.SortID.ToString();
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
            string Url = txtUrl.Text;

            GK2010.BLL.Company bll = new GK2010.BLL.Company();
            GK2010.Model.Company model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                model.Title = Title;
                model.TitleEn = TitleEn;
                model.Detail = Detail;
                model.Url = Url;
                model.SortID = SortID;
                AdminSEO1.SEOTitle = model.SEOTitle;
                AdminSEO1.SEOKeywords = model.SEOKeywords;
                AdminSEO1.SEODescription = model.SEODescription;


                bool ret = bll.Update(model);

                #region 转向到操作结果界面
                if (ret)
                {
                    AdminTag1.Save(TableName.Company, ConfigParam.ID);
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
