using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Common;
using GK2010.Utility;

namespace GK2010.Web.Product
{
    public partial class MemberProductEvaluateList : PageBase
    {

        #region 变量
        protected readonly BLL.MemberProductEvaluate mpe = new BLL.MemberProductEvaluate();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int ProductID = ConfigParam.ID;

                //显示基本信息
                showBasicMessage(ProductID);

                //显示评分
                showSorce(ProductID);

               //显示商品的评价(分页)
                 BindProductEvaluate();
            }
        }
        #region  显示基本信息
        private void showBasicMessage(int ProductID)
        {
            BLL.Product bll = new BLL.Product();
            Model.Product model = bll.GetModel(ProductID);

             ZPageBase_MainChannel.EnumNavigator = EnumNavigator.Product;

                string linkBig = BLL.ProductCategory.GetTitle(model.RootID);
                string linkBigUrl = string.Format(ConfigUrl.UrlProductCategory, model.RootID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,1,1);

                string linkSmall = BLL.ProductCategory.GetTitle(model.CategoryID);
               string linkSmallUrl = string.Format(ConfigUrl.UrlProductCategory, model.RootID, model.CategoryID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1);
            litProduct_Title.Text = "<a href='/'>首页</a>&nbsp;&gt;&nbsp;<a href='/product/'>产品中心</a>&nbsp;&gt;&nbsp;<a href='"+
                linkBigUrl + "'>" + linkBig + "</a>&nbsp;&gt;&nbsp;<a href='" + linkSmallUrl + "'>" + linkSmall + "</a>&nbsp;&gt;&nbsp;<a href='/product/" +
                model.ID + ".html'>" + model.Title + "</a>&nbsp;&gt;&nbsp;评价列表";
             
            #region SEO
            Model.SEO modelSeo = new GK2010.Model.SEO();
            modelSeo.DetailTitle = model.Title;
            modelSeo.CategoryTitle = "";
            modelSeo.Tags = model.Tags;
            modelSeo.SEOTitle = model.SEOTitle;
            modelSeo.SEOKeywords = model.SEOKeywords;
            modelSeo.SEODescription = model.SEODescription;
            GK2010.BLL.ConfigSeo.Set("MemberProductEvaluateList", modelSeo, out SeoTitle, out SeoKeywords, out SeoDescription);
            #endregion
        }
        #endregion

        #region 显示评分
        private void showSorce(int productID)
        {
            float zongPinFen = mpe.GetSorce(productID);//总评分
            float pinFenCount = mpe.GetSorceCount(productID);//评分次数
            if (pinFenCount == 0)
                litScroe1_0.Text = "5.0";
            else
                litScroe1_0.Text = (zongPinFen / pinFenCount).ToString("#.#");

            int good = mpe.GetCommentCountByComment(productID, 1);//好评次数
            int center = mpe.GetCommentCountByComment(productID, 2);//中评次数
            int poor = mpe.GetCommentCountByComment(productID, 3);//差评次数
            long commentCount = mpe.GetCommentCount(productID);//总评次数

            litPepCount1.Text = commentCount.ToString();

            #region 好评显示
            if (good == 0 || commentCount == 0)
            {
                litGoodScroe1_1.Text = "100%";
                litGoodScroe1_2.Text = "100%";
                litGoodWith1_1.Text = "<div style='width: 260px;'>  </div>";
            }
            else
            {
                litGoodScroe1_1.Text = (Convert.ToInt64((float)good / (float)commentCount * 100)).ToString() + "%";//好评百分比
                litGoodScroe1_2.Text = litGoodScroe1_1.Text;
                litGoodWith1_1.Text = "<div style='width: " + ((float)good / (float)commentCount * 260).ToString() + "px;'>  </div>";
            }
            #endregion

            #region 中评显示
            if (center == 0 || commentCount == 0)
            {
                litCenterScroe1.Text = "0%";
                litCenterWith1.Text = "<div style='width: 0px;'>  </div>";
            }
            else
            {
                litCenterScroe1.Text = (Convert.ToInt64((float)center / (float)commentCount * 100)).ToString() + "%";//好评百分比
                litCenterWith1.Text = "<div style='width: " + ((float)center / (float)commentCount * 260).ToString() + "px;'>  </div>";
            }
            #endregion

            #region 差评显示
            if (poor == 0 || commentCount == 0)
            {
                litPoorScroe1.Text = "0%";
                litPoorWith1.Text = "<div style='width: 0px;'>  </div>";
            }
            else
            {
                litPoorScroe1.Text = (Convert.ToInt64((float)poor / (float)commentCount * 100)).ToString() + "%";//好评百分比
                litPoorWith1.Text = "<div style='width: " + ((float)poor / (float)commentCount * 260).ToString() + "px;'>  </div>";
            }
            #endregion
        }
        #endregion


        #region 商品评价栏目的repeater控件事件
        protected void repeaterEvaluateList1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.MemberProductEvaluate model1 = (Model.MemberProductEvaluate)e.Item.DataItem;
                    if (model1.Reply.ToString().Trim().Length > 1)
                    {
                        Literal literal1 = (Literal)e.Item.FindControl("lit_JieShi1");
                        literal1.Text = "<dl> <dt>掌柜解释：</dt>  <dd> " + model1.Reply.ToString() + "</dd></dl>";

                    }
                    break;
            }
        }
        #endregion

        #region 显示商品的评价(分页)
        private void BindProductEvaluate()
        {
            int total = 0;
            int PageIndex = ConfigParam.Page;
            List<GK2010.Model.MemberProductEvaluate> models = mpe.getList(GK2010.Utility.ConfigParam.ID, PageIndex, out total);
            AspNetPager1.PageSize = 10;
            AspNetPager1.RecordCount = total;
            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlPaging = true;

            AspNetPager1.UrlRewritePattern = string.Format(ConfigUrl.UrlMemberProductEvaluateList, ConfigParam.ID, "{0}");

            repeaterEvaluateList1.DataSource = models;
            repeaterEvaluateList1.DataBind();

            if (models.Count == 0)
            {
                AspNetPager1.Visible = false;
            }

        }

        #endregion
    }
}