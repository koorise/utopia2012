using System;
namespace GK2010.Model
{
	/// <summary>
	/// 用于发送信息时的替换模块
	/// </summary>
	[Serializable]
	public class MsgHelper
	{
        public MsgHelper()
		{}

        #region 用户编号
        private string _UserID = "";
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        #endregion

        #region 用户名
        private string _UserName = "";
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        #endregion

        #region 真实姓名
        private string _RealName = "";
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName
        {
            get { return _RealName; }
            set { _RealName = value; }
        }
        #endregion

        #region 支付宝账号
        private string _AlipayNumber = "";
        /// <summary>
        /// 支付宝账号
        /// </summary>
        public string AlipayNumber
        {
            get { return _AlipayNumber; }
            set { _AlipayNumber = value; }
        }
        #endregion

        #region 银行卡号
        private string _BankNumber = "";
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankNumber
        {
            get { return _BankNumber; }
            set { _BankNumber = value; }
        }
        #endregion

        #region 手机号码
        private string _Mobile = "";
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }
        #endregion

        #region 手机(修改验证)
        private string _MobileUrlModify = "";
        /// <summary>
        /// 手机(修改验证)
        /// </summary>
        public string MobileUrlModify
        {
            get { return _MobileUrlModify; }
            set { _MobileUrlModify = value; }
        }
        #endregion

        #region 邮箱
        private string _Email = "";
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        #endregion

        #region 邮箱(修改验证)
        private string _EmailUrlModify = "";
        /// <summary>
        /// 邮箱(修改验证)
        /// </summary>
        public string EmailUrlModify
        {
            get { return _EmailUrlModify; }
            set { _EmailUrlModify = value; }
        }
        #endregion        

        #region 进入邮箱地址
        private string _EmailUrl = "";
        /// <summary>
        /// 进入邮箱地址
        /// </summary>
        public string EmailUrl
        {
            get { return _EmailUrl; }
            set { _EmailUrl = value; }
        }
        #endregion

        #region 邮箱激活地址
        private string _ActiveUrl = "";
        /// <summary>
        /// 邮箱激活地址
        /// </summary>
        public string ActiveUrl
        {
            get { return _ActiveUrl; }
            set { _ActiveUrl = value; }
        }
        #endregion

        #region 邮箱激活码
        private string _ActiveCode = "";
        /// <summary>
        /// 邮箱激活码
        /// </summary>
        public string ActiveCode
        {
            get { return _ActiveCode; }
            set { _ActiveCode = value; }
        }
        #endregion

        #region 现在时间
        private string _Now = "";
        /// <summary>
        /// 现在时间
        /// </summary>
        public string Now
        {
            get { return _Now; }
            set { _Now = value; }
        }
        #endregion

        #region 时间格式yyyy年MM月dd日
        private string _YYYYMMDD = "";
        /// <summary>
        /// 现在时间
        /// </summary>
        public string YYYYMMDD
        {
            get { return _YYYYMMDD; }
            set { _YYYYMMDD = value; }
        }
        #endregion
	}
}

