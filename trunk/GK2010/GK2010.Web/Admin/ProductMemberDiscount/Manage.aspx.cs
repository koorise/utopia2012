using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
using System.Data;
namespace GK2010.Web.Admin.ProductMemberDiscount
{
    public partial class Manage : System.Web.UI.Page
    {
        //小类别
        public string SmallID = "";
        public int UserID = 0;

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("Product");
            if (!IsPostBack)
            {
                BLL.ProductCategory bll = new GK2010.BLL.ProductCategory();
                DropDownListHelper.Bind(dropBig, "Title", "ID", bll.GetList("0", "ParentID"));

                dropSmall.Items.Clear();
                dropSmall.Items.Insert(0, new ListItem("请选择", "0"));

                //用户名
                UserID = ConfigParam.UserID;
                txtUserName.Text = BLL.Member.GetRealName(ConfigParam.UserID) + "(" + BLL.Member.GetUserName(UserID) + ")";


                BindData();

                HyperLinkBack.NavigateUrl = "ManageMember.aspx";
            }
        }
        #endregion

        #region 绑定列表

        #region 绑定数据
        private void BindData()
        {
            string sql = "1=1";
            if (ConfigParam.Keyword != "")
            {
                txtKey.Text = ConfigParam.Keyword;
                sql += " and Title like '%" + ConfigParam.Keyword + "%'";
            }
            if (ConfigParam.BigID > 0)
            {
                dropBig.SelectedValue = ConfigParam.BigID.ToString();

                BLL.ProductCategory bllProductCategory = new GK2010.BLL.ProductCategory();
                DropDownListHelper.Bind(dropSmall, "Title", "ID", bllProductCategory.GetList(dropBig.SelectedValue, "ParentID"));

                sql += " and RootID = " + ConfigParam.BigID;
            }

            if (ConfigParam.SmallID > 0)
            {
                dropSmall.SelectedValue = ConfigParam.SmallID.ToString();
                sql += " and CategoryID = " + ConfigParam.SmallID;
            }

            int total = 0;
            int PageIndex = ConfigParam.Page;
            int PageSize = grid.PageSize;
            GK2010.BLL.ProductMemberDiscount bll = new GK2010.BLL.ProductMemberDiscount();
            DataSet ds = bll.GetList(PageSize, PageIndex, UserID, sql, out total);
            AspNetPager1.PageSize = PageSize;
            AspNetPager1.RecordCount = total;
            grid.DataKeyNames = "id".Split(',');
            grid.DataSource = ds;
            grid.DataBind();
        }
        #endregion

        #region grid_RowDataBound
        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //GK2010.Model.Product model = (GK2010.Model.Product)e.Row.DataItem;
                //string UrlRedirect = string.Format(ConfigUrl.AdminUrlModify, model.ID, ConfigUrl.CurrentUrl);
                //HyperLink HyperLinkModify = (HyperLink)e.Row.FindControl("HyperLinkModify");
                //HyperLinkModify.NavigateUrl = UrlRedirect;

                //UrlRedirect = string.Format(ConfigUrl.AdminUrlDelete, model.ID, ConfigUrl.CurrentUrl);
                //HyperLink HyperLinkDelete = (HyperLink)e.Row.FindControl("HyperLinkDelete");
                //HyperLinkDelete.NavigateUrl = UrlRedirect;
                //HyperLinkDelete.Attributes.Add("onclick", "return confirm('" + ResultMsg.DeleteConfirm + "')");

                //if (model.DiyFlag == 1)
                //{
                //    Literal txtParts = (Literal)e.Row.FindControl("txtParts");
                //    txtParts.Text = "<a id='btnParts" + model.ID + "' href=\"javascript:void(0)\" >[部件]</a>";
                //}
            }
        }
        #endregion

        #endregion

        #region 搜索
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage.aspx?UserID=" + ConfigParam.UserID + "&BigID=" + dropBig.SelectedValue + "&SmallID=" + dropSmall.SelectedValue + "&Keyword=" + txtKey.Text);
        }
        #endregion

        #region 类别
        protected void dropBig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropBig.SelectedValue != "0")
            {
                BLL.ProductCategory bll = new GK2010.BLL.ProductCategory();
                DropDownListHelper.Bind(dropSmall, "Title", "ID", bll.GetList(dropBig.SelectedValue, "ParentID"));
                Response.Redirect("manage.aspx?BigID=" + dropBig.SelectedValue + "&Keyword=" + txtKey.Text);
            }
            else
            {
                dropSmall.Items.Clear();
                dropSmall.Items.Insert(0, new ListItem("请选择", "0"));
                Response.Redirect("manage.aspx?UserID=" + ConfigParam.UserID + "&Keyword=" + txtKey.Text);
            }

        }

        protected void dropSmall_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropSmall.SelectedValue != "0")
            {
                Response.Redirect("manage.aspx?UserID=" + ConfigParam.UserID + "&BigID=" + dropBig.SelectedValue + "&SmallID=" + dropSmall.SelectedValue + "&Keyword=" + txtKey.Text);
            }
            else
            {
                Response.Redirect("manage.aspx?UserID=" + ConfigParam.UserID + "&BigID=" + dropBig.SelectedValue + "&Keyword=" + txtKey.Text);
            }
        }
        #endregion

        #region 批量设置
        protected void btnSetBatch_Click(object sender, EventArgs e)
        {
            int DiscountPrice = IntHelper.Parse(txtDiscountPrice.Text, -1);
            int DiscountJF = IntHelper.Parse(txtDiscountJF.Text, -1);
            bool Flag = false;
            if (DiscountPrice > 0 && DiscountPrice <= 100 && DiscountJF > 0 && DiscountJF <= 100)
            {
                for (int i = 0; i <= grid.Rows.Count - 1; i++)
                {
                    CheckBox chkID = (CheckBox)grid.Rows[i].FindControl("chkID");

                    #region 操作
                    if (chkID.Checked)
                    {
                        Flag = true;
                        int ProductID = IntHelper.Parse(grid.DataKeys[i].Value.ToString(), -1);
                        BLL.Product bllProduct = new GK2010.BLL.Product();
                        Model.Product modelProduct = bllProduct.GetModel(ProductID);
                        if (modelProduct != null)
                        {
                            //只有低于标准折扣的才可设置
                            if (DiscountPrice >= modelProduct.BasicDiscountPrice && DiscountJF >= modelProduct.BasicDiscountJF)
                            {
                                int UserID = ConfigParam.UserID;
                                BLL.ProductMemberDiscount bll = new GK2010.BLL.ProductMemberDiscount();
                                Model.ProductMemberDiscount model = bll.GetModel(UserID, ProductID);
                                if (model != null)
                                {
                                    model.CheckFlag = 1;
                                    model.DiscountPrice = DiscountPrice;
                                    model.DiscountJF = DiscountJF;
                                }
                                else
                                {
                                    model = new GK2010.Model.ProductMemberDiscount();
                                    model.UserID = UserID;
                                    model.ProductID = ProductID;
                                    model.DiscountPrice = DiscountPrice;
                                    model.DiscountJF = DiscountJF;
                                    model.CheckFlag = 1;
                                    model.CheckDate = 0;
                                    model.CheckUserID = 0;
                                }
                                bool ok = bll.Operator(model);
                            }
                        }
                    }
                    #endregion  
                }

                if (!Flag)
                {
                    MessageBox.ShowAlert(this, "修改失败：请先选择要批量设置的产品！");
                    return;
                }

                Response.Redirect(Request.RawUrl);
            }
            else
            {
                MessageBox.ShowAlert(this, "修改失败：折扣请设置成1-100之间的整数");
            }
        }
        #endregion
    }
}
