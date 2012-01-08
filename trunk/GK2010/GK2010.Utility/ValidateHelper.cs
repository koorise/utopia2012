using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace GK2010.Utility
{
    public class ValidateHelper
    {
        #region 邮箱格式
        public static bool IsEmail(string str)
        {
            return Regex.IsMatch(str, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", RegexOptions.IgnoreCase);
        }
        #endregion

        #region 手机格式
        public static bool IsMobile(string str)
        {
            return Regex.IsMatch(str, @"^1[358]\d{9}$", RegexOptions.IgnoreCase);

        }
        #endregion
    }
}
