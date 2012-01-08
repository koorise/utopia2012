using System;
using System.Collections.Generic;
using System.Text;
using GK2010.Utility;

namespace GK2010.BLL
{
    public class MemberProductFavorites
    {
        #region  私有变量
        private readonly GK2010.DAL.MemberProductFavorites dal = new GK2010.DAL.MemberProductFavorites();
        #endregion
        private Message message;

        public MemberProductFavorites()
        {
            message = new Message();
        }

        #region 添加
        public Message Add(Model.MemberProductFavorite model)
        {
            return dal.Add(model);
        }
        #endregion


        #region Model 获取收藏人气
        /// <summary>
        /// 获取收藏人气
        /// </summary>
        public static int GetCount(int BigCategoryID, int ProductID)
        {
            return DAL.MemberProductFavorites.GetCount(BigCategoryID, ProductID);
         }
        #endregion
    }
}