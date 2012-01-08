using System;
namespace GK2010.Model
{
	/// <summary>
	/// ʵ����SystemTree_Group ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class SystemTree_Group
	{
		public SystemTree_Group()
		{}
		#region Model
		private int _id;
		private int? _groupid;
		private int? _treeid;
		/// <summary>
		/// ��ɫȨ����
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public int? GroupID
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public int? TreeID
		{
			set{ _treeid=value;}
			get{return _treeid;}
		}
		#endregion Model

	}
}

