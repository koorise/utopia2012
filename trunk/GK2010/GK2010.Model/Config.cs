using System;
namespace GK2010.Model
{
    /// <summary>
    /// 实体类Config 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Config
    {
        public Config()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _titleen;
        private string _webdomain;
        private string _webname;
        private string _webbeian;
        private string _webstatic;
        private string _controlservice;
        private string _controltop;
        private string _controlboot;
        private int _showpricediyflag;
        private int _showpricewhennotlogin;
        private string _alipayaccount;
        private string _alipaypartnerid;
        private string _alipaykey;
        private string _alipayusername;
        private string _alipayuserpwd;
        private string _emailusername;
        private string _emailuserpwd;
        private string _emailhost;
        private string _emailport;
        private string _mobileusername;
        private string _mobileuserpwd;
        private string _mobileeid;
        /// <summary>
        /// 常用配置信息
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TitleEn
        {
            set { _titleen = value; }
            get { return _titleen; }
        }
        /// <summary>
        /// 网站域名
        /// </summary>
        public string WebDomain
        {
            set { _webdomain = value; }
            get { return _webdomain; }
        }
        /// <summary>
        /// 网站名称
        /// </summary>
        public string WebName
        {
            set { _webname = value; }
            get { return _webname; }
        }
        /// <summary>
        /// 网站备案号
        /// </summary>
        public string WebBeian
        {
            set { _webbeian = value; }
            get { return _webbeian; }
        }
        /// <summary>
        /// 网站统计
        /// </summary>
        public string WebStatic
        {
            set { _webstatic = value; }
            get { return _webstatic; }
        }
        /// <summary>
        /// 网站53在线客服代码
        /// </summary>
        public string ControlService
        {
            set { _controlservice = value; }
            get { return _controlservice; }
        }
        /// <summary>
        /// 头部
        /// </summary>
        public string ControlTop
        {
            set { _controltop = value; }
            get { return _controltop; }
        }
        /// <summary>
        /// 底部
        /// </summary>
        public string ControlBoot
        {
            set { _controlboot = value; }
            get { return _controlboot; }
        }
        /// <summary>
        /// 显示选型价格
        /// </summary>
        public int ShowPriceDiyFlag
        {
            set { _showpricediyflag = value; }
            get { return _showpricediyflag; }
        }
        /// <summary>
        /// 没有登录显示价格
        /// </summary>
        public int ShowPriceWhenNotLogin
        {
            set { _showpricewhennotlogin = value; }
            get { return _showpricewhennotlogin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AliPayAccount
        {
            set { _alipayaccount = value; }
            get { return _alipayaccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AliPayPartnerID
        {
            set { _alipaypartnerid = value; }
            get { return _alipaypartnerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AliPayKey
        {
            set { _alipaykey = value; }
            get { return _alipaykey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AliPayUserName
        {
            set { _alipayusername = value; }
            get { return _alipayusername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AliPayUserPwd
        {
            set { _alipayuserpwd = value; }
            get { return _alipayuserpwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EmailUserName
        {
            set { _emailusername = value; }
            get { return _emailusername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EmailUserPwd
        {
            set { _emailuserpwd = value; }
            get { return _emailuserpwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EmailHost
        {
            set { _emailhost = value; }
            get { return _emailhost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EmailPort
        {
            set { _emailport = value; }
            get { return _emailport; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MobileUserName
        {
            set { _mobileusername = value; }
            get { return _mobileusername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MobileUserPwd
        {
            set { _mobileuserpwd = value; }
            get { return _mobileuserpwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MobileEID
        {
            set { _mobileeid = value; }
            get { return _mobileeid; }
        }
        #endregion Model

    }
}

