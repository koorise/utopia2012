using System;
namespace GK2010.Model
{
	/// <summary>
	/// ʵ����Library_Medium ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Library_Medium
	{
		public Library_Medium()
		{}
		#region Model
		private int _id;
		private string _tablename;
		private int? _tableid;
		private int? _categoryid;
		/// <summary>
		/// ��Ŷ�Ӧ����
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
		/// ���ʱ��
		/// </summary>
		public int? CategoryID
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
		}
		#endregion Model

	}
}

