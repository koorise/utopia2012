using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Tech
{
    public partial class _default : PageBase
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            //导航
            ZPageBase_MainChannel.EnumNavigator = EnumNavigator.Tech;

            //当前位置
            Navigator1.BindNavigator(EnumNavigator.Tech);

            //获取首页显示内容
            ChannelIndexCategory1.TableName = TableName.Tech;

            #region SEO
            Model.SEO modelSeo = new GK2010.Model.SEO();
            BLL.ConfigSeo.Set("TechIndex", modelSeo, out SeoTitle, out SeoKeywords, out SeoDescription);
            #endregion

            #region 焦点技术支持
            BindHot();
            #endregion

            #region 技术支持排行
            BindHits();
            #endregion
        }
        #endregion

        #region 焦点技术支持
        private void BindHot()
        {
            BLL.Tech bll = new BLL.Tech();
            List<Model.Tech> models = bll.GetList("", "HotFlag_Top14");

            int n = models.Count;

            //第1条
            if (n > 0)
            {
                Model.Tech model = models[0];
                string Url = string.Format(ConfigUrl.UrlTechDetail, model.ID);
                string Title = model.Title;
                string TitleSub = StringHelper.SubString(model.Title, 30, 0);              
                HyperLinkHotTitle1.Text = TitleSub;
                HyperLinkHotTitle1.ToolTip = Title;
                HyperLinkHotTitle1.NavigateUrl = Url;
            }

            //第2-7条
            n = models.Count;
            if (n > 1)
            {
                if (n > 7) n = 7;
                RepeaterListHotUp.DataSource = models.GetRange(1, n - 1);
                RepeaterListHotUp.DataBind();
            }

            //第8条
            n = models.Count;
            if (n > 7)
            {
                Model.Tech model = models[7];
                string Url = string.Format(ConfigUrl.UrlTechDetail, model.ID);
                string Title = model.Title;
                string TitleSub = StringHelper.SubString(model.Title, 30, 0);
                HyperLinkHotTitle2.Text = TitleSub;
                HyperLinkHotTitle2.ToolTip = Title;
                HyperLinkHotTitle2.NavigateUrl = Url;
            }

            //第9-14条
            n = models.Count;
            if (n > 8)
            {
                if (n > 14) n = 14;
                RepeaterListHotDown.DataSource = models.GetRange(8, n - 8);
                RepeaterListHotDown.DataBind();
            }
            
        }

        protected void RepeaterListHot_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.Tech model = (Model.Tech)e.Item.DataItem;

                    //详细
                    string Url = string.Format(ConfigUrl.UrlTechDetail, model.ID);
                    string Title = model.Title;
                    string TitleSub = StringHelper.SubString(model.Title, 35, 0);
                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    HyperLinkTitle.Text = TitleSub;
                    HyperLinkTitle.ToolTip = Title;
                    HyperLinkTitle.NavigateUrl = Url;


                    //类别
                    Url = string.Format(ConfigUrl.UrlTechList, model.CategoryID,0,1);
                    Title = BLL.TechCategory.GetTitle(model.CategoryID);
                    TitleSub = StringHelper.SubString(Title, 8, 0);
                    HyperLink HyperLinkCategory = (HyperLink)e.Item.FindControl("HyperLinkCategory");
                    HyperLinkCategory.Text = "["+TitleSub+"]";
                    HyperLinkCategory.ToolTip = Title;
                    HyperLinkCategory.NavigateUrl = Url;

                    break;
            }
        }
        #endregion

        #region 技术支持排行
        private void BindHits()
        {
            BLL.Tech bll = new BLL.Tech();
            List<Model.Tech> models = bll.GetList("", "Hits_Top10");

            //只取前5条
            int n = models.Count;
            if (n > 5) n = 5;
            RepeaterListHits.DataSource = models.GetRange(0,n);
            RepeaterListHits.DataBind();
        }

        protected void RepeaterListHits_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.Tech model = (Model.Tech)e.Item.DataItem;

                    string Url = string.Format(ConfigUrl.UrlTechDetail, model.ID);
                    string Title = model.Title;
                    string TitleSub = StringHelper.SubString(model.Title, 44, 0);

                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    HyperLinkTitle.Text = TitleSub;
                    HyperLinkTitle.ToolTip = Title;
                    HyperLinkTitle.NavigateUrl = Url;

                    break;
            }
        }

        #endregion
    }
}
