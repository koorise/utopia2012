using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类Product 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Product
	{
		public Product()
		{}
		#region Model
		private int _id;
		private long _cacheid;
		private int _rootid;
		private int _categoryid;
		private string _title;
		private string _titleen;
		private string _summary;
		private string _detail;
		private string _tags;
		private int _hits;
		private string _url;
		private string _defaultbrand;
		private string _defaultperiod;
		private decimal _defaultpriceold;
		private decimal _defaultprice;
		private decimal _defaultjf;
		private int _pictureid;
		private string _picturesmall;
		private string _picturenormal;
		private string _picturebig;
		private int _indexflag;
		private decimal _indexsortid;
		private int _commendflag;
		private decimal _commendsortid;
		private int _hotflag;
		private decimal _hotsortid;
		private int _channelflag;
		private decimal _channelsortid;
		private int _categoryflag;
		private decimal _categorysortid;
		private decimal _sortid;
		private string _seotitle;
		private string _seokeywords;
		private string _seodescription;
		private int _showflag;
		private int _checkflag;
		private long _checkdate;
		private int _checkuserid;
		private long _postdate;
		private int _postuserid;
		private long _editdate;
		private int _edituserid;
		private long _deldate;
		private int _deluserid;
		private int _memberflag;
		private int _diyflag;
		private string _diytypecn;
		private string _diytypeen;
		private string _diytypepartsid;
		private string _diytypeprice;
		private string _diytypeattachmentflag;
		private string _diyexpression;
		private int _basicdiscountprice;
		private int _basicdiscountjf;
        private string _diytypeshowflag;
        private string _DefaultType = "";
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 当前快照编号(用时间来)
		/// </summary>
		public long CacheID
		{
			set{ _cacheid=value;}
			get{return _cacheid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int RootID
		{
			set{ _rootid=value;}
			get{return _rootid;}
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
		/// 产品名称
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 产品拼音
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
		public int Hits
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
		/// 品牌
		/// </summary>
		public string DefaultBrand
		{
			set{ _defaultbrand=value;}
			get{return _defaultbrand;}
		}
		/// <summary>
		/// 货期
		/// </summary>
		public string DefaultPeriod
		{
			set{ _defaultperiod=value;}
			get{return _defaultperiod;}
		}
		/// <summary>
		/// 默认原价
		/// </summary>
		public decimal DefaultPriceOld
		{
			set{ _defaultpriceold=value;}
			get{return _defaultpriceold;}
		}
        
            /// <summary>
		/// 默认型号
		/// </summary>
        public string DefaultType
		{
            set { _DefaultType = value; }
            get { return _DefaultType; }
		}
		/// <summary>
		/// 默认现价
		/// </summary>
		public decimal DefaultPrice
		{
			set{ _defaultprice=value;}
			get{return _defaultprice;}
		}
		/// <summary>
		/// 默认积分
		/// </summary>
		public decimal DefaultJF
		{
			set{ _defaultjf=value;}
			get{return _defaultjf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PictureID
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
		public int IndexFlag
		{
			set{ _indexflag=value;}
			get{return _indexflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal IndexSortID
		{
			set{ _indexsortid=value;}
			get{return _indexsortid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CommendFlag
		{
			set{ _commendflag=value;}
			get{return _commendflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal CommendSortID
		{
			set{ _commendsortid=value;}
			get{return _commendsortid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int HotFlag
		{
			set{ _hotflag=value;}
			get{return _hotflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal HotSortID
		{
			set{ _hotsortid=value;}
			get{return _hotsortid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ChannelFlag
		{
			set{ _channelflag=value;}
			get{return _channelflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ChannelSortID
		{
			set{ _channelsortid=value;}
			get{return _channelsortid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CategoryFlag
		{
			set{ _categoryflag=value;}
			get{return _categoryflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal CategorySortID
		{
			set{ _categorysortid=value;}
			get{return _categorysortid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SEOTitle
		{
			set{ _seotitle=value;}
			get{return _seotitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SEOKeywords
		{
			set{ _seokeywords=value;}
			get{return _seokeywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SEODescription
		{
			set{ _seodescription=value;}
			get{return _seodescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ShowFlag
		{
			set{ _showflag=value;}
			get{return _showflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CheckFlag
		{
			set{ _checkflag=value;}
			get{return _checkflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long CheckDate
		{
			set{ _checkdate=value;}
			get{return _checkdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CheckUserID
		{
			set{ _checkuserid=value;}
			get{return _checkuserid;}
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
		public int PostUserID
		{
			set{ _postuserid=value;}
			get{return _postuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long EditDate
		{
			set{ _editdate=value;}
			get{return _editdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int EditUserID
		{
			set{ _edituserid=value;}
			get{return _edituserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long DelDate
		{
			set{ _deldate=value;}
			get{return _deldate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DelUserID
		{
			set{ _deluserid=value;}
			get{return _deluserid;}
		}
		/// <summary>
		/// 会员可见
		/// </summary>
		public int MemberFlag
		{
			set{ _memberflag=value;}
			get{return _memberflag;}
		}
		/// <summary>
		/// 支持选型（1支持，2不支持）
		/// </summary>
		public int DiyFlag
		{
			set{ _diyflag=value;}
			get{return _diyflag;}
		}
		/// <summary>
		/// 默认选型（中文）
		/// </summary>
		public string DiyTypeCn
		{
			set{ _diytypecn=value;}
			get{return _diytypecn;}
		}
		/// <summary>
		/// 默认选型（英文）
		/// </summary>
		public string DiyTypeEn
		{
			set{ _diytypeen=value;}
			get{return _diytypeen;}
		}
		/// <summary>
		/// 默认选型（部件）
		/// </summary>
		public string DiyTypePartsID
		{
			set{ _diytypepartsid=value;}
			get{return _diytypepartsid;}
		}
		/// <summary>
		/// 默认选型（价格）
		/// </summary>
		public string DiyTypePrice
		{
			set{ _diytypeprice=value;}
			get{return _diytypeprice;}
		}
		/// <summary>
		/// 默认选型（正常型号与附件型号）
		/// </summary>
		public string DiyTypeAttachmentFlag
		{
			set{ _diytypeattachmentflag=value;}
			get{return _diytypeattachmentflag;}
		}
        /// <summary>
		/// 型号显示与隐藏
		/// </summary>
		public string DiyTypeShowFlag
		{
            set { _diytypeshowflag = value; }
            get { return _diytypeshowflag; }
		}
        
		/// <summary>
		/// 计算公式
		/// </summary>
		public string DiyExpression
		{
			set{ _diyexpression=value;}
			get{return _diyexpression;}
		}
		/// <summary>
		/// 价格折扣（百分比）
		/// </summary>
		public int BasicDiscountPrice
		{
			set{ _basicdiscountprice=value;}
			get{return _basicdiscountprice;}
		}
		/// <summary>
		/// 积分折扣（百分比）
		/// </summary>
		public int BasicDiscountJF
		{
			set{ _basicdiscountjf=value;}
			get{return _basicdiscountjf;}
		}
		#endregion Model

	}
}

