<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel_Help.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GK2010.Web.Help._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=SeoTitle %></title>
    <meta name="keywords" content="<%=SeoKeywords %>" />
    <meta name="description" content="<%=SeoDescription %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="message_position"><h2>帮助中心</h2></div>
    <div class="list-help-links">
        <ul>
            <asp:Repeater ID="RepeaterList" runat="server" OnItemDataBound="RepeaterList_ItemDataBound">
                <ItemTemplate><li><asp:HyperLink ID="HyperLinkTitle" runat="server"></asp:HyperLink></li></ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
