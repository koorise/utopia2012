<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>后台管理</title>
    <link href="../css/login/register.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <% server.execute  "../top_login.asp" %>
    <div class="main m_center">
        <div class="forgot">
            <div class="hd">
                <table>
                    <tr>
                        <td>
                         <img src="/images/tubiao01_1.jpg" width="16" height="16" />
                        </td>
                        <td>
                            输入用户名
                        </td>
                        <td>
                         <img src="/images/tubiao02_2.jpg" width="16" height="16" />
                        </td>
                        <td>
                            选择获取方式
                        </td>
                        <td>
                            <img src="/images/tubiao02.jpg" width="16" height="16" />
                        </td>
                        <td>
                            设定新的密码
                        </td>
                    </tr>
                </table>
            </div>
            <div class="bd">
              <div class="forgot_cont">
                <table cellpadding="0" cellspacing="0">
                  <tr>
                    <td class="f14 B h30"> 系统已经向您的xzlwj@126.com邮箱码发送了一组验证码，该验证码的有效期为半小时。&nbsp;</br>
                      <a href="" class="Aorange"> 现在就登录</a> </td>
                  </tr>
                  <tr>
                    <td> 请输入验证码：
                        <input type="text" id="username" name="username" class="text" tabindex="1" />
                    </td>
                  </tr>
                  <tr>
                    <td class="h100"> 如果您的邮箱不能正常接收验证码。</br>
                      您还可以通过填写<a href="" class="Ablue">找回密码申请表</a>，由工作人员协助您找回密码。 </td>
                  </tr>
                  <tr>
                    <td><input name="button" type="button" class="btn_org_small B" id="registsubmit" tabindex="8" value="下一步" />
                    </td>
                  </tr>
                </table>
              </div>
            </div>
            <div class="ft">
            </div>
        </div>
    </div>
    <% server.execute  "../foot_login.asp" %>
</body>
</html>
