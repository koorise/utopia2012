using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类ProductVirtual 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ProductVirtual
	{
		public ProductVirtual()
		{}
		#region Model
		private int _id;
		private int? _productcategoryid;
		private int? _productid;
		private int? _virtualcategoryid;
		private int? _virtualid;
		/// <summary>
		/// 产品虚拟值
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 产品一级类别
		/// </summary>
		public int? ProductCategoryID
		{
			set{ _productcategoryid=value;}
			get{return _productcategoryid;}
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
		/// 虚拟类别
		/// </summary>
		public int? VirtualCategoryID
		{
			set{ _virtualcategoryid=value;}
			get{return _virtualcategoryid;}
		}
		/// <summary>
		/// 虚拟类别值
		/// </summary>
		public int? VirtualID
		{
			set{ _virtualid=value;}
			get{return _virtualid;}
		}
		#endregion Model

	}
}

