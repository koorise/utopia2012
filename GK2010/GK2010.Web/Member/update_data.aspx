<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_Member.master" AutoEventWireup="true"
    CodeBehind="update_data.aspx.cs" Inherits="GK2010.Web.Member.update_data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Position" runat="server">
    首页 > 我的工控 > 修改资料
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <div class="cer1">
        <h2 class="h2  wp90">
            资料修改</h2>
        <div class="md10 pdL10">
            <table border="0" cellpadding="0" cellspacing="2" class="wp90 m_center ">
                <tr class="tr1">
                    <td colspan="3">
                        帮助我们完善您的个人信息，有助于我们未来根据您的情况提供更加个性化的服务；我们会对您的个人资料隐私加以保密。
                    </td>
                </tr>
                <tr class="tr1">
                    <td class="td1 w100">
                        用户名：
                    </td>
                    <td class="td2">
                        <input name="Input2" class="input w120" maxlength="10" />
                    </td>
                    <td class="td2">
                        &nbsp;
                    </td>
                </tr>
                <tr class="tr1">
                    <td class="td1">
                        电子邮件：
                    </td>
                    <td class="td2">
                        <input name="Input" class="input w120" maxlength="10" />
                    </td>
                    <td class="td2">
                        &nbsp;
                    </td>
                </tr>
                <tr class="tr1">
                    <td class="td1">
                        公司名称：
                    </td>
                    <td class="td2">
                        <input name="Input3" class="input w120" maxlength="10" />
                    </td>
                    <td class="td2">
                        &nbsp;
                    </td>
                </tr>
                <tr class="tr1">
                    <td class="td1">
                        姓名：
                    </td>
                    <td class="td2">
                        <input name="Input32" class="input w120" maxlength="10" />
                    </td>
                    <td class="td2">
                        &nbsp;
                    </td>
                </tr>
                <tr class="tr1">
                    <td class="td1">
                        手机：
                    </td>
                    <td class="td2">
                        <input name="Input33" class="input w120" maxlength="10" />
                    </td>
                    <td class="td2">
                        &nbsp;
                    </td>
                </tr>
                <tr class="tr1">
                    <td class="td1">
                        电话：
                    </td>
                    <td class="td2">
                        <input name="Input22" class="input w120" maxlength="10" />
                    </td>
                    <td class="td2">
                        &nbsp;
                    </td>
                </tr>
                <tr class="tr1">
                    <td class="td1">
                        传真：
                    </td>
                    <td class="td2">
                        <input name="Input23" class="input w120" maxlength="10" />
                    </td>
                    <td class="td2">
                        &nbsp;
                    </td>
                </tr>
                <tr class="tr1">
                    <td class="td1">
                        地址：
                    </td>
                    <td class="td2">
                        <input name="Input24" class="input w120" maxlength="10" />
                    </td>
                    <td class="td2">
                        &nbsp;
                    </td>
                </tr>
                <tr class="tr1">
                    <td class="td1">
                        邮编：
                    </td>
                    <td class="td2">
                        <input name="Input3" class="input w120" maxlength="10" />
                    </td>
                    <td class="td2">
                        &nbsp;
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
                    <td class="td2">
                        &nbsp;
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
