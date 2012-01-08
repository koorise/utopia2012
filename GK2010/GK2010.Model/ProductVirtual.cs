using System;
namespace GK2010.Model
{
	/// <summary>
	/// ʵ����ProductVirtual ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ProductVirtual
	{
		public ProductVirtual()
		{}
		#region Model
		private int _id;
		private int? _productcategoryid;
		private int? _productid;
		private int? _virtualcategoryid;
		private int? _virtualid;
		/// <summary>
		/// ��Ʒ����ֵ
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ��Ʒһ�����
		/// </summary>
		public int? ProductCategoryID
		{
			set{ _productcategoryid=value;}
			get{return _productcategoryid;}
		}
		/// <summary>
		/// ��Ʒ���
		/// </summary>
		public int? ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public int? VirtualCategoryID
		{
			set{ _virtualcategoryid=value;}
			get{return _virtualcategoryid;}
		}
		/// <summary>
		/// �������ֵ
		/// </summary>
		public int? VirtualID
		{
			set{ _virtualid=value;}
			get{return _virtualid;}
		}
		#endregion Model

	}
}

