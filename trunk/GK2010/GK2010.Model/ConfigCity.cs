using System;
namespace GK2010.Model
{
	/// <summary>
	/// ʵ����ConfigCity ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ConfigCity
	{
		public ConfigCity()
		{}
		#region Model
		private int _id;
		private string _provinceid;
		private string _cityid;
		private string _cityname;
		private string _cityen;
		private string _citycharfull;
		private string _citycharsub;
		private string _citycode;
		private int? _hotflag;
		private decimal? _hotsortid;
		private int? _openflag;
		private string _weburl;
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
		/// ���б��
		/// </summary>
		public string CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string CityName
		{
			set{ _cityname=value;}
			get{return _cityname;}
		}
		/// <summary>
		/// ����ƴ��
		/// </summary>
		public string CityEn
		{
			set{ _cityen=value;}
			get{return _cityen;}
		}
		/// <summary>
		/// ��ĸȫд�磨�Ͼ�nanjing��
		/// </summary>
		public string CityCharFull
		{
			set{ _citycharfull=value;}
			get{return _citycharfull;}
		}
		/// <summary>
		/// ��ĸ��д�磨�Ͼ�nj��
		/// </summary>
		public string CityCharSub
		{
			set{ _citycharsub=value;}
			get{return _citycharsub;}
		}
		/// <summary>
		/// �绰����
		/// </summary>
		public string CityCode
		{
			set{ _citycode=value;}
			get{return _citycode;}
		}
		/// <summary>
		/// ���ų���
		/// </summary>
		public int? HotFlag
		{
			set{ _hotflag=value;}
			get{return _hotflag;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public decimal? HotSortID
		{
			set{ _hotsortid=value;}
			get{return _hotsortid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OpenFlag
		{
			set{ _openflag=value;}
			get{return _openflag;}
		}
		/// <summary>
		/// ��վ��ַ
		/// </summary>
		public string WebUrl
		{
			set{ _weburl=value;}
			get{return _weburl;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public decimal? SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		#endregion Model

	}
}

