using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.MemberGroup
{
    public partial class Add : System.Web.UI.Page
    {
       
	    #region Page_Load
	    protected void Page_Load(object sender, EventArgs e)
	    {
		     BLL.SystemTree.CheckPermission("MemberGroup");
	    }
	    #endregion

	    #region 添加
	    protected void btnAdd_Click(object sender, EventArgs e)
	    {		    
		    string Title = txtTitle.Text;		  
		    decimal SortID = DecimalHelper.Parse(txtSortID.Text,0);

		    GK2010.Model.MemberGroup model=new GK2010.Model.MemberGroup();		
		    model.Title = Title;
		    model.SortID = SortID;

		    GK2010.BLL.MemberGroup bll=new GK2010.BLL.MemberGroup();
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
