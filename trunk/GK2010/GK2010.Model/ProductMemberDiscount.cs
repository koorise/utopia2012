using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类ProductMemberDiscount 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ProductMemberDiscount
	{
		public ProductMemberDiscount()
		{}
		#region Model
		private int _id;
		private int? _userid;
		private int? _productid;
		private int? _discountprice;
		private int? _discountjf;
		private int? _checkflag;
		private long _checkdate;
		private int? _checkuserid;
		/// <summary>
		/// 会员产品折扣
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 产品编号
		/// </summary>
		public int? ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 产品折扣(百分比)
		/// </summary>
		public int? DiscountPrice
		{
			set{ _discountprice=value;}
			get{return _discountprice;}
		}
		/// <summary>
		/// 积分折扣(百分比)
		/// </summary>
		public int? DiscountJF
		{
			set{ _discountjf=value;}
			get{return _discountjf;}
		}
		/// <summary>
		/// 审核标志
		/// </summary>
		public int? CheckFlag
		{
			set{ _checkflag=value;}
			get{return _checkflag;}
		}
		/// <summary>
		/// 审核时间
		/// </summary>
		public long CheckDate
		{
			set{ _checkdate=value;}
			get{return _checkdate;}
		}
		/// <summary>
		/// 审核人
		/// </summary>
		public int? CheckUserID
		{
			set{ _checkuserid=value;}
			get{return _checkuserid;}
		}
		#endregion Model

	}
}

