using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类ConfigCity 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ConfigCity
	{
		public ConfigCity()
		{}
		#region Model
		private int _id;
		private string _provinceid;
		private string _cityid;
		private string _cityname;
		private string _cityen;
		private string _citycharfull;
		private string _citycharsub;
		private string _citycode;
		private int? _hotflag;
		private decimal? _hotsortid;
		private int? _openflag;
		private string _weburl;
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
		/// 城市编号
		/// </summary>
		public string CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 城市名称
		/// </summary>
		public string CityName
		{
			set{ _cityname=value;}
			get{return _cityname;}
		}
		/// <summary>
		/// 城市拼音
		/// </summary>
		public string CityEn
		{
			set{ _cityen=value;}
			get{return _cityen;}
		}
		/// <summary>
		/// 字母全写如（南京nanjing）
		/// </summary>
		public string CityCharFull
		{
			set{ _citycharfull=value;}
			get{return _citycharfull;}
		}
		/// <summary>
		/// 字母简写如（南京nj）
		/// </summary>
		public string CityCharSub
		{
			set{ _citycharsub=value;}
			get{return _citycharsub;}
		}
		/// <summary>
		/// 电话区号
		/// </summary>
		public string CityCode
		{
			set{ _citycode=value;}
			get{return _citycode;}
		}
		/// <summary>
		/// 热门城市
		/// </summary>
		public int? HotFlag
		{
			set{ _hotflag=value;}
			get{return _hotflag;}
		}
		/// <summary>
		/// 热门排序
		/// </summary>
		public decimal? HotSortID
		{
			set{ _hotsortid=value;}
			get{return _hotsortid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OpenFlag
		{
			set{ _openflag=value;}
			get{return _openflag;}
		}
		/// <summary>
		/// 分站地址
		/// </summary>
		public string WebUrl
		{
			set{ _weburl=value;}
			get{return _weburl;}
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

