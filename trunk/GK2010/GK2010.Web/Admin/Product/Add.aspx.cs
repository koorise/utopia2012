using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.Product
{
    public partial class Add : System.Web.UI.Page
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("Product");
        }
        #endregion

        #region 添加
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int RootID = IntHelper.Parse(Request[dropBig.UniqueID], 0);
            int CategoryID = IntHelper.Parse(Request[dropSmall.UniqueID], 0);
            string Title = txtTitle.Text;
            string TitleEn = txtTitleEn.Text;
            string Detail = txtDetail.Value;
            int Hits = 0;
            string Url = "";
            string DefaultBrand = txtDefaultBrand.Text;
            string DefaultPeriod = txtDefaultPeriod.Text;
            decimal DefaultPriceOld = DecimalHelper.Parse(txtDefaultPriceOld.Text, 0);
            decimal DefaultPrice = DecimalHelper.Parse(txtDefaultPrice.Text, 0);
            decimal DefaultJF = DecimalHelper.Parse(txtDefaultJF.Text, 0);
            int PictureID = 0;
            string PictureSmall = "";
            string PictureNormal = "";
            string PictureBig = "";
            int IndexFlag = chkIndexFlag.Checked ? 1 : 0;
            decimal IndexSortID = 0;
            int CommendFlag = chkCommendFlag.Checked ? 1 : 0;
            decimal CommendSortID = 0;
            int HotFlag = chkHotFlag.Checked ? 1 : 0; ;
            decimal HotSortID = 0;
            int ChannelFlag = chkChannelFlag.Checked ? 1 : 0; ;
            decimal ChannelSortID = 0;
            int CategoryFlag = chkCategoryFlag.Checked ? 1 : 0; ;
            decimal CategorySortID = 0;
            decimal SortID = 0;

            int ShowFlag = chkShowFlag.Checked ? 1 : 0;
            int CheckFlag = 1;
            long CheckDate = DatetimeHelper.Now;
            int CheckUserID = LoginHelper.UserID;
            long PostDate = DatetimeHelper.Now;
            int PostUserID = LoginHelper.UserID;
            long EditDate = 0;
            int EditUserID = 0;
            long DelDate = 0;
            int DelUserID = 0;
            int MemberFlag = chkMemberFlag.Checked ? 1 : 0;
            int DiyFlag = chkDiyFlag.Checked ? 1 : 0;
            string DiyTypeCn = "";
            string DiyTypeEn = "";
            string DiyTypePartsID = "";
            string DiyTypePrice = "";
            string DiyTypeAttachmentFlag = "";
            string DiyExpression = "";
            int BasicDiscountPrice = IntHelper.Parse(txtBasicDiscountPrice.Text, 0);
            int BasicDiscountJF = IntHelper.Parse(txtBasicDiscountJF.Text, 0);

            GK2010.Model.Product model = new GK2010.Model.Product();
            model.CacheID = DatetimeHelper.Now;
            model.RootID = RootID;
            model.CategoryID = CategoryID;
            model.Title = Title;
            model.TitleEn = TitleEn;
            model.Detail = Detail;
            model.Hits = Hits;
            model.Url = Url;
            model.DefaultBrand = DefaultBrand;
            model.DefaultPeriod = DefaultPeriod;
            model.DefaultPriceOld = DefaultPriceOld;
            model.DefaultPrice = DefaultPrice;
            model.DefaultJF = DefaultJF;
            model.PictureID = PictureID;
            model.PictureSmall = PictureSmall;
            model.PictureNormal = PictureNormal;
            model.PictureBig = PictureBig;
            model.IndexFlag = IndexFlag;
            model.IndexSortID = IndexSortID;
            model.CommendFlag = CommendFlag;
            model.CommendSortID = CommendSortID;
            model.HotFlag = HotFlag;
            model.HotSortID = HotSortID;
            model.ChannelFlag = ChannelFlag;
            model.ChannelSortID = ChannelSortID;
            model.CategoryFlag = CategoryFlag;
            model.CategorySortID = CategorySortID;
            model.SortID = SortID;
            model.SEOTitle = AdminSEO1.SEOTitle;
            model.SEOKeywords = AdminSEO1.SEOKeywords;
            model.SEODescription = AdminSEO1.SEODescription;
            model.ShowFlag = ShowFlag;
            model.CheckFlag = CheckFlag;
            model.CheckDate = CheckDate;
            model.CheckUserID = CheckUserID;
            model.PostDate = PostDate;
            model.PostUserID = PostUserID;
            model.EditDate = EditDate;
            model.EditUserID = EditUserID;
            model.DelDate = DelDate;
            model.DelUserID = DelUserID;
            model.MemberFlag = MemberFlag;
            model.DiyFlag = DiyFlag;
            model.DiyTypeCn = DiyTypeCn;
            model.DiyTypeEn = DiyTypeEn;
            model.DiyTypePartsID = DiyTypePartsID;
            model.DiyTypePrice = DiyTypePrice;
            model.DiyTypeAttachmentFlag = DiyTypeAttachmentFlag;
            model.DiyExpression = DiyExpression;
            model.BasicDiscountPrice = BasicDiscountPrice;
            model.BasicDiscountJF = BasicDiscountJF;

            GK2010.BLL.Product bll = new GK2010.BLL.Product();
            int ret = bll.Add(model);

            #region 转向到操作结果界面
            if (ret > 0)
            {
                AdminIndustry1.Save(TableName.Product, ret);
                AdminMedium1.Save(TableName.Product, ret);
                AdminTag1.Save(TableName.Product, ret);
                MessageBox.ShowAlertAndRedirect(this.Page, "添加成功", "manage.aspx");
            }
            else
            {
                MessageBox.ShowAlert(this.Page, "添加失败");
            }
            #endregion

        }
        #endregion

    }
}
