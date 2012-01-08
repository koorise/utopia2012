using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类MemberValid 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class MemberValid
	{
		public MemberValid()
		{}
		#region Model
        private int _id = 0;
        private int _validtype = 0;
		private string _validvalue;
        private int _userid = 0;
		private string _activecode;
        private long _startdate = 0;
		private long _enddate = 0;
		/// <summary>
		/// 验证
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 验证类型
		/// </summary>
		public int ValidType
		{
			set{ _validtype=value;}
			get{return _validtype;}
		}
		/// <summary>
		/// 邮箱或手机值
		/// </summary>
		public string ValidValue
		{
			set{ _validvalue=value;}
			get{return _validvalue;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 激活码
		/// </summary>
		public string ActiveCode
		{
			set{ _activecode=value;}
			get{return _activecode;}
		}
		/// <summary>
		/// 有效期开始时间
		/// </summary>
		public long StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 有效期结束时间
		/// </summary>
		public long EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		#endregion Model

	}
}

