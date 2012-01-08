using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类ConfigSeo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ConfigSeo
	{
		public ConfigSeo()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _titleen;
		private string _seotitle;
		private string _seokeywords;
		private string _seodescription;
		private decimal _sortid = 0;
		/// <summary>
		/// SEO
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
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
		public string SeoTitle
		{
			set{ _seotitle=value;}
			get{return _seotitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SeoKeywords
		{
			set{ _seokeywords=value;}
			get{return _seokeywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SeoDescription
		{
			set{ _seodescription=value;}
			get{return _seodescription;}
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

