<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true"
    CodeBehind="cart.aspx.cs" Inherits="GK2010.Web.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="/css/member.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="main">
        <div class="message">
            首页 > 我的工控 > 订单中心</div>
    </div>
    <div class="member mdT8">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <img src="/images/car02.jpg" width="156" height="51" />
                </td>
                <td>
                    <table cellspacing="0" cellpadding="0" class="w350 flow_r">
                        <tr>
                            <td>
                                <img src="/images/tubiao01.jpg" width="16" height="16" />
                            </td>
                            <td>
                                我的购物车
                            </td>
                            <td>
                                <img src="/images/tubiao02.jpg" width="16" height="16" />
                            </td>
                            <td>
                                确认购买信息
                            </td>
                            <td>
                                <img src="/images/tubiao03.jpg" width="16" height="16" />
                            </td>
                            <td>
                                成功提交订单
                            </td>
                        </tr>
                    </table>
                </td>
               
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table1">
            <thead>
                <tr>
                    <td>
                        商品
                    </td>
                    <td>
                        名称
                    </td>
                    <td>
                        型号
                    </td>
                    <td>
                        原价格
                    </td>
                    <td>
                        会员价
                    </td>
                    <td>
                        数量
                    </td>
                    <td>
                        金额
                    </td>
                    <td>
                        积分
                    </td>
                    <td>
                        删除
                    </td>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RepeaterCartList" runat="server" 
                    onitemdatabound="RepeaterCartList_ItemDataBound">
                <ItemTemplate>
                    <tr class="tr1">
                    <td class="td1">
                        <asp:Literal ID="lit_img" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:Literal ID="lit_title" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:Literal ID="lit_DefaultType" runat="server"></asp:Literal>
                    </td>
                    <td>
                        ￥<asp:Literal ID="lit_oldPrice" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <span class="red">￥<asp:Literal ID="lit_memberPrice" runat="server"></asp:Literal></span>
                    </td>
                    <td>
                        <input type="text" name="textfield" id="TotalNum<%# Eval("ID") %>" class="input w20" value="<%# Eval("Num") %>") onchange="UpdateCartNum('<%# Eval("CartNum") %>',<%# Eval("ID") %>)" />
                    </td>
                    <td>
                        <span class="red">￥<asp:Literal ID="lit_TotalPrice" runat="server"></asp:Literal></span>
                    </td>
                    <td>
                        <asp:Literal ID="lit_totalJF" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:Literal ID="lit_del" runat="server"></asp:Literal>
                    </td>
                </tr>
                </ItemTemplate>
                </asp:Repeater>
                <tr class="tr1">
                    <td colspan="9" class="text_r">
                        产品总件数：<span class="red"><asp:Literal ID="lit_totalNum" runat="server"></asp:Literal></span>件 赠送积分：<span class="red"><asp:Literal
                            ID="lit_totalJF" runat="server"></asp:Literal></span>分 
                        产品的金额总计(不含运费）:<span class="red"><asp:Literal ID="lit_totalProductsPrice" 
                            runat="server"></asp:Literal></span>
                    </td>
                </tr>
            </tbody>
            </table>
            <div style="height:5px; overflow:hidden"></div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <input type="submit" name="Submit" value="继续购物" class="btn_blue_big" />
                    <input type="submit" name="Submit2" value="清空购物车" class="btn_blue_big" />
                </td>
                <td>
                    
                </td>
                <td class="text_r">
                    <a href="cart_step2.aspx"><img src="/images/button10.jpg" /></a>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
