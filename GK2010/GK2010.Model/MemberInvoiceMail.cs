using System;
using System.Collections.Generic;
using System.Text;

namespace GK2010.Model
{
   public class MemberInvoiceMail
    {
        protected int _id;
        protected int _userID;
        protected string _company = String.Empty;
        protected string _realName = String.Empty;
        protected string _province = String.Empty;
        protected string _city = String.Empty;
        protected string _area = String.Empty;
        protected string _address = String.Empty;
        protected string _postCode = String.Empty;
        protected string _telephone = String.Empty;
        protected string _mobile = String.Empty;
        protected string _email = String.Empty;
        protected decimal _sortID;
        protected int _defaultFlag;

        #region Public Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }

        public string RealName
        {
            get { return _realName; }
            set { _realName = value; }
        }

        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }

        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public decimal SortID
        {
            get { return _sortID; }
            set { _sortID = value; }
        }

        public int DefaultFlag
        {
            get { return _defaultFlag; }
            set { _defaultFlag = value; }
        }
        #endregion
    }
}
