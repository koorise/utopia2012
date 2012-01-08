using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using GK2010.Utility;
using GK2010.Model;

namespace GK2010.DAL
{
   public class MemberProductEvaluate
   {
       #region 获取最新的几条产品评价列表
       public DataSet GetTopNumDataSetByProductID(int ProductID)
       {
           SqlParameter[] p ={
                            new SqlParameter("@ProductID",SqlDbType.BigInt,8)};
           p[0].Value = ProductID;
           DataSet ds = DbHelperSQL.RunProcedure("UP_MemberProductEvaluate_GetTopNumList",p, "ds");
           return ds;
       }
       #endregion

       #region 获取产品评价列表
       public DataSet GetDataSetByProductID(int ProductID, int Num)
       {
           SqlParameter[] p ={
                            new SqlParameter("@ProductID",SqlDbType.BigInt,8)};
           p[0].Value = ProductID;
           DataSet ds = DbHelperSQL.RunProcedure("UP_MemberProductEvaluate_GetList", p, "ds");
           return ds;
       }
       #endregion

       #region  根据商品返回总评分
       public int GetSorce(int productID)
       {
           SqlParameter[] parameter = { new SqlParameter("@productID", SqlDbType.BigInt) };
           parameter[0].Value = productID;
           int zongfen;
           return DbHelperSQL.RunProcedure("UP_MemberProductEvaluate_GetSource", parameter, out zongfen);
       }
       #endregion

       #region  根据商品返回评分次数
       public int GetSorceCount(int productID)
       {
           SqlParameter[] parameter = { new SqlParameter("@productID", SqlDbType.BigInt) };
           parameter[0].Value = productID;
           int pinfenCount;
           return DbHelperSQL.RunProcedure("UP_MemberProductEvaluate_GetSourceCount", parameter, out pinfenCount);
       }
       #endregion

       #region 根据商品返回所有评价次数
       public int GetCommentCount(int productID)
       {
           SqlParameter[] parameter = { new SqlParameter("@productID", SqlDbType.BigInt) };
           parameter[0].Value = productID;
           int commentCount;
           return DbHelperSQL.RunProcedure("UP_MemberProductEvaluate_GetEvaluate", parameter, out commentCount);
       }
       #endregion

       #region 根据商品返回评价次数
       public int GetCommentCountByComment(int productID,int comment)
       {
           SqlParameter[] parameter = { new SqlParameter("@productID", SqlDbType.BigInt), new SqlParameter("@comment",SqlDbType.Int) };
           parameter[0].Value = productID;
           parameter[1].Value = comment;
           int commentCount;
           return DbHelperSQL.RunProcedure("UP_MemberProductEvaluate_GetEvaluateByComment", parameter, out commentCount);
       }
       #endregion

       #region 获取评价列表（分页）
       public DataSet getList(int ProductID, int PageIndex, out int totalRows)
       {
           SqlParameter[] p ={ 
                             new SqlParameter("@ProductID",SqlDbType.BigInt,8),
                             new SqlParameter("@PageIndex",SqlDbType.Int,4)
                             };
           p[0].Value = ProductID;
           p[1].Value = PageIndex;
           DataSet ds = DbHelperSQL.RunProcedure("UP_MemberProductEvaluate_GetListByProductID", p, "ds");
           totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
           return ds;
       }
       #endregion
   }
}
