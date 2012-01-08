using System;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类ConfigIP 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ConfigIP
	{
		public ConfigIP()
		{}
		#region Model
		private int _id;
		private decimal? _ip_dec1;
		private decimal? _ip_dec2;
		private string _ip_varchar1;
		private string _ip_varchar2;
		private string _country;
		private string _province;
		private string _city;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IP_Dec1
		{
			set{ _ip_dec1=value;}
			get{return _ip_dec1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IP_Dec2
		{
			set{ _ip_dec2=value;}
			get{return _ip_dec2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IP_Varchar1
		{
			set{ _ip_varchar1=value;}
			get{return _ip_varchar1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IP_Varchar2
		{
			set{ _ip_varchar2=value;}
			get{return _ip_varchar2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Province
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string City
		{
			set{ _city=value;}
			get{return _city;}
		}
		#endregion Model

	}
}

