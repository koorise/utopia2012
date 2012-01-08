using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.FriendLink
{
    public partial class Modify :System.Web.UI.Page
    {
       
	    #region Page_Load
	    protected void Page_Load(object sender, EventArgs e)
	    {
		    BLL.SystemTree.CheckPermission("FriendLink");
		    if (!IsPostBack)
		    {
			    ShowInfo(ConfigParam.ID);
		    }
	    }
	    #endregion
    	

	    #region 显示信息
	    private void ShowInfo(int ID)
	    {
		    GK2010.BLL.FriendLink bll=new GK2010.BLL.FriendLink();
		    GK2010.Model.FriendLink model=bll.GetModel(ConfigParam.ID);
		    if(model != null)
		    {
			    txtTitle.Text = model.Title;
			    txtUrl.Text = model.Url;
			    txtSortID.Text = model.SortID.ToString();
		    }
	    }
	    #endregion


	    #region 修改
	    public void btnUpdate_Click(object sender, EventArgs e)
	    {
            string Title = txtTitle.Text;
            string Url = txtUrl.Text;
            decimal SortID = DecimalHelper.Parse(txtSortID.Text, 0);

		    GK2010.BLL.FriendLink bll = new GK2010.BLL.FriendLink();
		    GK2010.Model.FriendLink model = bll.GetModel(ConfigParam.ID);
		    if(model != null)
		    {
                model.Title = Title;
                model.Url = Url;
                model.SortID = SortID;

			    bool ret = bll.Update(model);
    			
			    #region 转向到操作结果界面
			     if (ret)
			    {
				    string ReturnUrl = ConfigParam.ReturnUrl;
				    if (ReturnUrl == ""){ReturnUrl = "manage.aspx";}
                    MessageBox.ShowAlertAndRedirect(this.Page, "修改成功", ReturnUrl);
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
