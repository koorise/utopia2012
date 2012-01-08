<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlAdminParamSearch.ascx.cs" Inherits="GK2010.Web.Controls.ControlAdminParamSearch" %>
<asp:DropDownList ID="dropIndexFlag" runat="server">
    <asp:ListItem Text="总首页" Value="-1"></asp:ListItem>
    <asp:ListItem Text="是" Value="1"></asp:ListItem>
    <asp:ListItem Text="否" Value="0"></asp:ListItem>
</asp:DropDownList>
<asp:DropDownList ID="dropHotFlag" runat="server">
    <asp:ListItem Text="频道首页焦点" Value="-1"></asp:ListItem>
    <asp:ListItem Text="是" Value="1"></asp:ListItem>
    <asp:ListItem Text="否" Value="0"></asp:ListItem>
</asp:DropDownList>
<asp:DropDownList ID="dropChannelFlag" runat="server">
    <asp:ListItem Text="频道首页推荐" Value="-1"></asp:ListItem>
    <asp:ListItem Text="是" Value="1"></asp:ListItem>
    <asp:ListItem Text="否" Value="0"></asp:ListItem>
</asp:DropDownList>
<asp:DropDownList ID="dropCommendFlag" runat="server">
    <asp:ListItem Text="频道列表页推荐" Value="-1"></asp:ListItem>
    <asp:ListItem Text="是" Value="1"></asp:ListItem>
    <asp:ListItem Text="否" Value="0"></asp:ListItem>
</asp:DropDownList>
