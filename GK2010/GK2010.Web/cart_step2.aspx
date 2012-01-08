<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true" CodeBehind="cart_step2.aspx.cs" Inherits="GK2010.Web.cart_step2" %>
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
                                    <img src="/images/tubiao02_2.jpg" width="16" height="16" />
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
                    <td class="text_r">
                        
                    </td>
                </tr>
            </table>
            <div class="plan mdT8">
                <div class="hd">
                </div>
                <div class="bd1">
                    <%-- <h2>
                        <span><a href="">[管理收货人地址] </a><a href="">[关闭]</a></span> &nbsp;收货人信息（以下带*的为必填内容!）</h2>
                   <table border="0" cellspacing="0" cellpadding="0" class="wp95 m_center table2">
                        <tr>
                            <td class="td1">
                                <em>* </em>公司名称：
                            </td>
                            <td>
                                <input type="text" name="textfield27" class="input w200" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>收货人姓名：
                            </td>
                            <td>
                                <input type="text" name="textfield26" class="input w200" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>省 份：
                            </td>
                            <td>
                                <select name="select">
                                    <option>江苏省</option>
                                </select>
                                省
                                <select name="select2">
                                    <option>南京</option>
                                </select>
                                市
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>地 址：
                            </td>
                            <td>
                                <input type="text" name="textfield2" class="input w200" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>邮 编：
                            </td>
                            <td>
                                <input type="text" name="textfield22" class="input w200" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>固定电话：
                            </td>
                            <td>
                                <input type="text" name="textfield23" class="input w200" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>手机号码：
                            </td>
                            <td>
                                <input type="text" name="textfield24" class="input w200" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>电子邮件：
                            </td>
                            <td>
                                <input type="text" name="textfield25" class="input w200" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <input type="submit" name="Submit" value="保存收货人信息" class="btn_org_big1 B" />
                            </td>
                        </tr>
                    </table>--%>
                    <div id="part_consignee"><asp:Literal ID="txtConsignee" runat="server"></asp:Literal></div>
                    <%--<h2>
                        <span><a href="">修改</a><a href=""> [关闭]</a></span> &nbsp;支付及配送方式</h2>
                    <table class="wp95 m_center table2" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="td1">
                                <em>* </em>支付方式：
                            </td>
                            <td>
                                在线支付
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>配送方式：
                            </td>
                            <td>
                                快递运输
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>运 费：
                            </td>
                            <td>
                                <div>
                                    <div>
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td align="right">
                                                    </td>
                                                    <td>
                                                        0.00
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>--%>
                    <div id="part_payTypeAndShipType"><asp:Literal ID="txtPayTypeAndShipType" runat="server"></asp:Literal></div>
                    <%--<h2>
                        <span><a href="">修改</a><a href=""> [关闭]</a></span> &nbsp;发票信息</h2>
                    <table class="wp95 m_center table2" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="td1">
                                <em>* </em>发票类型：
                            </td>
                            <td>
                                普通发票
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>发票抬头：
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>发票内容：
                            </td>
                            <td>
                                <div>
                                    <div>
                                        <form id="frmInvoice" name="frmInvoice">
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        产品明细
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        </form>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>--%>
                    <div id="part_invoice">  <asp:Literal ID="txtInvoice" runat="server"></asp:Literal></div>
                    <%--<h2>
                        <span><a href="">修改</a><a href=""> [关闭]</a></span> &nbsp;发票邮寄信息</h2>
                    <table border="0" cellspacing="0" cellpadding="0" class="wp95 m_center table2">
                        <tr>
                            <td class="td1">
                                <em>* </em>公司名称：
                            </td>
                            <td>
                                <input type="text" name="textfield27" class="input w200" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>收货人姓名：
                            </td>
                            <td>
                                <input type="text" name="textfield26" class="input w200" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>省 份：
                            </td>
                            <td>
                                <select name="select">
                                    <option>江苏省</option>
                                </select>
                                省
                                <select name="select2">
                                    <option>南京</option>
                                </select>
                                市
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>地 址：
                            </td>
                            <td>
                                <input type="text" name="textfield2" class="input w200" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>邮 编：
                            </td>
                            <td>
                                <input type="text" name="textfield22" class="input w200" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>固定电话：
                            </td>
                            <td>
                                <input type="text" name="textfield23" class="input w200" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>手机号码：
                            </td>
                            <td>
                                <input type="text" name="textfield24" class="input w200" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td1">
                                <em>* </em>电子邮件：
                            </td>
                            <td>
                                <input type="text" name="textfield25" class="input w200" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <input type="submit" name="Submit" value="保存收货人信息" class="btn_org_big1 B" />
                            </td>
                        </tr>
                    </table>--%>
                    <div id="part_invoiceMail"><asp:Literal ID="txtInvoiceMail" runat="server"></asp:Literal></div>
                    <h2>
                        <span><a href="">修改</a><a href=""> [关闭]</a></span> &nbsp;商品清单</h2>
                    <table cellpadding="0" cellspacing="0" class="wp95 m_center table3">
                        <thead>
                            <tr>
                                <td>
                                    序号
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
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterCartList" runat="server" 
                                onitemdatabound="RepeaterCartList_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                <td>
                                    <asp:Literal ID="lit_xuhao" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lit_title" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lit_DefaultType" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <span class="red">￥<asp:Literal ID="lit_oldPrice" runat="server"></asp:Literal></span>
                                </td>
                                <td>
                                    <span class="red">￥<asp:Literal ID="lit_memberPrice" runat="server"></asp:Literal></span>
                                </td>
                                <td>
                                    <%# Eval("Num") %>
                                </td>
                                <td>
                                    <span class="red">￥<asp:Literal ID="lit_TotalPrice" runat="server"></asp:Literal></span>
                                </td>
                                <td>
                                    <asp:Literal ID="lit_totalJF" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <h2>
                        &nbsp;结算信息</h2>
                    <table class="wp95 m_center " border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                该订单完成后，您将获得 <span class="red B">
                                    <asp:Literal ID="lit_totalJF" runat="server"></asp:Literal></span> 积分 ，以及价值 <span class="red B">￥0.00</span>元的红包。<br />
                                商品总价: <span class="red B">￥<asp:Literal ID="lit_totalProductsPrice" runat="server"></asp:Literal></span>元 + 配送费用: <span class="red B">￥32.00</span>元
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <br />
                                应付款金额: <span class="red B">￥512.00</span>元
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnSubOrder" CssClass="btn_org_big1 B" runat="server" 
                                    Text="提交订单" onclick="btnSubOrder_Click" />
                                 
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
