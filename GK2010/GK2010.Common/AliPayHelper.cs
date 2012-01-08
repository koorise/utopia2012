using System.Web;
using System.Text;
using System.Security.Cryptography;
/// <summary>
/// 支付宝接口
/// </summary>
namespace GK2010.Common
{
    public class AliPayHelper
    {
        /// <summary>
        /// 与ASP兼容的MD5加密算法
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
        /// 冒泡排序法
        /// 按照字母序列从a到z的顺序排列
        /// </summary>
        public static string[] BubbleSort(string[] r)
        {
            int i, j; //交换标志 
            string temp;

            bool exchange;

            for (i = 0; i < r.Length; i++) //最多做R.Length-1趟排序 
            {
                exchange = false; //本趟排序开始前，交换标志应为假

                for (j = r.Length - 2; j >= i; j--)
                {
                    if (System.String.CompareOrdinal(r[j + 1], r[j]) < 0)　//交换条件
                    {
                        temp = r[j + 1];
                        r[j + 1] = r[j];
                        r[j] = temp;

                        exchange = true; //发生了交换，故将交换标志置为真 
                    }
                }

                if (!exchange) //本趟排序未发生交换，提前终止算法 
                {
                    break;
                }
            }
            return r;
        }

        /// <summary>
        /// URL链接生成
        /// </summary>
        /// <param name="gateway">网关</param>
        /// <param name="service">服务参数</param>
        /// <param name="partner">合作伙伴ID</param>
        /// <param name="sign_type">加密类型</param>
        /// <param name="batch_no">订单号</param>
        /// <param name="account_name">真实姓名或公司名</param>
        /// <param name="batch_fee">总金额</param>
        /// <param name="batch_num">总笔数</param>
        /// <param name="email">付款人支付宝帐号</param>
        /// <param name="pay_date">付款时间</param>
        /// <param name="detail_data">详细</param>
        /// <param name="notify_url">请求通知页</param>
        /// <param name="key">安全校验玛   </param>
        /// <param name="_input_charset">编码格式</param>
        /// <returns>生成的URL链接字符串或MD5加密结果字符串</returns>
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

            //构造数组；
            //以下数组即是参与加密的参数，若参数的值不允许为空，若该参数为空，则不要成为该数组的元素
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
            
            //进行排序；
            string[] Sortedstr = BubbleSort(Oristr);


            //构造待md5摘要字符串 ；

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

            //生成Md5摘要；
            string sign = GetMD5(prestr.ToString(), _input_charset);

            //以下是POST方式传递参数
            return sign;

            //以下是GET方式传递参数

            //构造支付Url；
            //StringBuilder parameter = new StringBuilder();
            //parameter.Append(gateway);
            //for (i = 0; i < Sortedstr.Length; i++)
            //{
            //    parameter.Append(Sortedstr[i] + "&");
            //}

            //parameter.Append("sign=" + sign + "&sign_type=" + sign_type);

            ////返回支付Url；
            //return parameter.ToString();
        }

    }
}