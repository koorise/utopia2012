using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类ConfigABC 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ConfigABC
	{
		public ConfigABC()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _titleen;
		private decimal? _sortid;
		/// <summary>
		/// 
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
		public decimal? SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		#endregion Model

	}
}

