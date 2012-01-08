<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_Member.master" AutoEventWireup="true"
    CodeBehind="changePassword.aspx.cs" Inherits="GK2010.Web.Member.changePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Position" runat="server">首页 > 我的工控 > 修改密码
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <div class="cer1">
        <h2 class="h2  wp90">
            密码由6-16个字符组成，为了您的账号安全，禁止使用全数字、全字母或连续字符作为密码。<span class="msg_comment_small Normal">&nbsp;密码设置技巧</span></h2>
        <div class="md10 pdL10">
            <table border="0" cellpadding="0" cellspacing="2" class="wp90 m_center ">
                <tr class="tr1">
                    <td class="td1 w100">
                        当前密码：
                    </td>
                    <td class="td2">
                        <input name="Input2" class="input w120" maxlength="10" />
                    </td>
                </tr>
                <tr class="tr1">
                    <td class="td1">
                        新密码：
                    </td>
                    <td class="td2">
                        <input name="Input" class="input w120" maxlength="10" />
                        <span class="STYLE4">6-16个字符，区分大小写，建议不要使用您的姓名或ID</span>
                    </td>
                </tr>
                <tr class="tr1">
                    <td class="td1">
                        确认新密码：
                    </td>
                    <td class="td2">
                        <input name="Input3" class="input w120" maxlength="10" />
                    </td>
                </tr>
                <tr class="tr1">
                    <td class="td1">
                        &nbsp;
                    </td>
                    <td class="td2">
                        <span class="tac  h35 wp75 md_center">
                            <input type="submit" name="Submit" value="确认" class="anniu01_small2" onclick="location.href='ok.asp'" />
                        </span>
                    </td>
                </tr>
            </table>
        </div>
        <div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
