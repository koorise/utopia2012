using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Controls
{
    public partial class ControlAdminParam : System.Web.UI.UserControl
    {
        #region 总首页推荐
        public int IndexFlag
        {
            get
            {
                return chkIndexFlag.Checked ? 1 : 0;
            }
            set
            {
                chkIndexFlag.Checked = (value == 1);
            }
        }
        #endregion

        #region 总首页推荐排序
        public decimal IndexSortID
        {
            get
            {
                return DecimalHelper.Parse(txtIndexSortID.Text, 2000);
            }
            set
            {
                txtIndexSortID.Text = value.ToString();
            }
        }
        #endregion

        #region 频道页首页推荐显示
        public int ChannelFlag
        {
            get
            {
                return chkChannelFlag.Checked ? 1 : 0;
            }
            set
            {
                chkChannelFlag.Checked = (value == 1);
            }
        }
        #endregion

        #region 频道页首页推荐排序
        public decimal ChannelSortID
        {
            get
            {
                return DecimalHelper.Parse(txtChannelSortID.Text, 2000);
            }
            set
            {
                txtChannelSortID.Text = value.ToString();
            }
        }
        #endregion

        #region 频道页今日推荐
        public int CommendFlag
        {
            get
            {
                return chkCommendFlag.Checked ? 1 : 0;
            }
            set
            {
                chkCommendFlag.Checked = (value == 1);
            }
        }
        #endregion

        #region 频道页今日推荐排序
        public decimal CommendSortID
        {
            get
            {
                return DecimalHelper.Parse(txtCommendSortID.Text, 2000);
            }
            set
            {
                txtCommendSortID.Text = value.ToString();
            }
        }
        #endregion

        #region 频道页热门推荐显示
        public int HotFlag
        {
            get
            {
                return chkHotFlag.Checked ? 1 : 0;
            }
            set
            {
                chkHotFlag.Checked = (value == 1);
            }
        }
        #endregion

        #region 频道页热门推荐排序
        public decimal HotSortID
        {
            get
            {
                return DecimalHelper.Parse(txtHotSortID.Text, 2000);
            }
            set
            {
                txtHotSortID.Text = value.ToString();
            }
        }
        #endregion

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        #endregion
       
    }
}