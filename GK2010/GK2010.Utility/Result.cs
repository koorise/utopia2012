using System;
using System.Configuration;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace GK2010.Utility
{
    #region 操作结果
    [Serializable]
    /// <summary>
    /// 操作结果
    /// </summary>
    public class Result
    {
        public int ResultID = 0;
        public ResultType ResultType;
        public ResultState ResultState;
        public string ResultMsg = "";
        public string ResultUrl = "";
        public object ResultObj = null;

        public Result()
        {}
    }
    #endregion

    #region ResultMsg
    public class ResultMsg
    {
        #region 操作结果提示
        public static string DeleteConfirm = "您确定要删除吗？";//删除确认
        public static string DeleteSingleSuccess = "成功删除1条记录!";//删除单条
        public static string DeleteBatchSuccess = "成功删除{0}条记录!";//删除批量
        public static string DeleteFail = "操作失败：未能删除信息!";//删除失败

        public static string ModifySingleSuccess = "成功修改1条信息!";//修改单条
        public static string ModifyBatchSuccess = "成功修改{0}条信息!";//修改批量
        public static string ModifyFail = "操作失败：未能修改信息!";//修改失败


        public static string AddSingleSuccess = "成功添加1条信息";//添加单条
        public static string AddBatchSuccess = "成功添加{0}条信息";//添加批量
        public static string AddFail = "操作失败：未能添加信息";//添加失败

        #endregion
    }
    #endregion

    #region ResultType
    [Serializable]
    public enum ResultType
    {
        Add,
        Modify,
        Delete,
        Manage
    }

    #endregion

    #region ResultState
    [Serializable]
    public enum ResultState
    {
        Success,
        Warning,
        Error
    }
    #endregion

    #region ResultSerialize
    public class ResultSerialize
    {
        /// <summary>
        /// 序列化 对象到字符串
        /// </summary>
        /// <param name="obj">泛型对象</param>
        /// <returns>序列化后的字符串</returns>
        public static string Serialize(Result result)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream();
                formatter.Serialize(stream, result);
                stream.Position = 0;
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                stream.Flush();
                stream.Close();
                return Convert.ToBase64String(buffer).Replace("+", "%2B");
            }
            catch (Exception ex)
            {
                throw new Exception("序列化失败,原因:" + ex.Message);
            }
        }

        /// <summary>
        /// 反序列化 字符串到对象
        /// </summary>
        /// <param name="obj">泛型对象</param>
        /// <param name="str">要转换为对象的字符串</param>
        /// <returns>反序列化出来的对象</returns>
        public static Result Desrialize(string str)
        {
            str = str.Replace("%2B", "+");
            Result result;
            try
            {
                IFormatter formatter = new BinaryFormatter();
                byte[] buffer = Convert.FromBase64String(str);
                MemoryStream stream = new MemoryStream(buffer);
                result = (Result)formatter.Deserialize(stream);
                stream.Flush();
                stream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("反序列化失败,原因:" + ex.Message);
            }
            return result;
        }
    }
    #endregion
    

}
