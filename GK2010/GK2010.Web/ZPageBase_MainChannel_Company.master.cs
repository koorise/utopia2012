using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web
{
    public partial class ZPageBase_MainChannel_Company : System.Web.UI.MasterPage
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            //导航
            Navigator1.BindNavigator(EnumNavigator.Corp);

            //关于我们
            BindAbout();
        }
        #endregion

        #region 关于我们

        private void BindAbout()
        {
            BLL.Company bll = new GK2010.BLL.Company();
            RepeaterList.DataSource = bll.GetList("", "Index");
            RepeaterList.DataBind();
        }

        protected void RepeaterList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.Company model = (Model.Company)e.Item.DataItem;

                    string Url = model.Url;
                    string Target = "_blank";
                    string CurrentClass = "";
                    if (Url == "")
                    {
                        Url = string.Format(ConfigUrl.UrlCorpDetail, model.ID);
                        Target = "_self";
                    }

                    Literal txtTitle = (Literal)e.Item.FindControl("txtTitle");
                    if (model.ID == ConfigParam.ID)
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
