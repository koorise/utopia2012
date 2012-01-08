using System;
namespace GK2010.Model
{
    /// <summary>
    /// ʵ����ConfigResultMsg ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class ConfigResultMsg
    {
        public ConfigResultMsg()
        { }
        #region Model
        private int _id;
        private string _category;
        private string _title;
        private string _titleen;
        private string _summary;
        private string _detail;
        private int? _type;
        private string _url1text;
        private string _url1;
        private string _url2text;
        private string _url2;
        private string _url3text;
        private string _url3;
        /// <summary>
        /// ���������ʾ
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string Category
        {
            set { _category = value; }
            get { return _category; }
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
        /// 
        /// </summary>
        public string Summary
        {
            set { _summary = value; }
            get { return _summary; }
        }
        /// <summary>
        /// ��ϸ
        /// </summary>
        public string Detail
        {
            set { _detail = value; }
            get { return _detail; }
        }
        /// <summary>
        /// ��ʾ����(0δ֪,1��ȷ,2����,3����)
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Url1Text
        {
            set { _url1text = value; }
            get { return _url1text; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Url1
        {
            set { _url1 = value; }
            get { return _url1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Url2Text
        {
            set { _url2text = value; }
            get { return _url2text; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Url2
        {
            set { _url2 = value; }
            get { return _url2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Url3Text
        {
            set { _url3text = value; }
            get { return _url3text; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Url3
        {
            set { _url3 = value; }
            get { return _url3; }
        }
        #endregion Model

    }
}

