using System;
using System.Security.Cryptography;  
using System.Text;
using System.Web.Security;
namespace GK2010.Utility.DEncryptHelper
{
	/// <summary>
	/// MD5
	/// </summary>
	public class MD5
	{
        public MD5()
		{			
		}

        #region MD5º”√‹
        public static string Encrypt(string Text)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(Text, "MD5");
        }
        #endregion


	}
}
