using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using System.Configuration;
using GK2010.Utility;
namespace GK2010.Common
{
    #region 邮件发送类
    public class EmailHelper
    {
        #region Field

        private string mMailFrom;
        private string mMailDisplyName;
        private string[] mMailTo;
        private string[] mMailCc;
        private string[] mMailBcc;
        private string mMailSubject;
        private string mMailBody;
        private string[] mMailAttachments;
        private string mSMTPServer;
        private int mSMTPPort;
        private string mSMTPUsername;
        private string mSMTPPassword;
        private bool mSMTPSSL;
        private MailPriority mPriority = MailPriority.Normal;
        private bool mIsBodyHtml = false;
        private MailMessage MailObject;
        bool mailSent = false;

        #endregion

        #region Properties

        /// <summary>
        /// 发件人地址
        /// </summary>
        private string MailFrom
        {
            set { mMailFrom = value; }
            get { return mMailFrom; }
        }

        /// <summary>
        /// 显示的名称
        /// </summary>
        private string MailDisplyName
        {
            set { mMailDisplyName = value; }
            get { return mMailDisplyName; }
        }

        /// <summary>
        /// 收件人地址
        /// </summary>
        private string[] MailTo
        {
            set { mMailTo = value; }
            get { return mMailTo; }
        }

        /// <summary>
        /// 抄送
        /// </summary>
        private string[] MailCc
        {
            set { mMailCc = value; }
            get { return mMailCc; }
        }

        /// <summary>
        /// 密件抄送
        /// </summary>
        private string[] MailBcc
        {
            set { mMailBcc = value; }
            get { return mMailBcc; }
        }

        /// <summary>
        /// 邮件主题
        /// </summary>
        private string MailSubject
        {
            set { mMailSubject = value; }
            get { return mMailSubject; }
        }

        /// <summary>
        /// 邮件正文
        /// </summary>
        private string MailBody
        {
            set { mMailBody = value; }
            get { return mMailBody; }
        }

        /// <summary>
        /// 附件
        /// </summary>
        private string[] MailAttachments
        {
            set { mMailAttachments = value; }
            get { return mMailAttachments; }
        }

        /// <summary>
        /// SMTP 服务器
        /// </summary>
        private string SMTPServer
        {
            set { mSMTPServer = value; }
            get { return mSMTPServer; }
        }

        /// <summary>
        /// 发送端口号(默认为 25)
        /// </summary>
        private int SMTPPort
        {
            set { mSMTPPort = value; }
            get { return mSMTPPort; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        private string SMTPUsername
        {
            set { mSMTPUsername = value; }
            get { return mSMTPUsername; }
        }

        /// <summary>
        /// 密码
        /// </summary>
        private string SMTPPassword
        {
            set { mSMTPPassword = value; }
            get { return mSMTPPassword; }
        }

        /// <summary>
        /// 是否使用安全套接字层 (SSL) 加密连接
        /// 默认为 false
        /// </summary>
        private Boolean SMTPSSL
        {
            set { mSMTPSSL = value; }
            get { return mSMTPSSL; }
        }

        /// <summary>
        /// 邮件的优先级
        /// </summary>
        private MailPriority Priority
        {
            get { return mPriority; }
            set { mPriority = value; }
        }

        /// <summary>
        /// 示邮件正文是否为 Html 格式的值
        /// </summary>
        private bool IsBodyHtml
        {
            get { return mIsBodyHtml; }
            set { mIsBodyHtml = value; }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// 邮件发送类
        /// 主机信息从配置文件中获取
        /// </summary>
        /// <param name="mailFrom">发件人地址</param>
        /// <param name="mailTo">收件人地址</param>
        /// <param name="mailSubject">邮件主题</param>
        /// <param name="mailBody">邮件正文</param>
        public EmailHelper(string[] mailTo, string mailSubject, string mailBody)
        {                     
            GK2010.BLL.Config bll = new GK2010.BLL.Config();
            GK2010.Model.Config model = bll.GetModel();
            if (model != null)
            {
                string EmailUserName = GK2010.Utility.DEncryptHelper.DESEncrypt.Decrypt(model.EmailUserName);
                string EmailUserPwd = GK2010.Utility.DEncryptHelper.DESEncrypt.Decrypt(model.EmailUserPwd);
                string EmailPort = GK2010.Utility.DEncryptHelper.DESEncrypt.Decrypt(model.EmailPort);
                string EmailHost = GK2010.Utility.DEncryptHelper.DESEncrypt.Decrypt(model.EmailHost);

                MailObject = new MailMessage();
                mMailFrom = EmailUserName;
                mMailDisplyName = EmailUserName;
                mMailTo = mailTo;
                mMailCc = null;
                mMailBcc = null;
                mMailSubject = mailSubject;
                mMailBody = mailBody;
                mMailAttachments = null;
                mSMTPServer = EmailHost;
                mSMTPPort = IntHelper.Parse( EmailPort,0);
                mSMTPUsername = EmailUserName;
                mSMTPPassword = EmailUserPwd;
                mSMTPSSL = false;
            }
            else
            {
                BLL.ConfigLog.Add("调用Config表中数据发生错误(邮箱)", "获取不到ID=1的记录",LoginHelper.UserID);               
            }   
        }

        /// <summary>
        /// 邮件发送类
        /// </summary>
        /// <param name="mailFrom">发件人地址</param>
        /// <param name="mailTo">收件人地址</param>
        /// <param name="mailSubject">邮件主题</param>
        /// <param name="mailBody">邮件正文</param>
        /// <param name="smtpServer">SMTP 服务器</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        private EmailHelper(string mailFrom, string[] mailTo, string mailSubject, string mailBody,
            string smtpServer, string userName, string password)
            : this(mailFrom, mailFrom, mailTo, mailSubject, mailBody, null, smtpServer, userName, password)
        {
        }

        /// <summary>
        /// 邮件发送类
        /// </summary>
        /// <param name="mailFrom">发件人地址</param>
        /// <param name="displayName">显示的名称</param>
        /// <param name="mailTo">收件人地址</param>
        /// <param name="mailSubject">邮件主题</param>
        /// <param name="mailBody">邮件正文</param>
        /// <param name="attachments">附件,多个时用逗号隔开(可为空)</param>
        /// <param name="smtpServer">SMTP 服务器</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        private EmailHelper(string mailFrom, string[] mailTo, string mailSubject, string mailBody,
            string[] attachments, string smtpServer, string userName, string password)
            : this(mailFrom, mailFrom, mailTo, mailSubject, mailBody,
            attachments, smtpServer, userName, password)
        {
        }

        /// <summary>
        /// 邮件发送类
        /// </summary>
        /// <param name="mailFrom">发件人地址</param>
        /// <param name="displayName">显示的名称</param>
        /// <param name="mailTo">收件人地址</param>
        /// <param name="mailSubject">邮件主题</param>
        /// <param name="mailBody">邮件正文</param>
        /// <param name="attachments">附件,多个时用逗号隔开(可为空)</param>
        /// <param name="smtpServer">SMTP 服务器</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        private EmailHelper(string mailFrom, string displayName, string[] mailTo, string mailSubject, string mailBody,
            string[] attachments, string smtpServer, string userName, string password)
            : this(mailFrom, displayName, mailTo, null, null, mailSubject, mailBody,
            attachments, smtpServer, 25, userName, password, false)
        {
        }

        /// <summary>
        /// 邮件发送类
        /// </summary>
        /// <param name="mailFrom">发件人地址</param>
        /// <param name="displayName">显示的名称</param>
        /// <param name="mailTo">收件人地址</param>
        /// <param name="mailCc">抄送,多个收件人用逗号隔开(可为空)</param>
        /// <param name="mailBcc">密件抄送,多个收件人用逗号隔开(可为空)</param>
        /// <param name="mailSubject">邮件主题</param>
        /// <param name="mailBody">邮件正文</param>
        /// <param name="attachments">附件,多个时用逗号隔开(可为空)</param>
        /// <param name="smtpServer">SMTP 服务器</param>
        /// <param name="smtpPort">发送端口号(默认为 25)</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="smtpSsl">是否使用安全套接字层 (SSL) 加密连接</param>
        private EmailHelper(string mailFrom, string displayName, string[] mailTo, string[] mailCc, string[] mailBcc, string mailSubject, string mailBody,
            string[] attachments, string smtpServer, int smtpPort, string userName, string password, bool smtpSsl)
        {
            MailObject = new MailMessage();
            mMailFrom = mailFrom;
            mMailDisplyName = displayName;
            mMailTo = mailTo;
            mMailCc = mailCc;
            mMailBcc = mailBcc;
            mMailSubject = mailSubject;
            mMailBody = mailBody;
            mMailAttachments = attachments;
            mSMTPServer = smtpServer;
            mSMTPPort = smtpPort;
            mSMTPUsername = userName;
            mSMTPPassword = password;
            mSMTPSSL = smtpSsl;
        }
        #endregion

        #region Methods

        /// <summary>
        /// 同步发送邮件
        /// </summary>
        /// <returns></returns>
        private Boolean Send()
        {
            return SendMail(false, null);
        }

        /// <summary>
        /// 异步发送邮件
        /// </summary>
        /// <param name="userState">异步任务的唯一标识符</param>
        /// <returns></returns>
        public void SendAsync(object userState)
        {
            SendMail(true, userState);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="isAsync">是否异步发送邮件</param>
        /// <param name="userState">异步任务的唯一标识符，当 isAsync 为 True 时必须设置该属性， 当 isAsync 为 False 时可设置为 null</param>
        /// <returns></returns>
        private Boolean SendMail(bool isAsync, object userState)
        {
            #region 设置属性值

            string[] mailTos = mMailTo;
            string[] mailCcs = mMailCc;
            string[] mailBccs = mMailBcc;
            string[] attachments = mMailAttachments;

            // build the email message
            MailMessage Email = new MailMessage();
            MailAddress MailFrom = new MailAddress(mMailFrom, mMailDisplyName);
            Email.From = MailFrom;
            Email.BodyEncoding = System.Text.Encoding.GetEncoding("gb2312");        

            if (mailTos != null)
            {
                foreach (string mailto in mailTos)
                {
                    if (!string.IsNullOrEmpty(mailto))
                    {
                        Email.To.Add(mailto);
                    }
                }
            }

            if (mailCcs != null)
            {
                foreach (string cc in mailCcs)
                {
                    if (!string.IsNullOrEmpty(cc))
                    {
                        Email.CC.Add(cc);
                    }
                }
            }

            if (mailBccs != null)
            {
                foreach (string bcc in mailBccs)
                {
                    if (!string.IsNullOrEmpty(bcc))
                    {
                        Email.Bcc.Add(bcc);
                    }
                }
            }

            if (attachments != null)
            {
                foreach (string file in attachments)
                {
                    if (!string.IsNullOrEmpty(file))
                    {
                        Attachment att = new Attachment(file);
                        Email.Attachments.Add(att);
                    }
                }
            }

            Email.Subject = mMailSubject;
            Email.Body = mMailBody;
            Email.Priority = mPriority;
            Email.IsBodyHtml = mIsBodyHtml;

            // Smtp Client
            SmtpClient SmtpMail = new SmtpClient(mSMTPServer, mSMTPPort);
            SmtpMail.Credentials = new NetworkCredential(mSMTPUsername, mSMTPPassword);
            SmtpMail.EnableSsl = mSMTPSSL;
            //SmtpMail.UseDefaultCredentials = false;

            SmtpMail.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

            #endregion

            //try
            //{
            if (!isAsync)
            {
                SmtpMail.Send(Email);
                mailSent = true;
            }
            else
            {
                userState = (userState == null)? Guid.NewGuid() : userState;
                SmtpMail.SendAsync(Email, userState);
            }
            //}
            //catch (SmtpFailedRecipientsException ex)
            //{
            //    mailSent = false;
            //}
            //catch (Exception ex)
            //{
            //    mailSent = false;
            //}

            return mailSent;
        }

        private void SendCompletedCallback(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            String token = (string)e.UserState;
            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
                mailSent = false;
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
                mailSent = false;
            }
            else
            {
                Console.WriteLine("Message sent.");
                mailSent = false;
            }
            mailSent = true;
        }

        #endregion

        #region 发送邮件(多个之间用逗号隔开)
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="Email">邮箱号码</param>
        /// <param name="Type">获取邮件内容的编码</param>
        /// <param name="model">替换字段</param>
        /// <returns></returns>
        public static bool Send(string Email, EnumSendType  MailSendType, Model.MsgHelper modelMsgHelper)
        {
            //先获取邮件内容
            BLL.ConfigMessageEmail bllEmail = new GK2010.BLL.ConfigMessageEmail();
            Model.ConfigMessageEmail modelEmail = bllEmail.GetModel(MailSendType.ToString());
            if (modelEmail != null)
            {
                string strTitle = modelEmail.Title;
                string strDetail = modelEmail.Detail;
                strDetail = MsgHelper.Replace(strDetail, modelMsgHelper);

                EmailHelper smtp = new EmailHelper(Email.Split(','), strTitle, strDetail);
                smtp.MailDisplyName = "工控商城";
                smtp.IsBodyHtml = true;
                smtp.Priority = System.Net.Mail.MailPriority.Normal;
                return smtp.Send();
            }
            else
            {
                //MsgHelper.SendError(txtError, "EmailValidSendEmailContentError");
                return false;
            }
        }
        #endregion

        #region 发送激活邮件
        /// <summary>
        /// 发送激活邮件
        /// </summary>
        /// <returns></returns>
        public static bool SendActive(int UserID,string Email)
        {
            Guid g = Guid.NewGuid();
            string ActiveCode = g.ToString();//激活码

            #region 插入数据库
            GK2010.Model.MemberValid model = new GK2010.Model.MemberValid();
            model.ValidType = EnumSendType.Valid.GetHashCode();
            model.ValidValue = Email;
            model.ActiveCode = ActiveCode;
            model.StartDate = DatetimeHelper.Now;
            model.EndDate = DatetimeHelper.NowAfterOneDay;
            model.UserID = UserID;

            GK2010.BLL.MemberValid bll = new GK2010.BLL.MemberValid();
            int ret = bll.Add(model);
            #endregion

            #region 发送邮件
            if (ret > 0)
            {
                //发送
                Model.MsgHelper modelMsgHelper = new GK2010.Model.MsgHelper();
                modelMsgHelper.UserName = BLL.Member.GetUserName(UserID);
                modelMsgHelper.UserID = UserID.ToString();
                modelMsgHelper.Email = Email;
                modelMsgHelper.ActiveUrl = "http://www." + Common.ConfigHelper.Config.WebDomain + "/register_active.aspx";
                modelMsgHelper.ActiveCode = ActiveCode;
                modelMsgHelper.Now = DateTime.Now.ToString();
                modelMsgHelper.YYYYMMDD = DateTime.Now.ToString("yyyy年MM月dd日");
                bool OK = EmailHelper.Send(Email, EnumSendType.Valid, modelMsgHelper);
                return OK;
            }
            else
            {
                return false;//激活码生成失败

            }
            #endregion
        }
        #endregion
        
    }

    #endregion
}
