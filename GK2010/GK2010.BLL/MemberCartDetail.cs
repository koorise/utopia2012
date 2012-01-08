using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GK2010.BLL
{
    public class MemberCartDetail
    {
        #region 私有变量
        private readonly GK2010.DAL.MemberCartDetail mc = new DAL.MemberCartDetail();
        #endregion

        #region 增加一条数据
        public int Add(GK2010.Model.MemberCartDetail model)
        {
            return mc.Add(model);
        }
        #endregion

        #region 根据id删除数据
        public bool DeleteByID(int id) {
            return mc.DeleteByID(id);
        }
        #endregion

        #region 根据ID获得一个对象
        public Model.MemberCartDetail GetModelByID(int id) {
            List<Model.MemberCartDetail> list = DataTableToList(mc.GetModelByID(id).Tables[0]);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }
        #endregion

        #region 根据购物车编号查询所有购物车里面的产品
        public DataSet GetMemberCartDetailDataSetByCartNum(string cartNum)
        {
            return mc.GetMemberCartDetailByCartNum(cartNum);
        }
        #endregion

        #region 根据购物车编号查询所有购物车里面的产品
        public List<Model.MemberCartDetail> GetMemberCartDetailByCartNum(string cartNum) { 
            return DataTableToList(mc.GetMemberCartDetailByCartNum(cartNum).Tables[0]);
        } 
        #endregion

        #region 根据产品快照编号和产品部件快照编号查询快照购物详细表
        public Model.MemberCartDetail GetMemberCartDetailByProductCacheIDAndProductPartCacheID(long productCacheID, long productPartCacheID) {
            List<Model.MemberCartDetail> list=DataTableToList(mc.GetMemberCartDetailByProductCacheIDAndProductPartCacheID(productCacheID,productPartCacheID).Tables[0]);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }
        #endregion

        #region 根据ID更新数据的数量、价格、积分
        public bool UpdatePartDataByID(Model.MemberCartDetail mcd) {
            return mc.UpdatePartDataByID(mcd);
        }
        #endregion

        #region  转换数据列表
        /// <summary>
       /// 转换数据列表
       /// </summary>
       public List<Model.MemberCartDetail> DataTableToList(DataTable dt)
       {
           return DataTableToList(dt.Select());
       }
       /// <summary>
       /// 转换数据列表
       /// </summary>
       public List<Model.MemberCartDetail> DataTableToList(DataRow[] drs)
       {
           List<GK2010.Model.MemberCartDetail> modelList = new List<GK2010.Model.MemberCartDetail>();
           GK2010.Model.MemberCartDetail model;
           foreach (DataRow dr in drs)
           {
               model = new GK2010.Model.MemberCartDetail();

               if (dr["BasicDiscountJF"].ToString() != "")
               {
                   model.BasicDiscountJF = int.Parse(dr["BasicDiscountJF"].ToString());
               }
               if (dr["BasicDiscountPrice"].ToString() != "")
               {
                   model.BasicDiscountPrice = int.Parse(dr["BasicDiscountPrice"].ToString());
               }
               model.CartNum = dr["CartNum"].ToString();
               model.DiyExpression = dr["DiyExpression"].ToString();
               if (dr["DiyFlag"].ToString() != "")
               {
                   model.DiyFlag = int.Parse(dr["DiyFlag"].ToString());
               }
               model.DiyTypeAttachmentFlag = dr["DiyTypeAttachmentFlag"].ToString();
               model.DiyTypeCn = dr["DiyTypeCn"].ToString();
               model.DiyTypeEn = dr["DiyTypeEn"].ToString();
               model.DiyTypePartsID = dr["DiyTypePartsID"].ToString();
               model.DiyTypePrice = dr["DiyTypePrice"].ToString();

               if (dr["Id"].ToString() != "")
               {
                   model.Id = int.Parse(dr["Id"].ToString());
               }
               if (dr["JF"].ToString() != "")
               {
                   model.JF = decimal.Parse(dr["JF"].ToString());
               }
               if (dr["JFOld"].ToString() != "")
               {
                   model.JFOld = decimal.Parse(dr["JFOld"].ToString());
               }
               if (dr["Num"].ToString() != "")
               {
                   model.Num = int.Parse(dr["Num"].ToString());
               }
               if (dr["Price"].ToString() != "")
               {
                   model.Price = decimal.Parse(dr["Price"].ToString());
               }
               if (dr["PriceOld"].ToString() != "")
               {
                   model.PriceOld = decimal.Parse(dr["PriceOld"].ToString());
               }
               if (dr["ProductCacheID"].ToString() != "")
               {
                   model.ProductCacheID = long.Parse(dr["ProductCacheID"].ToString());
               }
               if (dr["ProductPartsCacheID"].ToString() != "")
               {
                   model.ProductPartsCacheID = long.Parse(dr["ProductPartsCacheID"].ToString());
               }
               if (dr["TotalJF"].ToString() != "")
               {
                   model.TotalJF = decimal.Parse(dr["TotalJF"].ToString());
               }
               if (dr["TotalPrice"].ToString() != "")
               {
                   model.TotalPrice = decimal.Parse(dr["TotalPrice"].ToString());
               }
               modelList.Add(model);
           }
           return modelList;
       }
       #endregion

    }
}
