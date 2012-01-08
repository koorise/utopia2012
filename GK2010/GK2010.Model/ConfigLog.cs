using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类ConfigLog 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ConfigLog
	{
		public ConfigLog()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _detail;
		private long _postdate;
		private int _userid;
		private int? _isread;
		private int? _issolve;
		private string _solvedetail;
		private long _solvedate;
		private int _solveuserid;
		/// <summary>
		/// 日志记录
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
		/// 发现人
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 阅读标志
		/// </summary>
		public int? IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		/// <summary>
		/// 是否解决
		/// </summary>
		public int? IsSolve
		{
			set{ _issolve=value;}
			get{return _issolve;}
		}
		/// <summary>
		/// 解决办法
		/// </summary>
		public string SolveDetail
		{
			set{ _solvedetail=value;}
			get{return _solvedetail;}
		}
		/// <summary>
		/// 解决时间
		/// </summary>
		public long SolveDate
		{
			set{ _solvedate=value;}
			get{return _solvedate;}
		}
		/// <summary>
		/// 解决人
		/// </summary>
		public int SolveUserID
		{
			set{ _solveuserid=value;}
			get{return _solveuserid;}
		}
		#endregion Model

	}
}

