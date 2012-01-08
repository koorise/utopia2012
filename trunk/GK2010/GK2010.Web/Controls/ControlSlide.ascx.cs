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
    public partial class ControlSlide : System.Web.UI.UserControl
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
        /// 内容列表
        /// </summary>
        public string strList = "";

        /// <summary>
        /// 当前类别
        /// </summary>
        public string Category = "";

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.Slide bllSlide = new GK2010.BLL.Slide();
            List<Model.Slide> modelsSlide = bllSlide.GetList(Category, "Top5");

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < modelsSlide.Count; i++)
            {
                int j = i + 1;
                Model.Slide model = modelsSlide[i];

                sb.AppendLine("linkarr" + Category + "[" + j + "] = \"" + model.Url + "\"");
                sb.AppendLine("picarr" + Category + "[" + j + "] = \"" + model.PictureNormal + "\";");
                sb.AppendLine("textarr" + Category + "[" + j + "] = \"" + model.Title + "\";");
            }
            strList = sb.ToString();

        }
        #endregion
       
    }
}