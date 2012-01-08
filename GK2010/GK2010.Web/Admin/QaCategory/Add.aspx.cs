using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.QaCategory
{
    public partial class Add : System.Web.UI.Page
    {
	    protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("QaCategory");
			if (!IsPostBack)
			{
                txtParentID.Text = BLL.QaCategory.GetTitle(ConfigParam.ParentID);
			}
		}

       	protected void btnAdd_Click(object sender, EventArgs e)
		{
            int ParentID = ConfigParam.ParentID;
			string Title=this.txtTitle.Text;
			string TitleEn=txtTitleEn.Text;
			string Summary="";
            string Detail = "";
			int PictureID=0;
			string Url=this.txtUrl.Text;
			string Path="";
			int HasChild=0;
            decimal SortID = DecimalHelper.Parse(this.txtSortID.Text,0);
            int UserID = ConfigParam.MemberID;
			int IsShow=1;
            int IsDefault = chkIsDefault.Checked?1:0;

			GK2010.Model.QaCategory model=new GK2010.Model.QaCategory();
			model.ParentID=ParentID;
			model.Title=Title;
			model.TitleEn=TitleEn;
			model.Summary=Summary;
			model.Detail=Detail;
			model.PictureID=PictureID;
			model.Url=Url;
			model.Path=Path;
			model.HasChild=HasChild;
			model.SortID=SortID;
			model.UserID=UserID;
			model.IsShow=IsShow;
			model.IsDefault=IsDefault;

			GK2010.BLL.QaCategory bll=new GK2010.BLL.QaCategory();
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
