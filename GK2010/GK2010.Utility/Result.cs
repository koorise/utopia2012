using System;
using System.Configuration;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace GK2010.Utility
{
    #region �������
    [Serializable]
    /// <summary>
    /// �������
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
        #region ���������ʾ
        public static string DeleteConfirm = "��ȷ��Ҫɾ����";//ɾ��ȷ��
        public static string DeleteSingleSuccess = "�ɹ�ɾ��1����¼!";//ɾ������
        public static string DeleteBatchSuccess = "�ɹ�ɾ��{0}����¼!";//ɾ������
        public static string DeleteFail = "����ʧ�ܣ�δ��ɾ����Ϣ!";//ɾ��ʧ��

        public static string ModifySingleSuccess = "�ɹ��޸�1����Ϣ!";//�޸ĵ���
        public static string ModifyBatchSuccess = "�ɹ��޸�{0}����Ϣ!";//�޸�����
        public static string ModifyFail = "����ʧ�ܣ�δ���޸���Ϣ!";//�޸�ʧ��


        public static string AddSingleSuccess = "�ɹ����1����Ϣ";//��ӵ���
        public static string AddBatchSuccess = "�ɹ����{0}����Ϣ";//�������
        public static string AddFail = "����ʧ�ܣ�δ�������Ϣ";//���ʧ��

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
        /// ���л� �����ַ���
        /// </summary>
        /// <param name="obj">���Ͷ���</param>
        /// <returns>���л�����ַ���</returns>
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
                throw new Exception("���л�ʧ��,ԭ��:" + ex.Message);
            }
        }

        /// <summary>
        /// �����л� �ַ���������
        /// </summary>
        /// <param name="obj">���Ͷ���</param>
        /// <param name="str">Ҫת��Ϊ������ַ���</param>
        /// <returns>�����л������Ķ���</returns>
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
                throw new Exception("�����л�ʧ��,ԭ��:" + ex.Message);
            }
            return result;
        }
    }
    #endregion
    

}
