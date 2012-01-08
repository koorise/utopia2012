using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.VirtualCategory
{
    public partial class Manage : System.Web.UI.Page
    {
        public int I = 1;

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("VirtualCategory");
            if (!IsPostBack)
            {
                BindData();
            }
        }
        #endregion

        #region 绑定列表

        #region 绑定数据
        private void BindData()
        {
            GK2010.BLL.ProductCategory bll = new GK2010.BLL.ProductCategory();
            List<GK2010.Model.ProductCategory> models = bll.GetList("","VirtualCategory");           
            grid.DataKeyNames = "id".Split(',');
            grid.DataSource = models;
            grid.DataBind();
        }
        #endregion

        #region grid_RowDataBound
        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GK2010.Model.ProductCategory model = (GK2010.Model.ProductCategory)e.Row.DataItem;

                GK2010.BLL.VirtualCategory bll = new GK2010.BLL.VirtualCategory();
                List<GK2010.Model.VirtualCategory> models = bll.GetList(model.ID.ToString(), "ProductCategory");
                GridView gridVirtual = (GridView)e.Row.FindControl("gridVirtual");
                gridVirtual.DataKeyNames = "id".Split(',');
                gridVirtual.DataSource = models;
                gridVirtual.DataBind();
            }
        }

        protected void gridVirtual_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GK2010.Model.VirtualCategory model = (GK2010.Model.VirtualCategory)e.Row.DataItem;               
            }
        }
        #endregion

        #endregion


    }
}
