using System;
namespace GK2010.Model
{
	/// <summary>
	/// ʵ����MemberGroup ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ������
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ͼƬ���
		/// </summary>
		public string PictureID
		{
			set{ _pictureid=value;}
			get{return _pictureid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public int TreadPost
		{
			set{ _treadpost=value;}
			get{return _treadpost;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public decimal SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		#endregion Model

	}
}

