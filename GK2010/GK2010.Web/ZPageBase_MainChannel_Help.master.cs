using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web
{
    public partial class ZPageBase_MainChannel_Help : System.Web.UI.MasterPage
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            //导航
            Navigator1.BindNavigator(EnumNavigator.Help);

            //帮助中心
            BindHelp();
        }
        #endregion

        #region 帮助中心

        private void BindHelp()
        {
            BLL.HelpCategory bll = new GK2010.BLL.HelpCategory();
            RepeaterList.DataSource = bll.GetList("", "");
            RepeaterList.DataBind();
        }

        protected void RepeaterList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.HelpCategory model = (Model.HelpCategory)e.Item.DataItem;

                    string Url = string.Format(ConfigUrl.UrlHelpList,model.ID,0,1);
                    string Target = "_self";
                    string CurrentClass = "";

                    Literal txtTitle = (Literal)e.Item.FindControl("txtTitle");
                    if (model.ID == ConfigParam.CategoryID)
                    {
                        CurrentClass = "class='B'";
                    }
                    txtTitle.Text = "<li " + CurrentClass + "><a target='" + Target + "' href='" + Url + "'>" + model.Title + "</a></li>";

                    break;
            }
        }
        #endregion
    }
}
