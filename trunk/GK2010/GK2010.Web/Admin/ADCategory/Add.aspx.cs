using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.ADCategory
{
    public partial class Add : System.Web.UI.Page
    {
	    protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("ADCategory");
			
		}

       	protected void btnAdd_Click(object sender, EventArgs e)
		{
            int ParentID = ConfigParam.ParentID;
			string Title=this.txtTitle.Text;
			string TitleEn=txtTitleEn.Text;	
            decimal SortID = DecimalHelper.Parse(this.txtSortID.Text,0);          

            GK2010.Model.ADCategory model = new GK2010.Model.ADCategory();
			model.ParentID=ParentID;
			model.Title=Title;
			model.TitleEn=TitleEn;
			model.SortID=SortID;
          

            GK2010.BLL.ADCategory bll = new GK2010.BLL.ADCategory();
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

    }
}
