using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;

namespace GK2010.Web.Product
{
    public partial class MemberProductFavorites_handle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 添加到收藏夹里
            if (Utility.ConfigParam.Action == "add")
            {
                string ret = Add(Utility.ConfigParam.ProductID,Utility.ConfigParam.CategoryID,Utility.ConfigParam.Title);
                Response.Write(ret);
                Response.End();
            }
            #endregion
        }

        #region 添加
        protected string Add(int ProductID,int CategoryID, string ProductTitle)
        {
            if (Common.LoginHelper.UserID <= 0)
            {
                return "失败|请先登录";
            }

            Model.MemberProductFavorite model = new Model.MemberProductFavorite();
            model.Id = 0;
            model.MemberID = Common.LoginHelper.UserID;
            model.BigCategoryID = CategoryID;
            model.ProductID = ProductID;
            model.ProductTitle = ProductTitle;
            model.Addtime = DateTime.Now;
            model.IP = Utility.ConfigParam.IP;
            BLL.MemberProductFavorites bll = new BLL.MemberProductFavorites();
            try
            {
                Message msg = bll.Add(model);
                if (msg.State == State.Success)
                {
                    return "成功|";
                }
                else
                {
                    return "失败|已经加入到收藏夹";
                }
            }
            catch
            {
                return "失败|已经加入到收藏夹";
            }

        }
        #endregion
    }
}
