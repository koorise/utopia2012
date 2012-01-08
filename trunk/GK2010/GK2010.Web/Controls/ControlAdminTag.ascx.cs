using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Controls
{
    public partial class ControlAdminTag : System.Web.UI.UserControl
    {
        #region 表名
        public TableName TableName;
        #endregion

        #region 表中编号
        public int TableID = 0;
        #endregion

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        #endregion

        #region 绑定数据
        private void BindData()
        {
           BLL.Library_Tag bll = new BLL.Library_Tag();
           txtTags.Text = bll.GetTitle(TableName, TableID);
        }
        #endregion

        #region 保存
        public bool Save(TableName TableName, int TableID)
        {
            string strSelect = txtTags.Text;
            strSelect = strSelect.Replace("，", ",");
            strSelect = StringHelper.DelLastChar(strSelect);
            BLL.Library_Tag bll = new BLL.Library_Tag();
            bool ret = bll.AddBatch(TableName, TableID, strSelect);
            return ret;
        }
        #endregion
    }
}