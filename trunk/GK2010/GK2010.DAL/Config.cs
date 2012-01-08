using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GK2010.Utility;
namespace GK2010.DAL
{
    /// <summary>
    /// 数据访问类Config。
    /// </summary>
    public class Config
    {
        #region  构造函数
        public Config()
        { }
        #endregion

        #region  成员方法
        #region  是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            int result = DbHelperSQL.RunProcedure("UP_Config_Exists", parameters, out rowsAffected);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region  增加一条数据
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Add(GK2010.Model.Config model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@TitleEn", SqlDbType.NVarChar,100),
					new SqlParameter("@WebDomain", SqlDbType.NVarChar,100),
					new SqlParameter("@WebName", SqlDbType.NVarChar,100),
					new SqlParameter("@WebBeian", SqlDbType.NVarChar,100),
					new SqlParameter("@WebStatic", SqlDbType.NVarChar,300),
					new SqlParameter("@ControlService", SqlDbType.NText),
					new SqlParameter("@ControlTop", SqlDbType.NText),
					new SqlParameter("@ControlBoot", SqlDbType.NText),
					new SqlParameter("@ShowPriceDiyFlag", SqlDbType.Int,4),
					new SqlParameter("@ShowPriceWhenNotLogin", SqlDbType.Int,4),
					new SqlParameter("@AliPayAccount", SqlDbType.NVarChar,300),
					new SqlParameter("@AliPayPartnerID", SqlDbType.NVarChar,300),
					new SqlParameter("@AliPayKey", SqlDbType.NVarChar,300),
					new SqlParameter("@AliPayUserName", SqlDbType.NVarChar,300),
					new SqlParameter("@AliPayUserPwd", SqlDbType.NVarChar,300),
					new SqlParameter("@EmailUserName", SqlDbType.NVarChar,300),
					new SqlParameter("@EmailUserPwd", SqlDbType.NVarChar,300),
					new SqlParameter("@EmailHost", SqlDbType.NVarChar,300),
					new SqlParameter("@EmailPort", SqlDbType.NVarChar,300),
					new SqlParameter("@MobileUserName", SqlDbType.NVarChar,300),
					new SqlParameter("@MobileUserPwd", SqlDbType.NVarChar,300),
					new SqlParameter("@MobileEID", SqlDbType.NVarChar,300)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.TitleEn;
            parameters[3].Value = model.WebDomain;
            parameters[4].Value = model.WebName;
            parameters[5].Value = model.WebBeian;
            parameters[6].Value = model.WebStatic;
            parameters[7].Value = model.ControlService;
            parameters[8].Value = model.ControlTop;
            parameters[9].Value = model.ControlBoot;
            parameters[10].Value = model.ShowPriceDiyFlag;
            parameters[11].Value = model.ShowPriceWhenNotLogin;
            parameters[12].Value = model.AliPayAccount;
            parameters[13].Value = model.AliPayPartnerID;
            parameters[14].Value = model.AliPayKey;
            parameters[15].Value = model.AliPayUserName;
            parameters[16].Value = model.AliPayUserPwd;
            parameters[17].Value = model.EmailUserName;
            parameters[18].Value = model.EmailUserPwd;
            parameters[19].Value = model.EmailHost;
            parameters[20].Value = model.EmailPort;
            parameters[21].Value = model.MobileUserName;
            parameters[22].Value = model.MobileUserPwd;
            parameters[23].Value = model.MobileEID;

            DbHelperSQL.RunProcedure("UP_Config_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }
        #endregion

        #region  更新一条数据
        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(GK2010.Model.Config model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@TitleEn", SqlDbType.NVarChar,100),
					new SqlParameter("@WebDomain", SqlDbType.NVarChar,100),
					new SqlParameter("@WebName", SqlDbType.NVarChar,100),
					new SqlParameter("@WebBeian", SqlDbType.NVarChar,100),
					new SqlParameter("@WebStatic", SqlDbType.NVarChar,300),
					new SqlParameter("@ControlService", SqlDbType.NText),
					new SqlParameter("@ControlTop", SqlDbType.NText),
					new SqlParameter("@ControlBoot", SqlDbType.NText),
					new SqlParameter("@ShowPriceDiyFlag", SqlDbType.Int,4),
					new SqlParameter("@ShowPriceWhenNotLogin", SqlDbType.Int,4),
					new SqlParameter("@AliPayAccount", SqlDbType.NVarChar,300),
					new SqlParameter("@AliPayPartnerID", SqlDbType.NVarChar,300),
					new SqlParameter("@AliPayKey", SqlDbType.NVarChar,300),
					new SqlParameter("@AliPayUserName", SqlDbType.NVarChar,300),
					new SqlParameter("@AliPayUserPwd", SqlDbType.NVarChar,300),
					new SqlParameter("@EmailUserName", SqlDbType.NVarChar,300),
					new SqlParameter("@EmailUserPwd", SqlDbType.NVarChar,300),
					new SqlParameter("@EmailHost", SqlDbType.NVarChar,300),
					new SqlParameter("@EmailPort", SqlDbType.NVarChar,300),
					new SqlParameter("@MobileUserName", SqlDbType.NVarChar,300),
					new SqlParameter("@MobileUserPwd", SqlDbType.NVarChar,300),
					new SqlParameter("@MobileEID", SqlDbType.NVarChar,300)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.TitleEn;
            parameters[3].Value = model.WebDomain;
            parameters[4].Value = model.WebName;
            parameters[5].Value = model.WebBeian;
            parameters[6].Value = model.WebStatic;
            parameters[7].Value = model.ControlService;
            parameters[8].Value = model.ControlTop;
            parameters[9].Value = model.ControlBoot;
            parameters[10].Value = model.ShowPriceDiyFlag;
            parameters[11].Value = model.ShowPriceWhenNotLogin;
            parameters[12].Value = model.AliPayAccount;
            parameters[13].Value = model.AliPayPartnerID;
            parameters[14].Value = model.AliPayKey;
            parameters[15].Value = model.AliPayUserName;
            parameters[16].Value = model.AliPayUserPwd;
            parameters[17].Value = model.EmailUserName;
            parameters[18].Value = model.EmailUserPwd;
            parameters[19].Value = model.EmailHost;
            parameters[20].Value = model.EmailPort;
            parameters[21].Value = model.MobileUserName;
            parameters[22].Value = model.MobileUserPwd;
            parameters[23].Value = model.MobileEID;

            DbHelperSQL.RunProcedure("UP_Config_Update", parameters, out rowsAffected);
            return rowsAffected > 0;
        }
        #endregion

        #region  删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.RunProcedure("UP_Config_Delete", parameters, out rowsAffected);
            return rowsAffected > 0;
        }
        #endregion

        #region  得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DataSet GetModel(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DataSet ds = DbHelperSQL.RunProcedure("UP_Config_GetModel", parameters, "ds");
            return ds;
        }
        #endregion


        #region 列表(不分页)
        public DataSet GetList(string Keywords, string Type)
        {
            SqlParameter[] parameters = {
				new SqlParameter("@Keywords", SqlDbType.VarChar, 50),
				new SqlParameter("@Type", SqlDbType.VarChar,50)
			};
            parameters[0].Value = Keywords;
            parameters[1].Value = Type;
            DataSet ds = DbHelperSQL.RunProcedure("UP_Config_GetList_ByCondition", parameters, "ds");
            return ds;
        }
        #endregion

        #region 列表(后台分页管理)
        public DataSet GetList(int PageSize, int PageIndex, string Keywords, string Type, out int totalRows)
        {
            SqlParameter[] parameters = {
				new SqlParameter("@PageSize", SqlDbType.Int),
				new SqlParameter("@PageIndex", SqlDbType.Int),
				new SqlParameter("@Keywords", SqlDbType.VarChar,50),
				new SqlParameter("@Type", SqlDbType.VarChar,50),
			};
            parameters[0].Value = PageSize;
            parameters[1].Value = PageIndex;
            parameters[2].Value = Keywords;
            parameters[3].Value = Type;
            DataSet ds = DbHelperSQL.RunProcedure("UP_Config_GetList", parameters, "ds");
            totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
            return ds;
        }
        #endregion

        #endregion  成员方法
    }
}

