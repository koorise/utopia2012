using System;
namespace GK2010.Model
{
	/// <summary>
	/// ���ڷ�����Ϣʱ���滻ģ��
	/// </summary>
	[Serializable]
	public class MsgHelper
	{
        public MsgHelper()
		{}

        #region �û����
        private string _UserID = "";
        /// <summary>
        /// �û����
        /// </summary>
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        #endregion

        #region �û���
        private string _UserName = "";
        /// <summary>
        /// �û���
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        #endregion

        #region ��ʵ����
        private string _RealName = "";
        /// <summary>
        /// ��ʵ����
        /// </summary>
        public string RealName
        {
            get { return _RealName; }
            set { _RealName = value; }
        }
        #endregion

        #region ֧�����˺�
        private string _AlipayNumber = "";
        /// <summary>
        /// ֧�����˺�
        /// </summary>
        public string AlipayNumber
        {
            get { return _AlipayNumber; }
            set { _AlipayNumber = value; }
        }
        #endregion

        #region ���п���
        private string _BankNumber = "";
        /// <summary>
        /// ���п���
        /// </summary>
        public string BankNumber
        {
            get { return _BankNumber; }
            set { _BankNumber = value; }
        }
        #endregion

        #region �ֻ�����
        private string _Mobile = "";
        /// <summary>
        /// �ֻ�����
        /// </summary>
        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }
        #endregion

        #region �ֻ�(�޸���֤)
        private string _MobileUrlModify = "";
        /// <summary>
        /// �ֻ�(�޸���֤)
        /// </summary>
        public string MobileUrlModify
        {
            get { return _MobileUrlModify; }
            set { _MobileUrlModify = value; }
        }
        #endregion

        #region ����
        private string _Email = "";
        /// <summary>
        /// ����
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        #endregion

        #region ����(�޸���֤)
        private string _EmailUrlModify = "";
        /// <summary>
        /// ����(�޸���֤)
        /// </summary>
        public string EmailUrlModify
        {
            get { return _EmailUrlModify; }
            set { _EmailUrlModify = value; }
        }
        #endregion        

        #region ���������ַ
        private string _EmailUrl = "";
        /// <summary>
        /// ���������ַ
        /// </summary>
        public string EmailUrl
        {
            get { return _EmailUrl; }
            set { _EmailUrl = value; }
        }
        #endregion

        #region ���伤���ַ
        private string _ActiveUrl = "";
        /// <summary>
        /// ���伤���ַ
        /// </summary>
        public string ActiveUrl
        {
            get { return _ActiveUrl; }
            set { _ActiveUrl = value; }
        }
        #endregion

        #region ���伤����
        private string _ActiveCode = "";
        /// <summary>
        /// ���伤����
        /// </summary>
        public string ActiveCode
        {
            get { return _ActiveCode; }
            set { _ActiveCode = value; }
        }
        #endregion

        #region ����ʱ��
        private string _Now = "";
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string Now
        {
            get { return _Now; }
            set { _Now = value; }
        }
        #endregion

        #region ʱ���ʽyyyy��MM��dd��
        private string _YYYYMMDD = "";
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string YYYYMMDD
        {
            get { return _YYYYMMDD; }
            set { _YYYYMMDD = value; }
        }
        #endregion
	}
}

