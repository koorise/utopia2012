using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.SystemPermission
{
    public partial class modify : System.Web.UI.Page
    {
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("SystemPermission");
            if (!IsPostBack)
            {
                //角色名称
                txtRole.Text = BLL.MemberGroup.GetTitle(ConfigParam.ID);              

                //设置并绑定GridView
                PageCommon.GridViewSetProperty(grid);
                BindData();

                #region 绑定已有权限
                BLL.SystemPermission bll = new GK2010.BLL.SystemPermission();
                List<GK2010.Model.SystemPermission> models = bll.GetList(ConfigParam.ID.ToString(), "GroupID");
                for (int i = 0; i <= grid.Rows.Count - 1; i++)
                {
                    CheckBoxList chkPermission = (CheckBoxList)grid.Rows[i].FindControl("chkPermission");
                    foreach (ListItem item in chkPermission.Items)
                    {
                        foreach (GK2010.Model.SystemPermission model in models)
                        {
                            if (item.Value == model.Permission)
                                item.Selected = true;
                        }
                    }
                }
                #endregion                
            }
        }
        #endregion

        #region 绑定列表

        #region 绑定数据
        private void BindData()
        {
            GK2010.BLL.SystemTree bll = new GK2010.BLL.SystemTree();
            List<GK2010.Model.SystemTree> models = bll.GetList("0", "ParentID");
            grid.DataSource = models;
            grid.DataBind();
        }
        #endregion

        #region grid_RowDataBound
        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GK2010.Model.SystemTree model = (GK2010.Model.SystemTree)e.Row.DataItem;
                CheckBoxList chkPermission = (CheckBoxList)e.Row.FindControl("chkPermission");
                
                GK2010.BLL.SystemTree bll = new GK2010.BLL.SystemTree();
                GK2010.Common.CheckBoxListHelper.Bind(chkPermission, "Title", "TitleEn", bll.GetList(model.Path, "Child"));             
            }
        }
        #endregion

        #endregion

        #region 保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strPermmsion = "";
            for (int i = 0; i <= grid.Rows.Count - 1; i++)
            {  
                CheckBoxList chkPermission = (CheckBoxList)grid.Rows[i].FindControl("chkPermission");
                foreach (ListItem item in chkPermission.Items)
                {
                    if (item.Selected)
                    {
                        strPermmsion += item.Value+",";
                    }
                }               
            }

            strPermmsion = StringHelper.DelLastChar(strPermmsion);
            GK2010.BLL.SystemPermission bll = new GK2010.BLL.SystemPermission();
            bool ret = bll.AddBatch(ConfigParam.ID, strPermmsion);     

            #region 转向到操作结果界面

            string UrlGo = ConfigParam.ReturnUrl;
            string UrlBack = ConfigUrl.CurrentUrl;
            string ErrorMsg = "";
            if (!ret)
            {
                ErrorMsg = "没有选择任何权限";
            }

            //转向链接
            string UrlRedirect = string.Format(ConfigUrl.AdminUrlResult, UrlGo, UrlBack, ErrorMsg);
            Response.Redirect(UrlRedirect);
            #endregion
        }
        #endregion
    }
}
