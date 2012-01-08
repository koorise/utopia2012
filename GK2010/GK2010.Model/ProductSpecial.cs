using System;
namespace GK2010.Model
{
	/// <summary>
	/// ʵ����ProductSpecial ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ProductSpecial
	{
		public ProductSpecial()
		{}
		#region Model
		private int _id;
		private int? _productid;
		private decimal? _price;
		private long _startdate;
		private long _enddate;
		private decimal? _sortid;
		/// <summary>
		/// ������Ʒ��ָ��ʱ������Ч��
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
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
		/// �����۸�
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// ��ʼʱ��
		/// </summary>
		public long StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public long EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public decimal? SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		#endregion Model

	}
}

