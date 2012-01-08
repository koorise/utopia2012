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

                    #region �����ӣ��޸ģ�ɾ�� 
                    //��1��
                    if (model.Path.Split(',').Length == 1)
                    {
                        //������
                        txtParam.Text = "<span style='font-weight:bold;font-size:14px'>" + ABCHelper.Parse(I++) +"&nbsp;"+ model.Title + "</span>";

                        //hasChild=0 HasParts=0˵��������������Ͳ��� 
                        //hasChild=0 HasParts=1˵���в����������ټ����
                        //hasChild=1 HasParts=0˵������𣬲����ټӲ���
                        if (model.HasChild == 0 && model.HasParts == 0)
                        {
                            txtParam.Text += "<a href='" + GetRedirectUrl("add", 0, model.ID, 1, model.AttachmentFlag) + "'>[������]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("add", 0, model.ID, 2, model.AttachmentFlag) + "'>[��Ӳ���]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("modify", model.ID, model.ParentID, 1, model.AttachmentFlag) + "'>[�޸�]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("delete", model.ID, model.ParentID, 1, model.AttachmentFlag) + "' onclick='return confirm(\"��ȷ��Ҫɾ����\")'>[ɾ��]</a>";
                        }
                        if (model.HasChild == 0 && model.HasParts == 1)
                        {
                            txtParam.Text += "<a href='" + GetRedirectUrl("add", 0, model.ID, 2, model.AttachmentFlag) + "'>[��Ӳ���]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("modify", model.ID, model.ParentID, 1, model.AttachmentFlag) + "'>[�޸�]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("delete", model.ID, model.ParentID, 1, model.AttachmentFlag) + "' onclick='return confirm(\"��ȷ��Ҫɾ����\")'>[ɾ��]</a>";
                        }

                        if (model.HasChild == 1 && model.HasParts == 0)
                        {
                            txtParam.Text += "<a href='" + GetRedirectUrl("add", 0, model.ID, 1, model.AttachmentFlag) + "'>[������]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("modify", model.ID, model.ParentID, 1, model.AttachmentFlag) + "'>[�޸�]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("delete", model.ID, model.ParentID, 1, model.AttachmentFlag) + "' onclick='return confirm(\"��ȷ��Ҫɾ����\")'>[ɾ��]</a>";
                        }
                    }

                    //��2��
                    if (model.Path.Split(',').Length == 2)
                    {
                        //Flag ���Ϊ1,����Ϊ2
                        if (model.Flag == 1)
                        {
                            txtParam.Text = "<span style='font-weight:bold;font-size:14px'>" + model.Title + "</span>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("add", 0, model.ID, 2, model.AttachmentFlag) + "'>[��Ӳ���]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("modify", model.ID, model.ParentID, 1, model.AttachmentFlag) + "'>[�޸�]</a>";
                            txtParam.Text += "<a href='" + GetRedirectUrl("delete", model.ID, model.ParentID, 1, model.AttachmentFlag) + "' onclick='return confirm(\"��ȷ��Ҫɾ����\")'>[ɾ��]</a>";
                        }
                    }

                    #endregion

                    #region �����ı༭��ɾ��
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
                        txtParamCode.Text += model.TitleEn + "&nbsp;" + model.Title + "&nbsp;�۸�" + model.Price + "Ԫ";
                        txtParamCode.Text += "</span>";

                        txtParam.Text += "&nbsp;<a href='" + GetRedirectUrl("modify", model.ID, model.ParentID, 2, model.AttachmentFlag) + "'>[�޸�]</a>";
                        txtParam.Text += "&nbsp;<a href='" + GetRedirectUrl("delete", model.ID, model.ParentID, 2, model.AttachmentFlag) + "'>[ɾ��]</a>";
                    }
                    #endregion

                    //��������ɫ
                    if (model.AttachmentFlag == 1)
                    {
                        txtTdStart.Text = "<td class=\"td4 tdcur\" style=\"width:100%; background:#D9ACCA\">";
                    }
                    //����ʾ����ɫ
                    if (model.ShowFlag == 0)
                    {
                        txtTdStart.Text = "<td class=\"td4 tdcur\" style=\"width:100%; background:gray;\">";
                    }
                    
                    txtTdEnd.Text = "</td>";
                    
                    break;
            }
        }
        #endregion

        #region ����
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            RedirectUrl(0, 1, 2);
        }
        #endregion

        #region ��������
        protected void btnAddFJ_Click(object sender, EventArgs e)
        {
            RedirectUrl(0,1,1);
        }
        #endregion

        #region ת��Url
        /// <summary>
        /// ת��Url
        /// </summary>
        /// <param name="ParentID">�����</param>
        /// <param name="Flag">���Ϊ1,����Ϊ2</param>
        /// <param name="AttachmentFlag">1�Ǹ�����2���Ǹ���</param>
        protected void RedirectUrl(int ParentID, int Flag, int AttachmentFlag)
        {
            Response.Redirect(GetRedirectUrl("add",0,ParentID, Flag, AttachmentFlag));
        }

        /// <param name="AttachmentFlag"></param>
       /// <summary>
        /// ��ȡUrl
       /// </summary>
       /// <param name="type">add,delete,modify</param>
       /// <param name="ID">���</param>
        /// <param name="ParentID">�����</param>
        /// <param name="Flag">���Ϊ1,����Ϊ2</param>
        /// <param name="AttachmentFlag">1�Ǹ�����2���Ǹ���</param>
       /// <returns></returns>
        protected string GetRedirectUrl(string type,int ID,int ParentID, int Flag, int AttachmentFlag)
        {
            int ProductID = ConfigParam.ProductID;//��Ʒ���
            string UrlRedirect = type+".aspx?Flag=" + Flag + "&ID="+ID+"&ProductID=" + ProductID + "&AttachmentFlag=" + AttachmentFlag + "&ParentID=" + ParentID + "&ReturnUrl=" + ConfigUrl.ReturnUrl;
            return UrlRedirect;
        }
        #endregion

        #region ����
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

            #region ת�򵽲����������
            Response.Redirect(Request.RawUrl);
            #endregion
        }
        #endregion
    }
}
