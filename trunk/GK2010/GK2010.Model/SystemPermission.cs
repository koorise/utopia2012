using System;
namespace GK2010.Model
{
	/// <summary>
	/// ʵ����SystemPermission ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class SystemPermission
	{
		public SystemPermission()
		{}
		#region Model
		private int _id;
		private int? _groupid;
		private string _permission;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �û����
		/// </summary>
		public int? GroupID
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// Ȩ�ޱ��
		/// </summary>
		public string Permission
		{
			set{ _permission=value;}
			get{return _permission;}
		}
		#endregion Model

	}
}

