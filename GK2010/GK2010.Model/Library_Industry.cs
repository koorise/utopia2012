using System;
namespace GK2010.Model
{
	/// <summary>
	/// ʵ����Library_Industry ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �����Ŷ�Ӧ��ҵ
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
		/// ��ҵ���
		/// </summary>
		public int? CategoryID
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
		}
		#endregion Model

	}
}

