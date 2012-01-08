using System;
using System.Collections.Generic;
using System.Text;

namespace GK2010.Model
{
    [Serializable]
    public class MemberProductFavorite
    {
        protected int _id;
        protected int _memberID;
        protected int _bigCategoryID;
        protected int _productID;
        protected string _productTitle = String.Empty;
        protected DateTime _addtime;
        protected string _iP = String.Empty;

        #region Public Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int MemberID
        {
            get { return _memberID; }
            set { _memberID = value; }
        }

        public int BigCategoryID
        {
            get { return _bigCategoryID; }
            set { _bigCategoryID = value; }
        }

        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        public string ProductTitle
        {
            get { return _productTitle; }
            set { _productTitle = value; }
        }

        public DateTime Addtime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        public string IP
        {
            get { return _iP; }
            set { _iP = value; }
        }
        #endregion
    }
}
