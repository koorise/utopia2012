<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlBoot.ascx.cs" Inherits="GK2010.Web.Controls.ControlBoot" %>
<div class="main foot mar5">
    <div class="flinks">
        <asp:Repeater ID="RepeaterList" runat="server" OnItemDataBound="RepeaterList_ItemDataBound">
            <ItemTemplate><asp:HyperLink ID="HyperLinkTitle" runat="server"></asp:HyperLink></ItemTemplate>
            <SeparatorTemplate>|</SeparatorTemplate>
        </asp:Repeater>
    </div>                    
    <div class="copyright">
        <asp:Literal ID="txtCopyRight" runat="server"></asp:Literal>        
    </div>
</div>