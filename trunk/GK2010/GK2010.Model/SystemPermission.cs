using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类SystemPermission 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SystemPermission
	{
		public SystemPermission()
		{}
		#region Model
		private int _id;
		private int? _groupid;
		private string _permission;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户编号
		/// </summary>
		public int? GroupID
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 权限编号
		/// </summary>
		public string Permission
		{
			set{ _permission=value;}
			get{return _permission;}
		}
		#endregion Model

	}
}

