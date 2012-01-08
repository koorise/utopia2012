<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true"
    CodeBehind="login.aspx.cs" Inherits="GK2010.Web.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/login/login.css" rel="stylesheet" type="text/css" />
    <title>用户登录 - <%=GK2010.Common.ConfigHelper.Config.WebName%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="main">
        <div class="message">首页 > 会员登录</div>
    </div>
    <div class="plan mdT8">
        <div class="hd">
        </div>
        <div class="bd1">
            <table class="wp95 m_center h200" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="h35">
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="bg03">
                    </td>
                    <td>
                        <table class="table">
                            <tr>
                                <td class="td1  text_r">
                                    如果您是新用户，请先<a href="/register.aspx" class="Aorange">注册</a>。
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="td2">
                                    <div class="login-box">
                                        <table class="wp95">
                                            <tr>
                                                <td class="label">
                                                    用户名：
                                                </td>
                                                <td class="field">
                                                    <asp:TextBox ID="txtUserName" cssclass="text" runat="server"></asp:TextBox>
                                                </td>
                                                <td class="status"><asp:RequiredFieldValidator ID="rfvUserName" ControlToValidate="txtUserName" runat="server" ErrorMessage="必填"></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td class="label">
                                                    密&nbsp; 码：
                                                </td>
                                                <td class="field">
                                                    <asp:TextBox ID="txtUserPwd" TextMode="Password" cssclass="text" runat="server"></asp:TextBox>
                                                </td>
                                                <td class="status"><asp:RequiredFieldValidator ID="rfvUserPwd" ControlToValidate="txtUserPwd" runat="server" ErrorMessage="必填"></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" class="text_c"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" class="text_c" style="height:30px; line-height:30px">
                                                    <asp:Button ID="btnLogin" runat="server" Text="登录"  cssclass="btn_light_small" 
                                                        onclick="btnLogin_Click" /> 新用户，请先<a href="/register.aspx" class="Aorange">注册</a>。                                              
                                                </td>
                                            </tr>
                                        </table>
                                        <div class="ft1">
                                            有任何疑问请访问帮助中心或者联系在线客服
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div class="ft">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
