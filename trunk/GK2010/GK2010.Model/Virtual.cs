using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类Virtual 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Virtual
	{
		public Virtual()
		{}
		#region Model
        private int _id = 0;
        private int _productcategoryid = 0;
        private int _categoryid = 0;
        private string _title = "";
        private string _titleen = "";
		private decimal _sortid = 0;
		/// <summary>
		/// 虚拟类别值
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ProductCategoryID
		{
			set{ _productcategoryid=value;}
			get{return _productcategoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CategoryID
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TitleEn
		{
			set{ _titleen=value;}
			get{return _titleen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		#endregion Model

	}
}

