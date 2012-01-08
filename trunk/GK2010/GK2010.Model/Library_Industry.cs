using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类Library_Industry 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Library_Industry
	{
		public Library_Industry()
		{}
		#region Model
		private int _id;
		private string _tablename;
		private int? _tableid;
		private int? _categoryid;
		/// <summary>
		/// 各表编号对应行业
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TableName
		{
			set{ _tablename=value;}
			get{return _tablename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TableID
		{
			set{ _tableid=value;}
			get{return _tableid;}
		}
		/// <summary>
		/// 行业编号
		/// </summary>
		public int? CategoryID
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
		}
		#endregion Model

	}
}

