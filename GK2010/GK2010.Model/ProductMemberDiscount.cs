using System;
namespace GK2010.Model
{
	/// <summary>
	/// ʵ����ProductMemberDiscount ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��Ա��Ʒ�ۿ�
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
		/// ��Ʒ���
		/// </summary>
		public int? ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// ��Ʒ�ۿ�(�ٷֱ�)
		/// </summary>
		public int? DiscountPrice
		{
			set{ _discountprice=value;}
			get{return _discountprice;}
		}
		/// <summary>
		/// �����ۿ�(�ٷֱ�)
		/// </summary>
		public int? DiscountJF
		{
			set{ _discountjf=value;}
			get{return _discountjf;}
		}
		/// <summary>
		/// ��˱�־
		/// </summary>
		public int? CheckFlag
		{
			set{ _checkflag=value;}
			get{return _checkflag;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public long CheckDate
		{
			set{ _checkdate=value;}
			get{return _checkdate;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public int? CheckUserID
		{
			set{ _checkuserid=value;}
			get{return _checkuserid;}
		}
		#endregion Model

	}
}

