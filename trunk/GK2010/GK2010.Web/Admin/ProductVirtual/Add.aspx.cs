using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.ProductVirtual
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
	

		int ProductCategoryID = IntHelper.Parse(txtProductCategoryID.Text,0);
		int ProductID = IntHelper.Parse(txtProductID.Text,0);
		int VirtualCategoryID = IntHelper.Parse(txtVirtualCategoryID.Text,0);
		int VirtualID = IntHelper.Parse(txtVirtualID.Text,0);

		GK2010.Model.ProductVirtual model=new GK2010.Model.ProductVirtual();
		model.ProductCategoryID = ProductCategoryID;
		model.ProductID = ProductID;
		model.VirtualCategoryID = VirtualCategoryID;
		model.VirtualID = VirtualID;

		GK2010.BLL.ProductVirtual bll=new GK2010.BLL.ProductVirtual();
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
