using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GK2010.Utility;

namespace GK2010.BLL
{
   public class MemberCity
    {
        #region Model
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.MemberCity GetModel(string Title)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50)
				};
            parameters[0].Value = Title;
            Model.MemberCity model = new Model.MemberCity();

            DataSet ds = DbHelperSQL.RunProcedure("UP_MemberCity_GetModelByCityID", parameters, "ds");
            model.CityID = Title;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();
                model.CityName = ds.Tables[0].Rows[0]["CityName"].ToString();

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

       #region 列表
       public DataSet GetList(string ProvinceID)
       {
           SqlParameter[] parameters = { new SqlParameter("@ProvinceID", SqlDbType.VarChar, 255), };
           parameters[0].Value = ProvinceID;

           DataSet ds = DbHelperSQL.RunProcedure("UP_MemberCity_GetList", parameters, "ds");
           return ds;
       }
       #endregion  

       #region  转换数据列表
       /// <summary>
       /// 转换数据列表
       /// </summary>
       public List<GK2010.Model.MemberCity> DataTableToList(DataTable dt)
       {
           return DataTableToList(dt.Select());
       }
       /// <summary>
       /// 转换数据列表
       /// </summary>
       public List<GK2010.Model.MemberCity> DataTableToList(DataRow[] drs)
       {
           List<GK2010.Model.MemberCity> modelList = new List<GK2010.Model.MemberCity>();
           GK2010.Model.MemberCity model;
           foreach (DataRow dr in drs)
           {
               model = new GK2010.Model.MemberCity();
               if (dr["ID"].ToString() != "")
               {
                   model.ID = int.Parse(dr["ID"].ToString());
               }
               model.ProvinceID = dr["ProvinceID"].ToString();
               model.CityName = dr["CityName"].ToString();
               model.CityID = dr["CityID"].ToString();

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

        #region 省市县

        public static string BindCity(string ProvinceID, string CityID)
        {
            return BindCity(ProvinceID, CityID, "");
        }
        public static string BindCity(string ProvinceID, string CityID, string Type)
        {
            StringBuilder sb = new StringBuilder();
            BLL.MemberCity bll = new MemberCity();
            DataSet ds = bll.GetList(ProvinceID);
            sb.Append("<select id='" + Type + "City' onchange='change" + Type + "City(this)'>");
            sb.Append("<option value='0'>请选择</option>");
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string strCityID = ds.Tables[0].Rows[i]["CityID"].ToString();
                    string strCityName = ds.Tables[0].Rows[i]["CityName"].ToString();
                    string strSelect = "";
                    if (strCityID == CityID)
                    {
                        strSelect = "selected";
                    }
                    sb.Append("<option value='" + strCityID + "' " + strSelect + " >" + strCityName + "</option>");
                }
            }
            sb.Append("</select>");
            return sb.ToString();
        }

        public static string GetCityName(string CityID)
        {
            BLL.MemberCity bll = new MemberCity();
            Model.MemberCity model = bll.GetModel(CityID);
            if (model != null)
            {
                return model.CityName;
            }
            else
            {
                return "";
            }
        }

        #endregion
    }
}
