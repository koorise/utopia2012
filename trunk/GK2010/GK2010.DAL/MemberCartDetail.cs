using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using GK2010.Utility;

namespace GK2010.DAL
{
    public class MemberCartDetail
    {
        #region 增加一条数据
        public int Add(GK2010.Model.MemberCartDetail model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BasicDiscountJF", SqlDbType.Int,4),
					new SqlParameter("@BasicDiscountPrice", SqlDbType.Int,4),
					new SqlParameter("@CartNum", SqlDbType.NVarChar,100),
					new SqlParameter("@DiyExpression", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyFlag", SqlDbType.Int,4),
					new SqlParameter("@DiyTypeAttachmentFlag", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypeCn", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypeEn", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypePartsID", SqlDbType.NVarChar,2000),
					new SqlParameter("@DiyTypePrice", SqlDbType.NVarChar,2000),
					new SqlParameter("@JF", SqlDbType.Decimal,9),
					new SqlParameter("@JFOld", SqlDbType.Decimal,9),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@PriceOld", SqlDbType.Decimal,9),
					new SqlParameter("@ProductCacheID", SqlDbType.BigInt,8),
					new SqlParameter("@ProductPartsCacheID", SqlDbType.BigInt,8),
					new SqlParameter("@TotalJF", SqlDbType.Decimal,9),
					new SqlParameter("@TotalPrice", SqlDbType.Decimal,9)              
            };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.BasicDiscountJF;
            parameters[2].Value = model.BasicDiscountPrice;
            parameters[3].Value = model.CartNum;
            parameters[4].Value = model.DiyExpression;
            parameters[5].Value = model.DiyFlag;
            parameters[6].Value = model.DiyTypeAttachmentFlag;
            parameters[7].Value = model.DiyTypeCn;
            parameters[8].Value = model.DiyTypeEn;
            parameters[9].Value = model.DiyTypePartsID;
            parameters[10].Value = model.DiyTypePrice;
            parameters[11].Value = model.JF;
            parameters[12].Value = model.JFOld;
            parameters[13].Value = model.Num;
            parameters[14].Value = model.Price;
            parameters[15].Value = model.PriceOld;
            parameters[16].Value = model.ProductCacheID;
            parameters[17].Value = model.ProductPartsCacheID;
            parameters[18].Value = model.TotalJF;
            parameters[19].Value = model.TotalPrice;

            DbHelperSQL.RunProcedure("Up_MemberCartDetail_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }
        #endregion

        #region 根据id删除数据
        public bool DeleteByID(int id)
        {
            SqlParameter[] p = { new SqlParameter("@ID",SqlDbType.Int,4) };
            p[0].Value = id;
            int rowsAffected;
            DbHelperSQL.RunProcedure("UP_MemberCartDetail_DeleteByID", p, out rowsAffected);
            return rowsAffected > 0;
        }
        #endregion

        #region 根据购物车编号查询所有购物车里面的产品
        public DataSet GetMemberCartDetailByCartNum(string cartNum)
        {
            SqlParameter[] p = { new SqlParameter("@CartNum", SqlDbType.NVarChar, 100) };
            p[0].Value = cartNum;
            DataSet ds = DbHelperSQL.RunProcedure("UP_MemberCartDetail_GetMemberCartDetailByCartNum", p, "ds");
            return ds;
        }
        #endregion

        #region 根据产品快照编号和产品部件快照编号查询快照购物详细表
        public DataSet GetMemberCartDetailByProductCacheIDAndProductPartCacheID(long productCacheID, long productPartCacheID)
        {
            SqlParameter[] p = { 
                                  new SqlParameter("@ProductCacheID", SqlDbType.BigInt,8),
                                  new SqlParameter("@ProductPartsCacheID",  SqlDbType.BigInt,8)
                              };
            p[0].Value = productCacheID;
            p[1].Value = productPartCacheID;
            DataSet ds = DbHelperSQL.RunProcedure("UP_MemberCartDetail_GetMemberCartDetailByProductCacheIDAndProductPartCacheID", p, "ds");
            return ds;
        }
        #endregion

        #region 根据ID更新数据的数量、价格、积分
        public bool UpdatePartDataByID(Model.MemberCartDetail mcd)
        {
            SqlParameter[] p = {
                               new SqlParameter("@ID",SqlDbType.Int,4),
                               new SqlParameter("@Num",SqlDbType.Int,4),
                               new SqlParameter("@TotalJF",SqlDbType.Decimal,18),
                               new SqlParameter("@TotalPrice",SqlDbType.Decimal,18)
                               };
            p[0].Value=mcd.Id;
            p[1].Value=mcd.Num;
            p[2].Value=mcd.TotalJF;
            p[3].Value=mcd.TotalPrice;
            int rowsAffected=0;
            DbHelperSQL.RunProcedure("UP_MemberCartDetail_UpdatePartDataByID", p, out rowsAffected);
            return rowsAffected > 0;
        }
        #endregion

        #region 根据ID获得一个对象
        public DataSet GetModelByID(int id) {
            SqlParameter[] p = { new SqlParameter("@ID",SqlDbType.Int,4) };
            p[0].Value = id;
            DataSet ds = DbHelperSQL.RunProcedure("UP_MemberCartDetail_GetModelByID", p, "ds");
            return ds;
        }
        #endregion
    }
}
