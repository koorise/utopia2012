<%@ Page Language="C#" MasterPageFile="~/ZSiteBaseAdmin.Master" AutoEventWireup="true"
    CodeBehind="Modify.aspx.cs" Inherits="GK2010.Web.Admin.Help.Modify" Title=""
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <h2 class="h1">
        ∞Ô÷˙±‡º≠</h2>
    <div class="admin_table mb10">
        <table cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td class="td1">
                    ¿‡±£∫
                </td>
                <td class="td2">
                    <asp:DropDownList ID="dropCategory" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="dropCategory" Display="Dynamic" ErrorMessage="±ÿÃÓ"  InitialValue="0"></asp:RequiredFieldValidator>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    √˚≥∆£∫
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input input_wa"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="±ÿÃÓ"></asp:RequiredFieldValidator>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <gk:AdminParam ID="AdminParam1" runat="server" />
            <tr>
                <td class="td1">
                    ∆¥“Ù£∫
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtTitleEn" runat="server" CssClass="input input_wa"></asp:TextBox>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    œÍœ∏–≈œ¢£∫
                </td>
                <td class="td2">
                    <fckeditorv2:FCKeditor ID="txtDetail" runat="server" BasePath="/admin/FCKeditor/"
                        Height="400px" ToolbarSet="Default" Width="100%">
                    </fckeditorv2:FCKeditor>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="td1">
                    ≈≈–Ú£∫
                </td>
                <td class="td2">
                    <asp:TextBox ID="txtSortID" runat="server" CssClass="input input_wa"></asp:TextBox>
                </td>
                <td class="td2">
                    <div class="help_a">
                    </div>
                </td>
            </tr>
            <gk:AdminTag ID="AdminTag1" runat="server" />
<gk:AdminSEO ID="AdminSEO1" runat="server" />
        </table>
    </div>
    <div class="tac mb10">
        <asp:Button ID="btnUpdate" runat="server" Text="–ﬁ ∏ƒ" CssClass="btn_yellow_big" OnClick="btnUpdate_Click">
        </asp:Button></div>
</asp:Content>
