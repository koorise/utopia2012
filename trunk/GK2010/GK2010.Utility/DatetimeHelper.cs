using System;
using System.Configuration;
using System.Collections.Generic;
namespace GK2010.Utility
{
	/// <summary>
    /// �����ۺϴ�����
	/// </summary>
    public class DatetimeHelper
	{
        #region ��ǰ����
        public static long Now
        {
            get
            {
                return DateTime.Now.ToFileTime();
            }
        }
        #endregion

        #region ��ǰ���ں�30����
        public static long NowAfter30s
        {
            get
            {
                return DateTime.Now.AddMinutes(30).ToFileTime();
            }
        }
        #endregion


        #region ��ǰ���ں�һ��
        public static long NowAfterOneDay
        {
            get
            {
                return DateTime.Now.AddDays(1).ToFileTime();
            }
        }
        #endregion

        #region ��ǰ���ں�һ��
        public static long NowAfterOneMonth
        {
            get
            {
                return DateTime.Now.AddMonths(1).ToFileTime();
            }
        }
        #endregion


        #region ��ǰ���ں�һ��
        public static long NowAfterOneYear
        {
            get
            {
                return DateTime.Now.AddYears(1).ToFileTime();
            }
        }
        #endregion


        #region ת������Ϊ����
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
        /// ����ָ��ʱ���ƺ�ָ�������������ʱ��
        /// </summary>
        /// <param name="str">��ǰʱ��yyyy-MM-dd HH:mm</param>
        /// <param name="day">��������</param>
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
        /// ����ָ��ʱ���ƺ�ָ�������������ʱ��
        /// </summary>
        /// <param name="obj">��ǰʱ��yyyy-MM-dd HH:mm</param>
        /// <param name="day">��������</param>
        /// <returns></returns>
        public static long ParseToLong(object obj, int day)
        {
            return ParseToLong(obj.ToString(), day);
        }      
 
        #endregion


        #region ת������Ϊ����
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
