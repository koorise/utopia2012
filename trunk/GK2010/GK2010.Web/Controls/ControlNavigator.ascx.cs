using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Controls
{
    public partial class ControlNavigator : System.Web.UI.UserControl
    {
        #region 绑定当前位置
        /// <summary>
        /// 绑定当前位置(当前位置：首页 > XXXX)
        /// </summary>
        /// <param name="EnumNavigator">导航</param>
        /// <param name="Detail"></param>
        public void BindNavigator(EnumNavigator EnumNavigator)
        {
            string Url = "";
            string strSep = "&nbsp;>&nbsp;";

            #region 绑定类别

            #region 产品中心
            if (EnumNavigator == EnumNavigator.Product)
            {
                Url = ConfigUrl.UrlProduct;
                txtNavigator.Text = strSep + "<a href='" + Url + "'>产品中心</a>";

                if (ConfigParam.ID > 0)
                {
                    BLL.Product bll = new GK2010.BLL.Product();
                    Model.Product model = bll.GetModel(ConfigParam.ID);
                    if (model != null)
                    {
                        txtNavigator.Text += strSep + "<span>" + BLL.ProductCategory.GetTitle(model.CategoryID) + "</span>";
                        txtNavigator.Text += strSep + "<span>产品详情</span>";
                    }
                }
            }
            #endregion

            #region 新闻中心
            if (EnumNavigator == EnumNavigator.News)
            {
                Url = ConfigUrl.UrlNews;
                txtNavigator.Text = strSep + "<a href='" + Url + "'>新闻中心</a>";

                if (ConfigParam.CategoryID > 0)
                {
                    //类别
                    txtNavigator.Text += strSep + "<span>" + BLL.NewsCategory.GetTitle(ConfigParam.CategoryID) + "</span>";
                }

                if (ConfigParam.ID > 0)
                {
                    //详细
                    BLL.News bll = new GK2010.BLL.News();
                    Model.News model = bll.GetModel(ConfigParam.ID);
                    if (model != null)
                    {
                        txtNavigator.Text += strSep + "<span>" + BLL.NewsCategory.GetTitle(model.CategoryID) + "</span>";
                        txtNavigator.Text += strSep + "<span>正文</span>";
                    }
                }
            }

            #endregion

            #region 技术支持

            if (EnumNavigator == EnumNavigator.Tech)
            {
                Url = ConfigUrl.UrlTech;
                txtNavigator.Text = strSep + "<a href='" + Url + "'>技术支持</a>";

                if (ConfigParam.CategoryID > 0)
                {
                    //类别
                    txtNavigator.Text += strSep + "<span>" + BLL.TechCategory.GetTitle(ConfigParam.CategoryID) + "</span>";
                }

                if (ConfigParam.ID > 0)
                {
                    //详细
                    BLL.Tech bll = new GK2010.BLL.Tech();
                    Model.Tech model = bll.GetModel(ConfigParam.ID);
                    if (model != null)
                    {
                        txtNavigator.Text += strSep + "<span>" + BLL.TechCategory.GetTitle(model.CategoryID) + "</span>";
                        txtNavigator.Text += strSep + "<span>正文</span>";
                    }
                }
            }
            #endregion

            #region 方案中心
            if (EnumNavigator == EnumNavigator.Program)
            {
                Url = ConfigUrl.UrlProgram;
                txtNavigator.Text = strSep + "<a href='" + Url + "'>方案中心</a>";
            }
            #endregion

            #region 解答中心
            if (EnumNavigator == EnumNavigator.Qa)
            {
                Url = ConfigUrl.UrlQa;
                txtNavigator.Text = strSep + "<a href='" + Url + "'>解答中心</a>";
            }

            #endregion

            #region 下载中心
            if (EnumNavigator == EnumNavigator.Down)
            {
                Url = ConfigUrl.UrlDown;
                txtNavigator.Text = strSep + "<a href='" + Url + "'>下载中心</a>";

                if (ConfigParam.CategoryID > 0)
                {
                    //类别
                    txtNavigator.Text += strSep + "<span>" + BLL.DownCategory.GetTitle(ConfigParam.CategoryID) + "</span>";
                }

                if (ConfigParam.ID > 0)
                {
                    //详细
                    BLL.Down bll = new GK2010.BLL.Down();
                    Model.Down model = bll.GetModel(ConfigParam.ID);
                    if (model != null)
                    {
                        txtNavigator.Text += strSep + "<span>" + BLL.DownCategory.GetTitle(model.CategoryID) + "</span>";
                        txtNavigator.Text += strSep + "<span>正文</span>";
                    }
                }
            }
            #endregion

            #region 帮且中心
            if (EnumNavigator == EnumNavigator.Help)
            {
                Url = ConfigUrl.UrlHelp;
                txtNavigator.Text = strSep + "<a href='" + Url + "'>帮且中心</a>";

                if (ConfigParam.CategoryID > 0)
                {
                    //类别
                    txtNavigator.Text += strSep + "<span>" + BLL.HelpCategory.GetTitle(ConfigParam.CategoryID) + "</span>";
                }

                if (ConfigParam.ID > 0)
                {
                    //详细
                    BLL.Help bll = new GK2010.BLL.Help();
                    Model.Help model = bll.GetModel(ConfigParam.ID);
                    if (model != null)
                    {
                        txtNavigator.Text += strSep + "<span>" + BLL.HelpCategory.GetTitle(model.CategoryID) + "</span>";
                        txtNavigator.Text += strSep + "<span>" + model.Title + "</span>";
                    }
                }
            }
            #endregion

            #region 关于我们
            if (EnumNavigator == EnumNavigator.Corp)
            {
                Url = ConfigUrl.UrlCorp;
                txtNavigator.Text = strSep + "<a href='" + Url + "'>关于我们</a>";

                //详细
                BLL.Company bll = new GK2010.BLL.Company();
                Model.Company model = bll.GetModel(ConfigParam.ID);
                if (model != null)
                {
                    txtNavigator.Text += strSep + "<span>" + model.Title + "</span>";
                }
            }
            #endregion

            #region 会员中心

            if (EnumNavigator == EnumNavigator.Member)
            {
                Url = ConfigUrl.UrlMember;
                txtNavigator.Text = strSep + "<a href='" + Url + "'>会员中心</a>";

            }
            #endregion

            #endregion     
        }
        #endregion
    }
}