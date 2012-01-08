using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.HelpCategory
{
    public partial class Modify : System.Web.UI.Page
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("HelpCategory");
            if (!IsPostBack)
            {
                ShowInfo(ConfigParam.ID);
            }
        }
        #endregion


        #region 显示信息
        private void ShowInfo(int ID)
        {
            GK2010.BLL.HelpCategory bll = new GK2010.BLL.HelpCategory();
            GK2010.Model.HelpCategory model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                txtTitle.Text = model.Title;
                txtTitleEn.Text = model.TitleEn;
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
            decimal SortID = DecimalHelper.Parse(txtSortID.Text, 0);         

            GK2010.BLL.HelpCategory bll = new GK2010.BLL.HelpCategory();
            GK2010.Model.HelpCategory model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                model.Title = Title;
                model.TitleEn = TitleEn;
                model.SortID = SortID;
                model.SEOTitle = AdminSEO1.SEOTitle;
                model.SEOKeywords = AdminSEO1.SEOKeywords;
                model.SEODescription = AdminSEO1.SEODescription;

                bool ret = bll.Update(model);

                #region 转向到操作结果界面
                if (ret)
                {
                    string ReturnUrl = ConfigParam.ReturnUrl;
                    if (ReturnUrl == "") { ReturnUrl = "manage.aspx"; }
                    MessageBox.ShowAlertAndRedirect(this.Page, "修改成功", "manage.aspx");
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
