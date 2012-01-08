using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.ProductSpecial
{
    public partial class Modify :System.Web.UI.Page
    {
       
	#region Page_Load
	protected void Page_Load(object sender, EventArgs e)
	{
		BLL.SystemTree.CheckPermission("ProductSpecial");
		if (!IsPostBack)
		{
			ShowInfo(ConfigParam.ID);
		}
	}
	#endregion
	

	#region 显示信息
	private void ShowInfo(int ID)
	{
		GK2010.BLL.ProductSpecial bll=new GK2010.BLL.ProductSpecial();
		GK2010.Model.ProductSpecial model=bll.GetModel(ConfigParam.ID);
		if(model != null)
		{
			lblID.Text = model.ID.ToString();
			txtProductID.Text = model.ProductID.ToString();
			txtPrice.Text = model.Price.ToString();
			txtStartDate.Text = DatetimeHelper.Parse(model.StartDate,"yyyy-MM-dd HH:mm:ss");
			txtEndDate.Text = DatetimeHelper.Parse(model.EndDate,"yyyy-MM-dd HH:mm:ss");
			txtSortID.Text = model.SortID.ToString();
		}
	}
	#endregion


	#region 修改
	public void btnUpdate_Click(object sender, EventArgs e)
	{
	

		int ProductID = IntHelper.Parse(txtProductID.Text,0);
		decimal Price = DecimalHelper.Parse(txtPrice.Text,0);
		long StartDate = DatetimeHelper.ParseToLong(txtStartDate.Text);
		long EndDate = DatetimeHelper.ParseToLong(txtEndDate.Text);
		decimal SortID = DecimalHelper.Parse(txtSortID.Text,0);


		GK2010.BLL.ProductSpecial bll = new GK2010.BLL.ProductSpecial();
		GK2010.Model.ProductSpecial model = bll.GetModel(ConfigParam.ID);
		if(model != null)
		{
			model.ProductID=ProductID;
			model.Price=Price;
			model.StartDate=StartDate;
			model.EndDate=EndDate;
			model.SortID=SortID;

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
