<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlBootHelp.ascx.cs"
    Inherits="GK2010.Web.Controls.ControlBootHelp" %>

<div class="main service">
    <asp:Repeater ID="rptCategory" runat="server" 
        onitemdatabound="rptCategory_ItemDataBound">
        <ItemTemplate>
            <dl class="fore<%# (Container.ItemIndex + 1) %>">
                <dt><b></b><strong><asp:Literal ID="LiteralTitle" runat="server"></asp:Literal></strong></dt>
                <dd>
                    <asp:Repeater ID="RepeaterList" runat="server">
                        <ItemTemplate>
                            <div class="item"><asp:HyperLink ID="helpUrl" runat="server"><asp:Literal ID="helpTitle" runat="server"></asp:Literal></asp:HyperLink></div>
                        </ItemTemplate>
                    </asp:Repeater>
                </dd>
            </dl>
        </ItemTemplate>
    </asp:Repeater>
</div>