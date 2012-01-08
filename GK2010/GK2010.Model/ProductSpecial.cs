using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类ProductSpecial 。(属性说明自动提取数据库字段的描述信息)
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
		/// 促销商品（指定时间内有效）
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
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
		/// 促销价格
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public long StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public long EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public decimal? SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		#endregion Model

	}
}

