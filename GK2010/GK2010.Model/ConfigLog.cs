using System;
namespace GK2010.Model
{
	/// <summary>
	/// ʵ����ConfigLog ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ConfigLog
	{
		public ConfigLog()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _detail;
		private long _postdate;
		private int _userid;
		private int? _isread;
		private int? _issolve;
		private string _solvedetail;
		private long _solvedate;
		private int _solveuserid;
		/// <summary>
		/// ��־��¼
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ��ϸ
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// �ύʱ��
		/// </summary>
		public long PostDate
		{
			set{ _postdate=value;}
			get{return _postdate;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// �Ķ���־
		/// </summary>
		public int? IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		/// <summary>
		/// �Ƿ���
		/// </summary>
		public int? IsSolve
		{
			set{ _issolve=value;}
			get{return _issolve;}
		}
		/// <summary>
		/// ����취
		/// </summary>
		public string SolveDetail
		{
			set{ _solvedetail=value;}
			get{return _solvedetail;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public long SolveDate
		{
			set{ _solvedate=value;}
			get{return _solvedate;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public int SolveUserID
		{
			set{ _solveuserid=value;}
			get{return _solveuserid;}
		}
		#endregion Model

	}
}

