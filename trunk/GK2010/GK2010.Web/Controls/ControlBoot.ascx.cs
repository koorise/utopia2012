using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Controls
{
    public partial class ControlBoot : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 关于我们

            BindAbout();

            #endregion

            #region 版权信息

            txtCopyRight.Text = BindCopyRight();

            #endregion
        }

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
                    if (Url == "")
                    {
                        Url = string.Format(ConfigUrl.UrlCorpDetail, model.ID);
                    }

                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    HyperLinkTitle.Text = model.Title;
                    HyperLinkTitle.Target = "_blank";
                    HyperLinkTitle.NavigateUrl = Url;

                    break;
            }
        }
        #endregion

        #region 版权信息

        private string BindCopyRight()
        {
            BLL.Config bll = new GK2010.BLL.Config();
            Model.Config model = bll.GetModel();
            if (model != null)
            {
                return model.ControlBoot;
            }
            return "";
        }

        #endregion

    }
}