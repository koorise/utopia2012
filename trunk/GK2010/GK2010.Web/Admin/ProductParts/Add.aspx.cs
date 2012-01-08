using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.ProductParts
{
    public partial class Add : System.Web.UI.Page
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("Product");
            if (!IsPostBack)
            {
                int Flag = ConfigParam.Flag;//类别为1,部件为2
                if (Flag == 1)
                {
                    lblTitle.Text = "类别名称";
                    tdTitleEn.Visible = false;
                    tdPrice.Visible = false;
                    tdDefaultFlag.Visible = false;
                    tdDetail.Visible = true;//了解更多显示                    
                    tdAttachment.Visible = true;
                    
                }
                if (Flag == 2)
                {
                    lblTitle.Text = "部件名称";
                    lblTitleEn.Text = "部件代码";
                    tdDetail.Visible = false;//了解更多不显示                    
                    tdAttachment.Visible = false;
                    tdDefaultFlag.Visible = true;
                }

                int AttachmentFlag = ConfigParam.AttachmentFlag;//1是附件，2不是附件）
                if (AttachmentFlag == 1)
                {
                    radAttachment.SelectedValue = "1";
                    lblAttachFlag.Text = "附件部件";
                }
                if (AttachmentFlag == 2)
                {
                    radAttachment.SelectedValue = "2";
                    lblAttachFlag.Text = "基本部件";
                }

                int ParentID = ConfigParam.ParentID;//父类别
                if (ParentID == 0)
                {
                    tdDetail.Visible = true;
                    tdAttachment.Visible = true;
                    tdShowFlag.Visible = true;
                }
                else
                {
                    tdDetail.Visible = false;
                    tdAttachment.Visible = false;
                    tdShowFlag.Visible = false;
                }

                txtParentID.Text = BLL.ProductParts.GetTitle(ConfigParam.ParentID);
            }
        }
        #endregion

        #region 添加
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int ProductID = ConfigParam.ProductID;//产品编号
            int ParentID = ConfigParam.ParentID;//父类别
            int Flag = ConfigParam.Flag;//类别为1,部件为2

            string Title = txtTitle.Text;
            string TitleEn = txtTitleEn.Text;
            string Detail = txtDetail.Value;
            decimal Price = DecimalHelper.Parse(txtPrice.Text, 0);
            decimal SortID = DecimalHelper.Parse(txtSortID.Text, 0);
            int ShowFlag = IntHelper.Parse( radShowFlag.SelectedValue,0);
            int DefaultFlag = IntHelper.Parse(radDefaultFlag.SelectedValue, 0);

            GK2010.Model.ProductParts model = new GK2010.Model.ProductParts();        
            model.ProductID = ProductID;
            model.ParentID = ParentID;       
            model.Title = Title;
            model.TitleEn = TitleEn;
            model.Price = Price;
            model.Detail = Detail;
            model.SortID = SortID;
            model.ShowFlag = ShowFlag;
            model.DefaultFlag = DefaultFlag;
            model.Flag = Flag;
            model.AttachmentFlag = IntHelper.Parse(radAttachment.SelectedValue,2);

            GK2010.BLL.ProductParts bll = new GK2010.BLL.ProductParts();
            int ret = bll.Add(model);

            #region 转向到操作结果界面
            if (ret > 0)
            {
                PriceHelper.UpdateProduct(model.ProductID);

                string ReturnUrl = ConfigParam.ReturnUrl;
                if (ReturnUrl == "") { ReturnUrl = "manage.aspx"; }
                MessageBox.ShowAlertAndRedirect(this.Page, "添加成功", ReturnUrl);
            }
            else
            {
                MessageBox.ShowAlert(this.Page, "添加失败");
            }
            #endregion

        }
        #endregion

        #region 返回
        protected void btnBack_Click(object sender, EventArgs e)
        {
            string ReturnUrl = ConfigParam.ReturnUrl;
            if (ReturnUrl == "") { ReturnUrl = "manage.aspx"; }
            Response.Redirect(ReturnUrl);
        }
        #endregion
        

    }
}
