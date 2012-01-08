<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlProductLeft.ascx.cs"
    Inherits="GK2010.Web.Controls.ControlProductLeft" %>
<div class="product_sort">
    <div class="hd">
    </div>
    <div id="YMenu-side">
        <ul class="YM-mainmnu">
            <asp:Repeater ID="RepeaterList" runat="server" OnItemDataBound="RepeaterList_ItemDataBound">
                <ItemTemplate>
                    <li class="YM-Tab">
                        <asp:HyperLink ID="HyperLinkTitle" runat="server"></asp:HyperLink>
                        <ul class="YM-submnu">
                            <asp:Repeater ID="RepeaterListChild" runat="server" OnItemDataBound="RepeaterListChild_ItemDataBound">
                                <ItemTemplate>
                                    <li>
                                        <asp:HyperLink ID="HyperLinkTitle" runat="server"></asp:HyperLink></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>

    <script language="javascript" type="text/javascript">
        <!--
        YAO.YTabs({
            tabs: YAO.getElByClassName('YM-Tab', 'li', 'YMenu-side'),
            contents: YAO.getElByClassName('YM-submnu', 'ul', 'YMenu-side'),
            hideAll: true
        });
        //-->
    </script>

    <div class="product_bottom clear"><img src="/images/chanp_bottom.jpg" /></div>
</div>
