using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Controls
{
    public partial class ControlAdminParamSearch : System.Web.UI.UserControl
    {
        #region 总首页推荐
        public int IndexFlag
        {
            get
            {
                return IntHelper.Parse(dropIndexFlag.SelectedValue, -1); 
            }
            set
            {
                dropIndexFlag.SelectedValue = value.ToString();
            }
        }
        #endregion


        #region 频道页首页推荐显示
        public int ChannelFlag
        {
            get
            {
                return  IntHelper.Parse( dropChannelFlag.SelectedValue,-1);
            }
            set
            {
                dropChannelFlag.SelectedValue = value.ToString();
            }
        }
        #endregion


        #region 频道页今日推荐
        public int CommendFlag
        {
            get
            {
                return IntHelper.Parse(dropCommendFlag.SelectedValue, -1);
            }
            set
            {
                dropCommendFlag.SelectedValue = value.ToString();
            }
        }
        #endregion


        #region 频道页热门推荐显示
        public int HotFlag
        {
            get
            {
                return IntHelper.Parse(dropHotFlag.SelectedValue, -1);  
            }
            set
            {
                dropHotFlag.SelectedValue = value.ToString();
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