using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.ProductParts
{
    public partial class Manage : System.Web.UI.Page
    {
        public int I = 1;
        public int ProductID = 0;

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("Product");
            if (!IsPostBack)
            {
                ProductID = ConfigParam.ProductID;

                ShowInfo();

                GK2010.BLL.ProductParts bll = new GK2010.BLL.ProductParts();
                RepeaterList.DataSource = bll.GetListNew(ConfigParam.ProductID);
                RepeaterList.DataBind();
            }
        }

        protected void ShowInfo()
        {
            GK2010.BLL.Product bll = new GK2010.BLL.Product();
            Model.Product model = bll.GetModel(ConfigParam.ProductID);
            if (model != null)
            {
                lblType.Text = model.DefaultType;
                lblPrice.Text = model.DefaultPrice.ToString("#.##");
                txtExpressions.Text = model.DiyExpression;
            }
        }


        protected void RepeaterList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.ProductParts model = (Model.ProductParts)e.Item.DataItem;

                    BLL.ProductParts bll = new BLL.ProductParts();
                    Literal txtParam = (Literal)e.Item.FindControl("txtParam");
                    Literal txtParamCode = (Literal)e.Item.FindControl("txtParamCode");
                    Literal txtTdStart = (Literal)e.Item.FindControl("txtTdStart");
                    Literal txtTdEnd = (Literal)e.Item.FindControl("txtTdEnd");
                    txtTdStart.Text = "<td class=\"td4 tdcur\" style=\"width:100%\">";

                    #region 类别添加，修改，删除 
                    //第1级
                    if (model.Path.Split(',').Length == 1)
                    {
                        //类别标题
                        txtParam.Text = "<span style='font-weight:bold;font-size:14px'>" + ABCHelper.Parse(I++) +"&nbsp;"+ model.Title + "</span>";

                        //hasChild=0 HasParts=0说明可以添加子类别和部件 
                        //hasChild=0 HasParts=1说明有部件，不可再加类别
                        //hasChild=1 HasParts=0说明有类别，不可再加部件
                        if (model.HasChild == 0 && model.HasParts == 0)
                        {
                            txtParam.Text += "<a href='" + GetRedirectUrl("add", 0, model.ID, 1, model.AttachmentFlag) + "'>[添加类别]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("add", 0, model.ID, 2, model.AttachmentFlag) + "'>[添加部件]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("modify", model.ID, model.ParentID, 1, model.AttachmentFlag) + "'>[修改]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("delete", model.ID, model.ParentID, 1, model.AttachmentFlag) + "' onclick='return confirm(\"您确定要删除吗？\")'>[删除]</a>";
                        }
                        if (model.HasChild == 0 && model.HasParts == 1)
                        {
                            txtParam.Text += "<a href='" + GetRedirectUrl("add", 0, model.ID, 2, model.AttachmentFlag) + "'>[添加部件]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("modify", model.ID, model.ParentID, 1, model.AttachmentFlag) + "'>[修改]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("delete", model.ID, model.ParentID, 1, model.AttachmentFlag) + "' onclick='return confirm(\"您确定要删除吗？\")'>[删除]</a>";
                        }

                        if (model.HasChild == 1 && model.HasParts == 0)
                        {
                            txtParam.Text += "<a href='" + GetRedirectUrl("add", 0, model.ID, 1, model.AttachmentFlag) + "'>[添加类别]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("modify", model.ID, model.ParentID, 1, model.AttachmentFlag) + "'>[修改]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("delete", model.ID, model.ParentID, 1, model.AttachmentFlag) + "' onclick='return confirm(\"您确定要删除吗？\")'>[删除]</a>";
                        }
                    }

                    //第2级
                    if (model.Path.Split(',').Length == 2)
                    {
                        //Flag 类别为1,部件为2
                        if (model.Flag == 1)
                        {
                            txtParam.Text = "<span style='font-weight:bold;font-size:14px'>" + model.Title + "</span>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("add", 0, model.ID, 2, model.AttachmentFlag) + "'>[添加部件]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("modify", model.ID, model.ParentID, 1, model.AttachmentFlag) + "'>[修改]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("delete", model.ID, model.ParentID, 1, model.AttachmentFlag) + "' onclick='return confirm(\"您确定要删除吗？\")'>[删除]</a>";
                        }
                    }

                    #endregion

                    #region 部件的编辑与删除
                    if (model.Flag == 2)
                    {
                        string IsDefault = "";
                        string DefaultCss = "";
                        if (model.DefaultFlag == 1)
                        {
                            IsDefault = "checked";
                            DefaultCss = "checked";
                        }
                        txtTdStart.Text = "<td class=\"td4 tdcur\" style=\"width:100%; background:#ffffff; \" >";

                        txtParamCode.Text = "<span id=\"span_rad_" + model.ID + "\" class=\"" + DefaultCss + "\">";
                        txtParamCode.Text += "<input type=radio name='rad" + model.RootID + "' onclick='ChangeOption(\"rad" + model.RootID + "\",this.value)' value='" + model.ID + "' " + IsDefault + " >";
                        txtParamCode.Text += model.TitleEn + "&nbsp;" + model.Title + "&nbsp;价格：" + model.Price + "元";
                        txtParamCode.Text += "</span>";

                        txtParam.Text += "&nbsp;<a href='" + GetRedirectUrl("modify", model.ID, model.ParentID, 2, model.AttachmentFlag) + "'>[修改]</a>";
                        txtParam.Text += "&nbsp;<a href='" + GetRedirectUrl("delete", model.ID, model.ParentID, 2, model.AttachmentFlag) + "'>[删除]</a>";
                    }
                    #endregion

                    //附件背景色
                    if (model.AttachmentFlag == 1)
                    {
                        txtTdStart.Text = "<td class=\"td4 tdcur\" style=\"width:100%; background:#D9ACCA\">";
                    }
                    //不显示背景色
                    if (model.ShowFlag == 0)
                    {
                        txtTdStart.Text = "<td class=\"td4 tdcur\" style=\"width:100%; background:gray;\">";
                    }
                    
                    txtTdEnd.Text = "</td>";
                    
                    break;
            }
        }
        #endregion

        #region 新增
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            RedirectUrl(0, 1, 2);
        }
        #endregion

        #region 新增附件
        protected void btnAddFJ_Click(object sender, EventArgs e)
        {
            RedirectUrl(0,1,1);
        }
        #endregion

        #region 转向Url
        /// <summary>
        /// 转向Url
        /// </summary>
        /// <param name="ParentID">父类别</param>
        /// <param name="Flag">类别为1,部件为2</param>
        /// <param name="AttachmentFlag">1是附件，2不是附件</param>
        protected void RedirectUrl(int ParentID, int Flag, int AttachmentFlag)
        {
            Response.Redirect(GetRedirectUrl("add",0,ParentID, Flag, AttachmentFlag));
        }

        /// <param name="AttachmentFlag"></param>
       /// <summary>
        /// 获取Url
       /// </summary>
       /// <param name="type">add,delete,modify</param>
       /// <param name="ID">编号</param>
        /// <param name="ParentID">父类别</param>
        /// <param name="Flag">类别为1,部件为2</param>
        /// <param name="AttachmentFlag">1是附件，2不是附件</param>
       /// <returns></returns>
        protected string GetRedirectUrl(string type,int ID,int ParentID, int Flag, int AttachmentFlag)
        {
            int ProductID = ConfigParam.ProductID;//产品编号
            string UrlRedirect = type+".aspx?Flag=" + Flag + "&ID="+ID+"&ProductID=" + ProductID + "&AttachmentFlag=" + AttachmentFlag + "&ParentID=" + ParentID + "&ReturnUrl=" + ConfigUrl.ReturnUrl;
            return UrlRedirect;
        }
        #endregion

        #region 保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in RepeaterList.Items)
            {
                HtmlInputHidden txtID = (HtmlInputHidden)item.FindControl("txtID");
                HtmlInputText txtSortID = (HtmlInputText)item.FindControl("txtSortID");
                GK2010.BLL.ProductParts bll = new GK2010.BLL.ProductParts();
                GK2010.Model.ProductParts model = bll.GetModel(int.Parse(txtID.Value));
                if (model != null)
                {
                    model.SortID = DecimalHelper.Parse(txtSortID.Value, 0);
                    bll.Update(model);
                }
            }

            #region 转向到操作结果界面
            Response.Redirect(Request.RawUrl);
            #endregion
        }
        #endregion
    }
}
