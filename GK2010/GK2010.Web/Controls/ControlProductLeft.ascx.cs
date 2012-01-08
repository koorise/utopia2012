using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Controls
{
    public partial class ControlProductLeft : System.Web.UI.UserControl
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCategory();
        }
        #endregion

        #region 绑定类别

        private void BindCategory()
        {
            BLL.ProductCategory bll = new BLL.ProductCategory();
            RepeaterList.DataSource = bll.GetList("0", "ParentID");
            RepeaterList.DataBind();
        }

        protected void RepeaterList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.ProductCategory model = (Model.ProductCategory)e.Item.DataItem;

                    BLL.ProductCategory bll = new BLL.ProductCategory();
                    Repeater RepeaterListChild = (Repeater)e.Item.FindControl("RepeaterListChild");
                    RepeaterListChild.DataSource = bll.GetList(model.ID.ToString(), "ParentID");
                    RepeaterListChild.DataBind();

                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    HyperLinkTitle.Text ="·"+ model.Title;
                    HyperLinkTitle.NavigateUrl = string.Format( ConfigUrl.UrlProductCategory,model.ID,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1);

                    break;
            }
        }

        protected void RepeaterListChild_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.ProductCategory model = (Model.ProductCategory)e.Item.DataItem;

                    //标题
                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    HyperLinkTitle.Text = "·" + model.Title;
                    HyperLinkTitle.ToolTip = model.Title;
                    HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory, model.ParentID, model.ID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1);

                    break;
            }
        }
        #endregion

        
    }
}