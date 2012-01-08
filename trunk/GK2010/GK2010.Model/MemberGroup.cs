using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类MemberGroup 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class MemberGroup
	{
		public MemberGroup()
		{}
		#region Model
        private int _id = 0;
		private string _type;
		private string _title;
		private string _pictureid;
		private int _treadpost=0;
        private decimal _sortid = 0;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// default|member|system|special
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 组名称
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 图片编号
		/// </summary>
		public string PictureID
		{
			set{ _pictureid=value;}
			get{return _pictureid;}
		}
		/// <summary>
		/// 发帖数量
		/// </summary>
		public int TreadPost
		{
			set{ _treadpost=value;}
			get{return _treadpost;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public decimal SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		#endregion Model

	}
}

