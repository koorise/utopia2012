using System;
namespace GK2010.Model
{
	/// <summary>
	/// ʵ����MemberValid ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class MemberValid
	{
		public MemberValid()
		{}
		#region Model
        private int _id = 0;
        private int _validtype = 0;
		private string _validvalue;
        private int _userid = 0;
		private string _activecode;
        private long _startdate = 0;
		private long _enddate = 0;
		/// <summary>
		/// ��֤
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ��֤����
		/// </summary>
		public int ValidType
		{
			set{ _validtype=value;}
			get{return _validtype;}
		}
		/// <summary>
		/// ������ֻ�ֵ
		/// </summary>
		public string ValidValue
		{
			set{ _validvalue=value;}
			get{return _validvalue;}
		}
		/// <summary>
		/// �û���
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public string ActiveCode
		{
			set{ _activecode=value;}
			get{return _activecode;}
		}
		/// <summary>
		/// ��Ч�ڿ�ʼʱ��
		/// </summary>
		public long StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// ��Ч�ڽ���ʱ��
		/// </summary>
		public long EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		#endregion Model

	}
}

