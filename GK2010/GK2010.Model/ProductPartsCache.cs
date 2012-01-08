using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类ProductPartsCache 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ProductPartsCache
	{
		public ProductPartsCache()
		{}
		#region Model
		private int _id;
		private long _cacheid;
		private int? _oldid;
		private long _productcatchid;
		private int? _rootid;
		private int? _categoryid;
		private string _categorypath;
		private string _title;
		private string _titleen;
		private string _summary;
		private string _detail;
		private int? _pictureid;
		private string _picturesmall;
		private string _picturenormal;
		private string _picturebig;
		private decimal? _sortid;
		private long _postdate;
		private int? _postuserid;
		private int? _showflag;
		private int? _defaultflag;
		private int? _attachmentflag;
		private int? _flag;
		/// <summary>
		/// 部件快照
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
		/// 原始部件编号
		/// </summary>
		public int? OldID
		{
			set{ _oldid=value;}
			get{return _oldid;}
		}
		/// <summary>
		/// 产品快照编号
		/// </summary>
		public long ProductCatchID
		{
			set{ _productcatchid=value;}
			get{return _productcatchid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RootID
		{
			set{ _rootid=value;}
			get{return _rootid;}
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
		public string CategoryPath
		{
			set{ _categorypath=value;}
			get{return _categorypath;}
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
		public int? ShowFlag
		{
			set{ _showflag=value;}
			get{return _showflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DefaultFlag
		{
			set{ _defaultflag=value;}
			get{return _defaultflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AttachmentFlag
		{
			set{ _attachmentflag=value;}
			get{return _attachmentflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		#endregion Model

	}
}

