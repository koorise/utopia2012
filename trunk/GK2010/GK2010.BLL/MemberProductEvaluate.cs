using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GK2010.Model;

namespace GK2010.BLL
{
    public class MemberProductEvaluate
    {
        #region  私有变量
        private readonly GK2010.DAL.MemberProductEvaluate dal = new GK2010.DAL.MemberProductEvaluate();
        #endregion

        #region 获取评价列表（分页）
        public List<Model.MemberProductEvaluate> getList(int ProductID,int PageIndex, out int totalRows)
        {
            DataSet ds = dal.getList(ProductID,PageIndex, out totalRows);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获取最新的几条产品评价列表
        public List<Model.MemberProductEvaluate> GetTopNumDataSetByProductID(int ProductID)
        {
            DataSet ds = dal.GetTopNumDataSetByProductID(ProductID);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 根据商品返回总评分
        public int GetSorce(int productID)
        {
            return dal.GetSorce(productID);
        }
        #endregion

        #region 根据商品返回评分次数
        public int GetSorceCount(int productID)
        {
            return dal.GetSorceCount(productID);
        }
        #endregion

        #region 获取产品评价列表
        public DataSet GetDataSetByProductID(int ProductID, int Num)
        {
            return dal.GetDataSetByProductID(ProductID, Num);
        }
        #endregion

        #region  转换数据列表
        /// <summary>
        /// 转换数据列表
        /// </summary>
        public List<GK2010.Model.MemberProductEvaluate> DataTableToList(DataTable dt)
        {
            return DataTableToList(dt.Select());
        }
        /// <summary>
        /// 转换数据列表
        /// </summary>
        public List<GK2010.Model.MemberProductEvaluate> DataTableToList(DataRow[] drs)
        {
            List<GK2010.Model.MemberProductEvaluate> modelList = new List<GK2010.Model.MemberProductEvaluate>();
            GK2010.Model.MemberProductEvaluate model;
            foreach (DataRow dr in drs)
            {
                model = new GK2010.Model.MemberProductEvaluate();
                if (dr["ID"].ToString() != "")
                {
                    model.Id = long.Parse(dr["ID"].ToString());
                }
                if (dr["ProductID"].ToString() != "")
                {
                    model.ProductID = long.Parse(dr["ProductID"].ToString());
                }
                if (dr["MemberID"].ToString() != "")
                {
                    model.MemberID = long.Parse(dr["MemberID"].ToString());
                }
                if (dr["BigCategoryID"].ToString() != "")
                {
                    model.BigCategoryID = int.Parse(dr["BigCategoryID"].ToString());
                }
                model.MemeberUserName = dr["MemeberUserName"].ToString();
                model.ProductTitle = dr["ProductTitle"].ToString();
                model.EvaluateTitle = dr["EvaluateTitle"].ToString();
                model.EvaluateTime = dr["EvaluateTime"].ToString();
                model.Advantage = dr["Advantage"].ToString();
                model.Inadequate = dr["Inadequate"].ToString();
                if (dr["EvaluateGrade"].ToString() != "")
                {
                    model.EvaluateGrade = int.Parse(dr["EvaluateGrade"].ToString());
                }
                model.Reply = dr["Reply"].ToString();
                if (dr["Review"].ToString() != "")
                {
                    model.Review = int.Parse(dr["Review"].ToString());
                }
                if (dr["Score"].ToString() != "")
                {
                    model.Score = int.Parse(dr["Score"].ToString());
                }
                if (dr["Comment"].ToString() != "")
                {
                    model.Comment = int.Parse(dr["Comment"].ToString());
                }
                modelList.Add(model);
            }
            return modelList;
        }
        #endregion

        #region 根据商品返回所有评价次数
        public int GetCommentCount(int productID)
        {
            return dal.GetCommentCount(productID);
        }
        #endregion

        #region 根据商品返回评价次数
        public int GetCommentCountByComment(int productID, int comment)
        {
            return dal.GetCommentCountByComment(productID,comment);
        }
        #endregion

    }
}