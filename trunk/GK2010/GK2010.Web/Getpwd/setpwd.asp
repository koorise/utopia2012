<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>��̨����</title>
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
                            �����û���
                        </td>
                        <td>
                         <img src="/images/tubiao02.jpg" width="16" height="16" />
                        </td>
                        <td>
                            ѡ���ȡ��ʽ
                        </td>
                        <td>
                            <img src="/images/tubiao03_3.jpg" width="16" height="16" />
                        </td>
                        <td>
                            �趨�µ�����
                        </td>
                    </tr>
                </table>
            </div>
            <div class="bd">
              <div class="forgot_cont">
                <table class="mdL40">
                  <tr>
                    <td class="label"> ���������룺</td>
                    <td class="field"><input id="pwd" class="text" name="pwd1" size="20" tabindex="2" 
                                type="password" />
                    </td>
                    <td class="status"></td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <td colspan="2"></td>
                  </tr>
                  <tr>
                    <td class="label"> ȷ�������룺</td>
                    <td class="field"><input id="Password1" class="text" name="pwd" tabindex="2" type="password" /></td>
                    <td class="status"></td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <td colspan="2"></td>
                  </tr>
                  <tr>
                    <td class="label">&nbsp;</td>
                    <td class="field"><input name="button" type="button" class="btn_org_small B" id="registsubmit" tabindex="8"  value="�ύ" />
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
