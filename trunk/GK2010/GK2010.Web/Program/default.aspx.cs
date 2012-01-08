using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Program
{
    public partial class _default : System.Web.UI.Page
    {
      

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            ZPageBase_MainChannel.EnumNavigator = EnumNavigator.Program;

            BindIndustry();
            BindMedium(); 
        }
        #endregion


        #region 绑定行业

        private void BindIndustry()
        {
            BLL.ConfigIndustry bll = new BLL.ConfigIndustry();
            RepeaterListIndustry.DataSource = bll.GetList("0", "ParentID");
            RepeaterListIndustry.DataBind();
        }

        protected void RepeaterListIndustry_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.ConfigIndustry model = (Model.ConfigIndustry)e.Item.DataItem;

                    BLL.ConfigIndustry bll = new BLL.ConfigIndustry();
                    Repeater RepeaterListIndustryChild = (Repeater)e.Item.FindControl("RepeaterListIndustryChild");
                    RepeaterListIndustryChild.DataSource = bll.GetList(model.ID.ToString(), "ParentID");
                    RepeaterListIndustryChild.DataBind();

                    string Url = string.Format(ConfigUrl.UrlProgramList, 0, model.ID, 0, 0, 1);
                    string Title = model.Title;
                    string TitleSub = StringHelper.SubString(model.Title, 18, 0);
                    string Picture = model.PictureNormal;

                    //标题
                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    HyperLinkTitle.Text = TitleSub;
                    HyperLinkTitle.NavigateUrl = Url;

                    //图片
                    Literal txtPicture = (Literal)e.Item.FindControl("txtPicture");
                    txtPicture.Text = "<a href='" + Url + "'><img src=\"" + Picture + "\" alt=\"" + Title + "\" width=\"50\" height=\"50\" /></a>";

                    break;
            }
        }

        protected void RepeaterListIndustryChild_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.ConfigIndustry model = (Model.ConfigIndustry)e.Item.DataItem;

                    //标题
                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    HyperLinkTitle.Text =  model.Title;
                    HyperLinkTitle.ToolTip = model.Title;
                    HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProgramList, 0, model.ParentID, model.ID, 0, 1);

                    break;
            }
        }
        #endregion

        #region 绑定介质

        private void BindMedium()
        {
            BLL.ConfigMedium bll = new BLL.ConfigMedium();
            RepeaterListMedium.DataSource = bll.GetList("0", "ParentID");
            RepeaterListMedium.DataBind();
        }

        protected void RepeaterListMedium_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.ConfigMedium model = (Model.ConfigMedium)e.Item.DataItem;

                    BLL.ConfigMedium bll = new BLL.ConfigMedium();
                    Repeater RepeaterListMediumChild = (Repeater)e.Item.FindControl("RepeaterListMediumChild");
                    RepeaterListMediumChild.DataSource = bll.GetList(model.ID.ToString(), "ParentID");
                    RepeaterListMediumChild.DataBind();

                    string Url = string.Format(ConfigUrl.UrlProgramList, 1, model.ID, 0, 0, 1);
                    string Title = model.Title;
                    string TitleSub = StringHelper.SubString( model.Title,18,0);
                    string Picture = model.PictureNormal;

                    //标题
                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    HyperLinkTitle.Text = TitleSub;
                    HyperLinkTitle.NavigateUrl = Url;

                    //图片
                    Literal txtPicture = (Literal)e.Item.FindControl("txtPicture");
                    txtPicture.Text = "<a href='" + Url + "'><img src=\"" + Picture + "\" alt=\"" + Title + "\" width=\"50\" height=\"50\" /></a>";

                    break;
            }
        }

        protected void RepeaterListMediumChild_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.ConfigMedium model = (Model.ConfigMedium)e.Item.DataItem;

                    //标题
                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    HyperLinkTitle.Text = model.Title;
                    HyperLinkTitle.ToolTip = model.Title;
                    HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProgramList, 1, model.ParentID, model.ID, 0, 1);

                    break;
            }
        }
        #endregion
    }
}
