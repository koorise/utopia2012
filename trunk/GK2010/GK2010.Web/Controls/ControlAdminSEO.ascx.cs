using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Web.Controls
{
    public partial class ControlAdminSEO : System.Web.UI.UserControl
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string SEOTitle
        {
            get
            {
                return txtSEOTitle.Text;
            }
            set
            {
                txtSEOTitle.Text = value;
            }
        }
        /// <summary>
        /// 关键字
        /// </summary>
        public string SEOKeywords
        {
            get
            {
                return txtSEOKeywords.Text;
            }
            set
            {
                txtSEOKeywords.Text = value;
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string SEODescription
        {
            get
            {
                return txtSEODescription.Text;
            }
            set
            {
                txtSEODescription.Text = value;
            }
        }
    }
}