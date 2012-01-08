using System;
using GK2010.Utility;
namespace GK2010.Model
{
	/// <summary>
	/// ʵ����ProductDiy ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ProductDiy
	{
        public ProductDiy()
		{}
		#region Model

        private string _DiyTypeCn = "";
        private string _DiyTypeEn = "";
        private string _DiyTypePartsID = "";
        private string _DiyTypePrice = "";
        private string _DiyTypeAttachmentFlag = "";
        private string _DiyTypeShowFlag = "";
        private string _DiyExpression = "";
        private decimal _Price = 0;
        private string _Type = "";
       
        /// <summary>
        /// ����
        /// </summary>
        public string DiyTypeCn
		{
            set { _DiyTypeCn = value; }
            get { return _DiyTypeCn; }
		}
        /// <summary>
        /// ��������
        /// </summary>
        public string DiyTypeEn
        {
            set { _DiyTypeEn = value; }
            get { return _DiyTypeEn; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string DiyTypePartsID
        {
            set { _DiyTypePartsID = value; }
            get { return _DiyTypePartsID; }
        }
        /// <summary>
        /// �����۸�
        /// </summary>
        public string DiyTypePrice
        {
            set { _DiyTypePrice = value; }
            get { return _DiyTypePrice; }
        }
        /// <summary>
        /// ����������|������
        /// </summary>
        public string DiyTypeAttachmentFlag
        {
            set { _DiyTypeAttachmentFlag = value; }
            get { return _DiyTypeAttachmentFlag; }
        }
        /// <summary>
        /// ��ʾ������
        /// </summary>
        public string DiyTypeShowFlag
        {
            set { _DiyTypeShowFlag = value; }
            get { return _DiyTypeShowFlag; }
        }
        /// <summary>
        /// ��ʽ
        /// </summary>
        public string DiyExpression
        {
            set { _DiyExpression = value; }
            get { return _DiyExpression; }
        }
         /// <summary>
        /// �۸�
        /// </summary>
        public decimal Price
        {
            set { _Price = value; }
            get { return _Price; }
        }
        /// <summary>
        /// �ͺ�
        /// </summary>
        public string Type
        {
            set { _Type = value; }
            get { return _Type; }
        }
		#endregion Model

	}
}

