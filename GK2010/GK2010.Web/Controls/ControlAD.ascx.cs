using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using GK2010.Common;
using GK2010.Utility;
namespace GK2010.Web.Controls
{
    public partial class ControlAD : System.Web.UI.UserControl
    {
        #region 变量
        /// <summary>
        /// 宽
        /// </summary>
        public int Width = 100;

        /// <summary>
        /// 高
        /// </summary>
        public int Height = 100;
        /// <summary>
        /// 当前类别
        /// </summary>
        public string Category = "";

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.AD bll = new GK2010.BLL.AD();
            List<Model.AD> models = bll.GetList(Category, "FirstAD");

            StringBuilder sb = new StringBuilder();
            if (models.Count > 0)
            {
                Model.AD model = models[0];
                sb.AppendLine("<div style='margin-bottom:10px'><a href='" + model.Url + "' target='_blank'><img src='" + model.PictureNormal + "' width='" + Width + "' height='" + Height + "' border='0' /></a></div>");
                txtContent.Text = sb.ToString();
            }
        }
        #endregion
    }
}