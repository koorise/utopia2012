using System;
using System.Configuration;
using System.Collections.Generic;
namespace GK2010.Utility
{
	/// <summary>
    /// �����ۺϴ�����
	/// </summary>
    public class DecimalHelper
	{
        #region ת��һ���ַ���Ϊ����
       
        public static decimal Parse(string str,decimal defaultValue)
        {
            try
            {
                return decimal.Parse(str);
            }
            catch
            {
                return defaultValue;
            }           
        }       
        #endregion

       
        
	}
}
