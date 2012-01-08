using System.Web;
using System.Text;
using System.Security.Cryptography;
/// <summary>
/// ֧�����ӿ�
/// </summary>
namespace GK2010.Common
{
    public class AliPayHelper
    {
        /// <summary>
        /// ��ASP���ݵ�MD5�����㷨
        /// </summary>
        public static string GetMD5(string s, string _input_charset)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(s));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

        /// <summary>
        /// ð������
        /// ������ĸ���д�a��z��˳������
        /// </summary>
        public static string[] BubbleSort(string[] r)
        {
            int i, j; //������־ 
            string temp;

            bool exchange;

            for (i = 0; i < r.Length; i++) //�����R.Length-1������ 
            {
                exchange = false; //��������ʼǰ��������־ӦΪ��

                for (j = r.Length - 2; j >= i; j--)
                {
                    if (System.String.CompareOrdinal(r[j + 1], r[j]) < 0)��//��������
                    {
                        temp = r[j + 1];
                        r[j + 1] = r[j];
                        r[j] = temp;

                        exchange = true; //�����˽������ʽ�������־��Ϊ�� 
                    }
                }

                if (!exchange) //��������δ������������ǰ��ֹ�㷨 
                {
                    break;
                }
            }
            return r;
        }

        /// <summary>
        /// URL��������
        /// </summary>
        /// <param name="gateway">����</param>
        /// <param name="service">�������</param>
        /// <param name="partner">�������ID</param>
        /// <param name="sign_type">��������</param>
        /// <param name="batch_no">������</param>
        /// <param name="account_name">��ʵ������˾��</param>
        /// <param name="batch_fee">�ܽ��</param>
        /// <param name="batch_num">�ܱ���</param>
        /// <param name="email">������֧�����ʺ�</param>
        /// <param name="pay_date">����ʱ��</param>
        /// <param name="detail_data">��ϸ</param>
        /// <param name="notify_url">����֪ͨҳ</param>
        /// <param name="key">��ȫУ����   </param>
        /// <param name="_input_charset">�����ʽ</param>
        /// <returns>���ɵ�URL�����ַ�����MD5���ܽ���ַ���</returns>
        public static string CreatUrl(
            string gateway, 
            string service, 
            string partner,
            string sign_type,

            string batch_no,
            string account_name,
            string batch_fee,
            string batch_num,
            string email,
            string pay_date,
            string detail_data,

            string notify_url,
            string key, 
            string _input_charset
            )
        {
            int i;

            //�������飻
            //�������鼴�ǲ�����ܵĲ�������������ֵ������Ϊ�գ����ò���Ϊ�գ���Ҫ��Ϊ�������Ԫ��
                string[] Oristr ={ 
                "service="+service, 
                "partner=" + partner, 
                "batch_no=" + batch_no, 
                "account_name=" + account_name, 
                "batch_fee=" + batch_fee,  
                "batch_num=" + batch_num, 
                "email=" + email, 
                "pay_date=" + pay_date,
                "detail_data=" + detail_data,
                "notify_url=" + notify_url,
                "_input_charset="+_input_charset
                };
            
            //��������
            string[] Sortedstr = BubbleSort(Oristr);


            //�����md5ժҪ�ַ��� ��

            StringBuilder prestr = new StringBuilder();

            for (i = 0; i < Sortedstr.Length; i++)
            {
                if (i == Sortedstr.Length - 1)
                {
                    prestr.Append(Sortedstr[i]);
                }
                else
                {
                    prestr.Append(Sortedstr[i] + "&");
                }
            }

            prestr.Append(key);

            //����Md5ժҪ��
            string sign = GetMD5(prestr.ToString(), _input_charset);

            //������POST��ʽ���ݲ���
            return sign;

            //������GET��ʽ���ݲ���

            //����֧��Url��
            //StringBuilder parameter = new StringBuilder();
            //parameter.Append(gateway);
            //for (i = 0; i < Sortedstr.Length; i++)
            //{
            //    parameter.Append(Sortedstr[i] + "&");
            //}

            //parameter.Append("sign=" + sign + "&sign_type=" + sign_type);

            ////����֧��Url��
            //return parameter.ToString();
        }

    }
}