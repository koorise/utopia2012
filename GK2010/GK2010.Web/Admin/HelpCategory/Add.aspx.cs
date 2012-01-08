using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.HelpCategory
{
    public partial class Add : System.Web.UI.Page
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("HelpCategory");
        }
        #endregion

        #region ���
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            string Title = txtTitle.Text;
            string TitleEn = txtTitleEn.Text;           
            decimal SortID = DecimalHelper.Parse(txtSortID.Text, 0);
          

            GK2010.Model.HelpCategory model = new GK2010.Model.HelpCategory();
          
            model.Title = Title;
            model.TitleEn = TitleEn;        
            model.SortID = SortID;
            model.SEOTitle = AdminSEO1.SEOTitle;
            model.SEOKeywords = AdminSEO1.SEOKeywords;
            model.SEODescription = AdminSEO1.SEODescription;


            GK2010.BLL.HelpCategory bll = new GK2010.BLL.HelpCategory();
            int ret = bll.Add(model);

            #region ת�򵽲����������
            if (ret > 0)
            {
                MessageBox.ShowAlertAndRedirect(this.Page, "��ӳɹ�", "manage.aspx");
            }
            else
            {
                MessageBox.ShowAlert(this.Page, "���ʧ��");
            }
            #endregion

        }
        #endregion

    }
}
