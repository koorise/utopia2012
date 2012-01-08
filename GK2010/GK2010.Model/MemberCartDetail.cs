using System;
using System.Collections.Generic;
using System.Text;

namespace GK2010.Model
{
    [Serializable]
   public class MemberCartDetail
    {
        protected int _id;
        protected string _cartNum = String.Empty;
        protected long _productCacheID;
        protected long _productPartsCacheID;
        protected int _diyFlag;
        protected string _diyTypeCn = String.Empty;
        protected string _diyTypeEn = String.Empty;
        protected string _diyTypePartsID = String.Empty;
        protected string _diyTypePrice = String.Empty;
        protected string _diyTypeAttachmentFlag = String.Empty;
        protected string _diyExpression = String.Empty;
        protected int _basicDiscountPrice;
        protected int _basicDiscountJF;
        protected decimal _priceOld;
        protected decimal _price;
        protected decimal _jFOld;
        protected decimal _jF;
        protected int _num;
        protected decimal _totalPrice;
        protected decimal _totalJF;

        #region Public Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string CartNum
        {
            get { return _cartNum; }
            set { _cartNum = value; }
        }

        public long ProductCacheID
        {
            get { return _productCacheID; }
            set { _productCacheID = value; }
        }

        public long ProductPartsCacheID
        {
            get { return _productPartsCacheID; }
            set { _productPartsCacheID = value; }
        }

        public int DiyFlag
        {
            get { return _diyFlag; }
            set { _diyFlag = value; }
        }

        public string DiyTypeCn
        {
            get { return _diyTypeCn; }
            set { _diyTypeCn = value; }
        }

        public string DiyTypeEn
        {
            get { return _diyTypeEn; }
            set { _diyTypeEn = value; }
        }

        public string DiyTypePartsID
        {
            get { return _diyTypePartsID; }
            set { _diyTypePartsID = value; }
        }

        public string DiyTypePrice
        {
            get { return _diyTypePrice; }
            set { _diyTypePrice = value; }
        }

        public string DiyTypeAttachmentFlag
        {
            get { return _diyTypeAttachmentFlag; }
            set { _diyTypeAttachmentFlag = value; }
        }

        public string DiyExpression
        {
            get { return _diyExpression; }
            set { _diyExpression = value; }
        }

        public int BasicDiscountPrice
        {
            get { return _basicDiscountPrice; }
            set { _basicDiscountPrice = value; }
        }

        public int BasicDiscountJF
        {
            get { return _basicDiscountJF; }
            set { _basicDiscountJF = value; }
        }

        public decimal PriceOld
        {
            get { return _priceOld; }
            set { _priceOld = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public decimal JFOld
        {
            get { return _jFOld; }
            set { _jFOld = value; }
        }

        public decimal JF
        {
            get { return _jF; }
            set { _jF = value; }
        }

        public int Num
        {
            get { return _num; }
            set { _num = value; }
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
        #endregion
    }
}
