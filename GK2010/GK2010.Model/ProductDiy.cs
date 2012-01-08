using System;
using GK2010.Utility;
namespace GK2010.Model
{
	/// <summary>
	/// 实体类ProductDiy 。(属性说明自动提取数据库字段的描述信息)
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
        /// 中文
        /// </summary>
        public string DiyTypeCn
		{
            set { _DiyTypeCn = value; }
            get { return _DiyTypeCn; }
		}
        /// <summary>
        /// 部件编码
        /// </summary>
        public string DiyTypeEn
        {
            set { _DiyTypeEn = value; }
            get { return _DiyTypeEn; }
        }
        /// <summary>
        /// 部件编号
        /// </summary>
        public string DiyTypePartsID
        {
            set { _DiyTypePartsID = value; }
            get { return _DiyTypePartsID; }
        }
        /// <summary>
        /// 部件价格
        /// </summary>
        public string DiyTypePrice
        {
            set { _DiyTypePrice = value; }
            get { return _DiyTypePrice; }
        }
        /// <summary>
        /// 部件（基础|附件）
        /// </summary>
        public string DiyTypeAttachmentFlag
        {
            set { _DiyTypeAttachmentFlag = value; }
            get { return _DiyTypeAttachmentFlag; }
        }
        /// <summary>
        /// 显示或隐藏
        /// </summary>
        public string DiyTypeShowFlag
        {
            set { _DiyTypeShowFlag = value; }
            get { return _DiyTypeShowFlag; }
        }
        /// <summary>
        /// 公式
        /// </summary>
        public string DiyExpression
        {
            set { _DiyExpression = value; }
            get { return _DiyExpression; }
        }
         /// <summary>
        /// 价格
        /// </summary>
        public decimal Price
        {
            set { _Price = value; }
            get { return _Price; }
        }
        /// <summary>
        /// 型号
        /// </summary>
        public string Type
        {
            set { _Type = value; }
            get { return _Type; }
        }
		#endregion Model

	}
}

