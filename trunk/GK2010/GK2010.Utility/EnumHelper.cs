using System;
using System.Collections.Generic;
using System.Text;
using GK2010.Utility;

namespace GK2010.Utility
{
    /// <summary>
    /// 导航
    /// </summary>
    public enum EnumNavigator
    {
        /// <summary>
        /// 首页
        /// </summary>
        Index = 1,
        /// <summary>
        /// 产品中心
        /// </summary>
        Product = 2,
        /// <summary>
        /// 新闻中心
        /// </summary>
        News = 3,
        /// <summary>
        /// 技术中心
        /// </summary>
        Tech = 4,
        /// <summary>
        /// 方案中心
        /// </summary>
        Program = 5,
        /// <summary>
        /// 解答中心
        /// </summary>
        Qa = 6,
        /// <summary>
        /// 下载中心
        /// </summary>
        Down = 7,
        /// <summary>
        /// 帮且中心
        /// </summary>
        Help = 8,
        /// <summary>
        /// 关于我们
        /// </summary>
        Corp = 9,
        /// <summary>
        /// 会员中心
        /// </summary>
        Member = 10,
         /// <summary>
        /// 积分商城
        /// </summary>
        JF = 11
    }

    /// <summary>
    /// 登录方式
    /// </summary>
    public enum EnumLoginType
    {
        /// <summary>
        /// 用户名
        /// </summary>
        UserName = 1,
        /// <summary>
        /// 邮箱
        /// </summary>
        Email = 2,
        /// <summary>
        /// 手机
        /// </summary>
        Mobile = 3
    }

    #region 发送邮件与发送短信
    /// <summary>
    /// 发送邮件与发送短信
    /// </summary>
    public enum EnumSendType
    {
        /// <summary>
        /// 取回密码
        /// </summary>
        GetPwd,
        /// <summary>
        /// 激活
        /// </summary>
        Valid
    }
    #endregion    

    /// <summary>
    /// 表名
    /// </summary>
    public enum TableName
    { 
        /// <summary>
        /// 关于我们
        /// </summary>
        Company,
        /// <summary>
        /// 技术支持
        /// </summary>
        Tech,
        /// <summary>
        /// 下载
        /// </summary>
        Down,
        /// <summary>
        /// 问答
        /// </summary>
        Qa,
        /// <summary>
        /// 帮助
        /// </summary>
        Help,
        /// <summary>
        /// 方案
        /// </summary>
        Program,
        /// <summary>
        /// 新闻
        /// </summary>
        News,
        /// <summary>
        /// 产品
        /// </summary>
        Product,
        /// <summary>
        /// 积分商品
        /// </summary>
        ProductJF,
        /// <summary>
        /// 品牌
        /// </summary>
        Brand,
        /// <summary>
        /// 幻灯片
        /// </summary>
        Slide
    }

}
