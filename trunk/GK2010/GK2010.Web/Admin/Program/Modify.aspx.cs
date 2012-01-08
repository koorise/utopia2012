using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.Program
{
    public partial class Modify : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("Program");
            if (!IsPostBack)
            {
                //行业
                AdminIndustry1.TableName = TableName.Program;
                AdminIndustry1.TableID = ConfigParam.ID;
                //介质
                AdminMedium1.TableName = TableName.Program;
                AdminMedium1.TableID = ConfigParam.ID;
                //标签
                AdminTag1.TableName = TableName.Program;
                AdminTag1.TableID = ConfigParam.ID;
                //详细
                ShowInfo(ConfigParam.ID);
            }
        }
        #endregion


        #region 显示信息
        private void ShowInfo(int ID)
        {
            GK2010.BLL.Program bll = new GK2010.BLL.Program();
            GK2010.Model.Program model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                txtTitle.Text = model.Title;
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
            
            string Title = txtTitle.Text;
            string Detail = txtDetail.Value;
            
            int IndexFlag = chkIndexFlag.Checked ? 1 : 0;
            int ChannelFlag = chkChannelFlag.Checked ? 1 : 0;
            int HotFlag = chkHotFlag.Checked ? 1 : 0;
            int CommendFlag = chkCommendFlag.Checked ? 1 : 0;
           
            long PostDate = DatetimeHelper.Now;
            int PostUserID = LoginHelper.UserID;          


            GK2010.BLL.Program bll = new GK2010.BLL.Program();
            GK2010.Model.Program model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                model.Title = Title;
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

                bool ret = bll.Update(model);

                #region 转向到操作结果界面
                if (ret)
                {
                    //保存行业
                    AdminIndustry1.Save(TableName.Program, ConfigParam.ID);
                    //保存介质
                    AdminMedium1.Save(TableName.Program, ConfigParam.ID);
                    //标签
                    AdminTag1.Save(TableName.Program, ConfigParam.ID);

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
