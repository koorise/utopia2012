<%@ Page Title="" Language="C#" MasterPageFile="~/ZPageBase_MainChannel.master" AutoEventWireup="true"    CodeBehind="default.aspx.cs" Inherits="GK2010.Web.Program._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="/css/news.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="main">
        <div class="plan mdT8">
            <div class="hd">
            </div>
            <div class="bd">
                <h2><img src="/images/tit01.gif" alt="适用行业" /></h2>
                <div class="bd_bd">
                     <asp:Repeater ID="RepeaterListIndustry" runat="server" OnItemDataBound="RepeaterListIndustry_ItemDataBound">
                        <ItemTemplate>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="td1" valign="top" height="70">
                                        <asp:Literal ID="txtPicture" runat="server"></asp:Literal>
                                    </td>
                                    <td valign="top">
                                        <asp:HyperLink ID="HyperLinkTitle" runat="server" CssClass="B"></asp:HyperLink><br />
                                        <asp:Repeater ID="RepeaterListIndustryChild" runat="server" OnItemDataBound="RepeaterListIndustryChild_ItemDataBound">
                                            <ItemTemplate><asp:HyperLink ID="HyperLinkTitle" runat="server"></asp:HyperLink></ItemTemplate>
                                            <SeparatorTemplate>&nbsp;|&nbsp;</SeparatorTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>  
                </div>
                <h2><img src="/images/tit02.gif" alt="应用介质" /></h2>
                <div class="bd_bd">
                    <asp:Repeater ID="RepeaterListMedium" runat="server" OnItemDataBound="RepeaterListMedium_ItemDataBound">
                        <ItemTemplate>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="td1" valign="top" height="70">
                                        <asp:Literal ID="txtPicture" runat="server"></asp:Literal>
                                    </td>
                                    <td valign="top">
                                        <asp:HyperLink ID="HyperLinkTitle" runat="server" CssClass="B"></asp:HyperLink><br />
                                        <asp:Repeater ID="RepeaterListMediumChild" runat="server" OnItemDataBound="RepeaterListMediumChild_ItemDataBound">
                                            <ItemTemplate><asp:HyperLink ID="HyperLinkTitle" runat="server"></asp:HyperLink></ItemTemplate>
                                            <SeparatorTemplate>&nbsp;|&nbsp;</SeparatorTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>  
                </div>
            </div>
            <div class="ft">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BootOther" runat="server">
</asp:Content>
