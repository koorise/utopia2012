using System;
using System.Collections.Generic;
using System.Text;
using GK2010.Utility;
using System.Data;

namespace GK2010.BLL
{
    public class MemberProductBrowse
    {
        private Message message;
        private DAL.MemberProductBrowse mpb;

        public MemberProductBrowse()
        {
            message = new Message();
            mpb = new DAL.MemberProductBrowse();
        }

        #region 添加
        public Message Add(Model.MemberProductBrowse model)
        {
            return mpb.Add(model);
        }
        #endregion

        #region 修改
        /// <summary>
        ///  更新一条数据
        /// </summary>
        public Message Update(Model.MemberProductBrowse model)
        {
            return mpb.Update(model);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public Message Delete(int ID)
        {

            return mpb.Delete(ID);
        }
        #endregion

        #region Model
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.MemberProductBrowse GetModel(int ID)
        {
            return mpb.GetModel(ID);
        }
        #endregion

        #region 列表(后台分页管理)
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string strOrder, out int totalRows)
        {
            return mpb.GetList(PageSize, PageIndex, strWhere, strOrder,out totalRows);
        }
        #endregion

        #region 最近浏览
        public DataSet GetList(int MemberID, string IP)
        {
            return mpb.GetList(MemberID, IP);
        }
        #endregion


        #region 获取浏览过此产品的会员还看过的产品
        public DataSet GetDataSetByProductID(int productID)
        {
            return mpb.GetDataSetByProductID(productID);
        }
        #endregion
    }
}
