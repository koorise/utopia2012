using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
namespace GK2010.Utility
{
    public class ConfigUrl
    {
        #region 是否是本机
        /// <summary>
        /// 是否是本机
        /// </summary>
        public static bool IsLocal
        {
            get
            {
                if (System.Web.HttpContext.Current.Request.Url.Host.ToLower() == "localhost")
                    return true;
                else
                    return false;
            }
        }
        #endregion

        #region 当前地址
        /// <summary>
        /// 当前地址
        /// </summary>
        public static string CurrentUrl
        {
            get
            {
                //return HttpContext.Current.Request.Url.ToString();
                return HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.RawUrl);
            }
        }
        #endregion  

        #region 返回地址
        /// <summary>
        /// 返回地址
        /// </summary>
        public static string ReturnUrl
        {
            get
            {
                return HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.RawUrl);
            }
        }
        #endregion        

        #region 管理后台Url
        public static string AdminUrlManage = "manage.aspx";//列表
        public static string AdminUrlAdd = "add.aspx?id={0}&ReturnUrl={1}";//添加
        public static string AdminUrlModify = "modify.aspx?id={0}&ReturnUrl={1}";//修改
        public static string AdminUrlShow = "show.aspx?id={0}&ReturnUrl={1}";//显示
        public static string AdminUrlDelete = "delete.aspx?id={0}&ReturnUrl={1}";//删除
        public static string AdminUrlDeleteBatch = "delete.aspx?ids={0}&ReturnUrl={1}";//批量删除
        public static string AdminUrlSearch = "manage.aspx?Keyword={0}";//搜索
        public static string AdminUrlResult = "/admin/result.aspx?UrlGo={0}&UrlBack={1}&ErrorMsg={2}";//操作结果
        #endregion    

        #region 前台地址

        #region 产品页面
       
        /// <summary>
        /// 产品首页
        /// </summary>
        public static string UrlProduct
        {
            get
            {
                return "/product/";
            }
        }
        ///<summary>
        ///产品类别列表
        ///{0}产品1级类别FirstCategoryID
        ///{1}产品2级类别SecondCategoryID
        ///{2}产品3级类别ThirdCategoryID（备用）
        ///{3}虚拟类别1(VirtualCategoryID1=0所有，其他代表值)
        ///{4}虚拟类别2(VirtualCategoryID2=0所有，其他代表值)
        ///{5}虚拟类别3
        ///{6}虚拟类别4
        ///{7}虚拟类别5
        ///{8}虚拟类别6
        ///{9}虚拟类别7
        ///{10}虚拟类别8
        ///{11}虚拟类别9
        ///{12}虚拟类别10   
        ///{13}排序(OrderyType=销量1,价格2,好评3,上架时间4)
        ///{14}显示方式(ShowType=图片1,列表2)
        ///{15}分页参数(Page=1，2，3，4，5)
        /// </summary>
        public static string UrlProductCategory
        {
            get
            {
                return "/product/{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}-{9}-{10}-{11}-{12}-{13}-{14}-{15}.html";
            }
        }
        /// <summary>
        /// 产品详细
        /// </summary>
        public static string UrlProductDetail
        {
            get
            {
                return "/product/{0}.html";
            }
        }

        /// <summary>
        /// 产品自助选型
        /// </summary>
        public static string UrlProductDiy
        {
            get
            {
                return "/product/diy_{0}.html";
            }
        }
        #endregion

        #region 产品评价列表
        /// <summary>
        /// 产品评价列表
        /// </summary>
        public static string UrlMemberProductEvaluateList
        {
            get
            {
                return "/product/{0}-{1}.html";
            }
        }
        #endregion

        #region 新闻中心

        /// <summary>
        /// 新闻中心首页
        /// </summary>
        public static string UrlNews
        {
            get
            {
                return "/news/";
            }
        }
        /// <summary>
        /// 新闻中心列表页
        /// </summary>
        public static string UrlNewsList
        {
            get
            {
                //{0}类别CategoryID
                //{1}排序OrderType
                //{15}分页参数(Page=1，2，3，4，5)
                return "/news/{0}-{1}-{2}.html";
            }
        }
        /// <summary>
        /// 新闻中心详细页
        /// </summary>
        public static string UrlNewsDetail
        {
            get
            {
                return "/news/{0}.html";
            }
        }

        #endregion

        #region 技术支持

        /// <summary>
        /// 技术支持首页
        /// </summary>
        public static string UrlTech
        {
            get
            {
                return "/Tech/";
            }
        }
        /// <summary>
        /// 技术支持列表页
        /// </summary>
        public static string UrlTechList
        {
            get
            {
                //{0}类别CategoryID
                //{1}排序OrderType
                //{15}分页参数(Page=1，2，3，4，5)
                return "/Tech/{0}-{1}-{2}.html";
            }
        }
        /// <summary>
        /// 技术支持详细页
        /// </summary>
        public static string UrlTechDetail
        {
            get
            {
                return "/Tech/{0}.html";
            }
        }

        #endregion

        #region 问答页面
        /// <summary>
        /// 问答首页
        /// </summary>
        public static string UrlQa
        {
            get
            {
                return "/Qa/";
            }
        }
        /// <summary>
        /// 问答列表页
        /// </summary>
        public static string UrlQaList
        {
            get
            {
                //{0}产品1级类别FirstCategoryID
                //{1}产品2级类别SecondCategoryID
                //{15}分页参数(Page=1，2，3，4，5)
                return "/Qa/{0}-{1}-{2}.html";
            }
        }
        /// <summary>
        /// 问答详细页
        /// </summary>
        public static string UrlQaDetail
        {
            get
            {
                return "/Qa/{0}.html";
            }
        }

        #endregion

        #region 解决方案页面
        /// <summary>
        /// 解决方案首页
        /// </summary>
        public static string UrlProgram
        {
            get
            {
                return "/Program/";
            }
        }
        /// <summary>
        /// 解决方案列表页{0}0行业,1介质,{1}1级类别,{2}2级类别,{3}排序,{4}分页
        /// </summary>
        public static string UrlProgramList
        {
            get
            {
                //{0}0应用行业|1应用介质 
                //{1}1级类别FirstCategoryID
                //{2}2级类别SecondCategoryID
                //{3}排序（0默认）
                //{4}分页参数(Page=1，2，3，4，5)
                return "/Program/{0}-{1}-{2}-{3}-{4}.html";
            }
        }
        /// <summary>
        /// 解决方案详细页
        /// </summary>
        public static string UrlProgramDetail
        {
            get
            {
                return "/Program/{0}.html";
            }
        }

        #endregion

        #region 下载中心页面
        /// <summary>
        /// 下载中心首页
        /// </summary>
        public static string UrlDown
        {
            get
            {
                return "/Down/";
            }
        }
        /// <summary>
        /// 下载中心列表页
        /// </summary>
        public static string UrlDownList
        {
            get
            {
                //{0}产品1级类别FirstCategoryID
                //{1}产品2级类别SecondCategoryID
                //{15}分页参数(Page=1，2，3，4，5)
                return "/Down/{0}-{1}-{2}.html";
            }
        }
        /// <summary>
        /// 下载中心详细页
        /// </summary>
        public static string UrlDownDetail
        {
            get
            {
                return "/Down/{0}.html";
            }
        }

        #endregion

        #region 帮助中心页面
        /// <summary>
        /// 帮助中心首页
        /// </summary>
        public static string UrlHelp
        {
            get
            {
                return "/Help/";
            }
        }
        /// <summary>
        /// 帮助中心列表页
        /// </summary>
        public static string UrlHelpList
        {
            get
            {
                //{0}帮助1级类别CategoryID
                //{1}帮助2级类别
                //{2}分页参数(Page=1，2，3，4，5)
                return "/Help/{0}-{1}-{2}.html";
            }
        }
        /// <summary>
        /// 帮助中心详细页
        /// </summary>
        public static string UrlHelpDetail
        {
            get
            {
                return "/Help/{0}.html";
            }
        }

        #endregion

        #region 关于我们页面
        /// <summary>
        /// 关于我们首页
        /// </summary>
        public static string UrlCorp
        {
            get
            {
                return "/Corp/";
            }
        }
        /// <summary>
        /// 关于我们列表页
        /// </summary>
        public static string UrlCorpList
        {
            get
            {
                //{0}产品1级类别FirstCategoryID
                //{1}产品2级类别SecondCategoryID
                //{2}分页参数(Page=1，2，3，4，5)
                return "/Corp/{0}-{1}-{2}.html";
            }
        }
        /// <summary>
        /// 关于我们详细页
        /// </summary>
        public static string UrlCorpDetail
        {
            get
            {
                return "/Corp/{0}.html";
            }
        }

        #endregion

        #region 品牌页面
        /// <summary>
        /// 品牌首页
        /// </summary>
        public static string UrlBrand
        {
            get
            {
                return "/Brand/";
            }
        }
        /// <summary>
        /// 品牌列表页
        /// </summary>
        public static string UrlBrandList
        {
            get
            {
                //{0}产品1级类别FirstCategoryID
                //{1}产品2级类别SecondCategoryID
                //{2}分页参数(Page=1，2，3，4，5)
                return "/Brand/{0}-{1}-{2}.html";
            }
        }
        /// <summary>
        /// 品牌详细页
        /// </summary>
        public static string UrlBrandDetail
        {
            get
            {
                return "/Brand/{0}.html";
            }
        }

        #endregion

        #region 评论页面
        /// <summary>
        /// 评论首页
        /// </summary>
        public static string UrlComment
        {
            get
            {
                return "/Comment/";
            }
        }
        /// <summary>
        /// 评论列表页
        /// </summary>
        public static string UrlCommentList
        {
            get
            {
                //{0}产品1级类别FirstCategoryID
                //{1}产品2级类别SecondCategoryID
                //{2}分页参数(Page=1，2，3，4，5)
                return "/Comment/{0}-{1}-{2}.html";
            }
        }
        /// <summary>
        /// 评论详细页
        /// </summary>
        public static string UrlCommentDetail
        {
            get
            {
                return "/Comment/{0}.html";
            }
        }

        #endregion

        #region 会员中心页面
        /// <summary>
        /// 会员中心页面首页
        /// </summary>
        public static string UrlMember
        {
            get
            {
                return "/Member/";
            }
        }

        #endregion

        #region 搜索页面
        /// <summary>
        /// 搜索页面
        /// </summary>
        public static string UrlSearch
        {
            get
            {
                return "/search.aspx?tag={0}";
            }
        }
        /// <summary>
        /// 搜索首页
        /// </summary>
        public static string UrlSearchIndex
        {
            get
            {
                return "/search.aspx";
            }
        }
        #endregion

        #endregion
    }
}
