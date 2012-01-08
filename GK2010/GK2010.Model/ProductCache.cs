using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类ProductCache 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ProductCache
	{
		public ProductCache()
		{}
		#region Model
		private int _id;
		private long _cacheid;
		private int? _oldid;
		private int? _categoryid;
		private string _title;
		private string _titleen;
		private string _summary;
		private string _detail;
		private string _tags;
		private int? _hits;
		private string _url;
		private string _defaultbrand;
		private string _defaultperiod;
		private decimal? _defaultpriceold;
		private decimal? _defaultprice;
		private decimal? _defaultjf;
		private int? _pictureid;
		private string _picturesmall;
		private string _picturenormal;
		private string _picturebig;
		private decimal? _sortid;
		private int? _showflag;
		private long _postdate;
		private int? _postuserid;
		private int? _memberflag;
		private int? _diyflag;
		private string _diytypecn;
		private string _diytypeen;
		private string _diytypepartsid;
		private string _diytypeprice;
		private string _diytypeattachmentflag;
		private string _diyexpression;
		private int? _basicdiscountprice;
		private int? _basicdiscountjf;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 快照编号
		/// </summary>
		public long CacheID
		{
			set{ _cacheid=value;}
			get{return _cacheid;}
		}
		/// <summary>
		/// 原始产品编号
		/// </summary>
		public int? OldID
		{
			set{ _oldid=value;}
			get{return _oldid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CategoryID
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
		public string Summary
		{
			set{ _summary=value;}
			get{return _summary;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tags
		{
			set{ _tags=value;}
			get{return _tags;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Hits
		{
			set{ _hits=value;}
			get{return _hits;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DefaultBrand
		{
			set{ _defaultbrand=value;}
			get{return _defaultbrand;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DefaultPeriod
		{
			set{ _defaultperiod=value;}
			get{return _defaultperiod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DefaultPriceOld
		{
			set{ _defaultpriceold=value;}
			get{return _defaultpriceold;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DefaultPrice
		{
			set{ _defaultprice=value;}
			get{return _defaultprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DefaultJF
		{
			set{ _defaultjf=value;}
			get{return _defaultjf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PictureID
		{
			set{ _pictureid=value;}
			get{return _pictureid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PictureSmall
		{
			set{ _picturesmall=value;}
			get{return _picturesmall;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PictureNormal
		{
			set{ _picturenormal=value;}
			get{return _picturenormal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PictureBig
		{
			set{ _picturebig=value;}
			get{return _picturebig;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ShowFlag
		{
			set{ _showflag=value;}
			get{return _showflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long PostDate
		{
			set{ _postdate=value;}
			get{return _postdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PostUserID
		{
			set{ _postuserid=value;}
			get{return _postuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MemberFlag
		{
			set{ _memberflag=value;}
			get{return _memberflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DiyFlag
		{
			set{ _diyflag=value;}
			get{return _diyflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DiyTypeCn
		{
			set{ _diytypecn=value;}
			get{return _diytypecn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DiyTypeEn
		{
			set{ _diytypeen=value;}
			get{return _diytypeen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DiyTypePartsID
		{
			set{ _diytypepartsid=value;}
			get{return _diytypepartsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DiyTypePrice
		{
			set{ _diytypeprice=value;}
			get{return _diytypeprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DiyTypeAttachmentFlag
		{
			set{ _diytypeattachmentflag=value;}
			get{return _diytypeattachmentflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DiyExpression
		{
			set{ _diyexpression=value;}
			get{return _diyexpression;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BasicDiscountPrice
		{
			set{ _basicdiscountprice=value;}
			get{return _basicdiscountprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BasicDiscountJF
		{
			set{ _basicdiscountjf=value;}
			get{return _basicdiscountjf;}
		}
		#endregion Model

	}
}

