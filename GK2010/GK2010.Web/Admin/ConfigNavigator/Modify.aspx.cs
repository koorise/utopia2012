using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.ConfigNavigator
{
    public partial class Modify : System.Web.UI.Page
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("ConfigNavigator");
            if (!IsPostBack)
            {
                ShowInfo(ConfigParam.ID);
            }
        }
        #endregion


        #region 显示信息
        private void ShowInfo(int ID)
        {
            GK2010.BLL.ConfigNavigator bll = new GK2010.BLL.ConfigNavigator();
            GK2010.Model.ConfigNavigator model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                txtTitle.Text = model.Title;
                txtTitleEn.Text = model.TitleEn;
               
                txtUrl.Text = model.Url;
                txtSortID.Text = model.SortID.ToString();

                chkIndexFlag.Checked = model.IndexFlag == 1;
            }
        }
        #endregion


        #region 修改
        public void btnUpdate_Click(object sender, EventArgs e)
        {
            string Title = txtTitle.Text;
            string TitleEn = txtTitleEn.Text;
          
            decimal SortID = DecimalHelper.Parse(txtSortID.Text, 0);
            string Url = txtUrl.Text;

            GK2010.BLL.ConfigNavigator bll = new GK2010.BLL.ConfigNavigator();
            GK2010.Model.ConfigNavigator model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                model.Title = Title;
                model.TitleEn = TitleEn;
                model.Url = Url;
                model.SortID = SortID;
                model.IndexFlag = chkIndexFlag.Checked ? 1 : 0;
              


                bool ret = bll.Update(model);

                #region 转向到操作结果界面
                if (ret)
                {
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
