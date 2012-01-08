using System;
namespace GK2010.Model
{
	/// <summary>
    /// ʵ����SEO(���ں�̨���ã�ǰ̨�滻��Ӧ��ֵ)
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
		/// ��ϸҳ����
		/// </summary>
        public string DetailTitle
		{
            set { _DetailTitle = value; }
            get { return _DetailTitle; }
		}

        /// <summary>
        /// �б�ҳ������
        /// </summary>
        public string CategoryTitle
        {
            set { _CategoryTitle = value; }
            get { return _CategoryTitle; }
        }

        /// <summary>
        /// ��ǩ
        /// </summary>
        public string Tags
        {
            set { _Tags = value; }
            get { return _Tags; }
        }

        /// <summary>
        /// ԭʼ����
        /// </summary>
        public string SEOTitle
        {
            set { _SEOTitle = value; }
            get { return _SEOTitle; }
        }

        /// <summary>
        /// ԭʼ�ؼ���
        /// </summary>
        public string SEOKeywords
        {
            set { _SEOKeywords = value; }
            get { return _SEOKeywords; }
        }

        /// <summary>
        /// ԭʼ����
        /// </summary>
        public string SEODescription
        {
            set { _SEODescription = value; }
            get { return _SEODescription; }
        }
		#endregion Model

	}
}

