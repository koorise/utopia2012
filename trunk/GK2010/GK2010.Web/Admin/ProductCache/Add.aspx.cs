using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.ProductCache
{
    public partial class Add : System.Web.UI.Page
    {
       
	#region Page_Load
	protected void Page_Load(object sender, EventArgs e)
	{
		 BLL.SystemTree.CheckPermission("ProductCache");
	}
	#endregion

	#region 添加
	protected void btnAdd_Click(object sender, EventArgs e)
	{
	

		long CacheID = DatetimeHelper.ParseToLong(txtCacheID.Text);
		int OldID = IntHelper.Parse(txtOldID.Text,0);
		int CategoryID = IntHelper.Parse(txtCategoryID.Text,0);
		string Title = txtTitle.Text;
		string TitleEn = txtTitleEn.Text;
		string Summary = txtSummary.Text;
		string Detail = txtDetail.Text;
		string Tags = txtTags.Text;
		int Hits = IntHelper.Parse(txtHits.Text,0);
		string Url = txtUrl.Text;
		string DefaultBrand = txtDefaultBrand.Text;
		string DefaultPeriod = txtDefaultPeriod.Text;
		decimal DefaultPriceOld = DecimalHelper.Parse(txtDefaultPriceOld.Text,0);
		decimal DefaultPrice = DecimalHelper.Parse(txtDefaultPrice.Text,0);
		decimal DefaultJF = DecimalHelper.Parse(txtDefaultJF.Text,0);
		int PictureID = IntHelper.Parse(txtPictureID.Text,0);
		string PictureSmall = txtPictureSmall.Text;
		string PictureNormal = txtPictureNormal.Text;
		string PictureBig = txtPictureBig.Text;
		decimal SortID = DecimalHelper.Parse(txtSortID.Text,0);
		int ShowFlag = IntHelper.Parse(txtShowFlag.Text,0);
		long PostDate = DatetimeHelper.ParseToLong(txtPostDate.Text);
		int PostUserID = IntHelper.Parse(txtPostUserID.Text,0);
		int MemberFlag = IntHelper.Parse(txtMemberFlag.Text,0);
		int DiyFlag = IntHelper.Parse(txtDiyFlag.Text,0);
		string DiyTypeCn = txtDiyTypeCn.Text;
		string DiyTypeEn = txtDiyTypeEn.Text;
		string DiyTypePartsID = txtDiyTypePartsID.Text;
		string DiyTypePrice = txtDiyTypePrice.Text;
		string DiyTypeAttachmentFlag = txtDiyTypeAttachmentFlag.Text;
		string DiyExpression = txtDiyExpression.Text;
		int BasicDiscountPrice = IntHelper.Parse(txtBasicDiscountPrice.Text,0);
		int BasicDiscountJF = IntHelper.Parse(txtBasicDiscountJF.Text,0);

		GK2010.Model.ProductCache model=new GK2010.Model.ProductCache();
		model.CacheID = CacheID;
		model.OldID = OldID;
		model.CategoryID = CategoryID;
		model.Title = Title;
		model.TitleEn = TitleEn;
		model.Summary = Summary;
		model.Detail = Detail;
		model.Tags = Tags;
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
		model.SortID = SortID;
		model.ShowFlag = ShowFlag;
		model.PostDate = PostDate;
		model.PostUserID = PostUserID;
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

		GK2010.BLL.ProductCache bll=new GK2010.BLL.ProductCache();
		int ret = bll.Add(model);
		
		#region 转向到操作结果界面
		 if (ret > 0)
		{
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
