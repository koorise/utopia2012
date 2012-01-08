<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_Member.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GK2010.Web.Member.MemberOrder._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Position" runat="server">
首页 > 我的工控 > 订单中心
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <div class="bd_bd">
        <h2>订单列表</h2>
        <table cellpadding="0" cellspacing="0" class="wp95 m_center table3">
            <thead>
                <tr>
                    <td>
                        订单编号
                    </td>
                    <td>
                        订单金额
                    </td>
                    <td>
                        订单状态
                    </td>
                    <td>
                        下单时间
                    </td>
                    <td>
                        详情
                    </td>
                    <td>
                        操作
                    </td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        00315
                    </td>
                    <td>
                        <strong>10000.00</strong>元
                    </td>
                    <td>
                        否
                    </td>
                    <td>
                        2010-10-22 22:29:01
                    </td>
                    <td>
                        <span class="red">产看</span>
                    </td>
                    <td>
                        取消
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
