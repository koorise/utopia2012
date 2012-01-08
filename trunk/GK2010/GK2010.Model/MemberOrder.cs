using System;
using System.Collections.Generic;
using System.Text;

namespace GK2010.Model
{
    [Serializable]
    public class MemberOrder
    {
        protected int _id;
        protected int _userID;
        protected string _orderNum = String.Empty;
        protected int _totalNum;
        protected decimal _shipPrice;
        protected decimal _productPrice;
        protected decimal _otherPrice;
        protected decimal _totalPriceHasPay;
        protected decimal _totalPrice;
        protected decimal _totalJF;
        protected string _consigneeCompany = String.Empty;
        protected string _consigneeRealName = String.Empty;
        protected string _consigneeProvince = String.Empty;
        protected string _consigneeCity = String.Empty;
        protected string _consigneeArea = String.Empty;
        protected string _consigneeAddress = String.Empty;
        protected string _consigneePostCode = String.Empty;
        protected string _consigneeTelephone = String.Empty;
        protected string _consigneeMobile = String.Empty;
        protected string _consigneeEmail = String.Empty;
        protected string _payType = String.Empty;
        protected string _shipType = String.Empty;
        protected string _invoiceType = String.Empty;
        protected string _invoiceCompany = String.Empty;
        protected string _invoiceNum = String.Empty;
        protected string _invoiceAddress = String.Empty;
        protected string _invoiceTelephone = String.Empty;
        protected string _invoiceBank = String.Empty;
        protected string _invoiceBankAccount = String.Empty;
        protected string _invoiceContent = String.Empty;
        protected string _invoiceMailCompany = String.Empty;
        protected string _invoiceMailRealName = String.Empty;
        protected string _invoiceMailProvince = String.Empty;
        protected string _invoiceMailCity = String.Empty;
        protected string _invoiceMailArea = String.Empty;
        protected string _invoiceMailAddress = String.Empty;
        protected string _invoiceMailPostCode = String.Empty;
        protected string _invoiceMailTelephone = String.Empty;
        protected string _invoiceMailMobile = String.Empty;
        protected string _invoiceMailEmail = String.Empty;
        protected string _liuyan = String.Empty;
        protected int _statusFlag;
        protected long _statusDate;
        protected int _statusUserID;
        protected long _postDate;
        protected int _postUserID;
        protected long _editDate;
        protected int _editUserID;
        protected string _remark = String.Empty;

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

        public string OrderNum
        {
            get { return _orderNum; }
            set { _orderNum = value; }
        }

        public int TotalNum
        {
            get { return _totalNum; }
            set { _totalNum = value; }
        }

        public decimal ShipPrice
        {
            get { return _shipPrice; }
            set { _shipPrice = value; }
        }

        public decimal ProductPrice
        {
            get { return _productPrice; }
            set { _productPrice = value; }
        }

        public decimal OtherPrice
        {
            get { return _otherPrice; }
            set { _otherPrice = value; }
        }

        public decimal TotalPriceHasPay
        {
            get { return _totalPriceHasPay; }
            set { _totalPriceHasPay = value; }
        }

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        public decimal TotalJF
        {
            get { return _totalJF; }
            set { _totalJF = value; }
        }

        public string ConsigneeCompany
        {
            get { return _consigneeCompany; }
            set { _consigneeCompany = value; }
        }

        public string ConsigneeRealName
        {
            get { return _consigneeRealName; }
            set { _consigneeRealName = value; }
        }

        public string ConsigneeProvince
        {
            get { return _consigneeProvince; }
            set { _consigneeProvince = value; }
        }

        public string ConsigneeCity
        {
            get { return _consigneeCity; }
            set { _consigneeCity = value; }
        }

        public string ConsigneeArea
        {
            get { return _consigneeArea; }
            set { _consigneeArea = value; }
        }

        public string ConsigneeAddress
        {
            get { return _consigneeAddress; }
            set { _consigneeAddress = value; }
        }

        public string ConsigneePostCode
        {
            get { return _consigneePostCode; }
            set { _consigneePostCode = value; }
        }

        public string ConsigneeTelephone
        {
            get { return _consigneeTelephone; }
            set { _consigneeTelephone = value; }
        }

        public string ConsigneeMobile
        {
            get { return _consigneeMobile; }
            set { _consigneeMobile = value; }
        }

        public string ConsigneeEmail
        {
            get { return _consigneeEmail; }
            set { _consigneeEmail = value; }
        }

        public string PayType
        {
            get { return _payType; }
            set { _payType = value; }
        }

        public string ShipType
        {
            get { return _shipType; }
            set { _shipType = value; }
        }

        public string InvoiceType
        {
            get { return _invoiceType; }
            set { _invoiceType = value; }
        }

        public string InvoiceCompany
        {
            get { return _invoiceCompany; }
            set { _invoiceCompany = value; }
        }

        public string InvoiceNum
        {
            get { return _invoiceNum; }
            set { _invoiceNum = value; }
        }

        public string InvoiceAddress
        {
            get { return _invoiceAddress; }
            set { _invoiceAddress = value; }
        }

        public string InvoiceTelephone
        {
            get { return _invoiceTelephone; }
            set { _invoiceTelephone = value; }
        }

        public string InvoiceBank
        {
            get { return _invoiceBank; }
            set { _invoiceBank = value; }
        }

        public string InvoiceBankAccount
        {
            get { return _invoiceBankAccount; }
            set { _invoiceBankAccount = value; }
        }

        public string InvoiceContent
        {
            get { return _invoiceContent; }
            set { _invoiceContent = value; }
        }

        public string InvoiceMailCompany
        {
            get { return _invoiceMailCompany; }
            set { _invoiceMailCompany = value; }
        }

        public string InvoiceMailRealName
        {
            get { return _invoiceMailRealName; }
            set { _invoiceMailRealName = value; }
        }

        public string InvoiceMailProvince
        {
            get { return _invoiceMailProvince; }
            set { _invoiceMailProvince = value; }
        }

        public string InvoiceMailCity
        {
            get { return _invoiceMailCity; }
            set { _invoiceMailCity = value; }
        }

        public string InvoiceMailArea
        {
            get { return _invoiceMailArea; }
            set { _invoiceMailArea = value; }
        }

        public string InvoiceMailAddress
        {
            get { return _invoiceMailAddress; }
            set { _invoiceMailAddress = value; }
        }

        public string InvoiceMailPostCode
        {
            get { return _invoiceMailPostCode; }
            set { _invoiceMailPostCode = value; }
        }

        public string InvoiceMailTelephone
        {
            get { return _invoiceMailTelephone; }
            set { _invoiceMailTelephone = value; }
        }

        public string InvoiceMailMobile
        {
            get { return _invoiceMailMobile; }
            set { _invoiceMailMobile = value; }
        }

        public string InvoiceMailEmail
        {
            get { return _invoiceMailEmail; }
            set { _invoiceMailEmail = value; }
        }

        public string Liuyan
        {
            get { return _liuyan; }
            set { _liuyan = value; }
        }

        public int StatusFlag
        {
            get { return _statusFlag; }
            set { _statusFlag = value; }
        }

        public long StatusDate
        {
            get { return _statusDate; }
            set { _statusDate = value; }
        }

        public int StatusUserID
        {
            get { return _statusUserID; }
            set { _statusUserID = value; }
        }

        public long PostDate
        {
            get { return _postDate; }
            set { _postDate = value; }
        }

        public int PostUserID
        {
            get { return _postUserID; }
            set { _postUserID = value; }
        }

        //public long EditDate
        //{
        //    get { return _editDate; }
        //    set { _editDate = value; }
        //}

        //public int EditUserID
        //{
        //    get { return _editUserID; }
        //    set { _editUserID = value; }
        //}

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        #endregion


    }


}
