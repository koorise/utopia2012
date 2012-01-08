using System;
using System.Configuration;
using System.Collections.Generic;
namespace GK2010.Utility
{
	/// <summary>
    /// 字符串综合处理类
	/// </summary>
    public class StringHelper
	{
        #region 删除最后一个字符
        public static string DelLastChar(object strKey)
        {
            return DelLastChar(strKey.ToString(), ",");
        }

        /// <summary>
        /// 删除最后一个字符串
        /// </summary>
        /// <param name="strKey">原始字符串</param>
        /// <returns>过滤后的字符串</returns>
        public static string DelLastChar(string strKey)
        {
            return DelLastChar(strKey, ",");
        }

        /// <summary>
        /// 删除最后一个字符
        /// </summary>
        /// <param name="strKey">原始字符串</param>
        /// <param name="strSeperator">分隔符</param>
        /// <returns>过滤后的字符串</returns>
        public static string DelLastChar(string strKey, string strSeperator)
        {            
            if (strKey.EndsWith(strSeperator))
            {
                return strKey.Substring(0, strKey.Length - 1);
            }
            return strKey;
        }		
        #endregion

        #region 把字符串分隔成整形泛型

        public static List<int> ToIntList(string strKey)
        {
            return ToIntList(strKey, ',');
        }

        public static List<int> ToIntList(string strKey, char strSeperator)
        {
            List<int> models = new List<int>();
            string[] strs = strKey.Split(strSeperator);

            foreach (string s in strs)
            {
                models.Add(int.Parse(s));
            }
            return models;
        }
        #endregion

        #region 把字符串分隔成字符串泛型

        public static List<string> ToStrList(string strKey)
        {
            return ToStrList(strKey, ',');
        }

        public static List<string> ToStrList(string strKey, char strSeperator)
        {
            List<string> models = new List<string>();
            string[] strs = strKey.Split(strSeperator);
            foreach (string s in strs)
            {
                models.Add(s);
            }
            return models;
        }
        #endregion

        #region 获取分隔线
        public static string GetStrLine(object ID, object Path)
        {
            return GetStrLine(int.Parse(ID.ToString()), Path.ToString());
        }
        public static string GetStrLine(int ID, string Path)
        {
            
            int Len = Path.Split(',').Length;
            if (Len == 1)
            {
                return "<i id=\"bt_" + ID + "\" class=\"expand expand_b\" ></i>";
            }
            if (Len == 2)
            {
                return "<i class=\"lower\"></i>";
            }
            if (Len == 3)
            {
                return "<i class=\"lower lower_a\"></i><i class=\"lower\"></i>";
            }
            if (Len == 4)
            {
                return "<i class=\"lower lower_a\"></i><i class=\"lower lower_a\"></i><i class=\"lower\"></i>";
            }
            return "";
            
        }
        #endregion

        #region 获取添加字符串
       

        public static string GetStrAdd(object ID, object Path)
        {
            return GetStrAdd(int.Parse(ID.ToString()), Path.ToString(),3);
        }
        public static string GetStrAdd(object ID, object Path, int DefaultLen)
        {
            return GetStrAdd(int.Parse(ID.ToString()), Path.ToString(), DefaultLen);
        }
        public static string GetStrAdd(int ID, string Path, int DefaultLen)
        {
            int Len = Path.Split(',').Length;
            if (Len >= DefaultLen)
            {
                return "";
            }
            else
            {
                return "<a href=\"add.aspx?ParentID=" + ID + "\" id=\"addbt_" + ID + "\" title=\"添加新栏目\" style=\"display:none;\">添加新栏目</a>";
            }
        }
        #endregion

        #region 获取带有Flag字段的值是否
        public static string GetStrFlag(object Flag)
        {
            if (Flag == null) return "";       
            return GetStrFlag(IntHelper.Parse(Flag,0), "是");
        }
        public static string GetStrFlag(int Flag)
        {
            return GetStrFlag(Flag, "是");
        }
        public static string GetStrFlag(object Flag,string defaultValue)
        {
            if (Flag == null) return defaultValue;
            return GetStrFlag(int.Parse(Flag.ToString()), defaultValue);
        }
        public static string GetStrFlag(int Flag, string defaultValue)
        {
            if (Flag == 1)
            {
                return "<span style='color:green'>" + defaultValue + "</span>";
            }
            else
            {
                return "<span style='color:red'></span>";
            }
        }

        /// <summary>
        /// 取值
        /// </summary>
        /// <param name="Flag">值</param>
        /// <param name="strYesValue">是</param>
        /// <param name="strNOValue">否</param>
        /// <returns></returns>
        public static string GetStrFlag(object Flag, string strYesValue,string strNOValue)
        {
            if (Flag == null) return "";
            if (Flag.ToString() == "1")
            {
                return "<span style='color:green'>" + strYesValue + "</span>"; ;
            }
            if (Flag.ToString() == "0")
            {
                return "<span style='color:red'>" + strNOValue + "</span>"; ;
            }
            return "";
        }
        public static string GetStrFlag(object Flag, string strYesValue, string strNOValue,string strInitValue)
        {
            if (Flag == null) return "";
            if (Flag.ToString() == "0")
            {
                return "<span style='color:blue'>" + strInitValue + "</span>"; ;
            }
            if (Flag.ToString() == "1")
            {
                return "<span style='color:green'>" + strYesValue + "</span>"; ;
            }
            if (Flag.ToString() == "2")
            {
                return "<span style='color:red'>" + strNOValue + "</span>"; ;
            }
            return "";
        }
        #endregion       

        #region 过滤SQL字符串
        public static string SQLFilter(string strSql)
        {
            strSql = strSql.Replace("'","''");
            strSql = strSql.Replace(":", "");
            strSql = strSql.Replace("-", "");
            strSql = strSql.Replace("%", "");
            return strSql;
        }
        #endregion


        #region 取随机数
        public static string Radmon(int codeLen)
        {
            string codeSerial = "0,1,2,3,4,5,6,7,8,9";
            string[] arr = codeSerial.Split(',');

            string code = "";
            int randValue = -1;
            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < codeLen; i++)
            {
                randValue = rand.Next(0, arr.Length - 1);
                code += arr[randValue];
            }

            return code;
        }
        #endregion

        #region 取随机金额数
        /// <summary>
        /// 取随机金额数(金额0.01-0.39)
        /// </summary>
        /// <returns>(金额0.01-0.39)</returns>
        public static decimal RadmonPrice()
        {
            int codeLen = 2;

            string codeSerial0 = "0,1,2,3";
            string[] arr0 = codeSerial0.Split(',');

            string codeSerial1 = "1,2,3,4,5,6,7,8,9";
            string[] arr1 = codeSerial1.Split(',');

         

            string code = "";
            int randValue = -1;
            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < codeLen; i++)
            {
                if (i == 0)
                {
                    randValue = rand.Next(0, arr0.Length - 1);
                    code += arr0[randValue];
                }
                if (i == 1)
                {
                    randValue = rand.Next(0, arr1.Length - 1);
                    code += arr1[randValue];
                }
            }
            code = "0." + code;
            return decimal.Parse(code);
        }
        #endregion

        #region 取邮箱登录地址
        public static string EmailSuffix(string Email)
        {
            if (Email.IndexOf("@")>0)
            {
                Email = Email.Split('@')[1];
            }

            return "http://mail."+Email;
        }
        #endregion

        #region 搜索文本替换颜色
        /// <summary>
        /// 搜索文本替换颜色
        /// </summary>
        /// <param name="objOld">原始文本</param>
        /// <param name="ojbReplace">待替换的文本</param>
        /// <returns></returns>
        public static string SearchText(object objOld,object ojbReplace)
        {
            string strOld = objOld.ToString();           
            string strReplace = ojbReplace.ToString();

             if(strOld.Length > 0 && strReplace.Length > 0)
                strOld = strOld.Replace(strReplace, "<span style='color:red'>" + strReplace + "</span>");
            return strOld;
        }
        #endregion

        #region 图片
        /// <summary>
        /// 若有图片，则显示图标，否则为空
        /// </summary>
        /// <param name="strPic"></param>
        /// <returns></returns>
        public static string GetPicture(string strPic)
        {
            if (strPic != "")
            {
                return "<img src='/images/ico_photo.gif' />";
            }
            return "";
        }
        /// <summary>
        /// 若有图片，则显示图标，否则为空
        /// </summary>
        /// <param name="strPic"></param>
        /// <returns></returns>
        public static string GetPicture(object strPic)
        {
            return GetPicture(strPic.ToString());
        }

        /// <summary>
        /// 获取100*100的图片
        /// </summary>
        /// <param name="strPic"></param>
        /// <returns></returns>
        public static string GetPicture_100_100(string strPic)
        {
            if (strPic == "")
            {
                return "/images/nopic_100_100.jpg";
            }
            return strPic;
        }
        /// <summary>
        /// 获取100*100的图片
        /// </summary>
        /// <param name="strPic"></param>
        /// <returns></returns>
        public static string GetPicture_100_100(object strPic)
        {
            return GetPicture_100_100(strPic.ToString());
        }

        /// <summary>
        /// 获取120*120的图片
        /// </summary>
        /// <param name="strPic"></param>
        /// <returns></returns>
        public static string GetPicture_120_120(string strPic)
        {
            if (strPic == "")
            {
                return "/images/nopic_120_120.jpg";
            }
            return strPic;
        }
        /// <summary>
        /// 获取120*120的图片
        /// </summary>
        /// <param name="strPic"></param>
        /// <returns></returns>
        public static string GetPicture_120_120(object strPic)
        {
            return GetPicture_120_120(strPic.ToString());
        }
        #endregion

        #region 截取字符串
        /// <summary>
        /// 根据字节数获取指定字符串
        /// </summary>
        /// <param name="strObject">字符串</param>
        /// <param name="Length">字节数</param>
        /// <returns>新的字符串不带省略号</returns>
        public static string SubString(object strObject, int Length)
        {
            return SubString(strObject, Length, 0);
        }

        /// <summary>
        /// 根据字节数获取指定字符串
        /// </summary>
        /// <param name="strObject">字符串</param>
        /// <param name="Length">字节数</param>
        /// <param name="Flag">1带省略号,0不带省略号</param>
        /// <returns></returns>
        public static string SubString(object strObject, int Length, int Flag)
        {
            string str = strObject.ToString();
            int i = 0;
            int j = 0;
            foreach (char Char in str)
            {
                if ((int)Char > 127)
                {
                    i += 2;
                }
                else
                {
                    i++;
                }

                if (i > Length)
                {
                    str = str.Substring(0, j) + (Flag == 1 ? "…" : "");
                    break;
                }

                j++;
            }
            return str;
        }
        #endregion

        #region Json
        public static string CreareJson(string Result, int State)
        {
            //注意，整型和字符型不一样
            return "{\"Result\":\"" + Result + "\",\"State\":" + State + "}";

        }
        #endregion

        
	}
}
