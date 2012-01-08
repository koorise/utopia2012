using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Controls
{
    public partial class ControlAdminIndustry : System.Web.UI.UserControl
    {
        #region 表名
        public TableName TableName;        
        #endregion

        #region 表中编号
        public int TableID = 0;
        #endregion

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();

                #region 绑定已选
                if (TableID > 0)
                {
                    BLL.Library_Industry bll = new GK2010.BLL.Library_Industry();
                    List<GK2010.Model.Library_Industry> models = bll.GetList(TableName, TableID);
                    for (int i = 0; i <= grid.Rows.Count - 1; i++)
                    {
                        CheckBoxList chkCategory = (CheckBoxList)grid.Rows[i].FindControl("chkCategory");
                        foreach (ListItem item in chkCategory.Items)
                        {
                            foreach (Model.Library_Industry model in models)
                            {
                                if (item.Value == model.CategoryID.ToString())
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
            BLL.ConfigIndustry bll = new GK2010.BLL.ConfigIndustry();
            List<GK2010.Model.ConfigIndustry> models = bll.GetList("0", "ParentID");
            grid.DataSource = models;
            grid.DataBind();
        }
        #endregion

        #region grid_RowDataBound
        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GK2010.Model.ConfigIndustry model = (GK2010.Model.ConfigIndustry)e.Row.DataItem;
                CheckBoxList chkCategory = (CheckBoxList)e.Row.FindControl("chkCategory");

                GK2010.BLL.ConfigIndustry bll = new GK2010.BLL.ConfigIndustry();
                GK2010.Common.CheckBoxListHelper.Bind(chkCategory, "Title", "ID", bll.GetList(model.ID.ToString(), "ParentID"));
            }
        }
        #endregion

        #endregion

        #region 保存
        public bool Save(TableName TableName,int TableID)
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
            BLL.Library_Industry bll = new BLL.Library_Industry();
            bool ret = bll.AddBatch(TableName, TableID, strSelect);
            return ret;
        }
        #endregion
    }
}