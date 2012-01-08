using System;
using System.Collections.Generic;
using System.Text;

namespace GK2010.Model
{
    [Serializable]
   public class MemberProductEvaluate
    {
        protected long _id;
        protected long _productID;
        protected long _memberID;
        protected string _memeberUserName = String.Empty;
        protected int _bigCategoryID;
        protected string _productTitle = String.Empty;
        protected string _evaluateTitle = String.Empty;
        protected string _evaluateTime = String.Empty;
        protected string _advantage = String.Empty;
        protected string _inadequate = String.Empty;
        protected int _evaluateGrade;
        protected string _reply = String.Empty;
        protected int _review;
        protected int _comment;
        protected int _score;

        #region Public Properties
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public long ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        public long MemberID
        {
            get { return _memberID; }
            set { _memberID = value; }
        }

        public string MemeberUserName {
            get { return _memeberUserName; }
            set { _memeberUserName = value; }
        }

        public int BigCategoryID
        {
            get { return _bigCategoryID; }
            set { _bigCategoryID = value; }
        }

        public string ProductTitle
        {
            get { return _productTitle; }
            set { _productTitle = value; }
        }

        public string EvaluateTitle
        {
            get { return _evaluateTitle; }
            set { _evaluateTitle = value; }
        }

        public string EvaluateTime
        {
            get { return _evaluateTime; }
            set { _evaluateTime = value; }
        }

        public string Advantage
        {
            get { return _advantage; }
            set { _advantage = value; }
        }

        public string Inadequate
        {
            get { return _inadequate; }
            set { _inadequate = value; }
        }

        public int EvaluateGrade
        {
            get { return _evaluateGrade; }
            set { _evaluateGrade = value; }
        }

        public string Reply
        {
            get { return _reply; }
            set { _reply = value; }
        }

        public int Review
        {
            get { return _review; }
            set { _review = value; }
        }
        public int Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
        #endregion
    }
}
