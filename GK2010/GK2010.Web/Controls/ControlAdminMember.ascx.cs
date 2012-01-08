using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Controls
{
    public partial class ControlAdminMember : System.Web.UI.UserControl
    {
       

        #region UserID
        public int UserID = 0;
        #endregion

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();

                #region 绑定已选
                if (UserID > 0)
                {
                    BLL.MemberRelation bll = new GK2010.BLL.MemberRelation();
                    List<GK2010.Model.MemberRelation> models = bll.GetList(UserID.ToString(), "UserID");
                    for (int i = 0; i <= grid.Rows.Count - 1; i++)
                    {
                        CheckBoxList chkCategory = (CheckBoxList)grid.Rows[i].FindControl("chkCategory");
                        foreach (ListItem item in chkCategory.Items)
                        {
                            foreach (Model.MemberRelation model in models)
                            {
                                if (item.Value == model.AdminID.ToString())
                                {
                                    item.Selected = true;
                                    item.Attributes.Add("style","color:red");
                                }
                            }
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
            BLL.MemberGroup bll = new GK2010.BLL.MemberGroup();
            List<GK2010.Model.MemberGroup> models = bll.GetList("", "");
            grid.DataSource = models;
            grid.DataBind();
        }
        #endregion

        #region grid_RowDataBound
        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GK2010.Model.MemberGroup model = (GK2010.Model.MemberGroup)e.Row.DataItem;
                CheckBoxList chkCategory = (CheckBoxList)e.Row.FindControl("chkCategory");

                GK2010.BLL.Member bll = new GK2010.BLL.Member();
                GK2010.Common.CheckBoxListHelper.Bind(chkCategory, "RealName", "ID", bll.GetList(model.ID.ToString(), "GroupID"));
            }
        }
        #endregion

        #endregion

        #region 保存
        public bool Save(int UserID)
        {
            string strSelect = "";
            for (int i = 0; i <= grid.Rows.Count - 1; i++)
            {
                CheckBoxList chkCategory = (CheckBoxList)grid.Rows[i].FindControl("chkCategory");
                foreach (ListItem item in chkCategory.Items)
                {
                    if (item.Selected)
                    {
                        strSelect += item.Value + ",";
                    }
                }
            }
            strSelect = StringHelper.DelLastChar(strSelect);
            BLL.MemberRelation bll = new BLL.MemberRelation();
            bool ret = bll.AddBatch(UserID, strSelect);
            return ret;
        }
        #endregion
    }
}