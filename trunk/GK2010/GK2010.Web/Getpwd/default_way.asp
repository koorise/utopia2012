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
                         <img src="/images/tubiao01.jpg" width="16" height="16" />
                        </td>
                        <td>
                            输入用户名
                        </td>
                        <td>
                         <img src="/images/tubiao02.jpg" width="16" height="16" />
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
              <div class="forgot_cont2 h90">
                <table>
                  <tr>
                    <td rowspan="3"><img src="/images/tel01_0.jpg" alt="手机" /> </td>
                    <td><h2> 用手机短信</h2></td>
                  </tr>
                  <tr>
                    <td><input name="button" type="button" class="btn_org_small1" onclick="location.href='mobile.asp'" tabindex="8" value="马上找回" />
                    </td>
                  </tr>
                  <tr>
                    <td></td>
                  </tr>
                </table>
                <table>
                  <tr>
                    <td rowspan="3"><img src="/images/email01.jpg" alt="邮箱" /> </td>
                    <td><h2> 通过保密邮箱</h2></td>
                  </tr>
                  <tr>
                    <td><input name="button2" type="button" class="btn_org_small1" onclick="location.href='email.asp'" tabindex="8" value="马上找回" />
                    </td>
                  </tr>
                  <tr>
                    <td></td>
                  </tr>
                </table>
                <table>
                  <tr>
                    <td rowspan="3"><img src="/images/ques01.jpg" alt="密保" /> </td>
                    <td><h2> 通过密码提示问题</h2></td>
                  </tr>
                  <tr>
                    <td><input name="button2" type="button" class="btn_org_small1" onclick="location.href='qa.asp'" tabindex="8" value="马上找回" />
                    </td>
                  </tr>
                  <tr>
                    <td></td>
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
