<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel_Help.master" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="GK2010.Web.Help.list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/page.css" rel="stylesheet" type="text/css" />
    <title><%=SeoTitle %></title>
    <meta name="keywords" content="<%=SeoKeywords %>" />
    <meta name="description" content="<%=SeoDescription %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="message_position"><h2><asp:Literal ID="txtCategory" runat="server"></asp:Literal></h2></div>
    <div class="list-help-links">
       <ul>
            <asp:Repeater ID="RepeaterList" runat="server" OnItemDataBound="RepeaterList_ItemDataBound">
                <ItemTemplate><li><asp:HyperLink ID="HyperLinkTitle" runat="server"></asp:HyperLink></li></ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div class="pages" >
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server"></webdiyer:AspNetPager>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
