<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true"
    CodeBehind="cart_step3.aspx.cs" Inherits="GK2010.Web.cart_step3" %>

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
                                <img src="/images/tubiao01_1.jpg" width="16" height="16" />
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
                                <img src="/images/tubiao03_3.jpg" width="16" height="16" />
                            </td>
                            <td>
                                成功提交订单
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="text_r">
                    &nbsp;
                </td>
            </tr>
        </table>
        <div class="plan mdT8">
            <div class="hd">
            </div>
            <div class="bd1">
                <h2>
                    &nbsp;感谢您在本店购物！您的订单已提交成功，请记住您的订单号: 2010100423607。
                </h2>
                <table class="wp90 m_center h200" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <img src="/images/tuu01.jpg" width="58" height="61" />
                        </td>
                        <td>
                            您选定的配送方式为: 中通速递 ，您选定的支付方式为: 银行汇款/转帐。您的应付款金额为: ￥512.00元
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            <div class="ft">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
