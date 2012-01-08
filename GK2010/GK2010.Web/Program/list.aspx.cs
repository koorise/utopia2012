using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Program
{
    public partial class list : PageBase
    {
        #region 变量
        public int I = 1;
        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //导航
                Navigator1.BindNavigator(EnumNavigator.Program);

                //当前选中项
                ZPageBase_MainChannel.EnumNavigator = EnumNavigator.Program;

                //绑定列表
                Bind();

                //方案推荐
                BindCommend();
            }
        }
        #endregion

        #region 绑定列表
        private void Bind()
        {
            BLL.Program bll = new BLL.Program();
            List<GK2010.Model.Program> models = null;

            //分页
            int total = 0;
            int PageIndex = ConfigParam.Page;
            int PageSize = 30;

            // 应用行业(0行业,1介质)
            int ApplicationFlag = ConfigParam.ApplicationFlag;

            // 0最新id desc，1方案排行 hits desc，2今日焦点 hotFlag desc,3方案推荐 commendflag desc
            int OrderType = ConfigParam.OrderType;

            // 类别
            int FirstCategoryID = ConfigParam.FirstCategoryID;
            int SecondCategoryID = ConfigParam.SecondCategoryID;
           
            if (OrderType > 0)
            {
                string strOrderType = "id";
                txtCategory.Text = "最新方案";

                #region 排序
                switch (OrderType)
                {
                    case 0:
                        strOrderType = "id";
                        txtCategory.Text = "最新方案";
                        break;
                    case 1:
                        strOrderType = "hits";
                        txtCategory.Text = "方案排行";
                        break;
                    case 2:
                        strOrderType = "hotFlag";
                        txtCategory.Text = "今日焦点";
                        break;
                    case 3:
                        strOrderType = "commendflag";
                        txtCategory.Text = "方案推荐";
                        break;
                    default:
                        strOrderType = "id";
                        txtCategory.Text = "最新方案";
                        break;
                }
                #endregion

                #region SEO
                Model.SEO modelSeo = new GK2010.Model.SEO();
                modelSeo.DetailTitle = txtCategory.Text;
                modelSeo.CategoryTitle = txtCategory.Text;
                modelSeo.Tags = txtCategory.Text;
                modelSeo.SEOTitle = "";
                modelSeo.SEOKeywords = "";
                modelSeo.SEODescription = "";

                BLL.ConfigSeo.Set("ProgramList", modelSeo, out SeoTitle, out SeoKeywords, out SeoDescription);
                #endregion
               
                models = bll.GetList(PageSize, PageIndex, strOrderType, "OrderType", out total);
            }
            else
            {
                if (ApplicationFlag == 0)
                {
                   
                    if (FirstCategoryID > 0)
                    {
                        txtCategory.Text = BLL.ConfigIndustry.GetTitle(FirstCategoryID);
                    }
                    if (SecondCategoryID > 0)
                    {
                        txtCategory.Text = BLL.ConfigIndustry.GetTitle(SecondCategoryID);
                    }
                }
                if (ApplicationFlag == 1)
                {
                   
                    if (FirstCategoryID > 0)
                    {
                        txtCategory.Text = BLL.ConfigMedium.GetTitle(FirstCategoryID);
                    }
                    if (SecondCategoryID > 0)
                    {
                        txtCategory.Text = BLL.ConfigMedium.GetTitle(SecondCategoryID);
                    }
                }
               
                models = bll.GetList(PageSize, PageIndex, ApplicationFlag, FirstCategoryID,SecondCategoryID,OrderType, out total);              
            }


            AspNetPager1.PageSize = PageSize;
            AspNetPager1.RecordCount = total;

            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlPaging = true;
            AspNetPager1.UrlRewritePattern = string.Format(ConfigUrl.UrlProgramList, ApplicationFlag, FirstCategoryID, SecondCategoryID,OrderType, "{0}");

            RepeaterList.DataSource = models;
            RepeaterList.DataBind();                      
          
        }

        protected void RepeaterList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.Program model = (Model.Program)e.Item.DataItem;

                    string Url = string.Format(ConfigUrl.UrlProgramDetail, model.ID);
                    string Title = model.Title;
                    string TitleSub = StringHelper.SubString( model.Title,60,1);
                    string PostDate = DatetimeHelper.Parse( model.PostDate,"yyyy年MM月dd日");
                    string strStyle = "";
                   
                    //标题+时间
                    Literal txtContent = (Literal)e.Item.FindControl("txtContent");                   
                    if (I % 5 == 0)
                    {
                        strStyle = " style='border-bottom:1px dashed #cccccc;margin-bottom:15px;padding-bottom:5px'";
                    }
                    txtContent.Text = "<li " + strStyle + "><a target='_blank' title='" + Title + "' href='" + Url + "'>" + TitleSub + "</a><span>" + PostDate + "</span></li>";
                    
                    I++;

                    break;
            }
        }

        #endregion

        #region 方案推荐
        private void BindCommend()
        {
            //BLL.Program bll = new BLL.Program();
            //List<Model.Program> models = bll.GetList("", "Commend_Top10");
           
            //RepeaterListCommend.DataSource = models;
            //RepeaterListCommend.DataBind();
        }

        protected void RepeaterListCommend_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.Program model = (Model.Program)e.Item.DataItem;

                    //string Url = string.Format(ConfigUrl.UrlProgramDetail, model.ID);
                    //string Title = model.Title;
                    //string TitleSub = StringHelper.SubString(model.Title, 36, 0);

                    //HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    //HyperLinkTitle.Text = TitleSub;
                    //HyperLinkTitle.ToolTip = Title;
                    //HyperLinkTitle.NavigateUrl = Url;

                    break;
            }
        }

        #endregion
    }
}
