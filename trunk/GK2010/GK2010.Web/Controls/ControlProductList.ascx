<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlProductList.ascx.cs" Inherits="GK2010.Web.Controls.ControlProductList" %>
<div class="hot_buy">
    <div class="hd"></div>
    <div class="bd mdT10">
        <table class="wp100 mdT10">
            <tr>
                <td>
                    <table width="335" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td rowspan="3" valign="top">
                                <a href=" " target="_blank">
                                    <img src="/images/chanp_pc01.jpg" alt="MOTO XT702" class="img1"></a>
                            </td>
                            <td class="blue pdL10" valign="top">
                                <span class="B">TCL L32E06</span><br />
                                完美的视觉盛宴，整机超轻超薄，简 约时尚，高效能，支持全高清显示， 个性化视听效果。
                            </td>
                        </tr>
                        <tr>
                            <td class="pdL10">
                                市场价：<s>4080</s><br />
                                今日特价：<span class="f20 orange B">3138</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="pdL10">
                                <img src="/images/button12.jpg" alt="" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="10">
                    <img src="/images/line06.jpg" alt="" />
                </td>
                <td>
                    <table width="335" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td rowspan="4" valign="top">
                                <a href=" " target="_blank">
                                    <img src="/images/chanp_pc01.jpg" alt="MOTO XT702" class="img1"></a>
                            </td>
                            <td class="blue pdL10" valign="top">
                                <span class="B">TCL L32E06</span><br />
                                完美的视觉盛宴，整机超轻超薄，简 约时尚，高效能，支持全高清显示， 个性化视听效果。
                            </td>
                        </tr>
                        <tr>
                            <td class="pdL10">
                                市场价：<s>4080</s>;
                            </td>
                        </tr>
                        <tr>
                            <td class="pdL10">
                                今日特价：<span class="f20 orange B">3138</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="pdL10">
                                <img src="/images/button12.jpg" alt="" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</div>
<div class="list_tit wp100 mdT8">
    <table class="wp100 solid1 h30">
        <tr>
            <td class="blue B h3 f14">
                &nbsp;<asp:Literal ID="txtCategory" runat="server"></asp:Literal>-商品筛选
            </td>
        </tr>
    </table>
</div>
<div class="hot_list mdT8">
    <table class="wp100 ">
        <tr>
            <td style="width: 100px" align="right" valign="top">
                <div style="padding-top: 3px; font-weight: bold">
                    类别：</div>
            </td>
            <td valign="top" align="left" class="virtual">
                <asp:Repeater ID="RepeaterListCategory" runat="server" OnItemDataBound="RepeaterListCategory_ItemDataBound">
                    <ItemTemplate><div><asp:HyperLink ID="HyperLinkTitle" runat="server"></asp:HyperLink></div></ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <asp:Repeater ID="RepeaterList" runat="server" OnItemDataBound="RepeaterList_ItemDataBound">
        <ItemTemplate>
        <tr>
            <td style="width: 100px" align="right" valign="top">
                <div style="padding-top: 3px; font-weight: bold"><%#Eval("Title") %>：</div>
            </td>
            <td valign="top" align="left" class="virtual">
                <asp:Repeater ID="RepeaterListChild" runat="server" OnItemDataBound="RepeaterListChild_ItemDataBound">
                    <ItemTemplate>
                        <div><asp:HyperLink ID="HyperLinkTitle" runat="server"></asp:HyperLink></div>
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>

</div>
<div class="list_tit wp100 mdT8">
    <table class="wp100 solid1 h30 f14">
        <tr>
            <td class="blue B h3">&nbsp;显示方式</td>
            <td align="right" style="padding-right:10px; padding-top:3px">
                <asp:HyperLink ID="HyperLinkShowTypeList" runat="server"></asp:HyperLink>
                <asp:HyperLink ID="HyperLinkShowTypePic" runat="server"></asp:HyperLink>
            </td>
        </tr>
    </table>
</div>
