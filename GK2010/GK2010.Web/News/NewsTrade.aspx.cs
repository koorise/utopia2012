using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;

namespace GK2010.Web.News
{
    public partial class NewsTrade : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            //导航
            ZPageBase_MainChannel.EnumNavigator = EnumNavigator.News;

            //当前位置
            Navigator1.BindNavigator(EnumNavigator.News);
       
            //DataList1.DataSource = bll.GetList(Keywords, Type);
            //DataList1.DataBind();
            
            Bind();
        }
        #endregion
        private void Bind()
        {
            int CategoryID = 2;
            //分页
            int total = 0;
            int PageIndex = ConfigParam.Page;
            int PageSize = 30;

            BLL.News bll = new BLL.News();
            List<GK2010.Model.News> models = models = bll.GetList(PageSize, PageIndex, CategoryID.ToString(), "CategoryID", out total);
            AspNetPager1.PageSize = PageSize;
            AspNetPager1.RecordCount = total;
            RepeaterList.DataSource = models;
            RepeaterList.DataBind();
            if (models.Count == 0)
            {
                AspNetPager1.Visible = false;
            }
            //AspNetPager1.EnableUrlRewriting = true;
            //AspNetPager1.UrlPaging = true;
            //AspNetPager1.UrlRewritePattern = string.Format(ConfigUrl.UrlNewsList2, CategoryID.ToString(),"{0}", "{0}");



            //string Keywords = "";
            //string Type = "";
            //BLL.NewsCategory newsbll = new BLL.NewsCategory();
            //Repeater1.DataSource = newsbll.GetList(Keywords, Type);
            //Repeater1.DataBind();


        }
        protected void RepeaterList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.News model = (Model.News)e.Item.DataItem;

                    string Url = string.Format(ConfigUrl.UrlNewsDetail, model.ID);
                    string Title = model.Title;
                    string PostDate = DatetimeHelper.Parse(model.PostDate, "yyyy年MM月dd日");
                    //Literal txtdate = (Literal)e.Item.FindControl("txtdate");
                    //txtdate.Text = PostDate;
                    HyperLink title = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    title.Text = Title;
          
                    title.NavigateUrl = Url;
                    break;
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //switch (e.Item.ItemType)
            //{
            //    case ListItemType.Item:
            //    case ListItemType.AlternatingItem:
            //    case ListItemType.EditItem:
            //        Model.NewsCategory model = (Model.NewsCategory)e.Item.DataItem;
            //        HyperLink newtitle = (HyperLink)e.Item.FindControl("HyperLink1");
            //        newtitle.Text = model.Title;
            //        newtitle.NavigateUrl = string.Format(ConfigUrl.UrlNewsList2, model.ID,"{0}", "{0}");
            //    break;
            //}
        }

      
    }
}
