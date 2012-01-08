using System;
namespace GK2010.Model
{
	/// <summary>
	/// ʵ����ConfigProvince ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ConfigProvince
	{
		public ConfigProvince()
		{}
		#region Model
		private int _id;
		private string _provinceid;
		private string _provincename;
		private string _provinceen;
		private decimal? _sortid;
		/// <summary>
		/// ���
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ʡ�ݱ��
		/// </summary>
		public string ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// ʡ������
		/// </summary>
		public string ProvinceName
		{
			set{ _provincename=value;}
			get{return _provincename;}
		}
		/// <summary>
		/// ʡ��ƴ��
		/// </summary>
		public string ProvinceEn
		{
			set{ _provinceen=value;}
			get{return _provinceen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		#endregion Model

	}
}

