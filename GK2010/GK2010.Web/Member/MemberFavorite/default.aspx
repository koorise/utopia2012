<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_Member.master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="GK2010.Web.Member.MemberFavorite._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Position" runat="server">
首页 > 我的工控 > 订单中心
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <h2>我的收藏夹</h2>
    <div class="bd_bd">
        <table cellpadding="0" cellspacing="0" class="wp95 m_center table3">
            <thead>
                <tr>
                    <td>
                        <input type="checkbox" name="checkbox" value="checkbox" />
                    </td>
                    <td>
                        产品名称
                    </td>
                    <td>
                        收藏时间
                    </td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <input type="checkbox" name="checkbox2" value="checkbox" />
                    </td>
                    <td>
                        米兰装饰
                    </td>
                    <td>
                        高小指
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3" class="text_c">
                        <input type="submit" name="Submit2" value="删除" class="btn_light_small" />
                        <input type="submit" name="Submit2" value="新增" class="btn_light_small" />
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
