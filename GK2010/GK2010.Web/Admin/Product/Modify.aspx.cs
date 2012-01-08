using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.Product
{
    public partial class Modify : System.Web.UI.Page
    {
        public string SmallID = "";

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("Product");
            if (!IsPostBack)
            {
                //行业
                AdminIndustry1.TableName = TableName.Product;
                AdminIndustry1.TableID = ConfigParam.ID;
                //介质
                AdminMedium1.TableName = TableName.Product;
                AdminMedium1.TableID = ConfigParam.ID;
                //标签
                AdminTag1.TableName = TableName.Product;
                AdminTag1.TableID = ConfigParam.ID;

                ShowInfo(ConfigParam.ID);
            }
        }
        #endregion

        #region 显示信息
        private void ShowInfo(int ID)
        {
            GK2010.BLL.Product bll = new GK2010.BLL.Product();
            GK2010.Model.Product model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                SmallID = model.CategoryID.ToString();
                txtTitle.Text = model.Title;
                txtTitleEn.Text = model.TitleEn;             
                txtDetail.Value = model.Detail;
              
                txtDefaultBrand.Text = model.DefaultBrand;
                txtDefaultPeriod.Text = model.DefaultPeriod;
                txtDefaultPriceOld.Text = model.DefaultPriceOld.ToString();
                txtDefaultPrice.Text = model.DefaultPrice.ToString();
                txtDefaultJF.Text = model.DefaultJF.ToString();
                chkIndexFlag.Checked = model.IndexFlag == 1;
                chkCommendFlag.Checked = model.CommendFlag == 1;
                chkHotFlag.Checked = model.HotFlag == 1;
                chkChannelFlag.Checked = model.ChannelFlag == 1;
                chkCategoryFlag.Checked = model.CategoryFlag == 1;
               
                AdminSEO1.SEOTitle = model.SEOTitle;
                AdminSEO1.SEOKeywords = model.SEOKeywords;
                AdminSEO1.SEODescription = model.SEODescription;
                chkShowFlag.Checked = model.ShowFlag == 1;
                chkMemberFlag.Checked = model.MemberFlag == 1;
                chkDiyFlag.Checked = model.DiyFlag == 1;  
                txtBasicDiscountPrice.Text = model.BasicDiscountPrice.ToString();
                txtBasicDiscountJF.Text = model.BasicDiscountJF.ToString();


            }
        }
        #endregion

        #region 修改
        public void btnAdd_Click(object sender, EventArgs e)
        {
            int RootID = IntHelper.Parse(Request[dropBig.UniqueID], 0);
            int CategoryID = IntHelper.Parse(Request[dropSmall.UniqueID], 0);
            string Title = txtTitle.Text;
            string TitleEn = txtTitleEn.Text;
            string Detail = txtDetail.Value;
           
            string DefaultBrand = txtDefaultBrand.Text;
            string DefaultPeriod = txtDefaultPeriod.Text;
            decimal DefaultPriceOld = DecimalHelper.Parse(txtDefaultPriceOld.Text, 0);
            decimal DefaultPrice = DecimalHelper.Parse(txtDefaultPrice.Text, 0);
            decimal DefaultJF = DecimalHelper.Parse(txtDefaultJF.Text, 0);
            int IndexFlag = chkIndexFlag.Checked ? 1 : 0;
            int CommendFlag = chkCommendFlag.Checked ? 1 : 0;
            int HotFlag = chkHotFlag.Checked ? 1 : 0; ;
            int ChannelFlag = chkChannelFlag.Checked ? 1 : 0;
            int CategoryFlag = chkCategoryFlag.Checked ? 1 : 0; 
          
            int ShowFlag = chkShowFlag.Checked ? 1 : 0;
            long EditDate = DatetimeHelper.Now;
            int EditUserID = LoginHelper.UserID;
            int MemberFlag = chkMemberFlag.Checked ? 1 : 0;
            int DiyFlag = chkDiyFlag.Checked ? 1 : 0;
            int BasicDiscountPrice = IntHelper.Parse(txtBasicDiscountPrice.Text, 0);
            int BasicDiscountJF = IntHelper.Parse(txtBasicDiscountJF.Text, 0);


            GK2010.BLL.Product bll = new GK2010.BLL.Product();
            GK2010.Model.Product model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                model.RootID = RootID;
                model.CategoryID = CategoryID;
                model.Title = Title;
                model.TitleEn = TitleEn;
                model.Detail = Detail;              
                model.DefaultBrand = DefaultBrand;
                model.DefaultPeriod = DefaultPeriod;
                model.DefaultPriceOld = DefaultPriceOld;
                model.DefaultPrice = DefaultPrice;
                model.DefaultJF = DefaultJF;
                model.IndexFlag = IndexFlag;
                model.CommendFlag = CommendFlag;
                model.HotFlag = HotFlag;
                model.ChannelFlag = ChannelFlag;
                model.CategoryFlag = CategoryFlag;
                model.SEOTitle = AdminSEO1.SEOTitle;
                model.SEOKeywords = AdminSEO1.SEOKeywords;
                model.SEODescription = AdminSEO1.SEODescription;
                model.ShowFlag = ShowFlag;
                model.EditDate = EditDate;
                model.EditUserID = EditUserID;
                model.MemberFlag = MemberFlag;
                model.DiyFlag = DiyFlag;
                model.BasicDiscountPrice = BasicDiscountPrice;
                model.BasicDiscountJF = BasicDiscountJF;

                bool ret = bll.Update(model);

                #region 转向到操作结果界面
                if (ret)
                {
                    //保存行业
                    AdminIndustry1.Save(TableName.Product, ConfigParam.ID);
                    //保存介质
                    AdminMedium1.Save(TableName.Product, ConfigParam.ID);
                    //标签
                    AdminTag1.Save(TableName.Product, ConfigParam.ID);

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
