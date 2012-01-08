using System;
namespace GK2010.Model
{
	/// <summary>
	/// ʵ����ProductParts ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ProductParts
	{
		public ProductParts()
		{}
		#region Model
        private int _id = 0;
        private long _cacheid = 0;
        private int _productid = 0;
        private int _rootid = 0;
        private int _parentid = 0;
        private int _haschild = 0;
        private string _path = "";
        private string _title = "";
        private string _titleen = "";
		private decimal _price = 0;
        private string _summary = "";
        private string _detail = "";
        private string _url = "";
        private int _pictureid = 0;
        private string _picturesmall = "";
        private string _picturenormal = "";
        private string _picturebig = "";
        private decimal _sortid = 0;
        private long _postdate = 0;
        private int _postuserid = 0;
        private long _editdate = 0;
        private int _edituserid = 0;
        private long _deldate = 0;
        private int _deluserid = 0;
        private int _showflag = 0;
        private int _defaultflag = 0;
        private int _attachmentflag = 0;
		private int _flag = 0;
        private int _hasparts;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ��ǰ����
		/// </summary>
		public long CacheID
		{
			set{ _cacheid=value;}
			get{return _cacheid;}
		}
		/// <summary>
		/// ��Ʒ���
		/// </summary>
		public int ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// ����𣨲����������𣬳�0֮��ģ�
		/// </summary>
		public int RootID
		{
			set{ _rootid=value;}
			get{return _rootid;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public int ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// ���������
		/// </summary>
		public int HasChild
		{
			set{ _haschild=value;}
			get{return _haschild;}
		}
        /// <summary>
        /// ���в��� 
        /// </summary>
        public int HasParts
        {
            set { _hasparts = value; }
            get { return _hasparts; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string Path
		{
			set{ _path=value;}
			get{return _path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TitleEn
		{
			set{ _titleen=value;}
			get{return _titleen;}
		}
		/// <summary>
		/// �۸�
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Summary
		{
			set{ _summary=value;}
			get{return _summary;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PictureID
		{
			set{ _pictureid=value;}
			get{return _pictureid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PictureSmall
		{
			set{ _picturesmall=value;}
			get{return _picturesmall;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PictureNormal
		{
			set{ _picturenormal=value;}
			get{return _picturenormal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PictureBig
		{
			set{ _picturebig=value;}
			get{return _picturebig;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long PostDate
		{
			set{ _postdate=value;}
			get{return _postdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PostUserID
		{
			set{ _postuserid=value;}
			get{return _postuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long EditDate
		{
			set{ _editdate=value;}
			get{return _editdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int EditUserID
		{
			set{ _edituserid=value;}
			get{return _edituserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long DelDate
		{
			set{ _deldate=value;}
			get{return _deldate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DelUserID
		{
			set{ _deluserid=value;}
			get{return _deluserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ShowFlag
		{
			set{ _showflag=value;}
			get{return _showflag;}
		}
		/// <summary>
		/// Ĭ�ϱ�־��ֻ�Բ�����Ч��
		/// </summary>
		public int DefaultFlag
		{
			set{ _defaultflag=value;}
			get{return _defaultflag;}
		}
		/// <summary>
		/// ������־��1�Ǹ�����2���Ǹ�����
		/// </summary>
		public int AttachmentFlag
		{
			set{ _attachmentflag=value;}
			get{return _attachmentflag;}
		}
		/// <summary>
		/// ���Ϊ1,����Ϊ2
		/// </summary>
		public int Flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		#endregion Model

	}
}

