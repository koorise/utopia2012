using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类MemberRelation 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class MemberRelation
	{
		public MemberRelation()
		{}
		#region Model
		private int _id;
		private int? _adminid;
		private int? _userid;
		/// <summary>
		/// 业务员与会员关系
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AdminID
		{
			set{ _adminid=value;}
			get{return _adminid;}
		}
		/// <summary>
		/// 业务员与会员关系
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

