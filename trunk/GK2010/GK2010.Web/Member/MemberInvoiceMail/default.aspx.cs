using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GK2010.Utility;

namespace GK2010.Web.Member.MemberInvoiceMail
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        #region 绑定
        private void BindData()
        {
            DataSet ds = DbHelperSQL.Query("select * from MemberInvoiceMail where UserID=" + Common.LoginHelper.UserID);

            GridView1.DataSource = ds;
            GridView1.DataBind();

            if (ds.Tables[0].Rows.Count == 0)
            {
                //btnAdd.Visible = false;
                btnDelete.Visible = false;
            }
        }
        #endregion

        #region 添加
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("member_InvoiceMail_add.aspx");
        }
        #endregion

        #region 删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            bool CheckFlag = false;
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox chkID = (CheckBox)GridView1.Rows[i].FindControl("chkID");
                if (chkID.Checked == true)
                {
                    CheckFlag = true;

                    //只可删除自己添加的信息
                    int ID = int.Parse(GridView1.DataKeys[i].Value.ToString());
                    BLL.MemberInvoiceMail bll = new BLL.MemberInvoiceMail();
                    Model.MemberInvoiceMail model = bll.GetModel(ID);
                    if (model != null && model.UserID == Common.LoginHelper.UserID)
                    {
                        bll.Delete(ID);
                    }
                }
            }

            if (!CheckFlag)
            {
                MessageBox.ShowAlert(this, "对不起，请选择要删除的行!");
                //MessageBox.ShowAlertAndRedirect(this, "对不起，请选择要删除的行!","default.aspx");
                return;
            }
            BindData();
        }
        #endregion

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;

                Literal txtDefaultFlag = (Literal)e.Row.FindControl("txtDefaultFlag");
                if (drv["DefaultFlag"].ToString() == "1")
                    txtDefaultFlag.Text = "是";
                else
                    txtDefaultFlag.Text = "否";



                HyperLink HyperLinkModify = (HyperLink)e.Row.FindControl("HyperLinkModify");
                HyperLinkModify.NavigateUrl = "member_Invoice_modify.aspx?InvoiceMailID=" + drv["id"].ToString();
            }
        }
    }
}
