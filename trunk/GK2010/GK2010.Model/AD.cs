using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类AD 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class AD
	{
		public AD()
		{}
		#region Model
        private int _id = 0;
        private int _categoryid = 0;
        private string _title = "";
        private string _titleen = "";
        private string _author = "";
        private string _source = "";
        private string _summary = "";
        private string _detail = "";
        private string _tags = "";
        private int _hits = 0;
        private string _path = "";
        private string _url = "";
        private int _pictureid = 0;
        private string _picturesmall = "";
        private string _picturenormal = "";
        private string _picturebig = "";
        private int _indexflag = 0;
        private decimal _indexsortid = 0;
        private int _commendflag = 0;
        private decimal _commendsortid = 0;
        private int _hotflag = 0;
        private decimal _hotsortid = 0;
        private int _channelflag = 0;
        private decimal _channelsortid = 0;
        private int _categoryflag = 0;
        private decimal _categorysortid = 0;
        private decimal _sortid = 0;
        private string _seotitle = "";
        private string _seokeywords = "";
        private string _seodescription = "";
        private int _showflag = 0;
        private int _checkflag = 0;
        private long _checkdate = 0;
        private int _checkuserid = 0;
        private long _postdate = 0;
        private int _postuserid = 0;
        private long _editdate = 0;
        private int _edituserid = 0;
        private long _deldate = 0;
        private int _deluserid = 0;
        private int _memberflag = 0;
		/// <summary>
		/// 技术支持
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
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
		public string Author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Source
		{
			set{ _source=value;}
			get{return _source;}
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
		public string Path
		{
			set{ _path=value;}
			get{return _path;}
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
		/// 
		/// </summary>
		public int MemberFlag
		{
			set{ _memberflag=value;}
			get{return _memberflag;}
		}
		#endregion Model

	}
}

