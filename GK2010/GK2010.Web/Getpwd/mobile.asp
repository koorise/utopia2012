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
                            <img src="/images/tubiao03.jpg" width="16" height="16" />
                        </td>
                        <td>
                            设定新的密码
                        </td>
                    </tr>
                </table>
            </div>
            <div class="bd">
              <div class="forgot_cont">
                <table cellpadding="0" cellspacing="0" >
                  <tr>
                    <td class="label">请输入您的手机号：</td>
                    <td class="field"><input type="text" id="username" name="username" class="text" tabindex="1" /></td>
                    <td class="status"><label id="username_succeed" class="blank"></label></td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <td colspan="2"></td>
                  </tr>
                  <tr>
                    <td class="label" ></td>
                    <td class="field"><img src="/images/yanzheng01.jpg" alt="验证码" /> <a href="" class="Ablue">看不清？换一张</a> </td>
                    <td class="status"></td>
                  </tr>
                  <tr>
                    <td class="label">输入验证码：</td>
                    <td class="field"><input name="text" type="text"  class="text" tabindex="2"></td>
                    <td class="status"></td>
                  </tr>
                  <tr>
                    <td class="label">&nbsp;</td>
                    <td class="field"><input name="button" type="button" class="btn_org_small B" id="registsubmit" tabindex="8"  value="提交" />
                    </td>
                    <td ></td>
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
