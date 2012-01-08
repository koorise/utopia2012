using System;
namespace GK2010.Model
{
	/// <summary>
	/// ʵ����Library_Tag ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��ǩ�⣨�������������
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string TableName
		{
			set{ _tablename=value;}
			get{return _tablename;}
		}
		/// <summary>
		/// ��ID
		/// </summary>
		public int? TableID
		{
			set{ _tableid=value;}
			get{return _tableid;}
		}
		/// <summary>
		/// ��ǩ
		/// </summary>
		public string Tag
		{
			set{ _tag=value;}
			get{return _tag;}
		}
		/// <summary>
		/// ��ǩƴ��
		/// </summary>
		public string TagEn
		{
			set{ _tagen=value;}
			get{return _tagen;}
		}
		#endregion Model

	}
}

