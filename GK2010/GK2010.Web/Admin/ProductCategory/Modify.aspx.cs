using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.ProductCategory
{
    public partial class Modify : System.Web.UI.Page
    {
       	protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("ProductCategory");
			if (!IsPostBack)
			{
                GK2010.BLL.ProductCategory bll = new GK2010.BLL.ProductCategory();
                DropDownListHelper.Bind(dropParentID, "Title", "ID", bll.GetListDropDownList(ConfigParam.ID));          

				ShowInfo(ConfigParam.ID);
			}
		}
			
		private void ShowInfo(int ID)
		{
            GK2010.BLL.ProductCategory bll = new GK2010.BLL.ProductCategory();
            GK2010.Model.ProductCategory model = bll.GetModel(ConfigParam.ID);
			if(model != null)
			{
                dropParentID.SelectedValue = model.ParentID.ToString();
				txtTitle.Text=model.Title;
                txtTitleEn.Text = model.TitleEn;		
				txtSortID.Text=model.SortID.ToString();
                AdminSEO1.SEOTitle = model.SEOTitle;
                AdminSEO1.SEOKeywords = model.SEOKeywords;
                AdminSEO1.SEODescription = model.SEODescription;
			}
		}

		public void btnUpdate_Click(object sender, EventArgs e)
		{
            int ParentID = int.Parse(dropParentID.SelectedValue);
			string Title=this.txtTitle.Text;
            string TitleEn = this.txtTitleEn.Text;	
            decimal SortID = DecimalHelper.Parse(this.txtSortID.Text,0);

            GK2010.BLL.ProductCategory bll = new GK2010.BLL.ProductCategory();
            GK2010.Model.ProductCategory model = bll.GetModel(ConfigParam.ID);
			if(model != null)
			{
			    model.ParentID=ParentID;
			    model.Title=Title;
                model.TitleEn = TitleEn;
			    model.SortID=SortID;
                model.SEOTitle = AdminSEO1.SEOTitle;
                model.SEOKeywords = AdminSEO1.SEOKeywords;
                model.SEODescription = AdminSEO1.SEODescription;

				bool ret = bll.Update(model);

                #region ת�򵽲����������
                if (ret)
                {
                    string ReturnUrl = ConfigParam.ReturnUrl;
                    if (ReturnUrl == "")
                    {
                        ReturnUrl = "manage.aspx";
                    }
                    MessageBox.ShowAlertAndRedirect(this.Page, "�޸ĳɹ�", ReturnUrl);
                }
                else
                {
                    MessageBox.ShowAlert(this.Page, "�޸�ʧ��");
                }
                #endregion
			}

		}

    }
}
