using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.Qa
{
    public partial class Modify : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("Qa");
            if (!IsPostBack)
            {
                GK2010.BLL.QaCategory bll = new GK2010.BLL.QaCategory();
                DropDownListHelper.Bind(dropCategory, "Title", "ID", bll.GetListDropDownList(-1));   

                //标签
                AdminTag1.TableName = TableName.Qa;
                AdminTag1.TableID = ConfigParam.ID;

                ShowInfo(ConfigParam.ID);
            }
        }
        #endregion


        #region 显示信息
        private void ShowInfo(int ID)
        {
            GK2010.BLL.Qa bll = new GK2010.BLL.Qa();
            GK2010.Model.Qa model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                dropCategory.SelectedValue = model.CategoryID.ToString();
                txtTitle.Text = model.Title;
                txtSummary.Text = model.Summary;
                txtDetail.Value = model.Detail;              
                chkIndexFlag.Checked = model.IndexFlag == 1;
                chkChannelFlag.Checked = model.ChannelFlag == 1;
                chkHotFlag.Checked = model.HotFlag == 1;
                chkCommendFlag.Checked = model.CommendFlag == 1;
                AdminSEO1.SEOTitle = model.SEOTitle;
                AdminSEO1.SEOKeywords = model.SEOKeywords;
                AdminSEO1.SEODescription = model.SEODescription;
            }
        }
        #endregion


        #region 修改
        public void btnAdd_Click(object sender, EventArgs e)
        {
            int CategoryID = IntHelper.Parse(dropCategory.SelectedValue, 0);
            string Title = txtTitle.Text;
            string Detail = txtDetail.Value;          
            int IndexFlag = chkIndexFlag.Checked ? 1 : 0;
            int ChannelFlag = chkChannelFlag.Checked ? 1 : 0;
            int HotFlag = chkHotFlag.Checked ? 1 : 0;
            int CommendFlag = chkCommendFlag.Checked ? 1 : 0;
           
            long PostDate = DatetimeHelper.Now;
            int PostUserID = LoginHelper.UserID;          


            GK2010.BLL.Qa bll = new GK2010.BLL.Qa();
            GK2010.Model.Qa model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                model.CategoryID = CategoryID;
                model.Title = Title;
                model.Summary = txtSummary.Text;
                model.Detail = Detail;               
                model.IndexFlag = IndexFlag;
                model.ChannelFlag = ChannelFlag;
                model.HotFlag = HotFlag;
                model.CommendFlag = CommendFlag;
                model.SEOTitle = AdminSEO1.SEOTitle;
                model.SEOKeywords = AdminSEO1.SEOKeywords;
                model.SEODescription = AdminSEO1.SEODescription;
                model.EditDate = PostDate;
                model.EditUserID = PostUserID;

                if (model.Detail.Length > 0)
                {
                    model.CheckFlag = model.Detail.Length > 0?1:0;
                    model.CheckDate = PostDate;
                }
                

                bool ret = bll.Update(model);

                #region 转向到操作结果界面
                if (ret)
                {
                    AdminTag1.Save(TableName.Qa, ConfigParam.ID);


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
