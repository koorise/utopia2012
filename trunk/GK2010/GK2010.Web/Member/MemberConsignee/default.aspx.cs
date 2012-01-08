using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using System.Data;

namespace GK2010.Web.Member.MemberConsignee
{
    public partial class _default : System.Web.UI.Page
    {
       // protected readonly BLL.MemberConsignee bll_mc = new BLL.MemberConsignee();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                BindData();
            //}
        }

        #region 绑定
        private void BindData()
        {
            DataSet ds = DbHelperSQL.Query("select * from MemberConsignee where UserID=" + Common.LoginHelper.UserID);

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
            Response.Redirect("member_consignee_add.aspx");
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
                    BLL.MemberConsignee bll = new BLL.MemberConsignee();
                    Model.MemberConsignee model = bll.GetModel(ID);
                    if (model != null && model.UserID == Common.LoginHelper.UserID)
                    {
                        bll.Delete(ID);
                    }
                }
            }

            if (!CheckFlag)
            {
                MessageBox.ShowAlert(this, "对不起，请选择要删除的行!");
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
                HyperLinkModify.NavigateUrl = "member_consignee_modify.aspx?ConsigneeID=" + drv["id"].ToString();
            }
        }
    }
}