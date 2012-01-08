using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.Help
{
    public partial class Modify : System.Web.UI.Page
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("Help");
            if (!IsPostBack)
            {
                GK2010.BLL.HelpCategory bll = new GK2010.BLL.HelpCategory();
                DropDownListHelper.Bind(dropCategory, "Title", "ID", bll.GetList("", ""));

                AdminTag1.TableName = TableName.Help;
                AdminTag1.TableID = ConfigParam.ID;

                ShowInfo(ConfigParam.ID);
            }
        }
        #endregion

        #region 显示信息
        private void ShowInfo(int ID)
        {
            GK2010.BLL.Help bll = new GK2010.BLL.Help();
            GK2010.Model.Help model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                dropCategory.SelectedValue = model.CategoryID.ToString();
                txtTitle.Text = model.Title;
                txtTitleEn.Text = model.TitleEn;              
                txtDetail.Value = model.Detail;
                txtSortID.Text = model.SortID.ToString();
                AdminSEO1.SEOTitle = model.SEOTitle;
                AdminSEO1.SEOKeywords = model.SEOKeywords;
                AdminSEO1.SEODescription = model.SEODescription;

                AdminParam1.IndexFlag = model.IndexFlag;
                AdminParam1.IndexSortID =model.IndexSortID;
                AdminParam1.CommendFlag = model.CommendFlag;
                AdminParam1.CommendSortID =model.CommendSortID ;
                AdminParam1.HotFlag =model.HotFlag;
                AdminParam1.HotSortID = model.HotSortID;
            }
        }
        #endregion

        #region 修改
        public void btnUpdate_Click(object sender, EventArgs e)
        {
            int CategoryID = IntHelper.Parse(dropCategory.SelectedValue, 0);
            string Title = txtTitle.Text;
            string TitleEn = txtTitleEn.Text;          
            string Detail = txtDetail.Value;           
            decimal SortID = DecimalHelper.Parse(txtSortID.Text, 0);
           

            GK2010.BLL.Help bll = new GK2010.BLL.Help();
            GK2010.Model.Help model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                model.CategoryID = CategoryID;
                model.Title = Title;
                model.TitleEn = TitleEn;
                model.Detail = Detail;
                model.SortID = SortID;
                model.SEOTitle = AdminSEO1.SEOTitle;
                model.SEOKeywords = AdminSEO1.SEOKeywords;
                model.SEODescription = AdminSEO1.SEODescription;

                model.IndexFlag = AdminParam1.IndexFlag;
                model.IndexSortID = AdminParam1.IndexSortID;
                model.CommendFlag = AdminParam1.CommendFlag;
                model.CommendSortID = AdminParam1.CommendSortID;
                model.HotFlag = AdminParam1.HotFlag;
                model.HotSortID = AdminParam1.HotSortID;

                bool ret = bll.Update(model);

                #region 转向到操作结果界面
                if (ret)
                {
                    AdminTag1.Save(TableName.Help, ConfigParam.ID);
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
