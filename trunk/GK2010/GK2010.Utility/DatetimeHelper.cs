using System;
using System.Configuration;
using System.Collections.Generic;
namespace GK2010.Utility
{
	/// <summary>
    /// 日期综合处理类
	/// </summary>
    public class DatetimeHelper
	{
        #region 当前日期
        public static long Now
        {
            get
            {
                return DateTime.Now.ToFileTime();
            }
        }
        #endregion

        #region 当前日期后30分钟
        public static long NowAfter30s
        {
            get
            {
                return DateTime.Now.AddMinutes(30).ToFileTime();
            }
        }
        #endregion


        #region 当前日期后一天
        public static long NowAfterOneDay
        {
            get
            {
                return DateTime.Now.AddDays(1).ToFileTime();
            }
        }
        #endregion

        #region 当前日期后一月
        public static long NowAfterOneMonth
        {
            get
            {
                return DateTime.Now.AddMonths(1).ToFileTime();
            }
        }
        #endregion


        #region 当前日期后一年
        public static long NowAfterOneYear
        {
            get
            {
                return DateTime.Now.AddYears(1).ToFileTime();
            }
        }
        #endregion


        #region 转换日期为数字
        public static long ParseToLong(string str)
        {
            try
            {
                
                return DateTime.Parse(str).ToFileTime();
            }
            catch
            {
                return 0;
            }
        }     
  
        public static long ParseToLong(object obj)
        {
            return ParseToLong(obj.ToString());  
        }

        /// <summary>
        /// 返回指定时间推后指定天数后的整数时间
        /// </summary>
        /// <param name="str">当前时间yyyy-MM-dd HH:mm</param>
        /// <param name="day">增长天数</param>
        /// <returns></returns>
        public static long ParseToLong(string str,int day)
        {
            try
            {

                return DateTime.Parse(str).AddDays(day).ToFileTime();
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 返回指定时间推后指定天数后的整数时间
        /// </summary>
        /// <param name="obj">当前时间yyyy-MM-dd HH:mm</param>
        /// <param name="day">增长天数</param>
        /// <returns></returns>
        public static long ParseToLong(object obj, int day)
        {
            return ParseToLong(obj.ToString(), day);
        }      
 
        #endregion


        #region 转换数字为日期
        public static string Parse(object obj, string strFormat)
        {
            
            return Parse(long.Parse(obj.ToString()),strFormat);            
        }
        public static string Parse(long l, string strFormat)
        {
            if (l <= 0)
                return "-";
            try
            {
                
                return DateTime.FromFileTime(l).ToString(strFormat);
            }
            catch
            {
                return "0";
            }
        }
        #endregion
	}
}
