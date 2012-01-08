using System;
namespace GK2010.Model
{
	/// <summary>
	/// ʵ����Member ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Member
	{
		public Member()
		{}
		#region Model
		private int _id;
		private int? _groupid;
		private string _username;
		private string _userpwd;
		private string _provinceid;
		private string _cityid;
		private string _areaid;
		private string _company;
		private string _realname;
		private string _email;
		private string _telephone;
		private string _mobile;
		private string _address;
		private string _postcode;
		private long _registerdate;
		private string _registerip;
		private string _lastip;
		private long _lastdate;
		private int? _mobileflag;
		private int? _emailflag;
		private int? _vipflag;
		private int? _adminflag;
		private int? _lockflag;
		private int? _totalorder;
		private decimal? _totaljf;
		/// <summary>
		/// ��Ա���
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// Ȩ��������
		/// </summary>
		public int? GroupID
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// �û���
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// �û�����
		/// </summary>
		public string UserPwd
		{
			set{ _userpwd=value;}
			get{return _userpwd;}
		}
		/// <summary>
		/// ʡ��
		/// </summary>
		public string ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// ��˾����
		/// </summary>
		public string Company
		{
			set{ _company=value;}
			get{return _company;}
		}
		/// <summary>
		/// ��ʵ����
		/// </summary>
		public string RealName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// �����ʼ�
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// �绰
		/// </summary>
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// �ֻ�����
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// ��ַ
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// �ʱ�
		/// </summary>
		public string PostCode
		{
			set{ _postcode=value;}
			get{return _postcode;}
		}
		/// <summary>
		/// ��¼ʱ��
		/// </summary>
		public long RegisterDate
		{
			set{ _registerdate=value;}
			get{return _registerdate;}
		}
		/// <summary>
		/// ע��IP
		/// </summary>
		public string RegisterIP
		{
			set{ _registerip=value;}
			get{return _registerip;}
		}
		/// <summary>
		/// �����¼IP
		/// </summary>
		public string LastIP
		{
			set{ _lastip=value;}
			get{return _lastip;}
		}
		/// <summary>
		/// �����¼ʱ��
		/// </summary>
		public long LastDate
		{
			set{ _lastdate=value;}
			get{return _lastdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MobileFlag
		{
			set{ _mobileflag=value;}
			get{return _mobileflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmailFlag
		{
			set{ _emailflag=value;}
			get{return _emailflag;}
		}
		/// <summary>
		/// VIP��־
		/// </summary>
		public int? VIPFlag
		{
			set{ _vipflag=value;}
			get{return _vipflag;}
		}
		/// <summary>
		/// ����Ա��־
		/// </summary>
		public int? AdminFlag
		{
			set{ _adminflag=value;}
			get{return _adminflag;}
		}
		/// <summary>
		/// ������־
		/// </summary>
		public int? LockFlag
		{
			set{ _lockflag=value;}
			get{return _lockflag;}
		}
		/// <summary>
		/// �ܶ�������
		/// </summary>
		public int? TotalOrder
		{
			set{ _totalorder=value;}
			get{return _totalorder;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public decimal? TotalJF
		{
			set{ _totaljf=value;}
			get{return _totaljf;}
		}
		#endregion Model

	}
}

