using System;
using System.Configuration;
using System.Collections.Generic;
namespace GK2010.Utility
{
	/// <summary>
    /// 数字综合处理类
	/// </summary>
    public class IntHelper
	{
        #region 转换一个字符串为数字

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
