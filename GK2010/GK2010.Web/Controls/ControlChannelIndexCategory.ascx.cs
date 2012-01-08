using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Controls
{
    public partial class ControlChannelIndexCategory : System.Web.UI.UserControl
    {
        #region 变量

        public TableName TableName = TableName.News;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
           
            #region 新闻中心
            if (TableName == TableName.News)
            {
                BLL.NewsCategory bllNewsCategory = new GK2010.BLL.NewsCategory();
                List<Model.NewsCategory> modelsNewsCategory = bllNewsCategory.GetList("", "");

                for (int i = 0; i < modelsNewsCategory.Count; i++)
                {
                    Model.NewsCategory modelNewsCategory = modelsNewsCategory[i];

                    int CategoryID = modelNewsCategory.ID;
                    string CategoryTitle = modelNewsCategory.Title;
                    string CategoryUrl = string.Format(ConfigUrl.UrlNewsList, CategoryID, 0, 1);

                    //CategoryID_Top12
                    BLL.News bllNews = new GK2010.BLL.News();
                    List<Model.News> modelsNews = bllNews.GetList(CategoryID.ToString(), "CategoryID_Top12");

                    object obj = modelsNews;
                    sb.Append(CheckI(i, CategoryTitle, CategoryUrl, modelsNews));
                }
                txtContent.Text = sb.ToString();
            }
            #endregion

            #region 技术支持
            if (TableName == TableName.Tech)
            {
                BLL.TechCategory bllTechCategory = new GK2010.BLL.TechCategory();
                List<Model.TechCategory> modelsTechCategory = bllTechCategory.GetList("", "");

                for (int i = 0; i < modelsTechCategory.Count; i++)
                {
                    Model.TechCategory modelTechCategory = modelsTechCategory[i];

                    int CategoryID = modelTechCategory.ID;
                    string CategoryTitle = modelTechCategory.Title;
                    string CategoryUrl = string.Format(ConfigUrl.UrlTechList, CategoryID, 0, 1);

                    //CategoryID_Top12
                    BLL.Tech bllTech = new GK2010.BLL.Tech();
                    List<Model.Tech> modelsTech = bllTech.GetList(CategoryID.ToString(), "CategoryID_Top12");

                    object obj = modelsTech;
                    sb.Append(CheckI(i, CategoryTitle, CategoryUrl, modelsTech));
                }
                txtContent.Text = sb.ToString();
            }
            #endregion

            #region 下载中心
            if (TableName == TableName.Down)
            {
                BLL.DownCategory bllDownCategory = new GK2010.BLL.DownCategory();
                List<Model.DownCategory> modelsDownCategory = bllDownCategory.GetList("", "");

                for (int i = 0; i < modelsDownCategory.Count; i++)
                {
                    Model.DownCategory modelDownCategory = modelsDownCategory[i];

                    int CategoryID = modelDownCategory.ID;
                    string CategoryTitle = modelDownCategory.Title;
                    string CategoryUrl = string.Format(ConfigUrl.UrlDownList, CategoryID, 0, 1);

                    //CategoryID_Top12
                    BLL.Down bllDown = new GK2010.BLL.Down();
                    List<Model.Down> modelsDown = bllDown.GetList(CategoryID.ToString(), "CategoryID_Top12");

                    object obj = modelsDown;
                    sb.Append(CheckI(i, CategoryTitle, CategoryUrl, modelsDown));
                }
                txtContent.Text = sb.ToString();
            }
            #endregion
           
        }

        /// <summary>
        /// 根据i判断取左中右值
        /// </summary>
        /// <param name="i"></param>
        /// <param name="CategoryTitle"></param>
        /// <param name="CategoryUrl"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private string CheckI(int i,string CategoryTitle,string CategoryUrl,object obj)
        {
            StringBuilder sb = new StringBuilder();
            if (i % 3 == 0)
            {
                sb.Append(Left(CategoryTitle, CategoryUrl, obj));
            }
            if (i % 3 == 1)
            {
                sb.Append(Center(CategoryTitle, CategoryUrl, obj));
            }
            if (i % 3 == 2)
            {
                sb.Append(Right(CategoryTitle, CategoryUrl, obj));
            }
            return sb.ToString();
        }

        private string Left(string CategoryTitle,string CategoryUrl,object obj)
        {
            StringBuilder sb = new StringBuilder();
            string strFirst;
            string strList;
            BindList(obj, out  strFirst, out strList, 0);
            
            sb.AppendLine("<div class=\"left mdB10\">");
            sb.AppendLine(" <div class=\"news_content\">");
            sb.AppendLine(" <div class=\"hd\">");
            sb.AppendLine("     <h2><span><a href=\"" + CategoryUrl + "\">更多</a></span>" + CategoryTitle + "</h2>");
            sb.AppendLine(" </div>");
            sb.AppendLine(strFirst);
            sb.AppendLine(" <div class=\"bd ul_square\">");           
            sb.AppendLine(" <ul>");
            sb.AppendLine(strList);
            sb.AppendLine(" </ul>");
            sb.AppendLine(" </div>");
            sb.AppendLine(" </div>");
            sb.AppendLine("</div>");
            return sb.ToString();
        }

        private string Center(string CategoryTitle, string CategoryUrl, object obj)
        {
            StringBuilder sb = new StringBuilder();
            string strFirst;
            string strList;
            BindList(obj, out  strFirst, out strList, 0);

            sb.AppendLine("<div class=\"center mdB10\">");
            sb.AppendLine(" <div class=\"news_content\">");
            sb.AppendLine(" <div class=\"hd\">");
            sb.AppendLine("     <h2><span><a href=\"" + CategoryUrl + "\">更多</a></span>" + CategoryTitle + "</h2>");
            sb.AppendLine(" </div>");
            sb.AppendLine(strFirst);
            sb.AppendLine(" <div class=\"bd ul_square\">");           
            sb.AppendLine(" <ul>");
            sb.AppendLine(strList);
            sb.AppendLine(" </ul>");
            sb.AppendLine(" </div>");
            sb.AppendLine(" </div>");
            sb.AppendLine("</div>");
            return sb.ToString();
        }

        private string Right(string CategoryTitle, string CategoryUrl, object obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"right mdB10\">");
            sb.AppendLine(" <div class=\"news_content\">"); 
            sb.AppendLine("<div class=\"hd\">");
            sb.AppendLine("     <h2><span><a href=\"" + CategoryUrl + "\">更多</a></span>" + CategoryTitle + "</h2>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div class=\"bd ul_square\">");
            sb.AppendLine(" <ul>");

            string strFirst;
            string strList;
            BindList(obj, out  strFirst, out strList, 1);
            sb.AppendLine(strList);

            sb.AppendLine(" </ul>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");   
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="strFirst"></param>
        /// <param name="strList"></param>
        /// <param name="flag">0代表（1图+5条），1代表（11条）</param>
        private void BindList(object obj,out string strFirst,out string strList,int flag)
        {
            StringBuilder sbFirst = new StringBuilder();
            StringBuilder sb = new StringBuilder();

            strFirst = "";
            strList = "";
            int WordCount = 40;

            #region 新闻中心
            if (TableName == TableName.News)
            {
                List<Model.News> models = obj as List<Model.News>;
                List<Model.News> models_List = models;

                //0代表（1图+5条）
                if (flag == 0)
                {
                    if (models.Count > 0)
                    {
                        Model.News model = models[0];
                        string Url = string.Format(ConfigUrl.UrlNewsDetail, model.ID);
                        string Title = model.Title;
                        string TitleSub = StringHelper.SubString(model.Title, 28, 0);
                        string Summary = StringHelper.SubString(model.Summary, 86, 1);
                        string Picture = StringHelper.GetPicture_100_100( model.PictureSmall);
                        int Hits = model.Hits;
                        string Sourse = model.Source;

                        sbFirst.AppendLine("<div class=\"first\">");
                        sbFirst.AppendLine("<a href=\"" + Url + "\" target='_blank'><img alt='" + Title + "' src=\"" + Picture + "\" /></a>");
                        sbFirst.AppendLine("<div class=\"first_right\">");
                        sbFirst.AppendLine("<a href=\"" + Url + "\" target='_blank' title='" + Title + "'><h3 style='cursor:pointer'>" + TitleSub + "</h3></a>");
                        sbFirst.AppendLine("<h4>来源:" + Sourse + " 浏览:" + Hits + "</h4>");
                        sbFirst.AppendLine("<p><a href=\"" + Url + "\" target='_blank'>简述：" + Summary + "<em>[详细] </em></a></p>");
                        sbFirst.AppendLine("</div>");
                        sbFirst.AppendLine("</div>");
                        sbFirst.AppendLine("<div class='clear'></div>");

                        int n = models.Count;
                        if (n > 6) n = 6;
                        models_List = models.GetRange(1, n - 1);
                    }

                    WordCount = 48;
                }

                //1代表（11条）
                if (flag == 1)
                {
                    if (models.Count > 10)
                    {
                        models_List = models.GetRange(0, 10);
                    }

                    WordCount = 34;
                }

                foreach (Model.News model in models_List)
                {
                    string Url = string.Format(ConfigUrl.UrlNewsDetail, model.ID);
                    string Title = model.Title;
                    string TitleSub = StringHelper.SubString(model.Title, WordCount, 1);

                    //34
                    sb.AppendLine("<li><a class='f12  ' href=\"" + Url + "\" target='_blank' title='" + Title + "'>" + TitleSub + "</a></li>");
                }
            }
            #endregion

            #region 技术支持
            if (TableName == TableName.Tech)
            {
                List<Model.Tech> models = obj as List<Model.Tech>;
                List<Model.Tech> models_List = models;

                //0代表（1图+5条）
                if (flag == 0)
                {
                    if (models.Count > 0)
                    {
                        Model.Tech model = models[0];
                        string Url = string.Format(ConfigUrl.UrlTechDetail, model.ID);
                        string Title = model.Title;
                        string TitleSub = StringHelper.SubString(model.Title, 28, 0);
                        string Summary = StringHelper.SubString(model.Summary, 86, 1);
                        string Picture = StringHelper.GetPicture_100_100(model.PictureSmall);
                        int Hits = model.Hits;
                        string Sourse = model.Source;

                        sbFirst.AppendLine("<div class=\"first\">");
                        sbFirst.AppendLine("<a href=\"" + Url + "\" target='_blank'><img alt='" + Title + "' src=\"" + Picture + "\" /></a>");
                        sbFirst.AppendLine("<div class=\"first_right\">");
                        sbFirst.AppendLine("<a href=\"" + Url + "\" target='_blank' title='" + Title + "'><h3 style='cursor:pointer'>" + TitleSub + "</h3></a>");
                        sbFirst.AppendLine("<h4>来源:" + Sourse + " 浏览:" + Hits + "</h4>");
                        sbFirst.AppendLine("<p><a href=\"" + Url + "\" target='_blank'>简述：" + Summary + "<em>[详细] </em></a></p>");
                        sbFirst.AppendLine("</div>");
                        sbFirst.AppendLine("</div>");
                        sbFirst.AppendLine("<div class='clear'></div>");

                        int n = models.Count;
                        if (n > 6)n = 6;
                        models_List = models.GetRange(1, n - 1);
                    }

                    WordCount = 48;
                }

                //1代表（11条）
                if (flag == 1)
                {
                    if (models.Count > 10)
                    {
                        models_List = models.GetRange(0, 10);
                    }

                    WordCount = 34;
                }

                
                foreach (Model.Tech model in models_List)
                {
                    string Url = string.Format(ConfigUrl.UrlTechDetail, model.ID);
                    string Title = model.Title;
                    string TitleSub = StringHelper.SubString(model.Title, WordCount, 1);

                    //34
                    sb.AppendLine("<li><a class='f12  ' href=\"" + Url + "\" target='_blank' title='" + Title + "'>" + TitleSub + "</a></li>");
                }
            }
            #endregion

            #region 下载中心
            if (TableName == TableName.Down)
            {
                List<Model.Down> models = obj as List<Model.Down>;
                List<Model.Down> models_List = models;

                //0代表（1图+5条）
                if (flag == 0)
                {
                    if (models.Count > 0)
                    {
                        Model.Down model = models[0];
                        string Url = string.Format(ConfigUrl.UrlDownDetail, model.ID);
                        string Title = model.Title;
                        string TitleSub = StringHelper.SubString(model.Title, 28, 0);
                        string Summary = StringHelper.SubString(model.Summary, 86, 1);
                        string Picture = StringHelper.GetPicture_100_100(model.PictureSmall);
                        int Hits = model.Hits;
                        string Sourse = model.Source;

                        sbFirst.AppendLine("<div class=\"first\">");
                        sbFirst.AppendLine("<a href=\"" + Url + "\" target='_blank'><img alt='" + Title + "' src=\"" + Picture + "\" /></a>");
                        sbFirst.AppendLine("<div class=\"first_right\">");
                        sbFirst.AppendLine("<a href=\"" + Url + "\" target='_blank' title='" + Title + "'><h3 style='cursor:pointer'>" + TitleSub + "</h3></a>");
                        sbFirst.AppendLine("<h4>来源:" + Sourse + " 浏览:" + Hits + "</h4>");
                        sbFirst.AppendLine("<p><a href=\"" + Url + "\" target='_blank'>简述：" + Summary + "<em>[详细] </em></a></p>");
                        sbFirst.AppendLine("</div>");
                        sbFirst.AppendLine("</div>");
                        sbFirst.AppendLine("<div class='clear'></div>");

                        int n = models.Count;
                        if (n > 6) n = 6;
                        models_List = models.GetRange(1, n - 1);
                    }

                    WordCount = 48;
                }

                //1代表（11条）
                if (flag == 1)
                {
                    if (models.Count > 10)
                    {
                        models_List = models.GetRange(0, 10);
                    }

                    WordCount = 34;
                }


                foreach (Model.Down model in models_List)
                {
                    string Url = string.Format(ConfigUrl.UrlDownDetail, model.ID);
                    string Title = model.Title;
                    string TitleSub = StringHelper.SubString(model.Title, WordCount, 1);

                    //34
                    sb.AppendLine("<li><a class='f12  ' href=\"" + Url + "\" target='_blank' title='" + Title + "'>" + TitleSub + "</a></li>");
                }
            }
            #endregion

            strFirst = sbFirst.ToString();
            strList = sb.ToString();
        }
    }
}