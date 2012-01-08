using System;
using System.Configuration;
using System.Collections.Generic;
namespace GK2010.Utility
{
	/// <summary>
    /// 数字综合处理类
	/// </summary>
    public class DecimalHelper
	{
        #region 转换一个字符串为数字
       
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
