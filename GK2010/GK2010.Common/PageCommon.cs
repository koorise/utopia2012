using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using GK2010.Utility;
namespace GK2010.Common
{
    public class PageCommon
    {
        #region GridView相关属性设置
        public static void GridViewSetProperty(GridView grid)
        {
            GridViewProperty model = new GridViewProperty();
            GridViewSetProperty(grid, model);
        }
        public static void GridViewSetProperty(GridView grid, GridViewProperty model)
        {
            grid.AutoGenerateColumns = model.AutoGenerateColumns;
            grid.DataKeyNames = model.DataKeyNames;
            grid.PageSize = model.PageSize;
        }
        #endregion

        #region AspNetPager相关属性设置
        public static void AspNetPagerSetProperty(Wuqi.Webdiyer.AspNetPager AspNetPager1)
        {
            AspNetPagerProperty model = new AspNetPagerProperty();
            AspNetPagerSetProperty(AspNetPager1, model); 
        }

        public static void AspNetPagerSetProperty(Wuqi.Webdiyer.AspNetPager AspNetPager1, AspNetPagerProperty model)
        {
            AspNetPager1.AlwaysShow = model.AlwaysShow;
            AspNetPager1.UrlPaging = model.UrlPaging;
            AspNetPager1.ShowPageIndex = false;
        }
        #endregion        
    }

    #region GridView相关属性类
    public class GridViewProperty
    {
        public bool AutoGenerateColumns = false;
        public string[] DataKeyNames = "id".Split(' ');
        public int PageSize = 20;

        public GridViewProperty()
        {}
    }
    #endregion

    #region AspNetPager相关属性类
    public class AspNetPagerProperty
    {
        public bool AlwaysShow = true;
        public bool UrlPaging = true;

        public AspNetPagerProperty()
        {}
    }

    #endregion
    
}
