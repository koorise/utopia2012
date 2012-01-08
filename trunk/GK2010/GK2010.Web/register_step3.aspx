<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true"
    CodeBehind="register_step3.aspx.cs" Inherits="GK2010.Web.register_step3" %>

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
                            <img src="/images/tubiao02.jpg" width="16" height="16" />
                        </td>
                        <td>
                            查看激活邮件
                        </td>
                        <td>
                            <img src="/images/tubiao03_3.jpg" width="16" height="16" />
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
            <table class="Bd f14 h300 md_center wp80" align="center">
                <tr>
                    <td width="113">
                        <img src="/images/sc01.gif" alt="图标" width="93" height="101" />
                    </td>
                    <td align="left">
                        <span class="g_color">恭喜您，你的邮箱<asp:Literal ID="txtEmail" runat="server"></asp:Literal>已激活成功。</span>
                    </td>
                    <td class="text_c">
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
