using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using GK2010.Model;
using GK2010.Utility;
namespace GK2010.BLL
{
	/// <summary>
	/// ҵ���߼���Member ��ժҪ˵����
	/// </summary>
	public class Member
	{
		#region  ˽�б���
		private readonly GK2010.DAL.Member dal=new GK2010.DAL.Member();
		#endregion
		
		#region  ���캯��
		public Member()
		{}
		#endregion		
		
		#region  ��Ա����

		#region  �Ƿ���ڸü�¼
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}
		#endregion  �Ƿ���ڸü�¼

		#region  ����һ������
		/// <summary>
		/// ����һ������
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

		#region  ����һ������
		/// <summary>
		/// ����һ������
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

		#region  ɾ��һ������
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		#endregion

		#region  �õ�һ������ʵ��
		/// <summary>
		/// �õ�һ������ʵ��
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
		
		#region  �õ�һ������ʵ��(�ؼ���)
		/// <summary>
		/// �õ�һ������ʵ��(�ؼ���)
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

		#region  �õ�һ������ʵ�壬�ӻ�����
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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

		#region  �б�(����ҳ)
		/// <summary>
		/// �б�(����ҳ)
		/// </summary>
		public List<GK2010.Model.Member> GetList(string Keywords, string Type)
		{
			DataSet ds = dal.GetList(Keywords,Type);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  �б�(����ҳ)��ȡTabel
		/// <summary>
		/// �б�(����ҳ)��ȡTabel
		/// </summary>
		public DataTable GetTable(string Keywords, string Type)
		{
			DataSet ds = dal.GetList(Keywords,Type);
			return ds.Tables[0];
		}
		#endregion

		#region  ��������б�
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<GK2010.Model.Member> GetList(int PageSize, int PageIndex, string Keywords,string Type, out int totalRows)
		{
			DataSet ds = dal.GetList(PageSize, PageIndex, Keywords,Type, out totalRows);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion

		#region  ת�������б�
		/// <summary>
		/// ת�������б�
		/// </summary>
		public List<GK2010.Model.Member> DataTableToList(DataTable dt)
		{
			return DataTableToList(dt.Select());
		}
		/// <summary>
		/// ת�������б�
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

		#endregion  ��Ա����

        #region ��������

        #region  �����û���|����|�ֻ���ȡ�û�����
       /// <summary>
       /// �����û���|����|�ֻ���ȡ�û�����
       /// </summary>
       /// <param name="EnumLoginType">��¼����</param>
       /// <param name="strValue">��¼ֵ</param>
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
   
        #region ��ȡ�û����
         /// <summary>
        ///��ȡ�û����
        /// </summary>
        /// <param name="EnumLoginType">��¼����</param>
        /// <param name="strValue">��¼ֵ</param>
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

        #region ��ȡ�û���
        /// <summary>
        /// ��ȡ�û���
        /// </summary>
        /// <param name="ID">�û����</param>
        /// <returns>�û���</returns>
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
        /// ��ȡ�û���
        /// </summary>
        /// <param name="ID">�û����</param>
        /// <returns>�û���</returns>
        public static string GetUserName(object ID)
        {
            return GetUserName(IntHelper.Parse(ID, 0));
        }
        #endregion

        #region ��ȡ��ʵ����
        /// <summary>
        /// ��ȡ��ʵ����
        /// </summary>
        /// <param name="ID">�û����</param>
        /// <returns>��ʵ����</returns>
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
        /// ��ȡ��ʵ����
        /// </summary>
        /// <param name="ID">�û����</param>
        /// <returns>��ʵ����</returns>
        public static string GetRealName(object ID)
        {
            return GetRealName(IntHelper.Parse(ID, 0));
        }
        #endregion       

        #region ����û���|�ֻ���|�����Ƿ����

        /// <summary>
        /// �ж��û���|�ֻ�|�����Ƿ����
        /// </summary>
        /// <param name="UserName">�û���|�ֻ�|����</param>
        /// <param name="LoginType">����</param>
        /// <returns>true|false</returns>
        public bool CheckUserName(string UserName, EnumLoginType LoginType)
        {
            if (LoginType == EnumLoginType.Email || LoginType == EnumLoginType.Mobile)
            {
                //����
                UserName = Utility.DEncryptHelper.DESEncrypt.Encrypt(UserName);
            }
            return dal.CheckUserName(UserName, LoginType);
        }
        #endregion


        #region ��Ա��¼
        /// <summary>
        /// ��Ա��¼
        /// </summary>
        /// <param name="UserName">��¼�˺�</param>
        /// <param name="UserPwd">��¼����</param>
        /// <param name="LoginType">��¼����</param>
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

        #region  ��Աע��
        /// <summary>
        /// ��Աע��
        /// </summary>
        /// <param name="strUserName">�û���</param>
        /// <param name="strUserPwd">����</param>
        /// <param name="strProvinceID">ʡ��</param>
        /// <param name="strCityID">����</param>
        /// <param name="ReCommendUserID">�Ƽ���</param>
        /// <returns>��Ա���</returns>
        public int Register(Model.Member model)
        {
            return 0;
        }
        #endregion

        #region �ֻ��Ƿ���֤
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

        #region �����Ƿ���֤
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
        

        #region �޸�����
        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="UserName">�˺�</param>
        /// <param name="UserPwd">������</param>
        /// <param name="UserPwd">������</param>
        /// <param name="LoginType">����</param>
        /// <returns>true|false</returns>
        public bool SetPwd(string UserName, string UserPwd, string UserPwdOld, EnumLoginType LoginType)
        {
            UserPwd = Utility.DEncryptHelper.MD5.Encrypt(UserPwd);//����
            UserPwdOld = Utility.DEncryptHelper.MD5.Encrypt(UserPwdOld);//����
            if (LoginType == EnumLoginType.Email || LoginType == EnumLoginType.Mobile)
            {
                UserName = Utility.DEncryptHelper.DESEncrypt.Encrypt(UserName);
            }
            return dal.SetPwd(UserName, UserPwd, UserPwdOld, LoginType);
        }

        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="UserName">�˺�</param>
        /// <param name="UserPwd">������</param>
        /// <param name="LoginType">����</param>
        /// <returns>true|false</returns>
        public bool SetPwd(string UserName, string UserPwd, EnumLoginType LoginType)
        {
            UserPwd = Utility.DEncryptHelper.MD5.Encrypt(UserPwd);//����         
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

