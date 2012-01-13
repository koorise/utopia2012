using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.News
{
    public partial class _default : PageBase
    {
        #region 变量
        public int I = 1;
        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            //导航
            ZPageBase_MainChannel.EnumNavigator = EnumNavigator.News;

            //当前位置
            Navigator1.BindNavigator(EnumNavigator.News);

            Bind();
        }
        #endregion

        private void Bind()
        {
            
            int CategoryID = ConfigParam.CategoryID;
            if (CategoryID==0)
            {
                CategoryID = 2;
            } 
           
            //分页
            int total = 0;
            int PageIndex = ConfigParam.Page;
            int PageSize = 15;

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
            string Keywords = "";
            string Type = "";
            BLL.NewsCategory newsbll = new BLL.NewsCategory();
            Repeater1.DataSource = newsbll.GetList(Keywords, Type);
            Repeater1.DataBind();

            #region SEO
            Model.SEO modelSeo = new GK2010.Model.SEO();
            modelSeo.CategoryTitle = BLL.NewsCategory.GetTitle(CategoryID);
            BLL.ConfigSeo.Set("NewsList", modelSeo, out SeoTitle, out SeoKeywords, out SeoDescription);
            #endregion

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
                    string TitleSub = StringHelper.SubString( model.Title,60,1);
                    string PostDate = DatetimeHelper.Parse( model.PostDate,"yyyy-MM-dd");
                    string strStyle = "";
                   
                    //标题+时间
                    Literal txtContent = (Literal)e.Item.FindControl("txtContent");                   
  
                        strStyle = " style='border-bottom:1px  #cccccc;padding-bottom:5px'";
               
                    txtContent.Text = "<li " + strStyle + "><a target='_blank' title='" + Title + "' href='" + Url + "'>" + TitleSub + "</a><span>" + PostDate + "</span></li>";
                    
           

                    break;
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            ViewState["PageIndex"] = AspNetPager1.CurrentPageIndex.ToString();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.NewsCategory model = (Model.NewsCategory)e.Item.DataItem;
                    HyperLink newtitle = (HyperLink)e.Item.FindControl("HyperLink1");
                    newtitle.Text = "<span>"+ model.Title +"</span>";
                    newtitle.NavigateUrl=("default.aspx?CategoryID=" + model.ID);
                    break;
            }
        }


    }
}
