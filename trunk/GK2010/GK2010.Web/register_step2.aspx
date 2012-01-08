<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true"
    CodeBehind="register_step2.aspx.cs" Inherits="GK2010.Web.register_step2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="main">
        <div class="message">首页 > 用户注册</div>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mdT8">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <table cellspacing="0" cellpadding="0" class="w350 flow_r">
                    <tr>
                        <td>
                            <img src="/images/tubiao01_1.jpg" width="16" height="16" />
                        </td>
                        <td>
                            填写注册信息
                        </td>
                        <td>
                            <img src="/images/tubiao02_2.jpg" width="16" height="16" />
                        </td>
                        <td>
                            查看激活邮件
                        </td>
                        <td>
                            <img src="/images/tubiao03.jpg" width="16" height="16" />
                        </td>
                        <td>
                            注册成功
                        </td>
                    </tr>
                </table>
            </td>
            <td class="text_r">
                &nbsp;
            </td>
        </tr>
    </table>
    <div class="plan mdT8">
        <div class="hd">
            <div class="hd_top">
            </div>
        </div>
        <div class="bd1">
            <table class="wp55 m_center" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="h100">
                        <img src="/images/tu02.gif" alt="" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="f16 text_c h50">
                        系统已向您的<asp:Label ID="txtEmail" runat="server" Text="" CssClass="blue B"></asp:Label>邮箱发了一份激活邮件，请您在48小时内完成激活。</td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="text_c h50"><asp:HyperLink ID="HL" runat="server" target="_blank">现在就进入邮箱查看</asp:HyperLink>
                    </td>
                    <td>
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
