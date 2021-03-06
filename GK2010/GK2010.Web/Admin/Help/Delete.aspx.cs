using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections.Generic;
using GK2010.Utility;
namespace GK2010.Web.Admin.Help
{
    public partial class Delete : System.Web.UI.Page
    {        
        
	#region  Page_Load
	protected void Page_Load(object sender, EventArgs e)
	{
		 BLL.SystemTree.CheckPermission("Help");
		GK2010.BLL.Help bll = new GK2010.BLL.Help();
		bool ret = false;
		int rowsAffected = 0;
		
		#region  批量删除
		if (ConfigParam.IDs != "")
		{
			List<int> models = StringHelper.ToIntList(ConfigParam.IDs);
			foreach(int id in models)
			{
				ret = bll.Delete(id);
				if (ret)
				{
					rowsAffected++;
				}
			}
		}
		#endregion
		
		#region  单个删除
		if (ConfigParam.ID > 0)
		{
			ret = bll.Delete(Utility.ConfigParam.ID);
			if (ret)
			{
				rowsAffected = 1;
			}
		}
		#endregion
			
		#region 转向到操作结果界面
		 if (rowsAffected > 0)
		{
			MessageBox.ShowAlertAndRedirect(this.Page, "删除成功", "manage.aspx");
		}
		else
		{
			MessageBox.ShowAlertAndRedirect(this.Page, "删除失败", "manage.aspx");
		}
		#endregion
	}
	#endregion

    }
}
