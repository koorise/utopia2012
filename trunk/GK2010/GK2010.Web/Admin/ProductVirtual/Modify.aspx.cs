using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.ProductVirtual
{
    public partial class Modify :System.Web.UI.Page
    {
       
	#region Page_Load
	protected void Page_Load(object sender, EventArgs e)
	{
        BLL.SystemTree.CheckPermission("Product");
		if (!IsPostBack)
		{
			ShowInfo(ConfigParam.ID);
		}
	}
	#endregion
	

	#region 显示信息
	private void ShowInfo(int ID)
	{
		GK2010.BLL.ProductVirtual bll=new GK2010.BLL.ProductVirtual();
		GK2010.Model.ProductVirtual model=bll.GetModel(ConfigParam.ID);
		if(model != null)
		{
			lblID.Text = model.ID.ToString();
			txtProductCategoryID.Text = model.ProductCategoryID.ToString();
			txtProductID.Text = model.ProductID.ToString();
			txtVirtualCategoryID.Text = model.VirtualCategoryID.ToString();
			txtVirtualID.Text = model.VirtualID.ToString();
		}
	}
	#endregion


	#region 修改
	public void btnUpdate_Click(object sender, EventArgs e)
	{
	

		int ProductCategoryID = IntHelper.Parse(txtProductCategoryID.Text,0);
		int ProductID = IntHelper.Parse(txtProductID.Text,0);
		int VirtualCategoryID = IntHelper.Parse(txtVirtualCategoryID.Text,0);
		int VirtualID = IntHelper.Parse(txtVirtualID.Text,0);


		GK2010.BLL.ProductVirtual bll = new GK2010.BLL.ProductVirtual();
		GK2010.Model.ProductVirtual model = bll.GetModel(ConfigParam.ID);
		if(model != null)
		{
			model.ProductCategoryID=ProductCategoryID;
			model.ProductID=ProductID;
			model.VirtualCategoryID=VirtualCategoryID;
			model.VirtualID=VirtualID;

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
