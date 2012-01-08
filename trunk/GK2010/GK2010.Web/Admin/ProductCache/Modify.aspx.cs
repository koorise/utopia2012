using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.ProductCache
{
    public partial class Modify :System.Web.UI.Page
    {
       
	#region Page_Load
	protected void Page_Load(object sender, EventArgs e)
	{
		BLL.SystemTree.CheckPermission("ProductCache");
		if (!IsPostBack)
		{
			ShowInfo(ConfigParam.ID);
		}
	}
	#endregion
	

	#region 显示信息
	private void ShowInfo(int ID)
	{
		GK2010.BLL.ProductCache bll=new GK2010.BLL.ProductCache();
		GK2010.Model.ProductCache model=bll.GetModel(ConfigParam.ID);
		if(model != null)
		{
			lblID.Text = model.ID.ToString();
			txtCacheID.Text = DatetimeHelper.Parse(model.CacheID,"yyyy-MM-dd HH:mm:ss");
			txtOldID.Text = model.OldID.ToString();
			txtCategoryID.Text = model.CategoryID.ToString();
			txtTitle.Text = model.Title;
			txtTitleEn.Text = model.TitleEn;
			txtSummary.Text = model.Summary;
			txtDetail.Text = model.Detail;
			txtTags.Text = model.Tags;
			txtHits.Text = model.Hits.ToString();
			txtUrl.Text = model.Url;
			txtDefaultBrand.Text = model.DefaultBrand;
			txtDefaultPeriod.Text = model.DefaultPeriod;
			txtDefaultPriceOld.Text = model.DefaultPriceOld.ToString();
			txtDefaultPrice.Text = model.DefaultPrice.ToString();
			txtDefaultJF.Text = model.DefaultJF.ToString();
			txtPictureID.Text = model.PictureID.ToString();
			txtPictureSmall.Text = model.PictureSmall;
			txtPictureNormal.Text = model.PictureNormal;
			txtPictureBig.Text = model.PictureBig;
			txtSortID.Text = model.SortID.ToString();
			txtShowFlag.Text = model.ShowFlag.ToString();
			txtPostDate.Text = DatetimeHelper.Parse(model.PostDate,"yyyy-MM-dd HH:mm:ss");
			txtPostUserID.Text = model.PostUserID.ToString();
			txtMemberFlag.Text = model.MemberFlag.ToString();
			txtDiyFlag.Text = model.DiyFlag.ToString();
			txtDiyTypeCn.Text = model.DiyTypeCn;
			txtDiyTypeEn.Text = model.DiyTypeEn;
			txtDiyTypePartsID.Text = model.DiyTypePartsID;
			txtDiyTypePrice.Text = model.DiyTypePrice;
			txtDiyTypeAttachmentFlag.Text = model.DiyTypeAttachmentFlag;
			txtDiyExpression.Text = model.DiyExpression;
			txtBasicDiscountPrice.Text = model.BasicDiscountPrice.ToString();
			txtBasicDiscountJF.Text = model.BasicDiscountJF.ToString();
		}
	}
	#endregion


	#region 修改
	public void btnUpdate_Click(object sender, EventArgs e)
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


		GK2010.BLL.ProductCache bll = new GK2010.BLL.ProductCache();
		GK2010.Model.ProductCache model = bll.GetModel(ConfigParam.ID);
		if(model != null)
		{
			model.CacheID=CacheID;
			model.OldID=OldID;
			model.CategoryID=CategoryID;
			model.Title=Title;
			model.TitleEn=TitleEn;
			model.Summary=Summary;
			model.Detail=Detail;
			model.Tags=Tags;
			model.Hits=Hits;
			model.Url=Url;
			model.DefaultBrand=DefaultBrand;
			model.DefaultPeriod=DefaultPeriod;
			model.DefaultPriceOld=DefaultPriceOld;
			model.DefaultPrice=DefaultPrice;
			model.DefaultJF=DefaultJF;
			model.PictureID=PictureID;
			model.PictureSmall=PictureSmall;
			model.PictureNormal=PictureNormal;
			model.PictureBig=PictureBig;
			model.SortID=SortID;
			model.ShowFlag=ShowFlag;
			model.PostDate=PostDate;
			model.PostUserID=PostUserID;
			model.MemberFlag=MemberFlag;
			model.DiyFlag=DiyFlag;
			model.DiyTypeCn=DiyTypeCn;
			model.DiyTypeEn=DiyTypeEn;
			model.DiyTypePartsID=DiyTypePartsID;
			model.DiyTypePrice=DiyTypePrice;
			model.DiyTypeAttachmentFlag=DiyTypeAttachmentFlag;
			model.DiyExpression=DiyExpression;
			model.BasicDiscountPrice=BasicDiscountPrice;
			model.BasicDiscountJF=BasicDiscountJF;

			bool ret = bll.Update(model);
			
			#region 转向到操作结果界面
			 if (ret)
			{
				string ReturnUrl = ConfigParam.ReturnUrl;
				if (ReturnUrl == ""){ReturnUrl = "manage.aspx";}
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
