using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GK2010.Utility;

namespace GK2010.BLL
{
   public class MemberArea
    {
        #region Model
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.MemberArea GetModel(string Title)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50)
				};
            parameters[0].Value = Title;
            Model.MemberArea model = new Model.MemberArea();

            DataSet ds = DbHelperSQL.RunProcedure("UP_MemberArea_GetModelByAreaID", parameters, "ds");
            model.AreaID = Title;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();
                model.CityID = ds.Tables[0].Rows[0]["CityID"].ToString();
                model.AreaName = ds.Tables[0].Rows[0]["AreaName"].ToString();

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
       public DataSet GetList(string CityID)
       {
           SqlParameter[] parameters = { new SqlParameter("@CityID", SqlDbType.VarChar, 50), };
           parameters[0].Value = CityID;

           DataSet ds = DbHelperSQL.RunProcedure("UP_MemberArea_GetList", parameters, "ds");
           return ds;
       }
       #endregion  

        #region 省市县

        public static string BindArea(string CityID, string AreaID)
        {
            return BindArea(CityID, AreaID, "");
        }

        public static string BindArea(string CityID, string AreaID, string Type)
        {
            StringBuilder sb = new StringBuilder();
            BLL.MemberArea bll = new MemberArea();
            DataSet ds = bll.GetList(CityID);
            sb.Append("<select id='" + Type + "Arae' onchange='change" + Type + "Area(this)'>");
            sb.Append("<option value='0'>请选择</option>");
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string strAreaID = ds.Tables[0].Rows[i]["AreaID"].ToString();
                    string strAreaName = ds.Tables[0].Rows[i]["AreaName"].ToString();
                    string strSelect = "";
                    if (strAreaID == AreaID)
                    {
                        strSelect = "selected";
                    }
                    sb.Append("<option value='" + strAreaID + "' " + strSelect + " >" + strAreaName + "</option>");
                }
            }
            sb.Append("</select>");
            return sb.ToString();
        }

        public static string GetAreaName(string AreaID)
        {
            BLL.MemberArea bll = new MemberArea();
            Model.MemberArea model = bll.GetModel(AreaID);
            if (model != null)
            {
                return model.AreaName;
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}
