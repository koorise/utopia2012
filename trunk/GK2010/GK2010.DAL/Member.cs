using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GK2010.Utility;
namespace GK2010.DAL
{
	/// <summary>
	/// 数据访问类Member。
	/// </summary>
	public class Member
	{
		#region  构造函数
		public Member()
		{}
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

			int result= DbHelperSQL.RunProcedure("UP_Member_Exists",parameters,out rowsAffected);
			if(result==1)
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
		public int Add(GK2010.Model.Member model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@GroupID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@UserPwd", SqlDbType.NVarChar,100),
					new SqlParameter("@ProvinceID", SqlDbType.NVarChar,100),
					new SqlParameter("@CityID", SqlDbType.NVarChar,100),
					new SqlParameter("@AreaID", SqlDbType.NVarChar,100),
					new SqlParameter("@Company", SqlDbType.NVarChar,100),
					new SqlParameter("@RealName", SqlDbType.NVarChar,100),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,100),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,100),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@PostCode", SqlDbType.NVarChar,100),
					new SqlParameter("@RegisterDate", SqlDbType.BigInt,8),
					new SqlParameter("@RegisterIP", SqlDbType.NVarChar,100),
					new SqlParameter("@LastIP", SqlDbType.NVarChar,100),
					new SqlParameter("@LastDate", SqlDbType.BigInt,8),
					new SqlParameter("@MobileFlag", SqlDbType.Int,4),
					new SqlParameter("@EmailFlag", SqlDbType.Int,4),
					new SqlParameter("@VIPFlag", SqlDbType.Int,4),
					new SqlParameter("@AdminFlag", SqlDbType.Int,4),
					new SqlParameter("@LockFlag", SqlDbType.Int,4),
					new SqlParameter("@TotalOrder", SqlDbType.Int,4),
					new SqlParameter("@TotalJF", SqlDbType.Decimal,9)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.GroupID;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.UserPwd;
			parameters[4].Value = model.ProvinceID;
			parameters[5].Value = model.CityID;
			parameters[6].Value = model.AreaID;
			parameters[7].Value = model.Company;
			parameters[8].Value = model.RealName;
			parameters[9].Value = model.Email;
			parameters[10].Value = model.Telephone;
			parameters[11].Value = model.Mobile;
			parameters[12].Value = model.Address;
			parameters[13].Value = model.PostCode;
			parameters[14].Value = model.RegisterDate;
			parameters[15].Value = model.RegisterIP;
			parameters[16].Value = model.LastIP;
			parameters[17].Value = model.LastDate;
			parameters[18].Value = model.MobileFlag;
			parameters[19].Value = model.EmailFlag;
			parameters[20].Value = model.VIPFlag;
			parameters[21].Value = model.AdminFlag;
			parameters[22].Value = model.LockFlag;
			parameters[23].Value = model.TotalOrder;
			parameters[24].Value = model.TotalJF;

			DbHelperSQL.RunProcedure("UP_Member_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.Member model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@GroupID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@UserPwd", SqlDbType.NVarChar,100),
					new SqlParameter("@ProvinceID", SqlDbType.NVarChar,100),
					new SqlParameter("@CityID", SqlDbType.NVarChar,100),
					new SqlParameter("@AreaID", SqlDbType.NVarChar,100),
					new SqlParameter("@Company", SqlDbType.NVarChar,100),
					new SqlParameter("@RealName", SqlDbType.NVarChar,100),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,100),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,100),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@PostCode", SqlDbType.NVarChar,100),
					new SqlParameter("@RegisterDate", SqlDbType.BigInt,8),
					new SqlParameter("@RegisterIP", SqlDbType.NVarChar,100),
					new SqlParameter("@LastIP", SqlDbType.NVarChar,100),
					new SqlParameter("@LastDate", SqlDbType.BigInt,8),
					new SqlParameter("@MobileFlag", SqlDbType.Int,4),
					new SqlParameter("@EmailFlag", SqlDbType.Int,4),
					new SqlParameter("@VIPFlag", SqlDbType.Int,4),
					new SqlParameter("@AdminFlag", SqlDbType.Int,4),
					new SqlParameter("@LockFlag", SqlDbType.Int,4),
					new SqlParameter("@TotalOrder", SqlDbType.Int,4),
					new SqlParameter("@TotalJF", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.GroupID;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.UserPwd;
			parameters[4].Value = model.ProvinceID;
			parameters[5].Value = model.CityID;
			parameters[6].Value = model.AreaID;
			parameters[7].Value = model.Company;
			parameters[8].Value = model.RealName;
			parameters[9].Value = model.Email;
			parameters[10].Value = model.Telephone;
			parameters[11].Value = model.Mobile;
			parameters[12].Value = model.Address;
			parameters[13].Value = model.PostCode;
			parameters[14].Value = model.RegisterDate;
			parameters[15].Value = model.RegisterIP;
			parameters[16].Value = model.LastIP;
			parameters[17].Value = model.LastDate;
			parameters[18].Value = model.MobileFlag;
			parameters[19].Value = model.EmailFlag;
			parameters[20].Value = model.VIPFlag;
			parameters[21].Value = model.AdminFlag;
			parameters[22].Value = model.LockFlag;
			parameters[23].Value = model.TotalOrder;
			parameters[24].Value = model.TotalJF;

			DbHelperSQL.RunProcedure("UP_Member_Update",parameters,out rowsAffected);
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

			DbHelperSQL.RunProcedure("UP_Member_Delete",parameters,out rowsAffected);
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

			DataSet ds= DbHelperSQL.RunProcedure("UP_Member_GetModel",parameters,"ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_Member_GetList_ByCondition", parameters, "ds");
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
			DataSet ds = DbHelperSQL.RunProcedure("UP_Member_GetList", parameters, "ds");
            totalRows = 0;
            if (ds.Tables.Count > 0)
            {
                totalRows = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
            }
			
			return ds;
		}
		#endregion 

		#endregion  成员方法

        #region 其他方法

        #region  根据用户名获取用户对象
        /// <summary>
        /// 根据用户名获取用户对象
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public DataSet GetModelByUserName(string UserName)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100)};
            parameters[0].Value = UserName;

            DataSet ds = DbHelperSQL.RunProcedure("UP_Member_GetUserIDByUserName", parameters, "ds");
            return ds;
        }
        #endregion

        #region  根据邮箱获取用户对象
        /// <summary>
        /// 根据邮箱获取用户对象
        /// </summary>
        /// <param name="Email">邮箱</param>
        /// <returns></returns>
        public DataSet GetModelByEmail(string Email)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@Email", SqlDbType.NVarChar,100)};
            parameters[0].Value = Email;

            DataSet ds = DbHelperSQL.RunProcedure("UP_Member_GetUserIDByEmail", parameters, "ds");
            return ds;
        }
        #endregion

        #region  根据手机获取用户对象
        /// <summary>
        /// 根据手机获取用户对象
        /// </summary>
        /// <param name="Mobile">手机</param>
        /// <returns></returns>
        public DataSet GetModelByMobile(string Mobile)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@Mobile", SqlDbType.NVarChar,100)};
            parameters[0].Value = Mobile;

            DataSet ds = DbHelperSQL.RunProcedure("UP_Member_GetUserIDByMobile", parameters, "ds");
            return ds;
        }
        #endregion

        #region 检查用户名|手机号|邮箱是否存在

        /// <summary>
        /// 判断用户名|手机|邮箱是否存在
        /// </summary>
        /// <param name="UserName">用户名|手机|邮箱</param>
        /// <param name="LoginType">类型</param>
        /// <returns>true|false</returns>
        public bool CheckUserName(string UserName, EnumLoginType LoginType)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@UserName", SqlDbType.NVarChar, 100),
                                            new SqlParameter("@LoginType", SqlDbType.NVarChar, 100)
											
										};
            parameters[0].Value = UserName;
            parameters[1].Value = LoginType;
            DataSet ds = DbHelperSQL.RunProcedure("UP_Member_CheckUserName", parameters, "ds");
            return ds.Tables[0].Rows[0]["ret"].ToString() == "1";
        }
        #endregion

        #region 检查用户名与手机（或用户名与邮箱）是否匹对
        /// <summary>
        ///  检查用户名与手机（或检查用户名和邮箱）是否匹对
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Keyword">手机号|邮箱</param>
        /// <param name="LoginType">LoginType</param>
        /// <returns></returns>
        public bool MathUserName(string UserName, string Keyword, EnumLoginType LoginType)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@UserName", SqlDbType.NVarChar, 100),
                                            new SqlParameter("@Keyword", SqlDbType.NVarChar, 100),
                                            new SqlParameter("@LoginType", SqlDbType.NVarChar, 100)
											
										};
            parameters[0].Value = UserName;
            parameters[1].Value = Keyword;
            parameters[2].Value = LoginType;
            DataSet ds = DbHelperSQL.RunProcedure("UP_Member_MathUserName", parameters, "ds");
            return ds.Tables[0].Rows[0]["ret"].ToString() == "1";
        }
        #endregion

        #region  会员注册
        /// <summary>
        /// 会员注册
        /// </summary>
        /// <param name="model">会员信息</param>
        /// <returns>用户编号</returns>
        public int Register(GK2010.Model.Member model)
        {
            return 0;
            //int rowsAffected;
            //SqlParameter[] parameters = {
            //        new SqlParameter("@ID", SqlDbType.Int,4),
            //        new SqlParameter("@ReCommendUserID", SqlDbType.Int,4),
            //        new SqlParameter("@GroupID", SqlDbType.Int,4),
            //        new SqlParameter("@Groups", SqlDbType.NVarChar,500),
            //        new SqlParameter("@UserName", SqlDbType.NVarChar,100),
            //        new SqlParameter("@UserPwd", SqlDbType.NVarChar,100),
            //        new SqlParameter("@FaceID", SqlDbType.Int,4),
            //        new SqlParameter("@Face", SqlDbType.NVarChar,300),
            //        new SqlParameter("@FaceBig", SqlDbType.NVarChar,300),
            //        new SqlParameter("@FaceSmall", SqlDbType.NVarChar,300),
            //        new SqlParameter("@RealName", SqlDbType.NVarChar,50),
            //        new SqlParameter("@Sex", SqlDbType.Int,4),
            //        new SqlParameter("@Email", SqlDbType.NVarChar,100),
            //        new SqlParameter("@Mobile", SqlDbType.NVarChar,100),
            //        new SqlParameter("@BirthDay", SqlDbType.NVarChar,50),
            //        new SqlParameter("@BirthDay_NL", SqlDbType.NVarChar,50),
            //        new SqlParameter("@ProvinceID", SqlDbType.NVarChar,50),
            //        new SqlParameter("@CityID", SqlDbType.NVarChar,50),
            //        new SqlParameter("@IDCard", SqlDbType.NVarChar,100),
            //        new SqlParameter("@IDCardPictureID", SqlDbType.Int,4),
            //        new SqlParameter("@SecondVerifyQ1", SqlDbType.NVarChar,50),
            //        new SqlParameter("@SecondVerifyA1", SqlDbType.NVarChar,50),
            //        new SqlParameter("@SecondVerifyQ2", SqlDbType.NVarChar,50),
            //        new SqlParameter("@SecondVerifyA2", SqlDbType.NVarChar,50),
            //        new SqlParameter("@SecondVerifyQ3", SqlDbType.NVarChar,50),
            //        new SqlParameter("@SecondVerifyA3", SqlDbType.NVarChar,50),
            //        new SqlParameter("@Honor", SqlDbType.NText),
            //        new SqlParameter("@Signature", SqlDbType.NText),
            //        new SqlParameter("@Introduce", SqlDbType.NText),
            //        new SqlParameter("@RegisterIP", SqlDbType.NVarChar,50),
            //        new SqlParameter("@RegisterTime", SqlDbType.BigInt,8),
            //        new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,50),
            //        new SqlParameter("@LastLoginTime", SqlDbType.BigInt,8),
            //        new SqlParameter("@TotalVIPLevel", SqlDbType.Int,4),
            //        new SqlParameter("@TotalRate", SqlDbType.Decimal,9),
            //        new SqlParameter("@TotalLogin", SqlDbType.Int,4),
            //        new SqlParameter("@TotalReserve", SqlDbType.Int,4),
            //        new SqlParameter("@TotalDeposit", SqlDbType.Int,4),
            //        new SqlParameter("@TotalPosts", SqlDbType.Int,4),
            //        new SqlParameter("@TotalReply", SqlDbType.Int,4),
            //        new SqlParameter("@TotalPhotos", SqlDbType.Int,4),
            //        new SqlParameter("@TotalOnline", SqlDbType.Int,4),
            //        new SqlParameter("@TotalAccount", SqlDbType.Decimal,9),
            //        new SqlParameter("@TotalAccountFixed", SqlDbType.Decimal,9),
            //        new SqlParameter("@TotalSmsNum", SqlDbType.Int,4),
            //        new SqlParameter("@TotalCheat", SqlDbType.Int,4),
            //        new SqlParameter("@IsIDCardVerify", SqlDbType.Int,4),
            //        new SqlParameter("@IsSecondVerify", SqlDbType.Int,4),
            //        new SqlParameter("@IsEmail", SqlDbType.Int,4),
            //        new SqlParameter("@IsMobile", SqlDbType.Int,4),
            //        new SqlParameter("@IsRealName", SqlDbType.Int,4),
            //        new SqlParameter("@IsOnline", SqlDbType.Int,4),
            //        new SqlParameter("@IsLock", SqlDbType.Int,4),
            //        new SqlParameter("@TempRemark", SqlDbType.NVarChar,4000),
            //        new SqlParameter("@CanCreateShop", SqlDbType.Int,4),
            //        new SqlParameter("@ShopID", SqlDbType.Int,4),
            //        new SqlParameter("@ShopStatus", SqlDbType.NVarChar,100)};
            //parameters[0].Direction = ParameterDirection.Output;
            //parameters[1].Value = model.ReCommendUserID;
            //parameters[2].Value = model.GroupID;
            //parameters[3].Value = model.Groups;
            //parameters[4].Value = model.UserName;
            //parameters[5].Value = model.UserPwd;
            //parameters[6].Value = model.FaceID;
            //parameters[7].Value = model.Face;
            //parameters[8].Value = model.FaceBig;
            //parameters[9].Value = model.FaceSmall;
            //parameters[10].Value = model.RealName;
            //parameters[11].Value = model.Sex;
            //parameters[12].Value = model.Email;
            //parameters[13].Value = model.Mobile;
            //parameters[14].Value = model.BirthDay;
            //parameters[15].Value = model.BirthDay_NL;
            //parameters[16].Value = model.ProvinceID;
            //parameters[17].Value = model.CityID;
            //parameters[18].Value = model.IDCard;
            //parameters[19].Value = model.IDCardPictureID;
            //parameters[20].Value = model.SecondVerifyQ1;
            //parameters[21].Value = model.SecondVerifyA1;
            //parameters[22].Value = model.SecondVerifyQ2;
            //parameters[23].Value = model.SecondVerifyA2;
            //parameters[24].Value = model.SecondVerifyQ3;
            //parameters[25].Value = model.SecondVerifyA3;
            //parameters[26].Value = model.Honor;
            //parameters[27].Value = model.Signature;
            //parameters[28].Value = model.Introduce;
            //parameters[29].Value = model.RegisterIP;
            //parameters[30].Value = model.RegisterTime;
            //parameters[31].Value = model.LastLoginIP;
            //parameters[32].Value = model.LastLoginTime;
            //parameters[33].Value = model.TotalVIPLevel;
            //parameters[34].Value = model.TotalRate;
            //parameters[35].Value = model.TotalLogin;
            //parameters[36].Value = model.TotalReserve;
            //parameters[37].Value = model.TotalDeposit;
            //parameters[38].Value = model.TotalPosts;
            //parameters[39].Value = model.TotalReply;
            //parameters[40].Value = model.TotalPhotos;
            //parameters[41].Value = model.TotalOnline;
            //parameters[42].Value = model.TotalAccount;
            //parameters[43].Value = model.TotalAccountFixed;
            //parameters[44].Value = model.TotalSmsNum;
            //parameters[45].Value = model.TotalCheat;
            //parameters[46].Value = model.IsIDCardVerify;
            //parameters[47].Value = model.IsSecondVerify;
            //parameters[48].Value = model.IsEmail;
            //parameters[49].Value = model.IsMobile;
            //parameters[50].Value = model.IsRealName;
            //parameters[51].Value = model.IsOnline;
            //parameters[52].Value = model.IsLock;
            //parameters[53].Value = model.TempRemark;
            //parameters[54].Value = model.CanCreateShop;
            //parameters[55].Value = model.ShopID;
            //parameters[56].Value = model.ShopStatus;


            //DbHelperSQL.RunProcedure("UP_Member_Register", parameters, out rowsAffected);
            //return (int)parameters[0].Value;
        }
        #endregion

        #region 会员登录
        /// <summary>
        /// 会员登录
        /// </summary>
        /// <param name="UserName">登录账号</param>
        /// <param name="UserPwd">登录密码</param>
        /// <param name="LoginType">登录类型</param>
        /// <returns></returns>
        public int Login(string UserName, string UserPwd, EnumLoginType LoginType)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@UserName", SqlDbType.NVarChar,100),
											new SqlParameter("@UserPwd", SqlDbType.NVarChar,100),
                                            new SqlParameter("@LoginTime", SqlDbType.BigInt,4),
                                            new SqlParameter("@LoginIP", SqlDbType.NVarChar,100),
                                            new SqlParameter("@LoginType", SqlDbType.NVarChar,50)
										};
            parameters[0].Value = UserName;
            parameters[1].Value = UserPwd;
            parameters[2].Value = DatetimeHelper.Now;
            parameters[3].Value = ConfigParam.IP;
            parameters[4].Value = LoginType.ToString();

            DataSet ds = DbHelperSQL.RunProcedure("UP_Member_Login", parameters, "ds");
            return IntHelper.Parse(ds.Tables[0].Rows[0]["UserID"], 0);
        }
        #endregion


        #region 修改密码
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserName">账号</param>
        /// <param name="UserPwd">新密码</param>
        /// <param name="UserPwd">旧密码</param>
        /// <param name="LoginType">类型</param>
        /// <returns>true|false</returns>
        public bool SetPwd(string UserName, string UserPwd, string UserPwdOld, EnumLoginType LoginType)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
											new SqlParameter("@UserName", SqlDbType.NVarChar,100),
											new SqlParameter("@UserPwd", SqlDbType.NVarChar,100),
                                            new SqlParameter("@UserPwdOld", SqlDbType.NVarChar,100),
                                            new SqlParameter("@LoginType", SqlDbType.NVarChar,100)
										};
            parameters[0].Value = UserName;
            parameters[1].Value = UserPwd;
            parameters[2].Value = UserPwdOld;
            parameters[3].Value = LoginType;

            DbHelperSQL.RunProcedure("UP_Member_SetPwd", parameters, out rowsAffected);
            return rowsAffected > 0;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserName">账号</param>
        /// <param name="UserPwd">新密码</param>
        /// <param name="LoginType">类型</param>
        /// <returns>true|false</returns>
        public bool SetPwd(string UserName, string UserPwd, EnumLoginType LoginType)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
											new SqlParameter("@UserName", SqlDbType.NVarChar,100),
											new SqlParameter("@UserPwd", SqlDbType.NVarChar,100),
                                            new SqlParameter("@LoginType", SqlDbType.NVarChar,100)
										};
            parameters[0].Value = UserName;
            parameters[1].Value = UserPwd;
            parameters[2].Value = LoginType;

            DbHelperSQL.RunProcedure("UP_Member_SetPwd2", parameters, out rowsAffected);
            return rowsAffected > 0;
        }
        #endregion
        #endregion
	}
}

