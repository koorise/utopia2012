using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Down
{
    public partial class detail : PageBase
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            //当前位置
            Navigator1.BindNavigator(EnumNavigator.Down);

            //当前选中项
            ZPageBase_MainChannel.EnumNavigator = EnumNavigator.Down;

            #region 详细
            BLL.Down bll = new GK2010.BLL.Down();
            Model.Down model = bll.GetModel(ConfigParam.ID);
            if (model != null)
            {
                txtTitle.Text = model.Title;
                txtHits.Text = model.Hits.ToString();
                txtPostDate.Text = DatetimeHelper.Parse(model.PostDate, "yyyy年MM月dd日 HH:mm");
                txtSummary.Text = "[<b>导读</b>]" + StringHelper.SubString(model.Summary, 140, 1);
                txtDetail.Text = model.Detail;
                txtSource.Text = model.Source == "" ? "工控商城网" : model.Source;

                #region 修改浏览次数
                model.Hits += 1;
                bll.Update(model);
                #endregion


                #region SEO
                Model.SEO modelSeo = new GK2010.Model.SEO();
                modelSeo.DetailTitle = model.Title;
                modelSeo.CategoryTitle = BLL.DownCategory.GetTitle(model.CategoryID);
                modelSeo.Tags = model.Tags;
                modelSeo.SEOTitle = model.SEOTitle;
                modelSeo.SEOKeywords = model.SEOKeywords;
                modelSeo.SEODescription = model.SEODescription;

                BLL.ConfigSeo.Set("DownDetail", modelSeo, out SeoTitle, out SeoKeywords, out SeoDescription);
                #endregion

                //相关产品
                ProductRelation1.TableName = TableName.Down;
                ProductRelation1.TableID = ConfigParam.ID;

            }
            #endregion
            
            //下载相关
            BindRelation();
           
        }
        #endregion

        #region 下载相关
        private void BindRelation()
        {
            BLL.Down bll = new BLL.Down();
            List<Model.Down> models = bll.GetList(ConfigParam.ID.ToString(), "Relation_Top10");

            RepeaterListRelation.DataSource = models;
            RepeaterListRelation.DataBind();

            if (models.Count == 0) RepeaterListRelation.Visible = false;
        }

        protected void RepeaterListRelation_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.Down model = (Model.Down)e.Item.DataItem;

                    string Url = string.Format(ConfigUrl.UrlDownDetail, model.ID);
                    string Title = model.Title;
                    string TitleSub = StringHelper.SubString(model.Title, 36, 0);

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
