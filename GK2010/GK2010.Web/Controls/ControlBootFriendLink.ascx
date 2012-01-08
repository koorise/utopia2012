<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlBootFriendLink.ascx.cs" Inherits="GK2010.Web.Controls.ControlBootFriendLink" %>
<div class="main link mdT8 ">
    <h2><img src="/images/link_word.jpg" /></h2>
    <div class="link_text hz2 line_h_50">
        <asp:Repeater ID="RepeaterList" runat="server" OnItemDataBound="RepeaterList_ItemDataBound">
            <ItemTemplate><asp:HyperLink ID="HyperLinkTitle" runat="server"></asp:HyperLink></ItemTemplate>
            <SeparatorTemplate>|</SeparatorTemplate>
        </asp:Repeater>
    </div>
</div>