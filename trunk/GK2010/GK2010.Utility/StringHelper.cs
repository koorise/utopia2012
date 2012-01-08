using System;
using System.Configuration;
using System.Collections.Generic;
namespace GK2010.Utility
{
	/// <summary>
    /// �ַ����ۺϴ�����
	/// </summary>
    public class StringHelper
	{
        #region ɾ�����һ���ַ�
        public static string DelLastChar(object strKey)
        {
            return DelLastChar(strKey.ToString(), ",");
        }

        /// <summary>
        /// ɾ�����һ���ַ���
        /// </summary>
        /// <param name="strKey">ԭʼ�ַ���</param>
        /// <returns>���˺���ַ���</returns>
        public static string DelLastChar(string strKey)
        {
            return DelLastChar(strKey, ",");
        }

        /// <summary>
        /// ɾ�����һ���ַ�
        /// </summary>
        /// <param name="strKey">ԭʼ�ַ���</param>
        /// <param name="strSeperator">�ָ���</param>
        /// <returns>���˺���ַ���</returns>
        public static string DelLastChar(string strKey, string strSeperator)
        {            
            if (strKey.EndsWith(strSeperator))
            {
                return strKey.Substring(0, strKey.Length - 1);
            }
            return strKey;
        }		
        #endregion

        #region ���ַ����ָ������η���

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

        #region ���ַ����ָ����ַ�������

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

        #region ��ȡ�ָ���
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

        #region ��ȡ����ַ���
       

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
                return "<a href=\"add.aspx?ParentID=" + ID + "\" id=\"addbt_" + ID + "\" title=\"�������Ŀ\" style=\"display:none;\">�������Ŀ</a>";
            }
        }
        #endregion

        #region ��ȡ����Flag�ֶε�ֵ�Ƿ�
        public static string GetStrFlag(object Flag)
        {
            if (Flag == null) return "";       
            return GetStrFlag(IntHelper.Parse(Flag,0), "��");
        }
        public static string GetStrFlag(int Flag)
        {
            return GetStrFlag(Flag, "��");
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
        /// ȡֵ
        /// </summary>
        /// <param name="Flag">ֵ</param>
        /// <param name="strYesValue">��</param>
        /// <param name="strNOValue">��</param>
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

        #region ����SQL�ַ���
        public static string SQLFilter(string strSql)
        {
            strSql = strSql.Replace("'","''");
            strSql = strSql.Replace(":", "");
            strSql = strSql.Replace("-", "");
            strSql = strSql.Replace("%", "");
            return strSql;
        }
        #endregion


        #region ȡ�����
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

        #region ȡ��������
        /// <summary>
        /// ȡ��������(���0.01-0.39)
        /// </summary>
        /// <returns>(���0.01-0.39)</returns>
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

        #region ȡ�����¼��ַ
        public static string EmailSuffix(string Email)
        {
            if (Email.IndexOf("@")>0)
            {
                Email = Email.Split('@')[1];
            }

            return "http://mail."+Email;
        }
        #endregion

        #region �����ı��滻��ɫ
        /// <summary>
        /// �����ı��滻��ɫ
        /// </summary>
        /// <param name="objOld">ԭʼ�ı�</param>
        /// <param name="ojbReplace">���滻���ı�</param>
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

        #region ͼƬ
        /// <summary>
        /// ����ͼƬ������ʾͼ�꣬����Ϊ��
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
        /// ����ͼƬ������ʾͼ�꣬����Ϊ��
        /// </summary>
        /// <param name="strPic"></param>
        /// <returns></returns>
        public static string GetPicture(object strPic)
        {
            return GetPicture(strPic.ToString());
        }

        /// <summary>
        /// ��ȡ100*100��ͼƬ
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
        /// ��ȡ100*100��ͼƬ
        /// </summary>
        /// <param name="strPic"></param>
        /// <returns></returns>
        public static string GetPicture_100_100(object strPic)
        {
            return GetPicture_100_100(strPic.ToString());
        }

        /// <summary>
        /// ��ȡ120*120��ͼƬ
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
        /// ��ȡ120*120��ͼƬ
        /// </summary>
        /// <param name="strPic"></param>
        /// <returns></returns>
        public static string GetPicture_120_120(object strPic)
        {
            return GetPicture_120_120(strPic.ToString());
        }
        #endregion

        #region ��ȡ�ַ���
        /// <summary>
        /// �����ֽ�����ȡָ���ַ���
        /// </summary>
        /// <param name="strObject">�ַ���</param>
        /// <param name="Length">�ֽ���</param>
        /// <returns>�µ��ַ�������ʡ�Ժ�</returns>
        public static string SubString(object strObject, int Length)
        {
            return SubString(strObject, Length, 0);
        }

        /// <summary>
        /// �����ֽ�����ȡָ���ַ���
        /// </summary>
        /// <param name="strObject">�ַ���</param>
        /// <param name="Length">�ֽ���</param>
        /// <param name="Flag">1��ʡ�Ժ�,0����ʡ�Ժ�</param>
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
                    str = str.Substring(0, j) + (Flag == 1 ? "��" : "");
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
            //ע�⣬���ͺ��ַ��Ͳ�һ��
            return "{\"Result\":\"" + Result + "\",\"State\":" + State + "}";

        }
        #endregion

        
	}
}
