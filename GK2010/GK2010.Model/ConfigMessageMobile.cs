using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类ConfigMessageMobile 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ConfigMessageMobile
	{
		public ConfigMessageMobile()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _titleen;
		private string _summary;
		private string _detail;
		private long _postdate;
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
		/// 标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 拼音
		/// </summary>
		public string TitleEn
		{
			set{ _titleen=value;}
			get{return _titleen;}
		}
		/// <summary>
		/// 摘要
		/// </summary>
		public string Summary
		{
			set{ _summary=value;}
			get{return _summary;}
		}
		/// <summary>
		/// 详细
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 提交时间
		/// </summary>
		public long PostDate
		{
			set{ _postdate=value;}
			get{return _postdate;}
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

