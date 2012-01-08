using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类Library_Tag 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Library_Tag
	{
		public Library_Tag()
		{}
		#region Model
		private int _id;
		private string _tablename;
		private int? _tableid;
		private string _tag;
		private string _tagen;
		/// <summary>
		/// 标签库（用于相关搜索）
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 表名
		/// </summary>
		public string TableName
		{
			set{ _tablename=value;}
			get{return _tablename;}
		}
		/// <summary>
		/// 表ID
		/// </summary>
		public int? TableID
		{
			set{ _tableid=value;}
			get{return _tableid;}
		}
		/// <summary>
		/// 标签
		/// </summary>
		public string Tag
		{
			set{ _tag=value;}
			get{return _tag;}
		}
		/// <summary>
		/// 标签拼音
		/// </summary>
		public string TagEn
		{
			set{ _tagen=value;}
			get{return _tagen;}
		}
		#endregion Model

	}
}

