<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="GK2010.Web.Admin.login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>工控商城网-后台登录</title>
    <link href="css/login.css" type="text/css" rel="stylesheet">
    <script>
			function doCheck()
			{
				var userName = document.getElementById("txtUsername");
				var userPwd = document.getElementById("txtPass");
				var checkCode = document.getElementById("txtCheckCode");
				
				if (userName.value == "") 
				{
					alert("请输入用户名!");
					userName.select();
					return false;
				}
				
				if (userPwd.value == "") 
				{
					alert("请输入密码!");
					userPwd.select();
					return false;
				}
				
				if (checkCode.value == "") 
				{
					alert("请输入验证码!");
					checkCode.select();
					return false;
				}
				return true;
			}
    </script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <table width="662" height="312" border="0" align="center" cellpadding="0" cellspacing="0"
        background="Images/login_bg.jpg">
        <tbody>
            <tr>
                <td align="center">
                    <table width="570" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <table cellspacing="0" cellpadding="0" width="570" border="0">
                                    <tbody>
                                        <tr>
                                            <td width="245" height="70" align="center" valign="top">
                                            </td>
                                            <td align="right" valign="top">
                                                <br>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="20">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td height="20">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table width="520" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="120" align="center" valign="middle">
                                            <table width="300" border="0" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td width="53" height="30" align="left" valign="middle" class="shei12">
                                                            用户名：
                                                        </td>
                                                        <td width="181" align="left" valign="middle" class="shei12">
                                                            <input class="hei11" tabindex="1" maxlength="22" size="22" name="user" id="txtUsername"
                                                                runat="server" style="width: 140px; height: 19px">
                                                            <asp:RequiredFieldValidator ControlToValidate="txtUsername" ErrorMessage="*" ID="RequiredFieldValidator1"
                                                                runat="server" class="huang12"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td width="66" rowspan="3" align="center" valign="top">
                                                            <table width="40" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="images/login_p_img11.gif"
                                                                OnClick="btnLogin_Click"></asp:ImageButton><a href="#"></a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="30" align="left" valign="middle" class="shei12">
                                                            密&nbsp;&nbsp; 码：
                                                        </td>
                                                        <td height="30" align="left" valign="middle" class="shei12">
                                                            <input name="user" type="password" class="hei11" tabindex="1" size="17" maxlength="22"
                                                                id="txtPass" runat="server" style="width: 140px; height: 19px">
                                                            <asp:RequiredFieldValidator ControlToValidate="txtPass" ErrorMessage="*" ID="RequiredFieldValidator2"
                                                                runat="server" class="huang12"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="30" align="left" valign="middle" class="shei12">
                                                            验证码：
                                                        </td>
                                                        <td height="30" align="left" valign="middle">
                                                            <input class="hei11" id="txtCheckCode" style="width: 64px; height: 19px" tabindex="1"
                                                                maxlength="22" size="5" name="txtCheckCode" runat="server">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="/CheckCode.aspx" BackColor="White">
                                                            </asp:Image>
                                                            <asp:RequiredFieldValidator ControlToValidate="txtCheckCode" ErrorMessage="*" ID="RequiredFieldValidator3"
                                                                runat="server" class="huang12"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="20">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="50" align="center" class="bai12">
                                            &nbsp;版权所有 工控商城网<br>Copyright(C) 2011-2012 All Rights Reserved.
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    <br />
    </form>
</body>
</html>
