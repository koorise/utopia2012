using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// 业务逻辑类Member 的摘要说明。
	/// </summary>
	public class Member
	{
		#region  私有变量
		private readonly GK2010.DAL.Member dal=new GK2010.DAL.Member();
		#endregion
		
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
			return dal.Exists(ID);
		}
		#endregion  是否存在该记录

		#region  增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(GK2010.Model.Member model)
		{
            if (model.Mobile.Length > 0)
            {
                model.Mobile = Utility.DEncryptHelper.DESEncrypt.Encrypt(model.Mobile);
            }
            if (model.Email.Length > 0)
            {
                model.Email = Utility.DEncryptHelper.DESEncrypt.Encrypt(model.Email);
            }
            if (model.UserPwd.Length > 0)
            {
                model.UserPwd = Utility.DEncryptHelper.MD5.Encrypt(model.UserPwd);
            }
			return dal.Add(model);
		}
		#endregion

		#region  更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GK2010.Model.Member model)
		{
            if (model.Mobile.Length > 0)
            {
                model.Mobile = Utility.DEncryptHelper.DESEncrypt.Encrypt(model.Mobile);
            }
            if (model.Email.Length > 0)
            {
                model.Email = Utility.DEncryptHelper.DESEncrypt.Encrypt(model.Email);
            }
			return dal.Update(model);
		}
		#endregion

		#region  删除一条数据
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		#endregion

		#region  得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GK2010.Model.Member GetModel(int ID)
		{
			
			DataSet ds = dal.GetModel(ID);
			List<GK2010.Model.Member> models = DataTableToList(ds.Tables[0]);
			if (models.Count > 0)
			{
				return models[0];
			}
			else
			{
				return null;
			}
		}
		#endregion
		
		#region  得到一个对象实体(关键字)
		/// <summary>
		/// 得到一个对象实体(关键字)
		/// </summary>
		public GK2010.Model.Member GetModel(string Keywords)
		{
			DataSet ds = dal.GetList(Keywords, "Keywords");
			List<GK2010.Model.Member> models = DataTableToList(ds.Tables[0]);
			if (models.Count > 0)
			{
				return models[0];
			}
			else
			{
				return null;
			}
		}
		#endregion

		#region  得到一个对象实体，从缓存中
		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public GK2010.Model.Member GetModelByCache(int ID)
		{
			
			string CacheKey = "MemberModel-" + ID;
			object objModel = Utility.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Utility.ConfigHelper.GetConfigInt("ModelCache");
						Utility.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (GK2010.Model.Member)objModel;
		}
		#endregion

		#region  列表(不分页)
		/// <summary>
		/// 列表(不分页)
		/// </summary>
		public List<GK2010.Model.Member> GetList(string Keywords, string Type)
		{
			DataSet ds = dal.GetList(Keywords,Type);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  列表(不分页)获取Tabel
		/// <summary>
		/// 列表(不分页)获取Tabel
		/// </summary>
		public DataTable GetTable(string Keywords, string Type)
		{
			DataSet ds = dal.GetList(Keywords,Type);
			return ds.Tables[0];
		}
		#endregion

		#region  获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GK2010.Model.Member> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  转换数据列表
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.Member> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// 转换数据列表
		/// </summary>
		public List<GK2010.Model.Member> DataTableToList(DataRow[] drs)
		{
			List<GK2010.Model.Member> modelList = new List<GK2010.Model.Member>();
			GK2010.Model.Member model;
			foreach (DataRow dr in drs)
			{
				model = new GK2010.Model.Member();
				if(dr["ID"].ToString()!="")
				{
					model.ID=int.Parse(dr["ID"].ToString());
				}
				if(dr["GroupID"].ToString()!="")
				{
					model.GroupID=int.Parse(dr["GroupID"].ToString());
				}
				model.UserName=dr["UserName"].ToString();
				model.UserPwd=dr["UserPwd"].ToString();
				model.ProvinceID=dr["ProvinceID"].ToString();
				model.CityID=dr["CityID"].ToString();
				model.AreaID=dr["AreaID"].ToString();
				model.Company=dr["Company"].ToString();
				model.RealName=dr["RealName"].ToString();
				model.Email=dr["Email"].ToString();
				model.Telephone=dr["Telephone"].ToString();
				model.Mobile=dr["Mobile"].ToString();
				model.Address=dr["Address"].ToString();
				model.PostCode=dr["PostCode"].ToString();
				if(dr["RegisterDate"].ToString()!="")
				{
					model.RegisterDate=long.Parse(dr["RegisterDate"].ToString());
				}
				model.RegisterIP=dr["RegisterIP"].ToString();
				model.LastIP=dr["LastIP"].ToString();
				if(dr["LastDate"].ToString()!="")
				{
					model.LastDate=long.Parse(dr["LastDate"].ToString());
				}
				if(dr["MobileFlag"].ToString()!="")
				{
					model.MobileFlag=int.Parse(dr["MobileFlag"].ToString());
				}
				if(dr["EmailFlag"].ToString()!="")
				{
					model.EmailFlag=int.Parse(dr["EmailFlag"].ToString());
				}
				if(dr["VIPFlag"].ToString()!="")
				{
					model.VIPFlag=int.Parse(dr["VIPFlag"].ToString());
				}
				if(dr["AdminFlag"].ToString()!="")
				{
					model.AdminFlag=int.Parse(dr["AdminFlag"].ToString());
				}
				if(dr["LockFlag"].ToString()!="")
				{
					model.LockFlag=int.Parse(dr["LockFlag"].ToString());
				}
				if(dr["TotalOrder"].ToString()!="")
				{
					model.TotalOrder=int.Parse(dr["TotalOrder"].ToString());
				}
				if(dr["TotalJF"].ToString()!="")
				{
					model.TotalJF=decimal.Parse(dr["TotalJF"].ToString());
				}

                if (model.Mobile.Length > 0)
                {
                    model.Mobile = Utility.DEncryptHelper.DESEncrypt.Decrypt(model.Mobile);
                }
                if (model.Email.Length > 0)
                {
                    model.Email = Utility.DEncryptHelper.DESEncrypt.Decrypt(model.Email);
                }
				modelList.Add(model);
			}
			return modelList;
		}
		#endregion

		#endregion  成员方法

        #region 其他方法

        #region  根据用户名|邮箱|手机获取用户对象
       /// <summary>
       /// 根据用户名|邮箱|手机获取用户对象
       /// </summary>
       /// <param name="EnumLoginType">登录类型</param>
       /// <param name="strValue">登录值</param>
       /// <returns></returns>
        public GK2010.Model.Member GetModel(EnumLoginType EnumLoginType, string strValue)
        {
            if (EnumLoginType == EnumLoginType.UserName)
            {
                DataSet ds = dal.GetModelByUserName(strValue);
                List<GK2010.Model.Member> models = DataTableToList(ds.Tables[0]);
                if (models.Count > 0)
                {
                    return models[0];
                }
            }
            if (EnumLoginType == EnumLoginType.Email)
            {
                strValue = GK2010.Utility.DEncryptHelper.DESEncrypt.Encrypt(strValue);
                DataSet ds = dal.GetModelByEmail(strValue);
                List<GK2010.Model.Member> models = DataTableToList(ds.Tables[0]);
                if (models.Count > 0)
                {
                    return models[0];
                }
            }
            if (EnumLoginType == EnumLoginType.Mobile)
            {
                strValue = GK2010.Utility.DEncryptHelper.DESEncrypt.Encrypt(strValue);
                DataSet ds = dal.GetModelByMobile(strValue);
                List<GK2010.Model.Member> models = DataTableToList(ds.Tables[0]);
                if (models.Count > 0)
                {
                    return models[0];
                }
            }

            return null;            
        }

       
        #endregion   
   
        #region 获取用户编号
         /// <summary>
        ///获取用户编号
        /// </summary>
        /// <param name="EnumLoginType">登录类型</param>
        /// <param name="strValue">登录值</param>
        /// <returns></returns>
        public static int GetUserID(EnumLoginType EnumLoginType, string strValue)
        {
            GK2010.BLL.Member bll = new GK2010.BLL.Member();
            GK2010.Model.Member model = bll.GetModel(EnumLoginType, strValue);
            if (model != null)
            {
                return model.ID;
            }         

            return 0;            
        }
        #endregion

        #region 获取用户名
        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <param name="ID">用户编号</param>
        /// <returns>用户名</returns>
        public static string GetUserName(int ID)
        {
            GK2010.BLL.Member bll = new GK2010.BLL.Member();
            GK2010.Model.Member model = bll.GetModel(ID);
            if (model != null)
            {
                return model.UserName;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <param name="ID">用户编号</param>
        /// <returns>用户名</returns>
        public static string GetUserName(object ID)
        {
            return GetUserName(IntHelper.Parse(ID, 0));
        }
        #endregion

        #region 获取真实姓名
        /// <summary>
        /// 获取真实姓名
        /// </summary>
        /// <param name="ID">用户编号</param>
        /// <returns>真实姓名</returns>
        public static string GetRealName(int ID)
        {
            GK2010.BLL.Member bll = new GK2010.BLL.Member();
            GK2010.Model.Member model = bll.GetModel(ID);
            if (model != null)
            {
                return model.RealName;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 获取真实姓名
        /// </summary>
        /// <param name="ID">用户编号</param>
        /// <returns>真实姓名</returns>
        public static string GetRealName(object ID)
        {
            return GetRealName(IntHelper.Parse(ID, 0));
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
            if (LoginType == EnumLoginType.Email || LoginType == EnumLoginType.Mobile)
            {
                //加密
                UserName = Utility.DEncryptHelper.DESEncrypt.Encrypt(UserName);
            }
            return dal.CheckUserName(UserName, LoginType);
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
        public Model.Member Login(string UserName, string UserPwd)
        {
            EnumLoginType LoginType = EnumLoginType.UserName;
            if (ValidateHelper.IsEmail(UserName))
            {
                LoginType = EnumLoginType.Email;
                UserName = Utility.DEncryptHelper.DESEncrypt.Encrypt(UserName);
            }
            if (ValidateHelper.IsMobile(UserName))
            {
                LoginType = EnumLoginType.Mobile;
                UserName = Utility.DEncryptHelper.DESEncrypt.Encrypt(UserName);
            }

            UserPwd = Utility.DEncryptHelper.MD5.Encrypt(UserPwd);

            int UserID = dal.Login(UserName, UserPwd, LoginType);
            return GetModel(UserID);
        }
        #endregion

        #region  会员注册
        /// <summary>
        /// 会员注册
        /// </summary>
        /// <param name="strUserName">用户名</param>
        /// <param name="strUserPwd">密码</param>
        /// <param name="strProvinceID">省份</param>
        /// <param name="strCityID">城市</param>
        /// <param name="ReCommendUserID">推荐人</param>
        /// <returns>会员编号</returns>
        public int Register(Model.Member model)
        {
            return 0;
        }
        #endregion

        #region 手机是否验证
        public static bool IsMobile(int MemberID)
        {
            BLL.Member bll = new GK2010.BLL.Member();
            Model.Member model = bll.GetModel(MemberID);
            if (model != null)
            {
                return model.MobileFlag == 1;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 邮箱是否验证
        public static bool IsEmail(int MemberID)
        {
            BLL.Member bll = new GK2010.BLL.Member();
            Model.Member model = bll.GetModel(MemberID);
            if (model != null)
            {
                return model.EmailFlag == 1;
            }
            else
            {
                return false;
            }
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
            UserPwd = Utility.DEncryptHelper.MD5.Encrypt(UserPwd);//加密
            UserPwdOld = Utility.DEncryptHelper.MD5.Encrypt(UserPwdOld);//加密
            if (LoginType == EnumLoginType.Email || LoginType == EnumLoginType.Mobile)
            {
                UserName = Utility.DEncryptHelper.DESEncrypt.Encrypt(UserName);
            }
            return dal.SetPwd(UserName, UserPwd, UserPwdOld, LoginType);
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
            UserPwd = Utility.DEncryptHelper.MD5.Encrypt(UserPwd);//加密         
            if (LoginType == EnumLoginType.Email || LoginType == EnumLoginType.Mobile)
            {
                UserName = Utility.DEncryptHelper.DESEncrypt.Encrypt(UserName);
            }
            return dal.SetPwd(UserName, UserPwd, LoginType);
        }

        #endregion
      
        #endregion
    }
}

