using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Controls
{
    public partial class ControlProductRelation : System.Web.UI.UserControl
    {
        #region 变量
        /// <summary>
        /// 数量
        /// </summary>
        public int Num = 4;
        /// <summary>
        /// 相关表
        /// </summary>
        public TableName TableName;
        /// <summary>
        /// 相关表ID
        /// </summary>
        public int TableID;
        #endregion        

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion
        
    }
}