using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.ProductPartsCache
{
    public partial class Add : System.Web.UI.Page
    {
       
	#region Page_Load
	protected void Page_Load(object sender, EventArgs e)
	{
		 BLL.SystemTree.CheckPermission("ProductPartsCache");
	}
	#endregion

	#region 添加
	protected void btnAdd_Click(object sender, EventArgs e)
	{
	

		long CacheID = DatetimeHelper.ParseToLong(txtCacheID.Text);
		int OldID = IntHelper.Parse(txtOldID.Text,0);
		int ProductCatchID = IntHelper.Parse(txtProductCatchID.Text,0);
		int RootID = IntHelper.Parse(txtRootID.Text,0);
		int CategoryID = IntHelper.Parse(txtCategoryID.Text,0);
		string CategoryPath = txtCategoryPath.Text;
		string Title = txtTitle.Text;
		string TitleEn = txtTitleEn.Text;
		string Summary = txtSummary.Text;
		string Detail = txtDetail.Text;
		int PictureID = IntHelper.Parse(txtPictureID.Text,0);
		string PictureSmall = txtPictureSmall.Text;
		string PictureNormal = txtPictureNormal.Text;
		string PictureBig = txtPictureBig.Text;
		decimal SortID = DecimalHelper.Parse(txtSortID.Text,0);
		long PostDate = DatetimeHelper.ParseToLong(txtPostDate.Text);
		int PostUserID = IntHelper.Parse(txtPostUserID.Text,0);
		int ShowFlag = IntHelper.Parse(txtShowFlag.Text,0);
		int DefaultFlag = IntHelper.Parse(txtDefaultFlag.Text,0);
		int AttachmentFlag = IntHelper.Parse(txtAttachmentFlag.Text,0);
		int Flag = IntHelper.Parse(txtFlag.Text,0);

		GK2010.Model.ProductPartsCache model=new GK2010.Model.ProductPartsCache();
		model.CacheID = CacheID;
		model.OldID = OldID;
		model.ProductCatchID = ProductCatchID;
		model.RootID = RootID;
		model.CategoryID = CategoryID;
		model.CategoryPath = CategoryPath;
		model.Title = Title;
		model.TitleEn = TitleEn;
		model.Summary = Summary;
		model.Detail = Detail;
		model.PictureID = PictureID;
		model.PictureSmall = PictureSmall;
		model.PictureNormal = PictureNormal;
		model.PictureBig = PictureBig;
		model.SortID = SortID;
		model.PostDate = PostDate;
		model.PostUserID = PostUserID;
		model.ShowFlag = ShowFlag;
		model.DefaultFlag = DefaultFlag;
		model.AttachmentFlag = AttachmentFlag;
		model.Flag = Flag;

		GK2010.BLL.ProductPartsCache bll=new GK2010.BLL.ProductPartsCache();
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
