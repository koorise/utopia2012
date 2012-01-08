using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GK2010.Utility;
using System.Data.SqlClient;

namespace GK2010.BLL
{
   public class MemberProvince
    {
       #region 列表
       public DataSet GetList()
       {
           SqlParameter[] parameters = { null };

           DataSet ds = DbHelperSQL.RunProcedure("UP_MemberProvince_GetList", parameters, "ds");
           return ds;
       }
       #endregion

       #region  转换数据列表
       /// <summary>
       /// 转换数据列表
       /// </summary>
       public List<GK2010.Model.MemberProvince> DataTableToList(DataTable dt)
       {
           return DataTableToList(dt.Select());
       }
       /// <summary>
       /// 转换数据列表
       /// </summary>
       public List<GK2010.Model.MemberProvince> DataTableToList(DataRow[] drs)
       {
           List<GK2010.Model.MemberProvince> modelList = new List<GK2010.Model.MemberProvince>();
           GK2010.Model.MemberProvince model;
           foreach (DataRow dr in drs)
           {
               model = new GK2010.Model.MemberProvince();
               if (dr["ID"].ToString() != "")
               {
                   model.ID = int.Parse(dr["ID"].ToString());
               }
               model.ProvinceID = dr["ProvinceID"].ToString();
               model.ProvinceName = dr["ProvinceName"].ToString();

               if (dr["DeleteFlag"].ToString() != "")
               {
                   model.DeleteFlag = int.Parse(dr["DeleteFlag"].ToString());
               }

               if (dr["SortID"].ToString() != "")
               {
                   model.SortID = decimal.Parse(dr["SortID"].ToString());
               }

               modelList.Add(model);
           }
           return modelList;
       }
       #endregion

       #region Model
       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Model.MemberProvince GetModel(string Title)
       {
           SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50)
				};
           parameters[0].Value = Title;
           Model.MemberProvince model = new Model.MemberProvince();

           DataSet ds = DbHelperSQL.RunProcedure("UP_MemberProvince_GetModelByProvinceID", parameters, "ds");
           model.ProvinceID = Title;
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
               {
                   model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
               }
               model.ProvinceName = ds.Tables[0].Rows[0]["ProvinceName"].ToString();
               if (ds.Tables[0].Rows[0]["SortID"].ToString() != "")
               {
                   model.SortID = decimal.Parse(ds.Tables[0].Rows[0]["SortID"].ToString());
               }
               if (ds.Tables[0].Rows[0]["DeleteFlag"].ToString() != "")
               {
                   model.DeleteFlag = int.Parse(ds.Tables[0].Rows[0]["DeleteFlag"].ToString());
               }
               return model;
           }
           else
           {
               return null;
           }
       }
       #endregion

        #region 省市县
        public static string BindProvince(string ProvinceID)
        {
            // return BindProvince(ProvinceID, "");
            return BindProvince(ProvinceID, "");
        }
        public static string BindProvince(string ProvinceID, string Type)
        {
            StringBuilder sb = new StringBuilder();
            BLL.MemberProvince bll = new MemberProvince();
            DataSet ds = bll.GetList();
            sb.Append("<select id='" + Type + "Province' onchange='change" + Type + "Province(this)'>");
            sb.Append("<option value='0'>请选择</option>");
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string strProvinceID = ds.Tables[0].Rows[i]["ProvinceID"].ToString();
                    string strProvinceName = ds.Tables[0].Rows[i]["ProvinceName"].ToString();
                    string strSelect = "";
                    if (strProvinceID == ProvinceID)
                    {
                        strSelect = "selected";
                    }
                    sb.Append("<option value='" + strProvinceID + "' " + strSelect + " >" + strProvinceName + "</option>");
                }
            }
            sb.Append("</select>");
            return sb.ToString();
        }
        public static string GetProvinceName(string ProvinceID)
        {
            BLL.MemberProvince bll = new MemberProvince();
            Model.MemberProvince model = bll.GetModel(ProvinceID);
            if (model != null)
            {
                return model.ProvinceName;
            }
            else
            {
                return "";
            }
        }

        #endregion
    }
}
