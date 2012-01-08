using System;
namespace GK2010.Model
{
	/// <summary>
    /// 实体类SEO(用于后台设置，前台替换对应的值)
	/// </summary>
	[Serializable]
    public class SEO
	{
		public SEO()
		{}
		#region Model

        private string _DetailTitle = "";
        private string _CategoryTitle = "";
        private string _Tags = "";

        private string _SEOTitle = "";
        private string _SEOKeywords = "";
        private string _SEODescription = "";
        
		/// <summary>
		/// 详细页标题
		/// </summary>
        public string DetailTitle
		{
            set { _DetailTitle = value; }
            get { return _DetailTitle; }
		}

        /// <summary>
        /// 列表页类别标题
        /// </summary>
        public string CategoryTitle
        {
            set { _CategoryTitle = value; }
            get { return _CategoryTitle; }
        }

        /// <summary>
        /// 标签
        /// </summary>
        public string Tags
        {
            set { _Tags = value; }
            get { return _Tags; }
        }

        /// <summary>
        /// 原始标题
        /// </summary>
        public string SEOTitle
        {
            set { _SEOTitle = value; }
            get { return _SEOTitle; }
        }

        /// <summary>
        /// 原始关键字
        /// </summary>
        public string SEOKeywords
        {
            set { _SEOKeywords = value; }
            get { return _SEOKeywords; }
        }

        /// <summary>
        /// 原始描述
        /// </summary>
        public string SEODescription
        {
            set { _SEODescription = value; }
            get { return _SEODescription; }
        }
		#endregion Model

	}
}

