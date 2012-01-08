using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.QaCategory
{
    public partial class Modify : System.Web.UI.Page
    {
       	protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("QaCategory");
			if (!IsPostBack)
			{
                GK2010.BLL.QaCategory bll = new GK2010.BLL.QaCategory();
                DropDownListHelper.Bind(dropParentID, "Title", "ID", bll.GetListDropDownList(ConfigParam.ID));     
               
				ShowInfo(ConfigParam.ID);
			}
		}
			
		private void ShowInfo(int ID)
		{
			GK2010.BLL.QaCategory bll=new GK2010.BLL.QaCategory();
			GK2010.Model.QaCategory model=bll.GetModel(ConfigParam.ID);
			if(model != null)
			{
                dropParentID.SelectedValue = model.ParentID.ToString();
				txtTitle.Text=model.Title;
                txtTitleEn.Text = model.TitleEn;		
				txtUrl.Text=model.Url;
				
				txtSortID.Text=model.SortID.ToString();
				chkIsDefault.Checked=model.IsDefault == 1;
			}
		}

		public void btnUpdate_Click(object sender, EventArgs e)
		{
            int ParentID = int.Parse(dropParentID.SelectedValue);
			string Title=this.txtTitle.Text;
            string TitleEn = this.txtTitleEn.Text;
			string Url=this.txtUrl.Text;
            decimal SortID = DecimalHelper.Parse(this.txtSortID.Text,0);
            int IsDefault = chkIsDefault.Checked?1:0;

			GK2010.BLL.QaCategory bll=new GK2010.BLL.QaCategory();
			GK2010.Model.QaCategory model=bll.GetModel(ConfigParam.ID);
			if(model != null)
			{
			    model.ParentID=ParentID;
			    model.Title=Title;
                model.TitleEn = TitleEn;
			    model.Url=Url;
			    model.SortID=SortID;
			    model.IsDefault=IsDefault;

				bool ret = bll.Update(model);

                #region 转向到操作结果界面
                if (ret)
                {
                    string ReturnUrl = ConfigParam.ReturnUrl;
                    if (ReturnUrl == "")
                    {
                        ReturnUrl = "manage.aspx";
                    }
                    MessageBox.ShowAlertAndRedirect(this.Page, "修改成功", ReturnUrl);
                }
                else
                {
                    MessageBox.ShowAlert(this.Page, "修改失败");
                }
                #endregion
			}

		}

    }
}
