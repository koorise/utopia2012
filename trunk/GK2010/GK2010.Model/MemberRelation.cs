using System;
namespace GK2010.Model
{
	/// <summary>
	/// ʵ����MemberRelation ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class MemberRelation
	{
		public MemberRelation()
		{}
		#region Model
		private int _id;
		private int? _adminid;
		private int? _userid;
		/// <summary>
		/// ҵ��Ա���Ա��ϵ
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AdminID
		{
			set{ _adminid=value;}
			get{return _adminid;}
		}
		/// <summary>
		/// ҵ��Ա���Ա��ϵ
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

