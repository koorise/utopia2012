using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类ProductPicture 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ProductPicture
	{
		public ProductPicture()
		{}
		#region Model
		private int _id;
		private int? _productid;
		private string _title;
		private string _summary;
		private string _detail;
		private int? _fileid;
		private decimal? _sortid;
		private int? _defaultflag;
		private string _picturesmall;
		private string _picturebig;
		private string _picturenormal;
		/// <summary>
		/// 产品图片
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
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
		/// 图片编号
		/// </summary>
		public int? FileID
		{
			set{ _fileid=value;}
			get{return _fileid;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public decimal? SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 默认封面
		/// </summary>
		public int? DefaultFlag
		{
			set{ _defaultflag=value;}
			get{return _defaultflag;}
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
		public string PictureBig
		{
			set{ _picturebig=value;}
			get{return _picturebig;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PictureNormal
		{
			set{ _picturenormal=value;}
			get{return _picturenormal;}
		}
		#endregion Model

	}
}

