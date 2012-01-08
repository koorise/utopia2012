using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.ProductSpecial
{
    public partial class Add : System.Web.UI.Page
    {
       
	#region Page_Load
	protected void Page_Load(object sender, EventArgs e)
	{
		 BLL.SystemTree.CheckPermission("ProductSpecial");
	}
	#endregion

	#region 添加
	protected void btnAdd_Click(object sender, EventArgs e)
	{
	

		int ProductID = IntHelper.Parse(txtProductID.Text,0);
		decimal Price = DecimalHelper.Parse(txtPrice.Text,0);
		long StartDate = DatetimeHelper.ParseToLong(txtStartDate.Text);
		long EndDate = DatetimeHelper.ParseToLong(txtEndDate.Text);
		decimal SortID = DecimalHelper.Parse(txtSortID.Text,0);

		GK2010.Model.ProductSpecial model=new GK2010.Model.ProductSpecial();
		model.ProductID = ProductID;
		model.Price = Price;
		model.StartDate = StartDate;
		model.EndDate = EndDate;
		model.SortID = SortID;

		GK2010.BLL.ProductSpecial bll=new GK2010.BLL.ProductSpecial();
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
