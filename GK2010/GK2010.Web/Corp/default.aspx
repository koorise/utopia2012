<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel_Company.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GK2010.Web.Corp._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=SeoTitle %></title>
    <meta name="keywords" content="<%=SeoKeywords %>" />
    <meta name="description" content="<%=SeoDescription %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="message_position"><h2><asp:Literal ID="txtTitle" runat="server"></asp:Literal></h2></div>
    <div class="help-detailed"><asp:Literal ID="txtDetail" runat="server"></asp:Literal></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
