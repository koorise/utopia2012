using System;
namespace GK2010.Model
{
    /// <summary>
    /// 实体类MemberProductBrowse 。
    /// </summary>
    public class MemberProductBrowse
    {
        public MemberProductBrowse()
        { }
        #region Model
        private int _id;
        private int _memberid;
        private int _bigcategoryid;
        private int _productid;
        private string _producttitle;
        private string _productImgUrl;
        private decimal _defaultPrice;
        private DateTime _addtime;
        private string _ip;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MemberID
        {
            set { _memberid = value; }
            get { return _memberid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BigCategoryID
        {
            set { _bigcategoryid = value; }
            get { return _bigcategoryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductTitle
        {
            set { _producttitle = value; }
            get { return _producttitle; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ProductImgUrl
        {
            set { _productImgUrl = value; }
            get { return _productImgUrl; }
        }

        public decimal DefaultPrice {
            set { _defaultPrice=value; }
            get { return _defaultPrice; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IP
        {
            set { _ip = value; }
            get { return _ip; }
        }
        #endregion Model
    }
}
