using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Controls
{
    public partial class ControlBootFriendLink : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 友情链接

            BindFriendLink();

            #endregion
        }

        #region 友情链接

        private void BindFriendLink()
        {
            BLL.FriendLink bll = new GK2010.BLL.FriendLink();
            RepeaterList.DataSource = bll.GetList("", "Top30");
            RepeaterList.DataBind();
        }
        protected void RepeaterList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.FriendLink model = (Model.FriendLink)e.Item.DataItem;

                    string Url = model.Url;

                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    HyperLinkTitle.Text = model.Title;
                    HyperLinkTitle.Target = "_blank";
                    HyperLinkTitle.NavigateUrl = Url;

                    break;
            }
        }
        #endregion
    }
}