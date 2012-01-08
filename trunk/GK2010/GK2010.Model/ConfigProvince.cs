using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类ConfigProvince 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ConfigProvince
	{
		public ConfigProvince()
		{}
		#region Model
		private int _id;
		private string _provinceid;
		private string _provincename;
		private string _provinceen;
		private decimal? _sortid;
		/// <summary>
		/// 编号
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 省份编号
		/// </summary>
		public string ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 省份名称
		/// </summary>
		public string ProvinceName
		{
			set{ _provincename=value;}
			get{return _provincename;}
		}
		/// <summary>
		/// 省份拼音
		/// </summary>
		public string ProvinceEn
		{
			set{ _provinceen=value;}
			get{return _provinceen;}
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

