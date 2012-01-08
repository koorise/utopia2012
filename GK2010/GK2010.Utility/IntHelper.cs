using System;
using System.Configuration;
using System.Collections.Generic;
namespace GK2010.Utility
{
	/// <summary>
    /// �����ۺϴ�����
	/// </summary>
    public class IntHelper
	{
        #region ת��һ���ַ���Ϊ����

        public static int Parse(string str, int defaultValue)
        {
            try
            {
                return int.Parse(str);
            }
            catch
            {
                return defaultValue;
            }           
        }
        public static int Parse(object obj, int defaultValue)
        {
            return Parse(obj.ToString(), defaultValue);
        }       
        #endregion       
        
	}
}
