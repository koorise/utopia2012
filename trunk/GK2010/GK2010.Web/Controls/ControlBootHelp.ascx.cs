using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;

namespace GK2010.Web.Controls
{
    public partial class ControlBootHelp : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 绑定类别
            BindCategory();
        }

        #region 绑定类别
        private void BindCategory()
        {
            int totalRows;

            BLL.HelpCategory bllHelpCategory = new BLL.HelpCategory();
            List<Model.HelpCategory> models = bllHelpCategory.GetList(5, 1, "", "", out totalRows);
            rptCategory.DataSource = models;
            rptCategory.DataBind();
        }

        protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.HelpCategory model = (Model.HelpCategory)e.Item.DataItem;

                    Literal LiteralTitle = (Literal)e.Item.FindControl("LiteralTitle");
                    LiteralTitle.Text = model.Title;

                    Repeater RepeaterList = (Repeater)e.Item.FindControl("RepeaterList");
                    RepeaterList.ItemDataBound += new RepeaterItemEventHandler(RepeaterList_ItemDataBound);

                    int totalRows;

                    BLL.Help bllHelp = new BLL.Help();
                    List<Model.Help> modelHelps = bllHelp.GetList(5, 1, model.ID.ToString(), "CategoryID", out totalRows);
                    RepeaterList.DataSource = modelHelps;
                    RepeaterList.DataBind();
                    break;
            }
        }

        protected void RepeaterList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.Help model = (Model.Help)e.Item.DataItem;

                    string Url = string.Format(ConfigUrl.UrlHelpDetail, model.ID);

                    HyperLink helpUrl = (HyperLink)e.Item.FindControl("helpUrl");
                    helpUrl.NavigateUrl = Url;

                    Literal helpTitle = (Literal)e.Item.FindControl("helpTitle");
                    helpTitle.Text = model.Title;
                    break;
            }
        }
        #endregion
    }
}