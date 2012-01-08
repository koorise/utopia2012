using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类SystemTree_Group 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SystemTree_Group
	{
		public SystemTree_Group()
		{}
		#region Model
		private int _id;
		private int? _groupid;
		private int? _treeid;
		/// <summary>
		/// 角色权限树
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 组编号
		/// </summary>
		public int? GroupID
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 树编号
		/// </summary>
		public int? TreeID
		{
			set{ _treeid=value;}
			get{return _treeid;}
		}
		#endregion Model

	}
}

