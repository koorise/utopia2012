using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Controls
{
    public partial class ControlAdminUpload : System.Web.UI.UserControl
    {
        #region 图片
        /// <summary>
        /// 图片
        /// </summary>
        public string Picture = "";       
        #endregion

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 绑定已选
                if (Picture != "")
                {
                    txtPicture.Text = "<br><img src='" + Picture + "' width='50' height='50'>";
                }
                #endregion
            }
        }
        #endregion

        #region 保存
        public Model.File Save()
        {
            FileHelper _FileHelper = new FileHelper(FileUpload1.PostedFile);
            Model.File modelFile = new GK2010.Model.File();
            modelFile = _FileHelper.Save();
            return modelFile;
        }
        #endregion
    }
}