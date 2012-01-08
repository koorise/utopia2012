using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using GK2010.Utility;
namespace GK2010.Web.Admin.ProductVirtual
{
    public partial class Manage : System.Web.UI.Page
    {

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("Product");
            if (!IsPostBack)
            {
                BindData();

                #region 绑定已设置值
                BLL.ProductVirtual bll = new GK2010.BLL.ProductVirtual();
                List<GK2010.Model.ProductVirtual> models = bll.GetList(ConfigParam.ProductID.ToString(), "ProductID");
                for (int i = 0; i <= grid.Rows.Count - 1; i++)
                {                  
                    RadioButtonList radID = (RadioButtonList)grid.Rows[i].FindControl("radID");
                    foreach (ListItem item in radID.Items)
                    {
                        foreach (GK2010.Model.ProductVirtual model in models)
                        {
                            if (item.Value == model.VirtualID.ToString())
                            {
                                item.Attributes.Add("style", "color:red");
                                item.Selected = true;
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
            GK2010.BLL.VirtualCategory bll = new GK2010.BLL.VirtualCategory();
            List<GK2010.Model.VirtualCategory> models = bll.GetList(ConfigParam.ProductID.ToString(), "ProductID");          
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
                GK2010.Model.VirtualCategory model = (GK2010.Model.VirtualCategory)e.Row.DataItem;
                RadioButtonList radID = (RadioButtonList)e.Row.FindControl("radID");
                GK2010.BLL.Virtual bll = new GK2010.BLL.Virtual();
                GK2010.Common.RadioButtonListHelper.Bind(radID, "Title", "ID", bll.GetList(model.ID.ToString(), "CategoryID"));
            }
        }
        #endregion

        #endregion

        #region 批量保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int ProductID = ConfigParam.ProductID;
            DbHelperSQL.ExecuteSql("delete from ProductVirtual where ProductID=" + ProductID);

            for (int i = 0; i <= grid.Rows.Count - 1; i++)
            {
                HtmlInputHidden txtID = (HtmlInputHidden)grid.Rows[i].FindControl("txtID");
                HtmlInputHidden txtProductCategoryID = (HtmlInputHidden)grid.Rows[i].FindControl("txtProductCategoryID");
                RadioButtonList radID = (RadioButtonList)grid.Rows[i].FindControl("radID");
                if (radID.SelectedValue != "")
                {
                    BLL.ProductVirtual bll = new GK2010.BLL.ProductVirtual();
                    Model.ProductVirtual model = new GK2010.Model.ProductVirtual();
                    model.ProductCategoryID = IntHelper.Parse(txtProductCategoryID.Value, 0);
                    model.ProductID = ProductID;
                    model.VirtualCategoryID = IntHelper.Parse(txtID.Value, 0);
                    model.VirtualID = IntHelper.Parse(radID.SelectedValue, 0);
                    bll.Add(model);
                }
            }

            //MessageBox.ShowAlert(this, "保存成功！");
        }
        #endregion

    }
}
