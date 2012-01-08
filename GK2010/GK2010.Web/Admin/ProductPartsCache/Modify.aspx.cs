using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.ProductPartsCache
{
    public partial class Modify :System.Web.UI.Page
    {
       
	#region Page_Load
	protected void Page_Load(object sender, EventArgs e)
	{
		BLL.SystemTree.CheckPermission("ProductPartsCache");
		if (!IsPostBack)
		{
			ShowInfo(ConfigParam.ID);
		}
	}
	#endregion
	

	#region 显示信息
	private void ShowInfo(int ID)
	{
		GK2010.BLL.ProductPartsCache bll=new GK2010.BLL.ProductPartsCache();
		GK2010.Model.ProductPartsCache model=bll.GetModel(ConfigParam.ID);
		if(model != null)
		{
			lblID.Text = model.ID.ToString();
			txtCacheID.Text = DatetimeHelper.Parse(model.CacheID,"yyyy-MM-dd HH:mm:ss");
			txtOldID.Text = model.OldID.ToString();
			txtProductCatchID.Text = model.ProductCatchID.ToString();
			txtRootID.Text = model.RootID.ToString();
			txtCategoryID.Text = model.CategoryID.ToString();
			txtCategoryPath.Text = model.CategoryPath;
			txtTitle.Text = model.Title;
			txtTitleEn.Text = model.TitleEn;
			txtSummary.Text = model.Summary;
			txtDetail.Text = model.Detail;
			txtPictureID.Text = model.PictureID.ToString();
			txtPictureSmall.Text = model.PictureSmall;
			txtPictureNormal.Text = model.PictureNormal;
			txtPictureBig.Text = model.PictureBig;
			txtSortID.Text = model.SortID.ToString();
			txtPostDate.Text = DatetimeHelper.Parse(model.PostDate,"yyyy-MM-dd HH:mm:ss");
			txtPostUserID.Text = model.PostUserID.ToString();
			txtShowFlag.Text = model.ShowFlag.ToString();
			txtDefaultFlag.Text = model.DefaultFlag.ToString();
			txtAttachmentFlag.Text = model.AttachmentFlag.ToString();
			txtFlag.Text = model.Flag.ToString();
		}
	}
	#endregion


	#region 修改
	public void btnUpdate_Click(object sender, EventArgs e)
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


		GK2010.BLL.ProductPartsCache bll = new GK2010.BLL.ProductPartsCache();
		GK2010.Model.ProductPartsCache model = bll.GetModel(ConfigParam.ID);
		if(model != null)
		{
			model.CacheID=CacheID;
			model.OldID=OldID;
			model.ProductCatchID=ProductCatchID;
			model.RootID=RootID;
			model.CategoryID=CategoryID;
			model.CategoryPath=CategoryPath;
			model.Title=Title;
			model.TitleEn=TitleEn;
			model.Summary=Summary;
			model.Detail=Detail;
			model.PictureID=PictureID;
			model.PictureSmall=PictureSmall;
			model.PictureNormal=PictureNormal;
			model.PictureBig=PictureBig;
			model.SortID=SortID;
			model.PostDate=PostDate;
			model.PostUserID=PostUserID;
			model.ShowFlag=ShowFlag;
			model.DefaultFlag=DefaultFlag;
			model.AttachmentFlag=AttachmentFlag;
			model.Flag=Flag;

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
